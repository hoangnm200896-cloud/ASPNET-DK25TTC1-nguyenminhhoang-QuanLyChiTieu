# QuanLyChiTieu - Đồ án Chuyên đề ASP.NET

## Thông tin sinh viên
- **Họ tên**: Nguyễn Minh Hoàng
- **Mã lớp**: DK25TTC1
- **GVHD**: TS. Nguyễn Nhứt Lam
- **Repository**: ASPNET-DK25TTC1-nguyenminhhoang-QuanLyChiTieu

## Giới thiệu đề tài
Ứng dụng web quản lý chi tiêu cá nhân, xây dựng trên nền tảng ASP.NET Core MVC,
cho phép người dùng ghi nhận, phân loại và theo dõi các khoản thu chi hàng ngày.

## Mục tiêu
- Xây dựng hệ thống quản lý chi tiêu với các chức năng CRUD cơ bản
- Áp dụng mô hình MVC và Entity Framework Core để làm việc với dữ liệu


## Công nghệ sử dụng
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQLite (QuanLyChiTieu.db)

## Cấu trúc thư mục dự án
```
QuanLyChiTieu/
├── Controllers/     # Xử lý logic điều hướng, request
├── Models/          # Định nghĩa các entity, dữ liệu
├── Views/           # Giao diện người dùng (Razor views)
├── Data/            # DbContext, cấu hình Entity Framework
├── wwwroot/         # Static files (CSS, JS, hình ảnh)
├── Properties/       # Cấu hình launch settings
├── Program.cs        # Điểm khởi chạy ứng dụng
├── appsettings.json  # Cấu hình ứng dụng
└── QuanLyChiTieu.csproj
```

## Chức năng đã hoàn thành
- [ ] Thiết lập project, cấu hình Entity Framework Core và SQLite
- [ ] Xây dựng Model dữ liệu (Giao dịch, Danh mục chi tiêu...)
- [ ] Chức năng Thêm/Sửa/Xóa/Xem giao dịch
- [ ] Thống kê chi tiêu theo tháng/danh mục
- [ ] Giao diện responsive


## Hướng dẫn cài đặt và chạy chương trình
1. Clone repository:
   ```
   git clone [https://github.com/hoangnm200896-cloud/ASPNET-DK25TTC1-nguyenminhhoang-QuanLyChiTieu.git]
   ```
2. Di chuyển vào thư mục dự án:
   ```
   cd QuanLyChiTieu
   ```
3. Khôi phục các package:
   ```
   dotnet restore
   ```
4. Chạy ứng dụng:
   ```
   dotnet run
   ```
5. Truy cập ứng dụng tại: `http://localhost:5062`

## Liên hệ
- Email: hoangnm200896@tvu-onschool.edu.vn
- SĐT: 0904200896
