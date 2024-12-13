using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SkiaSharp;

namespace WebProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // QR kodu oluştur
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);

                // SkiaSharp kullanarak QR kodu çiz
                using (SKBitmap bitmap = new SKBitmap(256, 256))
                using (SKCanvas canvas = new SKCanvas(bitmap))
                {
                    canvas.Clear(SKColors.White);

                    int moduleCount = squareCode.ModuleMatrix.Count;
                    float scale = 256f / moduleCount;

                    for (int y = 0; y < moduleCount; y++)
                    {
                        for (int x = 0; x < moduleCount; x++)
                        {
                            if (squareCode.ModuleMatrix[y][x])
                            {
                                canvas.DrawRect(x * scale, y * scale, scale, scale, new SKPaint { Color = SKColors.Black });
                            }
                        }
                    }

                    // QR kodunu PNG olarak kaydet
                    using (SKImage skImage = SKImage.FromBitmap(bitmap))
                    using (SKData data = skImage.Encode(SKEncodedImageFormat.Png, 100))
                    {
                        memoryStream.Write(data.ToArray(), 0, (int)data.Size);
                        ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }

            return View();
        }
    }
}