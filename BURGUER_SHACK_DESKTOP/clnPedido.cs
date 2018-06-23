﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQL_POWERUP;
using System.Data.SqlClient;

namespace BURGUER_SHACK_DESKTOP
{
    public class clnPedido
    {

        public enum pedidoSituacao
        {
            REALIZADO,
            PREPARO,
            PRONTO
        }

        private int _cod = -1;

        private int _codAtendimento = -1;
        private int _codFuncionario = -1;

        private double _valor;
        private pedidoSituacao _situacao;

        public int Cod { get => _cod; set => _cod = value; }
        public int CodAtendimento { get => _codAtendimento; set => _codAtendimento = value; }
        public int CodFuncionario { get => _codFuncionario; set => _codFuncionario = value; }
        public double Valor { get => _valor; set => _valor = value; }
        public pedidoSituacao Situacao { get => _situacao; set => _situacao = value; }

        private clnPedido obter(SqlDataReader reader) => new clnPedido
        {
            Cod = clnUtilConvert.ToInt(reader["id"]),
            CodAtendimento = clnUtilConvert.ToInt(reader["id_atendimento"]),
            CodFuncionario = clnUtilConvert.ToInt(reader["id_funcionario"]),
            Situacao = situacao(clnUtilConvert.ToChar(reader["situacao"])),
            Valor = clnUtilConvert.ToDouble(reader["valor"])
        };

        public List<clnPedido> obterPorAtendimento()
        {
            sqlCommandSelect objSelect = new sqlCommandSelect();
            objSelect.table("pedido");
            objSelect.Where.where("id_atendimento", CodAtendimento);

            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            List<clnPedido> objPedidos = new List<clnPedido>();
            while (reader.Read())
                objPedidos.Add(obter(reader));
            reader.Close();

            return objPedidos;
        }

        public void alterar()
        {
            sqlCommandUpdate objUpdate = new sqlCommandUpdate();
            objUpdate.table("pedido");
            objUpdate.Set.val("valor", Valor)
                         .val("situacao", prefixo(Situacao));
            objUpdate.Where.where("id", Cod);

            objUpdate.execute(App.DatabaseSql);
        }

        public void gravar()
        {
            sqlCommandInsert objInsert = new sqlCommandInsert();
            objInsert.table("pedido");
            objInsert.Insert.val("id_atendimento", CodAtendimento)
                            .val("id_funcionario", CodFuncionario)
                            .val("valor", Valor)
                            .val("situacao", prefixo(Situacao));

            Cod = objInsert.executeWithOutput(App.DatabaseSql);
        }

        private char prefixo(pedidoSituacao situacao)
        {
            switch (situacao)
            {
                case pedidoSituacao.PREPARO:
                    return 'E';
                case pedidoSituacao.PRONTO:
                    return 'P';
                default:
                    return 'R';
            }
        }

        private pedidoSituacao situacao(char prefixo)
        {
            switch (prefixo)
            {
                case 'E':
                    return pedidoSituacao.PREPARO;
                case 'P':
                    return pedidoSituacao.PRONTO;
                default:
                    return pedidoSituacao.REALIZADO;
            }
        }

    }
}
