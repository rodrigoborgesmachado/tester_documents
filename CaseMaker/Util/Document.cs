using CaseMaker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMaker.Util
{
    public static class Document
    {
        #region Métodos

        /// <summary>
        /// Método que retorna o texto com o relatório do tempo estimado de teste para a mudança
        /// </summary>
        /// <param name="project"></param>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        public static string CriaTextoEstimativa(MD_Project project, ref string mensagem)
        {
            Util.CL_Files.WriteOnTheLog("Document.CriaTextoCopiarEstimativa()", Util.Global.TipoLog.DETALHADO);
            mensagem = "";
            string retorno = "";
            try
            {
                StringBuilder texto = new StringBuilder();
                MD_Estimativa estimativa = project.GetEstimativa();

                texto.Append("\\tabela\\tabelacorpo");
                texto.Append("\\linha\\coluna\\tTarefa\\et\\ecoluna\\coluna\\tTempo\\et\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaLer RRM\\ecoluna\\coluna" + estimativa.TempoLeituraRRM + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaPreparação do banco\\ecoluna\\coluna" + estimativa.TempoPreparacaoBanco + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaCriar roteiro\\ecoluna\\coluna" + estimativa.TempoRoteiro + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaInstalar versão\\ecoluna\\coluna" + estimativa.TempoInstalação + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaSSI banco de dados\\ecoluna\\coluna" + estimativa.TempoBanco + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaSSI Carga\\ecoluna\\coluna" + estimativa.TempoCarga + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaImportação, Exportação\\ecoluna\\coluna" + estimativa.TempoExpImp + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaSSU - Station\\ecoluna\\coluna" + estimativa.TempoStation + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaSSI - LdxProc\\ecoluna\\coluna" + estimativa.TempoLdxproc + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaSSI - MW\\ecoluna\\coluna" + estimativa.TempoMiddleware + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaSSM - AND\\ecoluna\\coluna" + estimativa.TempoAndroid + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaSSM - WIN\\ecoluna\\coluna" + estimativa.TempoWindows + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaImpactos negativos\\ecoluna\\coluna" + estimativa.TempoImpactos + "\\ecoluna\\elinha");
                texto.Append("\\linha\\colunaTotal\\ecoluna\\coluna" + CalculaTempoTotalEstimativa(estimativa) + "\\ecoluna\\elinha");
                texto.Append("\\etabelacorpo\\etabela");

                retorno = texto.ToString();

            }
            catch (Exception e)
            {
                mensagem = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return "";
            }
            return retorno;
        }

        /// <summary>
        /// Método que retorna o texto com o relatório do tempo estimado de teste para a mudança
        /// </summary>
        /// <param name="project"></param>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        public static string CriaTextoCopiarEstimativa(MD_Project project, ref string mensagem)
        {
            Util.CL_Files.WriteOnTheLog("Document.CriaTextoCopiarEstimativa()", Util.Global.TipoLog.DETALHADO);
            mensagem = "";
            string retorno = "";
            try
            {
                StringBuilder texto = new StringBuilder();
                MD_Estimativa estimativa = project.GetEstimativa();

                texto.Append("Ler RRM _______________________________: " + estimativa.TempoLeituraRRM + Environment.NewLine);
                texto.Append("Preparação do banco ___________________: " + estimativa.TempoPreparacaoBanco + Environment.NewLine);
                texto.Append("Criar roteiro _________________________: " + estimativa.TempoRoteiro + Environment.NewLine);
                texto.Append("Instalar versão _______________________: " + estimativa.TempoInstalação + Environment.NewLine);
                texto.Append("SSI banco de dados ____________________: " + estimativa.TempoBanco + Environment.NewLine);
                texto.Append("SSI Carga _____________________________: " + estimativa.TempoCarga + Environment.NewLine);
                texto.Append("Importação, Exportação ________________: " + estimativa.TempoExpImp + Environment.NewLine);
                texto.Append("SSU - Station _________________________: " + estimativa.TempoStation + Environment.NewLine);
                texto.Append("SSI - LdxProc _________________________: " + estimativa.TempoLdxproc + Environment.NewLine);
                texto.Append("SSI - MW ______________________________: " + estimativa.TempoMiddleware + Environment.NewLine);
                texto.Append("SSM - AND _____________________________: " + estimativa.TempoAndroid +  Environment.NewLine);
                texto.Append("SSM - WIN _____________________________: " + estimativa.TempoWindows +  Environment.NewLine);
                texto.Append("Impactos negativos ____________________: " + estimativa.TempoImpactos + Environment.NewLine);
                texto.Append("Total _________________________________: " + CalculaTempoTotalEstimativa(estimativa) + Environment.NewLine);

                retorno = texto.ToString();

            }
            catch (Exception e)
            {
                mensagem = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return "";
            }
            return retorno;
        }

        /// <summary>
        /// Método que cria o relatório de testes
        /// </summary>
        /// <param name="cenario">Cenario para se criar o relatório</param>
        /// <param name="diretorio_saida">Diretório para salvar a saída do relatório</param>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        public static bool CriaRelatorio(MD_Cenario cenario, string diretorio_saida, ref string mensagem)
        {
            CL_Files.WriteOnTheLog("Document.CriaRelatoria", Global.TipoLog.DETALHADO);
            mensagem = "";
            try
            {
                if (!CriaArquivoJson(cenario.Project, ref mensagem))
                    return false;

                if (!CriaArquivoXMLFromCenario(cenario, ref mensagem))
                    return false;

                if (!CriarPdf(Global.app_temp_file_xml, diretorio_saida, ref mensagem))
                    return false;

            }
            catch (Exception e)
            {
                mensagem = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="mensagemErro"></param>
        /// <param name="comEstimativa"></param>
        /// <returns></returns>
        public static bool CriaRelatorioCompleto(MD_Project project, string caminhoSaida, ref string mensagemErro, bool comEstimativa)
        {
            CL_Files.WriteOnTheLog("Document.CriaRelatorioCompleto", Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                if (!CriaArquivoJson(project, ref mensagemErro))
                    return false;

                if (!CriaArquivoXMLFromProject(project, comEstimativa, ref mensagemErro))
                    return false;

                if (!CriarPdf(Global.app_temp_file_xml, caminhoSaida, ref mensagemErro))
                    return false;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que cria o relatório de estimativa
        /// </summary>
        /// <param name="project"></param>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        public static bool CriaEstimativa(MD_Project project, string diretorio_saida, ref string mensagem)
        {
            CL_Files.WriteOnTheLog("Document.CriaEstimativa", Global.TipoLog.DETALHADO);
            mensagem = "";
            try
            {
                if (!CriaArquivoJson(project, ref mensagem))
                    return false;

                if (!CriaArquivoCSV(project.GetEstimativa(), ref mensagem))
                    return false;

                if(!CriarPdf(Global.app_temp_file_csv, diretorio_saida, ref mensagem))
                    return false;

            }
            catch(Exception e)
            {
                mensagem = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que cria o arquivo xml a partir de um projeto
        /// </summary>
        /// <param name="project"></param>
        /// <param name="mensagemErro"></param>
        /// <returns></returns>
        public static bool CriaArquivoXMLFromProject(MD_Project project, bool geraestimativa, ref string mensagemErro)
        {
            CL_Files.WriteOnTheLog("Document.CriaArquivoXML", Global.TipoLog.DETALHADO);
            mensagemErro = "";

            try
            {
                File.Delete(Global.app_temp_file_xml);

                StringBuilder texto = new StringBuilder();

                texto.Append("<?xml version=\"1.0\"?>" + Environment.NewLine);
                texto.Append("<document>" + Environment.NewLine);
                texto.Append("  <page>" + Environment.NewLine);
                texto.Append("      <title>" + Environment.NewLine);
                texto.Append("          " + project.NumeroTarefa + "-" + project.Nome + Environment.NewLine);
                texto.Append("      </title>" + Environment.NewLine);
                texto.Append("      <informacoes>" + Environment.NewLine);
                texto.Append("      </informacoes>" + Environment.NewLine);
                texto.Append("      <text>" + project.Descricao + Environment.NewLine);
                texto.Append("      </text>" + Environment.NewLine);
                texto.Append("  </page>" + Environment.NewLine);

                if (geraestimativa)
                {
                    MD_Estimativa estimativa = project.GetEstimativa();
                    texto.Append("  <page>" + Environment.NewLine);
                    texto.Append("      <title>" + Environment.NewLine);
                    texto.Append("          " + project.NumeroTarefa + " - Estimativa de testes" + Environment.NewLine);
                    texto.Append("      </title>" + Environment.NewLine);
                    texto.Append("      <informacoes>" + Environment.NewLine);
                    texto.Append("      </informacoes>" + Environment.NewLine);
                    texto.Append("      <text>" + CriaTextoEstimativa(project, ref mensagemErro) + Environment.NewLine);
                    texto.Append("      </text>" + Environment.NewLine);
                    texto.Append("  </page>" + Environment.NewLine);
                }

                int i = 0;
                foreach(MD_Cenario cenario in project.GetCenarios())
                {
                    string caminhocsv = Global.app_temp_file_csv.Replace(".", i + ".");

                    texto.Append("  <page>" + Environment.NewLine);
                    texto.Append("      <title>" + Environment.NewLine);
                    texto.Append("          Cenário " + (i+1).ToString());
                    texto.Append("      </title>" + Environment.NewLine);
                    texto.Append("      <informacoes>" + Environment.NewLine);
                    texto.Append("      </informacoes>" + Environment.NewLine);
                    texto.Append("      <text>" + GetTextoCenario(cenario, false) + Environment.NewLine);
                    texto.Append("      </text>" + Environment.NewLine);
                    texto.Append("  </page>" + Environment.NewLine);

                    if (!MontaCSVCenario(cenario, caminhocsv, ref mensagemErro))
                        return false;

                    if (Directory.GetFiles(Global.app_Prints_directory(cenario.Project) + cenario.Codigo + "\\").Count() > 0)
                    {
                        texto.Append("  <page>" + Environment.NewLine);
                        texto.Append("      <title>" + Environment.NewLine);
                        texto.Append("          Relatório de Testes" + Environment.NewLine);
                        texto.Append("      </title>" + Environment.NewLine);
                        texto.Append("      <informacoes>" + Environment.NewLine);
                        texto.Append("      </informacoes>" + Environment.NewLine);
                        texto.Append("      <table_lines>2</table_lines>" + Environment.NewLine);
                        texto.Append("      <csv_file>" + caminhocsv + "</csv_file>" + Environment.NewLine);
                        texto.Append("  </page>" + Environment.NewLine);
                    }
                }

                texto.Append("</document>" + Environment.NewLine);

                CL_Files arquivo = new CL_Files(Global.app_temp_file_xml);
                arquivo.WriteOnTheEnd(texto.ToString());
                arquivo = null;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que cria o arquivo xml a partir de um cenário
        /// </summary>
        /// <param name="cenario">cenário a se criar o arquivo xml</param>
        /// <param name="mensagemErro">mensagem se houver erro</param>
        /// <returns></returns>
        public static bool CriaArquivoXMLFromCenario(MD_Cenario cenario, ref string mensagemErro)
        {
            CL_Files.WriteOnTheLog("Document.CriaArquivoXML", Global.TipoLog.DETALHADO);
            mensagemErro = "";

            try
            {
                File.Delete(Global.app_temp_file_xml);

                if (!MontaCSVCenario(cenario, Global.app_temp_file_csv, ref mensagemErro))
                    return false;

                StringBuilder texto = new StringBuilder();

                texto.Append("<?xml version=\"1.0\"?>" + Environment.NewLine);
                texto.Append("<document>" + Environment.NewLine);
                texto.Append("  <page>" + Environment.NewLine);
                texto.Append("      <title>" + Environment.NewLine);
                texto.Append("          " + cenario.Project.NumeroTarefa + "-" + cenario.Project.Nome + " - Relatório de Testes" + Environment.NewLine);
                texto.Append("      </title>" + Environment.NewLine);
                texto.Append("      <informacoes>" + Environment.NewLine);
                texto.Append("      </informacoes>" + Environment.NewLine);
                texto.Append("      <text>" + GetTextoCenario(cenario, true) + Environment.NewLine);
                texto.Append("      </text>" + Environment.NewLine);
                texto.Append("  </page>" + Environment.NewLine);

                if (Directory.GetFiles(Global.app_Prints_directory(cenario.Project) + cenario.Codigo + "\\").Count() > 0)
                {
                    texto.Append("  <page>" + Environment.NewLine);
                    texto.Append("      <title>" + Environment.NewLine);
                    texto.Append("          Relatório de Testes" + Environment.NewLine);
                    texto.Append("      </title>" + Environment.NewLine);
                    texto.Append("      <informacoes>" + Environment.NewLine);
                    texto.Append("      </informacoes>" + Environment.NewLine);
                    texto.Append("      <table_lines>2</table_lines>" + Environment.NewLine);
                    texto.Append("      <csv_file>" + Global.app_temp_file_csv + "</csv_file>" + Environment.NewLine);
                    texto.Append("  </page>" + Environment.NewLine);
                }

                texto.Append("</document>" + Environment.NewLine);

                CL_Files arquivo = new CL_Files(Global.app_temp_file_xml);
                arquivo.WriteOnTheEnd(texto.ToString());
                arquivo = null;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que monta o arquivo csv a partir dos anexos do cenário
        /// </summary>
        /// <param name="cenario">Cenário a se criar o relatório</param>
        /// <param name="mensagemErro">Mensagem de Erro</param>
        /// <returns>True - csv criado com sucesso; False - Não foi possível gerar o relatório</returns>
        private static bool MontaCSVCenario(MD_Cenario cenario, string caminhoSaida, ref string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Document.MontaCSVCenario()", Util.Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                File.Delete(Global.app_temp_file_csv);

                string[] texto = Directory.GetFiles(Global.app_Prints_directory(cenario.Project) + cenario.Codigo + "\\");
                if (texto.Count() == 0)
                    return true;

                StringBuilder builder = new StringBuilder();

                bool first = true;
                string[] txt = texto[0].Split('\\');
                MD_Anexos anexo_old = MD_Anexos.RetornaAnexoFromFileName(txt[txt.Count() - 1], cenario);
                MD_Anexos anexos = anexo_old;
                for (int i = 0; i< texto.Count(); i++)
                {
                    txt = texto[i].Split('\\');
                    FileInfo info = new FileInfo(texto[i]);
                    anexos = MD_Anexos.RetornaAnexoFromFileName(txt[txt.Count() -1], cenario);

                    if (info.Extension.Equals(".jpg") || info.Extension.Equals(".jpeg") || info.Extension.Equals(".png"))
                    {
                        if (first)
                        {
                            builder.Append("<img src=\"" + texto[i] + "\" width=\"90%\" height=\"90%\" >");
                            anexo_old = anexos;
                            first = false;
                        }
                        else
                        {
                            builder.Append(";<img src=\"" + texto[i] + "\" width=\"90%\" height=\"90%\" >" + Environment.NewLine);
                            builder.Append(anexo_old.Descricao + ";" + anexos.Descricao + Environment.NewLine);
                            first = true;
                        }
                    }
                }
                if (!first)
                {
                    builder.Append(";" + Environment.NewLine);
                    builder.Append(anexo_old.Descricao + ";" + Environment.NewLine);
                }

                CL_Files file = new CL_Files(caminhoSaida);
                file.WriteOnTheEnd(builder.ToString());
                file = null;
            }
            catch(Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que retorna o texto do cenário
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private static string GetTextoCenario(MD_Cenario cenario, bool completo)
        {
            Util.CL_Files.WriteOnTheLog("Document.GetTextoCenario()", Util.Global.TipoLog.DETALHADO);
            StringBuilder texto = new StringBuilder();

            if (completo)
            {
                texto.Append("\\tDescrição\\et" + Environment.NewLine);
                texto.Append(cenario.Project.Descricao + Environment.NewLine + "|");
            }
            
            texto.Append("\\center\\tTestes - \\u" + (cenario.EhReparo == Enumerator.Reparo.SIM ? "Reparo" : "Mudança") + "\\eu " + cenario.Tarefa  + " - Status: \\u" + cenario.Status.Nome + "\\eu - Analista " + cenario.Project.NomeTester + "\\et\\ecenter" + Environment.NewLine);
            if (!string.IsNullOrEmpty(cenario.BancoUtilizado))
                texto.Append("\\tBanco:\\et" + cenario.BancoUtilizado + (cenario.BancoUtilizado.LastIndexOf('.') == (cenario.BancoUtilizado.Length - 1) ? "" : ".") + Environment.NewLine);
            if (!string.IsNullOrEmpty(cenario.Entrada))
                texto.Append("\\tEntrada:\\et" + Environment.NewLine + cenario.Entrada + (cenario.Entrada.LastIndexOf('.') == (cenario.Entrada.Length - 1) ? "" : ".") + Environment.NewLine);
            if (!string.IsNullOrEmpty(cenario.Saida))
                texto.Append("\\tSaída:\\et" + Environment.NewLine + cenario.Saida + (cenario.Saida.LastIndexOf('.') == (cenario.Saida.Length - 1) ? "" : ".") + Environment.NewLine);
            if (!string.IsNullOrEmpty(cenario.Passos))
                texto.Append("\\tPassos:\\et" + Environment.NewLine + cenario.Passos + (cenario.Passos.LastIndexOf('.') == (cenario.Passos.Length - 1) ? "" : ".") + Environment.NewLine);

            return texto.ToString();
        }

        /// <summary>
        /// Método que cria o arquivo json de configuração
        /// </summary>
        /// <param name="project">Projeto a se criar a configuração</param>
        /// <param name="mensagemErro">Mensagem de erro se houver</param>
        /// <returns>true - Criou o arquivo com sucesso; False - erro</returns>
        private static bool CriaArquivoJson(MD_Project project, ref string mensagemErro)
        {
            CL_Files.WriteOnTheLog("Document.CriaEstimativa", Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                
                
                File.Delete(Global.app_temp_file_json);

                MD_Estimativa estimativa = project.GetEstimativa();

                StringBuilder texto = new StringBuilder();
                texto.Append("{\n");
                texto.Append("  'AUTHOR':'" + project.NomeTester + "'," + Environment.NewLine);
                texto.Append("  'CRIACAO':'" + project.DataCriacao.ToShortDateString() + "'," + Environment.NewLine);
                texto.Append("  'CRIADOR':'" + project.NomeTester + "',");
                texto.Append("  'MODIFICACAO':'" + project.DataCriacao.ToShortDateString() + "'," + Environment.NewLine);
                texto.Append("  'ASSUNTO':'" + project.Nome + "'," + Environment.NewLine);
                texto.Append("  'TITULO':'" + project.NumeroTarefa + " - " + project.Nome + "'" + Environment.NewLine);
                texto.Append("}");

                StreamWriter writer = new StreamWriter(Global.app_temp_file_json);

                writer.Write(texto.ToString());
                writer.Close();
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que cria o arquivo csv para estimativa
        /// </summary>
        /// <param name="estimativa"></param>
        /// <param name="mensagemErro"></param>
        /// <returns></returns>
        private static bool CriaArquivoCSV(MD_Estimativa estimativa, ref string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Document.CriaArquivoCSV()", Util.Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                File.Delete(Global.app_temp_file_csv);

                StringBuilder texto = new StringBuilder();
                texto.Append("<b>Testes</b>;\n");
                texto.Append("Ler RRM;" + estimativa.TempoLeituraRRM + Environment.NewLine);
                texto.Append("Preparação do banco;" + estimativa.TempoPreparacaoBanco + Environment.NewLine);
                texto.Append("Criar roteiro;" + estimativa.TempoRoteiro + Environment.NewLine);
                texto.Append("Instalar versão;" + estimativa.TempoInstalação + Environment.NewLine);
                texto.Append("SSI banco de dados;" + estimativa.TempoBanco + Environment.NewLine);
                texto.Append("SSI Carga;" + estimativa.TempoCarga + Environment.NewLine);
                texto.Append("Importação, Exportação;" + estimativa.TempoExpImp + Environment.NewLine);
                texto.Append("SSU - Station;" + estimativa.TempoStation + Environment.NewLine);
                texto.Append("SSI - LdxProc;" + estimativa.TempoLdxproc + Environment.NewLine);
                texto.Append("SSI - MW;" + estimativa.TempoMiddleware + Environment.NewLine);
                texto.Append("SSM - AND ;" + estimativa.TempoAndroid + Environment.NewLine);
                texto.Append("SSM - WIN;" + estimativa.TempoWindows  + Environment.NewLine);
                texto.Append("Impactos negativos;" + estimativa.TempoImpactos + Environment.NewLine);
                texto.Append("Total;" + CalculaTempoTotalEstimativa(estimativa) + Environment.NewLine);

                CL_Files file = new CL_Files(Global.app_temp_file_csv);

                file.WriteOnTheEnd(texto.ToString());
                file = null;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que calcula o tempo total estimato da estimativa
        /// </summary>
        /// <param name="estimativa"></param>
        /// <returns>Formato das horas totais: 00:00:00</returns>
        public static string CalculaTempoTotalEstimativa(MD_Estimativa estimativa)
        {
            Util.CL_Files.WriteOnTheLog("Document.CalculaTempoTotalEstimativa()", Util.Global.TipoLog.DETALHADO);
            int horas = 0;
            int minutos = 0;
            int segundos = 0;

            horas += int.Parse(estimativa.TempoAndroid.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoBanco.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoCarga.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoExpImp.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoImpactos.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoInstalação.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoLdxproc.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoLeituraRRM.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoMiddleware.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoPreparacaoBanco.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoRoteiro.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoStation.Split(':')[0].ToString());
            horas += int.Parse(estimativa.TempoWindows.Split(':')[0].ToString());

            minutos += int.Parse(estimativa.TempoAndroid.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoBanco.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoCarga.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoExpImp.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoImpactos.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoInstalação.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoLdxproc.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoLeituraRRM.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoMiddleware.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoPreparacaoBanco.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoRoteiro.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoStation.Split(':')[1].ToString());
            minutos += int.Parse(estimativa.TempoWindows.Split(':')[1].ToString());

            segundos += int.Parse(estimativa.TempoAndroid.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoBanco.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoCarga.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoExpImp.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoImpactos.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoInstalação.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoLdxproc.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoLeituraRRM.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoMiddleware.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoPreparacaoBanco.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoRoteiro.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoStation.Split(':')[2].ToString());
            segundos += int.Parse(estimativa.TempoWindows.Split(':')[2].ToString());

            while(segundos >= 60)
            {
                minutos++;
                segundos -= 60;
            }

            while (minutos >= 60)
            {
                horas++;
                minutos -= 60;
            }

            string retorno = (horas >= 10 ? horas.ToString() : "0" + horas)  + ":" + (minutos >= 10 ? minutos.ToString() : "0" + minutos) + ":" + (segundos >= 10 ? segundos.ToString() : "0" + segundos);
            return retorno;
        }

        /// <summary>
        /// Método que gera o pdf
        /// </summary>
        /// <param name="caminhoEntrada">Diretório de entrada</param>
        /// <param name="diretorioSaida">Diretório de saída do pdf</param>
        /// <param name="mensagemErro">Mensagem de erro se houve</param>
        /// <returns>true - sucesso; False - erro</returns>
        private static bool CriarPdf(string caminhoEntrada, string diretorioSaida, ref string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Document.CriarPdf()", Util.Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                string comando = " -i \"" + caminhoEntrada + "\" -o \"" + diretorioSaida + "\" -c \"" + Global.app_temp_file_json + "\" -l";
                Util.CL_Files.WriteOnTheLog(Global.app_teste_document_file + comando, Util.Global.TipoLog.DETALHADO);
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(Global.app_teste_document_file, comando);

                while (!process.HasExited) ;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que executa um, arquivo
        /// </summary>
        /// <param name="diretorio"></param>
        /// <param name="mensagemErro"></param>
        /// <returns>True - Sucesso; False - Erro</returns>
        public static bool ExecutaFile(string diretorio, bool espera_finalizar, ref string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Document.ExecutaFile()", Util.Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(diretorio);

                if(espera_finalizar)
                    while (!process.HasExited) ;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                CL_Files.WriteOnTheLog("Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        #endregion Métodos
    }
}

