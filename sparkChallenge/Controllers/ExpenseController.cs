using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sparkChallenge.Database;
using sparkChallenge.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sparkChallenge.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _db;

        public ExpenseController(AppDbContext db)
        {
            _db = db;

        }
        // GET: /<controller>/
        public async Task<ActionResult<List<Expense>>> Index()
        {
            var result = new List<Expense>();
            try
            {
                 result = await _db.Expenses.FromSqlRaw("SelectAllExpenses").ToListAsync();
                ViewData["Success"] = "Success";

            }
            catch (Exception ex)
            {
                ViewData["Success"] = "Fail";

            }

            return View(result);
        }

        public IActionResult CreateExpense()
        {
            return View();
        }

        public async Task<IActionResult> ModifyExpense(int id)
        {
            var result = new List<Expense>();

            try
            {
                result = await _db.Expenses.FromSqlRaw($"GetExpense {id}").ToListAsync();
                ViewData["Success"] = "Success";

            }
            catch (Exception ex)
            {
                ViewData["Success"] = "Fail";

            }
            return View("ModifyExpense", result);
        }


        [HttpPut]
        public async Task<IActionResult> ModifyExpense([Bind("title", "company", "amount", "date", "folio")] Expense expense)
        {
           
            try
            {
                await _db.Database.ExecuteSqlRawAsync($"UpdateExpense {expense.title},{expense.company},{expense.amount},{expense.date}");
                ViewData["Success"] = "Success";

            }
            catch (Exception ex)
            {
                ViewData["Success"] = "Fail";

            }

            return View("Index");
        }


       

        [HttpPost]
        public async Task<IActionResult> CreateExpense([Bind("title","company","amount","date","folio")] Expense expense)
        {
            try
            {
                await _db.Database.ExecuteSqlRawAsync($"CreateExpense {expense.title},{expense.company},{expense.amount},{expense.date}");
                ViewData["Success"] = "Success";

            }
            catch (Exception ex)
            {
                ViewData["Success"] = "Fail";

            }

            return View("CreateExpense");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            try
            {
                await _db.Expenses.FromSqlRaw($"DeleteExpense {id}").ToListAsync();
                ViewData["Success"] = "Success";

            }
            catch (Exception ex)
            {
                ViewData["Success"] = "Fail";

            }

            return View("Index");
        }
    }
}

