//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ReconsB.Data;
//using ReconsB.model;
//using ReconsB.model.DTOs;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ReconsB.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class InvoiceController : Controller
//    {
//        private readonly AddDbContext _dbContext;

//        public InvoiceController(AddDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        [Route("/invoice")]
//        [HttpGet]
//        public async Task<IActionResult> GetInvoices()
//        {
//            var invoices = await _dbContext.Invoice.ToListAsync();
//            return Ok(invoices);
//        }

//        [Route("/invoice")]
//        [HttpPost]
//        public async Task<IActionResult> PostInvoice([FromForm] InvoiceDto request, IFormFile file)
//        {
//            // Create a single invoice entity
//            var invoiceEntity = await CreateInvoiceEntity(request, file);

//            if (invoiceEntity == null)
//            {
//                return BadRequest("Invalid invoice data.");
//            }

//            await _dbContext.invoice.AddAsync(invoiceEntity);
//            await _dbContext.SaveChangesAsync();

//            return Ok("Invoice posted successfully");
//        }

//        [Route("/invoices")]
//        [HttpPost]
//        public async Task<IActionResult> PostInvoices([FromForm] List<InvoiceDto> requests, [FromForm] List<IFormFile> files)
//        {
//            if (requests.Count != files.Count)
//            {
//                return BadRequest("The number of invoices and files must match.");
//            }

//            var invoiceEntities = new List<Invoice>();

//            for (int i = 0; i < requests.Count; i++)
//            {
//                var invoiceEntity = await CreateInvoiceEntity(requests[i], files[i]);

//                if (invoiceEntity == null)
//                {
//                    return BadRequest($"Invalid data for invoice at index {i}.");
//                }

//                invoiceEntities.Add(invoiceEntity);
//            }

//            await _dbContext.invoice.AddRangeAsync(invoiceEntities);
//            await _dbContext.SaveChangesAsync();

//            return Ok("Invoices posted successfully");
//        }

//        private async Task<Invoice> CreateInvoiceEntity(InvoiceDto request, IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//            {
//                return null;  
//            }

//            if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
//            {
//                return null;  
//            }

//            var invoiceEntity = new Invoice
//            {
//                FileName = request.FileName,
//                Type = request.Type,
//                FromCompany = request.FromCompany,
//                InvoiceDate = request.InvoiceDate,
//                DueDate = request.DueDate,
//                Reference = request.Reference,
//                InvoiceNumber = request.InvoiceNumber,
//                PONumber = request.PONumber,
//                CustomerNumber = request.CustomerNumber,
//                PaymentTerms = request.PaymentTerms,
//                InvoiceAmount = request.InvoiceAmount,
//                Currency = request.Currency,
//                TotalTax = request.TotalTax,
//                TotalAmount = request.TotalAmount,
//                Status = request.Status,
//                SecurityChecks = request.SecurityChecks,
//                ContactId = request.ContactId,
//                ErpSupplierName = request.ErpSupplierName,
//                FileType = file.ContentType
//            };

//            using (var memoryStream = new MemoryStream())
//            {
//                await file.CopyToAsync(memoryStream);
//                invoiceEntity.FileData = memoryStream.ToArray(); 
//            }

//            return invoiceEntity;
//        }
//    }
//}