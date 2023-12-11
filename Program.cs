using Interfaces_OOP;

static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
{
    Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    T aPlusB = a.Add(b);
    Console.WriteLine("a = " + a);
    Console.WriteLine("b = " + b);
    Console.WriteLine("(a + b) = " + aPlusB);
    Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
    Console.WriteLine(" = = = ");
    T curr = a.Multiply(a);
    Console.WriteLine("a^2 = " + curr);
    T wholeRightPart = curr;
    curr = a.Multiply(b); // ab
    curr = curr.Add(curr); // ab + ab = 2ab

    Console.WriteLine("2*a*b = " + curr);
    wholeRightPart = wholeRightPart.Add(curr);
    curr = b.Multiply(b);
    Console.WriteLine("b^2 = " + curr);
    wholeRightPart = wholeRightPart.Add(curr);
    Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
    Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
}
static void testSquaresDiffrences<T>(T a, T b) where T : IMyNumber<T>
{
    Console.WriteLine("=== Starting testing (a-b)=(a^2-b^2) / (a+b) with a = " + a + ", b = " + b + " ===");
    T aSbutractB = a.Subtract(b);    
    Console.WriteLine("a = " + a);
    Console.WriteLine("b = " + b);
    Console.WriteLine("(a - b) = " + aSbutractB);
    Console.WriteLine(" = = = ");
    T aPlusB = a.Add(b);
    T aSquared = a.Multiply(a);
    T bSquared = b.Multiply(b);
    T curr = aSquared.Subtract(bSquared);
    Console.WriteLine("(a + b) = " + aPlusB);
    Console.WriteLine("a^2 = " + aSquared);        
    Console.WriteLine("b^2 = " + bSquared);
    Console.WriteLine("a^2 - b^2 = " + curr);
    T wholeRightPart = curr.Divide(aPlusB);
    Console.WriteLine("(a ^ 2 - b ^ 2) / (a + b) = " + wholeRightPart);
    Console.WriteLine($"RESULT: {aSbutractB} = {wholeRightPart}");
    Console.WriteLine("=== Finishing testing (a-b)=(a^2-b^2) / (a+b) with a = " + a + ", b = " + b + " ===");
}

MyFrac f1 = new MyFrac("1/3");
MyFrac f2 = new MyFrac(-2, -3);
MyFrac f3 = new MyFrac(10, 11);
testAPlusBSquare(f1, f2);
testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
testSquaresDiffrences(f1, f2);
testSquaresDiffrences(new MyComplex(1, 3), new MyComplex(1, 6));
MyFrac[] myFracs= new MyFrac[3];
myFracs[0] = f1;
myFracs[1] = f2;
myFracs[2] = f3;
Array.Sort(myFracs);
Console.WriteLine($"Sorted array of fractions: \n {myFracs[0]} \n {myFracs[1]} \n {myFracs[2]}");
