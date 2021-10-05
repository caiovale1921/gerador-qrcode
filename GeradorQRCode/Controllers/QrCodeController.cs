using GeradorQRCode.Models;
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
            if (!string.IsNullOrEmpty(inputLink))
            {
                QrCodeClass qrCodeClass = new QrCodeClass(qrText: inputLink);
                return View(qrCodeClass);
            }
            return View();
        }
    }
}
