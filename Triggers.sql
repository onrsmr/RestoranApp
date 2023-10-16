select * from tbSatis
select * from tbSiparis

CREATE TRIGGER tr_SiparisToSatis
ON tbSiparis
AFTER INSERT
AS
BEGIN
    -- Yeni eklenen sipari�lerin her biri i�in i�lemler yap�l�r
    DECLARE @SiparisNo NVARCHAR(50)
    DECLARE @Sat�sNo NVARCHAR(50)
    
    -- Yeni eklenen sipari�in bilgilerine eri�im
    SELECT @SiparisNo = SiparisNo FROM INSERTED

    -- Sat�� numaras�n� olu�tur
    SET @Sat�sNo = 'STS' + RIGHT('0000' + CAST((SELECT COUNT(*) FROM tbSatis) + 1 AS NVARCHAR(10)), 4)

    -- Yeni sat�� kayd�n� tbSatis tablosuna ekle
    INSERT INTO tbSatis (Sat�sNo, SiparisNo, Tarih, UrunAdi, Miktar, ToplamFiyat)
    SELECT @Sat�sNo, @SiparisNo, Tarih, UrunAdi, Miktar, ToplamFiyat
    FROM INSERTED
END

