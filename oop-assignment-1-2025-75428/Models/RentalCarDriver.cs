using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_assignment_1_2025_75428.Models;
 public static class RentalCarDriver
{
    public static void Run()
    {
        Console.WriteLine("=== RENTAL CAR SYSTEM DEMO ===");
        Console.WriteLine();

        
        RentalCar car1 = new RentalCar("Toyota", "Camry", "Saloon", "ABC-123", 75.50, false);
        RentalCar car2 = new RentalCar("Honda", "Civic", "HatchBack", "XYZ-789", 65.00);
        RentalCar car3 = new RentalCar("Ford", "Mustang", "Convertible", "MUS-001", 120.00, true);
        RentalCar car4 = new RentalCar("Nissan", "Qashqai", "CrossOver"); // Using 3-parameter constructor

        
        Console.WriteLine("Initial Car Details:");
        car1.Display();
        car2.Display();
        car3.Display();
        car4.Display();

       
        Console.WriteLine("Testing Borrow Method:");
        car1.Borrow();  
        car1.Borrow();  
        car3.Borrow();  

        
        Console.WriteLine("\nTesting Return Method:");
        car3.ReturnRentalCar();  
        car2.ReturnRentalCar();  

    
        Console.WriteLine("\nTesting Price Methods:");
        Console.WriteLine($"Car1 price: {car1.CheckPrice()}");
        car1.ChangePrice(80.00);
        Console.WriteLine($"Car1 new price: {car1.CheckPrice()}");

        
        Console.WriteLine("\nTesting Borrowed Status:");
        Console.WriteLine($"Car1 borrowed: {car1.CheckBorrowed()}");
        Console.WriteLine($"Car2 borrowed: {car2.CheckBorrowed()}");
        Console.WriteLine($"Car3 borrowed: {car3.CheckBorrowed()}");

     
        Console.WriteLine("\nTesting Error Handling:");
        try
        {
            RentalCar invalidCar = new RentalCar("", "Model", "Saloon", "REG-123", 50.0);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error creating car: {ex.Message}");
        }

        try
        {
            RentalCar invalidBodyType = new RentalCar("Toyota", "Camry", "InvalidType", "REG-456", 50.0);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error creating car: {ex.Message}");
        }

       
        Console.WriteLine("\nFinal Car Details:");
        car1.Display();
        car2.Display();
        car3.Display();
        car4.Display();
    }
}
