using QRCoder;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCQR.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult QR()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult  QR(string txtQRCORE)
        {
            ViewBag.txtQRCORE = txtQRCORE;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qrGenerator.CreateQrCode(txtQRCORE, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Width = 15;
            imgBarCode.Height = 15;
            using(System.Drawing.Bitmap bitmap = qRCode.GetGraphic(20))
            {
                using (MemoryStream ms =new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ViewBag.imageBytes = ms.ToArray();
                    
                }
            }
            return View();
        }

         
    }
    
}