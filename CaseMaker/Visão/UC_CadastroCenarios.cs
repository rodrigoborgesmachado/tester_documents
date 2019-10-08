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
using System.Data.SQLite;
using System.IO;

namespace CaseMaker.Visão
{
    public partial class UC_CadastroCenarios : UserControl
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Objeto referente à tela principal
        /// </summary>
        FO_Principal principal;

        /// <summary>
        /// Controle dos eventos da tela
        /// </summary>
        bool lockchange = false;

        /// <summary>
        /// Tarefa sendo efetuada na tela
        /// </summary>
        Tarefa tarefa = Tarefa.VISUALIZANDO;

        /// <summary>
        /// Cenário do cadastro
        /// </summary>
        MD_Cenario cenario;

        /// <summary>
        /// Projeto referente o cenário
        /// </summary>
        MD_Project project;

        #endregion Atributos e Propriedades

        #region Eventos

        #region Informações

        /// <summary>
        /// Evento lançado no clique do botão de informação de tarefa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_tarefa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Número da tarefa referente ao teste.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação de versão do SGBD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_versãoSgbd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versão do Banco de dados");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação do banco de dados utilizado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bancoUtilizado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Banco de dados utilizado para os testes.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação da entrada do cen[ario de teste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_entrada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entrada de testes do cenário.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação da saída do cenário de teste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_info_saida_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saída de testes do cenário.");
        }

        /// <summary>
        /// Evento lançado no clique do botão de informação dos passos do cenário de teste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_passos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Passos para efetuar os testes do cenário.");
        }

        #endregion Informações

        /// <summary>
        /// Evento lançado na entrada de qualquer caracter no campo da tarefa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_numero_tarefa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lockchange)
                return;

            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.tbx_numero_tarefa_KeyPress()", Util.Global.TipoLog.DETALHADO);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão confirmar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.btn_confirmar_Click()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.VISUALIZANDO)
            {
                tarefa = Tarefa.EDITANDO;
                HabilitaBotoes();
                HabilitaCampos(true);
            }
            else
            {
                Incluir();
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão excluir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.btn_excluir_Click()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.VISUALIZANDO)
            {
                if (MessageBox.Show("Deseja excluir o cenário?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (cenario.Delete())
                {
                    MessageBox.Show("Excluído com sucesso!");
                    principal.CarregaTreeView();
                    FechaTela();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir!");
                }
            }
            else if (tarefa == Tarefa.INCLUINDO)
            {
                FechaTela();
            }
            else
            {
                tarefa = Tarefa.VISUALIZANDO;
                PopulaLabels();
                HabilitaBotoes();
                HabilitaCampos(false);
            }
        }

        /// <summary>
        /// Evento lançado no clique do botão add status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_status_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.btn_add_status_Click()", Util.Global.TipoLog.DETALHADO);
            FO_CadastroStatus cadastroStatus = new FO_CadastroStatus(Util.DataBase.GetIncrement("MAKSTATUS"), Tarefa.INCLUINDO);
            cadastroStatus.ShowDialog();
            CarregaComboStatus();
        }

        /// <summary>
        /// Evento lançado no clique do botão de incluir anexo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_adicionarAnexo_Click(object sender, EventArgs e)
        {
            if (lockchange)
                return;

            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.btn_adicionarAnexo_Click()", Util.Global.TipoLog.DETALHADO);
            lockchange = true;
            FO_CadastroInfoAnexo dialog_f = new FO_CadastroInfoAnexo(new MD_Anexos(Util.DataBase.GetIncrement("MAKANEXOS"), cenario), Tarefa.INCLUINDO);

            if (dialog_f.ShowDialog() == DialogResult.OK)
            {
                PreencheListView();                    
            }
            
            lockchange = false;
        }

        /// <summary>
        /// Evento acionado no clique do botão excluir anexo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_removerAnexo_Click(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.btn_removerAnexo_Click()", Util.Global.TipoLog.DETALHADO);
            int count = lvw_anexos.Items.Count;
            if (lvw_anexos.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Selecione um anexo!");
                return;
            }

            if (lvw_anexos.SelectedIndices.Count > 1)
            {
                MessageBox.Show("Para visualizar anexos, deve ser selecionado apenas um.");
            }

            string caminho_arquivo = lvw_anexos.Items[lvw_anexos.SelectedIndices[0]].Tag.ToString();
            try
            {
                File.Delete(caminho_arquivo);
                if (!File.Exists(caminho_arquivo))
                {
                    MessageBox.Show("Arquivo excluído do cenário com sucesso.");

                    string[] info = caminho_arquivo.Split('\\');

                    MD_Anexos anexo = MD_Anexos.RetornaAnexoFromFileName(info[info.Count() - 1].ToString(), cenario);
                    if(anexo != null)
                        anexo.Delete();
                    PreencheListView();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao excluir o anexo!");
                Util.CL_Files.WriteOnTheLog("Erro: " + ex.Message, Util.Global.TipoLog.SIMPLES);
            } 
        }

        /// <summary>
        /// Evento lançado no cliqeu duplo na list view de anexos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvw_anexos_DoubleClick(object sender, EventArgs e)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.lvw_anexos_DoubleClick()", Util.Global.TipoLog.DETALHADO);
            if (lvw_anexos.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Selecione um anexo!");
                return;
            }

            if (lvw_anexos.SelectedIndices.Count > 1)
            {
                MessageBox.Show("Para visualizar anexos, deve ser selecionado apenas um.");
            }

            string caminho_arquivo = lvw_anexos.Items[lvw_anexos.SelectedIndices[0]].Tag.ToString();
            string mensagem = "";
            if(!Util.Document.ExecutaFile(caminho_arquivo, false, ref mensagem))
            {
                MessageBox.Show(mensagem);
            }

        }

        /// <summary>
        /// Evento lançado no clique do botão gerar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gerar_document_Click(object sender, EventArgs e)
        {
            if (lockchange)
                return;

            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.btn_gerar_document_Click()", Util.Global.TipoLog.DETALHADO);
            lockchange = true;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Selecione o diretório de saída. O pdf será salvo no diretório selecionado com o nome: saida.pdf";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            FO_Agurade agurade = new FO_Agurade("Carregando relatório de testes!");
            agurade.Show();
            string mensagemErro = "";
            bool resultado = Util.Document.CriaRelatorio(cenario, dialog.SelectedPath, ref mensagemErro);
            agurade.Close();
            if (resultado)
            {
                MessageBox.Show("Relatório de testes criado com sucesso! Saída: " + dialog.SelectedPath + "\\saida.pdf");
                if(MessageBox.Show("Deseja abrir o arquivo de saída?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Util.Document.ExecutaFile(dialog.SelectedPath + "\\saida.pdf", false, ref mensagemErro);
                }
            }
            else
                MessageBox.Show("Erro ao gerar o relatório!");

            lockchange = false;
        }

        #endregion Eventos

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="principal">Instância da tela que abriu o user control</param>
        /// <param name="project">Projeto referente o cenário de teste</param>
        /// <param name="cenario">Cenário de teste que dará o load da classe</param>
        /// <param name="tarefa">Tarefa a ser executada na tela</param>
        /// <param name="tela">Código da tela</param>
        public UC_CadastroCenarios(FO_Principal principal, MD_Project project, MD_Cenario cenario, Tarefa tarefa, Telas tela, TipoSistema sistema)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.UC_CadastroCenarios()", Util.Global.TipoLog.DETALHADO);
            this.principal = principal;
            this.project = project;
            this.cenario = cenario;
            this.tarefa = tarefa;
            this.Tag = (int)tela;

            InitializeComponent();
            CarregaForm();
            PopulaCampos(sistema);
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que carrega o form
        /// </summary>
        public void CarregaForm()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.CarregaForm()", Util.Global.TipoLog.DETALHADO);
            this.Dock = DockStyle.Fill;
            PopulaLabels();
            HabilitaCampos(tarefa != Tarefa.VISUALIZANDO);
            HabilitaBotoes();
            CarregaComboStatus();
            PreencheListView();
        }

        /// <summary>
        /// Método que preenche a label caso seja cadastro
        /// </summary>
        /// <param name="sistema"></param>
        public void PopulaCampos(TipoSistema sistema)
        {
            if (tarefa != Tarefa.INCLUINDO || sistema == TipoSistema.GENERICO)
                return;

            if (sistema == TipoSistema.SSI)
            {
                tbx_passos.Text = @"- Rodar script de banco." + Environment.NewLine + "- Verificar existência de parâmetro no middleware." + Environment.NewLine + "- Verifiar criação dos campos no SSI." + Environment.NewLine + "- Verificar criação dos campos no script de carga." + Environment.NewLine + "- Verificar geração de carga." + Environment.NewLine + "- Verificar exportação.";
                tbx_saida.Text = "";
                tbx_entrada.Text = "";
            }
        }

        /// <summary>
        /// Método que faz o load das labels
        /// </summary>
        public void PopulaLabels()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.PopulaLabels()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.INCLUINDO)
            {
                tbx_numero_tarefa.Text = project.NumeroTarefa.ToString();
            }
            else
            {
                tbx_bancoUtilizado.Text = cenario.BancoUtilizado;
                tbx_entrada.Text = cenario.Entrada;
                tbx_numero_tarefa.Text = cenario.Tarefa.ToString();
                tbx_passos.Text = cenario.Passos;
                tbx_saida.Text = cenario.Saida;
                tbx_versaoSgbd.Text = cenario.VersaoSgbd;
                cmb_tipoSistema.SelectedIndex = (int)cenario.TipoDoSistema;
                rbt_firebird.Checked = cenario.TipoBanco == Banco.FIREBIRD;
                rbt_oracle.Checked = cenario.TipoBanco == Banco.ORACLE;
                rbt_sql.Checked = cenario.TipoBanco == Banco.SQLSERVER;

                ckb_reparo.Checked = cenario.EhReparo == Reparo.SIM;
            }
        }

        /// <summary>
        /// Método que habilita/desabilita os campos para seleção
        /// </summary>
        /// <param name="enable"></param>
        public void HabilitaCampos(bool enable)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.HabilitaCampos()", Util.Global.TipoLog.DETALHADO);
            tbx_bancoUtilizado.Enabled = enable;
            tbx_entrada.Enabled = enable;
            tbx_numero_tarefa.Enabled = enable;
            tbx_passos.Enabled = enable;
            tbx_saida.Enabled = enable;
            tbx_versaoSgbd.Enabled = enable;
            rbt_firebird.Enabled = enable;
            rbt_oracle.Enabled = enable;
            rbt_sql.Enabled = enable;
            btn_add_status.Enabled = enable;
            btn_adicionarAnexo.Enabled = enable;
            btn_removerAnexo.Enabled = enable;
            cmb_status.Enabled = enable;
            cmb_tipoSistema.Enabled = enable;
            ckb_reparo.Enabled = enable;
        }

        /// <summary>
        /// Método que habilita os bõtões para seleção
        /// </summary>
        public void HabilitaBotoes()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.HabilitaBotoes()", Util.Global.TipoLog.DETALHADO);
            if (tarefa == Tarefa.VISUALIZANDO)
            {
                btn_confirmar.Text = "Editar";
                btn_excluir.Text = "Excluir";
                btn_excluir.Enabled = btn_confirmar.Enabled = btn_gerar_document.Enabled = true;
            }
            else
            {
                btn_confirmar.Text = "Confirmar";
                btn_excluir.Text = "Cancelar";
                btn_excluir.Enabled = btn_confirmar.Enabled = true;
                btn_gerar_document.Enabled = false;
            }
        }

        /// <summary>
        /// Método que carrega o combo de status
        /// </summary>
        public void CarregaComboStatus()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.CarregaComboStatus()", Util.Global.TipoLog.DETALHADO);
            // Instância aberta apenas para criar as tabelas
            MD_Status status = new MD_Status(0);

            string sentenca = MD_Status.ComandoTodosStatus();
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            cmb_status.DataSource = Util.DataBase.GetDataSourceFromDataReader(reader).DefaultView;
            cmb_status.DisplayMember = "NOMESTAT";
            cmb_status.ValueMember = "CODIGOSTAT";
            reader.Close();
        }

        /// <summary>
        /// Método que preenche o ListView
        /// </summary>
        public void PreencheListView()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.PreencheListView()", Util.Global.TipoLog.DETALHADO);
            lvw_anexos.Clear();
            lvw_anexos.StateImageList = img_list;
            lvw_anexos.SmallImageList = img_list;
            string diretorioArquivos = Util.Global.app_Prints_directory(cenario.Project) + cenario.Codigo + "\\";
            Directory.CreateDirectory(diretorioArquivos);

            foreach(string arquivo in Directory.GetFiles(diretorioArquivos).ToList())
            {
                FileInfo info = new FileInfo(arquivo);
                ListViewItem item = new ListViewItem(info.Name);

                item.ImageIndex = 0;
                item.Tag = info.FullName;

                lvw_anexos.Items.Add(item);
            }

        }

        /// <summary>
        /// Método que verifica os campos
        /// </summary>
        /// <param name="mensagem">Variável para pegar mensagem de erro</param>
        /// <returns>True - Validados; False - Há erros</returns>
        public bool VerificaCampos(ref string mensagem)
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.VerificaCampos()", Util.Global.TipoLog.DETALHADO);
            bool retorno = true;

            if (string.IsNullOrEmpty(tbx_numero_tarefa.Text))
            {
                mensagem += (string.IsNullOrEmpty(mensagem) ? "" : "\n") + "Campo tarefa vazio!";
                tbx_numero_tarefa.Focus();
                retorno = false;
            }

            if (string.IsNullOrEmpty(tbx_bancoUtilizado.Text))
            {
                mensagem += (string.IsNullOrEmpty(mensagem) ? "" : "\n") + "Banco de dados utilizado nos testes está vazio!";
                tbx_bancoUtilizado.Focus();
                retorno = false;
            }

            if(cmb_status.SelectedIndex < 0)
            {
                mensagem += (string.IsNullOrEmpty(mensagem) ? "" : "\n") + "O campo de status do teste não foi selecionado!";
                cmb_status.Focus();
                retorno = false;
            }

            if (cmb_tipoSistema.SelectedIndex < 0)
            {
                mensagem += (string.IsNullOrEmpty(mensagem) ? "" : "\n") + "O campo de Tipo do Cenário não foi selecionado!";
                cmb_tipoSistema.Focus();
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Método que faz o insert do formulário
        /// </summary>
        public void Incluir()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.Incluir()", Util.Global.TipoLog.DETALHADO);
            string mensagem = "";
            if(!VerificaCampos(ref mensagem))
            {
                MessageBox.Show(mensagem);
                return;
            }

            cenario.BancoUtilizado = tbx_bancoUtilizado.Text;
            cenario.Entrada = tbx_entrada.Text;
            cenario.Tarefa = int.Parse(tbx_numero_tarefa.Text);
            cenario.Passos = tbx_passos.Text;
            cenario.Saida = tbx_saida.Text;
            cenario.VersaoSgbd = tbx_versaoSgbd.Text;
            cenario.TipoBanco = rbt_firebird.Checked ? Banco.FIREBIRD : (rbt_oracle.Checked ? Banco.ORACLE : Banco.SQLSERVER);
            cenario.EhReparo = ckb_reparo.Checked ? Reparo.SIM : Reparo.NAO;
            cenario.Status = new MD_Status(int.Parse(cmb_status.SelectedValue.ToString()));
            cenario.TipoDoSistema = (TipoSistema)cmb_tipoSistema.SelectedIndex;

            bool incluiu = false;
            if (tarefa == Tarefa.EDITANDO)
                incluiu = cenario.Update();
            else
                incluiu = cenario.Insert();
            if (incluiu)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                tarefa = Tarefa.VISUALIZANDO;
                PopulaLabels();
                HabilitaCampos(tarefa != Tarefa.VISUALIZANDO);
                HabilitaBotoes();
                principal.CarregaTreeView();
            }
            else
            {
                MessageBox.Show("Erro ao inserir!");
            }

        }

        /// <summary>
        /// Método que fecha o user control
        /// </summary>
        public void FechaTela()
        {
            Util.CL_Files.WriteOnTheLog("UC_CadastroCenarios.FechaTela()", Util.Global.TipoLog.DETALHADO);
            principal.FecharTela((Telas)this.Tag);
            this.Dispose();
        }

        #endregion Métodos

    }
}
