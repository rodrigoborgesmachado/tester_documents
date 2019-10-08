using CaseMaker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CaseMaker.Util.Enumerator;

namespace CaseMaker.Visão
{
    public partial class FO_CadastroInfoAnexo : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Anexo referente ao cadastro
        /// </summary>
        MD_Anexos anexo;

        /// <summary>
        /// Tarefa sendo executada no formulário
        /// </summary>
        Tarefa tarefa;

        #endregion Atributos e Propriedades

        #region Eventos

        /// <summary>
        /// Evento lançado no clique do botão cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancela_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.btn_cancela_Click()", Util.Global.TipoLog.DETALHADO);
            anexo = null;
            this.Dispose();
        }

        /// <summary>
        /// Evento lançado no clique do botão de incluir anexo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_arquivo_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.btn_arquivo_Click()", Util.Global.TipoLog.DETALHADO);
            OpenFileDialog dialog_f = new OpenFileDialog();
            dialog_f.Title = "Selecione o arquivo a ser anexado no Cenário de testes";

            if (dialog_f.ShowDialog() == DialogResult.OK)
            {
                tbx_file.Text = dialog_f.FileName.ToString();
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão confirmar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.btn_confirmar_Click()", Util.Global.TipoLog.DETALHADO);
            Incluir();
        }

        #endregion Eventos

        #region Construtores

        /// <summary>
        /// Construtor Principal da classe
        /// </summary>
        /// <param name="anexo">Anexo pertencente ao formulario</param>
        public FO_CadastroInfoAnexo(MD_Anexos anexo, Tarefa tarefa)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.FO_CadastroInfoAnexo()", Util.Global.TipoLog.DETALHADO);
            this.anexo = anexo;
            this.tarefa = tarefa;
            InicializaForm();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que inicializa o formulário
        /// </summary>
        public void InicializaForm()
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.InicializaForm()", Util.Global.TipoLog.DETALHADO);
            InitializeComponent();
            PopulaCampos();
        }

        /// <summary>
        /// Método que carrega os campos com seus valores
        /// </summary>
        public void PopulaCampos()
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.PopulaCampos()", Util.Global.TipoLog.DETALHADO);
            if (tarefa != Tarefa.INCLUINDO)
            {
                tbx_file.Text = Util.Global.app_Prints_directory(anexo.Cenario.Project) + anexo.Cenario.Codigo +  "\\" + anexo.Arquivo;
                tbx_descricao.Text = anexo.Descricao;
            }
            tbx_file.Enabled = false;
        }

        /// <summary>
        /// Método que valida os campos do formulário
        /// </summary>
        /// <returns>True - Válidos; False - Com erro</returns>
        public bool ValidaCampos(ref string mensagem)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.ValidaCampos()", Util.Global.TipoLog.DETALHADO);
            bool retorno = true;

            if (string.IsNullOrEmpty(tbx_file.Text))
            {
                tbx_file.Focus();
                mensagem = "Não foi selecionado um arquivo para o anexo!";
                retorno = false;
            }
            else if (string.IsNullOrEmpty(tbx_descricao.Text))
            {
                tbx_descricao.Focus();
                mensagem = "Descrição não preenchida!";
                retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Método que faz a inclusão do anexo
        /// </summary>
        public void Incluir()
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroInfoAnexo.Incluir()", Util.Global.TipoLog.DETALHADO);
            string mensagemErro = "";
            if (!ValidaCampos(ref mensagemErro))
            {
                MessageBox.Show(mensagemErro);
                return;
            }

            FileInfo info = new FileInfo(tbx_file.Text);
            anexo.Arquivo = info.Name;
            anexo.Descricao = tbx_descricao.Text;

            
            if(!anexo.Cenario.CopiaPrint(info.FullName, ref mensagemErro))
            {
                MessageBox.Show(mensagemErro);
            }
            else
            {
                bool resultado = true;
                if (tarefa == Tarefa.EDITANDO)
                    resultado = anexo.Update();
                else
                    resultado = anexo.Insert();
                if (resultado)
                {
                    MessageBox.Show("Anexo incluído com sucesso!");
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                    MessageBox.Show("Erro ao incluir!");
            }
        }

        #endregion Métodos

    }
}
