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
    public partial class frmPedidoProduto : Form
    {

        private int _mesa;

        public int Mesa { get => _mesa; set => _mesa = value; }

        public frmPedidoProduto()
        {
            InitializeComponent();

            clnUtil.atualizarTabIndex(Controls);
        }

        public void alterarConteudo(UserControl uctConteudo, String titulo)
        {
            clnUtil.alterarConteudo(pnlConteudo, uctConteudo, uctUIX, titulo);
        }

        private void abrirVisualizar()
        {
            alterarConteudo(new uctPedidoProdutoVer(), "Visualizar");
        }

        private void fechar()
        {
            if (clnMensagem.mostrarSimNao("Produto", "Deseja cancelar as alterações realizadas no pedido?", clnMensagem.MSG_ERRO))
            {
                Close();
            }
        }

        private void frmPedidoProduto_Load(object sender, EventArgs e)
        {
            clnApp.CommonTemplate.frmApply(this, uctUIX);

            UIX.uixButton.btnApply(btnRemover, clnApp.CommonTemplate.Style.WarningButtonColor);

            abrirVisualizar();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            fechar();
        }

        private void uctUIX_Close(object sender, EventArgs e)
        {
            fechar();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            abrirVisualizar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if(clnMensagem.mostrarSimNao("Produto", "Deseja realmente remover esse produto do pedido?", clnMensagem.MSG_INFO))
            {

                //faz e tal
                Close();
            }
        }
    }
}
