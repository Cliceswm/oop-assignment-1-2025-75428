using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_assignment_1_2025_75428.Models
{
    public interface IRentable
    {
        bool Borrow();
        void ReturnRentalCar();
        void Display();
        bool CheckBorrowed();
        double CheckPrice();
        void ChangePrice(double newPrice);
    }
}
