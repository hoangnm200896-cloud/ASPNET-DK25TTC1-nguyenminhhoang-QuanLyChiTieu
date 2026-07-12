# Báo cáo tiến độ - Tuần 2

**Thời gian**: 29/06/2026 - 05/07/2026
**Sinh viên**: Nguyễn Minh Hoàng
**Mã lớp**: DK25TTC1

## Công việc đã thực hiện
- Xây dựng DanhMucController với đầy đủ chức năng CRUD (thêm, sửa, xóa, xem danh sách danh mục)
- Xây dựng GiaoDichController với đầy đủ chức năng CRUD giao dịch thu chi, liên kết tới danh mục tương ứng
- Thiết kế các View tương ứng theo mô hình Razor View (Index, Create, Edit, Delete, Details) cho cả Danh mục và Giao dịch
- Xây dựng DashboardViewModel để tổng hợp dữ liệu hiển thị: tổng thu nhập, tổng chi tiêu, số dư, chi tiêu theo danh mục, danh sách giao dịch gần nhất
- Áp dụng validate dữ liệu đầu vào cơ bản (bắt buộc nhập tên giao dịch, số tiền, ngày)
- Kiểm thử thủ công các chức năng thêm/sửa/xóa để đảm bảo dữ liệu lưu đúng vào SQLite

## Khó khăn gặp phải
- Tuần này tiến độ báo cáo và commit bị gián đoạn do bận công việc cá nhân, chưa ghi báo cáo và commit đúng lịch trình hàng tuần như dự kiến
- Gặp một số warning liên quan đến non-nullable property khi build (CS8618), đã ghi nhận để xử lý ở giai đoạn hoàn thiện sau

## Kế hoạch tuần tới
- Thiết lập repository GitHub chính thức, bổ sung đầy đủ lịch sử commit và báo cáo tiến độ còn thiếu
- Duy trì commit và báo cáo tiến độ đều đặn hàng tuần từ tuần 3 trở đi
- Rà soát và tinh chỉnh giao diện Dashboard, kiểm tra lại luồng dữ liệu hiển thị
