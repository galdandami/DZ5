using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrixA =
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };

        int[,] matrixB =
        {
            { 7, 8 },
            { 9, 10 },
            { 11, 12 }
        };

        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);

        Console.WriteLine("Матрица B:");
        PrintMatrix(matrixB);

        int[,] result = MultiplyMatrices(matrixA, matrixB);

        Console.WriteLine("Результат умножения A * B:");
        PrintMatrix(result);

        Console.ReadLine();
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static int[,] MultiplyMatrices(int[,] a, int[,] b)
    {
        int rowsA = a.GetLength(0);
        int colsA = a.GetLength(1);
        int rowsB = b.GetLength(0);
        int colsB = b.GetLength(1);

        if (colsA != rowsB)
        {
            throw new ArgumentException("Число столбцов первой матрицы должно совпадать с числом строк второй матрицы.");
        }

        int[,] result = new int[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += a[i, k] * b[k, j];
                }
                result[i, j] = sum;
            }
        }

        return result;
    }
}