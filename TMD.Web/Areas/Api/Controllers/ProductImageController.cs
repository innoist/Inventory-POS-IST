using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using TMD.Models.RequestModels;

namespace TMD.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Product Image Api for thumbnail size image
    /// </summary>
    public class ProductImageController : ApiController
    {
        // GET api/<controller>/fileName.jpg
        [Route("~/api/Product/Thumbnail")]
        public HttpResponseMessage Get([FromUri] ProductImageRequest request)
        {
            if (string.IsNullOrEmpty(request?.ImageName))
            {
                return null;
            }

            string path = HttpContext.Current.Server.MapPath("~/" + ConfigurationManager.AppSettings["InventoryImage"] + request.ImageName);
            HttpResponseMessage response = new HttpResponseMessage();
            // load it up
            using (Bitmap bmp = new Bitmap(path))
            {
                var fs = new FileStream(HttpContext.Current.Server.MapPath("~/" + ConfigurationManager.AppSettings["InventoryImage"] + @"\I"  + request.ImageName), FileMode.Create);
                bmp.Save(fs, ImageFormat.Png);
                bmp.Dispose();
                
                Image img = Image.FromStream(fs);
                fs.Close();
                fs.Dispose();

                int h = img.Height;
                int w = img.Width;
                int b = h > w ? h : w;
                double per = (b > 120) ? (120 * 1.0) / b : 1.0;
                h = (int)(h * per);
                w = (int)(w * per);

                // create the thumbnail image
                using (Image img2 =
                          img.GetThumbnailImage(w, h,
                          () => false,
                          IntPtr.Zero))
                {
                    // emit it to the response stream
                    MemoryStream ms = new MemoryStream();
                    img2.Save(ms, ImageFormat.Png);
                    response.Content = new ByteArrayContent(ms.ToArray());
                    ms.Close();
                    ms.Dispose();
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
            }
        }

    }
}