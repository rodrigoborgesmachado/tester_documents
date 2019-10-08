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
    public partial class FO_Agurade : Form
    {
        /// <summary>
        /// Contrutor principal da classe
        /// </summary>
        public FO_Agurade(string mengagem)
        {
            Util.CL_Files.WriteOnTheLog("FO_Agurade.FO_Agurade()", Util.Global.TipoLog.DETALHADO);
            InitializeComponent();
            lbl_carregando.Text = mengagem;
        }
    }
}
