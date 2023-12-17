using System.Numerics;
using System.Text.RegularExpressions;

namespace Interfaces_OOP
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        private double re;
        private double im;

        // Constructors        
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex(int re, int im)
        {
            this.re = re;
            this.im = im;
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
            double div = that.re * that.re + that.im * that.im;

            ZeroDivisionCheck(div);            

            double rePart = (this.re * that.re + this.im * that.im) / div;
            double imPart = (this.im * that.re - this.re * that.im) / div;

            return new MyComplex(rePart, imPart);
        }

        private void ZeroDivisionCheck(double denom)
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
