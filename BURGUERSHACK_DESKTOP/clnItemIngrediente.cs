﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQL_POWERUP;
using System.Data.SqlClient;
using BURGUERSHACK_COMMON;

namespace BURGUERSHACK_DESKTOP
{
    public class clnItemIngrediente
    {

        private int _codIngrediente = -1;
        private int? _codProdutoIngrediente = null;
        private int _codItem = -1;

        private int _quantidade;

        public int CodIngrediente { get => _codIngrediente; set => _codIngrediente = value; }
        public int? CodProdutoIngrediente { get => _codProdutoIngrediente; set => _codProdutoIngrediente = value; }
        public int CodItem { get => _codItem; set => _codItem = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }

        private clnItemIngrediente obter(SqlDataReader reader) => new clnItemIngrediente
        {
            CodIngrediente = clnUtilConvert.ToInt(reader["id_ingrediente"]),
            CodItem = clnUtilConvert.ToInt(reader["id_item"]),
            Quantidade = clnUtilConvert.ToInt(reader["quantidade"]),
            CodProdutoIngrediente = clnUtilConvert.ToNullableInt(reader["id_produto_ingrediente"])
        };

        public List<clnItemIngrediente> obterPorItem()
        {
            sqlSelect objSelect = new sqlSelect();
            objSelect.table("item_ingrediente");
            objSelect.Where.where("id_item", CodItem);

            SqlDataReader reader = objSelect.execute(App.DatabaseSql);
            List<clnItemIngrediente> objIngredientes = new List<clnItemIngrediente>();
            while (reader.Read())
                objIngredientes.Add(obter(reader));
            reader.Close();

            return objIngredientes;
        }

        public void gravar()
        {
            sqlInsert objInsert = new sqlInsert();
            objInsert.table("item_ingrediente");
            objInsert.Insert.val("id_ingrediente", CodIngrediente)
                            .val("id_item", CodItem)
                            .val("id_produto_ingrediente", CodProdutoIngrediente)
                            .val("quantidade", Quantidade);

            objInsert.execute(App.DatabaseSql);
        }

        public void alterar()
        {
            sqlUpdate objUpdate = new sqlUpdate();
            objUpdate.table("item_ingrediente");
            objUpdate.Set.val("id_ingrediente", CodIngrediente)
                         .val("quantidade", Quantidade);
            objUpdate.Where.where("id_item", CodItem)
                           .where("id_produto_ingrediente", CodProdutoIngrediente);

            objUpdate.execute(App.DatabaseSql);
        }

        internal void remover()
        {
            sqlDelete objDelete = new sqlDelete();
            objDelete.table("item_ingrediente");
            objDelete.Where.where("id_ingrediente", CodIngrediente)
                           .where("id_item", CodItem)
                           .where("id_produto_ingrediente", CodProdutoIngrediente);

            objDelete.execute(App.DatabaseSql);
        }

        public class clnListar : clnUtilListar<clnItemIngrediente>
        {
            internal override int Cod(clnItemIngrediente obj)
            {
                return obj.CodItem * obj.CodIngrediente;
            }

            internal override string Detalhes(clnItemIngrediente obj)
            {
                string detalhes = "";
                detalhes += "Quantidade: " + obj.Quantidade;

                return detalhes;
            }

            internal override string Imagem(clnItemIngrediente obj)
            {
                clnIngrediente objIngrediente = new clnIngrediente
                {
                    Cod = obj.CodIngrediente
                }.obterPorCod();

                clnArquivo objArquivo = new clnArquivo
                {
                    Cod = objIngrediente.CodImagem
                }.obterPorCodigo();

                return objArquivo.Local;
            }

            internal override string Nome(clnItemIngrediente obj)
            {
                clnIngrediente objIngrediente = new clnIngrediente
                {
                    Cod = obj.CodIngrediente
                }.obterPorCod();

                return objIngrediente.Nome;
            }
        }

    }
}