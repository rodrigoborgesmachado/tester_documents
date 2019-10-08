using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CaseMaker.Util.Enumerator;
using CaseMaker.Model;

namespace CaseMaker.Visão
{
    public partial class UC_CadastroEstimativa : UserControl
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Objeto referente à tela principal
        /// </summary>
        FO_Principal principal;

        /// <summary>
        /// Objeto model referente à estimativa
        /// </summary>
        MD_Estimativa estimativa;

        /// <summary>
        /// Tarefa referente à tela
        /// </summary>
        Tarefa tarefa = Tarefa.VISUALIZANDO;

        #endregion Atributos e Propriedades

        #region Eventos

        #region Eventos - botoes info

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de leitura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_tempoLeitrua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto para leitura do RRM.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de preparacao do baco de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_PreparacaoBanco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto para a preparação do banco de dados.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de crição do roteiro de teste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_roteiro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto para a criação do roteiro de testes.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de instalação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_instalacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com a instalação do sistema.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de banco de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_bancoDados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes no banco de dados.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste do script de carga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_scriptCarga_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes do script de banco de dados.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste do importa~ção e exportação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_exportacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes de Importação/Exportação.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste do station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_station_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes no Station.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste do ldxproc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_ldxproc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes no LdxProc.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste do middleware
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_middleware_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes do Middleware.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste no android
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_android_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes no Android.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste no windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_windows_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes no Windows.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de tempo de teste de impactos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_impactos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tempo gasto com testes em Impactos Negativos.");
        }

        #endregion Eventos - botoes info

        /// <summary>
        /// Evento lançado no clique do botão fechar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.btn_fechar_Click()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.VISUALIZANDO)
                FechaTela();
            else
            {
                btn_confirmar.Text = "Editar";
                btn_fechar.Text = "Fechar";
                PopulaLabels();
                CarregaCampos(false);
                tarefa = Tarefa.VISUALIZANDO;
            }

        }

        /// <summary>
        /// Evento lançado no clique do botão confirmar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.btn_confirmar_Click()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.VISUALIZANDO)
            {
                tarefa = Tarefa.EDITANDO;
                btn_confirmar.Text = "Confirmar";
                btn_fechar.Text = "Cancelar";
                CarregaCampos(true);
            }
            else
            {
                btn_confirmar.Text = "Editar";
                btn_fechar.Text = "Fechar";
                Editar();
                PopulaLabels();
                principal.CarregaTreeView();
                tarefa = Tarefa.VISUALIZANDO;
                CarregaCampos(false);
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão gerar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gerar_document_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.btn_gerar_document_Click()", Util.Global.TipoLog.DETALHADO);
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Selecione o diretório de saída. O pdf será salvo no diretório selecionado com o nome: saida.pdf";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Selecione o diretório de saída!");
                return;
            }

            FO_Agurade agurade = new FO_Agurade("Carregando relatório de estimativa!");
            agurade.Show();
            string mensagemErro = "";
            bool resultado = Util.Document.CriaEstimativa(estimativa.Project, dialog.SelectedPath, ref mensagemErro);
            agurade.Close();
            if (resultado)
            {
                MessageBox.Show("Estimativa criada com sucesso! Saída: " + dialog.SelectedPath + "\\saida.pdf");
            }
            else
                MessageBox.Show("Erro ao gerar arquivo csv!");

            CarregaWebBrowser(dialog.SelectedPath + "\\saida.pdf");

            FO_DisponibilizaEstimativaAnalista tela = new FO_DisponibilizaEstimativaAnalista(Util.Document.CriaTextoCopiarEstimativa(estimativa.Project, ref mensagemErro));
            tela.ShowDialog();
        }

        /// <summary>
        /// Evento disparado na alteração do valor do campo de horas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtxb_tempoLeitura_TextChanged(object sender, EventArgs e)
        {
            
        }

        #endregion Eventos

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="principal">Tela principal que chamou o usercontrol</param>
        /// <param name="estimativa">Model estimativa</param>
        /// <param name="tarefa">Tarefa a se fazer</param>
        /// <param name="tela">Tag da tela</param>
        public UC_CadastroEstimativa(FO_Principal principal, MD_Estimativa estimativa, Tarefa tarefa, Telas tela)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.UC_CadastroEstimativa()", Util.Global.TipoLog.DETALHADO);
            this.principal = principal;
            this.estimativa = estimativa;
            this.tarefa = tarefa;
            this.Tag = (int)tela;

            IniciaUserControl();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que inicializa a tela
        /// </summary>
        public void IniciaUserControl()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.IniciaUserControl()", Util.Global.TipoLog.DETALHADO);
            InitializeComponent();
            lbl_titulo.Text = "RRM: " + estimativa.Project.NumeroTarefa + " - " + estimativa.Project.Nome;
            this.Dock = DockStyle.Fill;
            PopulaLabels();
            CarregaCampos((tarefa == Tarefa.VISUALIZANDO ? false : true));
        }

        /// <summary>
        /// Método que popula as labels
        /// </summary>
        public void PopulaLabels()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.PopulaLabels()", Util.Global.TipoLog.DETALHADO);
            mtbx_android.Text = estimativa.TempoAndroid;
            mtbx_bancoDados.Text = estimativa.TempoBanco;
            mtbx_carga.Text = estimativa.TempoCarga;
            mtbx_impExportacao.Text = estimativa.TempoExpImp;
            mtbx_ldxproc.Text = estimativa.TempoLdxproc;
            mtbx_middleware.Text = estimativa.TempoMiddleware;
            mtbx_roteiro.Text = estimativa.TempoRoteiro;
            mtbx_station.Text = estimativa.TempoStation;
            mtxb_tempoLeitura.Text = estimativa.TempoLeituraRRM;
            mtbx_tempoInstalacao.Text = estimativa.TempoInstalação;
            mtbx_windows.Text = estimativa.TempoWindows;
            mtxb_tempoPreparacaoBanco.Text = estimativa.TempoPreparacaoBanco;
            mtbx_impactos.Text = estimativa.TempoImpactos;
            lbl_tempo_edit.Text = Util.Document.CalculaTempoTotalEstimativa(estimativa);
        }

        /// <summary>
        /// Método que carrega os campos do formulário
        /// </summary>
        /// <param name="enable"></param>
        public void CarregaCampos(bool enable)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.CarregaCampos()", Util.Global.TipoLog.DETALHADO);
            mtbx_android.Enabled = enable;
            mtbx_bancoDados.Enabled = enable;
            mtbx_carga.Enabled = enable;
            mtbx_impExportacao.Enabled = enable;
            mtbx_ldxproc.Enabled = enable;
            mtbx_middleware.Enabled = enable;
            mtbx_roteiro.Enabled = enable;
            mtbx_station.Enabled = enable;
            mtxb_tempoLeitura.Enabled = enable;
            mtbx_tempoInstalacao.Enabled = enable;
            mtbx_windows.Enabled = enable;
            mtxb_tempoPreparacaoBanco.Enabled = enable;
            mtbx_impactos.Enabled = enable;
            btn_gerar_document.Enabled = !enable;
        }

        /// <summary>
        /// Método que faz a edição da estimativa
        /// </summary>
        public void Editar()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.Editar()", Util.Global.TipoLog.DETALHADO);
            estimativa.TempoAndroid = mtbx_android.Text;
            estimativa.TempoBanco = mtbx_bancoDados.Text;
            estimativa.TempoCarga = mtbx_carga.Text;
            estimativa.TempoExpImp = mtbx_impExportacao.Text;
            estimativa.TempoLdxproc = mtbx_ldxproc.Text;
            estimativa.TempoMiddleware = mtbx_middleware.Text;
            estimativa.TempoRoteiro = mtbx_roteiro.Text;
            estimativa.TempoStation = mtbx_station.Text;
            estimativa.TempoLeituraRRM = mtxb_tempoLeitura.Text;
            estimativa.TempoInstalação = mtbx_tempoInstalacao.Text;
            estimativa.TempoWindows = mtbx_windows.Text;
            estimativa.TempoPreparacaoBanco = mtxb_tempoPreparacaoBanco.Text;
            estimativa.TempoImpactos = mtbx_impactos.Text;

            if (estimativa.Update())
            {
                tarefa = Tarefa.VISUALIZANDO;
                PopulaLabels();
                MessageBox.Show("Estimativa editada com sucesso!");
            }
            else
                MessageBox.Show("Erro ao editar a estimativa");
        }

        /// <summary>
        /// Método que fecha o user control
        /// </summary>
        public void FechaTela()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.FechaTela()", Util.Global.TipoLog.DETALHADO);
            principal.FecharTela((Telas)this.Tag);
            this.Dispose();
        }

        /// <summary>
        /// Método que carrega o webBrowser
        /// </summary>
        public void CarregaWebBrowser(string caminho)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroEstimativa.CarregaWebBrowser()", Util.Global.TipoLog.DETALHADO);
            web_exemplo.ScriptErrorsSuppressed = true;
            web_exemplo.Navigate(Util.Global.app_temp_html_file);
        }

        #endregion Métodos

        
    }
}
