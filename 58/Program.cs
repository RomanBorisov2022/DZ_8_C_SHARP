// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.Clear();

int row1 = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int col1 = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");
int row2 = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int col2 = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");

int[,] matrix1 = GetArray(row1, col1, 0, 10);
PrintArray(matrix1);
Console.WriteLine();
int[,] matrix2 = GetArray(row2, col2, 0, 10);
PrintArray(matrix2);
Console.WriteLine();
int[,] productMatrix = ResultMatrix(matrix1, matrix2);
PrintArray(productMatrix);

if (col1 != row2) 
{
    Console.WriteLine("Произведение найти невозможно.");
}

//_____________________получение числа от пользователя_____________//
int GetNumberFromUser(string message, string errorMessage)
{
    while(true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if(isCorrect)
            return userNumber;
        Console.WriteLine(errorMessage);
    } 
}

//__________________________заполнение массива______________________//
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);;
        }
    }
    return result;
}

//__________________________вывод массива на экран______________//
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
             Console.Write($"{inArray[i, j]} ");
        }
         Console.WriteLine();
     }
}

//_________________нахождение произведения двух матриц__________________//
int[,] ResultMatrix(int[,] array1, int[,] array2)
{
    int[,] result = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int row = 0; row < array1.GetLength(0); row++)
    {
        for (int col = 0; col < array2.GetLength(1); col++)
        {
            for (int i = 0; i < array1.GetLength(1); i++)
            {
                result[row, col] += array1[row, i] * array2[i, col];
            }
        }
    }
    return result;
}