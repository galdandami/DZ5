using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        LinkedList<LinkedList<int>> matrixA = new LinkedList<LinkedList<int>>();
        matrixA.AddLast(new LinkedList<int>(new[] { 1, 2, 3 }));
        matrixA.AddLast(new LinkedList<int>(new[] { 4, 5, 6 }));

        LinkedList<LinkedList<int>> matrixB = new LinkedList<LinkedList<int>>();
        matrixB.AddLast(new LinkedList<int>(new[] { 7, 8 }));
        matrixB.AddLast(new LinkedList<int>(new[] { 9, 10 }));
        matrixB.AddLast(new LinkedList<int>(new[] { 11, 12 }));

        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);

        Console.WriteLine("Матрица B:");
        PrintMatrix(matrixB);

        LinkedList<LinkedList<int>> result = MultiplyMatrices(matrixA, matrixB);

        Console.WriteLine("Результат умножения A * B:");
        PrintMatrix(result);

        Console.ReadLine();
    }

    static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
    {
        foreach (LinkedList<int> row in matrix)
        {
            foreach (int value in row)
            {
                Console.Write($"{value,5}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static LinkedList<LinkedList<int>> MultiplyMatrices(
        LinkedList<LinkedList<int>> a,
        LinkedList<LinkedList<int>> b)
    {
        int rowsA = a.Count;
        int colsA = a.First.Value.Count;
        int rowsB = b.Count;
        int colsB = b.First.Value.Count;

        if (colsA != rowsB)
        {
            throw new ArgumentException("Число столбцов первой матрицы должно совпадать с числом строк второй матрицы.");
        }

        int[,] arrayB = new int[rowsB, colsB];
        int bi = 0;
        foreach (LinkedList<int> rowB in b)
        {
            int bj = 0;
            foreach (int value in rowB)
            {
                arrayB[bi, bj] = value;
                bj++;
            }
            bi++;
        }

        LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();

        foreach (LinkedList<int> rowA in a)
        {
            LinkedList<int> resultRow = new LinkedList<int>();

            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                int k = 0;
                foreach (int valueA in rowA)
                {
                    sum += valueA * arrayB[k, j];
                    k++;
                }
                resultRow.AddLast(sum);
            }

            result.AddLast(resultRow);
        }

        return result;
    }
}