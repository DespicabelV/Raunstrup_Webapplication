using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Data;
using Raunstrup_Webapplication.Models;


namespace Raunstrup_Webapplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Allan_Temp_API : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Allan_Temp_API(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Allan_Temp_API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomerModel()
        {
            return await _context.CustomerModel.ToListAsync();
        }

        // GET: api/Allan_Temp_API/Offer
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferModel>> GetCustomerModel(int id)
        {
            var offerModel = await _context.OfferModel.FindAsync(id);

            if (offerModel == null)
            {
                return NotFound();
            }

            return offerModel;
        }

        [Produces("application/json")]
        [HttpGet("Search")]
        public IActionResult Search()
        {
            try
            {
                string Filter_ID = HttpContext.Request.Query["ID"].ToString(); //Http request bliver lavet her
                var ID = _context.OfferModel.Where(o => Convert.ToString(o.Offer_ID).Contains(Filter_ID))
                    .Select(o => Convert.ToString(o.Offer_ID).ToList()); //Select bliver lavet her
                return Ok(ID);
            }
            catch
            {
                return BadRequest();
            }
        }



        //[HttpGet]
        //public async Task<IActionResult> Index(int id)
        //{
        //    var offerModel = await _context.OfferModel.FirstOrDefaultAsync(o => o.Offer_ID == id);

        //    return IA;
        //}

        // PUT: api/Allan_Temp_API/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomerModel(int id, CustomerModel customerModel)
        //{
        //    if (id != customerModel.Costumor_Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customerModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Allan_Temp_API
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<CustomerModel>> PostCustomerModel(CustomerModel customerModel)
        //{
        //    _context.CustomerModel.Add(customerModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomerModel", new { id = customerModel.Costumor_Id }, customerModel);
        //}

        // DELETE: api/Allan_Temp_API/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<CustomerModel>> DeleteCustomerModel(int id)
        //{
        //    var customerModel = await _context.CustomerModel.FindAsync(id);
        //    if (customerModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CustomerModel.Remove(customerModel);
        //    await _context.SaveChangesAsync();

        //    return customerModel;
        //}

        //private bool CustomerModelExists(int id)
        //{
        //    return _context.CustomerModel.Any(e => e.Costumor_Id == id);
        //}
    }

    public class OfferPrint
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public OfferPrint(IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
        }

        #region Declaration
        int _maxColumn = 6;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(6);
        PdfPCell _pdfCell;
        MemoryStream _memoryStream = new MemoryStream();

        List<OfferModel> _offerModels = new List<OfferModel>();

        #endregion

        public byte[] Print(List<OfferModel> offerModels)
        {
            _offerModels = offerModels;

            _document = new Document();
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(5f, 5f, 5f, 5f);

            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter docWrite = PdfWriter.GetInstance(_document,_memoryStream);

            _document.Open();

            float[] sizes = new float[_maxColumn];
            for (var i = 0; i < _maxColumn; i++)
            {
                if (i==0)
                {
                    sizes[i] = 20;
                }
                else
                {
                    sizes[i] = 100;
                }
            }

            _pdfTable.SetWidths(sizes);

            this.ReportHeader();
            this.EmptyRow(2);
            this.OfferBody();

            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);

            _document.Close();

            return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            _pdfCell = new PdfPCell(this.AddLogo());
            _pdfCell.Colspan = 1;
            _pdfCell.Border = 0;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell=new PdfPCell(this.SetPageTitle());
            _pdfCell.Colspan = _maxColumn - 1;
            _pdfCell.Border = 0;
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();
        }

        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            string path = _hostEnvironment.WebRootPath + "/Images";

            string imgCombine = Path.Combine(path, "Raunstruplogo.png");
            Image img = Image.GetInstance(imgCombine);
            _pdfCell = new PdfPCell(img);
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);

            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private PdfPTable SetPageTitle()
        {
            int maxColumn = 6;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfCell=new PdfPCell(new Phrase("Offer Information", _fontStyle));
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private void EmptyRow(int nCount)
        {
            for (int i = 0; i <= nCount; i++)
            {
                _pdfCell=new PdfPCell(new Phrase("",_fontStyle));
                _pdfCell.Colspan = _maxColumn;
                _pdfCell.Border = 0;
                _pdfCell.ExtraParagraphSpace = 10;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();
            }
        }

        private void OfferBody()
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);

            #region Detail Table Header

            _pdfCell = new PdfPCell(new Phrase("Id", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Title", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Start Date", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("End Date", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Price", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Customer Id", fontStyleBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.Gray
            };
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();
            #endregion

            #region Detail Table Body

            foreach (var offerModel in _offerModels)
            {
                _pdfCell = new PdfPCell(new Phrase(offerModel.Offer_Title, _fontStyle))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BackgroundColor = BaseColor.Gray
                };
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(offerModel.Offer_ID.ToString(), _fontStyle))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BackgroundColor = BaseColor.Gray
                };
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(offerModel.Start_date.ToShortDateString(), _fontStyle))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BackgroundColor = BaseColor.Gray
                };
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(offerModel.End_Date.ToShortDateString(), _fontStyle))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BackgroundColor = BaseColor.Gray
                };
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(offerModel.Offer_Price.ToString(), _fontStyle))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BackgroundColor = BaseColor.Gray
                };
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(offerModel.ForeignKey1_.Costumor_Id.ToString(), _fontStyle))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    BackgroundColor = BaseColor.Gray
                };
                _pdfTable.AddCell(_pdfCell);

                _pdfTable.CompleteRow();
            }

            #endregion
        }
    }

}
