﻿namespace BURGUER_SHACK_DESKTOP
{
    partial class uctPedidoAlterar
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbPedidoAlterar = new System.Windows.Forms.GroupBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.ltbProdutos = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlPreco = new System.Windows.Forms.Panel();
            this.dgvClienteProduto = new System.Windows.Forms.DataGridView();
            this.lblNomeProduto2 = new System.Windows.Forms.Label();
            this.txtPesquisa2 = new System.Windows.Forms.TextBox();
            this.grbPedidoAlterar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // grbPedidoAlterar
            // 
            this.grbPedidoAlterar.Controls.Add(this.dgvClienteProduto);
            this.grbPedidoAlterar.Controls.Add(this.lblNomeProduto2);
            this.grbPedidoAlterar.Controls.Add(this.txtPesquisa2);
            this.grbPedidoAlterar.Controls.Add(this.ltbProdutos);
            this.grbPedidoAlterar.Controls.Add(this.button1);
            this.grbPedidoAlterar.Controls.Add(this.pnlPreco);
            this.grbPedidoAlterar.Controls.Add(this.dgvProdutos);
            this.grbPedidoAlterar.Controls.Add(this.lblNomeProduto);
            this.grbPedidoAlterar.Controls.Add(this.txtPesquisa);
            this.grbPedidoAlterar.Location = new System.Drawing.Point(5, 5);
            this.grbPedidoAlterar.Name = "grbPedidoAlterar";
            this.grbPedidoAlterar.Size = new System.Drawing.Size(423, 597);
            this.grbPedidoAlterar.TabIndex = 6;
            this.grbPedidoAlterar.TabStop = false;
            this.grbPedidoAlterar.Text = "ALTERAR PEDIDO";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(5, 50);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(410, 164);
            this.dgvProdutos.TabIndex = 2;
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Location = new System.Drawing.Point(6, 23);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(118, 13);
            this.lblNomeProduto.TabIndex = 1;
            this.lblNomeProduto.Text = "NOME DO PRODUTO:";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(144, 24);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(270, 20);
            this.txtPesquisa.TabIndex = 0;
            // 
            // ltbProdutos
            // 
            this.ltbProdutos.FormattingEnabled = true;
            this.ltbProdutos.Location = new System.Drawing.Point(5, 455);
            this.ltbProdutos.Name = "ltbProdutos";
            this.ltbProdutos.Size = new System.Drawing.Size(260, 134);
            this.ltbProdutos.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 38);
            this.button1.TabIndex = 12;
            this.button1.Text = "Confirmar Pedido";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlPreco
            // 
            this.pnlPreco.BackColor = System.Drawing.Color.White;
            this.pnlPreco.Location = new System.Drawing.Point(271, 455);
            this.pnlPreco.Name = "pnlPreco";
            this.pnlPreco.Size = new System.Drawing.Size(144, 90);
            this.pnlPreco.TabIndex = 11;
            // 
            // dgvClienteProduto
            // 
            this.dgvClienteProduto.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClienteProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClienteProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClienteProduto.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvClienteProduto.Location = new System.Drawing.Point(5, 273);
            this.dgvClienteProduto.Name = "dgvClienteProduto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClienteProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvClienteProduto.Size = new System.Drawing.Size(410, 164);
            this.dgvClienteProduto.TabIndex = 16;
            // 
            // lblNomeProduto2
            // 
            this.lblNomeProduto2.AutoSize = true;
            this.lblNomeProduto2.Location = new System.Drawing.Point(6, 246);
            this.lblNomeProduto2.Name = "lblNomeProduto2";
            this.lblNomeProduto2.Size = new System.Drawing.Size(118, 13);
            this.lblNomeProduto2.TabIndex = 15;
            this.lblNomeProduto2.Text = "NOME DO PRODUTO:";
            // 
            // txtPesquisa2
            // 
            this.txtPesquisa2.Location = new System.Drawing.Point(144, 247);
            this.txtPesquisa2.Name = "txtPesquisa2";
            this.txtPesquisa2.Size = new System.Drawing.Size(270, 20);
            this.txtPesquisa2.TabIndex = 14;
            // 
            // uctPedidoAlterar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbPedidoAlterar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "uctPedidoAlterar";
            this.Size = new System.Drawing.Size(433, 606);
            this.grbPedidoAlterar.ResumeLayout(false);
            this.grbPedidoAlterar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPedidoAlterar;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.ListBox ltbProdutos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlPreco;
        private System.Windows.Forms.DataGridView dgvClienteProduto;
        private System.Windows.Forms.Label lblNomeProduto2;
        private System.Windows.Forms.TextBox txtPesquisa2;
    }
}