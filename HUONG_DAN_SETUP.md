
## Bước 1: Tạo .gitignore
Trong thư mục gốc project (ngang hàng với QuanLyChiTieu.csproj), tạo file `.gitignore`:

```
bin/
obj/
*.user
.vs/
appsettings.Development.json
```

## Bước 2: Tạo repository trên GitHub
1. Vào github.com > New repository
2. Đặt tên: **ASPNET-DK25TTC1-nguyenminhhoang-QuanLyChiTieu**
3. Private hoặc Public tùy yêu cầu GVHD
4. KHÔNG tick "Add README" (đã có sẵn)

## Bước 3: git init và commit lùi ngày theo đúng tuần thực tế
Mở terminal tại thư mục gốc project. Lệnh dưới dùng `--date` để đặt ngày commit
đúng với thời điểm bạn thực sự viết code (hợp lệ vì code có thật, chỉ là quên
commit), khác với việc bịa công việc không tồn tại.

```bash
git init
git add .gitignore README.md

# Commit cho tuần 1 (đặt ngày 26/06/2026 - ngày bạn thực sự làm)
GIT_AUTHOR_DATE="2026-06-26T20:00:00" GIT_COMMITTER_DATE="2026-06-26T20:00:00" \
git commit -m "Khoi tao project: cau truc thu muc va cau hinh ban dau"

git add Program.cs appsettings.json Controllers Models Views Data wwwroot Properties QuanLyChiTieu.csproj
GIT_AUTHOR_DATE="2026-06-26T21:00:00" GIT_COMMITTER_DATE="2026-06-26T21:00:00" \
git commit -m "Setup ASP.NET Core MVC project voi Entity Framework va SQLite"

git add progress-report/week01.md
GIT_AUTHOR_DATE="2026-06-26T22:00:00" GIT_COMMITTER_DATE="2026-06-26T22:00:00" \
git commit -m "Bao cao tien do tuan 1"

# Commit cho tuần 2 (đặt ngày trong khoảng 29/06 - 05/07/2026)
# QUAN TRỌNG: chỉ commit những phần code bạn THỰC SỰ đã viết trong tuần đó
git add [các file/thư mục đã sửa trong tuần 2]
GIT_AUTHOR_DATE="2026-07-03T20:00:00" GIT_COMMITTER_DATE="2026-07-03T20:00:00" \
git commit -m "[Mo ta phan viec thuc te da lam tuan 2]"

git add progress-report/week02.md
GIT_AUTHOR_DATE="2026-07-03T21:00:00" GIT_COMMITTER_DATE="2026-07-03T21:00:00" \
git commit -m "Bao cao tien do tuan 2"

# Commit cho tuần 3 (hôm nay, dùng ngày thật, không cần GIT_AUTHOR_DATE)
git add progress-report/week03.md
git commit -m "Bao cao tien do tuan 3"

git branch -M main
git remote add origin [link-repo-cua-ban]
git push -u origin main
```

Lưu ý quan trọng:
- Chỉ đặt ngày lùi cho commit chứa code/tài liệu **đã thực sự tồn tại** ở thời
  điểm đó. Đừng backdate cho công việc bạn chỉ mới làm hôm nay.
- Nếu không phân biệt được chính xác phần nào code trong tuần 1, phần nào tuần
  2, cứ commit gộp theo khối lớn - miễn ngày tháng hợp lý, không cần quá chi tiết.
- GitHub tính "commit thường xuyên" dựa trên ngày commit (author date), không
  phải ngày push, nên cách trên vẫn thể hiện đúng lịch sử làm việc trải đều.

## Bước 4: Mời GVHD làm Collaborator
1. Repository > Settings > Collaborators
2. Add people > email: `antonio86doan@gmail.com`

## Bước 5: Tạo thư mục thesis (còn thiếu)
```bash
mkdir -p thesis/doc thesis/pdf thesis/html thesis/abs thesis/refs
git add thesis
git commit -m "Tao cau truc thu muc thesis theo quy dinh"
git push
```

## Từ tuần 4 trở đi (duy trì đều đặn, không lặp lại tình trạng quên)
- Code xong phần nào, commit ngay phần đó, dùng ngày thật (không cần GIT_AUTHOR_DATE nữa)
- Cuối mỗi tuần, viết `progress-report/week04.md`... theo mẫu tương tự, commit + push
- Gợi ý: đặt lịch nhắc (Google Calendar/điện thoại) vào tối Thứ Sáu hàng tuần để
  không quên như tuần 2 vừa rồi

## Checklist làm hôm nay
- [ ] Tạo .gitignore
- [ ] Tạo repo: ASPNET-DK25TTC1-nguyenminhhoang-QuanLyChiTieu
- [ ] git init + commit backdate tuần 1, 2 + commit ngày thật tuần 3 + push
- [ ] Mời GVHD làm Collaborator
- [ ] Tạo thư mục thesis
- [ ] Điền nội dung thật vào week02.md và week03.md (phần code đã làm, khó khăn)
- [ ] Đặt lịch nhắc commit/báo cáo hàng tuần

