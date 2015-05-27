using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Framework;
using Framework.Core.Localized;
using Framework.Data;

namespace EPS.Models
{
    [TableName("Users")]
    [PrimaryKey("UserId")]
    public class UserEntry
    {
        [Column("UserId")]
        public int UserId { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("User Name")]
        [Remote("CheckUserName", "Users", ErrorMessage = "{0} already used, please select another.")]
        [Column("UserName")]
        public string UserName { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Password")]
        [LocalizedStringLength(20, MinimumLength = 6, ErrorMessage = "Please enter {0} between {1} and {2} characters long.")]
        [Column("Password")]
        public string Password { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Email")]
        [Remote("CheckEmail", "Users", ErrorMessage = "{0} already used, please select another.")]
        [Column("Email")]
        public string Email { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("First Name")]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Last Name")]
        [Column("LastName")]
        public string LastName { get; set; }

        [LocalizedDisplay("Language")]
        [Column("Language")]
        public string Language { get; set; }
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }
        [Column("CreatedTime")]
        public DateTime? CreatedTime { get; set; }
        [Column("ChangedBy")]
        public string ChangedBy { get; set; }
        [Column("ChangedTime")]
        public DateTime? ChangedTime { get; set; }

        [LocalizedDisplay("Reenter Password")]
        [LocalizedStringLength(20, MinimumLength = 6, ErrorMessage = "Please enter {0} between {1} and {2} characters long.")]
        [LocalizedCompare("Password", ErrorMessage = "{0} and {1} does not match.")]
        [Ignore]
        public string NonPassword { get; set; }
    }
}
