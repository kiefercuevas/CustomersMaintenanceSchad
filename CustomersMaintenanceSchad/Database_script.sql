USE [Test_Invoice]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1/20/2023 1:56:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustName] [nvarchar](70) NOT NULL,
	[Address] [nvarchar](120) NOT NULL,
	[Status] [bit] NOT NULL,
	[CustomerTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerTypes]    Script Date: 1/20/2023 1:56:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 1/20/2023 1:56:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalItbis] [money] NOT NULL,
	[SubTotal] [money] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 1/20/2023 1:56:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[TotalItbis] [money] NOT NULL,
	[SubTotal] [money] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([Id], [CustName], [Address], [Status], [CustomerTypeId]) VALUES (1, N'Emilio', N'Calle #3 esq. 17 Villa Faro', 1, 1)
GO
INSERT [dbo].[Customers] ([Id], [CustName], [Address], [Status], [CustomerTypeId]) VALUES (2, N'Pedro', N'Calle 21 #8', 0, 3)
GO
INSERT [dbo].[Customers] ([Id], [CustName], [Address], [Status], [CustomerTypeId]) VALUES (3, N'Prueba2', N'Calle 14 #287', 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerTypes] ON 
GO
INSERT [dbo].[CustomerTypes] ([Id], [Description]) VALUES (1, N'PLATINO')
GO
INSERT [dbo].[CustomerTypes] ([Id], [Description]) VALUES (2, N'ORO')
GO
INSERT [dbo].[CustomerTypes] ([Id], [Description]) VALUES (3, N'BRONCE')
GO
SET IDENTITY_INSERT [dbo].[CustomerTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 
GO
INSERT [dbo].[Invoice] ([Id], [CustomerId], [TotalItbis], [SubTotal], [Total]) VALUES (9, 1, 47.5200, 264.0000, 311.5200)
GO
INSERT [dbo].[Invoice] ([Id], [CustomerId], [TotalItbis], [SubTotal], [Total]) VALUES (10, 1, 2736.0000, 15200.0000, 17936.0000)
GO
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetail] ON 
GO
INSERT [dbo].[InvoiceDetail] ([Id], [InvoiceId], [Qty], [Price], [TotalItbis], [SubTotal], [Total]) VALUES (5, 9, 12, 22.0000, 47.5200, 264.0000, 311.5200)
GO
INSERT [dbo].[InvoiceDetail] ([Id], [InvoiceId], [Qty], [Price], [TotalItbis], [SubTotal], [Total]) VALUES (6, 10, 10, 200.0000, 360.0000, 2000.0000, 2360.0000)
GO
INSERT [dbo].[InvoiceDetail] ([Id], [InvoiceId], [Qty], [Price], [TotalItbis], [SubTotal], [Total]) VALUES (7, 10, 10, 500.0000, 900.0000, 5000.0000, 5900.0000)
GO
INSERT [dbo].[InvoiceDetail] ([Id], [InvoiceId], [Qty], [Price], [TotalItbis], [SubTotal], [Total]) VALUES (8, 10, 5, 120.0000, 108.0000, 600.0000, 708.0000)
GO
INSERT [dbo].[InvoiceDetail] ([Id], [InvoiceId], [Qty], [Price], [TotalItbis], [SubTotal], [Total]) VALUES (9, 10, 20, 300.0000, 1080.0000, 6000.0000, 7080.0000)
GO
INSERT [dbo].[InvoiceDetail] ([Id], [InvoiceId], [Qty], [Price], [TotalItbis], [SubTotal], [Total]) VALUES (10, 10, 10, 25.0000, 45.0000, 250.0000, 295.0000)
GO
INSERT [dbo].[InvoiceDetail] ([Id], [InvoiceId], [Qty], [Price], [TotalItbis], [SubTotal], [Total]) VALUES (11, 10, 10, 135.0000, 243.0000, 1350.0000, 1593.0000)
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetail] OFF
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_CustomerType]  DEFAULT ((1)) FOR [CustomerTypeId]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_TotalItbis]  DEFAULT ((0)) FOR [TotalItbis]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [DF_InvoiceDetail_TotalItbis1]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [DF_InvoiceDetail_TotalItbis]  DEFAULT ((0)) FOR [TotalItbis]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerTypes] FOREIGN KEY([CustomerTypeId])
REFERENCES [dbo].[CustomerTypes] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerTypes]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customers]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoice]
GO
