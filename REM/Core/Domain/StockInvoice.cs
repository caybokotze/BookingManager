using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REM.Core.Domain
{
    public class StockInvoice
    {
        public int Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
        

        #region Entity Framework Mappings

        public ICollection<InvoicePersonLink> InvoicePersonLinks { get; set; }
        public ICollection<StockInvoiceList> StockInvoiceLists { get; set; }
        public int RatesId { get; set; }
        public Rate Rates { get; set; }

        #endregion
    }

    public class InvoicePersonLink
    {
        public int Id { get; set; }

        #region Entity Framework Mappings
        //Linked: One instance of person.
        public int PersonId { get; set; }
        public Person Person { get; set; }
        //Linked: One instance of invoice.
        public int StockInvoiceId { get; set; }
        public StockInvoice Invoice { get; set; }

        #endregion
    }

    public class StockInvoiceList
    {
        public int Id { get; set; }

        #region Entity Framework Mappings

        public int StockInvoiceId { get; set; }
        public StockInvoice StockInvoice { get; set; }
        public int StockItemId { get; set; }
        public StockItem StockItems { get; set; }


        #endregion
    }

    public class StockItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Cost { get; set; }

        #region Entity Framework Mappings

        public ICollection<StockInvoiceList> StockInvoiceLists { get; set; }
        public int MarkupId { get; set; }
        public Markup Markup { get; set; }
        #endregion
    }






}