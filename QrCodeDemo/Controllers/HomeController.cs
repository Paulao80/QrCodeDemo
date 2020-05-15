using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QrCodeDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string qrcode)
        {
            ViewBag.QRCodeImage = GerarQrCode(qrcode);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private string GerarQrCode(string texto)
        {

            string qrcodeimage;
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qr = new QRCodeGenerator();
                QRCodeData data = qr.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);
                using (Bitmap bitMap = code.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    qrcodeimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return qrcodeimage;
        }
    }
} 