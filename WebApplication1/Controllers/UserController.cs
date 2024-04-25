using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data;

namespace WebApplication1.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Users()
    {
        DataSet users = new User().GetUsers();
        List<string> rows = new List<string>();
        List<string> columns = new List<string>();
        List<List<string>> table = new List<List<string>>();
        foreach (DataTable dt in users.Tables)
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
    
    public IActionResult Login(string username, string password)
    {
        new User().CreateUser(username, password);
        return RedirectToAction("Users");
    }
}