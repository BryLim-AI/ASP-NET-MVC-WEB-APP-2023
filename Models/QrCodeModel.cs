using System.ComponentModel.DataAnnotations;

namespace QrCode.Models
{

    public class QrCodeModel
    {
        public QrCodeModel()
        {
            QRUrl = "";
        }
        [Display(Name= "Enter URL Here:")]
        public string QRUrl { get; set; }

        [Display(Name = "QRCode Image")]
        public string QRCodeImagePath { get; set; }
    }
}
