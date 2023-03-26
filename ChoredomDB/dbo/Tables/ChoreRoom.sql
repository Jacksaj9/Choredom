CREATE TABLE [dbo].[ChoreRoom] (
    [ChoreID] INT NOT NULL,
    [RoomID]  INT NOT NULL,
    CONSTRAINT [PK_ChoreRoom] PRIMARY KEY CLUSTERED ([ChoreID] ASC),
    CONSTRAINT [FK_ChoreRoom_Chore] FOREIGN KEY ([ChoreID]) REFERENCES [dbo].[Chore] ([ChoreID]),
    CONSTRAINT [FK_ChoreRoom_Room] FOREIGN KEY ([RoomID]) REFERENCES [dbo].[Room] ([RoomID])
);

