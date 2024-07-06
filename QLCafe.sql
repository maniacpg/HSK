-- Tạo cơ sở dữ liệu
CREATE DATABASE QLCF
GO

USE QLCF
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

update Ban set TrangThai = N'Đầy' where id = 6
-- Bảng TaiKhoan
CREATE TABLE TaiKhoan
(   
    Ten NVARCHAR(100) NOT NULL,
    TenTK NVARCHAR(100) PRIMARY KEY,
    MatKhau NVARCHAR(1000) NOT NULL DEFAULT N'0',
    Type INT NOT NULL DEFAULT 0 --1.admin/0.staff
)
GO
select * from TaiKhoan where TenTK = N'maniac' and MatKhau = N'123456';
-- Bảng DanhmucDoUong
CREATE TABLE DanhmucDoUong
(
    id INT PRIMARY KEY,
    TenDoUong NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten'
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
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (2, N'Trá đào', 2, 25000);
INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (3, N'Pepsi', 3, 15000);
-- Chèn dữ liệu vào bảng DanhmucDoUong
INSERT INTO DanhmucDoUong (id, TenDoUong) VALUES (1, N'Cà phê');
INSERT INTO DanhmucDoUong (id, TenDoUong) VALUES (2, N'Trá');
INSERT INTO DanhmucDoUong (id, TenDoUong) VALUES (3, N'Nước ngọt');

select * from DoUong

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
CREATE TABLE HoaDon
(
    id INT IDENTITY PRIMARY KEY,
    DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
    DateCheckOut DATE,
    idBan INT NOT NULL,
    status INT NOT NULL,   -- 1.Paid/0.not paid
    idKH INT,        
    idNV INT,           
    FOREIGN KEY (idBan) REFERENCES dbo.Ban(id),
    FOREIGN KEY (idKH) REFERENCES dbo.KhachHang(id),
    FOREIGN KEY (idNV) REFERENCES dbo.NhanVien(id)
)
GO

-- Bảng ChiTietHoaDonBan
CREATE TABLE ChiTietHoaDonBan
(
    id INT IDENTITY PRIMARY KEY,
    idHoaDon INT NOT NULL,
    idDoUong INT NOT NULL,
    count INT NOT NULL DEFAULT 0,
    FOREIGN KEY (idHoaDon) REFERENCES dbo.HoaDon(id),
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
        Ten, 
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
exec Select_All_TaiKhoan
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
    
    SELECT d.id, d.TenDoUong, d.DonGia, dm.TenDoUong AS TenDanhMuc
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
        Ten, 
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

Exec Select_Ban

-- Thêm dữ liệu mẫu
INSERT INTO NhanVien (id, TenNV, SDTNV, emailNV, GioiTinh, NgaySinh)
VALUES 
(1, N'Nguyễn Văn Hùng', '0901234567', 'nguyenvanhung@email.com', 1, '1990-01-15'),
(2, N'Trần Thị Mai', '0912345678', 'tranthimai@email.com', 0, '1992-05-20'),
(3, N'Lê Minh Tuấn', '0923456789', 'leminhtuanh@email.com', 1, '1988-11-30'),
(4, N'Phạm Thị Hương', '0934567890', 'phamthihuong@email.com', 0, '1995-08-10'),
(5, N'Hoàng Đức Anh', '0945678901', 'hoangducanh@email.com', 1, '1993-03-25'),
(6, N'Vũ Thị Lan Anh', '0956789012', 'vuthilananh@email.com', 0, '1991-12-05')
GO

-- Thêm dữ liệu mẫu cho bảng TaiKhoan
INSERT INTO TaiKhoan (Ten, TenTK, MatKhau, Type)
VALUES 
(N'Đình Quân', 'maniac', '123456', 0),
(N'Phong Nguyễn', 'phongn', '123456', 1)
GO


INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Nguyễn Thị Mai', '0901234567', 'mainguyen@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Phạm Văn Hùng', '0902345678', 'hungpham@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Lê Thị Thu', '0903456789', 'thule@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Trần Quốc Toàn', '0904567890', 'toantran@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Hoàng Văn Hải', '0905678901', 'haihoang@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Võ Thị Hạnh', '0906789012', 'hanhvo@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Đặng Văn Tùng', '0907890123', 'tungdang@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Bùi Thị Lan', '0908901234', 'lanbui@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Ngô Văn Cường', '0909012345', 'cuongngo@example.com');
INSERT INTO KhachHang (TenKH, SDTKH, emailKH) VALUES (N'Phan Thị Thu Hà', '0910123456', 'haphan@example.com');
GO

INSERT INTO HoaDon (DateCheckIn, DateCheckOut, idBan, status, idKH, idNV)
VALUES 
(GETDATE(), Getdate(), 1, 1, 1, 1)
(GETDATE(), null, 1, 0, 1, 1),
(GETDATE(), null, 2, 1, 6, 2),
(GETDATE(), null, 3, 0, 7, 3),
(GETDATE(), null, 4, 1, 8, 4),
(GETDATE(), null, 5, 0, 9, 5),
(GETDATE(), null, 6, 1, 10, 1),
(GETDATE(), null, 7, 0, 11, 2),
(GETDATE(), null, 8, 1, 12, 3),
(GETDATE(), null, 9, 0, 13, 4),
(GETDATE(), null, 10, 1, 14, 5);

select * from HoaDon
-- Chèn dữ liệu vào bảng ChiTietHoaDonBan
INSERT INTO ChiTietHoaDonBan (idHoaDon, idDoUong, count)
VALUES 
-- Chi tiết hóa đơn số 1
(1, 1, 2),  -- Cà phê đen x 2
(1, 2, 1),  -- Trà đào x 1

-- Chi tiết hóa đơn số 2
(2, 3, 3),  -- Pepsi x 3

-- Chi tiết hóa đơn số 3
(3, 1, 1),  -- Cà phê đen x 1
(3, 2, 2),  -- Trà đào x 2

-- Chi tiết hóa đơn số 4
(4, 3, 1),  -- Pepsi x 1

-- Chi tiết hóa đơn số 5
(5, 1, 1),  -- Cà phê đen x 1
(5, 2, 1),  -- Trà đào x 1
(5, 3, 2),  -- Pepsi x 2

-- Chi tiết hóa đơn số 6
(6, 1, 2),  -- Cà phê đen x 2
(6, 3, 1),  -- Pepsi x 1

-- Chi tiết hóa đơn số 7
(7, 2, 3),  -- Trà đào x 3

-- Chi tiết hóa đơn số 8
(8, 1, 1),  -- Cà phê đen x 1

-- Chi tiết hóa đơn số 9
(9, 2, 2),  -- Trà đào x 2

-- Chi tiết hóa đơn số 10
(10, 3, 1); -- Pepsi x 1

-- Kiểm tra dữ liệu trong bảng ChiTietHoaDonBan
SELECT * FROM ChiTietHoaDonBan where idHoaDon = 3
select * from HoaDon where idBan = 3
select du.TenDoUong,ct.count, du.DonGia, du.DonGia*ct.count as ThanhTien  from ChiTietHoaDonBan as ct, HoaDon as hd, DoUong as du 
where ct.idHoaDon = hd.id and ct.idDoUong = du.id and hd.status = 0 and hd.idBan = 3 

select * from HoaDon
select * from ChiTietHoaDonBan
select * from Ban