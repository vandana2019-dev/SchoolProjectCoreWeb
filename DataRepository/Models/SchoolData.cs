using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

namespace DataRepository.Models
{
    [Table("SchoolData")]
	public class SchoolData
    {
		[Key]
		public int Id { get; set; }

        [DisplayName("Email")]
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("School Name")]
        [Required(ErrorMessage = "Test")]
         
		public string SchoolName { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Write(false)]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string AccessCode { get; set; }


	}
}
