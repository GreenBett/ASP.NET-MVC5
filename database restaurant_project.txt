CREATE TABLE [dbo].[Serveur] (
    [id_serveur] INT            IDENTITY (1, 1) NOT NULL,
    [nom]        NVARCHAR (100) NOT NULL,
    [login]      NVARCHAR (100) NOT NULL,
    [password]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_serveur] ASC)
);
CREATE TABLE [dbo].[Tables] (
    [Id_table]      INT            IDENTITY (1, 1) NOT NULL,
    [Etat_table]    NVARCHAR (100) NULL,
    [Etat_commande] NVARCHAR (100) NULL,
    [id_serveur]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id_table] ASC),
    CONSTRAINT [FK1] FOREIGN KEY ([id_serveur]) REFERENCES [dbo].[Serveur] ([id_serveur])
);
CREATE TABLE [dbo].[Plats] (
    [Idplat]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [IsSelected] BIT            NOT NULL,
    [Prix]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Idplat] ASC)
);
CREATE TABLE [dbo].[Commandes] (
    [id_commande] INT            IDENTITY (1, 1) NOT NULL,
    [Idplat]      INT            NULL,
    [QTT]         INT            NULL,
    [etat_plat]   NVARCHAR (100) NULL,
    [etat_comm]   NVARCHAR (100) NULL,
    [Id_table]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id_commande] ASC),
    CONSTRAINT [fk2] FOREIGN KEY ([Idplat]) REFERENCES [dbo].[Plats] ([Idplat]),
    CONSTRAINT [fk3] FOREIGN KEY ([Id_table]) REFERENCES [dbo].[Tables] ([Id_table])
);
CREATE TABLE [dbo].[TotalCommandes] (
    [Id]           INT   IDENTITY (1, 1) NOT NULL,
    [Num_commande] INT   NULL,
    [Jours]        DATE  NULL,
    [Num_table]    INT   NULL,
    [Prix]         MONEY NULL,
    [id_serveur]   INT   NULL,
    [gain_serveur] MONEY NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk4] FOREIGN KEY ([Num_table]) REFERENCES [dbo].[Tables] ([Id_table]),
    CONSTRAINT [fk5] FOREIGN KEY ([id_serveur]) REFERENCES [dbo].[Serveur] ([id_serveur])
);

SET IDENTITY_INSERT [dbo].[Serveur] ON
INSERT INTO [dbo].[Serveur] ([id_serveur], [nom], [login], [password]) VALUES (1, N'majdouline', N'majdouline', N'123')
INSERT INTO [dbo].[Serveur] ([id_serveur], [nom], [login], [password]) VALUES (2, N'chaimae', N'chaimae', N'123')
SET IDENTITY_INSERT [dbo].[Serveur] OFF

SET IDENTITY_INSERT [dbo].[Tables] ON
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (1, N'pleine', N'encours', 1)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (2, N'vide', N'---', 1)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (3, N'vide', N'---', 1)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (4, N'vide', N'---', 1)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (5, N'vide', N'---', 1)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (6, N'vide', N'---', 2)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (7, N'vide', N'---', 2)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (8, N'vide', N'---', 2)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (9, N'vide', N'---', 2)
INSERT INTO [dbo].[Tables] ([Id_table], [Etat_table], [Etat_commande], [id_serveur]) VALUES (10, N'vide', N'---', 2)
SET IDENTITY_INSERT [dbo].[Tables] OFF


SET IDENTITY_INSERT [dbo].[Plats] ON
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (1, N'Cheeseburger Fries', 0, 25)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (2, N'Chorizo Flats', 0, 20)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (3, N'Ultimate Nachos', 0, 25)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (4, N'Honey Mustard Chicken Crunch', 0, 15)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (5, N'Southwest Avocado', 0, 15)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (6, N'Grilled Chicken', 0, 40)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (7, N'Crispy Chicken', 0, 45)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (9, N'Garden Salad', 0, 10)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (11, N'French Fries', 0, 10)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (12, N'Orange Juice', 0, 13)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (14, N'Apple Juice', 0, 15)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (15, N'Milk', 0, 10)
INSERT INTO [dbo].[Plats] ([Idplat], [Name], [IsSelected], [Prix]) VALUES (16, N'Diet Coke', 0, 12)
SET IDENTITY_INSERT [dbo].[Plats] OFF
