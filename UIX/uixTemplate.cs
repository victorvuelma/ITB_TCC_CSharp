﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace UIX
{
    public class uixTemplate
    {

        private uixStyle _style;

        public uixTemplate(uixStyle style)
        {
            this._style = style;
        }

        public void ctlApply(Control[] ctls)
        {
            foreach (Control control in ctls)
            {
                this.ctlApply(control);
            }
        }

        public void ctlApply(Control ctl)
        {

            if (ctl is btnUIX)
            {
                btnUIX btn = (btnUIX)ctl;
                uixButton.btnApply(btn, Style.ButtonColor, Style.BoldFont);
                btn.HoverColor = Style.ButtonColor.DarkColor;
            }
            else if (ctl is Button)
            {
                this.btnApply((Button)ctl);
            }
            else if (ctl is ComboBox)
            {
                this.cboApply((ComboBox)ctl);
            }
            else if(ctl is DataGridView)
            {
                this.dgvApply((DataGridView)ctl);
            }
            else if (ctl is GroupBox)
            {
                this.grbApply((GroupBox)ctl);
            }
            else if (ctl is Label)
            {
                this.lblApply((Label)ctl);
            }
            else if (ctl is Panel)
            {
                this.pnlApply((Panel)ctl);
            }
            else if (ctl is MaskedTextBox)
            {
                this.mtbApply((MaskedTextBox)ctl);
            }
            else if (ctl is TextBox)
            {
                this.txtApply((TextBox)ctl);
            }
            else if (ctl is UserControl)
            {
                this.uctApply((UserControl)ctl);
            }
        }

        public void btnApply(Button btn)
        {
            uixButton.btnApply(btn, Style.ButtonColor, Style.BoldFont);
        }

        public void cboApply(ComboBox cbo)
        {
            uixComboBox.cboApply(cbo, Style.ButtonColor, Style.ContentFont);
        }

        public void dgvApply(DataGridView dgv)
        {
            uixDataGridView.dgvApply(dgv, Style.TextBoxColor, Style.PanelColor, Style.BoldFont);
        }

        public void grbApply(GroupBox grb)
        {
            uixGroupBox.grbApply(grb, Style.GroupBoxColor, Style.ContentFont);

            foreach (Control ctl in grb.Controls)
            {
                ctlApply(ctl);
                if(ctl is Panel)
                {
                    ctl.BackColor = grb.BackColor;
                }
            }
        }

        public void lblApply(Label lbl)
        {
            uixLabel.lblApply(lbl, Style.LabelColor, Style.ContentFont);
        }

        public void mtbApply(MaskedTextBox mtb)
        {
            uixMaskedTextBox.mtbApply(mtb, Style.TextBoxColor, Style.ContentFont);
        }

        public void pnlApply(Panel pnl)
        {
            uixPanel.pnlApply(pnl, Style.PanelColor, Style.ContentFont);

            foreach (Control ctl in pnl.Controls)
            {
                ctlApply(ctl);
            }
        }

        public void txtApply(TextBox txt)
        {
            uixTextBox.txtApply(txt, Style.TextBoxColor, Style.ContentFont);
        }

        public void uctApply(UserControl uct)
        {
            uixUserControl.uctApply(uct, Style.FormColor, Style.ContentFont);

            foreach (Control ctl in uct.Controls)
            {
                ctlApply(ctl);
            }
        }

        public void frmApply(Form frm, uctUIX ctl)
        {

            uixForm.frmApply(frm, ctl, Style);

            foreach (Control control in frm.Controls)
            {
                if (control != ctl)
                {
                    this.ctlApply(control);
                }
            }

            uixForm.applyMargin(frm, Style);
        }

        public uixStyle Style { get => _style; }

    }

}
