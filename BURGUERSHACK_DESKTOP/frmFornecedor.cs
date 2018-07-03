﻿using BURGUERSHACK_COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BURGUERSHACK_DESKTOP
{
    public partial class frmFornecedor : Form
    {

        private clnUtilFormValidar _validar;

        private clnFornecedor _objFuncionario;

        internal clnFornecedor ObjFornecedor { get => _objFuncionario; set => _objFuncionario = value; }

        public frmFornecedor()
        {
            InitializeComponent();

            _validar = new clnUtilFormValidar();
            _validar.addValidacao(txtRazaoSocial, clnUtilFormValidar.ValidarTipo.OBRIGATORIO);
            _validar.addValidacao(mtbCNPJ, new clnUtilFormValidar.ValidarTipo[] { clnUtilFormValidar.ValidarTipo.OBRIGATORIO, clnUtilFormValidar.ValidarTipo.CNPJ });
            _validar.addValidacao(mtbTel, new clnUtilFormValidar.ValidarTipo[] { clnUtilFormValidar.ValidarTipo.OBRIGATORIO, clnUtilFormValidar.ValidarTipo.TELEFONE });
            _validar.addValidacao(txtEmail, new clnUtilFormValidar.ValidarTipo[] { clnUtilFormValidar.ValidarTipo.OBRIGATORIO, clnUtilFormValidar.ValidarTipo.EMAIL });

            _validar.addValidacao(mtbEndCEP, new clnUtilFormValidar.ValidarTipo[] { clnUtilFormValidar.ValidarTipo.OBRIGATORIO, clnUtilFormValidar.ValidarTipo.CEP });
            _validar.addValidacao(txtEndLogradouro, clnUtilFormValidar.ValidarTipo.OBRIGATORIO);
            _validar.addValidacao(txtEndNr, new clnUtilFormValidar.ValidarTipo[] { clnUtilFormValidar.ValidarTipo.OBRIGATORIO, clnUtilFormValidar.ValidarTipo.INT, clnUtilFormValidar.ValidarTipo.INT_MAIOR_0 });
            _validar.addValidacao(txtEndBairro, clnUtilFormValidar.ValidarTipo.OBRIGATORIO);
            _validar.addValidacao(txtEndCidade, clnUtilFormValidar.ValidarTipo.OBRIGATORIO);
            _validar.addValidacao(cboEndUF, clnUtilFormValidar.ValidarTipo.OBRIGATORIO);

            mtbCNPJ.Mask = clnUtil.MASK_CNPJ;
            mtbTel.Mask = clnUtil.MASK_TEL;
            mtbEndCEP.Mask = clnUtil.MASK_CEP;
        }

        private void salvar()
        {
            if (_validar.valido())
            {
                if (ObjFornecedor == null)
                {
                    clnFornecedor objFornecedorCNPJ = new clnFornecedor
                    {
                        Cnpj = clnUtil.retirarFormatacao(mtbCNPJ.Text)
                    }.obterPorCNPJ();

                    if (objFornecedorCNPJ == null)
                    {
                        clnFornecedor objFornecedor = new clnFornecedor
                        {
                            RazaoSocial = txtRazaoSocial.Text,
                            Cnpj = clnUtil.retirarFormatacao(mtbCNPJ.Text),
                            Telefone = clnUtil.retirarFormatacao(mtbTel.Text),
                            Email = txtEmail.Text,
                            EndCEP = clnUtil.retirarFormatacao(mtbEndCEP.Text),
                            EndLogradouro = txtEndLogradouro.Text,
                            EndNumero = txtEndNr.Text,
                            EndComplemento = txtEndComplemento.Text,
                            EndBairro = txtEndBairro.Text,
                            EndLocalidade = txtEndCidade.Text,
                            EndUF = cboEndUF.Text
                        };
                        objFornecedor.gravar();
                        ObjFornecedor = objFornecedor;
                        clnUtilMensagem.mostrarOk("Cadastro de Fornecedor", "Fornecedor cadastrado com sucesso!", clnUtilMensagem.MensagemIcone.OK);
                        Close();
                    }
                    else
                    {
                        clnUtilMensagem.mostrarOk("Cadastro de Fornecedor", "Não foi possível cadastrar o fornecedor, o CNPJ já está cadastrado!", clnUtilMensagem.MensagemIcone.ERRO);
                        mtbCNPJ.Focus();
                    }
                }
                else
                {
                    ObjFornecedor.RazaoSocial = txtRazaoSocial.Text;
                    ObjFornecedor.Email = txtEmail.Text;
                    ObjFornecedor.Telefone = clnUtil.retirarFormatacao(mtbTel.Text);
                    ObjFornecedor.EndCEP = clnUtil.retirarFormatacao(mtbEndCEP.Text);
                    ObjFornecedor.EndLogradouro = txtEndLogradouro.Text;
                    ObjFornecedor.EndNumero = txtEndNr.Text;
                    ObjFornecedor.EndComplemento = txtEndComplemento.Text;
                    ObjFornecedor.EndBairro = txtEndBairro.Text;
                    ObjFornecedor.EndLocalidade = txtEndCidade.Text;
                    ObjFornecedor.EndUF = cboEndUF.Text;
                    ObjFornecedor.alterar();
                    clnUtilMensagem.mostrarOk("Alteração de Fornecedor", "Fornecedor alterado com sucesso!", clnUtilMensagem.MensagemIcone.OK);
                    Close();
                }
            }
        }

        private void fechar()
        {
            if (ObjFornecedor == null)
            {
                if (clnUtilMensagem.mostrarSimNao("Cadastro de Fornecedor", "Deseja cancelar o cadastro?", clnUtilMensagem.MensagemIcone.ERRO))
                {
                    Close();
                }
            }
            else
            {
                if (clnUtilMensagem.mostrarSimNao("Alteração de Fornecedor", "Deseja cancelar as alterações?", clnUtilMensagem.MensagemIcone.ERRO))
                {
                    Close();
                }
            }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            clnUtil.atualizarForm(this);
            UIX.uixButton.btnApply(btnCancelar, AppDesktop.VisualStyle.ButtonWarningColor);

            clnUtil.definirCEP(mtbEndCEP, txtEndLogradouro, txtEndBairro, txtEndCidade, cboEndUF.cbo, txtEndNr);

            if (ObjFornecedor == null)
            {
                hdrUIX.Title = App.Name + " - Novo Fornecedor";
            }
            else
            {
                hdrUIX.Title = App.Name + " - Alterando Fornecedor " + ObjFornecedor.Cod;
                mtbCNPJ.Enabled = false;

                txtRazaoSocial.Text = ObjFornecedor.RazaoSocial;
                mtbCNPJ.Text = ObjFornecedor.Cnpj;
                txtEmail.Text = ObjFornecedor.Email;
                mtbTel.Text = ObjFornecedor.Telefone;

                mtbEndCEP.Text = ObjFornecedor.EndCEP;
                txtEndLogradouro.Text = ObjFornecedor.EndLogradouro;
                txtEndNr.Text = ObjFornecedor.EndNumero;
                txtEndComplemento.Text = ObjFornecedor.EndComplemento;
                txtEndBairro.Text = ObjFornecedor.EndBairro;
                txtEndCidade.Text = ObjFornecedor.EndLocalidade;
                cboEndUF.Text = ObjFornecedor.EndUF;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvar();
        }

        private void hdrUIX_Close(object sender, EventArgs e)
        {
            fechar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fechar();
        }

    }
}