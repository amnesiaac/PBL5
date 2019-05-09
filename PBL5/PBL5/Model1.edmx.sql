
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2019 20:23:51
-- Generated from EDMX file: C:\Users\bruno\source\repos\PBL5\PBL5\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db_PBL5];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RemedioSet'
CREATE TABLE [dbo].[RemedioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Tarja] int  NOT NULL,
    [Dosagem] nvarchar(max)  NOT NULL,
    [Intervalo] nvarchar(max)  NOT NULL,
    [Comprado] bit  NOT NULL
);
GO

-- Creating table 'MedicoSet'
CREATE TABLE [dbo].[MedicoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Especialidade] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ReceitaSet'
CREATE TABLE [dbo].[ReceitaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] nvarchar(max)  NOT NULL,
    [ClinicaHospital] nvarchar(max)  NOT NULL,
    [RemedioId] int  NOT NULL,
    [MedicoId] int  NOT NULL,
    [DoençaId] int  NOT NULL
);
GO

-- Creating table 'DoençaSet'
CREATE TABLE [dbo].[DoençaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CompraRemediosSet'
CREATE TABLE [dbo].[CompraRemediosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReceitaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RemedioSet'
ALTER TABLE [dbo].[RemedioSet]
ADD CONSTRAINT [PK_RemedioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MedicoSet'
ALTER TABLE [dbo].[MedicoSet]
ADD CONSTRAINT [PK_MedicoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReceitaSet'
ALTER TABLE [dbo].[ReceitaSet]
ADD CONSTRAINT [PK_ReceitaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DoençaSet'
ALTER TABLE [dbo].[DoençaSet]
ADD CONSTRAINT [PK_DoençaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompraRemediosSet'
ALTER TABLE [dbo].[CompraRemediosSet]
ADD CONSTRAINT [PK_CompraRemediosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RemedioId] in table 'ReceitaSet'
ALTER TABLE [dbo].[ReceitaSet]
ADD CONSTRAINT [FK_RemedioReceita]
    FOREIGN KEY ([RemedioId])
    REFERENCES [dbo].[RemedioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RemedioReceita'
CREATE INDEX [IX_FK_RemedioReceita]
ON [dbo].[ReceitaSet]
    ([RemedioId]);
GO

-- Creating foreign key on [MedicoId] in table 'ReceitaSet'
ALTER TABLE [dbo].[ReceitaSet]
ADD CONSTRAINT [FK_MedicoReceita]
    FOREIGN KEY ([MedicoId])
    REFERENCES [dbo].[MedicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicoReceita'
CREATE INDEX [IX_FK_MedicoReceita]
ON [dbo].[ReceitaSet]
    ([MedicoId]);
GO

-- Creating foreign key on [DoençaId] in table 'ReceitaSet'
ALTER TABLE [dbo].[ReceitaSet]
ADD CONSTRAINT [FK_DoençaReceita]
    FOREIGN KEY ([DoençaId])
    REFERENCES [dbo].[DoençaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoençaReceita'
CREATE INDEX [IX_FK_DoençaReceita]
ON [dbo].[ReceitaSet]
    ([DoençaId]);
GO

-- Creating foreign key on [ReceitaId] in table 'CompraRemediosSet'
ALTER TABLE [dbo].[CompraRemediosSet]
ADD CONSTRAINT [FK_ReceitaCompraRemedios]
    FOREIGN KEY ([ReceitaId])
    REFERENCES [dbo].[ReceitaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReceitaCompraRemedios'
CREATE INDEX [IX_FK_ReceitaCompraRemedios]
ON [dbo].[CompraRemediosSet]
    ([ReceitaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------