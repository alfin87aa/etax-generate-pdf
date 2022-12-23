using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etax_generate_pdf.Models;
using Microsoft.Net.Http.Headers;
using System.Xml.Serialization;
using WkHtmlToPdfDotNet;
using RazorLight;
using WkHtmlToPdfDotNet.Contracts;
using System.Globalization;

namespace etax_generate_pdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaRetur : ControllerBase
    {
        private readonly EtaxContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConverter _converter;

        public NotaRetur(EtaxContext context, IHttpClientFactory httpClientFactory, IConverter converter)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _converter = converter;
        }

        private async Task<String?> GetFakturPajak(string url)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                    { HeaderNames.Accept, "application/xml" },
                    { HeaderNames.AcceptEncoding , "gzip, deflate, br" },
                    { HeaderNames.Connection , "keep-alive" },
                    { HeaderNames.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var response = await httpResponseMessage.Content.ReadAsStringAsync();      
                
                return response;
            }
            return null;
        }

        [HttpGet("{ReturNumber}")]
        public async Task<Object> Get(string ReturNumber)
        {
            var param = ReturNumber.Replace("%2F", "/");
            var query2 = from r in _context.Returs
						 from v in _context.Set<VatIn>().Where(v => r.TaxNumber == v.TaxNumber).DefaultIfEmpty()
                         from c in _context.Set<MasterVendor>().Where(c => r.Npwp == c.Npwp).DefaultIfEmpty()
                         where r.ReturNumber == param.ToString()
                         select new {r,v.Url, c.Address};

			var returs = await query2.FirstOrDefaultAsync();


			if (returs == null)
                return NotFound();
                   
            DJP? dataFP = new DJP();

            if (returs.Url != null)
            {
                //var url = "http://svc.efaktur.pajak.go.id/validasi/faktur/010011021055000/0002237651452/3031300D06096086480165030402010500042011CD8614B8BD68BD64DDC8F4C16FB17AE686EB28BCCF9CE79A228BF92DCDA804";
                var url = returs.Url;
				for (var i = 0; i < 10; i++)
                {
                    var resposeDjp = await GetFakturPajak(url);

                    if (resposeDjp != null)
                    {
                        // Deserialize the XML document into an object
                        XmlSerializer serializer = new XmlSerializer(typeof(DJP));
                        using (TextReader reader = new StringReader(resposeDjp))
                        {
                            dataFP = serializer.Deserialize(reader) as DJP;
                        }
                        break;
                    }
                }
            }
            else
            {
                dataFP.NomorFaktur = returs.r.TaxNumber;
                dataFP.TanggalFaktur = returs.r.TaxDate?.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                dataFP.NamaPenjual = returs.r.Name;
                dataFP.NpwpPenjual = returs.r.Npwp;
                dataFP.AlamatPenjual = returs.Address;
                dataFP.JumlahDpp = (double)returs.r.Dpp;
                dataFP.JumlahPpn = (double)returs.r.Ppn;
                dataFP.JumlahPpnBm = (double)returs.r.Ppnbm;
            }

			dataFP.ReturNumber = returs.r.ReturNumber;
            dataFP.ReturDate = returs.r.ReturDate;

            var engine = new RazorLightEngineBuilder().UseFileSystemProject(Directory.GetCurrentDirectory())
                                                      .UseMemoryCachingProvider()
                                                      .Build();

            var htmlContent = await engine.CompileRenderAsync(Path.GetFileName("NotaRetur.cshtml"), dataFP);

            IDocument document = CreateDocument("Nota Retur", htmlContent);
            byte[] content = _converter.Convert(document);

            return File(content, "application/pdf", $"Nota Retur {returs.r.ReturNumber}.pdf");
        }

        private static IDocument CreateDocument(string title, string htmlContent)
        {
            return new HtmlToPdfDocument
            {
                GlobalSettings =
                    {
                        ColorMode = ColorMode.Grayscale,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        //Margins = new MarginSettings { Top = 20, Bottom = 20 },
                        DocumentTitle = title,
                    },
                Objects =
                    {
                        new ObjectSettings
                        {
                            //PagesCount = true,
                            HtmlContent = htmlContent,
                            WebSettings = { DefaultEncoding = "utf-8" },
                            //FooterSettings =
                            //{
                            //    FontSize = 9,
                            //    Right = "Page [page] of [toPage]",
                            //    Line = true,
                            //    Spacing = 2.5,
                            //},
                        },
                    },
            };
        }
    }
}
