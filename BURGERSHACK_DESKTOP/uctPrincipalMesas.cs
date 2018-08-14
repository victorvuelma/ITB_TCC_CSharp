﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vitorrdgs.UiX.Component;
using vitorrdgs.UiX.Property;

namespace BurgerShack.Desktop
{
    public partial class uctPrincipalMesas : UserControl
    {

        private int _codFuncionario;

        public int CodFuncionario { get => _codFuncionario; set => _codFuncionario = value; }

        public uctPrincipalMesas()
        {
            InitializeComponent();
        }

        private void exibirMesas()
        {
            pnlMesas.Controls.Clear();

            List<Control> mesaControles = new List<Control>();
            foreach (clnMesa objMesa in new clnMesa().obterMesas())
            {
                UIXButton btn = new UIXButton
                {
                    Description = "MESA " + objMesa.Cod,
                    Name = "btnMesa" + objMesa.Cod,
                    Size = new Size(100, 100)
                };
                if (objMesa.Situacao == clnMesa.mesaSituacao.DISPONIVEL)
                {
                    btn.Image = Properties.Resources.mesa;
                }
                else
                {
                    btn.ForeColor = pnlOcupada.BackColor;
                    btn.Image = Properties.Resources.mesauso;
                }
                btn.Click += (object sender, EventArgs e) =>
                {
                    abrirMesa(objMesa);
                };

                mesaControles.Add(btn);
            }
            clnUtil.adicionarControles(pnlMesas, mesaControles, 20);
            mesaControles.Clear();
        }

        private void abrirMesa(clnMesa objMesa)
        {
            clnAtendimento objAtendimento = null;
            if (objMesa.Situacao == clnMesa.mesaSituacao.OCUPADA)
            {
                int? codAtendimento = objMesa.obterCodAtendimento();

                if (codAtendimento != null)
                {
                    objAtendimento = new clnAtendimento
                    {
                        Cod = (int)codAtendimento
                    }.obterPorCodigo();
                }
            }
            else
            {
                if (clnUtilMensagem.mostrarSimNao("Atendimento", "Você deseja iniciar um novo atendimento para a Mesa " + objMesa.Cod + "?", clnUtilMensagem.MensagemIcone.INFO))
                {
                    objAtendimento = new clnAtendimento
                    {
                        CodFuncionario = CodFuncionario,
                        Inicio = DateTime.Now,
                        Situacao = clnAtendimento.atendimentoSituacao.ANDAMENTO
                    };
                    objAtendimento.gravar();

                    objAtendimento.adicionarMesa(objMesa.Cod);

                    objMesa.Situacao = clnMesa.mesaSituacao.OCUPADA;
                    objMesa.alterar();
                }
                else
                {
                    return;
                }
            }
            frmAtendimento frmAtendimento = new frmAtendimento
            {
                ObjAtendimento = objAtendimento,
                CodFuncionario = CodFuncionario
            };
            frmAtendimento.ShowDialog();

            exibirMesas();
        }

        private void uctPedidoMesa_Load(object sender, EventArgs e)
        {
            pnlLivre.BackColor = uixColor.WHITE;
            pnlOcupada.BackColor = uixColor.INDIGO_DARK;

            exibirMesas();
        }

    }
}