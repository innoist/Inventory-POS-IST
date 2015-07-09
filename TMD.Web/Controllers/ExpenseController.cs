using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService expenseService;
        private readonly IExpenseCategoryService expenseCategoryService;

        public ExpenseController(IExpenseService expenseService, IExpenseCategoryService expenseCategoryService)
        {
            this.expenseService = expenseService;
            this.expenseCategoryService = expenseCategoryService;
        }
        //
        // GET: /Expense/
        public ActionResult Index()
        {
            IEnumerable<ExpenseModel> expenses = expenseService.GetAllExpenses().Select(x => x.CreateFromServerToClient());
            return View(expenses);
        }

        //
        // GET: /Expense/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Expense/Create
        public ActionResult Create(long? id)
        {
            ExpenseViewModel model = new ExpenseViewModel();
            model.ExpenseCategories = expenseCategoryService.GetAllExpenseCategories().Select(x => x.CreateFromServerToClient());
            if (id != null)
            {
                var expense = expenseService.GetExpense((long)id);
                if (expense != null)
                    model.ExpenseModel = expense.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /Expense/Create
        [HttpPost]
        public ActionResult Create(ExpenseViewModel evm)
        {
            try
            {
                if (evm.ExpenseModel.Id == 0)
                {
                    evm.ExpenseModel.RecCreatedBy = User.Identity.Name;
                    evm.ExpenseModel.RecCreatedDate = DateTime.Now;
                }
                evm.ExpenseModel.RecLastUpdatedBy = User.Identity.Name;
                evm.ExpenseModel.RecLastUpdatedDate = DateTime.Now;


                if (expenseService.AddExpense(evm.ExpenseModel.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Expense has been saved successfully.", IsSaved = true };
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Expense/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Expense/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Expense/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Expense/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
