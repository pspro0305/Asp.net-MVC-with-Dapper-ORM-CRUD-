using Asp.net_MVC_with_Dapper_ORM.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.net_MVC_with_Dapper_ORM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DataAccess"].ConnectionString);
        public ActionResult List()
        {
            List<Customer> customers = new List<Customer>();
            customers = db.Query<Customer>("Select * From Customers").ToList();
            return View(customers);
        }
        public ActionResult SaveData()
        {
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        public ActionResult SaveData(Customer customer)
        {
            Customer obj = new Customer();
            string sqlQuery = "Insert Into Customers (FirstName, LastName, Email) Values(@FirstName, @LastName, @Email)";
            int rowsAffected = db.Execute(sqlQuery, customer);
            return View(customer);
        }
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = new Customer();
            customer = db.Query<Customer>("Select * From Customers WHERE CustomerID =" + id, new { id }).SingleOrDefault();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                string sqlQuery = "UPDATE Customers set FirstName='" + customer.FirstName +
                         "',LastName='" + customer.LastName +
                         "',Email='" + customer.Email +
                         "' WHERE CustomerID=" + customer.CustomerID;

                int rowsAffected = db.Execute(sqlQuery);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer();
            customer = db.Query<Customer>("Select * From Customers WHERE CustomerID =" + id, new { id }).SingleOrDefault();
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                string sqlQuery = "Delete From Customers WHERE CustomerID = " + id;
                int rowsAffected = db.Execute(sqlQuery);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            Customer customer = new Customer();
            customer = db.Query<Customer>("Select * From Customers WHERE CustomerID =" + id, new { id }).SingleOrDefault();
            return View(customer);
        }
    }
}