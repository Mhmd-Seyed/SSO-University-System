# 🎓 University SSO System

### Selçuk Üniversitesi – Merkezi Kimlik Doğrulama ve Yetkilendirme Sistemi

Bu proje, Selçuk Üniversitesi bünyesinde kullanılan farklı otomasyon sistemlerinin **Tek Şifre Sistemi (Single Sign-On – SSO)** aracılığıyla ortak bir kimlik doğrulama altyapısına entegre edilmesini amaçlamaktadır.

Kullanıcılar tek bir üniversite hesabıyla giriş yapabilecek, farklı uygulamalara yeniden şifre girmeden erişebilecek ve sahip oldukları roller arasından seçim yaparak yetkilerine uygun işlemleri gerçekleştirebilecektir.

## 🎯 Projenin Amacı

Projenin temel amacı, üniversite uygulamaları için güvenli, merkezi ve yönetilebilir bir kimlik doğrulama sistemi geliştirmektir.

Sistem sayesinde:

- Kullanıcılar tek hesapla birden fazla uygulamaya erişebilecek.
- Kullanıcı rolleri ve yetkileri merkezi olarak yönetilebilecek.
- Bir kullanıcı birden fazla role sahip olabilecek.
- Yetkisiz erişimler engellenecek.
- Uygulamalar arasında güvenli oturum yönetimi sağlanacak.

## 🔗 Entegre Edilecek Sistemler

| Uygulama | Açıklama | Rol Sayısı |
|---|---|---|
| **OBS** | Öğrenci Bilgi Sistemi | 7 |
| **Yemekhane Otomasyonu** | Yemek rezervasyonu ve yönetimi | 3 |
| **Kütüphane Otomasyonu** | Kitap ve kütüphane işlemleri | 3 |
| **Toplam** | | **13** |

Bu uygulamalar farklı geliştirme ekipleri tarafından hazırlanacak ve merkezi SSO sistemimize entegre edilecektir.

## ⚙️ Kullanılacak Teknolojiler

| Teknoloji | Kullanım Amacı |
|---|---|
| ASP.NET Core | Backend geliştirme |
| ASP.NET Core Identity | Kullanıcı ve hesap yönetimi |
| Entity Framework Core | Veritabanı işlemleri |
| Microsoft SQL Server | Veritabanı yönetimi |
| OpenIddict | Kimlik doğrulama sunucusu altyapısı |
| OpenID Connect | Merkezi kimlik doğrulama |
| OAuth 2.0 | Güvenli yetkilendirme |

## 🔐 SSO Çalışma Mantığı

1. Kullanıcı OBS, Yemekhane veya Kütüphane uygulamasına giriş yapmak ister.
2. İlgili uygulama kullanıcıyı merkezi SSO giriş sayfasına yönlendirir.
3. Kullanıcı e-posta adresi ve şifresiyle kimliğini doğrular.
4. Sistem kullanıcının ilgili uygulamadaki rollerini kontrol eder.
5. Tek rolü varsa doğrudan giriş yapılır; birden fazla rolü varsa rol seçimi yapılır.
6. Kullanıcının erişim yetkisi yoksa giriş engellenir.
7. Kullanıcı seçtiği rolün yetkileriyle ilgili uygulamaya yönlendirilir.

Kullanıcı başka bir uygulamaya geçtiğinde, merkezi oturumu geçerliyse yeniden şifre girmesine gerek kalmaz.

## 🛡️ Güvenlik ve Yetkilendirme

Sistemde **Rol Tabanlı Erişim Kontrolü (RBAC)** yaklaşımı kullanılacaktır.

- Her uygulamanın rolleri ve yetkileri ayrı tanımlanacaktır.
- Kullanıcı yalnızca kendisine atanmış rolleri seçebilecektir.
- İşlem bazlı yetkilendirme kontrolleri uygulanacaktır.
- Kullanıcı girişleri ve önemli işlemler kayıt altına alınacaktır.
- Kullanıcının rolü kaldırıldığında mevcut erişim yetkileri yeniden kontrol edilecek ve gerektiğinde oturumu geçersiz kılınacaktır.

## 👨‍💻 Proje Ekibi

Proje, dört kişilik bir ekip tarafından geliştirilmektedir. Görev dağılımı; sistem mimarisi, veritabanı, kimlik doğrulama, rol-yetki yönetimi ve uygulama entegrasyonlarını kapsamaktadır.

Geliştirme süreci GitHub üzerinden takip edilecektir.

## 📌 Proje Durumu

🚧 **Proje tasarım ve geliştirme aşamasındadır.**

Sistem mimarisi, veritabanı yapısı ve uygulama entegrasyonları geliştirme sürecinde tamamlanacaktır.

---

**Selçuk Üniversitesi – Bilgisayar Mühendisliği**

*University SSO System*
