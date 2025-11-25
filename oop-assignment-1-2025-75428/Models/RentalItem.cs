using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_assignment_1_2025_75428.Models
{
    public abstract class RentalItem
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string BodyType { get; set; } = string.Empty;
        public double Price { get; set; } = 0.0;
        public bool Borrowed { get; protected set; } = false;

        protected RentalItem(string manufacturer, string model, string bodyType, double price)
        {
            if (string.IsNullOrWhiteSpace(manufacturer) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(bodyType) ||
                price < 0)
            {
                Console.WriteLine("Invalid parameters provided");
                throw new ArgumentException("Manufacturer, model, and bodyType cannot be empty, and price must be positive");
            }

            Manufacturer = manufacturer;
            Model = model;
            BodyType = bodyType;
            Price = price;
        }

        public abstract void Display();
    }
}