create database QLyQuanCafe1
go

use QLyQuanCafe1
go

--Table
create table Ban
(
	id int identity primary key,
	name nvarchar(100) not null default N'Chua dat ten',
	TrangThai nvarchar(100) not null, --empty/full
)
go

--Account
create table TaiKhoan
(	
	Ten nvarchar(100) not null,
	TenTK nvarchar(100) primary key,
	MatKhau nvarchar(1000) not null default N'0',
	Type int not null default 0 --1.admin/0.staff
)
go

--Categories
create table DanhmucDoUong
(
	id int identity primary key,
	TenDoUong nvarchar(100) not null default N'Chua dat ten'
)
go

--Food
create table DoUong
(
	id int identity primary key,
	TenDoUong nvarchar(100) default N'Chua dat ten',
	idDanhMuc int not null,
	DonGia float not null default 0

	foreign key (idDanhMuc) references dbo.DanhmucDoUong(id)
)
go

-- Customer
create table KhachHang
(
	id int identity primary key,
	TenKH nvarchar(100) not null default N'Chưa đặt tên',
	SDTKH nvarchar(20),
	emailKH nvarchar(100),
)

-- Staff
create table NhanVien
(
	id int identity primary key,
	TenNV nvarchar(100) not null default N'Chưa đặt tên',
	SDTNV nvarchar(20),
	emailNV nvarchar(100),
)

-- Bill
create table HoaDon
(
	id int identity primary key,
	DateCheckIn Date not null default getdate(),
	DateCheckOut Date,
	idBan int not null,
	status int not null,   -- 1.Paid/0.not paid
	idKH int,        -- Thêm khóa ngoại cho bảng Khách hàng
	idNV int,           -- Thêm khóa ngoại cho bảng Nhân viên
	foreign key (idBan) references dbo.Ban(id),
	foreign key (idKH) references dbo.KhachHang(id),
	foreign key (idNV) references dbo.NhanVien(id)
)

-- Bill Info
create table ChiTietHoaDonBan
(
	id int identity primary key,
	idHoaDon int not null,
	idDoUong int not null,
	count int not null default 0,
	foreign key (idHoaDon) references dbo.HoaDon(id),
	foreign key (idDoUong) references dbo.DoUong(id),
)

--Nha cung cap

create table NCC
(
	id int identity primary key,
	name nvarchar(1000),
	diaChi nvarchar(1000),
	sDT varchar(10),
)
go
--Hoa don nhap
create table HoaDonNhapHang
(
	id int identity primary key,         
	idNCC int not null,   
	idNV int not null,
	DateReceived Date not null default getdate(), 
	TotalAmount float not null default 0,         
	foreign key (idNCC) references dbo.NCC(id),
	foreign key (idNV) references dbo.NhanVien(id) 
)
go

--Chi tiet hoa don nhap
create table ChiTietHoaDonNhapHang
(
	id int identity primary key,     
	idHoaDon int not null,           
	idDoUong int not null,             
	SoLuong int not null default 0, 
	Gia float not null default 0,  
	foreign key (idHoaDon) references dbo.HoaDonNhapHang(id),
	foreign key (idDoUong) references dbo.DoUong(id)              
)
go

--insert
