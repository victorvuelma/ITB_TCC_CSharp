﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using vitorrdgs.SqlMaster;
using System.Data.SqlClient;
using BurgerShack.Common.UTIL;
using BurgerShack.Common;
using vitorrdgs.SqlMaster.Command;
using vitorrdgs.SqlMaster.Element;

namespace BurgerShack.Desktop
{
    class clnFornecedor
    {

        private int _cod;

        private string _razaoSocial;
        private string _cnpj;

        private string _email;
        private string _telefone;

        private String _endLogradouro;
        private String _endNumero;
        private String _endComplemento;
        private String _endCEP;
        private String _endBairro;
        private String _endLocalidade;
        private String _endUF;

        public int Cod { get => _cod; set => _cod = value; }
        public string RazaoSocial { get => _razaoSocial; set => _razaoSocial = value; }
        public string Cnpj { get => _cnpj; set => _cnpj = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public string EndLogradouro { get => _endLogradouro; set => _endLogradouro = value; }
        public string EndNumero { get => _endNumero; set => _endNumero = value; }
        public string EndComplemento { get => _endComplemento; set => _endComplemento = value; }
        public string EndCEP { get => _endCEP; set => _endCEP = value; }
        public string EndBairro { get => _endBairro; set => _endBairro = value; }
        public string EndLocalidade { get => _endLocalidade; set => _endLocalidade = value; }
        public string EndUF { get => _endUF; set => _endUF = value; }

        private clnFornecedor obter(SqlDataReader reader) => new clnFornecedor
        {
            Cod = clnUtilConvert.ToInt(reader["id"]),
            RazaoSocial = clnUtilConvert.ToString(reader["razao_social"]),
            Email = clnUtilConvert.ToString(reader["email"]),
            Cnpj = clnUtilConvert.ToString(reader["cnpj"]),
            Telefone = clnUtilConvert.ToString(reader["telefone"]),
            EndLogradouro = clnUtilConvert.ToString(reader["end_logradouro"]),
            EndNumero = clnUtilConvert.ToString(reader["end_nr"]),
            EndComplemento = clnUtilConvert.ToString(reader["end_complemento"]),
            EndCEP = clnUtilConvert.ToString(reader["end_cep"]),
            EndBairro = clnUtilConvert.ToString(reader["end_bairro"]),
            EndLocalidade = clnUtilConvert.ToString(reader["end_localidade"]),
            EndUF = clnUtilConvert.ToString(reader["end_uf"])
        };

        public clnFornecedor obterPorCod()
        {
            sqlSelect objSelect = new sqlSelect();
            objSelect.table("fornecedor");
            objSelect.Where.where("id", Cod);

            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            clnFornecedor objFornecedor = null;
            if (reader.Read())
                objFornecedor = obter(reader);

            return objFornecedor;
        }

        public clnFornecedor obterPorCNPJ()
        {
            sqlSelect objSelect = new sqlSelect();
            objSelect.table("fornecedor");
            objSelect.Where.where("cnpj", Cnpj);

            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            clnFornecedor objFornecedor = null;
            if (reader.Read())
                objFornecedor = obter(reader);

            return objFornecedor;
        }

        public List<clnFornecedor> obterPorRazaoCNPJ()
        {
            sqlSelect objSelect = new sqlSelect();
            objSelect.table("fornecedor");
            objSelect.Where.where("cnpj", sqlElementWhereCommon.whereOperation.LIKE, "%" + Cnpj + "%", sqlElementWhere.whereAssociation.OR)
                           .where("razao_social", sqlElementWhereCommon.whereOperation.LIKE, "%" + RazaoSocial + "%");

            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            List<clnFornecedor> objFornecedor = new List<clnFornecedor>();
            while (reader.Read())
                objFornecedor.Add(obter(reader));

            return objFornecedor;
        }

        public void alterar()
        {
            sqlUpdate objUpdate = new sqlUpdate();
            objUpdate.table("fornecedor");
            objUpdate.Where.where("id", Cod);
            objUpdate.Set.val("razao_social", RazaoSocial)
                         .val("email", Email)
                         .val("telefone", Telefone)
                         .val("end_logradouro", EndLogradouro)
                         .val("end_nr", EndNumero)
                         .val("end_complemento", EndComplemento)
                         .val("end_cep", EndCEP)
                         .val("end_bairro", EndBairro)
                         .val("end_localidade", EndLocalidade)
                         .val("end_uf", EndUF);

            objUpdate.execute(App.DatabaseSql);
        }

        public void gravar()
        {
            sqlInsert objInsert = new sqlInsert();
            objInsert.table("fornecedor");
            objInsert.Insert.val("razao_social", RazaoSocial)
                            .val("cnpj", Cnpj)
                            .val("email", Email)
                            .val("telefone", Telefone)
                            .val("end_logradouro", EndLogradouro)
                            .val("end_nr", EndNumero)
                            .val("end_complemento", EndComplemento)
                            .val("end_cep", EndCEP)
                            .val("end_bairro", EndBairro)
                            .val("end_localidade", EndLocalidade)
                            .val("end_uf", EndUF);

            Cod = objInsert.executeWithOutput(App.DatabaseSql);
        }

    }
}