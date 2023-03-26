CREATE TABLE [dbo].[ChoreOccurence] (
    [ChoreID]     INT NOT NULL,
    [OccurenceID] INT NOT NULL,
    CONSTRAINT [PK_ChoreOccurence] PRIMARY KEY CLUSTERED ([ChoreID] ASC),
    CONSTRAINT [FK_ChoreOccurence_Chore] FOREIGN KEY ([ChoreID]) REFERENCES [dbo].[Chore] ([ChoreID]),
    CONSTRAINT [FK_ChoreOccurence_Occurence] FOREIGN KEY ([OccurenceID]) REFERENCES [dbo].[Occurence] ([OccurenceID])
);

