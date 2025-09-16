##BookDemo Projesi

Bu proje, **ASP.NET Core Web API** kullanılarak geliştirilmiş basit bir kitap yönetim sistemidir.  
Entity Framework Core ile **SQL Server veritabanı** üzerinden CRUD (Create, Read, Update, Delete) işlemleri yapılabilmektedir.

---

## 🚀 Kullanılan Teknolojiler ve Paketler

- **ASP.NET Core 9.0** → Web API geliştirme altyapısı  
- **Entity Framework Core 9.0.9**
  - `Microsoft.EntityFrameworkCore` → ORM (Object-Relational Mapper)  
  - `Microsoft.EntityFrameworkCore.SqlServer` → SQL Server sağlayıcısı  
  - `Microsoft.EntityFrameworkCore.Design` → Migration ve tasarım zamanı araçları  
  - `Microsoft.EntityFrameworkCore.Tools` → EF Core CLI komutları  
- **Swashbuckle.AspNetCore (9.0.4)** → Swagger/OpenAPI dokümantasyonu  
- **SQL Server** → Veritabanı

---

## 📂 Proje Yapısı

BookDemo

│── Entities

│ └── Models

│ └── Book.cs # Kitap model sınıfı

││── Web API

│├── Controllers

│ │└── BooksController.cs # Kitap CRUD API

│ ├── Data

│ │ ├── ApplicationContext.cs # EF Core DbContext

│ │ └── Config

│ │ └── BookConfig.cs # Entity yapılandırmaları

│ ├── Migrations # EF Core Migration dosyaları

│ ├── appsettings.json # Veritabanı connection string ayarları

│ └── Program.cs # API başlangıç noktası


---

## 📖 API Endpointleri

| HTTP Metodu | Endpoint               | Açıklama |
|-------------|------------------------|----------|
| GET         | `/api/books`           | Tüm kitapları getirir |
| GET         | `/api/books/{id}`      | ID’ye göre kitap getirir |
| POST        | `/api/books`           | Yeni kitap ekler |
| PUT         | `/api/books/{id}`      | Var olan kitabı günceller |
| DELETE      | `/api/books/{id}`      | ID’ye göre kitap siler |
| DELETE      | `/api/books`           | Tüm kitapları siler |

---

## 🛠 Kurulum ve Çalıştırma

1. **Projeyi klonlayın**
   ```bash
   git clone https://github.com/Arsedy/BookDemo.git
   cd BookDemo
  - Veritabanı bağlantısını yapılandırın
  - appsettings.json içinde connection string ayarlayın:

  - "sqlConnection": "Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = BooksApp; Integrated Security = true ;"

2. **Programı Başlatma** : "BookDemo.sln" tıklayın ve projeyi başlatın Swagger UI açılcaktır. 

  - Migration çalıştırın ve veritabanını oluşturun

  - Swagger UI üzerinden test edin

📌 Notlar
- Bu proje öğrenme amaçlı geliştirilmiştir.

- Entity Framework Core ile Code-First yaklaşımı kullanılmıştır.

- Migration dosyaları Migrations klasöründe tutulmaktadır.

- API dokümantasyonu Swagger (OpenAPI) ile otomatik olarak oluşturulmaktadır.
