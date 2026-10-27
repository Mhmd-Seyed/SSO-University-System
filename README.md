# 🔐 Tek Şifre Giriş Sistemi (SSO)

**Selçuk Üniversitesi Bitirme Projesi**

Bu proje, ASP.NET Core Identity ve OpenIddict kullanılarak geliştirilen bir Merkezi Kimlik Doğrulama (SSO) sistemidir. Öğrenci ve Yemekhane gibi farklı uygulamaların tek bir oturumla, güvenli bir şekilde (BFF mimarisi ile) entegre edilmesi hedeflenmektedir.

## 🚀 Teknolojiler
- **Backend:** ASP.NET Core, Identity, OpenIddict, Entity Framework Core, SQL Server
- **Frontend:** React, TypeScript

## 👥 Ekip ve Görev Dağılımı

Proje 6 haftalık bir süreçte, backend iki takıma bölünerek, frontend ise ortaklaşa geliştirilecektir:

* **1. Ekip (Veritabanı & Identity):** SQL Server, EF Core, Identity kurulumu, roller ve kullanıcı CRUD API'leri. (İlk 2 Hafta)
* **2. Ekip (SSO & OpenIddict):** OpenIddict ayarları, Authorization Code + PKCE akışı, istemci (Öğrenci/Yemekhane) yönlendirmeleri ve oturum yönetimi. (3. ve 4. Hafta)
* **Tüm Ekip (Frontend & Test):** React ekranlarının (Mock datadan gerçek API'ye) geliştirilmesi, SSO entegrasyonu ve uçtan uca testler. (Tüm Süreç)

## 📅 Takvim Özeti
- **1-2. Hafta:** Altyapı, Veritabanı ve Temel Yetkilendirme
- **3-4. Hafta:** SSO Akışı ve İstemci Entegrasyonları
- **5-6. Hafta:** Uçtan Uca Entegrasyon, Güvenlik Testleri ve Demo

devamı gelecek haftalarda gelecektir....
