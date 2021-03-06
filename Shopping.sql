create database [Shopping]
USE [Shopping]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cart](
	[id_cart] [varchar](50) NOT NULL,
	[id_user] [varchar](50) NOT NULL,
	[name_product] [nvarchar](50) NOT NULL,
	[price_product] [nvarchar](50) NOT NULL,
	[count] [int] NOT NULL,
	[image] [varchar](max) NOT NULL,
	[id_product] [nvarchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[id_category] [nvarchar](50) PRIMARY KEY NOT NULL ,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[id_comment] [nvarchar](50) PRIMARY KEY NOT NULL,
	[id_product] [nvarchar](50) NOT NULL,
	[comment] [nvarchar](max) NOT NULL,
	[star] [int] NOT NULL,
	[id_user] [nvarchar](50) NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,

	CONSTRAINT [FK_Comment_Product] FOREIGN KEY ([id_product]) REFERENCES [dbo].[Product]([id_product]) ON DELETE CASCADE,
	CONSTRAINT [FK_Comment_User] FOREIGN KEY ([id_user]) REFERENCES [dbo].[User]([id_user]) ON DELETE CASCADE

) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[id_delivery] [nvarchar](50) NOT NULL,
	[id_history] [nvarchar](50) NOT NULL,
	[address_from] [nvarchar](max) NOT NULL,
	[address_to] [nvarchar](max) NOT NULL,
	[distance] [nvarchar](50) NOT NULL,
	[duration] [nvarchar](50) NOT NULL,
	[price] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[id_delivery] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detail_Order]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_Order](
	[id_detail_history] [nvarchar](50) PRIMARY KEY NOT NULL,
	[id_history] [nvarchar](50) NOT NULL,
	[name_product] [nvarchar](50) NOT NULL,
	[price_product] [nvarchar](50) NOT NULL,
	[count] [int] NOT NULL,
	[image] [nvarchar](max) NOT NULL,
	[id_product] [nvarchar](50) NULL,

	CONSTRAINT [FK_Detail_Order_Product] FOREIGN KEY ([id_product]) REFERENCES [dbo].[Product]([id_product]) ON DELETE SET NULL,
	CONSTRAINT [FK_Detail_Order_Order] FOREIGN KEY ([id_history]) REFERENCES [dbo].[Order]([id_history]) ON DELETE CASCADE

) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Note]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[id_note] [nvarchar](50) PRIMARY KEY NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id_history] [nvarchar](50) PRIMARY KEY NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[total] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[pay] [bit] NOT NULL,
	[feeship] [int] NOT NULL,
	[id_user] [nvarchar](50) NULL,
	[id_payment] [nvarchar](50) NULL,
	[id_note] [nvarchar](50) NULL,

    CONSTRAINT [FK_Order_Payment] FOREIGN KEY ([id_payment]) REFERENCES [dbo].[Payment]([id_payment]) ON DELETE SET NULL,
	CONSTRAINT [FK_Order_User] FOREIGN KEY ([id_user]) REFERENCES [dbo].[User]([id_user]) ON DELETE SET NULL,
	CONSTRAINT [FK_Order_Note] FOREIGN KEY ([id_note]) REFERENCES [dbo].[Note]([id_note]) ON DELETE SET NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id_payment] [nvarchar](50) PRIMARY KEY NOT NULL,
	[pay_category] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permission]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[id_permission] [nvarchar](50) PRIMARY KEY NOT NULL,
	[permission] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id_product] [nvarchar](50) NOT NULL,
	[id_category] [nvarchar](50) NULL,
	[name_product] [nvarchar](100) NOT NULL,
	[price_product] [nvarchar](50) NOT NULL,
	[image] [nvarchar](max) NOT NULL,
	[describe] [nvarchar](max) NOT NULL

	PRIMARY KEY CLUSTERED ([id_product]),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([id_category]) REFERENCES [dbo].[Category]([id_category]) ON DELETE SET NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 5/10/2021 2:55:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [nvarchar](50) PRIMARY KEY NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[id_permission] [nvarchar](50) NULL,

    CONSTRAINT [FK_User_Permission] FOREIGN KEY ([id_permission]) REFERENCES [dbo].[Permission]([id_permission]) ON DELETE SET NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Category] ([id_category], [name]) VALUES (N'category_1', N'GÀ GIÒN VUI VẺ')
INSERT [dbo].[Category] ([id_category], [name]) VALUES (N'category_2', N'GÀ SỐT CAY')
INSERT [dbo].[Category] ([id_category], [name]) VALUES (N'category_3', N'MÌ Ý SỐT BÒ HẦM')
INSERT [dbo].[Category] ([id_category], [name]) VALUES (N'category_4', N'BURGER & COM')
INSERT [dbo].[Category] ([id_category], [name]) VALUES (N'category_5', N'PHẦN ĂN THÊM')
INSERT [dbo].[Category] ([id_category], [name]) VALUES (N'category_6', N'MÓN TRÁNG MIẾNG')
INSERT [dbo].[Comment] ([id_comment], [id_product], [comment], [star], [id_user], [fullname]) VALUES (N'0.6219960257342678', N'product_4', N'Ngon quá', 4, N'0.8402404073486265', N'Nguyen Kim Tien')
INSERT [dbo].[Comment] ([id_comment], [id_product], [comment], [star], [id_user], [fullname]) VALUES (N'0.7766625307927313', N'product_42', N'Sản phẩm chất lương', 5, N'0.8402404073486265', N'Nguyen Kim Tien')
INSERT [dbo].[Delivery] ([id_delivery], [id_history], [address_from], [address_to], [distance], [duration], [price]) VALUES (N'0.800100434512308', N'0.08804157026981341', N'155 Sư Vạn Hạnh, Phường 13, District 10, Ho Chi Minh City, Vietnam', N'364 Điện Biên Phủ, District 3, Ho Chi Minh City, Vietnam', N'2.18 Km', N'8 mins', N'5')
INSERT [dbo].[Detail_Order] ([id_detail_history], [id_history], [name_product], [price_product], [count], [image], [id_product]) VALUES (N'CT0.04083184364426429', N'0.7369608497057472', N'SANDWICH THỊT NƯỚNG BBQ', N'10', 1, N'https://jollibee.com.vn/uploads/dish/20522844a2900d-1830004_sandwichesbbq.png', N'product_42')
INSERT [dbo].[Detail_Order] ([id_detail_history], [id_history], [name_product], [price_product], [count], [image], [id_product]) VALUES (N'CT0.23654225333192014', N'0.4167923872717778', N'CƠM GÀ GIÒN + SÚP BÍ ĐỎ + NƯỚC NGỌT', N'11', 1, N'https://jollibee.com.vn/uploads/dish/091277ef7fe806-hinhghep22.png', N'product_8')
INSERT [dbo].[Detail_Order] ([id_detail_history], [id_history], [name_product], [price_product], [count], [image], [id_product]) VALUES (N'CT0.43694811089432783', N'0.4167923872717778', N'2 MIẾNG GÀ SỐT CAY', N'13', 2, N'https://jollibee.com.vn/uploads/dish/0ea5c976da5a4a-2minggsgstcay.png', N'product_5                     ')
INSERT [dbo].[Detail_Order] ([id_detail_history], [id_history], [name_product], [price_product], [count], [image], [id_product]) VALUES (N'CT0.9231029610702466', N'0.7369608497057472', N'SANDWICH GÀ GIÒN + NƯỚC NGỌT', N'5', 1, N'https://jollibee.com.vn/uploads/dish/f0509916cba46a-2860002_sandwichga01pepsi.png', N'product_28')
INSERT [dbo].[Note] ([id_note], [fullname], [phone]) VALUES (N'0.6978846237561849', N'Nguyen Kim Tien', N'0763557366')
INSERT [dbo].[Note] ([id_note], [fullname], [phone]) VALUES (N'0.4307055662757453', N'Nguyen Kim Tien', N'0763557366')
INSERT [dbo].[Order] ([id_history], [address], [total], [status], [pay], [feeship], [id_user], [id_payment], [id_note]) VALUES (N'0.4167923872717778', N'299 Phan Huy Ích, Gò Vấp, Ho Chi Minh City, Vietnam', N'52', N'1', 1, 15, N'0.8402404073486265', N'60635313a1ba573dc01656b5', N'0.4307055662757453')
INSERT [dbo].[Order] ([id_history], [address], [total], [status], [pay], [feeship], [id_user], [id_payment], [id_note]) VALUES (N'0.7369608497057472', N'364 Điện Biên Phủ, District 3, Ho Chi Minh City, Vietnam', N'20', N'1', 0, 5, N'0.8402404073486265', N'60635313a1ba573dc01656b6', N'0.6978846237561849')
INSERT [dbo].[Payment] ([id_payment], [pay_category]) VALUES (N'60635313a1ba573dc01656b6', N'Thanh Toán Trực Tiếp')
INSERT [dbo].[Payment] ([id_payment], [pay_category]) VALUES (N'60635313a1ba573dc01656b5', N'PayPal')
INSERT [dbo].[Permission] ([id_permission], [permission]) VALUES (N'0.4856544654', N'Nhân Viên')
INSERT [dbo].[Permission] ([id_permission], [permission]) VALUES (N'0.4857534654', N'Admin')
INSERT [dbo].[Permission] ([id_permission], [permission]) VALUES (N'0.4859514654', N'Khách Hàng')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_1', N'category_1', N'2 MIẾNG GÀ GIÒN', N'8', N'https://jollibee.com.vn/uploads/dish/d1834d87116836-2mingggin.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_2', N'category_1', N'4 MIẾNG GÀ GIÒN', N'10', N'https://jollibee.com.vn/uploads/dish/427e7a3136f84a-4mingggin.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_3', N'category_1', N'6 MIẾNG GÀ GIÒN', N'15', N'https://jollibee.com.vn/uploads/dish/ee8e7512368728-6mingggin.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_4', N'category_2', N'1 MIẾNG GÀ SỐT CAY + COM', N'11', N'https://jollibee.com.vn/uploads/dish/38b2b63ad78a31-1gstcaycm.jpg', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_5', N'category_2', N'2 MIẾNG GÀ SỐT CAY', N'13', N'https://jollibee.com.vn/uploads/dish/0ea5c976da5a4a-2minggsgstcay.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_6', N'category_1', N'CƠM GÀ GIÒN', N'10', N'https://jollibee.com.vn/uploads/dish/6d2e290195e851-cmggin.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_7', N'category_1', N'2 MIẾNG GÀ GIÒN + KHOAI TÂY VỪA + NƯỚC NGỌT', N'12', N'https://jollibee.com.vn/uploads/dish/d07da082f7ebc7-2810016_02miengcj01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_8', N'category_1', N'CƠM GÀ GIÒN + SÚP BÍ ĐỎ + NƯỚC NGỌT', N'11', N'https://jollibee.com.vn/uploads/dish/091277ef7fe806-hinhghep22.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_9', N'category_1', N'C4 - CƠM GÀ GIÒN + NƯỚC NGỌT', N'9', N'https://jollibee.com.vn/uploads/dish/0ade732c6f5968-2810014_comga01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_10', N'category_1', N'C3 - 1 MIẾNG GÀ GIÒN + KHOAI TÂY VỪA + NƯỚC NGỌT', N'10', N'https://jollibee.com.vn/uploads/dish/18d46e3c3c7c3f-2810004_01miengcj01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_11', N'category_1', N'1 MIẾNG GÀ GIÒN', N'5', N'https://jollibee.com.vn/uploads/dish/3e4f6705b1d1ed-1810001_01miengcj1.jpg', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_12', N'category_2', N'2 MIẾNG GÀ SỐT CAY + KHOAI TÂY + NƯỚC', N'13', N'https://jollibee.com.vn/uploads/dish/1be860c93c1cbf-2810053_02cc01reg01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_13', N'category_2', N'1 MIẾNG GÀ SỐT CAY + CƠM + NƯỚC', N'9', N'https://jollibee.com.vn/uploads/dish/28719893e508b2-2810050_01comgacc01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_14', N'category_2', N'1 MIẾNG GÀ SỐT CAY + CƠM + NƯỚC + SÚP', N'9', N'https://jollibee.com.vn/uploads/dish/b827535750c3e4-hinhghep07.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_15', N'category_2', N'1 MIẾNG GÀ SỐT CAY + KHOAI TÂY + NƯỚC', N'9', N'https://jollibee.com.vn/uploads/dish/a80f1c062be676-2810052_01cc01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_16', N'category_2', N'1 MIẾNG GÀ SÀI GÒN SỐT CAY', N'8', N'https://jollibee.com.vn/uploads/dish/cc6e01cdf7b86b-1810036_01miengcc.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_17', N'category_3', N'01 MIẾNG GÀ GIÒN VUI VẺ + 01 MỲ Ý SỐT BÒ BẰM', N'10', N'https://jollibee.com.vn/uploads/dish/8f78c6810be7e1-2840004_jedscombo65kcompressor.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_18', N'category_3', N'MÌ Ý SỐT BÒ BẰM LỚN + 2 MIẾNG GÀ KHÔNG XƯƠNG + KHOAI TÂY VỪA + NƯỚC NGỌT', N'12', N'https://jollibee.com.vn/uploads/dish/5a5b876853153a-2840023_01myylon02gakoxuong01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_19', N'category_3', N'MÌ Ý SỐT BÒ BẰM LỚN + 2 MIẾNG GÀ KHÔNG XƯƠNG + NƯỚC NGỌT', N'10', N'https://jollibee.com.vn/uploads/dish/fc52c6aab9fdc7-2840021_01myylon02gakoxuong01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_41', N'category_4', N'SANDWICH GÀ GIÒN', N'8', N'https://jollibee.com.vn/uploads/dish/92d27d47dadbfc-hambugerlon.jpg', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_42', N'category_4', N'SANDWICH THỊT NƯỚNG BBQ', N'10', N'https://jollibee.com.vn/uploads/dish/20522844a2900d-1830004_sandwichesbbq.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_37', N'category_5', N'7 KHOANH MỰC ỐNG CHIÊN GIÒN', N'7', N'https://jollibee.com.vn/uploads/dish/744ebde303c3d1-2mienggaran20.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_38', N'category_5', N'KHOAI TÂY LẮC VỊ BƠ MẬT ONG (LỚN)', N'8', N'https://jollibee.com.vn/uploads/dish/e3b5c6e82578c2-2mienggaran21.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_39', N'category_6', N'KEM SÔCÔLA (CÚP)', N'5', N'https://jollibee.com.vn/uploads/dish/c400652c2a03e0-chocolateicecream01.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_40', N'category_6', N'KEM SỮA TƯƠI (CÚP)', N'5', N'https://jollibee.com.vn/uploads/dish/ba9d396f70568c-kemvani201.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_20', N'category_3', N'MÌ Ý SỐT BÒ BẰM LỚN + NƯỚC NGỌT', N'8', N'https://jollibee.com.vn/uploads/dish/7befdf5dbb9328-2840019_01myylon01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_21', N'category_3', N'MÌ Ý SỐT BÒ BẰM LỚN + 1 MIẾNG GÀ RÁN + NƯỚC NGỌT', N'13', N'https://jollibee.com.vn/uploads/dish/a01c6ffac8f4d6-2840020_01myylon01cj01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_22', N'category_3', N'MÌ Ý SỐT BÒ BẰM LỚN + 1 MIẾNG GÀ RÁN + KHOAI TÂY VỪA + NƯỚC NGỌT', N'15', N'https://jollibee.com.vn/uploads/dish/20ad9d7968afc4-2840024_01myylon01cj01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_23', N'category_3', N'MÌ Ý SỐT BÒ BẰM LỚN + KHOAI TÂY VỪA + NƯỚC NGỌT', N'10', N'https://jollibee.com.vn/uploads/dish/af648a3b708bff-2840022_01myylon01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_24', N'category_3', N'N3 - MÌ Ý SỐT BÒ BẰM + 1 MIẾNG GÀ RÁN + KHOAI TÂY VỪA + NƯỚC NGỌT', N'14', N'https://jollibee.com.vn/uploads/dish/7152e2e85bd4c2-2840011_01myynho01cj01khoainho01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_25', N'category_3', N'N5 - MÌ Ý SỐT BÒ BẰM + 2 MIẾNG GÀ GIÒN KHÔNG XƯƠNG + KHOAI TÂY VỪA + NƯỚC NGỌT', N'13', N'https://jollibee.com.vn/uploads/dish/c341d1e4536398-2840010_01myynho02gakhongxuong01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_26', N'category_3', N'N1 - MÌ Ý SỐT BÒ BẰM + 2 MIẾNG GÀ GIÒN KHÔNG XƯƠNG + NƯỚC NGỌT', N'12', N'https://jollibee.com.vn/uploads/dish/5f31ab1c9f1a00-2840008_01myynho02gakoxuong01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_27', N'category_3', N'MÌ Ý SỐT BÒ BẰM', N'12', N'https://jollibee.com.vn/uploads/dish/50a754c7b328c8-1840001_01myy.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_28', N'category_4', N'SANDWICH GÀ GIÒN + NƯỚC NGỌT', N'5', N'https://jollibee.com.vn/uploads/dish/f0509916cba46a-2860002_sandwichga01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_29', N'category_4', N'SANDWICH THỊT NƯỚNG BBQ + KHOAI TÂY + NƯỚC NGỌT', N'7', N'https://jollibee.com.vn/uploads/dish/ca79195ff54344-2860007_sandwichbbq01khoaivua01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_30', N'category_4', N'SANDWICH THỊT NƯỚNG BBQ + NƯỚC NGỌT', N'6', N'https://jollibee.com.vn/uploads/dish/92d19ff9ee533e-2860006_01sandwichbbq01pepsi.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_31', N'category_5', N'KHOAI TÂY CHIÊN (VỪA)', N'4', N'https://jollibee.com.vn/uploads/dish/5532107fb902fd-1860001_khoaivua21.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_32', N'category_5', N'KHOAI TÂY CHIÊN (LỚN)', N'5', N'https://jollibee.com.vn/uploads/dish/2a0e60ca7a388a-2mienggaran23.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_33', N'category_5', N'KHOAI TÂY LẮC VỊ BBQ (VỪA)', N'4', N'https://jollibee.com.vn/uploads/dish/344f5860c20f57-6930a7bd0381642mienggaran22.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_34', N'category_6', N'BÁNH PIE NHÂN XOÀI ĐÀO', N'2', N'https://jollibee.com.vn/uploads/dish/99da79db6f9f3e-600x6001.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_35', N'category_6', N'BÁNH PIE NHÂN KHOAI MÔN', N'2', N'https://jollibee.com.vn/uploads/dish/999e149f170dbe-2mienggaran13.png', N'')
INSERT [dbo].[Product] ([id_product], [id_category], [name_product], [price_product], [image], [describe]) VALUES (N'product_36', N'category_6', N'KEM SUNDAES DÂU', N'2', N'https://jollibee.com.vn/uploads/dish/d01402ed11976b-kemsundeadau.png', N'')
INSERT [dbo].[User] ([id_user], [username], [password], [fullname], [email], [id_permission]) VALUES (N'0.3513029946203592', N'quoctoan123', N'123', N'Nguyen Quoc Toan', N'hahadaubo@gmail.com', N'0.4859514654')
INSERT [dbo].[User] ([id_user], [username], [password], [fullname], [email], [id_permission]) VALUES (N'0.8402404073486265', N'tienkim9920', N'123', N'Nguyen Kim Tien', N'tienkim9920@gmail.com', N'0.4859514654')
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
