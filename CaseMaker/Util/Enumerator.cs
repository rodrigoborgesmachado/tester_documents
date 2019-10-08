using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMaker.Util
{
    public class Enumerator
    {

        /// <summary>
        /// Enum referente à tela a ser aberta
        /// </summary>
        public enum Telas
        {
            CADASTRO_PROJETO = 0,
            CADASTRO_PROJETO_INCLUIR = 1,
            CADASTRO_ESTIMATIVA = 2,
            CADASTRO_CENARIO = 3
        }

        /// <summary>
        /// Tarefa sendo executada na tela
        /// </summary>
        public enum Tarefa
        {
            INCLUINDO = 0,
            EDITANDO = 1,
            EXCLUINDO = 2,
            VISUALIZANDO = 3
        }

        /// <summary>
        /// Enumerator for type of data
        /// </summary>
        public enum DataType
        {
            DATE = 1,
            INT = 2,
            STRING = 3,
            CHAR = 4,
            DECIMAL
        }

        #region Enumerator from rules

        /// <summary>
        /// Tipo do projeto:
        ///     0 - Correção
        ///     1 - Mudança
        /// </summary>
        public enum ProjType
        {
            MUDANCA = 0,
            CORRECAO = 1
        }

        /// <summary>
        /// Tipo do projeto (Sistema):
        ///      0 - SFV
        ///      1 - Flex
        /// </summary>
        public enum Sistema
        {
            SFV = 0,
            FLEX = 1
        }

        /// <summary>
        /// Tipos de erro:
        ///     0 - Sucesso
        ///     1 - Erro
        /// </summary>
        public enum StatusErro
        {
            SUCESSO = 0,
            ERRO = 1
        }

        /// <summary>
        /// Enumerator que verifica se o cenário de teste é um reparo ou não
        ///     0 - SIM 
        ///     1 - NÃO
        /// </summary>
        public enum Reparo
        {
            SIM = 0,
            NAO = 1
        }

        /// <summary>
        /// Enumerator que representa o banco de dados que está sendo testado
        ///     0 - ORACLE
        ///     1 - SQL SERVER
        ///     2 - FIREBIRD
        /// </summary>
        public enum Banco
        {
            ORACLE = 0,
            SQLSERVER = 1,
            FIREBIRD = 3
        }

        /// <summary>
        /// Enumerador que representa o tipo do sistema
        ///     0 - SSI
        ///     1 - SSM
        ///     2 - SSU
        ///     3 - LdxMail
        /// </summary>
        public enum TipoSistema
        {
            SSI = 0,
            SSM = 1,
            SSU = 2,
            LDXMAIL = 3,
            GENERICO = 1000
        }

        #endregion Enumerator from rules
    }
}
