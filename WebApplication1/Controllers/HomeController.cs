using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using System.Data;

namespace WebApplication1.Controllers
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

        public IActionResult Users()
        {
			DataSet Users = new User().getUsers();
            List<string> rows = new List<string>();
            List<string> columns = new List<string>();
            List<List<string>> table = new List<List<string>>();
            foreach (DataTable dt in Users.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                    columns.Add(column.ColumnName);
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (object? cell in cells)
                        rows.Add(cell.ToString());
                }
            }
            table.Add(columns);
            table.Add(rows);
            return View(table);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
