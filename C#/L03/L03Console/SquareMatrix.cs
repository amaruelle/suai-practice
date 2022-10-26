using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03Console
{
    public class SquareMatrix
    {
        private int size;
        private List<List<double>> values;
        public int Size
        {
            get { return size; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("ERROR: Size should be greater than 0.");
                }
                size = value;
            }
        }
        public List<List<double>> Values
        {
            get { return values; }
            set
            {
                if (value.Count != Size || value[0].Count != Size)
                {
                    throw new Exception("ERROR: Invalid input");
                }
                values = value;
            }
        }

        // конструкторы
        public SquareMatrix(int size, List<List<double>> values) { Size = size; Values = values; }
        public SquareMatrix(int size)
        {
            Size = size;
            var values = new List<List<double>>();
            for (int i = 0; i < size; i++)
            {
                values.Add(new List<double>());
                for (int j = 0; j < size; j++)
                {
                    var rand = new Random();
                    values.Last().Add(Math.Round(rand.NextDouble() * 10, 2));
                }
            }

            Values = values;
        }

        // методы
        public double MatrixSum()
        {
            int indexX = 0;
            int indexY = 0;
            double sum = 0;
            while (indexX != values.Count)
            {
                while (indexY != values[indexX].Count)
                {
                    sum += values[indexX].Sum();
                    indexY++;
                }
                indexX++;
            }
            return Math.Round(sum, 2);
        }

        public SquareMatrix Plus(SquareMatrix operand)
        {
            SquareMatrix initial = new(operand.Size);
            if (this.Size != operand.Size) throw new Exception("ERROR: Incorrect size of operands");

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                    initial.Values[i][j] = Math.Round(this.Values[i][j] + operand.Values[i][j], 2);
            }

            return initial;
        }

        public SquareMatrix Minus(SquareMatrix operand)
        {
            SquareMatrix initial = new(operand.Size);
            if (this.Size != operand.Size) throw new Exception("ERROR: Incorrect size of operands");

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                    initial.Values[i][j] = Math.Round(this.Values[i][j] - operand.Values[i][j], 2);
            }

            return initial;
        }

        public SquareMatrix MultiplyConstant(int constant)
        {
            SquareMatrix initial = new(this.Size);

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                    initial.Values[i][j] = Math.Round(this.Values[i][j] * constant, 2);
            }

            return initial;
        }

        public SquareMatrix Multiply(SquareMatrix operand)
        {
            if (operand.Size != this.Size) throw new Exception("ERROR: Incorrect size of operands.");

            var initial = new SquareMatrix(this.Size);
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    double val = 0;
                    for (int z = 0; z < this.Size; z++)
                    {
                        val += Math.Round(this.Values[i][z] * operand.Values[z][j], 2);
                    }

                    initial.Values[i][j] = Math.Round(val, 2);
                }
            }

            return initial;
        }

        public override string ToString()
        {
            string matrixStr = "\n";
            matrixStr += new StringBuilder().Insert(0, "--", Size*6).ToString();
            matrixStr += "\n";
            foreach (var list in values)
            {
                matrixStr += '\t' + String.Join('\t', list) + '\n';
            }
            matrixStr += new StringBuilder().Insert(0, "--", Size*6).ToString();
            return matrixStr;
        }
    }
}
