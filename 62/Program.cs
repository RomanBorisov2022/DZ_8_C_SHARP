// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.Clear();

int row = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int col = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");
int[,] matrix = new int[row, col];
matrix = ChangeArray(matrix);
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
int[,] ChangeArray(int[,] array)
{
    int x = 0;                
    int y = 0;
    int el = 1;
    while (el <= row * col)
    {
        while (y + 1 < col)  
        {
            if (matrix[x, y] == 0)
            {
                matrix[x, y] = el;
                el++;
            }
            if (el > col * row || matrix[x, y + 1] != 0)
                break;                               
            y++;
        }
        while (x + 1 < row)  
        {
            if (matrix[x, y] == 0)
            {
                matrix[x, y] = el;
                el++;
            }
            if (el > col * row || matrix[x + 1, y] != 0)  
                break;                              
            x++;
        }
        while (y - 1 >= 0)  
        {
            if (matrix[x, y] == 0)
            {
                matrix[x, y] = el;
                el++;
            }
            if (el > col * row || matrix[x, y - 1] != 0)
                break;                             
            y--;
        }
        while (x - 1 >= 1)  
        {
            if (matrix[x, y] == 0)
            {
                matrix[x, y] = el;
                el++;
            }
            if (el > col * row || matrix[x - 1, y] != 0)
                break;                              
            x--;
        }
}
return matrix;
}