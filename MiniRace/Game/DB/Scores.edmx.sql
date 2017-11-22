
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2017 19:17:20
-- Generated from EDMX file: C:\Users\admin\Documents\Visual Studio 2015\Projects\MiniRace\MiniRace\Game\DB\Scores.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Records];
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

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [PlayerId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description_PlayerId] int  NOT NULL
);
GO

-- Creating table 'ScoreSet'
CREATE TABLE [dbo].[ScoreSet] (
    [PlayerId] int IDENTITY(1,1) NOT NULL,
    [Ammount] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PlayerId] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([PlayerId] ASC);
GO

-- Creating primary key on [PlayerId] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [PK_ScoreSet]
    PRIMARY KEY CLUSTERED ([PlayerId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Description_PlayerId] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [FK_PlayerDescription]
    FOREIGN KEY ([Description_PlayerId])
    REFERENCES [dbo].[ScoreSet]
        ([PlayerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerDescription'
CREATE INDEX [IX_FK_PlayerDescription]
ON [dbo].[PlayerSet]
    ([Description_PlayerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------