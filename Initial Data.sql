USE [BluesoftLibrary]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 
GO
INSERT [dbo].[Authors] ([ID], [FirstName], [LastName], [BirthDay]) VALUES (1, N'Edgar', N'Allan Poe', CAST(N'1809-01-19T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Authors] ([ID], [FirstName], [LastName], [BirthDay]) VALUES (2, N'Gabriel', N'García Marquez', CAST(N'1982-03-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Authors] ([ID], [FirstName], [LastName], [BirthDay]) VALUES (3, N'Antonio y Eduardo', N'Acín', CAST(N'1987-05-25T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([ID], [Name], [ISBN], [Category_ID], [Author_ID]) VALUES (1, N'El cuervo', N'15BF893', 3, 1)
GO
INSERT [dbo].[Books] ([ID], [Name], [ISBN], [Category_ID], [Author_ID]) VALUES (2, N'Persiguiendo a Einstein', N'258YT89', 5, 3)
GO
INSERT [dbo].[Books] ([ID], [Name], [ISBN], [Category_ID], [Author_ID]) VALUES (3, N'Cien años de soledad', N'789PS53', 4, 2)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (1, N'Novela', N'Novelas de dramaticas que cuentan historias increibles.')
GO
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (2, N'Ciencia ficción', N'Ciencia basada en la imaginación con infinitos mundos posibles')
GO
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (3, N'Terror', N'Novelas de suspenso y terror actas para el lector mas intrepido.')
GO
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (4, N'Aventura', N'Aventuras inimaginables en otros mundos.')
GO
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (5, N'Ciencia', N'Educación y ciencia para llegar a ser eruditos.')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
