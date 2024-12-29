using Microsoft.AspNetCore.Mvc;

namespace WebProje.MyViewComponents;

public class PrivacyPolicyViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var gizlilik = @"
                <p>Web sitemiz, kullanıcıların gizliliğini korumayı taahhüt eder. Bu politika, web sitemiz üzerinden toplanan kişisel bilgilerin nasıl kullanıldığı, saklandığı ve korunduğu hakkında bilgi vermektedir.</p>
                
                <h3>1. Toplanan Bilgiler</h3>
                <p>Web sitemizi ziyaret ettiğinizde aşağıdaki bilgiler toplanabilir:</p>
                <ul>
                    <li>Ad ve Soyad</li>
                    <li>E-posta adresi</li>
                    <li>Telefon numarası</li>
                    <li>IP adresi</li>
                    <li>Çerezler ve benzeri teknolojiler</li>
                </ul>
                
                <h3>2. Bilgilerin Kullanımı</h3>
                <p>Toplanan bilgiler şu amaçlarla kullanılabilir:</p>
                <ul>
                    <li>Hizmetlerimizi sunmak ve iyileştirmek</li>
                    <li>Kullanıcı deneyimini kişiselleştirmek</li>
                    <li>İletişim ve destek sağlamak</li>
                    <li>Yasal yükümlülükleri yerine getirmek</li>
                </ul>
                
                <h3>3. Bilgi Paylaşımı</h3>
                <p>Kişisel bilgileriniz aşağıdaki durumlar haricinde üçüncü taraflarla paylaşılmaz:</p>
                <ul>
                    <li>Yasal gereklilikler doğrultusunda</li>
                    <li>Kullanıcı onayı alındığında</li>
                    <li>Hizmet sağlayıcılarla anlaşmalar doğrultusunda</li>
                </ul>
                
                <h3>4. Güvenlik</h3>
                <p>Kişisel bilgilerinizin güvenliği bizim için önemlidir. Güvenlik önlemleri şunları içerir:</p>
                <ul>
                    <li>SSL (Güvenli Yuva Katmanı) teknolojisi</li>
                    <li>Veri şifreleme</li>
                    <li>Yetkilendirilmiş erişim</li>
                </ul>
                
                <h3>5. Çerezler (Cookies)</h3>
                <p>Web sitemiz, kullanıcı deneyimini iyileştirmek için çerezler kullanır. Çerez tercihlerinizi tarayıcı ayarlarından değiştirebilirsiniz.</p>
                
                <h3>6. Haklarınız</h3>
                <p>Kişisel bilgilerinizle ilgili şu haklara sahipsiniz:</p>
                <ul>
                    <li>Bilgilerinize erişim hakkı</li>
                    <li>Bilgilerinizi düzeltme hakkı</li>
                    <li>Bilgilerinizi silme hakkı</li>
                    <li>İşlemeyi sınırlama hakkı</li>
                </ul>
                
                <h3>7. İletişim</h3>
                <p>Gizlilik politikamızla ilgili sorularınız için bizimle iletişime geçebilirsiniz:</p>
                <ul>
                    <li><strong>E-posta:</strong> info@webproje.com</li>
                    <li><strong>Telefon:</strong> +90 505 091 09 00</li>
                </ul>
                
                <p>Bu gizlilik politikası, zaman zaman güncellenebilir. Güncellemeler web sitemiz üzerinden duyurulacaktır.</p>
            ";

            return View("Default", gizlilik);
        }
}