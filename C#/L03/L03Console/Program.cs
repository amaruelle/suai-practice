using System;
namespace L03Console
{
    class Program
    {
        class Line
        {
            double mX1, mY1, mX2, mY2;
            public Line(double x1, double y1, double x2, double y2)//Конструктор
            {
                mX1 = x1; mY1 = y1; mX2 = x2; mY2 = y2;
            }
            //Описание свойств
            public void SetX1(double value)
            {
                mX1 = value;
            }
            public double GetX1()
            {
                return mX1;
            }
            public void SetY1(double value)
            {
                mY1 = value;
            }
            public double GetY1()
            {
                return mY1;
            }
            public void SetX2(double value)
            {
                mX2 = value;
            }
            public double GetX2()
            {
                return mX2;
            }
            public void SetY2(double value)
            {
                mY2 = value;
            }
            public double GetY2()
            {
                return mY2;
            }
            //Метод
            public double GetLength()
            {
                double dx = mX2 - mX1;
                double dy = mY2 - mY1;
                return Math.Sqrt(dx * dx + dy * dy);
            }
        };
        static void Main(string[] args)
        {
            double x1, y1, x2, y2;
            x1 = Convert.ToSingle(Console.ReadLine());
            y1 = Convert.ToSingle(Console.ReadLine()); ;
            x2 = Convert.ToSingle(Console.ReadLine()); ;
            y2 = Convert.ToSingle(Console.ReadLine()); ;
            Line line = new Line(x1, y1, x2, y2);
            //x1++;так компилятор не изменяет значения полей
            Console.WriteLine("Distance");
            Console.WriteLine(line.GetLength());
            Console.WriteLine("Modified field");
            line.SetX1(line.GetX1() + 1);
            Console.WriteLine(line.GetX1());
        }
    }
}