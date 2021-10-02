using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorQRCode.Controllers
{
    public class QrCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputLink)
        {
            if (inputLink != null && inputLink != "")
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(inputLink, QRCodeGenerator.ECCLevel.Q);
                QRCode qRCode = new QRCode(qrCodeData);
                Bitmap qrCodeBitmap = qRCode.GetGraphic(20);
                return View(BitmapToBytes(qrCodeBitmap));
            }
            return View();
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
