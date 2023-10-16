use dbRestoran

select * from tbSiparis


insert into tbMenu (MenuKodu,MenuIcerigi,MenuFiyati) values 
('Patapata Menu','Hamburger1 + Patates',100),
('Dabadaba Menu','Hamburger2 + Patates',110),
('Çaçaça Menu','Hamburger3 + Patates',120),
('Veveve Menu','Hamburger4 + Patates',130);

--insert into tbFatura (FaturaNo,FaturaTarihi,FaturaTutari) values();

delete from tbMasalar
insert into tbMasalar (MasaNo) values
('Masa1'),
('Masa2'),
('Masa3'),
('Masa4'),
('Masa5'),
('Masa6');

create table tbIcecekler
(
ID int identity (1,1),
IcecekAdi nvarchar(50) primary key,
)


insert into tbIcecekler (IcecekAdi) values
('Kola'),
('Fanta'),
('IceTea'),
('Ayran'),
('Sprite'),
('Su');

create table tbSoslar
(
ID int identity (1,1),
SosAdi nvarchar(50) primary key
)

insert into tbSoslar (SosAdi) values
('Ketçap'),
('Mayonez'),
('RangeSos'),
('Barbekü'),
('Hardal');

create table tbBoylar
(
ID int identity (1,1),
BoyAdi nvarchar(50) primary key,
)


insert into tbBoylar (BoyAdi) values
('Normal'),
('Orta'),
('Büyük');

select * from tbSiparis
insert into tbFiyatlar (UrunKodu,UrunAdi,SatisFiyati) values
('Menu1','Patapata Menu',100),
('Menu2','Dabadaba Menu',110),
('Menu3','Çaçaça Menu',120),
('Menu4','Veveve Menu',130),
('Ýçecek1','Kola',35),
('Ýçecek2','Fanta',35),
('Ýçecek3','IceTea',35),
('Ýçecek4','Ayran',25),
('Ýçecek5','Sprite',35),
('Ýçecek6','Su',10),
('Sos1','Ketçap',5),
('Sos2','Mayonez',5),
('Sos3','RangeSos',5),
('Sos4','Barbekü',5),
('Sos5','Hardal',5),
('Boy1','Normal',0),
('Boy2','Orta',5),
('Boy3','Büyük',10);

