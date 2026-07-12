# Báo cáo tiến độ - Tuần 1

**Thời gian**: 22/06/2026 - 26/06/2026 (Thứ Sáu)
**Sinh viên**: Nguyễn Minh Hoàng
**Mã lớp**: DK25TTC1

## Công việc đã thực hiện
- Khởi tạo project ASP.NET Core MVC (.NET 8) với tên QuanLyChiTieu
- Thiết lập cấu trúc thư mục chuẩn MVC: Controllers, Models, Views, Data, wwwroot
- Cấu hình kết nối cơ sở dữ liệu SQLite (QuanLyChiTieu.db) trong appsettings.json
- Xây dựng các Model chính:
  - DanhMuc: quản lý danh mục thu/chi (TenDanhMuc, LoaiDanhMuc, MoTa, danh sách GiaoDich liên kết)
  - GiaoDich: quản lý giao dịch thu chi (TenGiaoDich, số tiền, ngày giao dịch, GhiChu, liên kết tới DanhMuc)
- Thiết lập DbContext trong thư mục Data, cấu hình quan hệ 1-nhiều giữa DanhMuc và GiaoDich bằng Entity Framework Core
- Chạy thử migration đầu tiên, kiểm tra kết nối database thành công

## Khó khăn gặp phải
- Chưa quen với cấu hình quan hệ khóa ngoại giữa DanhMuc và GiaoDich trong Entity Framework Core, phải tìm hiểu thêm về Fluent API
- Mất thời gian điều chỉnh connection string cho đúng với SQLite

## Kế hoạch tuần tới
- Xây dựng Controller và View cho chức năng CRUD Danh mục
- Bắt đầu xây dựng Controller cho Giao dịch

## Ghi chú
- Đây là báo cáo tiến độ đầu tiên, kèm theo commit lịch sử tương ứng trên GitHub.
