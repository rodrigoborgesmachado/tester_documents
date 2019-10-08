-- Todas as tabelas terão a inicial MAK pois são referente ao projeto CASE_MAKER. No projeto tester_documents o começo das tabelas são com PDF.

-- Tabela de informações do PDF a ser gerado () projeto TESTER_DOCUMENTS
CREATE TABLE PDFINFO (
	CODIGO  			INTEGER  	 NOT NULL, 
	AUTHOR  			VARCHAR(100) DEFAULT '' NOT NULL, 
	DATA_CRIACAO  		INTEGER 	 DEFAULT 0  NOT NULL, 
	CREATOR  			VARCHAR(100) DEFAULT '' NOT NULL, 
	DATA_MODIFICACAO 	INTEGER  	 DEFAULT 0  NOT NULL, 
	SUBJECT  			VARCHAR(100) DEFAULT '' NOT NULL, 
	TITLE  				VARCHAR(100) DEFAULT '' NOT NULL, 
	KEYWORDS  			VARCHAR(100) DEFAULT '' NOT NULL, 
	DIRLOG  			VARCHAR(100) DEFAULT '' NOT NULL,  
	PRIMARY KEY (CODIGO)
);

-- Tabela de controle de código
CREATE TABLE CODIGOS_TABLE(
	TABELA VARCHAR(30) NOT NULL,
	CODIGO INT DEFAULT 0 NOT NULL,
	PRIMARY KEY(TABLE)
);


-- Tabela que armazena os documentos (projeto do caso de uso)
CREATE TABLE MAKDOCUMENTS (
	CODIGOPROJ			INTEGER  	  NOT NULL, 
	NOMEPROJ			VARCHAR(50)   DEFAULT ''  NOT NULL, -- Nome da nova regra (nome do RRM)
	DESCRICAOPROJ		VARCHAR(5000) DEFAULT ''  NOT NULL, -- Breve resumo da regra (primeira parte do RRM)
	DATA_CRIACAO  		INTEGER 	  DEFAULT 0   NOT NULL, 
	TAREFA		  		INTEGER 	  DEFAULT 0   NOT NULL, 
	DIR_RRM  	  		VARCHAR(300)  DEFAULT ''  NOT NULL, -- Diretório onde o RRM está salvo
	NOME_PROGRAMADOR	VARCHAR(50)   DEFAULT ''  NOT NULL, 
	NOME_ANALISTA		VARCHAR(50)   DEFAULT ''  NOT NULL, 
	NOME_TESTER			VARCHAR(50)   DEFAULT ''  NOT NULL,
	TIPOPROJ			CHAR(1)       DEFAULT ''  NOT NULL, -- Tipo do projeto: 0 -> Mudança, 1 -> Correção
	VERSAOSYSTEM		VARCHAR(8)    DEFAULT '00.00.00' NOT NULL, -- Versão que o RRM está sendo lançado
	PRODUTO				CHAR(1)    	  DEFAULT '1' NOT NULL, -- Tipo do produto (0 - SFV; 1- Flex)
	PRIMARY KEY (CODIGOPROJ, TAREFA)
);
INSERT INTO CODIGOS_TABLE (TABELA, CODIGO) VALUES ('MAKDOCUMENTS', 0);

-- Tabela de estimativas
CREATE TABLE MAKESTIMATIVAS (
	CODIGOEST			INTEGER		NOT NULL,
	TAREFA				INTEGER  	NOT NULL, 
	TMLEITURA			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de leitura do RRM
	TMPRBANCO			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de preparação do banco
	TMROTEIRO			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de criação de roteiro
	TMINSTALAR			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de instalar versão
	TMBANCO				VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste no banco de dados
	TMCARGA				VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste do script de carga
	TMIMPEXP			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste de importação e exportação
	TMSSUSTATION		VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste do station
	TMSSILDXPROC		VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste do ldxproc
	TMSSIMW				VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste do Middleware
	TMSSMAND			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste do Android
	TMSSMWIN			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste do Windows
	TMIMPACTOS			VARCHAR(8)  DEFAULT '00:00:00' NOT NULL, -- Tempo de teste do Windows
	FOREIGN KEY (CODIGOPROJ) REFERENCES MAKDOCUMENTS (TAREFA),
	PRIMARY KEY (CODIGOEST, CODIGOPROJ)
);
INSERT INTO CODIGOS_TABLE (TABELA, CODIGO) VALUES ('MAKESTIMATIVAS', 0);

CREATE TABLE MAKSTATUS (
	CODIGOSTAT			INTEGER		NOT NULL,
	NOMESTAT			VARCHAR(50) NOT NULL,
	ERRO				CHAR(1) DEFAULT '0' NOT NULL -- Se o novo status é status de erro
	PRIMARY KEY (CODIGOSTAT)
);
INSERT INTO MAKSTATUS (CODIGOSTAT, NOMESTAT, ERRO) VALUES (0, 'Sucesso', '0');
INSERT INTO MAKSTATUS (CODIGOSTAT, NOMESTAT, ERRO) VALUES (1, 'Erro', '1');
INSERT INTO CODIGOS_TABLE (TABELA, CODIGO) VALUES ('MAKSTATUS', 2);

CREATE TABLE MAKCENARIOS (
	CODIGOCEN			INTEGER		NOT NULL,
	TAREFA				INTEGER  	NOT NULL, 
	REPARO				CHAR(1) 	DEFAULT '0' NOT NULL, -- Verifica se o teste é de um reparo ou não
	NUTAREFA			INTEGER  	NOT NULL, -- Número da tarefa do teste
	VERSAOSGBD			VARCHAR(25) DEFAULT '0' NOT NULL, -- Versão do banco utilizado
	TIPOBANCO			CHAR(1)		DEFAULT '0' NOT NULL, -- Tipo do banco utilizado (0 - Oracle; 1 - SQL Server; 2 - Firebird)
	BANCOUTIL			VARCHAR(50) DEFAULT '-' NOT NULL, -- Banco utilizado para o teste
	ENTRADA				VARCHAR(3000), -- Entrada do sistema
	SAIDA				VARCHAR(3000), -- Saída do sistema
	PASSOS				VARCHAR(3000), -- Passos a serem executados no teste
	CODIGOSTAT			CHAR(1) 	DEFAULT '0' NOT NULL, -- Status do teste
	DATA_CRIACAO  		INTEGER 	DEFAULT 0   NOT NULL,	
	SISTEMA				INTEGER		DEFAULT 0	NOT NULL, -- Sistema do cenário (0 - SSI, 1 - SSM, 2 - SSU, 3 - LdxMail)
	FOREIGN KEY (TAREFA) 	 REFERENCES MAKDOCUMENTS (TAREFA),
	FOREIGN KEY (CODIGOSTAT) REFERENCES MAKSTATUS    (CODIGOSTAT),
	PRIMARY KEY (CODIGOCEN, CODIGOPROJ)
);
INSERT INTO CODIGOS_TABLE (TABELA, CODIGO) VALUES ('MAKCENARIOS', 0);

CREATE TABLE MAKANEXOS(
	CODIGOANEXO 		INTEGER		 NOT NULL,
	CODIGOCEN			INTEGER		 NOT NULL,
	TAREFA				INTEGER  	 NOT NULL, 
	NOMEFILE			VARCHAR(50)  NOT NULL, -- Nome do arquivo de anexo
	DESCRICAOANEX		VARCHAR(500) NOT NULL, -- Descrição do anexo
	FOREIGN KEY (CODIGOCEN) REFERENCES MAKCENARIOS  (CODIGOCEN),
	FOREIGN KEY (TAREFA) 	REFERENCES MAKDOCUMENTS (TAREFA),
	PRIMARY KEY (CODIGOANEXO, CODIGOANEXO, TAREFA)
);
INSERT INTO CODIGOS_TABLE (TABELA, CODIGO) VALUES ('MAKANEXOS', 0);

CREATE TABLE LOGG(
	TIPO_LOG CHAR(1) DEFAULT '0' NOT NULL,
	PRIMARY KEY (TIPO_LOG)
);
INSERT INTO LOGG (TIPO_LOG) VALUES ('0');