using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public interface  IDataRepo
    {
        Task<IEnumerable<SchoolData>> GetSchoolDataByEmail(string email);
        void AddSchoolData(SchoolData schoolData);
        Task<bool> GetSchoolDataByAccessCode(string accessCode);
        Task AddBookingDataAsync(BookingData bookingData);
    }
}
