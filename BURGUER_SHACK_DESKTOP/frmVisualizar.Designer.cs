﻿namespace BURGUER_SHACK_DESKTOP
{
    partial class frmVisualizar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizar));
            this.grbOpcoes = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisa = new UIX.txtUIX();
            this.pnlOpcoes = new System.Windows.Forms.Panel();
            this.hdrUIX = new UIX.hdrUIX();
            this.grbOpcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbOpcoes
            // 
            this.grbOpcoes.Controls.Add(this.btnPesquisar);
            this.grbOpcoes.Controls.Add(this.txtPesquisa);
            this.grbOpcoes.Controls.Add(this.pnlOpcoes);
            this.grbOpcoes.Location = new System.Drawing.Point(5, 55);
            this.grbOpcoes.Name = "grbOpcoes";
            this.grbOpcoes.Size = new System.Drawing.Size(550, 485);
            this.grbOpcoes.TabIndex = 5;
            this.grbOpcoes.TabStop = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(450, 15);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(95, 25);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.AccessibleName = "Pesquisar";
            this.txtPesquisa.AllowedChars = UIX.uixAllowedChars.ALL;
            this.txtPesquisa.Campo = "Pesquisar";
            this.txtPesquisa.Location = new System.Drawing.Point(5, 15);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPesquisa.MaxLength = 32767;
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(440, 25);
            this.txtPesquisa.TabIndex = 1;
            this.txtPesquisa.Leave += new System.EventHandler(this.txtPesquisa_Leave);
            // 
            // pnlOpcoes
            // 
            this.pnlOpcoes.AutoScroll = true;
            this.pnlOpcoes.Location = new System.Drawing.Point(5, 50);
            this.pnlOpcoes.MaximumSize = new System.Drawing.Size(540, 1000);
            this.pnlOpcoes.Name = "pnlOpcoes";
            this.pnlOpcoes.Size = new System.Drawing.Size(540, 425);
            this.pnlOpcoes.TabIndex = 0;
            // 
            // hdrUIX
            // 
            this.hdrUIX.BackColor = System.Drawing.SystemColors.ControlDark;
            this.hdrUIX.ButtonCloseEnabled = true;
            this.hdrUIX.ButtonMinEnabled = false;
            this.hdrUIX.Image = null;
            this.hdrUIX.Location = new System.Drawing.Point(0, 0);
            this.hdrUIX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hdrUIX.Name = "hdrUIX";
            this.hdrUIX.Size = new System.Drawing.Size(560, 50);
            this.hdrUIX.TabIndex = 4;
            this.hdrUIX.Title = "Visualizar";
            this.hdrUIX.Close += new System.EventHandler(this.hdrUIX_Close);
            // 
            // frmVisualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 550);
            this.Controls.Add(this.grbOpcoes);
            this.Controls.Add(this.hdrUIX);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVisualizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selecione";
            this.Load += new System.EventHandler(this.frmSelecionar_Load);
            this.grbOpcoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbOpcoes;
        private UIX.hdrUIX hdrUIX;
        private System.Windows.Forms.Panel pnlOpcoes;
        private UIX.txtUIX txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
    }
}