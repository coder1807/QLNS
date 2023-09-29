create database QLNhansu
go

use QLNhansu
go

create table Phongban (
	MaPB char(2),
	TenPB nvarchar(30),
	primary key (MaPB),
)

create table Nhanvien(
	MaNV char(6),
	TenNV nvarchar(20),
	Ngaysinh datetime,
	MaPB char(2),
	primary key (MaNV)
)

alter table Nhanvien
	add constraint fk_MaPB
	foreign key (MaPB)
	references Phongban(MaPB)
	go

insert into Phongban (MaPB,TenPB)
values ('1',N'Phòng ban Sale')
insert into Phongban (MaPB,TenPB)
values ('2',N'Phòng ban IT')

insert into Nhanvien (MaNV,TenNV,Ngaysinh,MaPB)
values ('111',N'Nguyễn Văn A','2005-02-20','1')
insert into Nhanvien (MaNV,TenNV,Ngaysinh,MaPB)
values ('222',N'Nguyễn Văn B','2001-10-15','2')
insert into Nhanvien (MaNV,TenNV,Ngaysinh,MaPB)
values ('333',N'Nguyễn Văn C','2000-10-11','2')

