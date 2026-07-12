# Báo cáo tiến độ - Tuần 3

**Thời gian**: 06/07/2026 - 12/07/2026
**Sinh viên**: Nguyễn Minh Hoàng
**Mã lớp**: DK25TTC1

## Công việc đã thực hiện
- Thiết lập GitHub repository chính thức cho đồ án, cấu hình .gitignore để loại trừ bin/, obj/ và các file cấu hình cá nhân
- Đưa toàn bộ mã nguồn lên GitHub, bổ sung đầy đủ lịch sử commit và báo cáo tiến độ cho tuần 1 và tuần 2
- Tạo cấu trúc thư mục progress-report và thesis theo đúng quy định trình bày đồ án
- Mời giảng viên hướng dẫn tham gia repository với vai trò Collaborator để theo dõi tiến độ
- Cài đặt và kiểm tra môi trường chạy chương trình (.NET SDK và Runtime phù hợp), build và chạy thử toàn bộ ứng dụng thành công
- Kiểm thử thực tế giao diện Dashboard: tổng quan thu chi, chi tiêu theo danh mục, danh sách giao dịch gần nhất hiển thị đúng dữ liệu
- Rà soát và cập nhật lại dữ liệu mẫu (danh mục, giao dịch minh họa) cho phù hợp với mốc thời gian trình bày trong đồ án

## Khó khăn gặp phải
- Máy cá nhân ban đầu chưa cài .NET Runtime phù hợp với phiên bản project (.NET 8), cần cài đặt bổ sung để chạy thử chương trình
- Một số cấu hình Git ban đầu (remote, refspec) bị thiết lập sai khi mới làm quen với quy trình push code lên GitHub, đã khắc phục xong

## Kế hoạch tuần tới
- Hoàn thiện xử lý các warning liên quan đến non-nullable property (CS8618) trong Models
- Bổ sung chức năng thống kê chi tiêu theo tháng/danh mục chi tiết hơn ở trang Thống kê
- Viết tài liệu báo cáo đồ án (nội dung phần Chương 1 - Tổng quan) vào thư mục thesis
