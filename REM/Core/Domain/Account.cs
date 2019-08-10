using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using REM.Logic;

namespace REM.Core.Domain
{

    public class Account : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public int PersonId { get; set; }
        public int PersonDetailId { get; set; }

        #region Entity Framework Mappings
        public Person Person { get; set; }
        public PersonDetail PersonDetail { get; set; }

        public ICollection<ProfileImageLink> ProfileImageLinks { get; set; }
        public ICollection<AccountBookingLink> AccountBookingLinks { get; set; }
        public ICollection<AccountCommentLink> AccountCommentLinks { get; set; }
        public ICollection<AccountMaintenanceLink> AccountMaintenanceLinks { get; set; }
        public ICollection<AccountCleaningLink> AccountCleaningLinks { get; set; }
        #endregion
    }


    public class PersonDetail
    {


        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string Address { get; set; }
        public string CellPhoneNumber { get; set; }



        #region Entity Framework Mappings
        //Linked: Single Instance of Person.
        //Note: This connection is compulsory.
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        //linked: Bookings.
        public ICollection<PersonDetailsBookingLink> PersonDetailsBookingLinks { get; set; }
        //linked: Maintenance workers. One to many.
        public ICollection<AccountMaintenanceLink> AccountMaintenanceLinks { get; set; }
        //linked: Cleaning person links. One to many.
        public ICollection<AccountCleaningLink> AccountCleaningLinks { get; set; }

        #endregion
    }

    public class Person
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }

        #region Entity Framework
        public ICollection<AccountBookingLink> AccountBookingLinks { get; set; }
        public ICollection<InvoicePersonLink> InvoicePersonLinks { get; set; }

        #endregion
    }

    public class AccountBookingLink
    {
        [Key]
        public int Id { get; set; }
        //This is to track who made the booking.
        public bool CreatedBooking { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        #region Entity Framework Mappings.
        //LINKED: Single instance of person.
        public Account Account { get; set; }
        //LINKED: Single instance of booking.
        public Booking Booking { get; set; }
        #endregion
    }

    public class PersonAddedToBooking
    {
        [Key]
        public int Id { get; set; }
        //
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        //
        [ForeignKey("AccountBookingLink")]
        public int AccountBookingLinkId { get; set; }
        //
        #region Entity Framework Mappings
        public Person Person { get; set; }
        public AccountBookingLink AccountBookingLink { get; set; }
        #endregion
    }

    public class PersonDetailsBookingLink
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
        #region Entity Framework Mappings
        //Linked: to a single instance of person details.
        public int PersonDetailsId { get; set; }
        public PersonDetail PersonDetail { get; set; }
        //Linked: to a single instance of person booking link.
        public int PersonBookingLinkId { get; set; }
        public AccountBookingLink PersonBookingLink { get; set; }
        //Linked: 
        #endregion
    }

    public class Staff
    {
        public int Id { get; set; }
        public string ResidentialAddress { get; set; }
        public string BankAccountNumber { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Department
    {
        [Key]
        public int Id { get; set; }
        //
        [Required(ErrorMessage = "Please enter the department name")]
        [Display(Name = "Department Name")]
        [DataType(DataType.Text)]
        [StringLength(PConstants.ShortNameLength, ErrorMessage = "The name you entered should be less than 50 characters.")]
        public string Name { get; set; }
    }

    public class StaffRole
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the staff role for this person.")]
        [Display(Name = "Staff Role")]
        [DataType(DataType.Text)]
        [StringLength(PConstants.ShortNameLength, ErrorMessage = "The name you entered should be less than 50 characters.")]
        public int Name { get; set; }
    }

    public class ProfileImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileDir { get; set; }
        public DateTime CreatedAt { get; set; }

    }

    public class ProfileImageLink
    {
        public int Id { get; set; }
        [ForeignKey("Profile")]
        public int ProfileImageId { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        #region Entity Framework Mappings
        public ProfileImage ProfileImage { get; set; }
        public Account Account { get; set; }
        #endregion
    }

    


}

//public PersonDetails(IdentityUser user)
//{
//    this.Id = user.Id;
//    this.AccessFailedCount = user.AccessFailedCount;
//    //Claims = user.Claims;
//    this.AccessFailedCount = user.AccessFailedCount;
//    this.Email = user.Email;
//    this.EmailConfirmed = user.EmailConfirmed;
//    this.LockoutEnabled = user.LockoutEnabled;
//    this.LockoutEndDateUtc = user.LockoutEndDateUtc;
//    this.PasswordHash = user.PasswordHash;
//    //this.Logins = user.Logins;
//    this.PhoneNumber = user.PhoneNumber;
//    this.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
//    //this.Roles = user.Roles;
//    this.SecurityStamp = user.SecurityStamp;
//    this.TwoFactorEnabled = user.TwoFactorEnabled;
//    this.UserName = user.UserName;
//}