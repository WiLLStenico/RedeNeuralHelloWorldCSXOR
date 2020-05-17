using System;

namespace Ultron
{
    public class Matrix
    {

        public int[,] Data { get; set; }
        public Matrix(int rows, int cols)
        {
            Data = new int[rows, cols];

            var random = new Random();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Data[row, col] = random.Next(0, 10);
                }
            }

        }

        public Matrix(int[, ] data)
        {
            Data = data;
        }

        public static Matrix arrayToMatryx(int[] input)
        { //Entrada dos dados do usuario em Array e sera tranformada em uma matriz de UMA coluna

            var result = new Matrix(input.Length, 1);

            for (int i = 0; i < result.Data.GetLength(0); i++)
            {
                result.Data[i, 0] = input[i];
            }

            return result;

        }

        public static int[,] Add(int[,] a, int[,] b)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            int[,] result = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static int[,] Subtract(int[,] a, int[,] b)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            int[,] result = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static int[,] Hadamard(int[,] a, int[,] b)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            int[,] result = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] * b[i, j];
                }
            }
            return result;
        }

        public static int[,] EscalarMultiply(int[,] a, int escalar)
        {

            int row = a.GetLength(0);
            int col = a.GetLength(1);

            int[,] result = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = a[i, j] * escalar; //TODO: Mudar para double
                }
            }
            return result;
        }

        public static int[,] Multiply(int[,] a, int[,] b)
        {
            //Se numero de colunas de A != de Linhas de B
            if (a.GetLength(1) != b.GetLength(0))
            {
                Console.WriteLine("Multiplicação Invalida");
                return null;
            }

            int row = a.GetLength(0); //linhas de A
            int col = b.GetLength(1); //colunas de B

            int[,] result = new int[row, col];

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

        public static int[,] Transpose(int[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            int[,] result = new int[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
    }
}