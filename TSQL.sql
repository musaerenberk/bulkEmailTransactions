use sl2146473_Udemy
go
create table Musteri
(
ID int identity(1,1) primary key,
Ad nvarchar(40),
Soyad nvarchar(40),
EmailAdres nvarchar(100),
KuponKOD nvarchar(10),
KuponDurum bit,
KuponAktifTarih datetime
)
go

create proc [udemyegitim].[KayitEKLE]
(
@Ad nvarchar(40),
@Soyad nvarchar(40),
@EmailAdres nvarchar(100)
)
as
begin
insert into Musteri (Ad,Soyad,EmailAdres) values (@Ad,@Soyad,@EmailAdres)
end

go

create proc [udemyegitim].[KuponKODAta]
(
@ID int,
@KuponKOD nvarchar(10),
@KuponDurum bit
)
as
begin
update Musteri
set 
KuponKOD = @KuponKOD,
KuponDurum = @KuponDurum
where 
ID = @ID
end

go

create proc [udemyegitim].[KuponKODGuncelle]
(
@KuponKOD nvarchar(10)
)
as
begin
update Musteri
set 
KuponDurum = 1,
KuponAktifTarih = getdate()
where
KuponKOD = @KuponKOD
end

go

create proc [udemyegitim].[KuponKODKontrol]
(
@KuponKOD nvarchar(10)
)
as
begin
select coalesce(count(*),0) from Musteri where KuponKOD = @KuponKOD 
end

go

create proc [udemyegitim].[MusteriGetirID]
(
@ID int
)
as
begin
select * from musteri where ID = @ID
end

go

create proc [udemyegitim].[MusteriKuponKODARA]
(
@KuponKOD nvarchar(10)
)
as
begin
select * from musteri where KuponKOD = @KuponKOD
end

go

create proc [udemyegitim].[MusteriListe]
as
begin
select * from Musteri
end