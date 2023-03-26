CREATE TABLE [dbo].[ChorePerson] (
    [ChoreID]  INT NOT NULL,
    [PersonID] INT NOT NULL,
    CONSTRAINT [PK_ChorePerson] PRIMARY KEY CLUSTERED ([ChoreID] ASC),
    CONSTRAINT [FK_ChorePerson_Chore] FOREIGN KEY ([ChoreID]) REFERENCES [dbo].[Chore] ([ChoreID]),
    CONSTRAINT [FK_ChorePerson_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID])
);

