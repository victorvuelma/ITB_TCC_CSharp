﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vitorrdgs.UiX.Manager;
using vitorrdgs.Util;
using vitorrdgs.Util.Data;

namespace BurgerShack.Desktop
{
    public partial class frmGerenciamento : Form
    {

        public frmGerenciamento()
        {
            InitializeComponent();
        }

        private void abrirLista(String tipo, IUtilCallback callbackNovo, IUtilCallback<DataGridView, String, bool> callbackObter, IUtilCallback<DataGridViewRow> callbackAlterar, bool inativos, String[] colunas)
        {
            uctListar.CallbackNovo = callbackNovo;
            uctListar.Colunas = colunas;
            uctListar.CallbackObter = callbackObter;
            uctListar.CallbackAlterar = callbackAlterar;
            uctListar.Inativos = inativos;

            hdrUIX.Title = "Gerenciamento :: " + tipo;

            uctListar.atualizar();
        }

        private void abrirIngredientes()
        {
            abrirLista("Ingredientes", new CallbackIngredienteNovo(), new CallbackIngredienteObter(), new CallbackIngredienteAlterar(), true, new String[] { "Código", "Nome", "Situacao", "Tipo", "Estoque", "Valor" });
        }

        private void abrirProdutos()
        {
            abrirLista("Produtos", new CallbackProdutoNovo(), new CallbackProdutoObter(), new CallbackProdutoAlterar(), true, new String[] { "Código", "Nome", "Situação", "Tipo", "Valor" });
        }

        private void abrirClientes()
        {
            abrirLista("Clientes", new CallbackClienteNovo(), new CallbackClienteObter(), new CallbackClienteAlterar(), true, new String[] { "Código", "Nome", "CPF", "Celular", "Data Nasc.", "Gênero", "Email" });
        }

        private void abrirFuncionarios()
        {
            abrirLista("Funcionários", new CallbackFuncionarioNovo(), new CallbackFuncionarioObter(), new CallbackFuncionarioAlterar(), true, new String[] { "Código", "Nome", "CPF", "RG", "Data Nasc.", "Gênero", "Cargo", "Salário", "Situação" });
        }

        private void abrirFornecedores()
        {
            abrirLista("Fornecedores", new CallbackFornecedorNovo(), new CallbackFornecedorObter(), new CallbackFornecedorAlterar(), true, new String[] { "Código", "Razão Social", "CNPJ", "Telefone", "Email" });
        }

        private void abrirReservas()
        {
            //abrirLista("Reservas", new CallbackReservaNovo(), new CallbackReservaObter(), new CallbackReservaAlterar(), true, new String[] { "Código", "Pessoas", "Data", "Situação" });
        }

        private void abrirEstoques()
        {
            //abrirLista("Estoques", new CallbackEstoqueNovo(), new CallbackEstoqueObter(), new CallbackEstoqueAlterar(), false, new String[] { "Código", "Ingrediente", "Fornecedor", "Quantidade", "Validade", "Valor" });
        }

        private void sair()
        {
            Close();
        }

        private void frmGerenciador_Load(object sender, EventArgs e)
        {
            clnUtil.atualizarForm(this);
            uixButton.btnApply(btnVoltar, AppDesktop.VisualStyle.ButtonWarningColor);

            abrirFuncionarios();
        }
        private void hdrUIX_Close(object sender, EventArgs e)
        {
            sair();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            sair();
        }

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            abrirIngredientes();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirClientes();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            abrirProdutos();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            abrirFuncionarios();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            abrirFornecedores();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            abrirEstoques();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            abrirReservas();
        }

        private class CallbackIngredienteNovo : IUtilCallback
        {
            public bool call()
            {
                frmIngrediente frmNovoIngrediente = new frmIngrediente { };
                frmNovoIngrediente.ShowDialog();
                return frmNovoIngrediente.ObjIngrediente != null;
            }
        }

        private class CallbackIngredienteAlterar : IUtilCallback<DataGridViewRow>
        {
            public bool call(DataGridViewRow row)
            {
                clnIngrediente objIngrediente = new clnIngrediente
                {
                    Cod = UtilConvert.ToInt(row.Cells[0].Value)
                }.obterPorCod();

                if (objIngrediente != null)
                {
                    frmIngrediente frmAlterarIngrediente = new frmIngrediente
                    {
                        ObjIngrediente = objIngrediente
                    };
                    frmAlterarIngrediente.ShowDialog();
                    return true;
                }
                return false;
            }
        }

        private class CallbackIngredienteObter : IUtilCallback<DataGridView, String, bool>
        {
            public bool call(DataGridView dgv, string pesquisa, bool ativo)
            {
                clnIngrediente objIngredientes = new clnIngrediente
                {
                    Nome = pesquisa,
                    Ativo = ativo
                };
                foreach (clnIngrediente objIngrediente in objIngredientes.obterPorNome())
                {
                    clnTipo objTipo = new clnTipo
                    {
                        Cod = objIngrediente.CodTipo,
                        Tipo = clnTipo.tipo.INGREDIENTE
                    }.obterPorCodigo();

                    int estoque = new clnEstoque
                    {
                        CodMercadoria = objIngrediente.Cod
                    }.obterQuantidadePorMercadoria();

                    //"Código", "Nome", "Situacao", "Tipo", "Estoque", "Valor"
                    dgv.Rows.Add(new object[] { objIngrediente.Cod, objIngrediente.Nome, objIngrediente.Situacao, objTipo.Cod + " - " + objTipo.Nome, estoque, UtilFormatar.formatarValor(objIngrediente.Valor) });
                }
                return false;
            }
        }

        private class CallbackProdutoNovo : IUtilCallback
        {
            public bool call()
            {
                frmProduto frmNovoProduto = new frmProduto { };
                frmNovoProduto.ShowDialog();
                return frmNovoProduto.ObjProduto != null;
            }
        }

        private class CallbackProdutoAlterar : IUtilCallback<DataGridViewRow>
        {
            public bool call(DataGridViewRow row)
            {
                clnProduto objProduto = new clnProduto
                {
                    Cod = UtilConvert.ToInt(row.Cells[0].Value)
                }.obterPorCod();

                if (objProduto != null)
                {
                    frmProduto frmAlterarProduto = new frmProduto
                    {
                        ObjProduto = objProduto
                    };
                    frmAlterarProduto.ShowDialog();
                    return true;
                }
                return false;
            }
        }

        private class CallbackProdutoObter : IUtilCallback<DataGridView, String, bool>
        {
            public bool call(DataGridView dgv, string pesquisa, bool ativo)
            {
                clnProduto objProdutos = new clnProduto
                {
                    Nome = pesquisa,
                    Ativo = ativo
                };
                foreach (clnProduto objProduto in objProdutos.obterPorNome())
                {
                    clnTipo objTipo = new clnTipo
                    {
                        Cod = objProduto.CodTipo,
                        Tipo = clnTipo.tipo.PRODUTO
                    }.obterPorCodigo();
                    //"Código", "Nome", "Situacao", "Tipo", "Estoque", "Valor"
                    dgv.Rows.Add(new object[] { objProduto.Cod, objProduto.Nome, objProduto.Situacao, objTipo.Cod + " - " + objTipo.Nome, UtilFormatar.formatarValor(objProduto.Valor) });
                }
                return false;
            }
        }

        private class CallbackClienteNovo : IUtilCallback
        {
            public bool call()
            {
                frmCliente frmNovoCliente = new frmCliente { };
                frmNovoCliente.ShowDialog();
                return frmNovoCliente.ObjCliente != null;
            }
        }

        private class CallbackClienteAlterar : IUtilCallback<DataGridViewRow>
        {
            public bool call(DataGridViewRow row)
            {
                clnCliente objCliente = new clnCliente
                {
                    Cod = UtilConvert.ToInt(row.Cells[0].Value)
                }.obterPorCod();

                if (objCliente != null)
                {
                    frmCliente frmAlterarCliente = new frmCliente
                    {
                        ObjCliente = objCliente
                    };
                    frmAlterarCliente.ShowDialog();
                    return true;
                }
                return false;
            }
        }

        private class CallbackClienteObter : IUtilCallback<DataGridView, String, bool>
        {
            public bool call(DataGridView dgv, string pesquisa, bool ativo)
            {
                clnCliente objClientes = new clnCliente
                {
                    Nome = pesquisa,
                    Cpf = pesquisa,
                    Ativo = ativo
                };
                foreach (clnCliente objCliente in objClientes.obterPorNomeCPF())
                {
                    //"Código", "Nome", "CPF", "Celular", "Data Nasc", "Genero", "Email"
                    dgv.Rows.Add(new object[] { objCliente.Cod, objCliente.Nome, UtilFormatar.formatarCPF(objCliente.Cpf), UtilFormatar.formatarCelular(objCliente.TelCelular), UtilFormatar.formatarData(objCliente.DataNascimento), objCliente.Genero, objCliente.Email });
                }
                return false;
            }
        }

        private class CallbackFuncionarioNovo : IUtilCallback
        {
            public bool call()
            {
                frmFuncionario frmNovoFuncionario = new frmFuncionario();
                frmNovoFuncionario.ShowDialog();
                return frmNovoFuncionario.ObjFuncionario != null;
            }
        }

        private class CallbackFuncionarioAlterar : IUtilCallback<DataGridViewRow>
        {
            public bool call(DataGridViewRow row)
            {
                clnFuncionario objFuncionario = new clnFuncionario
                {
                    Cod = UtilConvert.ToInt(row.Cells[0].Value)
                }.obterPorCod();

                if (objFuncionario != null)
                {
                    frmFuncionario frmAlterarFuncionario = new frmFuncionario
                    {
                        ObjFuncionario = objFuncionario
                    };
                    frmAlterarFuncionario.ShowDialog();
                    return true;
                }
                return false;
            }
        }

        private class CallbackFuncionarioObter : IUtilCallback<DataGridView, String, bool>
        {
            public bool call(DataGridView dgv, string pesquisa, bool ativo)
            {
                clnFuncionario objFuncionarios = new clnFuncionario
                {
                    Nome = pesquisa,
                    Cpf = pesquisa,
                    Ativo = ativo
                };
                foreach (clnFuncionario objFuncionario in objFuncionarios.obterPorNomeCPF())
                {
                    clnCargo objCargo = new clnCargo
                    {
                        Cod = objFuncionario.CodCargo
                    }.obterPorCod();

                    //"Código", "Nome", "CPF", "RG", "Data Nasc", "Genero", "Email","Celular", "Cargo", "Salario", "Situacao"
                    dgv.Rows.Add(new object[] { objFuncionario.Cod, objFuncionario.Nome, UtilFormatar.formatarCPF(objFuncionario.Cpf), objFuncionario.Rg, UtilFormatar.formatarData(objFuncionario.DataNascimento), objFuncionario.Genero, objCargo.Nome, UtilFormatar.formatarValor(objFuncionario.Salario), objFuncionario.Situacao });
                }
                return false;
            }
        }

        private class CallbackFornecedorNovo : IUtilCallback
        {
            public bool call()
            {
                frmFornecedor frmNovoFornecedor = new frmFornecedor();
                frmNovoFornecedor.ShowDialog();
                return frmNovoFornecedor.ObjFornecedor != null;
            }
        }

        private class CallbackFornecedorAlterar : IUtilCallback<DataGridViewRow>
        {
            public bool call(DataGridViewRow row)
            {
                clnFornecedor objFornecedor = new clnFornecedor
                {
                    Cod = UtilConvert.ToInt(row.Cells[0].Value)
                }.obterPorCod();

                if (objFornecedor != null)
                {
                    frmFornecedor frmAlterarFornecedor = new frmFornecedor
                    {
                        ObjFornecedor = objFornecedor
                    };
                    frmAlterarFornecedor.ShowDialog();
                    return true;
                }
                return false;
            }
        }

        private class CallbackFornecedorObter : IUtilCallback<DataGridView, String, bool>
        {
            public bool call(DataGridView dgv, string pesquisa, bool ativo)
            {
                clnFornecedor objFornecedores = new clnFornecedor
                {
                    RazaoSocial = pesquisa,
                    Cnpj = pesquisa,
                    Ativo = ativo
                };
                foreach (clnFornecedor objFornecedor in objFornecedores.obterPorRazaoCNPJ())
                {
                    //"Código", "Razão Social", "CNPJ", "Telefone", "Email"
                    dgv.Rows.Add(new object[] { objFornecedor.Cod, objFornecedor.RazaoSocial, UtilFormatar.formatarCNPJ(objFornecedor.Cnpj), UtilFormatar.formatarTelefone(objFornecedor.Telefone), objFornecedor.Email });
                }
                return false;
            }
        }

        private class CallbackReservaNovo : IUtilCallback
        {
            public bool call()
            {
                frmReserva frmNovoReserva = new frmReserva { };
                frmNovoReserva.ShowDialog();
                return frmNovoReserva.ObjReserva != null;
            }
        }

        private class CallbackReservaAlterar : IUtilCallback<DataGridViewRow>
        {
            public bool call(DataGridViewRow row)
            {
                clnReserva objReserva = new clnReserva
                {
                    Cod = UtilConvert.ToInt(row.Cells[0].Value)
                }.obterPorCod();

                if (objReserva != null)
                {
                    frmReserva frmAlterarReserva = new frmReserva
                    {
                        ObjReserva = objReserva
                    };
                    frmAlterarReserva.ShowDialog();
                    return true;
                }
                return false;
            }
        }

        private class CallbackReservaObter : IUtilCallback<DataGridView, String, bool>
        {
            public bool call(DataGridView dgv, string pesquisa, bool ativo)
            {
                DateTime? data = UtilConvert.ObterNullableData(pesquisa);
                List<clnReserva> objReservas = null;
                if (data != null)
                {
                    objReservas = new clnReserva
                    {
                        Agendado = (DateTime)data,
                        Ativo = !ativo

                    }.obterPorDataAgendada();
                }
                else
                {
                    objReservas = new clnReserva
                    {
                        Ativo = ativo
                    }.obterReservas();
                }
                foreach (clnReserva objReserva in objReservas)
                {
                    //"Código", "Pessoas", "Data", "Situação"
                    dgv.Rows.Add(new object[] { objReserva.Cod, objReserva.Pessoas, UtilFormatar.formatarData(objReserva.Agendado), objReserva.Situacao });
                }
                return false;
            }
        }

        private class CallbackEstoqueNovo : IUtilCallback
        {
            public bool call()
            {
                frmEstoque frmNovoEstoque = new frmEstoque();
                frmNovoEstoque.ShowDialog();
                return frmNovoEstoque.ObjEstoque != null;
            }
        }

        private class CallbackEstoqueAlterar : IUtilCallback<DataGridViewRow>
        {
            public bool call(DataGridViewRow row)
            {
                clnEstoque objEstoque = new clnEstoque
                {
                    Cod = UtilConvert.ToInt(row.Cells[0].Value)
                }.obterPorCod();

                if (objEstoque != null)
                {
                    frmEstoque frmAlterarEstoque = new frmEstoque
                    {
                        ObjEstoque = objEstoque
                    };
                    frmAlterarEstoque.ShowDialog();
                    return true;
                }
                return false;
            }
        }

        private class CallbackEstoqueObter : IUtilCallback<DataGridView, String>
        {
            public bool call(DataGridView dgv, string pesquisa)
            {
                clnEstoque objEstoques = new clnEstoque();
                foreach (clnEstoque objEstoque in objEstoques.obterEstoques())
                {
                    clnIngrediente objIngrediente = new clnIngrediente
                    {
                        Cod = objEstoque.CodMercadoria
                    }.obterPorCod();

                    clnFornecedor objFornecedor = new clnFornecedor
                    {
                        Cod = objEstoque.CodFornecedor
                    }.obterPorCod();

                    //"Código", "Ingrediente", "Fornecedor", "Quantidade", "Validade", "Valor"
                    dgv.Rows.Add(new object[] { objEstoque.Cod, objIngrediente.Nome, objFornecedor.RazaoSocial, objEstoque.Quantidade, UtilFormatar.formatarData(objEstoque.Validade), UtilFormatar.formatarValor(objEstoque.Valor) });
                }
                return false;
            }
        }


    }
}
