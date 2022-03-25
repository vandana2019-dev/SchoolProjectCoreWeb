using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
	public class Status
	{
		[Key]
		public int Id { get; set; }
		public string StatusName { get; set; }

	}
}
