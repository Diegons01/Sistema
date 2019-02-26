namespace Sistema.View.View
{
    partial class FrmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTela = new System.Windows.Forms.ToolStripLabel();
            this.toolStripHora = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnCadastrarVendedor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTela,
            this.toolStripHora});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTela
            // 
            this.toolStripTela.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripTela.Name = "toolStripTela";
            this.toolStripTela.Size = new System.Drawing.Size(79, 22);
            this.toolStripTela.Text = "    Bem vindo!";
            // 
            // toolStripHora
            // 
            this.toolStripHora.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripHora.Name = "toolStripHora";
            this.toolStripHora.Size = new System.Drawing.Size(49, 22);
            this.toolStripHora.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Relogio_Tick);
            // 
            // btnProduto
            // 
            this.btnProduto.Image = global::Sistema.View.Properties.Resources.basket;
            this.btnProduto.Location = new System.Drawing.Point(257, 70);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(152, 111);
            this.btnProduto.TabIndex = 6;
            this.btnProduto.Text = "Cadastrar Produto";
            this.btnProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnCadastrarVendedor
            // 
            this.btnCadastrarVendedor.Image = global::Sistema.View.Properties.Resources.Vendedor;
            this.btnCadastrarVendedor.Location = new System.Drawing.Point(56, 70);
            this.btnCadastrarVendedor.Name = "btnCadastrarVendedor";
            this.btnCadastrarVendedor.Size = new System.Drawing.Size(152, 111);
            this.btnCadastrarVendedor.TabIndex = 5;
            this.btnCadastrarVendedor.Text = "Cadastrar Vendedor";
            this.btnCadastrarVendedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCadastrarVendedor.UseVisualStyleBackColor = true;
            this.btnCadastrarVendedor.Click += new System.EventHandler(this.btnCadastrarVendedor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BackgroundImage = global::Sistema.View.Properties.Resources.loginescuro3;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(849, 399);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 399);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.btnCadastrarVendedor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripTela;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCadastrarVendedor;
        private System.Windows.Forms.ToolStripLabel toolStripHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnProduto;
    }
}