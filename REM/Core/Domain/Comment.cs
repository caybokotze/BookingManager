using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace REM.Core.Domain
{
    public class Comment
    {
        public Comment()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Text)]
        [StringLength(1000, ErrorMessage = "One Comment can not be more than 1000 characters.")]
        public string Content { get; set; }

        #region Entity Framework Mappings

        public ICollection<CommentEditedAtLink> CommentEditedAtLinks { get; set; }
        public ICollection<AccountCommentLink> AccountCommentLinks { get; set; }
        public ICollection<MaintenanceReportComment> MaintenanceReportComments { get; set; }
        public ICollection<CleaningReportComment> CleaningReportComments { get; set; }
        

        #endregion
    }

    public class AccountCommentLink
    {
        public int Id { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        #region Entity Framework Mappings
        public Account Account { get; set; }
        public Comment Comment { get; set; }
        #endregion
    }

    public class CommentEditedAtLink
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CommentEditedAt")]
        public int CommentEditedAtId { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        #region Entity Framework Mappings
        public CommentEditedAt CommentEditedAt { get; set; }
        public Comment Comment { get; set; }
        #endregion
    }

    public class CommentEditedAt
    {
        public CommentEditedAt()
        {
            LastEdited = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastEdited { get; set; }
    }

    public class MaintenanceReportComment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MaintenanceReport")]
        public int MaintenanceReportId { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        
        #region Entity Framework Mappings

        public MaintenanceReport MaintenanceReport { get; set; }
        public Comment Comment { get; set; }

        #endregion
    }

    public class CleaningReportComment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CleaningReport")]
        public int CleaningReportId { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        #region Entity Framework Mappings

        public CleaningReport CleaningReport { get; set; }
        public Comment Comment { get; set; }

        #endregion
    }
}