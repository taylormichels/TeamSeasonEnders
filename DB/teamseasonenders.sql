USE [TeamSeasonEnders]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 05/09/2016 16:52:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NULL,
	[Division] [varchar](50) NULL,
	[Conference] [varchar](50) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (1, N'Bruins', N'Boston', N'MA', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (2, N'Sabres', N'Buffalo', N'NY', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (3, N'Red Wings', N'Detroit', N'MI', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (5, N'Panthers', N'Sunrise', N'FL', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (6, N'Canadiens', N'Montreal', N'QC', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (7, N'Senators', N'Ottawa', N'ON', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (8, N'Lightning', N'Tampa', N'FL', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (9, N'Maple Leafs', N'Toronto', N'ON', N'Atlantic', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (10, N'Hurricanes', N'Carolina', N'NC', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (11, N'Blue Jackets', N'Columbus', N'OH', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (12, N'Devils', N'Newark', N'NJ', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (13, N'Islanders', N'New York', N'NY', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (14, N'Rangers', N'New York', N'NY', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (15, N'Flyers', N'Philadelphia', N'PA', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (16, N'Penguins', N'Pittsburg', N'PA', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (17, N'Capitals', N'Washington', N'DC', N'Metropolitan', N'Eastern')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (18, N'Ducks', N'Anaheim', N'CA', N'Pacific', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (19, N'Coyotes', N'Glendale', N'AZ', N'Pacific', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (20, N'Flames', N'Calgary', N'AB', N'Pacific', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (21, N'Oilers', N'Edmonton', N'AB', N'Pacific', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (22, N'Kings', N'Los Angeles', N'CA', N'Pacific', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (23, N'Sharks', N'San Jose', N'CA', N'Pacific', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (24, N'Canucks', N'Vancouver', N'BC', N'Pacific', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (25, N'Blackhawks', N'Chicago', N'IL', N'Central', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (27, N'Avalanche', N'Denver', N'CO', N'Central', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (28, N'Stars', N'Dallas', N'TX', N'Central', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (29, N'Wild', N'St Paul', N'MN', N'Central', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (30, N'Predators', N'Nashville', N'TN', N'Central', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (31, N'Blues', N'St. Louis', N'MO', N'Central', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (32, N'Jets', N'Winnipeg', N'MB', N'Central', N'Western')
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (34, N'Maroons', N'Montreal', N'QC', NULL, NULL)
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (35, N'Whalers', N'Hartford', N'CT', NULL, NULL)
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (36, N'Americans', N'New York', N'NY', NULL, NULL)
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (37, N'Wanderers', N'Montreal', N'QC', NULL, NULL)
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (38, N'Nordiques', N'Quebec', N'CA', NULL, NULL)
INSERT [dbo].[Team] ([Id], [Name], [City], [State], [Division], [Conference]) VALUES (39, N'Thrashers', N'Atlanta', N'GA', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Team] OFF
/****** Object:  Table [dbo].[PlayoffResult]    Script Date: 05/09/2016 16:52:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlayoffResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[OpponentId] [int] NOT NULL,
	[Round] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[GameCount] [int] NULL,
	[GamesWon] [int] NOT NULL,
	[GamesLost] [int] NOT NULL,
 CONSTRAINT [PK_PlayoffResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PlayoffResult] ON
INSERT [dbo].[PlayoffResult] ([Id], [TeamId], [OpponentId], [Round], [Year], [GameCount], [GamesWon], [GamesLost]) VALUES (2, 14, 1, N'2', 2013, NULL, 1, 4)
INSERT [dbo].[PlayoffResult] ([Id], [TeamId], [OpponentId], [Round], [Year], [GameCount], [GamesWon], [GamesLost]) VALUES (3, 14, 1, N'1', 1973, NULL, 4, 1)
INSERT [dbo].[PlayoffResult] ([Id], [TeamId], [OpponentId], [Round], [Year], [GameCount], [GamesWon], [GamesLost]) VALUES (4, 14, 1, N'4', 1972, NULL, 2, 4)
SET IDENTITY_INSERT [dbo].[PlayoffResult] OFF
/****** Object:  ForeignKey [FK_PlayoffResult_Opponent]    Script Date: 05/09/2016 16:52:27 ******/
ALTER TABLE [dbo].[PlayoffResult]  WITH CHECK ADD  CONSTRAINT [FK_PlayoffResult_Opponent] FOREIGN KEY([OpponentId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[PlayoffResult] CHECK CONSTRAINT [FK_PlayoffResult_Opponent]
GO
/****** Object:  ForeignKey [FK_PlayoffResult_Team]    Script Date: 05/09/2016 16:52:27 ******/
ALTER TABLE [dbo].[PlayoffResult]  WITH CHECK ADD  CONSTRAINT [FK_PlayoffResult_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[PlayoffResult] CHECK CONSTRAINT [FK_PlayoffResult_Team]
GO
