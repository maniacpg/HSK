-- Tạo cơ sở dữ liệu
CREATE DATABASE QLCF2
GO

USE QLCF2
GO


-- Bảng Ban
CREATE TABLE Ban
(
    id INT PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    TrangThai NVARCHAR(100) NOT NULL --empty/full
)
GO
select * from Ban
-- Chèn dữ liệu vào bảng Ban
-- Chèn dữ liệu vào bảng Ban
INSERT INTO Ban (id, name, TrangThai) VALUES (1, N'Bàn 1', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (2, N'Bàn 2', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (3, N'Bàn 3', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (4, N'Bàn 4', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (5, N'Bàn 5', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (6, N'Bàn 6', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (7, N'Bàn 7', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (8, N'Bàn 8', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (9, N'Bàn 9', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (10, N'Bàn 10', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (11, N'Bàn 11', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (12, N'Bàn 12', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (13, N'Bàn 13', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (14, N'Bàn 14', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (15, N'Bàn 15', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (16, N'Bàn 16', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (17, N'Bàn 17', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (18, N'Bàn 18', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (19, N'Bàn 19', N'Trống');
INSERT INTO Ban (id, name, TrangThai) VALUES (20, N'Bàn 20', N'Trống');


-- Bảng TaiKhoan
CREATE TABLE TaiKhoan
(   
    
    TenTK NVARCHAR(100) PRIMARY KEY,
    MatKhau NVARCHAR(1000) NOT NULL DEFAULT N'0',
    Type INT NOT NULL DEFAULT 0 --1.admin/0.staff
)
GO
ALTER TABLE TaiKhoan
ADD Ten NVARCHAR(100)
ADD idNhanVien INT;

ALTER TABLE TaiKhoan
ADD CONSTRAINT FK_TaiKhoan_NhanVien
FOREIGN KEY (idNhanVien) REFERENCES NhanVien(id);
INSERT INTO TaiKhoan (TenTK, MatKhau, Type, idNhanVien)
VALUES 
(N'kd', '1', 1, 1),
(N'staff', '1', 0, 2);



-- Bảng DanhmucDoUong
CREATE TABLE DanhmucDoUong
(
    id INT PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten'
)
GO



-- Bảng DoUong

CREATE TABLE DoUong
(
    id INT PRIMARY KEY,
    TenDoUong NVARCHAR(100) DEFAULT N'Chua dat ten',
    idDanhMuc INT NOT NULL,
    DonGia FLOAT NOT NULL DEFAULT 0

    FOREIGN KEY (idDanhMuc) REFERENCES dbo.DanhmucDoUong(id)
)
GO

-- Chèn dữ liệu vào bảng DoUong
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (1, N'Cà phê đen', 1, 20000);
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (2, N'Trà đào', 2, 25000);
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (3, N'Pepsi', 3, 15000);
-- Chèn thêm đồ uống vào danh mục 'Cà phê'
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (4, N'Cà phê sữa', 1, 22000);
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (5, N'Cà phê đá', 1, 18000);

-- Chèn thêm đồ uống vào danh mục 'Trà'
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (6, N'Trà chanh', 2, 23000);
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (7, N'Trà dâu', 2, 27000);

-- Chèn thêm đồ uống vào danh mục 'Nước ngọt'
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (8, N'Coca', 3, 15000);
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (9, N'Sprite', 3, 15000);
GO

-- Chèn dữ liệu vào bảng DanhmucDoUong
INSERT INTO DanhmucDoUong (id, TenDanhMuc) VALUES (1, N'Cà phê');
INSERT INTO DanhmucDoUong (id, TenDanhMuc) VALUES (2, N'Trà');
INSERT INTO DanhmucDoUong (id, TenDanhMuc) VALUES (3, N'Nước ngọt');



-- Bảng NhanVien (không có IDENTITY ở cột id)
CREATE TABLE NhanVien
(
    id INT PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    SDTNV NVARCHAR(20),
    emailNV NVARCHAR(100),
    GioiTinh BIT,
    NgaySinh DATE
)
GO
INSERT INTO NhanVien (id, TenNV, SDTNV, emailNV, GioiTinh, NgaySinh)
VALUES 
(1, N'Đình Quân', '0123456789', 'a@example.com', 1, '2001-05-27'),
(2, N'Nguyễn An', '0987654321', 'b@example.com', 1, '1990-02-02');

-- Bảng KhachHang
CREATE TABLE KhachHang
(
    id INT identity PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    SDTKH NVARCHAR(20),
    emailKH NVARCHAR(100),
)
GO

-- Bảng HoaDon
CREATE TABLE HoaDonBan
(
    id INT IDENTITY PRIMARY KEY,
    DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
    DateCheckOut DATE,
    idBan INT NOT NULL,
	
    status INT NOT NULL,   -- 1.Paid/0.not paid
               
    FOREIGN KEY (idBan) REFERENCES dbo.Ban(id),
    
)
GO
select * from HoaDonBan
ALTER TABLE HoaDonBan
ADD idNhanVien INT;

ALTER TABLE HoaDonBan
ADD CONSTRAINT FK_HoaDonBan_NhanVien
FOREIGN KEY (idNhanVien) REFERENCES NhanVien(id);

alter table HoaDonBan add GiamGia int
update HoaDonBan set GiamGia = 0


-- Bảng ChiTietHoaDonBan
CREATE TABLE ChiTietHoaDonBan
(
    id INT IDENTITY PRIMARY KEY,
    idHoaDon INT NOT NULL,
    idDoUong INT NOT NULL,
    count INT NOT NULL DEFAULT 0,
    FOREIGN KEY (idHoaDon) REFERENCES dbo.HoaDonBan(id),
    FOREIGN KEY (idDoUong) REFERENCES dbo.DoUong(id),
)
GO

-- Bảng NCC
CREATE TABLE NCC
(
    id INT PRIMARY KEY,
    name NVARCHAR(1000),
    diaChi NVARCHAR(1000),
    sDT VARCHAR(10),
)
GO

-- Bảng HoaDonNhapHang
CREATE TABLE HoaDonNhapHang
(
    id INT IDENTITY PRIMARY KEY,         
    idNCC INT NOT NULL,   
    idNV INT NOT NULL,
    DateReceived DATE NOT NULL DEFAULT GETDATE(), 
    TotalAmount FLOAT NOT NULL DEFAULT 0,         
    FOREIGN KEY (idNCC) REFERENCES dbo.NCC(id),
    FOREIGN KEY (idNV) REFERENCES dbo.NhanVien(id) 
)
GO

-- Bảng ChiTietHoaDonNhapHang
CREATE TABLE ChiTietHoaDonNhapHang
(
    id INT IDENTITY PRIMARY KEY,     
    idHoaDon INT NOT NULL,           
    idDoUong INT NOT NULL,             
    SoLuong INT NOT NULL DEFAULT 0, 
    Gia FLOAT NOT NULL DEFAULT 0,  
    FOREIGN KEY (idHoaDon) REFERENCES dbo.HoaDonNhapHang(id),
    FOREIGN KEY (idDoUong) REFERENCES dbo.DoUong(id)              
)
GO

-- Stored Procedures

-- Insert_KhachHang
CREATE PROCEDURE Insert_KhachHang
    @TenKH NVARCHAR(100),
    @SDTKH NVARCHAR(20),
    @emailKH NVARCHAR(100)
AS
BEGIN
    INSERT INTO KhachHang(TenKH, SDTKH, emailKH)
    VALUES (@TenKH, @SDTKH, @emailKH)
END
GO

-- Select_KhachHang
CREATE PROCEDURE Select_KhachHang
AS
BEGIN
    SELECT id, TenKH, SDTKH, emailKH
    FROM KhachHang;
END 
GO

-- Update_KhachHang
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

-- Delete_KhachHang
CREATE PROCEDURE Delete_KhachHang
    @ID INT
AS
BEGIN
    DELETE FROM KhachHang
    WHERE id = @ID;
END
GO

-- Insert_TaiKhoan
CREATE PROCEDURE Insert_TaiKhoan
    @Ten NVARCHAR(100),
    @TenTK NVARCHAR(100),
    @MatKhau NVARCHAR(1000),
    @Type INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenTK = @TenTK)
    BEGIN
        INSERT INTO TaiKhoan (Ten, TenTK, MatKhau, Type)
        VALUES (@Ten, @TenTK, @MatKhau, @Type)
        SELECT N'Tài khoản đã được thêm thành công.' AS Result
    END
    ELSE
    BEGIN
        SELECT N'Tên tài khoản đã tồn tại. Vui lòng chọn tên khác.' AS Result
    END
END
GO

-- Select_All_TaiKhoan
CREATE PROCEDURE Select_All_TaiKhoan
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        
        TenTK,         
        CASE 
            WHEN Type = 1 THEN N'Admin'
            WHEN Type = 0 THEN N'Nhân viên'
            ELSE N'Không xác định'
        END AS LoaiTaiKhoan
    FROM 
        TaiKhoan
    ORDER BY 
        TenTK
END
GO

-- Update_TaiKhoan
CREATE PROCEDURE Update_TaiKhoan
    @Ten NVARCHAR(100),
    @TenTK NVARCHAR(100),
    @Type INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE TaiKhoan
    SET Ten = @Ten, Type = @Type
    WHERE TenTK = @TenTK
    IF @@ROWCOUNT > 0
        SELECT 1 AS Result
    ELSE
        SELECT 0 AS Result
END
GO

-- Delete_TaiKhoan
CREATE PROCEDURE Delete_TaiKhoan
    @TenTK NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM TaiKhoan WHERE TenTK = @TenTK;
    IF @@ROWCOUNT > 0
        SELECT 1;
    ELSE
        SELECT 0;
END
GO

-- Select_NhanVien
CREATE PROCEDURE Select_NhanVien
AS
BEGIN
    SELECT id, TenNV, SDTNV, emailNV, NgaySinh, GioiTinh
    FROM NhanVien;
END 
GO
--Insert NhanVien
CREATE PROCEDURE Insert_NhanVien
    @id INT,
    @TenNV NVARCHAR(100),
    @SDTNV NVARCHAR(20),
    @emailNV NVARCHAR(100),
    @GioiTinh BIT,
    @NgaySinh DATE
AS
BEGIN
    INSERT INTO NhanVien (id, TenNV, SDTNV, emailNV, GioiTinh, NgaySinh)
    VALUES (@id, @TenNV, @SDTNV, @emailNV, @GioiTinh, @NgaySinh);
END
GO
--cap nhat NhanVien
CREATE PROCEDURE Update_NhanVien
    @id INT,
    @TenNV NVARCHAR(100),
    @SDTNV NVARCHAR(20),
    @emailNV NVARCHAR(100),
    @GioiTinh BIT,
    @NgaySinh DATE
AS
BEGIN
    UPDATE NhanVien
    SET TenNV = @TenNV,
        SDTNV = @SDTNV,
        emailNV = @emailNV,
        GioiTinh = @GioiTinh,
        NgaySinh = @NgaySinh
    WHERE id = @id;
END
GO
--Xoa NhanVien
CREATE PROCEDURE Delete_NhanVien
    @id INT
AS
BEGIN
    DELETE FROM NhanVien
    WHERE id = @id;
END
GO
exec Delete_NhanVien @id = 12
select * from NhanVien
--tim kiem theo ten

CREATE PROCEDURE Search_NhanVien
    @TenNV NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM NhanVien
    WHERE TenNV LIKE '%' + @TenNV + '%';
END

CREATE PROCEDURE Select_DoUong
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT d.id, d.TenDoUong, d.DonGia, dm.TenDanhMuc AS TenDanhMuc
    FROM DoUong d
    INNER JOIN DanhmucDoUong dm ON d.idDanhMuc = dm.id;
END
GO

CREATE PROCEDURE sp_GetTaiKhoanByTenTKAndMatKhau
    @TenTK NVARCHAR(100),
    @MatKhau NVARCHAR(1000)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
         
        TenTK, 
        MatKhau, 
        Type
    FROM 
        TaiKhoan
    WHERE 
        TenTK = @TenTK 
        AND MatKhau = @MatKhau;
END
GO

create proc Select_Ban
as
begin
select * from Ban
end

create proc Insert_HoaDonBan
@idBan int
as
begin 
insert HoaDonBan(DateCheckIn, DateCheckOut, idBan, status, GiamGia, idNhanVien)
values (getdate(), null, @idBan, 0, 0, null)

end
go

select * from HoaDonBan
select * from HoaDonBan where idBan = 1 and status = 0
create proc Insert_ChitietHoaDon
@idHoaDon int, @idDoUong int, @count int
as
begin
	declare @isExistCTHoaDon int;
	declare @soLuongDoUong int = 1;
	select @isExistCTHoaDon = id, @soLuongDoUong = count from ChiTietHoaDonBan where idHoaDon = @idHoaDon and idDoUong = @idDoUong

	if(@isExistCTHoaDon > 0)
	begin
	declare @newCount int = @soLuongDoUong + @count
	if(@newCount > 0)
	    UPDATE ChiTietHoaDonBan set count = @soLuongDoUong + @count where idDoUong = @idDoUong
	else 
		delete ChiTietHoaDonBan where idHoaDon = @idHoaDon and idDoUong = @idDoUong
	end
	else
	begin
	
	insert ChiTietHoaDonBan(idHoaDon, idDoUong, count)
	values (@idHoaDon, @idDoUong, @count)
	end
end
go


create PROCEDURE ChuyenBan
    @idBan1 INT,
    @idBan2 INT
AS
BEGIN
    DECLARE @idHoaDon1 INT;
    DECLARE @idHoaDon2 INT;

    -- Lấy ID hóa đơn của bàn 1 và bàn 2
    SELECT @idHoaDon1 = id FROM HoaDonBan WHERE idBan = @idBan1 AND status = 0;
    SELECT @idHoaDon2 = id FROM HoaDonBan WHERE idBan = @idBan2 AND status = 0;

    -- Nếu không có hóa đơn cho bàn 1, tạo hóa đơn mới
    IF (@idHoaDon1 IS NULL)
    BEGIN
        INSERT INTO HoaDonBan (DateCheckIn, DateCheckOut, idBan, status)
        VALUES (GETDATE(), NULL, @idBan1, 0);

        SELECT @idHoaDon1 = MAX(id) FROM HoaDonBan WHERE idBan = @idBan1 AND status = 0;
    END

    -- Nếu không có hóa đơn cho bàn 2, tạo hóa đơn mới
    IF (@idHoaDon2 IS NULL)
    BEGIN
        INSERT INTO HoaDonBan (DateCheckIn, DateCheckOut, idBan, status)
        VALUES (GETDATE(), NULL, @idBan2, 0);

        SELECT @idHoaDon2 = MAX(id) FROM HoaDonBan WHERE idBan = @idBan2 AND status = 0;
    END

    -- Tạo bảng tạm để lưu id của các chi tiết hóa đơn của bàn 2
    SELECT id INTO #idCTHDTable FROM ChiTietHoaDonBan WHERE idHoaDon = @idHoaDon2;

    -- Chuyển chi tiết hóa đơn từ bàn 1 sang bàn 2
    UPDATE ChiTietHoaDonBan SET idHoaDon = @idHoaDon2 WHERE idHoaDon = @idHoaDon1;

    -- Chuyển chi tiết hóa đơn từ bảng tạm về bàn 1
    UPDATE ChiTietHoaDonBan SET idHoaDon = @idHoaDon1 WHERE id IN (SELECT id FROM #idCTHDTable);

    -- Xóa bảng tạm
    DROP TABLE #idCTHDTable;

    -- Cập nhật trạng thái của bàn 1 và bàn 2
    DECLARE @countCTHD1 INT;
    DECLARE @countCTHD2 INT;

    SELECT @countCTHD1 = COUNT(*) FROM ChiTietHoaDonBan WHERE idHoaDon = @idHoaDon1;
    SELECT @countCTHD2 = COUNT(*) FROM ChiTietHoaDonBan WHERE idHoaDon = @idHoaDon2;

    IF (@countCTHD1 > 0)
        UPDATE Ban SET TrangThai = N'Đầy' WHERE id = @idBan1;
    ELSE
        UPDATE Ban SET TrangThai = N'Trống' WHERE id = @idBan1;

    IF (@countCTHD2 > 0)
        UPDATE Ban SET TrangThai = N'Đầy' WHERE id = @idBan2;
    ELSE
        UPDATE Ban SET TrangThai = N'Trống' WHERE id = @idBan2;
END
GO


alter table HoaDonBan add thanhTien float
alter table HoaDonBan add tongTien float

create proc ThongKeDSHoaDonTheoNgay

@checkIn Date, @checkOut date
as
begin
select b.name , h.DateCheckIn , h.DateCheckOut,h.thanhTien, h.GiamGia, h.tongTien, n.TenNV
from Ban as b, HoaDonBan as h, NhanVien as n
where 
	DateCheckIn >= @checkIn 
	and DateCheckOut <= @checkOut
	and h.status = 1 
	and b.id = h.idBan 
	and n.id = h.idNhanVien
end
GO




-- trigger


create trigger CapNhatCTHD
on ChiTietHoaDonBan for insert, update
as
begin
	declare @idHoaDon int 
	select @idHoaDon = idHoaDon from Inserted
	Declare @idBan int 
	select @idBan = idBan from HoaDonBan where id = @idHoaDon and status = 0
	declare @count int 
	select @count = count(*) from HoaDonBan where id = @idHoaDon
	
	if(@count >0)
	update Ban set TrangThai = N'Đầy' where id = @idBan
	else 
	update Ban set TrangThai = N'Trống' where id = @idBan
end
go


create trigger CapNhatHD
on HoaDonBan for update
as
begin
	declare @idHoaDon int
	select @idHoaDon = id from Inserted
	
	Declare @idBan int 
	select @idBan = idBan from HoaDonBan where id = @idHoaDon

	declare @count int = 0
	select @count = count(*) from HoaDonBan where @idBan = idBan and status = 0
	if(@count = 0)
	update Ban set TrangThai = N'Trống' where id = @idBan
end
go










