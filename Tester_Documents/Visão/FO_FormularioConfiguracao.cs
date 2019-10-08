using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester_Documents.Visão
{
    public partial class FO_FormularioConfiguracao : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Informação a ser carregada no formulário
        /// </summary>
        Model.MD_PDFInformations informacao = new Model.MD_PDFInformations(0);

        #endregion Atributos e Propriedades

        #region Eventos

        /// <summary>
        /// Evento lançado no clique do botão editar da tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            Incluir();
        }

        #endregion Eventos

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        public FO_FormularioConfiguracao()
        {
            InicializaForm();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que faz a inicialização do form
        /// </summary>
        public void InicializaForm()
        {
            InitializeComponent();
            PopulaCampos();
        }

        /// <summary>
        /// Método que preenche os campos do formulário com os dados salvo no banco
        /// </summary>
        public void PopulaCampos()
        {
            if (!informacao.Empty)
            {
                tbx_author.Text = informacao.Author;
                tbx_creator.Text = informacao.Creator;
                tbx_subject.Text = informacao.Subject;
                tbx_titulo.Text = informacao.Title;
                tbx_keywords.Text = informacao.KeyWords;
                tbx_log.Text = informacao.Dirlog;
                dtp_data_criacao.Text = informacao.DataCriacaoPDF.ToShortDateString();
                dtp_data_alteracao.Text = informacao.DatamodificacaoPDF.ToShortDateString();
            }
        }

        /// <summary>
        /// Método que faz a inclusão dos dados
        /// </summary>
        public void Incluir()
        {
            informacao.Author = tbx_author.Text;
            informacao.Creator = tbx_creator.Text;
            informacao.Subject = tbx_subject.Text;
            informacao.KeyWords = tbx_keywords.Text;
            informacao.Title = tbx_titulo.Text;
            informacao.DataCriacaoPDF = DateTime.Parse(dtp_data_criacao.Text);
            informacao.DatamodificacaoPDF = DateTime.Parse(dtp_data_alteracao.Text);
            informacao.Dirlog = tbx_log.Text;
            if (informacao.Insert())
            {
                if(MessageBox.Show("Salvo com sucesso! Deseja fechar?") == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro! Verificar log " + Util.Global.app_logs_directoty);
                }
            }
        }

        #endregion Métodos
    }
}
