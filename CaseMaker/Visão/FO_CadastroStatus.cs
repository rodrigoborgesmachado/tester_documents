using CaseMaker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CaseMaker.Util.Enumerator;

namespace CaseMaker.Visão
{
    public partial class FO_CadastroStatus : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Status referente ao cadastro
        /// </summary>
        MD_Status status;

        /// <summary>
        /// Tarefa executada no form
        /// </summary>
        Tarefa tarefa = Tarefa.VISUALIZANDO;

        #endregion Atributos e Propriedades

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        public FO_CadastroStatus(int codigo, Tarefa tarefa)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroStatus.FO_CadastroStatus()", Util.Global.TipoLog.DETALHADO);
            status = new MD_Status(codigo);
            this.tarefa = tarefa;
            InicializaForm();
        }

        #endregion Construtores

        #region Eventos

        /// <summary>
        /// Evento lançado no clique do botão confirmar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroStatus.btn_confirmar_Click()", Util.Global.TipoLog.DETALHADO);
            Incluir();
        }

        /// <summary>
        /// Evento lançado no clique do botão cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancela_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroStatus.btn_cancela_Click()", Util.Global.TipoLog.DETALHADO);
            status = null;
            this.Dispose();
        }

        #endregion Eventos

        #region Métodos

        /// <summary>
        /// Método que inicializa o form
        /// </summary>
        public void InicializaForm()
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroStatus.InicializaForm()", Util.Global.TipoLog.DETALHADO);
            InitializeComponent();
            PopulaLabels();
        }

        /// <summary>
        /// Método que popula as labels
        /// </summary>
        public void PopulaLabels()
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroStatus.PopulaLabels()", Util.Global.TipoLog.DETALHADO);
            if (!status.Empty)
            {
                tbx_nome.Name = status.Nome;
            }
            if (tarefa == Tarefa.VISUALIZANDO)
                HabilitaCampos(false);
            else 
                HabilitaCampos(true);
        }

        /// <summary>
        /// Método que habilita os campos
        /// </summary>
        /// <param name="habilita"></param>
        public void HabilitaCampos(bool habilita)
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroStatus.HabilitaCampos()", Util.Global.TipoLog.DETALHADO);
            tbx_nome.Enabled = habilita;
        }

        /// <summary>
        /// Método que faz a inclusão do status
        /// </summary>
        public void Incluir()
        {
            Util.CL_Files.WriteOnTheLog("FO_CadastroStatus.Incluir()", Util.Global.TipoLog.DETALHADO);
            status.Nome = tbx_nome.Text;
            status.Status_erro = (ckb_erro.Checked ? StatusErro.ERRO : StatusErro.SUCESSO);

            bool retorno = true;
            if (tarefa == Tarefa.EDITANDO)
                retorno = status.Update();
            else if (tarefa == Tarefa.INCLUINDO)
                retorno = status.Insert();

            if (retorno)
            {
                MessageBox.Show("Cadastro efetuado com sucesso!");
                status = null;
                this.Dispose();
            }
            else
                MessageBox.Show("Erro ao efetuar o cadastro, consultar o log!");

        }

        #endregion Métodos

    }
}
