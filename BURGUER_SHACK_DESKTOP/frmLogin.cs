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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            UIX.uixTemplate _frmTemplate = new UIX.uixTemplate(UIX.uixStyle.SILVER);

            clnTemplate.CommonTemplate.frmApply(this, uctUIX);
        }

        private void uctUIX_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "garçom" && txtSenha.Text == "123")
            {
                frmPedido objfrmPedido = new frmPedido();
                objfrmPedido.Visible = true;
                this.Visible = false;
            }
            else if (txtNome.Text == "cozinha" && txtSenha.Text == "123")
            {
                frmCozinha objfrmCozinha = new frmCozinha();
                objfrmCozinha.Visible = true;
                this.Visible = false;
            }
            else if (txtNome.Text == "lider" && txtSenha.Text == "123")
            {
                frmGerenciador objfrmGerenciador = new frmGerenciador();
                objfrmGerenciador.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você deve digitar um login válido!", "Problemas de autenticação");
                txtNome.Text = "";
                txtSenha.Text = "";
            }
        }
    }
}
