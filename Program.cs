using Scaffolding.Data;
using Scaffolding.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Scaffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _db = new();

            #region Solve Question 1
            try
            {
                var q1 = _db.Customers.Select(c => new { c.FirstName, c.LastName, c.Email }).ToList();
                foreach (var item in q1)
                    Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 1:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 2
            try
            {
                var q2 = _db.Orders.Where(o => o.StaffId == 3).ToList();
                foreach (var order in q2)
                    Console.WriteLine($"OrderId: {order.OrderId}, StaffId: {order.StaffId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 2:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 3
            try
            {
                var q3 = _db.Products.Where(p => p.Category != null && p.Category.CategoryName == "Mountain Bikes").ToList();
                foreach (var p in q3)
                    Console.WriteLine(p.ProductName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 3:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 4
            try
            {
                var q4 = _db.Orders.GroupBy(o => o.StoreId)
                                   .Select(g => new { StoreId = g.Key, Count = g.Count() })
                                   .ToList();
                foreach (var g in q4)
                    Console.WriteLine($"Store {g.StoreId}: {g.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 4:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 5
            try
            {
                var q5 = _db.Orders.Where(o => o.ShippedDate == null).ToList();
                foreach (var o in q5)
                    Console.WriteLine($"Order {o.OrderId} not shipped");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 5:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 6
            try
            {
                var q6 = _db.Orders.GroupBy(o => o.Customer)
                                   .Select(g => new { Customer = g.Key, Count = g.Count() })
                                   .ToList();
                foreach (var c in q6)
                {
                    if (c.Customer != null)
                        Console.WriteLine($"{c.Customer.FirstName} {c.Customer.LastName} - Orders: {c.Count}");
                    else
                        Console.WriteLine($"Unknown customer - Orders: {c.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 6:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 7
            try
            {
                var q7 = _db.Products.Where(p => !p.OrderItems.Any()).ToList();
                foreach (var p in q7)
                    Console.WriteLine(p.ProductName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 7:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 8
            try
            {
                var q8 = _db.Stocks.Where(s => s.Quantity < 5).Select(s => s.Product).ToList();
                foreach (var p in q8)
                    Console.WriteLine(p.ProductName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 8:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 9
            try
            {
                var q9 = _db.Products.FirstOrDefault();
                if (q9 != null)
                    Console.WriteLine(q9.ProductName);
                else
                    Console.WriteLine("No products found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 9:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 10
            try
            {
                int modelYear = 2016;
                var q10 = _db.Products.Where(p => p.ModelYear == modelYear).ToList();
                foreach (var p in q10)
                    Console.WriteLine(p.ProductName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 10:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 11
            try
            {
                var q11 = _db.OrderItems
                             .GroupBy(oi => oi.Product)
                             .Select(g => new { Product = g.Key, Count = g.Count() })
                             .ToList();
                foreach (var p in q11)
                    Console.WriteLine($"{p.Product?.ProductName ?? "Unknown product"}: {p.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 11:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 12
            try
            {
                int categoryId = 6;
                var q12 = _db.Products.Count(p => p.CategoryId == categoryId);
                Console.WriteLine($"Category {categoryId} has {q12} products");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 12:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion

            #region Solve Question 13
            try
            {
                    var q13 = _db.Products.Any() ? _db.Products.Average(p => p.ListPrice) : 0;
                Console.WriteLine($"Average product price: {q13}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 13:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion
            #region Solve Question 14
            try
            {
                var q14 = _db.Products.OrderByDescending(p => p.ListPrice).FirstOrDefault();
                if (q14 != null)
                    Console.WriteLine($"Most expensive product: {q14.ProductName} at {q14.ListPrice}");
                else
                    Console.WriteLine("No products found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 14:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion
            #region Solve Question 15
            try
            {
                var q15 = _db.Products.OrderBy(p => p.ListPrice).FirstOrDefault();
                if (q15 != null)
                    Console.WriteLine($"Cheapest product: {q15.ProductName} at {q15.ListPrice}");
                else
                    Console.WriteLine("No products found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Question 15:");
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            #endregion
        }
    }
}