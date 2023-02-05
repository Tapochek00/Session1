USE [master]
GO
/****** Object:  Database [Session1]    Script Date: 05.02.2023 19:08:28 ******/
CREATE DATABASE [Session1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Session1', FILENAME = N'C:\Users\АВС\Session1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Session1_log', FILENAME = N'C:\Users\АВС\Session1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Session1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Session1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Session1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Session1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Session1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Session1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Session1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Session1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Session1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Session1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Session1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Session1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Session1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Session1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Session1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Session1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Session1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Session1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Session1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Session1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Session1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Session1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Session1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Session1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Session1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Session1] SET  MULTI_USER 
GO
ALTER DATABASE [Session1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Session1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Session1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Session1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Session1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Session1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Session1] SET QUERY_STORE = OFF
GO
USE [Session1]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 05.02.2023 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Phone] [nvarchar](11) NULL,
	[email] [nvarchar](20) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demands]    Script Date: 05.02.2023 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demands](
	[id] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[ObjectType] [nvarchar](20) NOT NULL,
	[Address_City] [nvarchar](20) NULL,
	[Address_Street] [nvarchar](20) NULL,
	[Address_House] [nvarchar](20) NULL,
	[Address_Number] [nvarchar](20) NULL,
	[MinPrice] [int] NULL,
	[MaxPrice] [int] NULL,
	[MinArea] [float] NULL,
	[MaxArea] [float] NULL,
	[MinRooms] [int] NULL,
	[MaxRooms] [int] NULL,
	[MinFloor] [int] NULL,
	[MaxFloor] [int] NULL,
 CONSTRAINT [PK_Demands] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RealEstateObjects]    Script Date: 05.02.2023 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RealEstateObjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address_City] [nvarchar](20) NULL,
	[Address_Street] [nvarchar](20) NULL,
	[Address_House] [nvarchar](20) NULL,
	[Address_Number] [nvarchar](20) NULL,
	[Coordinate_latitude] [float] NULL,
	[Coordinate_longitude] [float] NULL,
	[TotalArea] [float] NULL,
	[Rooms] [int] NULL,
	[Floor] [int] NULL,
	[TotalFloors] [int] NULL,
	[ObjectType] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_RealEstateObjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Realtor]    Script Date: 05.02.2023 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Realtor](
	[Id] [int] NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[DealShare] [float] NULL,
 CONSTRAINT [PK_Realtor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[supplies]    Script Date: 05.02.2023 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[AgentId] [int] NOT NULL,
	[RealEstateId] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_supplies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (2, N'Семенов', N'Евгений ', N'Николаевич', N'32-25-55', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (3, N'Денисова', N'Олеся', N'Леонидовна', NULL, N'dummy@email.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (5, N'Сафронов', N'Алексей', N'Вячеславович', NULL, N'client@esoft.tech')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (6, N'Кудряшов', N'Александр', N'Витальевич', N'551988', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (8, N'Фёдоров', N'Алексей', N'Николаевич', NULL, N'fedorov@mail.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (10, N'Пелымская', N'Светлана', N'Александровна', N'83452112233', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (12, N'Коновальчик', N'Татьяна', N'Геннадьевна', NULL, N'dummy@email.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (14, N'Молоковская', N'Светлана', N'Михайловна', N'898489848', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (16, N'Моторина', N'Анастасия', N'Сергеевна', N'895159848', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (17, N'Поспелова', N'Ольга', N'Александровна', NULL, N'angel@mail.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (18, N'Жиляков', N'Владимир', N'Владимирович', N'445588', N'445588@email.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (20, N'Ефремов', N'Владислав', N'Николаевич', NULL, N'parampampam@mail.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (21, N'Баль', N'Валентина', N'Сергеевна', N'7998888444', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (22, N'Стрелков', N'Артем', N'Николаевич', NULL, N'test@test.test')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (23, N'Луканин', N'Павел', N'Валерьевич', NULL, N'foo@bar.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (25, N'Шарипова', N'Эльвира', N'Закирчановна', N'12345678910', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (26, N'Фомина', N'Маргарита', N'Николаевна', NULL, N'fomina@email.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (27, N'Кремлев', N'Владислав', N'Юрьевич', N'777', N'kremlevvu@gmail.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (28, N'Пономарева', N'Елена', N'Сергеевна', NULL, N'ponomareva@gmail.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (29, N'Шелест', N'Тамара', N'Васильевна', N'112', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (30, N'Шарипов', N'Рустам', N'Владимирович', NULL, N'sharipov@yandex.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (31, N'Романов', N'Сергей', N'Федорович', N'2', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (32, N'Кручинин', N'Иван', N'Андреевич', NULL, N'kruch@list.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (33, N'Алферов', N'Алексей', N'Николаевич', N'688899444', NULL)
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (35, N'Попов ', N'Алексей', N'Николаевич', N'489848565', N'popovan@bik.ru')
INSERT [dbo].[Client] ([Id], [LastName], [FirstName], [Patronymic], [Phone], [email]) VALUES (36, N'Неезжала', N'Наталья', N'Леонидовна', NULL, N'neez@mail.ru')
GO
SET IDENTITY_INSERT [dbo].[RealEstateObjects] ON 

INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (1, N'Тюмень
', N'Энергостроителей
', N'25
', N'12', 0, 0, 41.7, 1, 3, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (2, N'Тюмень
', N'Елизарова', N'8
', N'44', 0, 0, 105, 3, 5, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (3, N'Тюмень
', N'Московский тракт
', N'139
', N'6', 0, 0, 62, 3, 2, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (4, N'Тюмень
', N'Широтная', N'189
', N'5', 0, 0, 50, 2, 7, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (5, N'Тюмень
', N'Пролетарская
', N'110
', N'99', 0, 0, 51.7, 2, 2, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (6, N'Тюмень
', N'Тараскульская
', N'189', N'1', 0, 0, 44, 2, 1, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (7, N'Тюмень
', N'Парфенова
', N'22
', N'1', 0, 0, 43.1, 1, 5, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (8, N'Тюмень
', N'Республики
', N'144
', N'16', 0, 0, 92, 3, 1, NULL, N'Квартира
')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (9, N'Тюмень
', N'1-й Заречный
', N'25', NULL, 0, 0, 84.4, NULL, NULL, 2, N'Дом')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (10, N'Тюмень
', N'Ялyтopoвcкий тpaкт
', NULL, NULL, 0, 0, 130, NULL, NULL, 3, N'Дом')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (11, N'Тюмень
', N'Березняковский п
', NULL, NULL, 0, 0, 120, NULL, NULL, 1, N'Дом')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (12, N'Тюмень
', N'Луговое
', NULL, NULL, 0, 0, 20.3, NULL, NULL, NULL, N'Земля')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (13, N'Тюмень
', N'Алексеевский хутор
', NULL, NULL, 0, 0, 12.45, NULL, NULL, NULL, N'Земля')
INSERT [dbo].[RealEstateObjects] ([Id], [Address_City], [Address_Street], [Address_House], [Address_Number], [Coordinate_latitude], [Coordinate_longitude], [TotalArea], [Rooms], [Floor], [TotalFloors], [ObjectType]) VALUES (14, N'Тюмень
', N'Суходольский мкр
', NULL, NULL, 0, 0, 12, NULL, NULL, NULL, N'Земля')
SET IDENTITY_INSERT [dbo].[RealEstateObjects] OFF
GO
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (1, N'Фахрутдинов', N'Роман', N'Рубинович', 20)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (4, N'Устинов', N'Максим', N'Алексеевич', 40)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (7, N'Сысоева', N'Людмила', N'Валентиновна', 45)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (9, N'Додонов', N'Илья', N'Геннадьевич', 45)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (11, N'Мухтаруллин', N'Руслан', N'Расыхович', 45)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (13, N'Мосеева', N'Любовь', N'Александровна', 45)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (15, N'Киселев', N'Алексей', N'Геннадьевич', 45)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (19, N'Клюйков', N'Евгений', N'Николаевич', 50)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (24, N'Жданова', N'Галина', N'Николаевна', 45)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (34, N'Басырова', N'Елена', N'Азатовна', 45)
INSERT [dbo].[Realtor] ([Id], [LastName], [FirstName], [Patronymic], [DealShare]) VALUES (37, N'Швецов', N'Виталий', N'Олегович', 45)
GO
USE [master]
GO
ALTER DATABASE [Session1] SET  READ_WRITE 
GO
