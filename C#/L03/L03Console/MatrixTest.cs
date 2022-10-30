using L03Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var test = new SquareMatrix(3);
var testOperand = new SquareMatrix(3);

Console.WriteLine("Sum of matrixes:");
Console.WriteLine(test.ToString() + "\n\n\t\t+");
Console.WriteLine(testOperand.ToString());
Console.WriteLine("\n\t\t=");
Console.WriteLine(test.Plus(testOperand).ToString());
Console.WriteLine("Matrix sum:"); Console.WriteLine(test.MatrixSum() + "\n");
Console.WriteLine("\n\nConstant Multiply Test\n----------\n");
Console.WriteLine(test.MultiplyConstant(3));
Console.WriteLine("\n\nMultiply Test\n----------\n");
Console.WriteLine(test.Multiply(testOperand));

Console.WriteLine();
Console.WriteLine((test + testOperand).ToString());
Console.WriteLine("\n\nMultiply Constant Test 2\n----------\n");
Console.WriteLine((test*2).ToString());
Console.WriteLine();
Console.WriteLine("\n\nMultiply Test 2\n----------\n");
Console.WriteLine((test * testOperand).ToString());