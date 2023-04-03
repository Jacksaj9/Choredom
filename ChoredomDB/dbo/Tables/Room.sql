CREATE TABLE [dbo].[Room] (
    [RoomID]   INT           IDENTITY (1, 1) NOT NULL,
    [RoomName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED ([RoomID] ASC)
);



