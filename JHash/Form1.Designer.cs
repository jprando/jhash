namespace JHashWin
{
    partial class FormPrincipal
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
            this.btnCalcular = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.registrarNoMenuDeContextoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.txtMD5 = new System.Windows.Forms.TextBox();
            this.txtSHA1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtSHA256 = new System.Windows.Forms.TextBox();
            this.txtSHA512 = new System.Windows.Forms.TextBox();
            this.lblNomeArquivo = new System.Windows.Forms.Label();
            this.lblExtencaoArquivo = new System.Windows.Forms.Label();
            this.txtComparar = new System.Windows.Forms.TextBox();
            this.lblComparar = new System.Windows.Forms.Label();
            this.ckbMD5 = new System.Windows.Forms.CheckBox();
            this.popMenuHash = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSelecionarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInverterSelecao = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelecionarArquivo = new System.Windows.Forms.Button();
            this.ckbSHA1 = new System.Windows.Forms.CheckBox();
            this.ckbSHA256 = new System.Windows.Forms.CheckBox();
            this.ckbSHA512 = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.menuCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            this.popMenuHash.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalcular
            // 
            this.btnCalcular.ContextMenuStrip = this.contextMenuStrip1;
            this.btnCalcular.Enabled = false;
            this.btnCalcular.Location = new System.Drawing.Point(108, 12);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(90, 25);
            this.btnCalcular.TabIndex = 1;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarNoMenuDeContextoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(234, 26);
            // 
            // registrarNoMenuDeContextoToolStripMenuItem
            // 
            this.registrarNoMenuDeContextoToolStripMenuItem.Name = "registrarNoMenuDeContextoToolStripMenuItem";
            this.registrarNoMenuDeContextoToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.registrarNoMenuDeContextoToolStripMenuItem.Text = "registrar no menu de contexto";
            this.registrarNoMenuDeContextoToolStripMenuItem.Click += new System.EventHandler(this.registrarNoMenuDeContextoToolStripMenuItem_Click);
            // 
            // lblArquivo
            // 
            this.lblArquivo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivo.Location = new System.Drawing.Point(12, 86);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(468, 32);
            this.lblArquivo.TabIndex = 2;
            this.lblArquivo.Text = "...";
            // 
            // txtMD5
            // 
            this.txtMD5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMD5.Location = new System.Drawing.Point(12, 138);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.ReadOnly = true;
            this.txtMD5.Size = new System.Drawing.Size(455, 20);
            this.txtMD5.TabIndex = 6;
            // 
            // txtSHA1
            // 
            this.txtSHA1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA1.Location = new System.Drawing.Point(12, 188);
            this.txtSHA1.Name = "txtSHA1";
            this.txtSHA1.ReadOnly = true;
            this.txtSHA1.Size = new System.Drawing.Size(455, 20);
            this.txtSHA1.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtSHA256
            // 
            this.txtSHA256.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA256.Location = new System.Drawing.Point(12, 238);
            this.txtSHA256.Name = "txtSHA256";
            this.txtSHA256.ReadOnly = true;
            this.txtSHA256.Size = new System.Drawing.Size(455, 20);
            this.txtSHA256.TabIndex = 10;
            // 
            // txtSHA512
            // 
            this.txtSHA512.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHA512.Location = new System.Drawing.Point(12, 288);
            this.txtSHA512.Multiline = true;
            this.txtSHA512.Name = "txtSHA512";
            this.txtSHA512.ReadOnly = true;
            this.txtSHA512.Size = new System.Drawing.Size(455, 37);
            this.txtSHA512.TabIndex = 12;
            // 
            // lblNomeArquivo
            // 
            this.lblNomeArquivo.AutoSize = true;
            this.lblNomeArquivo.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeArquivo.Location = new System.Drawing.Point(12, 46);
            this.lblNomeArquivo.Name = "lblNomeArquivo";
            this.lblNomeArquivo.Size = new System.Drawing.Size(38, 18);
            this.lblNomeArquivo.TabIndex = 3;
            this.lblNomeArquivo.Text = "...";
            // 
            // lblExtencaoArquivo
            // 
            this.lblExtencaoArquivo.AutoSize = true;
            this.lblExtencaoArquivo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtencaoArquivo.Location = new System.Drawing.Point(12, 68);
            this.lblExtencaoArquivo.Name = "lblExtencaoArquivo";
            this.lblExtencaoArquivo.Size = new System.Drawing.Size(28, 14);
            this.lblExtencaoArquivo.TabIndex = 4;
            this.lblExtencaoArquivo.Text = "...";
            // 
            // txtComparar
            // 
            this.txtComparar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComparar.Location = new System.Drawing.Point(12, 345);
            this.txtComparar.Multiline = true;
            this.txtComparar.Name = "txtComparar";
            this.txtComparar.Size = new System.Drawing.Size(455, 37);
            this.txtComparar.TabIndex = 14;
            this.txtComparar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtComparar.Enter += new System.EventHandler(this.txtComparar_Enter);
            this.txtComparar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComparar_KeyDown);
            // 
            // lblComparar
            // 
            this.lblComparar.AutoSize = true;
            this.lblComparar.Location = new System.Drawing.Point(12, 328);
            this.lblComparar.Name = "lblComparar";
            this.lblComparar.Size = new System.Drawing.Size(77, 14);
            this.lblComparar.TabIndex = 13;
            this.lblComparar.Text = "COMPARAÇÃO";
            // 
            // ckbMD5
            // 
            this.ckbMD5.AutoSize = true;
            this.ckbMD5.Checked = true;
            this.ckbMD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMD5.Location = new System.Drawing.Point(12, 114);
            this.ckbMD5.Name = "ckbMD5";
            this.ckbMD5.Size = new System.Drawing.Size(47, 18);
            this.ckbMD5.TabIndex = 5;
            this.ckbMD5.Text = "MD5";
            this.ckbMD5.UseVisualStyleBackColor = true;
            // 
            // popMenuHash
            // 
            this.popMenuHash.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelecionarTodos,
            this.menuInverterSelecao,
            this.toolStripSeparator1,
            this.menuCancelar});
            this.popMenuHash.Name = "popMenuHash";
            this.popMenuHash.Size = new System.Drawing.Size(215, 98);
            // 
            // menuSelecionarTodos
            // 
            this.menuSelecionarTodos.Name = "menuSelecionarTodos";
            this.menuSelecionarTodos.Size = new System.Drawing.Size(214, 22);
            this.menuSelecionarTodos.Text = "Selecionar Todos os Hashs";
            this.menuSelecionarTodos.Click += new System.EventHandler(this.selecionarTudoToolStripMenuItem_Click);
            // 
            // menuInverterSelecao
            // 
            this.menuInverterSelecao.Name = "menuInverterSelecao";
            this.menuInverterSelecao.Size = new System.Drawing.Size(214, 22);
            this.menuInverterSelecao.Text = "Inverter Seleção dos Hashs";
            this.menuInverterSelecao.Click += new System.EventHandler(this.inverterSeleçãoToolStripMenuItem_Click);
            // 
            // btnSelecionarArquivo
            // 
            this.btnSelecionarArquivo.Location = new System.Drawing.Point(12, 12);
            this.btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            this.btnSelecionarArquivo.Size = new System.Drawing.Size(90, 25);
            this.btnSelecionarArquivo.TabIndex = 0;
            this.btnSelecionarArquivo.Text = "Arquivo";
            this.btnSelecionarArquivo.UseVisualStyleBackColor = true;
            this.btnSelecionarArquivo.Click += new System.EventHandler(this.btnSelecionarArquivo_Click);
            // 
            // ckbSHA1
            // 
            this.ckbSHA1.AutoSize = true;
            this.ckbSHA1.Location = new System.Drawing.Point(12, 164);
            this.ckbSHA1.Name = "ckbSHA1";
            this.ckbSHA1.Size = new System.Drawing.Size(54, 18);
            this.ckbSHA1.TabIndex = 18;
            this.ckbSHA1.Text = "SHA1";
            this.ckbSHA1.UseVisualStyleBackColor = true;
            // 
            // ckbSHA256
            // 
            this.ckbSHA256.AutoSize = true;
            this.ckbSHA256.Location = new System.Drawing.Point(12, 214);
            this.ckbSHA256.Name = "ckbSHA256";
            this.ckbSHA256.Size = new System.Drawing.Size(68, 18);
            this.ckbSHA256.TabIndex = 19;
            this.ckbSHA256.Text = "SHA256";
            this.ckbSHA256.UseVisualStyleBackColor = true;
            // 
            // ckbSHA512
            // 
            this.ckbSHA512.AutoSize = true;
            this.ckbSHA512.Location = new System.Drawing.Point(12, 264);
            this.ckbSHA512.Name = "ckbSHA512";
            this.ckbSHA512.Size = new System.Drawing.Size(68, 18);
            this.ckbSHA512.TabIndex = 20;
            this.ckbSHA512.Text = "SHA512";
            this.ckbSHA512.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(204, 17);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 14);
            this.lblInfo.TabIndex = 21;
            // 
            // menuCancelar
            // 
            this.menuCancelar.Enabled = false;
            this.menuCancelar.Name = "menuCancelar";
            this.menuCancelar.Size = new System.Drawing.Size(214, 22);
            this.menuCancelar.Text = "Cancelar";
            this.menuCancelar.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 391);
            this.ContextMenuStrip = this.popMenuHash;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.ckbMD5);
            this.Controls.Add(this.ckbSHA512);
            this.Controls.Add(this.ckbSHA256);
            this.Controls.Add(this.ckbSHA1);
            this.Controls.Add(this.btnSelecionarArquivo);
            this.Controls.Add(this.lblComparar);
            this.Controls.Add(this.txtComparar);
            this.Controls.Add(this.lblExtencaoArquivo);
            this.Controls.Add(this.lblNomeArquivo);
            this.Controls.Add(this.txtSHA512);
            this.Controls.Add(this.txtSHA256);
            this.Controls.Add(this.txtSHA1);
            this.Controls.Add(this.txtMD5);
            this.Controls.Add(this.lblArquivo);
            this.Controls.Add(this.btnCalcular);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hash de Arquivo";
            this.contextMenuStrip1.ResumeLayout(false);
            this.popMenuHash.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArquivo;
        private System.Windows.Forms.TextBox txtMD5;
        private System.Windows.Forms.TextBox txtSHA1;
        private System.Windows.Forms.TextBox txtSHA512;
        private System.Windows.Forms.Label lblNomeArquivo;
        private System.Windows.Forms.Label lblExtencaoArquivo;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblComparar;
        public System.Windows.Forms.TextBox txtComparar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registrarNoMenuDeContextoToolStripMenuItem;
        public System.Windows.Forms.TextBox txtSHA256;
        private System.Windows.Forms.CheckBox ckbMD5;
        private System.Windows.Forms.Button btnSelecionarArquivo;
        private System.Windows.Forms.ContextMenuStrip popMenuHash;
        private System.Windows.Forms.ToolStripMenuItem menuSelecionarTodos;
        private System.Windows.Forms.ToolStripMenuItem menuInverterSelecao;
        private System.Windows.Forms.CheckBox ckbSHA1;
        private System.Windows.Forms.CheckBox ckbSHA256;
        private System.Windows.Forms.CheckBox ckbSHA512;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuCancelar;
    }
}

