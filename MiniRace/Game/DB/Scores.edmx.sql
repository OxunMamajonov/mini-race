
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/05/2017 20:48:40
-- Generated from EDMX file: C:\Users\admin\documents\visual studio 2015\Projects\MiniRace\MiniRace\Game\DB\Scores.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ScoresDBB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PlayerScore]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScoreSet] DROP CONSTRAINT [FK_PlayerScore];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PlayerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerSet];
GO
IF OBJECT_ID(N'[dbo].[ScoreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScoreSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [PlayerID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ScoreID] int  NOT NULL
);
GO

-- Creating table 'ScoreSet'
CREATE TABLE [dbo].[ScoreSet] (
    [ScoreID] int IDENTITY(1,1) NOT NULL,
    [Ammount] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [Player_PlayerID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PlayerID] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([PlayerID] ASC);
GO

-- Creating primary key on [ScoreID] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [PK_ScoreSet]
    PRIMARY KEY CLUSTERED ([ScoreID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Player_PlayerID] in table 'ScoreSet'
ALTER TABLE [dbo].[ScoreSet]
ADD CONSTRAINT [FK_PlayerScore]
    FOREIGN KEY ([Player_PlayerID])
    REFERENCES [dbo].[PlayerSet]
        ([PlayerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerScore'
CREATE INDEX [IX_FK_PlayerScore]
ON [dbo].[ScoreSet]
    ([Player_PlayerID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------