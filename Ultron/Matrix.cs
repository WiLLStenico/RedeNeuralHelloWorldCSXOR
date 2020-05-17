using System;

namespace Ultron
{
    public class Matrix
    {

        public double[,] Data { get; set; }
        public Matrix(int rows, int cols)
        {
            Data = new double[rows, cols];

            var random = new Random();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Data[row, col] = (Double)random.Next(0, 100000000)/100000000*2-1;
                }
            }

        }

        public Matrix(double[, ] data)
        {
            Data = data;
        }

        public static Matrix arrayToMatryx(double[] input)
        { //Entrada dos dados do usuario em Array e sera tranformada em uma matriz de UMA coluna

            var result = new Matrix(input.Length, 1);

            for (int i = 0; i < result.Data.GetLength(0); i++)
            {
                result.Data[i, 0] = input[i];
            }

            return result;

        }

        public static double[,] Add(double[,] a, double[,] b)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            double[,] result = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static double[,] Subtract(double[,] a, double[,] b)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            double[,] result = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static double[,] Hadamard(double[,] a, double[,] b)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            double[,] result = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] * b[i, j];
                }
            }
            return result;
        }

        public static double[,] EscalarMultiply(double[,] a, double escalar)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            double[,] result = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] * escalar; 
                }
            }
            return result;
        }

        public static double[,] Multiply(double[,] a, double[,] b)
        {
            //Se numero de colunas de A != de Linhas de B
            if (a.GetLength(1) != b.GetLength(0))
            {
                Console.WriteLine("Multiplicação Invalida");
                return null;
            }

            int row = a.GetLength(0); //linhas de A
            int col = b.GetLength(1); //colunas de B

            double[,] result = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {

                        result[i, j] = result[i, j] + a[i, k] * b[k, j];
                    }

                }
            }
            return result;
        }

        public static double[,] Transpose(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public void toConsole(){

        int row = Data.GetLength(0); //linhas de A
            int col = Data.GetLength(1); //colunas de B

            double[,] result = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(Data[i,j]+",");
                }
                Console.WriteLine();
            }

        }
    }
}