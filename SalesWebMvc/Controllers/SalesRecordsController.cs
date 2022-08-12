using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate) // Get the initial and final date
        {
            if (!minDate.HasValue) // if the initial date does not have any value, an default value is chosen
            {
                minDate = new DateTime(2018, 1, 1); // Chance the year from 2018 to DateTime.Now.Year, if you change the seeding items
            }
            if (!maxDate.HasValue) // if the final date does not have any value, an default value is now
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd"); // Show on the /SalesRecords/SimpleSearch the initial an final value of the results
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate); // Find all the value in the date range
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate) // Get the initial and final date
        {
            if (!minDate.HasValue) // if the initial date does not have any value, an default value is chosen
            {
                minDate = new DateTime(2018, 1, 1); // Chance the year from 2018 to DateTime.Now.Year, if you change the seeding items
            }
            if (!maxDate.HasValue) // if the final date does not have any value, an default value is now
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd"); // Show on the /SalesRecords/GroupingSearch the initial an final value of the results
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate); // Find all the value in the date range
            return View(result);
        }
    }
}
