using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REM.Core.Domain
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public DateTime AddedAt => DateTime.Now;

        [Display(Name = "Registered Business Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Date Registered")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EstablishedAt { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "Business Tax Number")]
        public string TaxNumber { get; set; }

        [StringLength(15)]
        [Display(Name = "Business Vat Number")]
        public string VatNumber { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "Business Registration Number")]
        public string BusinessNumber { get; set; }

        #region Entity Framework Mappings
        

        //LINKED: Business Branches
        public ICollection<BusinessBranchLink> BusinessBranchLinks { get; set; }
        #endregion

    }

    public class BusinessBranch
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [StringLength(14, MinimumLength = 10)]
        [Display(Name = "Telephone Number")]
        public string TelNumber { get; set; }

        [StringLength(255)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [StringLength(255)]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [StringLength(50)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        #region Entity Framework Mappings.
        //Linked: One instance of Business
        public ICollection<BusinessBranchLink> BusinessBranchLinks { get; set; }
        public ICollection<BranchBookingLink> BranchBookingLinks { get; set; }
        public ICollection<DirectorsLink> DirectorsLinks { get; set; }
        #endregion

    }


    public class BranchBookingLink
    {
        [Key]
        public int Id { get; set; }

        #region Entity Framework Mappings

        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int BusinessBranchId { get; set; }
        public BusinessBranch BusinessBranch { get; set; }

        #endregion
    }

    public class BusinessBankDetails
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        //

        #region Entity Framework Mappings
        public ICollection<BusinessBankDetailsLink> BankDetailsLinks { get; set; }
        #endregion

    }

    public class BusinessBankDetailsLink
    {
        public int Id { get; set; }
        public int BusinessBranchId { get; set; }
        public BusinessBranch BusinessBranch { get; set; }
        public int BusinessBankDetailsId { get; set; }
        public BusinessBankDetails BusinessBankDetails { get; set; }
    }

    public class BusinessBranchLink
    {
        public int Id { get; set; }
        public int BusinessBranchId { get; set; }
        public BusinessBranch BusinessBranch { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }

    public class DirectorsLink
    {
        public int Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;

        #region Entity Framework Mappings
        public int PersonDetailsId { get; set; }
        public AccountBookingLink PersonDetails { get; set; }
        public int BusinessBranchId { get; set; }
        public BusinessBranch BusinessBranch { get; set; }
        #endregion

    }

}