﻿namespace BURGUER_SHACK_DESKTOP
{
    partial class frmCozinha
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
            this.uctUIX1 = new UIX.uctUIX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // uctUIX1
            // 
            this.uctUIX1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uctUIX1.Location = new System.Drawing.Point(0, 0);
            this.uctUIX1.Name = "uctUIX1";
            this.uctUIX1.Size = new System.Drawing.Size(250, 40);
            this.uctUIX1.TabIndex = 0;
            this.uctUIX1.UIXButtonCloseEnabled = true;
            this.uctUIX1.UIXButtonMinEnabled = true;
            this.uctUIX1.UIXTitle = "Titulo UIX";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvPedidos);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 379);
            this.panel1.TabIndex = 1;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(3, 3);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(988, 373);
            this.dgvPedidos.TabIndex = 0;
            // 
            // frmCozinha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 437);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uctUIX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCozinha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCozinha";
            this.Load += new System.EventHandler(this.frmCozinha_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIX.uctUIX uctUIX1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPedidos;
    }
}