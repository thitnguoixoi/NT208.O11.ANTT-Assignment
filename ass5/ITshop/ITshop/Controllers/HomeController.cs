using ITshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITshop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        protected void SaveToFile(string filePath, string data)
        {
            System.IO.File.AppendAllText(Server.MapPath(filePath), data);
        }
        [HttpPost]
        public ActionResult SubmitForm(string name, string email, string message)
        {
            // Logic for handling the contact form
            string filePath = "~/App_Data/ContactForm.txt";
            string data = $"Name: {name}\nEmail: {email}\nMessage: {message}\n\n";

            SaveToFile(filePath, data);

            return RedirectToAction("Index");
        }
        public ActionResult ProductDisplay()
        {
            // Get the path to the Products.txt file
            string filePath = Server.MapPath("~/App_Data/Products.txt");

            // Read all lines from the file
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Create a list to store products
            List<Product> productList = new List<Product>();

            // Parse each line and create Product objects
            foreach (string line in lines)
            {
                string[] values = line.Split('|');
                if (values.Length == 7)
                {
                    Product product = new Product
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1],
                        Price = decimal.Parse(values[2]),
                        Quantity = int.Parse(values[3]),
                        Brand = values[4],
                        Description = values[5],
                        ImageUrl = values[6]
                    };

                    productList.Add(product);
                }
                else
                {
                    // Handle invalid data format
                    // You might want to log this or handle it according to your requirements
                }
            }
            return View(productList);
        }

        public ActionResult Delete(string id)
        {
            // Read the existing products from the file
            string filePath = Server.MapPath("~/App_Data/Products.txt");
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Pass the lines variable to the view along with the product ID
            ViewBag.Lines = lines;
            ViewBag.ProductId = id;

            return View();
        }

        public ActionResult Edit(int id)
        {
            // Your existing code to read data from the file
            string filePath = Server.MapPath("~/App_Data/Products.txt");
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Find the product with the given ID
            string productToUpdate = lines.FirstOrDefault(line => line.StartsWith(id + "|"));

            // Check if the product with the given ID was found
            if (productToUpdate == null)
            {
                // Optionally, handle the case where the product is not found, e.g., redirect to an error page
                return RedirectToAction("Index");
            }

            // Parse the product data
            string[] parts = productToUpdate.Split('|');
            string productName = parts[1];
            string productPrice = parts[2];
            string productBrand = parts[3];
            string productQuantity = parts[4];
            string productDescription = parts[5];
            string productImageUrl = parts[6];

            // Pass the product data to the view
            ViewBag.ProductId = id;
            ViewBag.ProductName = productName;
            ViewBag.ProductPrice = productPrice;
            ViewBag.ProductBrand = productBrand;
            ViewBag.ProductQuantity = productQuantity;
            ViewBag.ProductDescription = productDescription;
            ViewBag.ProductImageUrl = productImageUrl;

            return View();
        }

    }
}