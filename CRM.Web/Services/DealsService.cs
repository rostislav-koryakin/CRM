﻿using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DinkToPdf;
using DinkToPdf.Contracts;
using CRM.Web.Models.Entities;
using CRM.Web.Data;

namespace CRM.Web.Services
{
    public class DealsService : IDealsService
    {
        private readonly AppDbContext _context;
        private readonly IConverter _converter;

        public DealsService(AppDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<IEnumerable<Deal>> GetAll()
        {
            return await _context.Deals
                .Include(d => d.Company)
                .Include(d => d.Contact)
                .Include(d => d.Salesman)
                .ToListAsync();
        }

        public async Task<PaginatedList<Deal>> GetPaginatedList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            var appDbContext = _context.Deals
                .Include(d => d.Company)
                .Include(d => d.Contact)
                .Include(d => d.Salesman)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                appDbContext = appDbContext.Where(d => d.Name.Contains(searchString)
                                                    || d.Company.Name.Contains(searchString)
                                                    || d.Contact.Email.Contains(searchString)
                                                    || d.Salesman.Email.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Name);
                    break;
                case "TotalAmount":
                    appDbContext = appDbContext.OrderBy(d => d.TotalAmount);
                    break;
                case "total_amount_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.TotalAmount);
                    break;
                case "Stage":
                    appDbContext = appDbContext.OrderBy(d => d.Stage);
                    break;
                case "stage_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Stage);
                    break;
                case "Contact":
                    appDbContext = appDbContext.OrderBy(d => d.Contact.Email);
                    break;
                case "contact_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Contact.Email);
                    break;
                case "Company":
                    appDbContext = appDbContext.OrderBy(d => d.Company.Name);
                    break;
                case "company_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Company.Name);
                    break;
                case "Salesman":
                    appDbContext = appDbContext.OrderBy(d => d.Salesman.Email);
                    break;
                case "salesman_desc":
                    appDbContext = appDbContext.OrderByDescending(d => d.Salesman.Email);
                    break;
                default:
                    appDbContext = appDbContext.OrderBy(d => d.Name);
                    break;
            }

            int pageSize = 10;

            return await PaginatedList<Deal>.CreateAsync(appDbContext.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public async Task<Deal> GetById(int? id)
        {
            return await _context.Deals
                .Where(d => d.Id == id)
                .Include(d => d.DealsProducts)
                    .ThenInclude(d => d.Product)
                .Include(d => d.Contact)
                .Include(d => d.Company)
                .Include(d => d.Salesman)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Create(Deal deal)
        {
            deal.CreatedDate = DateTime.Now;

            await _context.Deals.AddAsync(deal);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> Update(Deal deal)
        {
            deal.UpdatedDate = DateTime.Now;

            _context.Update(deal);

            var saveResult = await _context.SaveChangesAsync();
            
            return saveResult == 1;
        }

        public async Task<bool> Delete(int? id)
        {
            var deal = await _context.Deals.FindAsync(id);
            
            _context.Deals.Remove(deal);
            
            var deleteResult = await _context.SaveChangesAsync();

            return deleteResult == 1;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Deals.AnyAsync(d => d.Id == id);
        }

        public async Task<byte[]> CreateQuotePDF(int id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = await GetHTMLQuoteTemplate(id),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\css", "quoteTemplate.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);

            return file;
        }
    
        public async Task<string> GetHTMLQuoteTemplate(int id)
        {
            var deal = await GetById(id);

            string totalDealAmount = deal.TotalAmount.ToString();
            string date = System.DateTime.Today.Date.ToString("dd.MM.yyyy");
            string validUntilDate = System.DateTime.Today.AddDays(14).Date.ToString("dd.MM.yyyy");

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>");

            sb.Append(@"  <div><h1>Sales Quote</h1></div>");
            sb.AppendFormat(@"<div id='date'>
                                    <p align='right'>
                                        Date: {0}<br>
                                       Valid Until: {1}<br>
                                    </p>
                                </div>", date, validUntilDate);

            sb.Append(@"  <div id='org'>
                                    <p align='left'>From: <br>
                                        Fejklowicz Company<br>
                                        Warszawa Prosta 12<br>
                                        01-203<br>
                                    </p>
                                </div>");

            sb.AppendFormat(@"  <div id='customer'>
                                    <p align='left'>To: <br>
                                        {0}<br>
                                        {1}, {2}<br>
                                        {3}<br>
                                    </p>
                                </div>", deal.Company.Name, deal.Company.City, deal.Company.Street, deal.Company.ZipCode);
            sb.Append(@"
                                    <table align='center'>
                                    <tr>
                                        <th>Product Name</th>
                                        <th>Quantity</th>
                                        <th>Net Price $</th>
                                        <th>VAT</th>
                                    </tr>");

            foreach (var item in deal.DealsProducts)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", item.Product.Name, item.Quantity, item.Product.Price, item.Product.VAT);
            }
            
            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            sb.AppendFormat(@"<div>
                                <h3 align='center'> Net Total $: {0} </h3>
                            </div>", totalDealAmount);

            return sb.ToString();
        }
    }
}