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
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Garçom";
            tplBurguerShack.CommonTemplate.frmApply(this, uctUIX);
        }

        private void btnNovoPedido_Click(object sender, EventArgs e)
        {
            uctPedidoNovo.Visible = true;
            uctUIX.UIXTitle = tplBurguerShack.AppName + " - Novo Pedido";
        }
    }
}
