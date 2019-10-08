using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseMaker.Visão
{
    public partial class FO_DisponibilizaEstimativaAnalista : Form
    {
        #region Eventos

        /// <summary>
        /// Evento lançado no clique do botão copiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("FO_DisponibilizaEstimativaAnalista.btn_copiar_Click()", Util.Global.TipoLog.DETALHADO);
            Clipboard.SetText(tbx_estimativa.Text);
        }

        #endregion


        #region Construtor 

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="mensagem">Mensagem a ser colocada no text box</param>
        public FO_DisponibilizaEstimativaAnalista(string mensagem)
        {
            Util.CL_Files.WriteOnTheLog("FO_DisponibilizaEstimativaAnalista.FO_DisponibilizaEstimativaAnalista()", Util.Global.TipoLog.DETALHADO);
            InitializeComponent();
            tbx_estimativa.Text = mensagem;
        }

        #endregion Construtor 

    }
}
