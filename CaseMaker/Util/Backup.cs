using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;
using System.Data.SQLite;
using CaseMaker.Model;

namespace CaseMaker.Util
{
    public static class Backup
    {
        #region Gerar Backup

        /// <summary>
        /// Método que cria o backup do sistema
        /// </summary>
        /// <param name="caminhoSaida">Caminho onde o arquivo de backup será salvo</param>
        /// <param name="mensagemErro">Mensagem de referência para acompanhar erro</param>
        /// <returns>true - gerado com sucesso; False - erro ao gerar</returns>
        public static bool GerarBackup(string caminhoSaida, ref string mensagemErro)
        {
            mensagemErro = "";
            try
            {
                if (Directory.Exists(Global.app_backup_directory))
                    Directory.Delete(Global.app_backup_directory, true);
                Directory.CreateDirectory(Global.app_backup_directory);

                if (!CopiaPastasParaBackup(ref mensagemErro))
                    return false;
                if (!CriaZip(ref mensagemErro))
                    return false;
            }
            catch(Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que cria o arquivo zip de backup
        /// </summary>
        /// <param name="mensagemErro">string para mensagem de erro</param>
        /// <returns>True - Arquivo criado; False - erro ao gerar o arquivo</returns>
        private static bool CriaZip(ref string mensagemErro)
        {
            mensagemErro = "";
            try
            {
                ZipFile zip = new ZipFile();
                zip.AddDirectory(Global.app_backup_directory);
                
                zip.Save(Global.nome_arquivo_backup);
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que copia as pastas do sistema para a pasta de backup
        /// </summary>
        /// <returns>true - sucesso; False - erro</returns>
        private static bool CopiaPastasParaBackup(ref string mensagemErro)
        {
            mensagemErro = "";
            try
            {
                List<string> diretorios = new List<string>();
                diretorios.Add(Global.app_base_directory);
                diretorios.Add(Global.app_temp_directory);
                diretorios.Add(Global.app_files_directory);
                diretorios.Add(Global.app_logs_directoty);
                diretorios.Add(Global.app_out_directory);

                foreach (string diretorio in diretorios)
                {
                    if (!Directory.Exists(diretorio))
                        continue;

                    CopiaDiretorio(diretorio, ref mensagemErro);
                    
                }
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que copia o diretório passado por referência para o diretório de backup
        /// </summary>
        /// <param name="diretorio"></param>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        private static bool CopiaDiretorio(string diretorio, ref string mensagemErro)
        {
            mensagemErro = "";
            try
            {
                string dir = Global.app_backup_directory + diretorio.Replace(Global.app_main_directoty, "");
                Directory.CreateDirectory(dir);
                if (dir.LastIndexOf('\\') != dir.Length-1)
                    dir += "\\";

                DirectoryInfo info = new DirectoryInfo(diretorio);
                foreach(DirectoryInfo i in info.GetDirectories())
                {
                    if(!CopiaDiretorio(i.FullName, ref mensagemErro))
                    {
                        return false;
                    }
                }

                foreach (string file in Directory.GetFiles(diretorio))
                {
                    FileInfo infoFile = new FileInfo(file);
                    File.Copy(file, dir + infoFile.Name);
                    infoFile = null;
                }
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }
        #endregion Gerar Backup

        /// <summary>
        /// Método que busca o backup a partir do arquivo
        /// </summary>
        /// <param name="file">Arquivo de backup a ser importado</param>
        /// <param name="mensagemErro">mensagem de erro</param>
        /// <returns>true - sucesso;false - erro</returns>
        public static bool BuscarBackup(string file, ref string mensagemErro)
        {
            mensagemErro = "";
            try
            {
                if (!File.Exists(file))
                {
                    mensagemErro = "Arquivo não existe!";
                    return false;
                }

                if (Directory.Exists(Global.app_backup_directory))
                    Directory.Delete(Global.app_backup_directory, true);
                Directory.CreateDirectory(Global.app_backup_directory);

                File.Copy(file, Global.nome_arquivo_backup);

                if (!ImportaBancoBackup(ref mensagemErro))
                    return false;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que copia os arquivos de anexo
        /// </summary>
        /// <param name="mensagemErro"></param>
        /// <returns></returns>
        private static bool CopiaAnexos(MD_Project project, ref string mensagemErro)
        {
            try
            {
                if (!Directory.Exists(Global.app_files_directory))
                    Directory.CreateDirectory(Global.app_files_directory);

                if (!Directory.Exists(Global.app_proj_directory(project)))
                {
                    Directory.CreateDirectory(Global.app_proj_directory(project));
                    Directory.CreateDirectory(Global.app_Prints_directory(project));
                    Directory.CreateDirectory(Global.app_RRM_directory(project));
                }

                string caminho = Global.app_backup_directory + Global.app_Prints_directory(project).Replace(Global.app_main_directoty, "");

                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                foreach (string file in Directory.GetFiles(caminho))
                {
                    Directory.CreateDirectory(Global.app_Prints_directory(project));
                    FileInfo info = new FileInfo(file);
                    File.Copy(file, Global.app_Prints_directory(project) + info.Name);
                }
                

                caminho = Global.app_backup_directory + Global.app_RRM_directory(project).Replace(Global.app_main_directoty, "");

                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                foreach (string dir in Directory.GetDirectories(caminho))
                {
                    string[] comp = dir.Split('\\');
                    foreach (string file in Directory.GetFiles(caminho))
                    {
                        Directory.CreateDirectory(Global.app_RRM_directory(project) + comp[comp.Count() - 1] + "\\");
                        FileInfo info = new FileInfo(file);
                        File.Copy(file, Global.app_RRM_directory(project) + comp[comp.Count() - 1] + "\\" + info.Name);
                    }
                }
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que importa backup
        /// </summary>
        /// <param name="mensagemErro"></param>
        /// <returns>True - importacao realizada; False - erro</returns>
        private static bool ImportaBancoBackup(ref string mensagemErro)
        {
            mensagemErro = "";
            try
            {
                ZipFile file = new ZipFile(Global.nome_arquivo_backup);
                file.ExtractAll(Global.app_backup_directory);
                file.Dispose();

                DataBase.CloseConnection();
                DataBase.OpenConnection(Global.app_backup_directory + Global.app_base_file.Replace(Global.app_main_directoty, ""));

                List<MD_Project> project = new List<MD_Project>();
                // Criar tabela ou campos que não existem
                MD_Project pr = new MD_Project(0, 0);

                List<MD_Estimativa> estimativas = new List<MD_Estimativa>();
                // Criar tabela ou campos que não existem
                MD_Estimativa es = new MD_Estimativa(0, pr);

                List<MD_Status> status = new List<MD_Status>();
                // Criar tabela ou campos que não existem
                MD_Status st = new MD_Status(0);

                List<MD_Cenario> cenarios = new List<MD_Cenario>();
                // Criar tabela ou campos que não existem
                MD_Cenario ce = new MD_Cenario(0, pr);

                List<MD_Anexos> anexos = new List<MD_Anexos>();
                // Criar tabela ou campos que não existem
                MD_Anexos an = new MD_Anexos(0, ce);

                string sentenca = "SELECT CODIGOPROJ, TAREFA FROM MAKDOCUMENTS";
                SQLiteDataReader reader = DataBase.Select(sentenca);
                if(reader != null)
                {
                    while (reader.Read())
                    {
                        project.Add(new MD_Project(int.Parse(reader["CODIGOPROJ"].ToString()), int.Parse(reader["TAREFA"].ToString())));
                    }
                    reader.Close();
                }

                sentenca = "SELECT EST.CODIGOEST, DOC.CODIGOPROJ, EST.TAREFA FROM MAKESTIMATIVAS EST, MAKDOCUMENTS DOC WHERE DOC.TAREFA = EST.TAREFA ";
                reader = DataBase.Select(sentenca);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        estimativas.Add(new Model.MD_Estimativa(int.Parse(reader["CODIGOEST"].ToString()),new Model.MD_Project(int.Parse(reader["CODIGOPROJ"].ToString()), int.Parse(reader["TAREFA"].ToString()))));

                    }
                    reader.Close();
                }

                sentenca = "SELECT CODIGOSTAT FROM MAKSTATUS ";
                reader = DataBase.Select(sentenca);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        status.Add(new Model.MD_Status(int.Parse(reader["CODIGOSTAT"].ToString())));
                    }
                    reader.Close();
                }

                sentenca = "SELECT CEN.CODIGOCEN, DOC.CODIGOPROJ, CEN.TAREFA FROM MAKCENARIOS CEN, MAKDOCUMENTS DOC WHERE DOC.TAREFA = CEN.TAREFA ";
                reader = DataBase.Select(sentenca);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        cenarios.Add(new Model.MD_Cenario(int.Parse(reader["CODIGOCEN"].ToString()), new Model.MD_Project(int.Parse(reader["CODIGOPROJ"].ToString()), int.Parse(reader["TAREFA"].ToString()))));
                    }
                    reader.Close();
                }

                sentenca = "SELECT ANEX.CODIGOANEXO, CEN.CODIGOCEN, CEN.TAREFA, DOC.CODIGOPROJ FROM MAKANEXOS ANEX, MAKCENARIOS CEN, MAKDOCUMENTS DOC WHERE ANEX.TAREFA = CEN.TAREFA AND ANEX.CODIGOCEN = CEN.CODIGOCEN AND ANEX.TAREFA = DOC.TAREFA";
                reader = DataBase.Select(sentenca);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        anexos.Add(new Model.MD_Anexos(int.Parse(reader["CODIGOCEN"].ToString()), new Model.MD_Cenario(int.Parse(reader["CODIGOCEN"].ToString()), new Model.MD_Project(int.Parse(reader["CODIGOPROJ"].ToString()), int.Parse(reader["TAREFA"].ToString())))));
                    }
                    reader.Close();
                }

                DataBase.CloseConnection();
                DataBase.OpenConnection();

                foreach (MD_Project proj in project)
                {
                    proj.Load();

                    if (proj.Empty)
                    {
                        if (!proj.Insert())
                            return false;
                        if (!CopiaAnexos(proj, ref mensagemErro))
                            return false;
                    }
                }

                foreach (MD_Estimativa est in estimativas)
                {
                    est.Load();
                    if(est.Empty)
                        if (!est.Insert())
                            return false;
                }
                    

                foreach (MD_Status stat in status)
                {
                    stat.Load();
                    if(stat.Empty)
                        if (!stat.Insert())
                            return false;
                }
                    

                foreach (MD_Cenario cen in cenarios)
                {
                    cen.Load();
                    if(cen.Empty)
                        if (!cen.Insert())
                            return false;
                }

                foreach (MD_Anexos anex in anexos)
                {
                    anex.Load();
                    if(anex.Empty)
                        if (!anex.Insert())
                            return false;
                }
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }
    }
}
