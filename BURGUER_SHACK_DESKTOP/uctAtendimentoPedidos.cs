﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BURGUER_SHACK_DESKTOP
{
    public partial class uctAtendimentoPedidos : UserControl
    {

        private int _codAtendimento;

        private List<clnPedido> _objPedidos;

        public uctAtendimentoPedidos()
        {
            InitializeComponent();
        }

        public List<clnPedido> ObjPedidos { get => _objPedidos; set => _objPedidos = value; }
        public int CodAtendimento { get => _codAtendimento; set => _codAtendimento = value; }

        private void exibirPedidos()
        {
            pnlPedidos.Controls.Clear();

            List<Control> pedidosControles = new List<Control>();
            foreach (clnPedido objPedido in ObjPedidos)
            {
                UIX.btnUIX btn = new UIX.btnUIX
                {
                    Description = "Pedido #" + objPedido.Cod,
                    Name = "btnPedido" + objPedido.Cod,
                    Size = new Size(110, 110),
                    Image = global::BURGUER_SHACK_DESKTOP.Properties.Resources.pedido
                };
                btn.Click += (object sender, EventArgs e) =>
                {
                    abrirPedido(objPedido);
                };

                pedidosControles.Add(btn);
            }
            clnUtil.adicionarControles(pnlPedidos, pedidosControles, 20);

            foreach (Control control in pedidosControles)
            {
                if (control is Button btn)
                {
                    UIX.uixButton.btnApply(btn, App.AppVisualStyle.ButtonImageColor);
                    btn.ForeColor = App.AppVisualStyle.ButtonImageColor.ContentColor;
                }
            }
            pedidosControles.Clear();

            pnlPedidos.BackColor = grbPedidos.BackColor;
        }

        private void abrirPedido(clnPedido objPedido)
        {
            List<clnItem> objProdutos = new clnItem
            {
                CodPedido = objPedido.Cod
            }.obterPorPedido();

            Dictionary<clnItem, List<clnItemIngrediente>> objPedidoProdutoIngredientes = new Dictionary<clnItem, List<clnItemIngrediente>>();
            foreach(clnItem objPedidoProduto in objProdutos)
            {
                List<clnItemIngrediente> objIngredientes = new clnItemIngrediente
                {
                    CodItem = objPedido.Cod
                }.obterPorItem();

                objPedidoProdutoIngredientes.Add(objPedidoProduto, objIngredientes);
            }
            frmPedido frmPedido = new frmPedido
            {
                CodAtendimento = CodAtendimento,
                ObjPedido = objPedido,
                ObjItens = objPedidoProdutoIngredientes
            };
        }

        private void uctAtendimentoPedidos_Load(object sender, EventArgs e)
        {
            exibirPedidos();
        }
    }
}
