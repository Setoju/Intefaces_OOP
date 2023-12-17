using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Interfaces_OOP
{
    public partial class MyFrac : IMyNumber<MyFrac>
    {
        private BigInteger nom;
        private BigInteger denom;

        // Constructors
        public MyFrac(BigInteger nom, BigInteger denom)
        {
            ZeroDivisionCheck(denom);               
            
            this.nom = nom;
            this.denom = denom;

            RemovingNegativeDenom();
        }

        public MyFrac(int nom, int denom)
        {
            BigInteger denomBig = (BigInteger)denom;
            BigInteger nomBig = (BigInteger)nom;      

            ZeroDivisionCheck(denomBig);

            this.nom = nomBig;
            this.denom = denomBig;

            RemovingNegativeDenom();
        }       

        public MyFrac(string frac)
        {
            // (-)? we create a group where we have optional minus character
            // \\d+ we chech for one or more number that is equal to [0-9]
            // / we check for front slash character
            // (-)? we create another group with optional minus
            // \\d+ and we again check for one or more number
            if (!Regex.IsMatch(frac, "(-)?\\d+/(-)?\\d+"))
            {
                throw new Exception("Provided string is not a frac.");
            }

            BigInteger[] bigIntFrac = Array.ConvertAll(frac.Split("/"), BigInteger.Parse);

            nom = bigIntFrac[0];
            denom = bigIntFrac[1];

            RemovingNegativeDenom();
        }              

        // Helping methods
        private void ZeroDivisionCheck(BigInteger denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException();
            }
        }

        private void RemovingNegativeDenom()
        {
            if (denom > 0)
                return;

            nom = -nom;
            denom = -denom;
        }

        private BigInteger SimplifyFrac(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Operations
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom + that.nom * this.denom, this.denom * that.denom);
        }        
        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom - that.nom * this.denom, this.denom * that.denom);
        }
        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.nom * that.nom, this.denom * that.denom);
        }
        public MyFrac Divide(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom, that.nom * this.denom);
        }

        public override string ToString()
        {
            if (nom == denom)
            {
                return "1";
            }

            BigInteger simplifiedFrac = SimplifyFrac(nom, denom);
            nom = nom / simplifiedFrac;
            denom = denom / simplifiedFrac;

            if (nom < 0 && denom >= 0  || nom >= 0 && denom < 0)
            {
                return $"-{Math.Abs((int)nom)}/{Math.Abs((int)denom)}";
            }
            else
            {
                return $"{nom}/{denom}";
            }
        }
    }
}
