using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMaker.Model
{
    /// <summary>
    /// [MAKANEXOS] Classe de implementação do objeto da tabela MAKANEXOS
    /// </summary>
    public class MD_Anexos : MDN_Model
    {
        #region Atributos e Propriedades

        int codigo_anexo = 0;
        /// <summary>
        /// [CODIGOANEXO] Código do anexo
        /// </summary>
        public int Codigo
        {
            get
            {
                return codigo_anexo;
            }
        }

        int codigo_projeto = 0;
        int numeroTarefa = 0;
        /// <summary>
        /// Objeto de representação do projeto associado ao cenário associado ao anexo
        /// </summary>
        MD_Project project;
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

        int codigo_cenario = 0;
        MD_Cenario cenario;
        /// <summary>
        /// [CODIGOCEN] Código do cenário vinculado ao anexo
        /// </summary>
        public MD_Cenario Cenario
        {
            get
            {
                if (cenario == null)
                    cenario = new MD_Cenario(codigo_cenario, project);
                return cenario;
            }
            set
            {
                cenario = value;
                codigo_cenario = cenario.Codigo;
            }
        }

        string nome_arquivo = "";
        /// <summary>
        /// [NOMEFILE] nome do arquivo
        /// </summary>
        public string Arquivo
        {
            get
            {
                return nome_arquivo;
            }
            set
            {
                nome_arquivo = value;
            }
        }

        string descricao_anexo = "";
        /// <summary>
        /// [DESCRICAOANEX] Descrição do anexo
        /// </summary>
        public string Descricao
        {
            get
            {
                return descricao_anexo;
            }
            set
            {
                descricao_anexo = value;
            }
        }

        #endregion Atributos e Propriedades

        #region Construtores

        /// <summary>
        /// Construtor Principal da classe
        /// </summary>
        MD_Anexos()
            : base()
        {
            Util.CL_Files.WriteOnTheLog("MD_Anexos.MD_Anexos()", Util.Global.TipoLog.DETALHADO);
            base.table = new MDN_Table("MAKANEXOS");
            this.table.Fields_Table.Add(new MDN_Campo("CODIGOANEXO",    true, Util.Enumerator.DataType.INT,    null, true,  true,  15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("CODIGOCEN",      true, Util.Enumerator.DataType.INT,    null, true,  true,  15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TAREFA",         true, Util.Enumerator.DataType.INT,    null, true,  true,  15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("NOMEFILE",       true, Util.Enumerator.DataType.STRING, "",   false, false, 50, 0));
            this.table.Fields_Table.Add(new MDN_Campo("DESCRICAOANEX",  true, Util.Enumerator.DataType.STRING, "",   false, false, 50, 0));

            if (!base.table.ExistsTable())
                base.table.CreateTable(false);

            base.table.VerificaColunas();
        }

        /// <summary>
        /// Construtor secundário da classe
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="cenario"></param>
        public MD_Anexos(int codigo, MD_Cenario cenario)
            :this()
        {
            Util.CL_Files.WriteOnTheLog("MD_Anexos.MD_Anexos(int codigo, MD_Cenario cenario)", Util.Global.TipoLog.DETALHADO);
            codigo_anexo = codigo;
            this.Cenario = cenario;
            this.Project = cenario.Project;
            Load();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que faz o Load da classe
        /// </summary>
        public override void Load()
        {
            Util.CL_Files.WriteOnTheLog("MD_Anexos.Load()", Util.Global.TipoLog.DETALHADO);
            string sentenca = base.table.CreateCommandSQLTable() + " WHERE CODIGOANEXO = " + Codigo + " AND CODIGOCEN = " + cenario.Codigo + " AND TAREFA = " + cenario.Project.NumeroTarefa;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            if (reader == null)
                this.Empty = true;
            else if (reader.Read())
            {
                Arquivo = reader["NOMEFILE"].ToString();
                Descricao = reader["DESCRICAOANEX"].ToString();
                reader.Close();

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
            Util.CL_Files.WriteOnTheLog("MD_Anexos.Delete()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "DELETE FROM " + table.Table_Name + " WHERE CODIGOANEXO = " + Codigo + " AND CODIGOCEN " + Cenario.Codigo + " AND TAREFA = " + Cenario.Project.NumeroTarefa; ;
            return Util.DataBase.Delete(sentenca);
        }

        /// <summary>
        /// Método que faz o insert do objeto
        /// </summary>
        /// <returns>True - Sucesso;False - Erro no insert</returns>
        public override bool Insert()
        {
            Util.CL_Files.WriteOnTheLog("MD_Anexos.Insert()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "INSERT INTO " + table.Table_Name + " (CODIGOANEXO, CODIGOCEN, TAREFA, NOMEFILE, DESCRICAOANEX) " +
                              " VALUES (" + Codigo + ", " + Cenario.Codigo + ", " + Cenario.Project.NumeroTarefa + ", '" + Arquivo + "','" + Descricao + "')";
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
            Util.CL_Files.WriteOnTheLog("MD_Anexos.Update()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "UPDATE " + table.Table_Name + " SET " +
                              "  CODIGOCEN		= " + Cenario.Codigo + 
                              ", NOMEFILE		= '" + Arquivo + "'" +
                              ", DESCRICAOANEX	= '" + Descricao + "'" +
                              " WHERE CODIGOANEXO = " + Codigo + " AND CODIGOCEN " + cenario.Codigo + " AND TAREFA = " + cenario.Project.NumeroTarefa; ;
            return Util.DataBase.Update(sentenca);
        }

        /// <summary>
        /// Método que retorna o anexo pelo nome do aruqivo e o cenário
        /// </summary>
        /// <param name="arquivo">Arquivo</param>
        /// <param name="cenario">Cenário</param>
        /// <returns>Novo abjeto</returns>
        public static MD_Anexos RetornaAnexoFromFileName(string arquivo, MD_Cenario cenario)
        {
            Util.CL_Files.WriteOnTheLog("MD_Anexos.RetornaAnexoFromFileName()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "SELECT CODIGOANEXO FROM MAKANEXOS WHERE  NOMEFILE = '" + arquivo + "' AND CODIGOCEN = " + cenario.Codigo + " AND TAREFA = " + cenario.Project.NumeroTarefa;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);

            if (reader == null)
                return null;
            else if (reader.Read())
            {
                int codigo = int.Parse(reader["CODIGOANEXO"].ToString());
                MD_Anexos anexo = new MD_Anexos(codigo, cenario);
                reader.Close();

                return anexo;
            }
            return null;
        }

        #endregion Métodos
    }
}
