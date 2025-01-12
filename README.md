# 🍽️ Restoran Menü/Sipariş Yönetim Sistemi

Bu proje, restoranlar için geliştirilmiş kapsamlı bir **ASP.NET Core MVC** uygulamasıdır. Yönetim paneliyle restoran operasyonlarını kolaylaştırır, kullanıcılar için ise menü ve sipariş süreçlerini pratik hale getirir. **SignalR** entegrasyonu ile anlık bildirim desteği sunar.

---

## 🚀 Özellikler

### 🛠️ Admin Paneli
- **Kategori ve Ürün İşlemleri**:
  - Kategoriler ve ürünler ekleyebilir, düzenleyebilir ve silebilirsiniz.
- **Sipariş Yönetimi**:
  - Kullanıcı siparişlerini listeleyebilir ve detaylarını görüntüleyebilirsiniz.
- **Masa Yönetimi**:
  - Masalar ekleyebilir, düzenleyebilir ve silebilirsiniz.
  - Masalara özel QR kodlar oluşturabilirsiniz.
- **Mail Gönderme**:
  - Kullanıcılara veya diğer e-posta adreslerine özel mailler gönderebilirsiniz.
- **Kupon Yönetimi**:
  - Sepetlere özel kuponlar tanımlayabilirsiniz.
- **Kullanıcı Yönetimi**:
  - Kullanıcı kaydedebilir, kayıtlı kullanıcıları ve adminleri görüntüleyebilirsiniz.
- **Rezervasyon Yönetimi**:
  - Rezervasyon taleplerini görüntüleyebilir ve onaylayabilirsiniz.
  - Onaylanan rezervasyonlar için kullanıcıya otomatik onay maili gönderilir.
- **İletişim Formları**:
  - Kullanıcıların gönderdiği iletişim formlarını görüntüleyebilir ve sorunları "Çözüldü" olarak işaretleyebilirsiniz.

### 🌐 Kullanıcı Arayüzü
- **Menü Görüntüleme**:
  - Restoran menüsünü kategorilere göre görüntüleyebilirsiniz.
- **Rezervasyon Talebi**:
  - Rezervasyon talepleri oluşturabilirsiniz.
- **İletişim Formu**:
  - Restoran yönetimiyle iletişime geçmek için form doldurabilirsiniz.
- **Masa QR Kodları**:
  - Masalara özel QR kodlar bulunmaktadır. QR kod okutulduğunda masaya özel bir sayfa açılır:
    - **Garson Çağırma**: Masaya garson çağırabilirsiniz.
    - **Hesap İsteme**: Hesap talebinde bulunabilirsiniz.
    - **Sipariş Verme**: Masaya sipariş oluşturabilirsiniz.
  - Bu işlemler **SignalR** entegrasyonu sayesinde admin paneline anlık bildirim olarak iletilir.

---

## 🔧 Teknolojiler ve Araçlar
- **.NET 9**: Uygulamanın geliştirilmesi için kullanılan framework.
- **ASP.NET Core MVC**: Web uygulaması geliştirme.
- **Entity Framework Core**: Veritabanı yönetimi.
- **SignalR**: Anlık bildirim ve iletişim.
- **MSSQL**: Veritabanı yönetim sistemi.
- **MailKit**: E-posta gönderimi.

---

---

## 🛠️ Kurulum ve Çalıştırma

### Gereksinimler
- **.NET 9 SDK**
- **MSSQL Server**
- **Visual Studio , Rider veya VS Code**

### Proje Depolarını Klonlayın

   ```bash
   git clone https://github.com/erennali/Web_Dersi_Final_Proje.git
