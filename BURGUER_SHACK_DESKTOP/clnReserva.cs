﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQL_POWERUP;
using System.Data.SqlClient;

namespace BURGUER_SHACK_DESKTOP
{
    class clnReserva
    {

        public enum reservaSituacao
        {
            CANCELADA,
            CONFIRMADA,
            MARCADA,
            UTILIZADA
        }

        private int _cod = -1;

        private int _codCliente = -1;
        private int _codFuncionario = -1;
        private List<int> _codMesas = new List<int>();

        private reservaSituacao _situacao;
        private int _pessoas;

        private DateTime _agendado;
        private DateTime _agendamento;

        public int Cod { get => _cod; set => _cod = value; }
        public int CodCliente { get => _codCliente; set => _codCliente = value; }
        public int CodFuncionario { get => _codFuncionario; set => _codFuncionario = value; }
        public List<int> CodMesas { get => _codMesas; set => _codMesas = value; }
        internal reservaSituacao Situacao { get => _situacao; set => _situacao = value; }
        public int Pessoas { get => _pessoas; set => _pessoas = value; }
        public DateTime Agendado { get => _agendado; set => _agendado = value; }
        public DateTime Agendamento { get => _agendamento; set => _agendamento = value; }

        private clnReserva obter(SqlDataReader reader)
        {
            clnReserva objReserva = new clnReserva
            {
                Cod = clnUtilConvert.ToInt(reader["id"]),
                CodCliente = clnUtilConvert.ToInt(reader["id_cliente"]),
                CodFuncionario = clnUtilConvert.ToInt(reader["id_funcionario"]),
                Situacao = situacao(clnUtilConvert.ToChar(reader["situacao"])),
                Pessoas = clnUtilConvert.ToInt(reader["pessoas"]),
                Agendado = clnUtilConvert.ToDateTime(reader["agendado"]),
                Agendamento = clnUtilConvert.ToDateTime(reader["agendamento"])
            };
            objReserva.obterMesas();

            return objReserva;
        }

        private void obterMesas()
        {
            sqlCommandSelect objSelect = new sqlCommandSelect();
            objSelect.table("reserva_mesa").Columns.select("id_mesa");
            objSelect.Where.where("id_reserva", Cod);

            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            while (reader.Read())
                CodMesas.Add(clnUtilConvert.ToInt(reader["id_mesa"]));
            reader.Close();
        }

        public List<clnReserva> obterPorDataAgendada()
        {
            sqlCommandSelect objSelect = new sqlCommandSelect();
            objSelect.table("reserva");
            objSelect.Where.where(new sqlObjWhereBetween { TableColumn = "agendado", Val1 = Agendado, Val2 = Agendado.AddDays(1) });

            List<clnReserva> objReservas = new List<clnReserva>();
            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            while (reader.Read())
                objReservas.Add(obter(reader));
            reader.Close();

            return objReservas;
        }

        public List<int> obterMesasReservadas()
        {
            sqlCommandSelect objSelect = new sqlCommandSelect();
            objSelect.table("mesa");
            objSelect.Columns.select("mesa.id");
            objSelect.Join.innerJoin("reserva_mesa", "id_mesa", "mesa.id")
                          .innerJoin("reserva", "id", "reserva_mesa.id_reserva");
            objSelect.Where.where("reserva.agendado", sqlObjWhereCommon.whereOperation.MAJOR_EQUALS, Agendado)
                           .where("reserva.agendado", sqlObjWhereCommon.whereOperation.LESS, Agendado.AddDays(1))
                           .where("reserva.situacao", sqlObjWhereCommon.whereOperation.UNEQUAL, prefixo(reservaSituacao.CANCELADA));

            List<int> objMesas = new List<int>();
            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            while (reader.Read())
                objMesas.Add(clnUtilConvert.ToInt(reader["id"]));
            reader.Close();

            return objMesas;
        }

        public void gravar()
        {
            sqlCommandInsert objInsert = new sqlCommandInsert();
            objInsert.table("reserva");
            objInsert.Insert.val("id_cliente", CodCliente)
                            .val("id_funcionario", CodFuncionario)
                            .val("situacao", prefixo(Situacao))
                            .val("pessoas", Pessoas)
                            .val("agendado", Agendado)
                            .val("agendamento", Agendamento);

            Cod = objInsert.executeWithOutput(App.DatabaseSql);

            gravarMesas();
        }

        private void gravarMesas()
        {
            foreach (int codMesa in CodMesas)
            {
                sqlCommandInsert objInsert = new sqlCommandInsert();
                objInsert.table("reserva_mesa");
                objInsert.Insert.val("id_reserva", Cod)
                                .val("id_mesa", codMesa);
                objInsert.execute(App.DatabaseSql);
            }
        }

        public void alterar()
        {
            sqlCommandUpdate objUpdate = new sqlCommandUpdate();
            objUpdate.table("reserva");
            objUpdate.Where.where("id", Cod);
            objUpdate.Set.val("pessoas", Pessoas)
                         .val("situacao", prefixo(Situacao));
            objUpdate.execute(App.DatabaseSql);
        }

        internal void addMesa(int mesa)
        {
            if (!CodMesas.Contains(mesa))
            {
                CodMesas.Add(mesa);
                if (Cod != -1)
                {
                    sqlCommandInsert objInsert = new sqlCommandInsert();
                    objInsert.table("reserva_mesa");
                    objInsert.Insert.val("id_reserva", Cod)
                                    .val("id_mesa", mesa);

                    objInsert.execute(App.DatabaseSql);
                }
            }
        }

        internal void removerMesa(int mesa)
        {
            if (CodMesas.Contains(mesa))
            {
                CodMesas.Add(mesa);
                if (Cod != -1)
                {
                    sqlCommandDelete objDelete = new sqlCommandDelete();
                    objDelete.table("reserva_mesa");
                    objDelete.Where.where("id_reserva", Cod)
                                   .where("id_mesa", mesa);

                    objDelete.execute(App.DatabaseSql);
                }
            }
        }

        private reservaSituacao situacao(char prefixo)
        {
            switch (prefixo)
            {
                case 'A':
                    return reservaSituacao.CANCELADA;
                case 'O':
                    return reservaSituacao.CONFIRMADA;
                case 'M':
                    return reservaSituacao.MARCADA;
                default:
                    return reservaSituacao.UTILIZADA;
            }
        }

        private char prefixo(reservaSituacao situacao)
        {
            switch (situacao)
            {
                case reservaSituacao.CANCELADA:
                    return 'A';
                case reservaSituacao.CONFIRMADA:
                    return 'O';
                case reservaSituacao.MARCADA:
                    return 'M';
                default:
                    return 'U';
            }
        }

    }
}
