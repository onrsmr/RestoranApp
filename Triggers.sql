select * from tbSatis
select * from tbSiparis

CREATE TRIGGER tr_SiparisToSatis
ON tbSiparis
AFTER INSERT
AS
BEGIN
    -- Yeni eklenen sipariþlerin her biri için iþlemler yapýlýr
    DECLARE @SiparisNo NVARCHAR(50)
    DECLARE @SatýsNo NVARCHAR(50)
    
    -- Yeni eklenen sipariþin bilgilerine eriþim
    SELECT @SiparisNo = SiparisNo FROM INSERTED

    -- Satýþ numarasýný oluþtur
    SET @SatýsNo = 'STS' + RIGHT('0000' + CAST((SELECT COUNT(*) FROM tbSatis) + 1 AS NVARCHAR(10)), 4)

    -- Yeni satýþ kaydýný tbSatis tablosuna ekle
    INSERT INTO tbSatis (SatýsNo, SiparisNo, Tarih, UrunAdi, Miktar, ToplamFiyat)
    SELECT @SatýsNo, @SiparisNo, Tarih, UrunAdi, Miktar, ToplamFiyat
    FROM INSERTED
END

