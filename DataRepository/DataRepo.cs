using Dapper;
using Dapper.Contrib.Extensions;
using DataRepository.DataConnection;
using DataRepository.Models;

namespace DataRepository
{
    public class DataRepo : IDataRepo
    {
        private readonly DapperContext _repository;

        public DataRepo(DapperContext repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SchoolData>> GetSchoolDataByEmail(string email)
        {
            var query = "select * from schooldata where EmailAddress = @email";

            using (var conn = _repository.CreateCommonConnection())
            {
                return await conn.QueryAsync<SchoolData>(query, new { email });

            }
        }
        public void AddSchoolData(SchoolData schoolData)
        {
            using (var conn = _repository.CreateCommonConnection())
            {
                var accessCode = new Random();
                schoolData.AccessCode = accessCode.Next(100,200).ToString();
                schoolData.CreatedDate = DateTime.Now;
                schoolData.UpdatedDate = DateTime.Now;

                conn.Insert(schoolData);
            }


        }

        public async Task<bool> GetSchoolDataByAccessCode(string accessCode)
        {
            var query = "select AccessCode from schooldata where AccessCode = @accessCode";
            using (var conn = _repository.CreateCommonConnection())
            {
                var schoolData = await conn.QueryAsync<SchoolData>(query, new { accessCode });

                return schoolData.Any() ? true : false;
            }
        }
        public async Task AddBookingDataAsync(BookingData bookingData)
        {
            var isAccessCodeExists = await GetSchoolDataByAccessCode(bookingData.AccessCode);
            if (isAccessCodeExists)
            {
                using (var conn = _repository.CreateCommonConnection())
                {
                    bookingData.CreatedDate = DateTime.Now;
                    bookingData.UpdatedDate = DateTime.Now;
                    conn.Insert(bookingData);
                }
            }
           
        }

       
    }
}
