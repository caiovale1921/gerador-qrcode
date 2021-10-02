using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorQRCode.Models
{
    public class QrCodeClass
    {
        public Byte[] QrCodeImg { get; set; }

        public string QrText { get; set; }

        public QrCodeClass(string qrText)
        {
            QrText = qrText;
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(QrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qrCodeData);
            var qrCodeImg = qRCode.GetGraphic(20);
            QrCodeImg = BitmapToBytes(qrCodeImg);
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
