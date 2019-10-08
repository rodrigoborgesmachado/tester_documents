using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tester_Documents.Visão;

namespace Tester_Documents
{
    public partial class FO_Main : Form
    {
        #region Events

        /// <summary>
        /// Evento lançado no double clique da tela para habilitar os logs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pan_top_DoubleClick(object sender, EventArgs e)
        {
            Util.Global.log_system = Util.Global.TipoLog.DETALHADO;
        }

        /// <summary>
        /// Event taked when the botton of select folder is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_folder_Click(object sender, EventArgs e)
        {
            OpenDirectoryFile(true);
        }

        /// <summary>
        /// Event taked when the botton of select folder is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_folder_out_Click(object sender, EventArgs e)
        {
            OpenDirectoryFile(false);
        }

        /// <summary>
        /// Event taken when the create button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_create_Click(object sender, EventArgs e)
        {
            btn_create.Enabled = false;
            Create();
            Util.Documento.CopiarLog();
            btn_create.Enabled = true;
        }

        /// <summary>
        /// Event taken when the create button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_configuracao_Click(object sender, EventArgs e)
        {
            FO_FormularioConfiguracao formulario = new FO_FormularioConfiguracao();
            formulario.ShowDialog();
        }

        #endregion Events

        #region Constructors

        /// <summary>
        /// Main constructor of the class
        /// </summary>
        public FO_Main()
        {
            InitializeComponent();
            InicializeForm();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Main method to take all the views
        /// </summary>
        public void InicializeForm()
        {
            
        }

        /// <summary>
        /// Método que abre diálogo para seleção do caminho das imagens
        /// </summary>
        public void OpenDirectoryFile(bool _in)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            OpenFileDialog dialog_f = new OpenFileDialog();

            if (!_in) 
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    this.tbx_folder_out.Text = dialog.SelectedPath.ToString();
            }
            else
            {
                if (dialog_f.ShowDialog() == DialogResult.OK)
                    this.tbx_folder_in.Text = dialog_f.FileName.ToString();
            }
        }

        /// <summary>
        /// Método que cria o arquivo de saída
        /// </summary>
        public void Create()
        {
            if (string.IsNullOrEmpty(this.tbx_folder_in.Text))
            {
                MessageBox.Show("Arquivo de entrada não selecionado!");
                return;
            }
            if (string.IsNullOrEmpty(this.tbx_folder_out.Text))
            {
                MessageBox.Show("Diretório de saída não selecionado!");
                return;
            }

            System.IO.FileInfo arquivo = new System.IO.FileInfo(this.tbx_folder_in.Text);
            Tester_Documents.Util.Documento documento = new Util.Documento(arquivo);
            string mensagemErro = "";

            if (arquivo.Extension == ".csv")
                documento = new Util.Documento_From_CSV(arquivo);
            else if (arquivo.Extension == ".xml")
                documento = new Util.Documento_From_XML(arquivo);

            documento.GerarRelatorio(this.tbx_folder_out.Text, out mensagemErro);

            if (!string.IsNullOrEmpty(mensagemErro))
            {
                MessageBox.Show(mensagemErro);
                return;
            }
            else
            {
                MessageBox.Show("Documento gerado com sucesso!\nDiretório: " + this.tbx_folder_out.Text + "\\" + arquivo.Name.Replace(arquivo.Extension, "") + ".pdf");
                return;
            }
        }

        #endregion Methods

        
    }
}
