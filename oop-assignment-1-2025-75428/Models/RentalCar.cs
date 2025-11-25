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

        // Valid body types for validation
        private static readonly HashSet<string> ValidBodyTypes = new HashSet<string>
        {
            "Saloon", "HatchBack", "Convertible", "CrossOver", "MPV"
        };

        // Constructor 1: Takes all 6 parameters
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

        // Constructor 2: Takes 5 parameters (without borrowed status)
        public RentalCar(string manufacturer, string model, string bodyType,
                        string registrationNumber, double price)
                        : this(manufacturer, model, bodyType, registrationNumber, price, false)
        {
        }

        // Constructor 3: Takes 3 parameters (minimum required)
        public RentalCar(string manufacturer, string model, string bodyType)
                        : this(manufacturer, model, bodyType, "TEMP-REG", 50.0, false)
        {
        }

        // IRentable interface implementation
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

        // Validation method for body type
        private void ValidateBodyType(string bodyType)
        {
            if (!ValidBodyTypes.Contains(bodyType))
            {
                throw new ArgumentException($"Invalid body type: {bodyType}. Valid types are: {string.Join(", ", ValidBodyTypes)}");
            }
        }

        // Override method from RentalItem base class
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