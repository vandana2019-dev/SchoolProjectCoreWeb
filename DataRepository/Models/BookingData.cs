using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
	[Table("BookingDataNew")]
    public class BookingData
    {
		[Key]
		public int Id { get; set; }
		public string AccessCode { get; set; }
		public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
