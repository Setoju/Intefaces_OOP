using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Interfaces_OOP
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        private BigInteger re;
        private BigInteger im;

        // Constructors
        public MyComplex(BigInteger re, BigInteger im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex(double re, double im)
        {
            this.re = (BigInteger)re;
            this.im = (BigInteger)im;
        }

        public MyComplex(int re, int im)
        {
            this.re = (BigInteger)re;
            this.im = (BigInteger)im;
        }

        // FIX THIS PART
        public MyComplex(string exp)
        {
            if (!Regex.IsMatch(exp, "\\d+(,\\d+)?\\+\\d+(,\\d+)?i"))
            {
                throw new Exception("Provided string is not a complex number.");
            }

            string[] values = exp.Remove(exp.Length - 1, 1).Split("+");

            re = IsComplexDouble(values[0]);
            im = IsComplexDouble(values[1]);
        }

        private BigInteger IsComplexDouble(string s)
        {
            return s.Contains(",") ? (BigInteger)double.Parse(s) : BigInteger.Parse(s);
        }

        // Operations
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.re + that.re, this.im + that.im);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.re - that.re, this.im - that.im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(this.re * that.re - this.im * that.im, this.re * that.im + this.im * that.re);
        }

        public MyComplex Divide(MyComplex that)
        {
            BigInteger div = that.re * that.re + that.im * that.im;

            DivisionCheck(div);            

            BigInteger rePart = (this.re * that.re + this.im * that.im) / div;
            BigInteger imPart = (this.im * that.re - this.re * that.im) / div;

            return new MyComplex(rePart, imPart);
        }

        private void DivisionCheck(BigInteger denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException();
            }
        }

        public override string ToString()
        {
            if (im == 0)
            {
                return $"{re}";
            }
            else if (re == 0)
            {
                return $"{im}";
            }
            else if (im < 0)
            {
                return $"{re}{im}i";
            }
            return $"{re}+{im}i";
        }
    }
}
