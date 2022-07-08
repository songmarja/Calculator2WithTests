using Calculator2;
using System.Collections.Generic;

namespace Calculator2.Tests
{
    public class CalculatorShould
    {
        //Arrange
        Calculator sut = new Calculator();

        [Fact]
        public void AddTwoNumbers()
        {
            //Arrange
            decimal firstNum = 10.66M;
            decimal secondNum = 20.3367M;

            //Act
            decimal result = sut.Add(firstNum, secondNum);

            //Assert
            Assert.Equal(30.997M, result);
        }
        [Fact]
        public void AddMultipleNumbers()
        {
            //Arrange
            decimal[] multipleNumbers = new decimal[] { 60m, 40m, 35.987M, 10.66M };

            //Act
            decimal result = sut.Add(multipleNumbers);

            //Assert
            Assert.Equal(146.647M, result);
        }

        [Fact]
        public void SubtractTwoNumbers()
        {
            //Arrange
            decimal firstNum = 20.665M;
            decimal secondNum = 5.336M;

            //Act
            decimal difference = sut.Subtract((firstNum), (secondNum));

            //Assert
            Assert.Equal(15.329M, difference);
        }

        [Fact]
        public void SubtractMultipleNumbers()
        {
            //Arrange
            decimal[] multipleNums = { 20.665M, 5.336M, 10.329M };
            
            //Act
            decimal difference = sut.Subtract(multipleNums);

            //Assert
            Assert.Equal(5.000M, difference);
        }

        [Fact]
        public void MultiplyTwoNumbers()
        {
            //Arrange
            decimal firstNum = 20.665M;
            decimal secondNum = 5.336M;

            //Act
            decimal product = sut.Multiply((firstNum), (secondNum));

            //Assert
            Assert.Equal(110.26844M, product);
        }

        [Fact]
        public void DivideTwoNumbers()
        {
            //Arrange
            decimal firstNum = 20.665M;
            decimal secondNum = 5.336M;

            //Act
            decimal quote = sut.Divide((firstNum), (secondNum));

            //Assert
            Assert.Equal(3.87275M, quote);
        }

        [Fact]
        public void ThrowExceptionForDivideByZero()
        {
            //Arrange
            decimal firstNum = 20.665M;
            decimal secondNum = 0M;
           
            Assert.Throws<DivideByZeroException>(() => {

            // Act (the actual operation)
            decimal quote = sut.Divide(firstNum, secondNum);

            // Then, Assert
            Assert.IsType<decimal>(quote);
                });
        }
    }
}