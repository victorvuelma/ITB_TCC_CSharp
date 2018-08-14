﻿using BurgerShack.Common;
using BurgerShack.Common.UTIL;
using BurgerShack.Desktop.UTIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vitorrdgs.UiX.Manager;

namespace BurgerShack.Desktop
{
    public partial class frmIngrediente : Form
    {

        private clnUtilFormValidar _validar;

        private clnIngrediente _objIngrediente;

        public clnIngrediente ObjIngrediente { get => _objIngrediente; set => _objIngrediente = value; }

        public frmIngrediente()
        {
            InitializeComponent();

            _validar = new clnUtilFormValidar();
            _validar.addValidacao(txtNome, clnUtilFormValidar.Validacao.OBRIGATORIO);
            _validar.addValidacao(txtValor, new clnUtilFormValidar.Validacao[] { clnUtilFormValidar.Validacao.OBRIGATORIO, clnUtilFormValidar.Validacao.VALOR });
            _validar.addValidacao(cboTipo, clnUtilFormValidar.Validacao.OBRIGATORIO);

        }

        private void abrirTipos()
        {
            frmTipo frmTipo = new frmTipo
            {
                Tipo = clnTipo.tipo.INGREDIENTE
            };
            frmTipo.ShowDialog();

            carregarTipos();
            if (frmTipo.ObjTipo != null)
                definirTipo(frmTipo.ObjTipo);
        }

        private void removerImagem()
        {
            if (clnUtilMensagem.mostrarSimNao("Ingrediente", "Deseja realmente remover a imagem?", clnUtilMensagem.MensagemIcone.INFO))
            {
                definirImagemPadrao();
            }
        }

        private void definirImagemPadrao()
        {
            picImagem.ImageLocation = clnArquivo.tempImage(Properties.Resources.ingrediente);
        }

        private void adicionarImagem()
        {
            OpenFileDialog objDialog = new OpenFileDialog
            {
                Filter = "png|*.png"
            };
            if (objDialog.ShowDialog() == DialogResult.OK)
            {
                picImagem.ImageLocation = objDialog.FileName;
            }
        }

        private void salvar()
        {
            if (_validar.validar(this))
            {
                if (ObjIngrediente == null)
                {
                    clnArquivo objArquivo = new clnArquivo
                    {
                        Local = picImagem.ImageLocation
                    };
                    objArquivo.gravar();

                    ObjIngrediente = new clnIngrediente
                    {
                        Situacao = clnIngrediente.ingredienteSituacao.FORADEESTOQUE,
                        Nome = txtNome.Text,
                        CodTipo = cboTipo.SelectedItem.Id,
                        CodImagem = objArquivo.Cod,
                        Valor = clnUtilConvert.ToDecimal(txtValor.Text)
                    };

                    ObjIngrediente.gravar();
                    clnUtilMensagem.mostrarOk("Cadastro de Ingrediente", "Ingrediente cadastrado com sucesso!");
                }
                else
                {
                    clnArquivo objArquivo = new clnArquivo
                    {
                        Cod = ObjIngrediente.CodImagem
                    }.obterPorCodigo();

                    if (!objArquivo.Local.Equals(picImagem.ImageLocation))
                    {
                        objArquivo = new clnArquivo
                        {
                            Local = picImagem.ImageLocation
                        };
                        objArquivo.gravar();
                        ObjIngrediente.CodImagem = objArquivo.Cod;
                    }
                    ObjIngrediente.CodTipo = clnUtilConvert.ToInt(cboTipo.Text.Split('-')[0]);
                    ObjIngrediente.Nome = txtNome.Text;
                    ObjIngrediente.Valor = clnUtilConvert.ToDecimal(txtValor.Text);
                    ObjIngrediente.Situacao = (clnIngrediente.ingredienteSituacao)Enum.Parse(typeof(clnIngrediente.ingredienteSituacao), cboSituacao.Text);

                    ObjIngrediente.alterar();

                    clnEstoque objEstoque = new clnEstoque
                    {
                        CodIngrediente = ObjIngrediente.Cod
                    };
                    objEstoque.atualizarIngrediente();

                    clnUtilMensagem.mostrarOk("Altereção de Ingrediente", "Ingrediente alterado com sucesso!");
                }
                Close();
            }
        }

        private void definirTipo(clnTipo objTipo)
        {
            cboTipo.Text = objTipo.Cod + " - " + objTipo.Nome;
        }

        private void carregarTipos()
        {
            cboTipo.clear();

            foreach (clnTipo objTipo in new clnTipo { Tipo = clnTipo.tipo.INGREDIENTE }.obterTipos())
            {
                cboTipo.add(objTipo.Cod, objTipo.Cod + " - " + objTipo.Nome);
                if (ObjIngrediente != null && ObjIngrediente.CodTipo.Equals(objTipo.Cod))
                {
                    definirTipo(objTipo);
                }
            }
        }

        private void fechar()
        {
            if (ObjIngrediente == null)
            {
                if (clnUtilMensagem.mostrarSimNao("Cadastro de Ingrediente", "Deseja cancelar o cadastro?", clnUtilMensagem.MensagemIcone.ERRO))
                {
                    Close();
                }
            }
            else
            {
                if (clnUtilMensagem.mostrarSimNao("Alteração de Ingrediente", "Deseja cancelar as alterações?", clnUtilMensagem.MensagemIcone.ERRO))
                {
                    Close();
                }
            }
        }

        private void frmIngrediente_Load(object sender, EventArgs e)
        {
            clnUtil.atualizarForm(this);
            uixButton.btnApply(btnVoltar, AppDesktop.VisualStyle.ButtonWarningColor);
            uixButton.btnApply(btnExcluir, AppDesktop.VisualStyle.ButtonWarningColor);

            if (ObjIngrediente != null)
            {
                hdrUIX.Title = App.Name + " - Alterando Ingrediente " + ObjIngrediente.Cod;

                clnArquivo objArquivo = new clnArquivo
                {
                    Cod = ObjIngrediente.CodImagem
                }.obterPorCodigo();

                txtNome.Text = ObjIngrediente.Nome;
                txtValor.Text = ObjIngrediente.Valor.ToString();
                picImagem.ImageLocation = objArquivo.Local;

                int ingredienteEstoque = new clnEstoque
                {
                    CodIngrediente = ObjIngrediente.Cod
                }.obterQuantidadePorIngrediente();

                if (ObjIngrediente.Situacao == clnIngrediente.ingredienteSituacao.FORADEESTOQUE)
                {
                    cboSituacao.Enabled = false;
                    cboSituacao.add(clnIngrediente.ingredienteSituacao.FORADEESTOQUE);
                }
                else
                {
                    cboSituacao.addRange(new object[] { clnIngrediente.ingredienteSituacao.DISPONIVEL, clnIngrediente.ingredienteSituacao.INDISPONIVEL });
                }
                cboSituacao.Text = ObjIngrediente.Situacao.ToString();
                lblEstoque.Text = "Estoque: " + ingredienteEstoque;
            }
            else
            {
                hdrUIX.Title = App.Name + " - Novo Ingrediente";

                definirImagemPadrao();

                grbSituacao.Hide();
                btnExcluir.Hide();
            }

            carregarTipos();
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            abrirTipos();
        }

        private void btnImgRemover_Click(object sender, EventArgs e)
        {
            removerImagem();
        }

        private void btnImgAdicionar_Click(object sender, EventArgs e)
        {
            adicionarImagem();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            fechar();
        }

        private void hdrUIX_Close(object sender, EventArgs e)
        {
            fechar();
        }
    }
}