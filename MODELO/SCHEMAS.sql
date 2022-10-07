/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     05/10/2022 00:02:25                          */
/*==============================================================*/


if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_ATIVIDADE')
          and type in ('P','PC'))
   drop procedure EXCLUI_ATIVIDADE
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_CIDADE')
          and type in ('P','PC'))
   drop procedure EXCLUI_CIDADE
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_CLIENTE')
          and type in ('P','PC'))
   drop procedure EXCLUI_CLIENTE
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_ITEMPACOTE')
          and type in ('P','PC'))
   drop procedure EXCLUI_ITEMPACOTE
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_MODULO')
          and type in ('P','PC'))
   drop procedure EXCLUI_MODULO
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_OPERADOR')
          and type in ('P','PC'))
   drop procedure EXCLUI_OPERADOR
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_PACOTE')
          and type in ('P','PC'))
   drop procedure EXCLUI_PACOTE
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_PARCEIRO')
          and type in ('P','PC'))
   drop procedure EXCLUI_PARCEIRO
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_PROCESSO')
          and type in ('P','PC'))
   drop procedure EXCLUI_PROCESSO
go

if exists (select 1
          from sysobjects
          where  id = object_id('EXCLUI_USUARIOCLIENTE')
          and type in ('P','PC'))
   drop procedure EXCLUI_USUARIOCLIENTE
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_ATIVIDADE')
          and type in ('P','PC'))
   drop procedure IA_ATIVIDADE
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_CIDADE')
          and type in ('P','PC'))
   drop procedure IA_CIDADE
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_CLIENTE')
          and type in ('P','PC'))
   drop procedure IA_CLIENTE
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_CLIENTEPROCESSO')
          and type in ('P','PC'))
   drop procedure IA_CLIENTEPROCESSO
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_ITEMPACOTE')
          and type in ('P','PC'))
   drop procedure IA_ITEMPACOTE
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_MODULO')
          and type in ('P','PC'))
   drop procedure IA_MODULO
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_OPERADOR')
          and type in ('P','PC'))
   drop procedure IA_OPERADOR
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_PACOTE')
          and type in ('P','PC'))
   drop procedure IA_PACOTE
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_PARCEIRO')
          and type in ('P','PC'))
   drop procedure IA_PARCEIRO
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_PROCESSO')
          and type in ('P','PC'))
   drop procedure IA_PROCESSO
go

if exists (select 1
          from sysobjects
          where  id = object_id('IA_USUARIOCLIENTE')
          and type in ('P','PC'))
   drop procedure IA_USUARIOCLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_CLIENTE') and o.name = 'FK_TB_CLIEN_REFERENCE_TB_PARCE')
alter table TB_CLIENTE
   drop constraint FK_TB_CLIEN_REFERENCE_TB_PARCE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_CLIENTE') and o.name = 'FK_TB_CLIEN_REFERENCE_TB_PACOT')
alter table TB_CLIENTE
   drop constraint FK_TB_CLIEN_REFERENCE_TB_PACOT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_CLIENTE') and o.name = 'FK_TB_CLIEN_REFERENCE_TB_CIDAD')
alter table TB_CLIENTE
   drop constraint FK_TB_CLIEN_REFERENCE_TB_CIDAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_CLIENTE') and o.name = 'FK_TB_CLIEN_REFERENCE_TB_ATIVI')
alter table TB_CLIENTE
   drop constraint FK_TB_CLIEN_REFERENCE_TB_ATIVI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_CLIENTEPROCESSO') and o.name = 'FK_TB_CLIEN_REFERENCE_TB_PROCE')
alter table TB_CLIENTEPROCESSO
   drop constraint FK_TB_CLIEN_REFERENCE_TB_PROCE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_CLIENTEPROCESSO') and o.name = 'FK_TB_CLIEN_REFERENCE_TB_CLIEN')
alter table TB_CLIENTEPROCESSO
   drop constraint FK_TB_CLIEN_REFERENCE_TB_CLIEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_ITEMPACOTE') and o.name = 'FK_TB_ITEMP_REFERENCE_TB_PACOT')
alter table TB_ITEMPACOTE
   drop constraint FK_TB_ITEMP_REFERENCE_TB_PACOT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_ITEMPACOTE') and o.name = 'FK_TB_ITEMP_REFERENCE_TB_PROCE')
alter table TB_ITEMPACOTE
   drop constraint FK_TB_ITEMP_REFERENCE_TB_PROCE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_OPERADOR') and o.name = 'FK_TB_OPERA_REFERENCE_TB_PARCE')
alter table TB_OPERADOR
   drop constraint FK_TB_OPERA_REFERENCE_TB_PARCE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_PROCESSO') and o.name = 'FK_TB_PROCE_REFERENCE_TB_MODUL')
alter table TB_PROCESSO
   drop constraint FK_TB_PROCE_REFERENCE_TB_MODUL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TB_USUARIOCLIENTE') and o.name = 'FK_TB_USUAR_REFERENCE_TB_CLIEN')
alter table TB_USUARIOCLIENTE
   drop constraint FK_TB_USUAR_REFERENCE_TB_CLIEN
go

alter table TB_ATIVIDADE
   drop constraint PK_TB_ATIVIDADE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_ATIVIDADE')
            and   type = 'U')
   drop table TB_ATIVIDADE
go

alter table TB_CIDADE
   drop constraint PK_TB_CIDADE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_CIDADE')
            and   type = 'U')
   drop table TB_CIDADE
go

alter table TB_CLIENTE
   drop constraint PK_TB_CLIENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_CLIENTE')
            and   type = 'U')
   drop table TB_CLIENTE
go

alter table TB_CLIENTEPROCESSO
   drop constraint PK_TB_CLIENTEPROCESSO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_CLIENTEPROCESSO')
            and   type = 'U')
   drop table TB_CLIENTEPROCESSO
go

alter table TB_ITEMPACOTE
   drop constraint PK_TB_ITEMPACOTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_ITEMPACOTE')
            and   type = 'U')
   drop table TB_ITEMPACOTE
go

alter table TB_MODULO
   drop constraint PK_TB_MODULO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_MODULO')
            and   type = 'U')
   drop table TB_MODULO
go

alter table TB_OPERADOR
   drop constraint PK_TB_OPERADOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_OPERADOR')
            and   type = 'U')
   drop table TB_OPERADOR
go

alter table TB_PACOTE
   drop constraint PK_TB_PACOTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_PACOTE')
            and   type = 'U')
   drop table TB_PACOTE
go

alter table TB_PARCEIRO
   drop constraint PK_TB_PARCEIRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_PARCEIRO')
            and   type = 'U')
   drop table TB_PARCEIRO
go

alter table TB_PROCESSO
   drop constraint PK_TB_PROCESSO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_PROCESSO')
            and   type = 'U')
   drop table TB_PROCESSO
go

alter table TB_USUARIOCLIENTE
   drop constraint PK_TB_USUARIOCLIENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TB_USUARIOCLIENTE')
            and   type = 'U')
   drop table TB_USUARIOCLIENTE
go

/*==============================================================*/
/* Table: TB_ATIVIDADE                                          */
/*==============================================================*/
create table TB_ATIVIDADE (
   IDATIVIDADE          int                  not null,
   DSATIVIDADE          varchar(50)          null
)
go

alter table TB_ATIVIDADE
   add constraint PK_TB_ATIVIDADE primary key (IDATIVIDADE)
go

/*==============================================================*/
/* Table: TB_CIDADE                                             */
/*==============================================================*/
create table TB_CIDADE (
   IDCIDADE             int                  not null,
   DSCIDADE             varchar(50)          null,
   UF                   varchar(2)           null
)
go

alter table TB_CIDADE
   add constraint PK_TB_CIDADE primary key (IDCIDADE)
go

/*==============================================================*/
/* Table: TB_CLIENTE                                            */
/*==============================================================*/
create table TB_CLIENTE (
   IDCLIENTE            int                  not null,
   IDCIDADE             int                  null,
   IDATIVIDADE          int                  null,
   IDPARCEIRO           int                  null,
   IDPACOTE             int                  null,
   TPPESSOA             char(1)              null,
   NRDOC                varchar(18)          null,
   RAZAOSOCIAL          varchar(50)          null,
   FANTASIA             varchar(50)          null,
   CEP                  varchar(10)          null,
   LOGRADOURO           varchar(50)          null,
   NUMERO               varchar(10)          null,
   REFERENCIA           varchar(50)          null,
   BAIRRO               varchar(30)          null,
   COMPLEMENTO          varchar(50)          null,
   IE                   varcahr(18)          null,
   CONTATO              varchar(50)          null,
   FONE                 varchar(14)          null,
   CELULAR              varchar(14)          null,
   EMAIL                varchar(255)         null,
   OBS                  varchar(1024)        null,
   NRSEQLIC             int                  null,
   DTLICENCA            datetime             null,
   MOBILE               bit                  null,
   QTMOBILE             int                  null,
   INATIVO              bit                  null
)
go

alter table TB_CLIENTE
   add constraint CKC_TPPESSOA_TB_CLIEN check (TPPESSOA is null or (TPPESSOA in ('J','F')))
go

alter table TB_CLIENTE
   add constraint PK_TB_CLIENTE primary key (IDCLIENTE)
go

/*==============================================================*/
/* Table: TB_CLIENTEPROCESSO                                    */
/*==============================================================*/
create table TB_CLIENTEPROCESSO (
   IDCLIENTE            int                  not null,
   IDPROCESSO           int                  not null,
   DTINI                datetime             null,
   DTFIN                datetime             null,
   MOTIVOINATIVO        varchar(1024)        null,
   INATIVO              bit                  null
)
go

alter table TB_CLIENTEPROCESSO
   add constraint PK_TB_CLIENTEPROCESSO primary key (IDCLIENTE, IDPROCESSO)
go

/*==============================================================*/
/* Table: TB_ITEMPACOTE                                         */
/*==============================================================*/
create table TB_ITEMPACOTE (
   IDPACOTE             int                  not null,
   IDPROCESSO           int                  not null
)
go

alter table TB_ITEMPACOTE
   add constraint PK_TB_ITEMPACOTE primary key (IDPACOTE, IDPROCESSO)
go

/*==============================================================*/
/* Table: TB_MODULO                                             */
/*==============================================================*/
create table TB_MODULO (
   IDMODULO             int                  not null,
   DSMODULO             varchar(50)          null
)
go

alter table TB_MODULO
   add constraint PK_TB_MODULO primary key (IDMODULO)
go

/*==============================================================*/
/* Table: TB_OPERADOR                                           */
/*==============================================================*/
create table TB_OPERADOR (
   IDPARCEIRO           int                  not null,
   IDOPERADOR           int                  not null,
   LOGIN                varchar(20)          null,
   SENHA                varchar(20)          null,
   NOMEOPERADOR         varchar(50)          null,
   EMAIL                varchar(255)         null,
   INATIVO              bit                  null
)
go

alter table TB_OPERADOR
   add constraint PK_TB_OPERADOR primary key (IDPARCEIRO, IDOPERADOR)
go

/*==============================================================*/
/* Table: TB_PACOTE                                             */
/*==============================================================*/
create table TB_PACOTE (
   IDPACOTE             int                  not null,
   DSPACOTE             varchar(50)          null
)
go

alter table TB_PACOTE
   add constraint PK_TB_PACOTE primary key (IDPACOTE)
go

/*==============================================================*/
/* Table: TB_PARCEIRO                                           */
/*==============================================================*/
create table TB_PARCEIRO (
   IDPARCEIRO           int                  not null,
   TPPESSOA             char(1)              null,
   NRDOC                varchar(18)          null,
   RAZAOSOCIAL          varchar(50)          null,
   FANTASIA             varchar(50)          null,
   CEP                  varchar(10)          null,
   LOGRADOURO           varchar(50)          null,
   NUMERO               varchar(10)          null,
   REFERENCIA           varchar(50)          null,
   BAIRRO               varchar(30)          null,
   COMPLEMENTO          varchar(50)          null,
   IE                   varcahr(18)          null,
   CONTATO              varchar(50)          null,
   FONE                 varchar(14)          null,
   CELULAR              varchar(14)          null,
   EMAIL                varchar(255)         null,
   FRANQUEADORA         bit                  null,
   INATIVO              bit                  null
)
go

alter table TB_PARCEIRO
   add constraint CKC_TPPESSOA_TB_PARCE check (TPPESSOA is null or (TPPESSOA in ('J','F')))
go

alter table TB_PARCEIRO
   add constraint PK_TB_PARCEIRO primary key (IDPARCEIRO)
go

/*==============================================================*/
/* Table: TB_PROCESSO                                           */
/*==============================================================*/
create table TB_PROCESSO (
   IDPROCESSO           int                  not null,
   IDMODULO             int                  null,
   DSPROCESSO           varchar(50)          null,
   COMPLEMENTO          varchar(1024)        null
)
go

alter table TB_PROCESSO
   add constraint PK_TB_PROCESSO primary key (IDPROCESSO)
go

/*==============================================================*/
/* Table: TB_USUARIOCLIENTE                                     */
/*==============================================================*/
create table TB_USUARIOCLIENTE (
   IDCLIENTE            int                  not null,
   IDLOGIN              int                  not null,
   LOGIN                varchar(20)          null,
   SENHA                varchar(20)          null,
   NOMEUSUARIO          varchar(50)          null,
   EMAIL                varchar(255)         null,
   NOTIFICAEVOLUCAO     bit                  null,
   INATIVO              bit                  null
)
go

alter table TB_USUARIOCLIENTE
   add constraint PK_TB_USUARIOCLIENTE primary key (IDCLIENTE, IDLOGIN)
go

alter table TB_CLIENTE
   add constraint FK_TB_CLIEN_REFERENCE_TB_PARCE foreign key (IDPARCEIRO)
      references TB_PARCEIRO (IDPARCEIRO)
go

alter table TB_CLIENTE
   add constraint FK_TB_CLIEN_REFERENCE_TB_PACOT foreign key (IDPACOTE)
      references TB_PACOTE (IDPACOTE)
go

alter table TB_CLIENTE
   add constraint FK_TB_CLIEN_REFERENCE_TB_CIDAD foreign key (IDCIDADE)
      references TB_CIDADE (IDCIDADE)
go

alter table TB_CLIENTE
   add constraint FK_TB_CLIEN_REFERENCE_TB_ATIVI foreign key (IDATIVIDADE)
      references TB_ATIVIDADE (IDATIVIDADE)
go

alter table TB_CLIENTEPROCESSO
   add constraint FK_TB_CLIEN_REFERENCE_TB_PROCE foreign key (IDPROCESSO)
      references TB_PROCESSO (IDPROCESSO)
go

alter table TB_CLIENTEPROCESSO
   add constraint FK_TB_CLIEN_REFERENCE_TB_CLIEN foreign key (IDCLIENTE)
      references TB_CLIENTE (IDCLIENTE)
go

alter table TB_ITEMPACOTE
   add constraint FK_TB_ITEMP_REFERENCE_TB_PACOT foreign key (IDPACOTE)
      references TB_PACOTE (IDPACOTE)
go

alter table TB_ITEMPACOTE
   add constraint FK_TB_ITEMP_REFERENCE_TB_PROCE foreign key (IDPROCESSO)
      references TB_PROCESSO (IDPROCESSO)
go

alter table TB_OPERADOR
   add constraint FK_TB_OPERA_REFERENCE_TB_PARCE foreign key (IDPARCEIRO)
      references TB_PARCEIRO (IDPARCEIRO)
go

alter table TB_PROCESSO
   add constraint FK_TB_PROCE_REFERENCE_TB_MODUL foreign key (IDMODULO)
      references TB_MODULO (IDMODULO)
go

alter table TB_USUARIOCLIENTE
   add constraint FK_TB_USUAR_REFERENCE_TB_CLIEN foreign key (IDCLIENTE)
      references TB_CLIENTE (IDCLIENTE)
go


CREATE PROCEDURE EXCLUI_ATIVIDADE(
        @P_IDATIVIDADE INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_ATIVIDADE
    WHERE IDATIVIDADE = @P_IDATIVIDADE;
END
go


CREATE PROCEDURE EXCLUI_CIDADE(
        @P_IDCIDADE INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_CIDADE
    WHERE ID_CIDADE = @P_IDCIDADE;
END
go


CREATE PROCEDURE EXCLUI_CLIENTE(
        @P_IDCLIENTE INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_CLIENTE
    WHERE IDCLIENTE = @P_IDCLIENTE;
END
go


CREATE PROCEDURE EXCLUI_ITEMPACOTE(
        @P_IDPACOTE INT,
        @P_IDPROCESSO INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_ITEMPACOTE
    WHERE IDPACOTE = @P_IDPACOTE
    AND IDPROCESSO = @P_IDPROCESSO;
END
go


CREATE PROCEDURE EXCLUI_MODULO(
        @P_IDMODULO INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_MODULO
    WHERE IDMODULO = @P_IDMODULO;
END
go


CREATE PROCEDURE EXCLUI_OPERADOR(
        @P_IDPARCEIRO INT,
        @P_IDOPERADOR INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_OPERADOR
    WHERE IDPARCEIRO = @P_IDPARCEIRO
    AND IDOPERADOR = @P_IDOPERADOR;
END
go


CREATE PROCEDURE EXCLUI_PACOTE(
        @P_IDPACOTE INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_PACOTE
    WHERE IDPACOTE = @P_IDPACOTE;
END
go


CREATE PROCEDURE EXCLUI_PARCEIRO(
        @P_IDPARCEIRO INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_PARCEIRO
    WHERE IDPARCEIRO = @P_IDPARCEIRO;
END
go


CREATE PROCEDURE EXCLUI_PROCESSO(
        @P_IDPROCESSO INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_PROCESSO
    WHERE IDPROCESSO = @P_IDPROCESSO;
END
go


CREATE PROCEDURE EXCLUI_USUARIOCLIENTE(
        @P_IDCLIENTE INT,
        @P_IDLOGIN INT)WITH RECOMPILE
AS
BEGIN
    DELETE TB_USUARIOCLIENTE
    WHERE IDCLIENTE = @P_IDCLIENTE
    AND IDLOGIN = @P_IDLOGIN;
END
go


CREATE PROCEDURE IA_ATIVIDADE(
        @P_IDATIVIDADE INT OUTPUT,
        @P_DSATIVIDADE VARCHAR(50))WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_ATIVIDADE
                    WHERE IDATIVIDADE = @P_IDATIVIDADE)
    BEGIN
        SET @P_IDATIVIDADE = 1 + ISNULL((SELECT MAX(IDATIVIDADE)
                                    FROM TB_ATIVIDADE), 0);
        INSERT INTO TB_ATIVIDADE(
            IDATIVIDADE,
            DSATIVIDADE)VALUES(
            @P_IDATIVIDADE,
            @P_DSATIVIDADE);                            
    END
    ELSE
    BEGIN
        UPDATE TB_ATIVIDADE SET
            DSATIVIDADE = @P_DSATIVIDADE
        WHERE IDATIVIDADE = @P_IDATIVIDADE;    
    END                
END
go


CREATE PROCEDURE IA_CIDADE(
        @P_IDCIDADE INT OUTPUT,
        @P_DSCIDADE VARCHAR(50),
        @P_UF VARCHAR(2))WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_CIDADE
                    WHERE IDCIDADE = @P_IDCIDADE)
    BEGIN
        INSERT INTO TB_CIDADE(
            IDCIDADE,
            DSCIDADE,
            UF)VALUES(
            @P_IDCIDADE,
            @P_DSCIDADE,
            @P_UF)
    END
    ELSE
    BEGIN
        UPDATE TB_CIDADE SET
            DSCIDADE = @P_DSCIDADE,
            UF = @P_UF
        WHERE IDCIDADE = @P_IDCIDADE;    
    END                
END
go


CREATE PROCEDURE IA_CLIENTE(
        @P_IDCLIENTE INT OUTPUT,
        @P_IDCIDADE INT,
        @P_IDATIVIDADE INT,
        @P_IDPARCEIRO INT,
        @P_IDPACOTE INT,
        @P_TPPESSOA CHAR(1),
        @P_NRDOC VARCHAR(18),
        @P_RAZAOSOCIAL VARCHAR(50),
        @P_FANTASIA VARCHAR(50),
        @P_CEP VARCHAR(10),
        @P_LOGRADOURO VARCHAR(50),
        @P_NUMERO VARCHAR(10),
        @P_REFERENCIA VARCHAR(50),
        @P_BAIRRO VARCHAR(30),
        @P_COMPLEMENTO VARCHAR(50),
        @P_IE VARCHAR(18),
        @P_CONTATO VARCHAR(50),
        @P_FONE VARCHAR(14),
        @P_CELULAR VARCHAR(14),
        @P_EMAIL VARCHAR(255),
        @P_OBS VARCHAR(1024),
        @P_NRSEQLIC INT,
        @P_DTLICENCA DATETIME,
        @P_MOBILE BIT,
        @P_QTMOBILE INT,
        @P_INATIVO BIT)WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_CLIENTE
                    WHERE IDCLIENTE = @P_IDCLIENTE)
    BEGIN
        SET @P_IDCLIENTE = 1 + ISNULL((SELECT MAX(IDCLIENTE)
                                FROM TB_CLIENTE), 0);
        INSERT INTO TB_CLIENTE(
            IDCLIENTE,
            IDCIDADE,
            IDATIVIDADE,
            IDPARCEIRO,
            IDPACOTE,
            TPPESSOA,
            NRDOC,
            RAZAOSOCIAL,
            FANTASIA,
            CEP,
            LOGRADOURO,
            NUMERO,
            REFERENCIA,
            BAIRRO,
            COMPLEMENTO,
            IE,
            CONTATO,
            FONE,
            CELULAR,
            EMAIL,
            OBS,
            NRSEQLIC,
            DTLICENCA,
            MOBILE,
            QTMOBILE,
            INATIVO)VALUES(
            @P_IDCLIENTE,
            @P_IDCIDADE,
            @P_IDATIVIDADE,
            @P_IDPARCEIRO,
            @P_IDPACOTE,
            @P_TPPESSOA,
            @P_NRDOC,
            @P_RAZAOSOCIAL,
            @P_FANTASIA,
            @P_CEP,
            @P_LOGRADOURO,
            @P_NUMERO,
            @P_REFERENCIA,
            @P_BAIRRO,
            @P_COMPLEMENTO,
            @P_IE,
            @P_CONTATO,
            @P_FONE,
            @P_CELULAR,
            @P_EMAIL,
            @P_OBS,
            @P_NRSEQLIC,
            @P_DTLICENCA,
            @P_MOBILE,
            @P_QTMOBILE,
            @P_INATIVO);                        
    END
    ELSE
    BEGIN
        UPDATE TB_CLIENTE SET
            IDCIDADE = @P_IDCIDADE,
            IDATIVIDADE = @P_IDATIVIDADE,
            IDPARCEIRO = @P_IDPARCEIRO,
            IDPACOTE = @P_IDPACOTE,
            TPPESSOA = @P_TPPESSOA,
            NRDOC = @P_NRDOC,
            RAZAOSOCIAL = @P_RAZAOSOCIAL,
            FANTASIA = @P_FANTASIA,
            CEP = @P_CEP,
            LOGRADOURO = @P_LOGRADOURO,
            NUMERO = @P_NUMERO,
            REFERENCIA = @P_REFERENCIA,
            BAIRRO = @P_BAIRRO,
            COMPLEMENTO = @P_COMPLEMENTO,
            IE = @P_IE,
            CONTATO = @P_CONTATO,
            FONE = @P_FONE,
            CELULAR = @P_CELULAR,
            EMAIL = @P_EMAIL,
            OBS = @P_OBS,
            NRSEQLIC = @P_NRSEQLIC,
            DTLICENCA = @P_DTLICENCA,
            MOBILE = @P_MOBILE,
            QTMOBILE = @P_QTMOBILE,
            INATIVO = @P_INATIVO
        WHERE IDCLIENTE = @P_IDCLIENTE;    
    END                
END
go


CREATE PROCEDURE IA_CLIENTEPROCESSO(
        @P_IDCLIENTE INT,
        @P_IDPROCESSO INT,
        @P_DTINI DATETIME,
        @P_DTFIN DATETIME,
        @P_MOTIVOINATIVO VARCHAR(1024),
        @P_INATIVO BIT)WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_CLIENTEPROCESSO
                    WHERE IDCLIENTE = @P_IDCLIENTE
                    AND IDPROCESSO = @P_IDPROCESSO)
    BEGIN
        INSERT INTO TB_CLIENTEPROCESSO(
            IDCLIENTE,
            IDPROCESSO,
            DTINI,
            DTFIN,
            MOTIVOINATIVO,
            INATIVO)VALUES(
            @P_IDCLIENTE,
            @P_IDPROCESSO,
            @P_DTINI,
            @P_DTFIN,
            @P_MOTIVOINATIVO,
            @P_INATIVO);
    END
    ELSE
    BEGIN
        UPDATE TB_CLIENTEPROCESSO SET
            DTINI = @P_DTINI,
            DTFIN = @P_DTFIN,
            MOTIVOINATIVO = @P_MOTIVOINATIVO,
            INATIVO = @P_INATIVO
        WHERE IDCLIENTE = @P_IDCLIENTE
        AND IDPROCESSO = @P_IDPROCESSO;    
    END                
END
go


CREATE PROCEDURE IA_ITEMPACOTE(
        @P_IDPACOTE INT,
        @P_IDPROCESSO INT)WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_ITEMPACOTE
                    WHERE IDPACOTE = @P_IDPACOTE
                    AND IDPROCESSO = @P_IDPROCESSO)
    BEGIN
        INSERT INTO TB_ITEMPACOTE(
            IDPACOTE,
            IDPROCESSO)VALUES(
            @P_IDPACOTE,
            @P_IDPROCESSO);
    END                
END
go


CREATE PROCEDURE IA_MODULO(
        @P_IDMODULO INT OUTPUT,
        @P_DSMODULO VARCHAR(50))WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_MODULO
                    WHERE IDMODULO = @P_IDMODULO)
    BEGIN
        SET @P_IDMODULO = 1 + ISNULL((SELECT MAX(IDMODULO)
                                    FROM TB_MODULO), 0);
        INSERT INTO TB_MODULO(
            IDMODULO,
            DSMODULO)VALUES(
            @P_IDMODULO,
            @P_DSMODULO);                            
    END
    ELSE
    BEGIN
        UPDATE TB_MODULO SET
            DSMODULO = @P_DSMODULO
        WHERE IDMODULO = @P_IDMODULO;    
    END                
END
go


CREATE PROCEDURE IA_OPERADOR(
        @P_IDPARCEIRO INT,
        @P_IDOPERADOR INT OUTPUT,
        @P_LOGIN VARCHAR(20),
        @P_SENHA VARCHAR(20),
        @P_NOMEOPERADOR VARCHAR(50),
        @P_EMAIL VARCHAR(255),
        @P_INATIVO BIT)WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_OPERADOR
                    WHERE IDPARCEIRO = @P_IDPARCEIRO
                    AND IDOPERADOR = @P_IDOPERADOR)
    BEGIN
        SET @P_IDOPERADOR = 1 + ISNULL((SELECT MAX(IDOPERADOR)
                                    FROM TB_OPERADOR), 0);
        INSERT INTO TB_OPERADOR(
            IDPARCEIRO,
            IDOPERADOR,
            LOGIN,
            SENHA,
            NOMEOPERADOR,
            EMAIL,
            INATIVO)VALUES(
            @P_IDPARCEIRO,
            @P_IDOPERADOR,
            @P_LOGIN,
            @P_SENHA,
            @P_NOMEOPERADOR,
            @P_EMAIL,
            @P_INATIVO);                            
    END
    ELSE
    BEGIN
        UPDATE TB_OPERADOR SET
            LOGIN = @P_LOGIN,
            SENHA = @P_SENHA,
            NOMEOPERADOR = @P_NOMEOPERADOR,
            EMAIL = @P_EMAIL,
            INATIVO = @P_INATIVO
        WHERE IDPARCEIRO = @P_IDPARCEIRO
        AND IDOPERADOR = @P_IDOPERADOR;    
    END                
END
go


CREATE PROCEDURE IA_PACOTE(
        @P_IDPACOTE INT OUTPUT,
        @P_DSPACOTE VARCHAR(50))WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_PACOTE
                    WHERE IDPACOTE = @P_IDPACOTE)
    BEGIN
        SET @P_IDPACOTE = 1 + ISNULL((SELECT MAX(IDPACOTE)
                                        FROM TB_PACOTE), 0);
        INSERT INTO TB_PACOTE(
            IDPACOTE,
            DSPACOTE)VALUES(
            @P_IDPACOTE,
            @P_DSPACOTE)                                
    END
    ELSE
    BEGIN
        UPDATE TB_PACOTE SET
            DSPACOTE = @P_DSPACOTE
        WHERE IDPACOTE = @P_IDPACOTE;    
    END                
END
go


CREATE PROCEDURE IA_PARCEIRO(
        @P_IDPARCEIRO INT OUTPUT,
        @P_TPPESSOA CHAR(1),
        @P_NRDOC VARCHAR(18),
        @P_RAZAOSOCIAL VARCHAR(50),
        @P_FANTASIA VARCHAR(50),
        @P_CEP VARCHAR(10),
        @P_LOGRADOURO VARCHAR(50),
        @P_NUMERO VARCHAR(10),
        @P_REFERENCIA VARCHAR(50),
        @P_BAIRRO VARCHAR(30),
        @P_COMPLEMENTO VARCHAR(50),
        @P_IE VARCHAR(18),
        @P_CONTATO VARCHAR(50),
        @P_FONE VARCHAR(14),
        @P_CELULAR VARCHAR(14),
        @P_EMAIL VARCHAR(255),
        @P_FRANQUEADORA BIT,
        @P_INATIVO BIT)WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_PARCEIRO
                    WHERE IDPARCEIRO = @P_IDPARCEIRO)
    BEGIN
        SET @P_IDPARCEIRO = 1 + ISNULL((SELECT MAX(IDPARCEIRO)
                                        FROM TB_PARCEIRO), 0);
        INSERT INTO TB_PARCEIRO(
            IDPARCEIRO,
            TPPESSOA,
            NRDOC,
            RAZAOSOCIAL,
            FANTASIA,
            CEP,
            LOGRADOURO,
            NUMERO,
            REFERENCIA,
            BAIRRO,
            COMPLEMENTO,
            IE,
            CONTATO,
            FONE,
            CELULAR,
            EMAIL,
            FRANQUEADORA,
            INATIVO)VALUES(
            @P_IDPARCEIRO,
            @P_TPPESSOA,
            @P_NRDOC,
            @P_RAZAOSOCIAL,
            @P_FANTASIA,
            @P_CEP,
            @P_LOGRADOURO,
            @P_NUMERO,
            @P_REFERENCIA,
            @P_BAIRRO,
            @P_COMPLEMENTO,
            @P_IE,
            @P_CONTATO,
            @P_FONE,
            @P_CELULAR,
            @P_EMAIL,
            @P_FRANQUEADORA,
            @P_INATIVO);                           
    END
    ELSE
    BEGIN
        UPDATE TB_PARCEIRO SET
            TPPESSOA = @P_TPPESSOA,
            NRDOC = @P_NRDOC,
            RAZAOSOCIAL = @P_RAZAOSOCIAL,
            FANTASIA = @P_FANTASIA,
            CEP = @P_CEP,
            LOGRADOURO = @P_LOGRADOURO,
            NUMERO = @P_NUMERO,
            REFERENCIA = @P_REFERENCIA,
            BAIRRO = @P_BAIRRO,
            COMPLEMENTO = @P_COMPLEMENTO,
            IE = @P_IE,
            CONTATO = @P_CONTATO,
            FONE = @P_FONE,
            CELULAR = @P_CELULAR,
            EMAIL = @P_EMAIL,
            FRANQUEADORA = @P_FRANQUEADORA,
            INATIVO = @P_INATIVO
        WHERE IDPARCEIRO = @P_IDPARCEIRO;    
    END                
END
go


CREATE PROCEDURE IA_PROCESSO(
        @P_IDPROCESSO INT OUTPUT,
        @P_IDMODULO INT,
        @P_DSPROCESSO VARCHAR(50),
        @P_COMPLEMENTO VARCHAR(1024))WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_PROCESSO
                    WHERE IDPROCESSO = @P_IDPROCESSO)
    BEGIN
        SET @P_IDPROCESSO = 1 + ISNULL((SELECT MAX(IDPROCESSO)
                                FROM TB_PROCESSO), 0);
        INSERT INTO TB_PROCESSO(
            IDPROCESSO,
            IDMODULO,
            DSPROCESSO,
            COMPLEMENTO)VALUES(
            @P_IDPROCESSO,
            @P_IDMODULO,
            @P_DSPROCESSO,
            @P_COMPLEMENTO);                        
    END
    ELSE
    BEGIN
        UPDATE TB_PROCESSO SET
            IDMODULO = @P_IDMODULO,
            DSPROCESSO = @P_DSPROCESSO,
            COMPLEMENTO = @P_COMPLEMENTO
        WHERE IDPROCESSO = @P_IDPROCESSO;    
    END                
END
go


CREATE PROCEDURE IA_USUARIOCLIENTE(
        @P_IDCLIENTE INT,
        @P_IDLOGIN INT OUTPUT,
        @P_LOGIN VARCHAR(20),
        @P_SENHA VARCHAR(20),
        @P_NOMEUSUARIO VARCHAR(50),
        @P_EMAIL VARCHAR(255),
        @P_NOTIFICAEVOLUCAO BIT,
        @P_INATIVO BIT)WITH RECOMPILE
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM TB_USUARIOCLIENTE
                    WHERE IDCLIENTE = @P_IDCLIENTE
                    AND IDLOGIN = @P_IDLOGIN)
    BEGIN
        SET @P_IDLOGIN = 1 + ISNULL((SELECT MAX(IDLOGIN)
                                FROM TB_USUARIOCLIENTE), 0);
        INSERT INTO TB_USUARIOCLIENTE(
            IDCLIENTE,
            IDLOGIN,
            LOGIN,
            SENHA,
            NOMEUSUARIO,
            EMAIL,
            NOTIFICAEVOLUCAO,
            INATIVO)VALUES(
            @P_IDCLIENTE,
            @P_IDLOGIN,
            @P_LOGIN,
            @P_SENHA,
            @P_NOMEUSUARIO,
            @P_EMAIL,
            @P_NOTIFICAEVOLUCAO,
            @P_INATIVO);                        
    END
    ELSE
    BEGIN
        UPDATE TB_USUARIOCLIENTE SET
            LOGIN = @P_LOGIN,
            SENHA = @P_SENHA,
            NOMEUSUARIO = @P_NOMEUSUARIO,
            EMAIL = @P_EMAIL,
            NOTIFICAEVOLUCAO = @P_NOTIFICAEVOLUCAO,
            INATIVO = @P_INATIVO
        WHERE IDCLIENTE = @P_IDCLIENTE
        AND IDLOGIN = @P_IDLOGIN;    
    END                                    
END
go

