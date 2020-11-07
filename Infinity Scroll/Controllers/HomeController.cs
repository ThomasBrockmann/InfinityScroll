using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infinity_Scroll.Models;

namespace Infinity_Scroll.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private const int BATCH_SIZE = 50;
        public IActionResult TestData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _TestData(string sortOrder, string searchString, int firstItem = 0)
        {
            List<TestData> testData = new List<TestData>();
            // Generate test data
            for (int i = 1; i < 500; i++)
            {
                testData.Add(new TestData() { Id = i, Field1 = "This is row " + i.ToString() });
            }

            // Sort and filter test data
            IEnumerable<TestData> query;
            if (sortOrder.ToLower() == "descending")
            {
                query = testData.OrderByDescending(m => m.Field1);
            }
            else
            {
                query = testData.OrderBy(m => m.Field1);
            }
            if (!String.IsNullOrEmpty(searchString)) query = query.Where(m => m.Field1.Contains(searchString));

            // Extract a portion of data
            var model = query.Skip(firstItem).Take(BATCH_SIZE).ToList();
            if (model.Count() == 0) return StatusCode(204);  // 204 := "No Content"
            return PartialView(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
