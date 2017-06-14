using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHashWin
{
    public partial class FormPrincipal : Form
    {
        #region variaveis e propriedades

        CancellationTokenSource tokenMain = null;

        #endregion

        #region Construtor

        public FormPrincipal()
        {
            InitializeComponent();
            openFileDialog1.FileName = String.Empty;
        }

        #endregion

        #region Hash

        #region Inicializacao

        public void CalcularHashInit()
        {
            lblArquivo.Text = String.Empty;
            lblNomeArquivo.Text = String.Empty;
            lblExtencaoArquivo.Text = String.Empty;
            this.CalcularHashInitHash();
        }

        private void CalcularHashInitHash()
        {
            this.MudarText(ckbMD5, "MD5");
            this.MudarText(ckbSHA1, "SHA1");
            this.MudarText(ckbSHA256, "SHA256");
            this.MudarText(ckbSHA512, "SHA512");

            this.MudarText(txtMD5, String.Empty);
            this.MudarText(txtSHA1, String.Empty);
            this.MudarText(txtSHA256, String.Empty);
            this.MudarText(txtSHA512, String.Empty);

            this.MudarBackColor(txtMD5, Color.White);
            this.MudarBackColor(txtSHA1, Color.White);
            this.MudarBackColor(txtSHA256, Color.White);
            this.MudarBackColor(txtSHA512, Color.White);
            this.MudarBackColor(txtComparar, Color.White);

            this.MudarForeColor(txtComparar, Color.White);
            this.MudarForeColor(txtComparar, Color.Black);
        }

        public void CalcularHashOnLoad(String caminhoArquivo)
        {
            lblArquivo.Text = Path.GetDirectoryName(caminhoArquivo);

            lblNomeArquivo.Font = new Font(lblNomeArquivo.Font.FontFamily, 12f, FontStyle.Bold);
            lblNomeArquivo.Text = Path.GetFileNameWithoutExtension(caminhoArquivo);
            if (lblNomeArquivo.Text.Length > 47)
            { lblNomeArquivo.Font = new Font(lblNomeArquivo.Font.FontFamily, 8.25f, FontStyle.Regular); }

            long tamanhoArquivo = new FileInfo(caminhoArquivo).Length;

            String tamanhoArquivoText = String.Concat(tamanhoArquivo.ToString(".00"), " Bytes");

            if (tamanhoArquivo >= 1099511627776)
            { tamanhoArquivoText = String.Concat((tamanhoArquivo / (1024 * 1024 * 1024.00)).ToString(".00"), " TB"); }
            else
                if (tamanhoArquivo >= 1024 * 1024 * 1024)
                { tamanhoArquivoText = String.Concat((tamanhoArquivo / (1024 * 1024 * 1024.00)).ToString(".00"), " GB"); }
                else
                    if (tamanhoArquivo >= 1024 * 1024)
                    { tamanhoArquivoText = String.Concat((tamanhoArquivo / (1024 * 1024.00)).ToString(".00"), " MB"); }
                    else
                        if (tamanhoArquivo >= 1024)
                        { tamanhoArquivoText = String.Concat((tamanhoArquivo / 1024.00).ToString(".00"), " KB"); }

            tamanhoArquivoText = tamanhoArquivoText.Replace(",00 ", " ");
            if (tamanhoArquivoText.Trim() == "Bytes")
            { tamanhoArquivoText = "0 Bytes"; }
            tamanhoArquivoText = String.Format("[ {0} ]", tamanhoArquivoText);

            lblExtencaoArquivo.Text = String.Concat(Path.GetExtension(caminhoArquivo), " ", tamanhoArquivoText);
        }

        #endregion

        #region Calcular

        internal void CalcularHash(String caminhoArquivo)
        {
            CancellationTokenSource tokenRelogio = null;
            Stream streamArquivo = null;
            DateTime hashInitDateTime = DateTime.Now;
            try
            {
                tokenRelogio = new CancellationTokenSource();
                tokenMain = new CancellationTokenSource();
                tokenMain.Token.Register(() =>
                {
                    /// quando cancelar executar estes passos
                    tokenRelogio.Cancel();
                    if (streamArquivo != null)
                    { streamArquivo.Close(); }
                    this.MudarText(this.lblInfo, "Cancelado!");
                    this.HabilitarBotoes();
                    this.MudarEnableds(true, ckbMD5, ckbSHA1, ckbSHA256, ckbSHA512);
                    this.MenuMudarEnableds(true, this.menuSelecionarTodos, this.menuInverterSelecao);
                    this.MenuMudarEnabled(false, this.menuCancelar);
                });

                Task.Factory.StartNew(() =>
                {
                    this.CalcularHashInitHash();
                    this.MudarEnableds(false, this.btnCalcular, this.btnSelecionarArquivo);
                    this.MenuMudarEnableds(false, this.menuSelecionarTodos, this.menuInverterSelecao);
                    this.MenuMudarEnabled(true, this.menuCancelar);
                    this.MudarText(this.lblInfo, "Carregando...");
                    hashInitDateTime = DateTime.Now;
                    streamArquivo = new BufferedStream(File.OpenRead(caminhoArquivo), 1000000);
                }, tokenMain.Token)
                .ContinueWith(t =>
                { this.MudarText(this.lblInfo, "Processando..."); }, tokenMain.Token)
                .ContinueWith(t =>
                {
                    this.MudarEnableds(false, ckbMD5, ckbSHA1, ckbSHA256, ckbSHA512);
                    Task taskRelogio = Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            if (tokenRelogio.IsCancellationRequested)
                            { break; }
                            this.MudarText(this.lblInfo, (DateTime.Now - hashInitDateTime).ToString());
                            Application.DoEvents();
                            Thread.Sleep(1000);
                        }
                    }, tokenRelogio.Token);

                    Task taskHash =
                        Task.Factory.StartNew(
                                  () => { if (ckbMD5.Checked) { this.CalcularHashMD5(streamArquivo); } }, tokenMain.Token)
                    .ContinueWith(tt => { if (ckbSHA1.Checked) { this.CalcularHashSHA1(streamArquivo); } }, tokenMain.Token)
                    .ContinueWith(tt => { if (ckbSHA256.Checked) { this.CalcularHashSHA256(streamArquivo); } }, tokenMain.Token)
                    .ContinueWith(tt => { if (ckbSHA512.Checked) { this.CalcularHashSHA512(streamArquivo); } }, tokenMain.Token);

                    taskHash.Wait();
                    if (streamArquivo != null)
                    { streamArquivo.Close(); }
                    tokenRelogio.Cancel();
                }, tokenMain.Token)
                .ContinueWith(t =>
                {
                    this.MudarEnableds(true, ckbMD5, ckbSHA1, ckbSHA256, ckbSHA512);
                    this.MenuMudarEnableds(true, this.menuSelecionarTodos, this.menuInverterSelecao);
                    this.MenuMudarEnabled(false, this.menuCancelar);
                    this.CompararHash();
                    this.HabilitarBotoes();
                }, tokenMain.Token)
                .ContinueWith(t => GC.Collect());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private String CalcularHashMD5(String caminhoArquivo)
        { return this.CalcularHashMD5(File.Open(caminhoArquivo, FileMode.Open, FileAccess.Read)); }

        private String CalcularHashSHA1(String caminhoArquivo)
        { return this.CalcularHashSHA1(File.Open(caminhoArquivo, FileMode.Open, FileAccess.Read)); }

        private String CalcularHashSHA256(String caminhoArquivo)
        { return CalcularHashSHA256(File.Open(caminhoArquivo, FileMode.Open, FileAccess.Read)); }

        private String CalcularHashSHA512(String caminhoArquivo)
        { return CalcularHashSHA512(File.Open(caminhoArquivo, FileMode.Open, FileAccess.Read)); }

        private String CalcularHashMD5(Stream sArquivo)
        {
            byte[] hashMD5 = null;
            try
            {
                try
                {
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    sArquivo.Position = 0;
                    hashMD5 = md5.ComputeHash(sArquivo);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex)
            {
                this.MudarText(ckbMD5, "MD5    Erro");
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.InvokeRequired)
                { this.BeginInvoke(new MethodExibirHash(ExibirHash), ex.Message); }
                throw new Exception(ex.Message, ex.InnerException);
            }

            String hashMD5text = BitConverter.ToString(hashMD5).Replace("-", "");
            this.ExibirHash(hashMD5text);
            this.MudarText(ckbMD5, "MD5");
            return hashMD5text;
        }

        private String CalcularHashSHA1(Stream sArquivo)
        {
            byte[] hashSHA1 = null;
            try
            {
                try
                {
                    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                    sArquivo.Position = 0;
                    hashSHA1 = sha1.ComputeHash(sArquivo);
                }
                catch (Exception ex)
                {
                    this.MudarText(ckbSHA1, "SHA1    Erro");
                    if (this.InvokeRequired)
                    { this.BeginInvoke(new MethodExibirHash(ExibirHash), ex.Message); }
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.InvokeRequired)
                { this.BeginInvoke(new MethodExibirHash(ExibirHash), ex.Message); }
                throw new Exception(ex.Message, ex.InnerException);
            }

            String hashSHA1Text = BitConverter.ToString(hashSHA1).Replace("-", "");
            this.ExibirHash(hashSHA1Text);
            this.MudarText(ckbSHA1, "SHA1");
            return hashSHA1Text;
        }

        private String CalcularHashSHA256(Stream sArquivo)
        {
            byte[] hashSHA256 = null;
            try
            {
                try
                {
                    SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                    sArquivo.Position = 0;
                    hashSHA256 = sha256.ComputeHash(sArquivo);
                }
                catch (Exception ex)
                {
                    this.MudarText(ckbSHA256, "SHA256  Erro");
                    if (this.InvokeRequired)
                    { this.BeginInvoke(new MethodExibirHash(ExibirHash), ex.Message); }
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.InvokeRequired)
                { this.BeginInvoke(new MethodExibirHash(ExibirHash), ex.Message); }
                throw new Exception(ex.Message, ex.InnerException);
            }

            String hashSHA256Text = BitConverter.ToString(hashSHA256).Replace("-", "");
            this.ExibirHash(hashSHA256Text);
            this.MudarText(ckbSHA256, "SHA256");
            return hashSHA256Text;
        }

        private String CalcularHashSHA512(Stream sArquivo)
        {
            byte[] hashSHA512 = null;
            try
            {
                try
                {
                    SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
                    sArquivo.Position = 0;
                    hashSHA512 = sha512.ComputeHash(sArquivo);
                }
                catch (Exception ex)
                {
                    this.MudarText(ckbSHA512, "SHA512  Erro");
                    if (this.InvokeRequired)
                    { this.BeginInvoke(new MethodExibirHash(ExibirHash), ex.Message); }
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.InvokeRequired)
                { this.BeginInvoke(new MethodExibirHash(ExibirHash), ex.Message); }
                throw new Exception(ex.Message, ex.InnerException);
            }

            String hashSHA512Text = BitConverter.ToString(hashSHA512).Replace("-", "");
            this.ExibirHash(hashSHA512Text);
            this.MudarText(ckbSHA512, "SHA512");
            return hashSHA512Text;
        }

        #endregion

        #endregion

        #region Interacao com a interface

        private void CompararHash()
        {
            if (this.InvokeRequired)
            { this.BeginInvoke(new MethodInvoker(CompararHash)); }
            else
                if (this.txtComparar.Text.Trim() != String.Empty)
                { this.textBox1_TextChanged(this.txtComparar, EventArgs.Empty); }
        }

        private void HabilitarBotoes()
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new MethodInvoker(HabilitarBotoes));
            else
            {
                this.btnSelecionarArquivo.Enabled = true;
                this.btnSelecionarArquivo.Update();
                this.btnCalcular.Text = "Calcular";
                this.btnCalcular.Enabled = true;
                this.btnCalcular.Update();
                this.btnCalcular.Focus();
            }
        }

        delegate void MethodExibirHash(String hash);
        private void ExibirHash(string hash)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodExibirHash(ExibirHash), hash);
            else
                switch (hash.Length)
                {
                    case 032: txtMD5.Text = hash; break;
                    case 040: txtSHA1.Text = hash; break;
                    case 064: txtSHA256.Text = hash; break;
                    case 128:
                    default: txtSHA512.Text = hash;
                        break;
                }
        }

        delegate void MethodMudarBackColor(Control input, Color text);
        private void MudarBackColor(Control input, Color cor)
        {
            if (this.InvokeRequired)
            { this.BeginInvoke(new MethodMudarBackColor(MudarBackColor), input, cor); }
            else
                if (input != null)
                {
                    input.BackColor = cor;
                    input.Update();
                }
        }

        delegate void MethodMudarForeColor(Control input, Color text);
        private void MudarForeColor(Control input, Color cor)
        {
            if (this.InvokeRequired)
            { this.BeginInvoke(new MethodMudarForeColor(MudarForeColor), input, cor); }
            else
                if (input != null)
                {
                    input.ForeColor = cor;
                    input.Update();
                }
        }

        delegate void MethodMudarText(Control input, String text);
        private void MudarText(Control input, String text)
        {
            if (this.InvokeRequired)
            { this.BeginInvoke(new MethodMudarText(MudarText), input, text); }
            else
                if (input != null)
                {
                    input.Text = text;
                    input.Update();
                }
        }

        private void MenuMudarEnableds(Boolean valor, params ToolStripMenuItem[] menuitens)
        {
            foreach (ToolStripMenuItem item in menuitens)
            { this.MenuMudarEnabled(valor, item); }
        }

        delegate void MethodMenuMudarEnabled(Boolean valor, ToolStripMenuItem menuItem);
        private void MenuMudarEnabled(Boolean valor, ToolStripMenuItem menuItem)
        {
            if (this.InvokeRequired)
            { this.BeginInvoke(new MethodMenuMudarEnabled(MenuMudarEnabled), valor, menuItem); }
            else
            { menuItem.Enabled = valor; }
        }

        private void MudarEnableds(Boolean valor, params Control[] inputs)
        {
            foreach (Control item in inputs)
            { this.MudarEnabled(valor, item); }
        }

        delegate void MethodMudarEnabled(Boolean valor, Control input);
        private void MudarEnabled(Boolean valor, Control input)
        {
            if (this.InvokeRequired)
            { this.BeginInvoke(new MethodMudarEnabled(MudarEnabled), valor, input); }
            else
                if (input != null)
                {
                    input.Enabled = valor;
                    input.Update();
                }
        }

        #endregion

        #region Acoes do Usuario

        public void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            { this.CalcularHash(openFileDialog1.FileName); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtMD5.BackColor = Color.White;
            txtSHA1.BackColor = Color.White;
            txtSHA256.BackColor = Color.White;
            txtSHA512.BackColor = Color.White;

            txtComparar.BackColor = Color.White;
            txtComparar.ForeColor = Color.Black;

            if (txtMD5.Text == String.Empty &&
                txtSHA1.Text == String.Empty &&
                txtSHA256.Text == String.Empty &&
                txtSHA512.Text == String.Empty)
            { return; }

            if (txtComparar.Text.Trim().ToUpper() == txtMD5.Text.Trim().ToUpper())
            { txtMD5.BackColor = Color.LightGreen; }
            else if (txtComparar.Text.Trim().ToUpper() == txtSHA1.Text.Trim().ToUpper())
            { txtSHA1.BackColor = Color.LightGreen; }
            else if (txtComparar.Text.Trim().ToUpper() == txtSHA256.Text.Trim().ToUpper())
            { txtSHA256.BackColor = Color.LightGreen; }
            else if (txtComparar.Text.Trim().ToUpper() == txtSHA512.Text.Trim().ToUpper())
            { txtSHA512.BackColor = Color.LightGreen; }
            else
            {
                txtComparar.BackColor = Color.Red;
                txtComparar.ForeColor = Color.Yellow;
            }
        }

        private void txtComparar_Enter(object sender, EventArgs e)
        { txtComparar.SelectAll(); }

        private void txtComparar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                txtComparar.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void registrarNoMenuDeContextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String regPath = @"*\shell\JHashWin\command";
                RegistryKey reg = Registry.ClassesRoot.CreateSubKey(regPath);
                reg.SetValue("", String.Format("{0} \"%1\"", Environment.CommandLine));
            }
            catch (UnauthorizedAccessException)
            { MessageBox.Show("Você não tem permissão para alterar o registro do windows!\r\nRode o programa como administrador.", "Erro ao registrar", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Erro ao registrar", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            btnSelecionarArquivo.Enabled = false;
            btnSelecionarArquivo.Update();
            btnCalcular.Enabled = false;
            btnCalcular.Update();
            btnCalcular.Enabled = openFileDialog1.ShowDialog() == DialogResult.OK || openFileDialog1.FileName != String.Empty;
            if (btnCalcular.Enabled)
            {
                this.CalcularHashInit();
                this.CalcularHashOnLoad(openFileDialog1.FileName);
                this.btnCalcular.Focus();
            }
            btnSelecionarArquivo.Enabled = true;
            btnSelecionarArquivo.Update();
            this.btnCalcular.Focus();
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ckbMD5.Checked = true;
            ckbSHA1.Checked = true;
            ckbSHA256.Checked = true;
            ckbSHA512.Checked = true;
        }

        private void inverterSeleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ckbMD5.Checked = !ckbMD5.Checked;
            ckbSHA1.Checked = !ckbSHA1.Checked;
            ckbSHA256.Checked = !ckbSHA256.Checked;
            ckbSHA512.Checked = !ckbSHA512.Checked;
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tokenMain != null)
            { tokenMain.Cancel(); }
        }

        #endregion
    }
}