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
create table KhachHang
(
	id int identity primary key,
	TenKH nvarchar(100) not null default N'Chưa đặt tên',
	SDTKH nvarchar(20),
	emailKH nvarchar(100),
)
alter table dbo.KhachHang 
alter column id int

SET IDENTITY_INSERT KhachHang ON;
INSERT INTO KhachHang (id, TenKH, SDTKH, emailKH)
VALUES 
(1, N'Nguyễn Văn An', '0901234567', 'nguyenvanan@email.com'),
(2, N'Trần Thị Bình', '0912345678', 'tranthibinh@email.com'),
(3, N'Lê Hoàng Cường', '0923456789', 'lehoangcuong@email.com'),
(4, N'Phạm Thị Dung', '0934567890', 'phamthidung@email.com'),
(5, N'Hoàng Văn Em', '0945678901', 'hoangvanem@email.com'),
(6, N'Ngô Thị Fương', '0956789012', 'ngothifuong@email.com'),
(7, N'Đặng Văn Giang', '0967890123', 'dangvangiang@email.com'),
(8, N'Bùi Thị Hoa', '0978901234', 'buithihoa@email.com'),
(9, N'Lý Văn Inh', '0989012345', 'lyvaninh@email.com'),
(10, N'Vũ Thị Kim', '0990123456', 'vuthikim@email.com');
--procedure
create procedure Insert_KhachHang

 @TenKH nvarchar(100),
 @SDTKH nvarchar(20),
 @emailKH nvarchar(100)
 as
 begin
 insert into KhachHang( TenKH, SDTKH, emailKH)
 values ( @TenKH, @SDTKH, @emailKH)
 end
 go

 create procedure Select_KhachHang
 as
 begin
 select id, TenKH, SDTKH, emailKH
 from KhachHang;
 end 
 go
 CREATE PROCEDURE Update_KhachHang
    @ID INT,
    @TenKH NVARCHAR(100),
    @SDTKH NVARCHAR(20),
    @EmailKH NVARCHAR(100)
AS
BEGIN
    UPDATE KhachHang
    SET TenKH = @TenKH,
        SDTKH = @SDTKH,
        emailKH = @EmailKH
    WHERE id = @ID;
END
GO

CREATE PROCEDURE Delete_KhachHang
    @ID INT
AS
BEGIN
    DELETE FROM KhachHang
    WHERE id = @ID;
END
GO
