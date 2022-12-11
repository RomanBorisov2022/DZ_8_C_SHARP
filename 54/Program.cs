// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.Clear();

int row = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int col = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");
int[,] matrix = GetArray(row, col, 0, 100);
PrintArray(matrix);
Console.WriteLine();
ChangeArray(matrix);
PrintArray(matrix);


//_______________получение числа от пользователя____________//
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

//___________________метод для заполнение массива_____________________//
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

//_______________вывод массива на экран_________________//
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




//____________________изменение массива_____________________//
void ChangeArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            int numberIndex = j;
            for (int n = j + 1; n < array.GetLength(1); n++)
            {
                if (array[i, n] > array[i, numberIndex])
                    numberIndex = n;
            }
            int result = array[i, j];
            array[i, j] = array[i, numberIndex];
            array[i, numberIndex] = result;
        }   
    }
}