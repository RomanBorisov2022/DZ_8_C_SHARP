// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
//Результат: 1 строка

Console.Clear();

int row = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int col = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");
int[,] matrix = GetArray(row, col, 0, 10);
PrintArray(matrix);
Console.WriteLine();
int[] sumString = FindSumString(matrix);
Console.WriteLine($"Индекс строки - {FindMinSumString(sumString)} ");




//______________________получение числа от пользователя_______________________//
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

//____________________________заполнение массива_______________________//
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

//____________________________вывод массива на экран__________________//
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

///_____________________нахождение суммы в строках____________________//

int[] FindSumString(int[,] inArray)
{
    int[] result = new int[inArray.GetLength(0)];
    int sum = 0;
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            sum = sum + inArray[i, j];
        }
        result[i] = sum;

        sum = 0;
    }
    return result;
}


//_____________________поиск строки с наименьшей суммой элементов________________//

int FindMinSumString(int[] inArray)
{  
    int min = 0;
    for(int i = 1; i < inArray.Length; i++)
    {
        if (inArray[i] < inArray[min]) 
        {
            min = i;
        }
    }
    return min;
}
