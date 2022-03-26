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
    public interface ISchoolData
    {
        // interface is a contract, we don't need access modifier for the properties
        int Id { get; set; }
        string EmailAddress { get; set; }
        string SchoolName { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        string AccessCode { get; set; }
    }
}
