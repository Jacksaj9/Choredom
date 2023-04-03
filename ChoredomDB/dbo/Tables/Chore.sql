CREATE TABLE [dbo].[Chore] (
    [ChoreID]   INT           IDENTITY (1, 1) NOT NULL,
    [ChoreName] VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_Chore] PRIMARY KEY CLUSTERED ([ChoreID] ASC)
);



