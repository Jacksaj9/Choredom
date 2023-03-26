CREATE TABLE [dbo].[Person] (
    [PersonID]    INT           NOT NULL,
    [FirstName]   VARCHAR (150) NOT NULL,
    [LastName]    VARCHAR (150) NOT NULL,
    [PersonBio]   VARCHAR (300) NULL,
    [PersonImage] VARCHAR (150) NULL,
    [ChoreList]   VARCHAR (150) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonID] ASC)
);

