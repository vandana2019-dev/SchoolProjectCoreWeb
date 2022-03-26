using DataRepository;
using DataRepository.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolProjectCoreWeb.Models;
using System.Diagnostics;

namespace SchoolProjectCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepo _dataRepo;

        public HomeController(ILogger<HomeController> logger, IDataRepo dataRepo)
        {
            _logger = logger;
            _dataRepo = dataRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SchoolRegistration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SchoolRegistration(SchoolData schoolData)
        {
            ModelState.Remove("AccessCode");
            if (!ModelState.IsValid)
                return View(schoolData);

            var isEmailAvailable = await _dataRepo.GetSchoolDataByEmail(schoolData.EmailAddress);
            if (isEmailAvailable.Any())
            {
                TempData["Error"] = "Email Address already exists";
                return View(schoolData);
            }
            _dataRepo.AddSchoolData(schoolData);
            return View();
        }

        public IActionResult MakeBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeBooking(BookingData bookingData)
        {
            //ModelState.Remove("AccessCode");
            if (!ModelState.IsValid)
                return View(bookingData);

            var isAccessCode = await _dataRepo.GetSchoolDataByAccessCode(bookingData.AccessCode);
            if (isAccessCode)
            {
                await _dataRepo.AddBookingDataAsync(bookingData);
            }
            else
            {
                TempData["Error"] = "Invalid access code";
                return View(bookingData);
            }

            ModelState.Clear();
            return View(new BookingData());
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string emailAddress, string password)
        {
            var schoolData = await _dataRepo.SchoolLogin(emailAddress, password);

            if(schoolData == null)
            {
                TempData["Error"] = "Invalid Email Address and Password";
                return View();
            }

            return View(schoolData);
        }
    }
}