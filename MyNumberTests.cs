using Interfaces_OOP;

namespace MyNumberUnitTests
{
    [TestClass]
    public class MyNumberTests
    {
        // MyFrac unit tests
        [TestMethod]
        public void FracAdding()
        {
            MyFrac f1 = new MyFrac(1, 3);
            MyFrac f2 = new MyFrac(1, 3);

            MyFrac result = f1.Add(f2);

            Assert.AreEqual("2/3", result.ToString());
        }

        [TestMethod]
        public void FracSubstracting()
        {
            MyFrac f1 = new MyFrac(5, 10);
            MyFrac f2 = new MyFrac(1, 3);

            MyFrac result = f1.Subtract(f2);

            Assert.AreEqual("1/6", result.ToString());
        }

        [TestMethod]
        public void FracMultiplying()
        {
            MyFrac f1 = new MyFrac(6, 13);
            MyFrac f2 = new MyFrac(1, 2);

            MyFrac result = f1.Multiply(f2);

            Assert.AreEqual("3/13", result.ToString());
        }

        [TestMethod]
        public void FracDividing()
        {
            MyFrac f1 = new MyFrac(1, 3);
            MyFrac f2 = new MyFrac(1, 3);

            MyFrac result = f1.Divide(f2);

            Assert.AreEqual("1", result.ToString());
        }

        [TestMethod]
        public void FracFromString()
        {
            MyFrac f1 = new MyFrac("1/3");                        

            Assert.AreEqual("1/3", f1.ToString());
        }

        [TestMethod]
        public void FracFromChar()
        {
            MyFrac f1 = new MyFrac('1', '3');            

            Assert.AreEqual("1/3", f1.ToString());
        }

        [TestMethod]
        public void SimplifyingFrac()
        {
            MyFrac f1 = new MyFrac(2, 6);           

            Assert.AreEqual("1/3", f1.ToString());
        }

        [TestMethod]
        public void DividingByZero()
        {
            MyFrac f1 = new MyFrac(2, 6);
            MyFrac f2 = new MyFrac(0, 2);
            
            Assert.ThrowsException<DivideByZeroException>(() => f1.Divide(f2));
        }
        // End of MyFrac unit tests

        // MyComplex unit tests
        [TestMethod]
        public void ComplexFromDouble()
        {
            MyComplex c1 = new MyComplex(1.1, 1.5);

            Assert.AreEqual("1+1i", c1.ToString());
        }
        [TestMethod]
        public void ComplexFromInt()
        {
            MyComplex c1 = new MyComplex(2, 5);

            Assert.AreEqual("2+5i", c1.ToString());
        }
        [TestMethod]
        public void ComplexFromString()
        {
            MyComplex c1 = new MyComplex("10+15i");

            Assert.AreEqual("10+15i", c1.ToString());
        }
        [TestMethod]
        public void AddingComplex()
        {
            MyComplex c1 = new MyComplex("10+15i");
            MyComplex c2 = new MyComplex("1+5i");

            MyComplex result = c1.Add(c2);

            Assert.AreEqual("11+20i", result.ToString());
        }
        [TestMethod]
        public void SubtractingComplex()
        {
            MyComplex c1 = new MyComplex("10+15i");
            MyComplex c2 = new MyComplex("9+14i");

            MyComplex result = c1.Subtract(c2);

            Assert.AreEqual("1+1i", result.ToString());
        }
        [TestMethod]
        public void MultiplyingComplex()
        {
            MyComplex c1 = new MyComplex("1+5i");
            MyComplex c2 = new MyComplex("3+2i");

            MyComplex result = c1.Multiply(c2);

            Assert.AreEqual("-7+17i", result.ToString());
        }
        [TestMethod]
        public void DividingComplex()
        {
            MyComplex c1 = new MyComplex("5+3i");
            MyComplex c2 = new MyComplex("3+3i");

            MyComplex result = c1.Divide(c2);

            Assert.AreEqual("1", result.ToString());
        }
    }
}