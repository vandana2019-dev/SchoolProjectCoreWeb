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
        Task<IEnumerable<ISchoolData>> GetSchoolDataByEmail(string email);
        void AddSchoolData(SchoolData schoolData);
        Task<bool> GetSchoolDataByAccessCode(string accessCode);
        Task AddBookingDataAsync(BookingData bookingData);

        Task<ISchoolData> SchoolLogin(string email, string password);
    }
}
