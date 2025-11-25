using oop_assignment_1_2025_75428.Models;
//75428
namespace RentalCarTest
{
    public class UnitTest1
    {

        public class RentalCarTests
        {
            private RentalCar CreateDefaultRentalCar(bool borrowed = false)
            {
                return new RentalCar("Toyota", "Camry", "Saloon", "ABC-123", 75.50, borrowed);
            }

            [Fact]
            public void Constructor_Properties_Are_Set_Correctly()
            {
                
                var rentalCar = CreateDefaultRentalCar();

                
                Assert.Equal("Toyota", rentalCar.Manufacturer);
                Assert.Equal("Camry", rentalCar.Model);
                Assert.Equal("Saloon", rentalCar.BodyType);
                Assert.Equal("ABC-123", rentalCar.RegistrationNumber);
                Assert.Equal(75.50, rentalCar.Price);
                Assert.False(rentalCar.CheckBorrowed());
            }

            [Fact]
            public void Constructor_With_Five_Parameters_Sets_Borrowed_To_False()
            {
                
                var rentalCar = new RentalCar("Honda", "Civic", "HatchBack", "XYZ-789", 65.00);

              
                Assert.False(rentalCar.CheckBorrowed());
            }

            [Fact]
            public void Constructor_With_Three_Parameters_Sets_Default_Values()
            {
                
                var rentalCar = new RentalCar("Ford", "Mustang", "Convertible");

                
                Assert.Equal("Ford", rentalCar.Manufacturer);
                Assert.Equal("Mustang", rentalCar.Model);
                Assert.Equal("Convertible", rentalCar.BodyType);
                Assert.Equal("TEMP-REG", rentalCar.RegistrationNumber);
                Assert.Equal(50.0, rentalCar.Price);
                Assert.False(rentalCar.CheckBorrowed());
            }

            [Fact]
            public void Borrow_When_Not_Borrowed_Sets_Borrowed_To_True()
            {
               
                var rentalCar = CreateDefaultRentalCar();

             
                var result = rentalCar.Borrow();

              
                Assert.True(result);
                Assert.True(rentalCar.CheckBorrowed());
            }

            [Fact]
            public void Borrow_When_Already_Borrowed_Returns_False()
            {
               
                var rentalCar = CreateDefaultRentalCar(true);

                var result = rentalCar.Borrow();

               
                Assert.False(result);
                Assert.True(rentalCar.CheckBorrowed());
            }

            [Fact]
            public void ReturnRentalCar_Sets_Borrowed_To_False()
            {
              
                var rentalCar = CreateDefaultRentalCar(true);

              
                rentalCar.ReturnRentalCar();

                
                Assert.False(rentalCar.CheckBorrowed());
            }

            [Fact]
            public void ReturnRentalCar_When_Not_Borrowed_Does_Not_Throw()
            {
             
                var rentalCar = CreateDefaultRentalCar(false);

                
                var exception = Record.Exception(() => rentalCar.ReturnRentalCar());
                Assert.Null(exception);
                Assert.False(rentalCar.CheckBorrowed());
            }

            [Fact]
            public void CheckPrice_Returns_Correct_Price()
            {
                
                var rentalCar = CreateDefaultRentalCar();

               
                var price = rentalCar.CheckPrice();

                
                Assert.Equal(75.50, price);
            }

            [Fact]
            public void ChangePrice_With_Valid_Price_Updates_Price()
            {
                
                var rentalCar = CreateDefaultRentalCar();

              
                rentalCar.ChangePrice(80.00);

              
                Assert.Equal(80.00, rentalCar.CheckPrice());
            }

            [Fact]
            public void ChangePrice_With_Negative_Price_Throws_Exception()
            {
              
                var rentalCar = CreateDefaultRentalCar();

                Assert.Throws<ArgumentException>(() => rentalCar.ChangePrice(-10.00));
            }

            [Fact]
            public void CheckBorrowed_Returns_Correct_Status()
            {
                var borrowedCar = CreateDefaultRentalCar(true);
                var availableCar = CreateDefaultRentalCar(false);

               
                Assert.True(borrowedCar.CheckBorrowed());
                Assert.False(availableCar.CheckBorrowed());
            }

            [Fact]
            public void Constructor_With_Invalid_BodyType_Throws_Exception()
            {
                
                Assert.Throws<ArgumentException>(() =>
                    new RentalCar("Toyota", "Camry", "InvalidType", "REG-123", 50.0));
            }

            [Fact]
            public void Constructor_With_Empty_Manufacturer_Throws_Exception()
            {
              
                Assert.Throws<ArgumentException>(() =>
                    new RentalCar("", "Model", "Saloon", "REG-123", 50.0));
            }

            [Fact]
            public void Constructor_With_Empty_RegistrationNumber_Throws_Exception()
            {
                
                Assert.Throws<ArgumentException>(() =>
                    new RentalCar("Toyota", "Camry", "Saloon", "", 50.0, false));
            }

            [Fact]
            public void RentalCar_Implements_IRentable_Interface()
            {
                
                var rentalCar = CreateDefaultRentalCar();

              
                Assert.IsAssignableFrom<IRentable>(rentalCar);
            }

            [Fact]
            public void RentalCar_Inherits_From_RentalItem()
            {
             
                var rentalCar = CreateDefaultRentalCar();

                
                Assert.IsAssignableFrom<RentalItem>(rentalCar);
            }

            [Fact]
            public void Display_Method_Does_Not_Throw_Exception()
            {
                
                var rentalCar = CreateDefaultRentalCar();

                var exception = Record.Exception(() => rentalCar.Display());
                Assert.Null(exception);
            }

            [Theory]
            [InlineData("Saloon")]
            [InlineData("HatchBack")]
            [InlineData("Convertible")]
            [InlineData("CrossOver")]
            [InlineData("MPV")]
            public void Constructor_With_Valid_BodyTypes_Creates_Object(string bodyType)
            {
                
                var rentalCar = new RentalCar("Toyota", "Camry", bodyType, "REG-123", 50.0);

                
                Assert.Equal(bodyType, rentalCar.BodyType);
            }

            [Fact]
            public void Borrow_Returns_True_On_Success()
            {
           
                var rentalCar = CreateDefaultRentalCar(false);

               
                var result = rentalCar.Borrow();

               
                Assert.True(result);
            }

            [Fact]
            public void Borrow_Returns_False_When_Already_Borrowed()
            {
               
                var rentalCar = CreateDefaultRentalCar(true);

                
                var result = rentalCar.Borrow();

              
                Assert.False(result);
            }
        }
    }
}