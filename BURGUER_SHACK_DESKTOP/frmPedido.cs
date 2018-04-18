﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BURGUER_SHACK_DESKTOP
{
    public partial class frmPedido : Form
    {
        public frmPedido()
        {
            InitializeComponent();
            uctPedidoNovo.Visible = false;
            uctPedidoAlterar.Visible = false;
            uctProdutoRemover.Visible = false;
            uctPedidoRemover.Visible = false;
            uctPedidos.Visible = false;
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Garçom";
            tplBurguerShack.CommonTemplate.frmApply(this, uctUIX);
        }

        private void btnNovoPedido_Click(object sender, EventArgs e)
        {
            uctPedidoNovo.Visible = true;
            uctPedidoAlterar.Visible = false;
            uctProdutoRemover.Visible = false;
            uctPedidoRemover.Visible = false;
            uctPedidos.Visible = false;
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Novo Pedido";
        }

        private void btnAlterarPedido_Click(object sender, EventArgs e)
        {
            uctPedidoNovo.Visible = false;
            uctPedidoAlterar.Visible = true;
            uctProdutoRemover.Visible = false;
            uctPedidoRemover.Visible = false;
            uctPedidos.Visible = false;
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Alterar Pedido";
        }

        private void btnPedidoRemover_Click(object sender, EventArgs e)
        {
            uctPedidoAlterar.Visible = false;
            uctPedidoNovo.Visible = false;
            uctProdutoRemover.Visible = true;
            uctPedidoRemover.Visible = false;
            uctPedidos.Visible = false;
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Alterar Pedido";
        }

        private void btnApagarPedido_Click(object sender, EventArgs e)
        {
            uctPedidoAlterar.Visible = false;
            uctPedidoNovo.Visible = false;
            uctProdutoRemover.Visible = false;
            uctPedidoRemover.Visible = true;
            uctPedidos.Visible = false;
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Remover Pedido";
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            uctPedidoAlterar.Visible = false;
            uctPedidoNovo.Visible = false;
            uctProdutoRemover.Visible = false;
            uctPedidoRemover.Visible = false;
            uctPedidos.Visible = true;
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Pedidos";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
