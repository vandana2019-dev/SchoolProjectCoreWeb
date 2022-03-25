using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    [Table("ParentData")]
    public class ParentData
    {
		[Key]
		public int Id { get; set; }
		public string AccessCode { get; set; }
		public string EmailAddress { get; set; }
		public int StudentId { get; set; }
		public int BookingDataId { get; set; }
		public int SchoolDataId { get; set; }
	}
}
