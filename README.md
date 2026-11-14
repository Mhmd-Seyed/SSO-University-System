# 🎓 University SSO System

### Selçuk Üniversitesi – Merkezi Kimlik Doğrulama ve Yetkilendirme Sistemi

Bu proje, üniversite bünyesinde kullanılan farklı otomasyon sistemlerinin **Tek Şifre Sistemi (Single Sign-On – SSO)** aracılığıyla ortak bir kimlik doğrulama altyapısına entegre edilmesini amaçlamaktadır.

Sistem sayesinde kullanıcılar tek bir üniversite hesabıyla giriş yapabilecek, yetkili oldukları uygulamalara yeniden şifre girmeden erişebilecek ve birden fazla role sahip olmaları durumunda kullanmak istedikleri rolü seçebilecektir.

> **Proje Durumu:** Tasarım ve geliştirme aşamasındadır. Selçuk Üniversitesi için hazırlanan akademik bir yazılım projesidir.

---

## 🎯 Projenin Amacı

Projenin temel amacı, üniversite uygulamalarında merkezi kimlik doğrulama, kullanıcı yönetimi ve rol tabanlı yetkilendirme altyapısı oluşturmaktır.

**Hedeflenen özellikler:**

- Tek hesapla birden fazla uygulamaya giriş yapılması.
- Kullanıcıların merkezi olarak kimlik doğrulaması.
- Uygulama bazlı rol ve yetki yönetimi.
- Bir kullanıcının birden fazla role sahip olabilmesi.
- Çoklu rol durumunda aktif rol seçimi.
- Yetkisiz uygulama ve işlem erişimlerinin engellenmesi.
- Güvenli oturum yönetimi.
- Rol değişikliklerinde mevcut erişim yetkilerinin yeniden değerlendirilmesi.

## 🏛️ Entegre Edilecek Uygulamalar

Merkezi SSO sistemine üç üniversite uygulamasının entegre edilmesi planlanmaktadır.

| Uygulama | Açıklama | Rol Sayısı |
|---|---|---|
| OBS | Öğrenci Bilgi Sistemi | 7 |
| Yemekhane Otomasyonu | Yemek rezervasyonu ve yönetimi | 3 |
| Kütüphane Otomasyonu | Kitap ve kütüphane işlemleri | 3 |
| **Toplam** | | **13** |

**Not:** Bu uygulamalar farklı geliştirme ekipleri tarafından hazırlanacaktır. Proje ekibimizin temel sorumluluğu merkezi SSO altyapısını geliştirmek ve uygulamalarla entegrasyonunu sağlamaktır.

## 👥 Kullanıcı Rolleri

### 1. Öğrenci Bilgi Sistemi (OBS)

| Rol | Temel Yetkiler |
|---|---|
| Öğrenci | Ders kaydı, not görüntüleme, transkript ve ders programı görüntüleme |
| Öğretim Üyesi | Not girme, ders ve devamsızlık yönetimi |
| Danışman | Danışmanlık öğrencilerini görüntüleme, ders kaydı onaylama |
| Bölüm Başkanı | Bölüm talepleri, ders görevlendirmeleri, bölüm raporları |
| Dekan | Fakülte raporları, akademik ve idari onay işlemleri |
| Bölüm Sekreteri | Evrak kaydı, başvuru takibi, duyuru işlemleri |
| Öğrenci İşleri | Öğrenci kayıtları, kayıt durumları ve belge işlemleri |

### 2. Yemekhane Otomasyonu

| Rol | Temel Yetkiler |
|---|---|
| Kullanıcı | Menü görüntüleme, rezervasyon oluşturma ve iptal etme |
| Görevli | Rezervasyon kontrolü, yemek hakkı doğrulama, teslim kaydı |
| Yönetici | Menü, kontenjan ve rapor yönetimi |

### 3. Kütüphane Otomasyonu

| Rol | Temel Yetkiler |
|---|---|
| Üye | Kitap arama, ayırtma, ödünç kayıtlarını görüntüleme |
| Kütüphaneci | Kitap ödünç verme, iade ve üyelik işlemleri |
| Yönetici | Kitap envanteri, ödünç kuralları ve rapor yönetimi |

Roller uygulamaya özel olarak tanımlanacaktır. Bir uygulamada Yönetici rolüne sahip olan kullanıcı, diğer uygulamalarda otomatik olarak yönetici yetkisi kazanmayacaktır.

## 🔐 SSO Çalışma Mantığı

1. Kullanıcı OBS, Yemekhane veya Kütüphane uygulamasına giriş yapmak ister.
2. Uygulama, kullanıcıyı merkezi SSO giriş ekranına yönlendirir.
3. Kullanıcı üniversite e-posta adresi ve şifresiyle kimliğini doğrular.
4. Sistem kullanıcının ilgili uygulamadaki aktif rollerini kontrol eder.
5. Kullanıcının tek rolü varsa doğrudan bu rolle devam edilir.
6. Birden fazla rolü varsa kullanıcıya rol seçim ekranı gösterilir.
7. Kullanıcının ilgili uygulamada geçerli rolü bulunmuyorsa erişim reddedilir.
8. Kimlik ve rol doğrulaması tamamlandıktan sonra kullanıcı ilgili uygulamaya güvenli biçimde yönlendirilir.

Kullanıcı daha sonra başka bir entegre uygulamaya geçtiğinde, merkezi SSO oturumu geçerliyse yeniden şifre girmesine gerek kalmaz. Ancak yeni uygulamadaki rolleri ve erişim yetkileri ayrıca değerlendirilir.

## ⚙️ Kullanılacak Teknolojiler

| Teknoloji | Kullanım Amacı |
|---|---|
| ASP.NET Core | Merkezi sistemin Backend altyapısı |
| ASP.NET Core Identity | Kullanıcı, şifre ve hesap yönetimi |
| Entity Framework Core | Veritabanı erişimi ve ilişkisel veri yönetimi |
| Microsoft SQL Server | Merkezi veritabanı |
| OpenIddict | OAuth 2.0 ve OpenID Connect sunucu altyapısı |
| OpenID Connect | Merkezi kimlik doğrulama protokolü |
| OAuth 2.0 | Güvenli yetkilendirme ve erişim belirteci işlemleri |
| GitHub | Sürüm kontrolü ve ekip çalışması |

## 🗄️ Veritabanı Yapısı

Merkezi sistemde kullanıcı, uygulama, rol ve yetki bilgilerinin yönetilmesi planlanmaktadır.

**Temel veri yapıları:**

- Kullanıcılar
- Uygulamalar
- Roller
- Yetkiler
- Kullanıcı-Rol İlişkileri
- Rol-Yetki İlişkileri
- Rol ve Birim Kapsamları
- Oturum ve Giriş Kayıtları
- Denetim Kayıtları

ASP.NET Core Identity'nin mevcut kullanıcı ve rol tablolarından yararlanılacak, uygulama bazlı rol yönetimi için gerektiğinde ek tablolar oluşturulacaktır.

OBS'deki akademik kayıtlar, Yemekhanedeki rezervasyonlar ve Kütüphanedeki kitap kayıtları ilgili uygulamaların kendi veritabanlarında tutulacaktır.

## 🛡️ Güvenlik ve Yetkilendirme

Sistemde rol tabanlı erişim kontrolü kullanılacaktır.

Planlanan güvenlik önlemleri:

- Güvenli parola saklama ve kimlik doğrulama.
- Uygulama bazlı rol ve yetki kontrolü.
- Aktif rolün sunucu tarafında doğrulanması.
- Yetkisiz erişimlerin engellenmesi.
- Giriş ve önemli işlemlerin kayıt altına alınması.
- Oturum ve erişim belirteçlerinin güvenli yönetimi.
- Rol kaldırıldığında erişim yetkilerinin yeniden kontrol edilmesi.
- Gerekli durumlarda oturumların ve erişim belirteçlerinin geçersiz kılınması.

**Önemli:** Rolün veritabanından kaldırılması, mevcut erişim belirteçlerini her durumda otomatik olarak geçersiz kılmaz. Bu nedenle rol değişikliklerinde yeniden yetkilendirme ve oturum iptali mekanizmaları uygulanacaktır.

Uygulamalar, işlem bazlı yetkilendirmeyi kendi Backend katmanlarında da gerçekleştirmekle sorumludur.

## 👨‍💻 Ekip Çalışması

Proje dört kişilik bir geliştirme ekibi tarafından yürütülmektedir.

Çalışmalar GitHub üzerinden takip edilecek ve geliştirme süreçleri görev paylaşımına göre gerçekleştirilecektir.

**Başlıca çalışma alanları:**

- Sistem mimarisi ve teknik analiz
- Merkezi kimlik doğrulama altyapısı
- Veritabanı ve kullanıcı yönetimi
- Rol ve yetkilendirme sistemi
- Uygulama entegrasyonları
- Güvenlik ve test çalışmaları
- Teknik dokümantasyon

## 🗺️ Proje Yol Haritası

- [ ] Gereksinim analizi ve sistem kapsamının kesinleştirilmesi
- [ ] Veritabanı ve ilişkisel model tasarımı
- [ ] ASP.NET Core Identity yapılandırması
- [ ] OpenIddict entegrasyonu
- [ ] Merkezi giriş ekranının geliştirilmesi
- [ ] Rol ve yetki yönetiminin geliştirilmesi
- [ ] Çoklu rol seçim mekanizmasının geliştirilmesi
- [ ] OBS entegrasyonu
- [ ] Yemekhane Otomasyonu entegrasyonu
- [ ] Kütüphane Otomasyonu entegrasyonu
- [ ] Oturum ve güvenlik kontrolleri
- [ ] Entegrasyon testleri
- [ ] Teknik dokümantasyon ve proje sunumu

## 📌 Proje Durumu

Proje geliştirme aşamasındadır.

Sistem mimarisi, veritabanı tasarımı, rol-yetki modeli ve uygulama entegrasyonları geliştirme süreci boyunca güncellenecektir.

Kurulum ve çalıştırma talimatları, proje altyapısı tamamlandıkça bu dosyaya eklenecektir.

---

**Selçuk Üniversitesi – Bilgisayar Mühendisliği**

*University SSO System – Akademik Yazılım Projesi*
