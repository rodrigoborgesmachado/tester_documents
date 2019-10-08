using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMaker.Model
{
    /// <summary>
    /// [MAKESTIMATIVAS] Classe referente à tabela MAKESTIMATIVAS
    /// </summary>
    public class MD_Estimativa : MDN_Model
    {
        #region Atributos e Propriedades

        int codigo = 0;
        /// <summary>
        /// [CODIGOEST] Código da estimativa
        /// </summary>
        public int Codigo
        {
            get
            {
                return codigo;
            }
        }

        int codigo_projeto = 0;
        int numeroTarefa = 0;
        MD_Project project;
        /// <summary>
        /// [TAREFA] Código do projeto que a estimativa está vinculada
        /// </summary>
        public MD_Project Project
        {
            get
            {
                if (project == null)
                    project = new MD_Project(codigo_projeto, numeroTarefa);
                return project;
            }
            set
            {
                project = value;
                codigo_projeto = project.Codigo;
                numeroTarefa = project.NumeroTarefa;
            }
        }

        string tempo_leitura = "00:00:00";
        /// <summary>
        /// [TMLEITURA] Tempo de leitura do RRM
        /// </summary>
        public string TempoLeituraRRM
        {
            get
            {
                return tempo_leitura;
            }
            set
            {
                tempo_leitura = value;
            }
        }

        string tempo_preparacaoBanco = "00:00:00";
        /// <summary>
        /// [TMPRBANCO] Tempo de preparação do banco de dados
        /// </summary>
        public string TempoPreparacaoBanco
        {
            get
            {
                return tempo_preparacaoBanco;
            }
            set
            {
                tempo_preparacaoBanco = value;
            }
        }

        string tempo_roteiro = "00:00:00";
        /// <summary>
        /// [TMROTEIRO] Tempo de criação do roteiro de teste
        /// </summary>
        public string TempoRoteiro
        {
            get
            {
                return tempo_roteiro;
            }
            set
            {
                tempo_roteiro = value;
            }
        }

        string tempo_instalacao = "00:00:00";
        /// <summary>
        /// [TMINSTALAR] Tempo de instalação
        /// </summary>
        public string TempoInstalação
        {
            get
            {
                return tempo_instalacao;
            }
            set
            {
                tempo_instalacao = value;
            }
        }

        string tempo_banco = "00:00:00";
        /// <summary>
        /// [TMBANCO] Tempo de testes do banco de dados
        /// </summary>
        public string TempoBanco
        {
            get
            {
                return tempo_banco;
            }
            set
            {
                tempo_banco = value;
            }
        }

        string tempo_carga = "00:00:00";
        /// <summary>
        /// [TMCARGA] Tempo de testes de carga
        /// </summary>
        public string TempoCarga
        {
            get
            {
                return tempo_carga;
            }
            set
            {
                tempo_carga = value;
            }
        }

        string tempo_importacao_exportacao = "00:00:00";
        /// <summary>
        /// [TMIMPEXP] Tempo de testes de importação/exportação
        /// </summary>
        public string TempoExpImp
        {
            get
            {
                return tempo_importacao_exportacao;
            }
            set
            {
                tempo_importacao_exportacao = value;
            }
        }

        string tempo_station = "00:00:00";
        /// <summary>
        /// [TMSSUSTATION] Tempo de testes do station
        /// </summary>
        public string TempoStation
        {
            get
            {
                return tempo_station;
            }
            set
            {
                tempo_station = value;
            }
        }

        string tempo_ldxproc = "00:00:00";
        /// <summary>
        /// [TMSSILDXPROC] Tempo de testes do ldxproc
        /// </summary>
        public string TempoLdxproc
        {
            get
            {
                return tempo_ldxproc;
            }
            set
            {
                tempo_ldxproc = value;
            }
        }

        string tempo_middleware = "00:00:00";
        /// <summary>
        /// [TMSSIMW] Tempo de testes do middleware
        /// </summary>
        public string TempoMiddleware
        {
            get
            {
                return tempo_middleware;
            }
            set
            {
                tempo_middleware = value;
            }
        }

        string tempo_android = "00:00:00";
        /// <summary>
        /// [TMSSMAND] Tempo de testes do android
        /// </summary>
        public string TempoAndroid
        {
            get
            {
                return tempo_android;
            }
            set
            {
                tempo_android = value;
            }
        }

        string tempo_windows = "00:00:00";
        /// <summary>
        /// [TMSSMWIN] Tempo de testes do windows
        /// </summary>
        public string TempoWindows
        {
            get
            {
                return tempo_windows;
            }
            set
            {
                tempo_windows = value;
            }
        }

        string tempo_impactos = "00:00:00";
        /// <summary>
        /// [TMIMPACTOS] Tempo de testes do windows
        /// </summary>
        public string TempoImpactos
        {
            get
            {
                return tempo_impactos;
            }
            set
            {
                tempo_impactos = value;
            }
        }

        #endregion Atributos e Propriedades

        #region Construtores

        /// <summary>
        ///  Construtor principal da classe
        /// </summary>
        MD_Estimativa ()
            : base()
        {
            Util.CL_Files.WriteOnTheLog("MD_Estimativa.MD_Estimativa()", Util.Global.TipoLog.DETALHADO);
            base.table = new MDN_Table("MAKESTIMATIVAS");
            this.table.Fields_Table.Add(new MDN_Campo("CODIGOEST",      true, Util.Enumerator.DataType.INT,     null,      true,  true, 15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TAREFA",         true, Util.Enumerator.DataType.INT,     null,      true,  true, 15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMLEITURA",      true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMPRBANCO",      true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMROTEIRO",      true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMINSTALAR",     true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMBANCO",        true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMCARGA",        true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMIMPEXP",       true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMSSUSTATION",   true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMSSILDXPROC",   true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMSSIMW",        true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMSSMAND",       true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMSSMWIN",       true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TMIMPACTOS",     true, Util.Enumerator.DataType.STRING, "00:00:00", false, false, 8, 0));

            if (!base.table.ExistsTable())
                base.table.CreateTable(false);

            base.table.VerificaColunas();
        }

        /// <summary>
        /// Construtor secundário da classe
        /// </summary>
        /// <param name="codigo_estimativa">Código da estimativa</param>
        /// <param name="projeto">Projeto que a estimativa está associada</param>
        public MD_Estimativa(int codigo_estimativa, MD_Project projeto) :
            this()
        {
            Util.CL_Files.WriteOnTheLog("MD_Estimativa.MD_Estimativa()", Util.Global.TipoLog.DETALHADO);
            codigo = codigo_estimativa;
            Project = projeto;

            Load();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que faz o Load da classe
        /// </summary>
        public override void Load()
        {
            Util.CL_Files.WriteOnTheLog("MD_Estimativa.Load()", Util.Global.TipoLog.DETALHADO);

            string sentenca = base.table.CreateCommandSQLTable() + " WHERE CODIGOEST = " + Codigo + " AND TAREFA = " + numeroTarefa;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            if (reader == null)
                this.Empty = true;
            else if (reader.Read())
            {
                tempo_leitura = reader["TMLEITURA"].ToString();
                tempo_preparacaoBanco = reader["TMPRBANCO"].ToString();
                tempo_roteiro = reader["TMROTEIRO"].ToString();
                tempo_instalacao = reader["TMINSTALAR"].ToString();
                tempo_banco = reader["TMBANCO"].ToString();
                tempo_carga = reader["TMCARGA"].ToString();
                tempo_importacao_exportacao = reader["TMIMPEXP"].ToString();
                tempo_station = reader["TMSSUSTATION"].ToString();
                tempo_ldxproc = reader["TMSSILDXPROC"].ToString();
                tempo_middleware = reader["TMSSIMW"].ToString();
                tempo_android = reader["TMSSMAND"].ToString();
                tempo_windows = reader["TMSSMWIN"].ToString();
                tempo_impactos = reader["TMIMPACTOS"].ToString();
                this.Empty = false;
                reader.Close();
            }
            else
            {
                this.Empty = true;
                reader.Close();
            }   
        }

        /// <summary>
        /// Método que faz o Delete do objeto
        /// </summary>
        /// <returns>True - Delete efetuado com sucesso; False - Falha no delete</returns>
        public override bool Delete()
        {
            Util.CL_Files.WriteOnTheLog("MD_Estimativa.Delete()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "DELETE FROM " + table.Table_Name + " WHERE CODIGOEST = " + Codigo;
            return Util.DataBase.Delete(sentenca);
        }

        /// <summary>
        /// Método que faz o insert do objeto
        /// </summary>
        /// <returns>True - Sucesso;False - Erro no insert</returns>
        public override bool Insert()
        {
            Util.CL_Files.WriteOnTheLog("MD_Estimativa.Insert()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "INSERT INTO " + table.Table_Name + " (CODIGOEST, TAREFA, TMLEITURA, TMPRBANCO, TMROTEIRO, TMINSTALAR, TMBANCO, TMCARGA, TMIMPEXP, TMSSUSTATION, TMSSILDXPROC, TMSSIMW, TMSSMAND, TMSSMWIN, TMIMPACTOS) " + 
                              " VALUES (" + Codigo + ", " + Project.NumeroTarefa + ", '" + TempoLeituraRRM  + "','" + TempoPreparacaoBanco + "', '" + TempoRoteiro + "', '" + TempoInstalação + "', '" + TempoBanco + "','" + TempoCarga + "','" + TempoExpImp + "', '" +
                              TempoStation + "','" + TempoLdxproc + "','" + TempoMiddleware + "','" + TempoAndroid + "','" + TempoWindows + "','" + TempoImpactos + "')";
            if (Util.DataBase.Insert(sentenca))
            {
                Empty = false;
                return true;
            }
            return false;

        }

        /// <summary>
        /// Método que faz o update do objeto
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            Util.CL_Files.WriteOnTheLog("MD_Estimativa.Update()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "UPDATE " + table.Table_Name + " SET " +
                              "  TMLEITURA		= '" + TempoLeituraRRM + "'" +
                              ", TMPRBANCO		= '" + TempoPreparacaoBanco + "'" +
                              ", TMROTEIRO		= '" + TempoRoteiro + "'" +
                              ", TMINSTALAR		= '" + TempoInstalação + "'" +
                              ", TMBANCO		= '" + TempoBanco + "'" +
                              ", TMCARGA		= '" + TempoCarga + "'" +
                              ", TMIMPEXP		= '" + TempoExpImp + "'" +
                              ", TMSSUSTATION	= '" + TempoStation + "'" +
                              ", TMSSILDXPROC	= '" + TempoLdxproc + "'" +
                              ", TMSSIMW		= '" + TempoMiddleware + "'" +
                              ", TMSSMAND		= '" + TempoAndroid + "'" +
                              ", TMSSMWIN		= '" + TempoWindows + "'" +
                              ", TMIMPACTOS		= '" + TempoImpactos + "'" +
                              " WHERE CODIGOEST = " + Codigo + " AND TAREFA = " + Project.NumeroTarefa;
            return Util.DataBase.Update(sentenca);
        }

        #endregion Métodos

    }
}
