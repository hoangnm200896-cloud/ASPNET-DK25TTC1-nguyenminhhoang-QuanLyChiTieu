# Báo cáo tiến độ - Tuần 4

**Thời gian**: 13/07/2026 - 19/07/2026
**Sinh viên**: Nguyễn Minh Hoàng
**Mã lớp**: DK25TTC1

## Công việc đã thực hiện
- Rà soát lại toàn bộ chức năng đã có của ứng dụng để đánh giá mức độ phù hợp với nhu cầu thực tế của người dùng đi làm, xác định các tính năng cần bổ sung: bộ lọc theo thời gian, tìm kiếm/lọc giao dịch, biểu đồ trực quan
- Kiểm tra và xác nhận chức năng tìm kiếm/lọc giao dịch (theo từ khóa, danh mục, khoảng ngày, loại thu/chi) tại trang Giao dịch đã hoạt động đầy đủ
- Kiểm tra và xác nhận chức năng biểu đồ trực quan (biểu đồ tròn chi tiêu theo danh mục, biểu đồ cột so sánh thu-chi theo 12 tháng) tại trang Dashboard và trang Thống kê đã hoạt động đầy đủ
- Bổ sung chức năng lọc theo tháng/năm ngay tại trang Dashboard (trước đây chỉ xem được tháng hiện tại): cập nhật HomeController để nhận tham số tháng/năm tùy chọn, cập nhật giao diện Views/Home/Index.cshtml thêm dropdown chọn tháng/năm
- Cài đặt bổ sung .NET 8 Runtime trên máy cá nhân để phục vụ việc build và chạy thử ứng dụng
- Build và kiểm thử lại toàn bộ ứng dụng sau khi chỉnh sửa

## Khó khăn gặp phải
- Phát hiện lỗi khi thêm giao dịch mới tại trang Tạo giao dịch (GiaoDich/Create): sau khi điền đầy đủ thông tin hợp lệ và bấm Lưu, hệ thống không báo lỗi validate nhưng giao dịch cũng không được ghi vào cơ sở dữ liệu (đã xác minh trực tiếp qua truy vấn SQLite). Đây là lỗi cần tiếp tục điều tra ở tuần tiếp theo, nghi ngờ liên quan đến quá trình xử lý submit form hoặc thao tác lưu dữ liệu trong Controller
- Một số warning CS8618 (non-nullable property) trong các Model vẫn chưa được xử lý, chưa ảnh hưởng đến hoạt động của ứng dụng nhưng cần dọn dẹp để mã nguồn sạch hơn

## Kế hoạch tuần tới
- Ưu tiên hàng đầu: tìm và khắc phục lỗi không lưu được giao dịch mới
- Xử lý các warning CS8618 còn tồn đọng trong Models
- Viết Chương 2: Nghiên cứu lý thuyết (ASP.NET Core MVC, Entity Framework Core, SQLite) cho báo cáo đồ án
- Bắt đầu Chương 3: Hiện thực hóa nghiên cứu (thiết kế Model, sơ đồ quan hệ dữ liệu)
