CREATE TABLE [dbo].[Occurence] (
    [OccurenceID] INT          IDENTITY (1, 1) NOT NULL,
    [Occurence]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Occurence] PRIMARY KEY CLUSTERED ([OccurenceID] ASC)
);



