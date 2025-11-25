using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_assignment_1_2025_75428.Models
{

    public class RentalCar : RentalItem, IRentable
    {
        public string RegistrationNumber { get; set; } = string.Empty;

      
        private static readonly HashSet<string> ValidBodyTypes = new HashSet<string>
        {
            "Saloon", "HatchBack", "Convertible", "CrossOver", "MPV"
        };

      
        public RentalCar(string manufacturer, string model, string bodyType,
                        string registrationNumber, double price, bool borrowed)
                        : base(manufacturer, model, bodyType, price)
        {
            ValidateBodyType(bodyType);

            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new ArgumentException("Registration number cannot be empty");
            }

            RegistrationNumber = registrationNumber;
            Borrowed = borrowed;
        }

      
        public RentalCar(string manufacturer, string model, string bodyType,
                        string registrationNumber, double price)
                        : this(manufacturer, model, bodyType, registrationNumber, price, false)
        {
        }

        
        public RentalCar(string manufacturer, string model, string bodyType)
                        : this(manufacturer, model, bodyType, "TEMP-REG", 50.0, false)
        {
        }

      
        public bool Borrow()
        {
            if (!Borrowed)
            {
                Borrowed = true;
                Console.WriteLine("RentalCar borrowed successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Error: RentalCar is already on loan.");
                return false;
            }
        }

        public void ReturnRentalCar()
        {
            if (Borrowed)
            {
                Borrowed = false;
                Console.WriteLine("RentalCar returned successfully.");
            }
            else
            {
                Console.WriteLine("RentalCar was not borrowed.");
            }
        }

        public bool CheckBorrowed() => Borrowed;

        public double CheckPrice() => Price;

        public void ChangePrice(double newPrice)
        {
            if (newPrice < 0)
            {
                throw new ArgumentException("Price cannot be negative", nameof(newPrice));
            }
            Price = newPrice;
            Console.WriteLine($"Price changed to: {newPrice}");
        }

        
        private void ValidateBodyType(string bodyType)
        {
            if (!ValidBodyTypes.Contains(bodyType))
            {
                throw new ArgumentException($"Invalid body type: {bodyType}. Valid types are: {string.Join(", ", ValidBodyTypes)}");
            }
        }

        
        public override void Display()
        {
            Console.WriteLine(new string('*', 50));
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Body Type: {BodyType}");
            Console.WriteLine($"Registration Number: {RegistrationNumber}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Borrowed: {Borrowed}");
            Console.WriteLine(new string('*', 50));
            Console.WriteLine();
        }
    }
}