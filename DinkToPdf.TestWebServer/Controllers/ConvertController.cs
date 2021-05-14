using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DinkToPdf.TestWebServer.Controllers
{
    [Route("api/[controller]")]
    public class ConvertController : Controller
    {
        private IConverter _converter;

        public ConvertController(IConverter converter)
        {
            _converter = converter;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A3,
                    Orientation = Orientation.Landscape,
                },

                Objects = {
                    new ObjectSettings()
                    {
                        Page = "http://google.com/",
                    },
                     new ObjectSettings()
                    {
                        Page = "https://github.com/",

                    }
                }
            };

            byte[] pdf = _converter.Convert(doc);


            return new FileContentResult(pdf, "application/pdf");
        }
    }
}
