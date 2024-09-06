# BookStore API

Bu proje, bir kitap mağazası için temel CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren basit bir RESTful API'dir.

## Özellikler

- Kitap listeleme
- Yeni kitap ekleme
- Belirli bir kitabı görüntüleme
- Kitap bilgilerini güncelleme
- (Henüz test edilmedi) Kitap silme

## Teknolojiler

- ASP.NET Core 6.0
- Entity Framework Core (InMemory provider)
- Swagger UI

## Kurulum

1. Bu repository'yi klonlayın
2. Proje dizinine gidin
3. `dotnet run` komutunu çalıştırın
4. Tarayıcınızda `http://localhost:5105/swagger/index.html` adresine giderek Swagger UI'ı açın

## API Endpoints

- GET /api/Book: Tüm kitapları listeler
- GET /api/Book/{id}: Belirli bir ID'ye sahip kitabı getirir
- POST /api/Book: Yeni bir kitap ekler
- PUT /api/Book/{id}: Belirli bir ID'ye sahip kitabı günceller
- DELETE /api/Book/{id}: Belirli bir ID'ye sahip kitabı siler (henüz test edilmedi)

## Örnek Kullanım

### Yeni Kitap Ekleme

POST /api/Book

Request Body:
{
  "title": "Yeni Test Kitabı",
  "genreId": 1,
  "pageCount": 200,
  "publishDate": "2023-06-15T00:00:00"
}

### Kitap Güncelleme

PUT /api/Book/4

Request Body:
{
  "title": "Güncellenmiş Test Kitabı",
  "genreId": 2,
  "pageCount": 250,
  "publishDate": "2023-06-20T00:00:00"
}

## Notlar

- Bu API, in-memory bir veritabanı kullanmaktadır. Bu nedenle, uygulama yeniden başlatıldığında tüm veriler sıfırlanacaktır.
- Uygulama başlatıldığında örnek veriler otomatik olarak yüklenmektedir.

## Gelecek Geliştirmeler

- Hata yönetiminin iyileştirilmesi
- Veri validasyonunun eklenmesi
- Daha karmaşık sorguların eklenmesi
- Gerçek bir veritabanına geçiş
- Birim testlerin eklenmesi

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır.
