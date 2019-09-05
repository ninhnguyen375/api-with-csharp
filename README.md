# DEMO Code API với .Net core 2.2
- Clone source về.
- Cài mariadb.
- Mở file appsetting.json sử lại thông số DB theo máy (user, pass, db).
- Mở terminal tại thư mục vừa clone về.
- Trên terminal, chạy lệnh: 
```
dotnet restore
```
- Dựng lại cấu trúc cho db
```
dotnet ef database update
```
- Chạy project
```
dotnet run
```
- NOTE: restart mỗi khi code thay đổi: 
```
dotnet watch run
```
### GET: 
https://localhost:5001/api/users