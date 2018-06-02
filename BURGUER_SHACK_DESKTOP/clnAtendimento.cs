﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_POWERUP;
using System.Data.SqlClient;

namespace BURGUER_SHACK_DESKTOP
{
    public class clnAtendimento
    {

        public enum atendimentoSituacao
        {
            ANDAMENTO,
            FINALIZADO
        }

        private int _cod;
        private int? _codCliente;
        private int _codFuncionario;
        private int? _codReserva;
        private List<int> _codMesas;

        private DateTime _inicio;
        private DateTime? _fim;

        private atendimentoSituacao _situacao;

        public int Cod { get => _cod; set => _cod = value; }
        public int? CodCliente { get => _codCliente; set => _codCliente = value; }
        public int CodFuncionario { get => _codFuncionario; set => _codFuncionario = value; }
        public int? CodReserva { get => _codReserva; set => _codReserva = value; }
        public List<int> CodMesas { get => _codMesas; set => _codMesas = value; }
        public DateTime Inicio { get => _inicio; set => _inicio = value; }
        public DateTime? Fim { get => _fim; set => _fim = value; }
        public atendimentoSituacao Situacao { get => _situacao; set => _situacao = value; }

        private clnAtendimento obter(SqlDataReader reader) => new clnAtendimento
        {
            Cod = clnUtilConvert.ToInt(reader["id"]),
            CodCliente = clnUtilConvert.ToNullableInt(reader["id_cliente"]),
            CodFuncionario = clnUtilConvert.ToInt(reader["id_funcionario"]),
            CodReserva = clnUtilConvert.ToNullableInt(reader["id_reserva"]),
            Inicio = clnUtilConvert.ToDateTime(reader["inicio"]),
            Fim = clnUtilConvert.ToNullableDateTime(reader["fim"]),
            Situacao = situacao(clnUtilConvert.ToString(reader["situacao"]))
        };

        private void obterMesas()
        {
            sqlCommandSelect objSelect = new sqlCommandSelect();
            objSelect.table("atendimento_mesa").Select.select("id_mesa");
            objSelect.Where.where("id_atendimento", Cod);

            CodMesas = new List<int>();
            SqlDataReader reader = objSelect.select(App.AppDatabase);
            while (reader.Read())
            {
                CodMesas.Add(clnUtilConvert.ToInt(reader["id_mesa"]));
            }
            reader.Close();
        }

        public clnAtendimento obterPorCodigo()
        {
            sqlCommandSelect objSelect = new sqlCommandSelect();
            objSelect.table("atendimento");
            objSelect.Where.where("id", Cod);

            clnAtendimento objAtendimento = null;
            SqlDataReader reader = objSelect.select(App.AppDatabase);
            if (reader.Read())
            {
                objAtendimento = obter(reader);
                objAtendimento.obterMesas();
            }
            reader.Close();
            return objAtendimento;
        }

        public void gravar()
        {
            sqlCommandInsert objInsert = new sqlCommandInsert();
            objInsert.Insert.val("id_cliente", CodCliente).val("id_funcionario", CodFuncionario).val("id_reserva", CodReserva)
                            .val("inicio", Inicio).val("fim", Fim).val("situacao", prefixo(Situacao));
            objInsert.table("atendimento");

            Cod = objInsert.insertWithOutput(App.AppDatabase);
            this.obterMesas();
        }

        public void adicionarMesa(int codMesa)
        {
            if (!CodMesas.Contains(codMesa))
            {
                CodMesas.Add(codMesa);
                sqlCommandInsert objInsert = new sqlCommandInsert();
                objInsert.table("atendimento_mesa").Insert.val("id_atendimento", Cod).val("id_mesa", codMesa);
                objInsert.insert(App.AppDatabase);
            }
        }

        public void removerMesa(int codMesa)
        {
            if (CodMesas.Contains(codMesa))
            {
                CodMesas.Remove(codMesa);
                sqlCommandDelete objDelete = new sqlCommandDelete();
                objDelete.table("atendimento_mesa").Where.where("id_atendimento", Cod).where("id_mesa", codMesa);
                objDelete.delete(App.AppDatabase);
            }
        }

        public atendimentoSituacao situacao(String prefixo)
        {
            switch (prefixo.ToUpper())
            {
                case "A":
                    return atendimentoSituacao.ANDAMENTO;
                default:
                    return atendimentoSituacao.FINALIZADO;
            }
        }

        public char prefixo(atendimentoSituacao situacao)
        {
            switch (situacao)
            {
                case atendimentoSituacao.ANDAMENTO:
                    return 'A';
                default:
                    return 'F';
            }
        }

    }
}
