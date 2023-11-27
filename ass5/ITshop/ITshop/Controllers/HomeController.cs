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

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            string filePath = Server.MapPath("~/App_Data/Products.txt");
            string[] lines = System.IO.File.ReadAllLines(filePath);

            var updatedLines = lines.Where(line => !line.StartsWith(productId + "|")).ToList();
            System.IO.File.WriteAllLines(filePath, updatedLines);

            return RedirectToAction("About", "Home"); // Hoặc chuyển hướng đến trang khác tùy vào nhu cầu của bạn
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

            // Pass the product data to the view
            Product product = new Product
            {
                Id = id,
                Name = parts[1],
                Price = decimal.Parse(parts[2]),
                Brand = parts[3],
                Quantity = int.Parse(parts[4]),
                Description = parts[5],
                ImageUrl = parts[6]
            };

            return View(product);

        }
        [HttpPost] // Xử lý khi submit form
        public ActionResult Edit(int productId, string productName, decimal productPrice, string productBrand, int productQuantity, string productDescription, string productImageUrl)
        {
            // Đọc dữ liệu từ file
            string filePath = Server.MapPath("~/App_Data/Products.txt");
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Tìm sản phẩm cần chỉnh sửa và cập nhật thông tin
            string productToUpdate = lines.FirstOrDefault(line => line.StartsWith(productId + "|"));

            if (productToUpdate != null)
            {
                string updatedProduct = $"{productId}|{productName}|{productPrice}|{productBrand}|{productQuantity}|{productDescription}|{productImageUrl}";

                // Thay đổi dòng thông tin sản phẩm
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith(productId + "|"))
                    {
                        lines[i] = updatedProduct;
                        break;
                    }
                }

                // Ghi dữ liệu mới vào file
                System.IO.File.WriteAllLines(filePath, lines);

                // Chuyển hướng đến trang /Home/About sau khi lưu thành công
                return RedirectToAction("About", "Home");
            }

            // Xử lý nếu không tìm thấy sản phẩm để chỉnh sửa
            return RedirectToAction("About", "Home");
        }

    }
}