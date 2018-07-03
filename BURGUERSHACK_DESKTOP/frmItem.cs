﻿using System;
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
    public partial class frmItem : Form
    {
        private clnUtilValidar _validar;

        private clnItem _objItem;
        private List<clnItemIngrediente> _objIngredientes;

        public clnItem ObjItem { get => _objItem; set => _objItem = value; }
        public List<clnItemIngrediente> ObjItemIngredientes { get => _objIngredientes; set => _objIngredientes = value; }

        public frmItem()
        {
            InitializeComponent();

            _validar = new clnUtilValidar();
            _validar.addValidacao(txtQuantidade, new clnUtilValidar.ValidarTipo[] { clnUtilValidar.ValidarTipo.OBRIGATORIO, clnUtilValidar.ValidarTipo.INT, clnUtilValidar.ValidarTipo.INT_MAIOR_0 });
        }

        private List<clnItemIngrediente> obterIngredientes()
        {
            if (ObjItem == null || ObjItem.CodPedido == -1)
            {
                return ObjItemIngredientes;
            }
            else
            {
                return new clnItemIngrediente
                {
                    CodItem = ObjItem.Cod
                }.obterPorItem();
            }
        }

        private void fechar()
        {
            if (clnUtilMensagem.mostrarSimNao("Item", "Deseja cancelar as alterações realizadas no item?", clnUtilMensagem.MensagemIcone.INFO))
            {
                Close();
            }
        }

        private void abrirIngredientes()
        {
            List<clnItemIngrediente> objItemIngredientes = obterIngredientes();

            if (ObjItemIngredientes.Count > 0)
            {
                clnItemIngrediente.clnListar objListar = new clnItemIngrediente.clnListar
                {
                    Opcoes = objItemIngredientes,
                    Icone = Properties.Resources.ingrediente,
                    Titulo = "Selecione um Ingrediente"
                };

                clnUtilVisualizar<frmItem, clnItemIngrediente> objVisualizar = new clnUtilVisualizar<frmItem, clnItemIngrediente>
                {
                    ObjListar = objListar,
                    Callback = new CallbackAlterar(),
                    Obj = this
                };

                frmUtilVisualizar frmVisualizar = new frmUtilVisualizar
                {
                    ObjVisualizar = objVisualizar
                };
                frmVisualizar.ShowDialog();
            }
            else if (clnUtilMensagem.mostrarSimNao("Item", "Não foi encontrado nenhum ingrediente, deseja adicionar?", clnUtilMensagem.MensagemIcone.OK))
            {
                abrirAdicionarIngrediente();
            }
        }

        private void exibirProduto(clnProduto objProduto, clnItem objItem)
        {
            clnArquivo objArquivo = new clnArquivo
            {
                Cod = objProduto.CodImagem
            }.obterPorCodigo();

            picProduto.ImageLocation = objArquivo.Local;
            lblProdutoNome.Text = objProduto.Nome;
            txtQuantidade.Text = Convert.ToString(objItem.Quantidade);
            txtAdicional.Text = objItem.Adicional;
        }

        private void abrirAdicionarIngrediente()
        {
            clnIngrediente objIngredientes = new clnIngrediente();

            clnIngrediente.clnListar objListar = new clnIngrediente.clnListar
            {
                Opcoes = objIngredientes.obterIngredientes(),
                Titulo = "Adicionar um Ingrediente",
                Icone = Properties.Resources.ingrediente
            };
            clnUtilSelecionar<clnIngrediente> objSelecionar = new clnUtilSelecionar<clnIngrediente>
            {
                ObjListar = objListar,
                Quantidade = clnUtilConvert.ToInt(txtQuantidade.Text)
            };

            frmUtilSelecionar frmSelecionar = new frmUtilSelecionar
            {
                ObjSelecionar = objSelecionar
            };
            frmSelecionar.ShowDialog();

            if (objSelecionar.Selecionado != null)
            {
                clnItemIngrediente objItemIngrediente = new clnItemIngrediente
                {
                    Quantidade = objSelecionar.Quantidade,
                    CodIngrediente = objSelecionar.Selecionado.Cod,
                    CodItem = ((ObjItem != null) ? ObjItem.Cod : -1),
                    CodProdutoIngrediente = 0
                };
                if (objItemIngrediente.CodItem != -1)
                {
                    clnUtilPedido.adicionarIngrediente(ObjItem, objItemIngrediente);
                }
                else
                {
                    clnUtilPedido.adicionarIngrediente(ObjItemIngredientes, objItemIngrediente);
                }

                clnUtilMensagem.mostrarOk("Ingrediente", "Ingrediente adicionado com sucesso!", clnUtilMensagem.MensagemIcone.OK);
            }
        }

        private void removerItem()
        {
            if (clnUtilMensagem.mostrarSimNao("Pedido", "Deseja realmente remover esse item do pedido?", clnUtilMensagem.MensagemIcone.INFO))
            {
                if (ObjItem != null && ObjItem.Cod != -1)
                {
                    ObjItem.remover();
                }
                ObjItem = null;

                Close();
            }
        }

        private void frmPedidoProduto_Load(object sender, EventArgs e)
        {
            clnUtil.atualizarForm(this);
            UIX.uixButton.btnApply(btnRemover, AppDesktop.VisualStyle.ButtonWarningColor);

            hdrUIX.Title = App.Name + "- Pedido :: Alterando Item " + ObjItem.Cod;

            clnProduto objProduto = new clnProduto
            {
                Cod = ObjItem.CodProduto
            }.obterPorCod();

            exibirProduto(objProduto, ObjItem);

            if (ObjItemIngredientes.Count == 0)
            {
                grbIngredientes.Hide();
            }
        }

        private void hdrUIX_Close(object sender, EventArgs e)
        {
            fechar();
        }

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            abrirIngredientes();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            removerItem();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_validar.valido())
            {
                ObjItem.Quantidade = clnUtilConvert.ToInt(txtQuantidade.Text);
                ObjItem.Adicional = txtAdicional.Text;

                if (ObjItem != null && ObjItem.Cod != -1)
                {
                    ObjItem.alterar();
                }

                Close();
            }
        }

        private void btnIngredienteAdd_Click(object sender, EventArgs e)
        {
            abrirAdicionarIngrediente();
        }

        private class CallbackAlterar : clnUtilVisualizar.visualizarCallback<frmItem, clnItemIngrediente>
        {
            public clnUtilVisualizar.visualizarAction call(frmItem frmItem, clnItemIngrediente objItemIngrediente)
            {
                if (objItemIngrediente.CodProdutoIngrediente != null)
                {
                    clnProdutoIngrediente objProdutoIngrediente = new clnProdutoIngrediente
                    {
                        Cod = (int)objItemIngrediente.CodProdutoIngrediente
                    }.obterPorCod();

                    if (objProdutoIngrediente == null || objProdutoIngrediente.Alterar || objProdutoIngrediente.Remover)
                    {
                        frmItemIngrediente frmIngrediente = new frmItemIngrediente
                        {
                            ObjItemIngrediente = objItemIngrediente
                        };
                        frmIngrediente.btnAlterar.Visible = objProdutoIngrediente == null || objProdutoIngrediente.Alterar;
                        frmIngrediente.btnRemover.Visible = objProdutoIngrediente == null || objProdutoIngrediente.Remover;
                        frmIngrediente.ShowDialog();

                        if (frmIngrediente.ObjItemIngrediente == null)
                        {
                            if (objItemIngrediente.CodItem != -1)
                            {
                                objItemIngrediente.remover();
                            }
                            frmItem.ObjItemIngredientes.Remove(objItemIngrediente);
                        }
                        else if (!objItemIngrediente.Equals(frmIngrediente.ObjItemIngrediente))
                        {
                            if (objItemIngrediente.CodItem != -1)
                            {
                                if (frmIngrediente.ObjItemIngrediente.CodIngrediente != objItemIngrediente.CodIngrediente)
                                {
                                    objItemIngrediente.remover();
                                    frmIngrediente.ObjItemIngrediente.gravar();
                                }
                                else
                                {
                                    frmIngrediente.ObjItemIngrediente.alterar();
                                }
                            }
                            clnUtil.listTrocar(frmItem.ObjItemIngredientes, objItemIngrediente, frmIngrediente.ObjItemIngrediente);
                        }
                    }
                    else
                    {
                        clnUtilMensagem.mostrarOk("Ingredientes", "Esse ingrediente não pode ser alterado ou removido.", clnUtilMensagem.MensagemIcone.ERRO);
                    }
                }
                return clnUtilVisualizar.visualizarAction.FECHAR;
            }
        }
    }
}
