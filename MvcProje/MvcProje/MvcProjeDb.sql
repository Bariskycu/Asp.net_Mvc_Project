create database CarShop
go
use CarShop
go
create table Urun
(UrunId int identity,
Baslik nvarchar(50),
ResimYol ntext,
Fiyat nvarchar(50),
Marka nvarchar(50),
Model nvarchar(50),
Yakit nvarchar(50),
Vites nvarchar(50),
KasaTipi nvarchar(50),
Renk nvarchar(50),
Kategori int,
ResimId int,
Constraint Pk_UrunId Primary key(UrunId)
)
go
create table Giris
(GirisId int identity,
Ad nvarchar(50),
Soyad nvarchar(50),
Email nvarchar(50),
KullaniciAdi nvarchar(50),
Sifre nvarchar(50),
Constraint Pk_GirisId Primary key(GirisId)
)
go
create table Marka
(
MarkaId int identity,
Marka nvarchar(50),
Constraint Pk_MarkaId Primary key(MarkaId)
)
go
create table Mesaj
(MesajId int identity,
Ad nvarchar(50),
Soyad nvarchar(50),
Telefon nvarchar(50),
Email nvarchar(50),
Mesaj ntext,
Constraint Pk_MesajId Primary key(MesajId)
)
go
create table AracTalip
(AracTalipId int identity,
Arac nvarchar(50),
Ad nvarchar(50),
Soyad nvarchar(50),
Telefon nvarchar(50),
Email nvarchar(50) NULL,
Mesaj ntext,
Constraint PK_AracTalipId Primary key(AracTalipId)
)
go
create table Resimler
(ResimlerId int identity,
ResimYolu ntext,
ResimId int,
Constraint Pk_ResimlerId Primary key(ResimlerId)
)