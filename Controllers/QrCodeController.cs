
using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using QrCode.Models;


namespace QrCode.Controllers
{
    public class QrCodeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public QrCodeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(QrCodeModel qrCode)
        {
            try
            {
                GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(qrCode.QRUrl, 200);
                barcode.AddBarcodeValueTextBelowBarcode();
                // Style
                barcode.SetMargins(10);
                barcode.ChangeBarCodeColor(Color.CadetBlue);
                string path = Path.Combine(_environment.WebRootPath, "GeneratedQRCode/qrcode.png");
                barcode.SaveAsPng(path);
                string fileName = Path.GetFileName(path);
                string imageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
                ViewBag.QrCodeUri = imageUrl;

                
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(qrCode);
        }

        
    }
}
