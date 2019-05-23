using System;
using System.Linq;

namespace netcore_postgre
{
    class Program
    {
            static void Main(string[] args)
            {
                using(var context = new ProductsContext())
                {
                    context.Products.Add(new Product()
                                        {
                                            Description = "16 GB Ram, 1 TB HDD, 2.3 GHZ i5 Processor",
                                            Name = "Dell Inspiron P800",
                                            PurchaseDate = new DateTime(),
                                            WarrantyDate = new DateTime()
                                        });
                    context.Products.Add(new Product()
                                        {
                                            Description = "6 GB Ram, 250 TB SSD, 2.3 GHZ i3 Processor",
                                            Name = "Casper Nirvana TC3401",
                                            PurchaseDate = new DateTime(),
                                            WarrantyDate = new DateTime()
                                        });
                    context.SaveChanges();
                }
                using (var context = new ProductsContext())
                {
                    var products = context.Products.OrderBy(p => p.PurchaseDate).ToList();
                    foreach (var item in products)
                    {
                        Console.WriteLine($"{item.Name}");
                        Console.WriteLine($"Bought on {item.PurchaseDate}");

                        if (item.WarrantyDate > DateTime.Now)
                            Console.WriteLine($@"Warranty expires in {GetTimeRemaining(item.WarrantyDate)}");
                        else
                            Console.WriteLine("Warranty expired");

                        Console.WriteLine();
                }
            }
        }

        private static string GetTimeRemaining(DateTime warrantyDate)
        {
            var time = warrantyDate - DateTime.Now;
            string output = String.Empty;

            if (time.Days > 0)
                output += time.Days + "d";

            if ((time.Days == 0 || time.Days == 1) && time.Hours > 0)
                output += time.Hours + "h";

            if (time.Days == 0 && time.Minutes > 0)
                output += time.Minutes + "min";

            if (output.Length == 0)
                output += time.Seconds + "s";

            return output;
        }
    }
}