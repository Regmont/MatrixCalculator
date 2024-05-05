using System;
using System.Globalization;

namespace MatrixCalculator
{
    class MyConsole
    {
        public void FillArray(double[,] matrix, int width, int length)
        {
            //Метод, заполняющий двумерный массив matrix в объекте данного класса

            //Циклы по i, j проходятся по всем элементам матрицы
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //notOk - флаг, означающий, что введены корректные данные
                    //top, left - координаты консольного курсора
                    bool notOK = true;
                    int top = 0;
                    int left;

                    //Цикл, работающий, пока не введены корректные данные
                    while (notOK)
                    {
                        Console.Write($"Введите matrix[{i}][{j}] (действительное число от -100000 до 100000): ");

                        top = Console.CursorTop;
                        left = Console.CursorLeft;

                        //Ввод очередного элемента матрицы
                        string str = Console.ReadLine();

                        //Проверка на возможность преобразования введённых символов в подходящее число
                        if (!(double.TryParse(str, out matrix[i, j]) ||
                            double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out matrix[i, j])))
                        {
                            //Если введённые символы - не число, затираем предполагаемую ошибку в следующей строке
                            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                            Console.SetCursorPosition(0, top + 1);

                            Console.WriteLine("Ошибка! Вы ввели не число, повторите ввод.");

                            //Затираем то, что введено в консоль, и возвращаем курсор в положение до ввода
                            Console.SetCursorPosition(left, top);
                            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                            Console.SetCursorPosition(0, top);
                        }
                        else if (Math.Abs(matrix[i, j]) > 100000)
                        {
                            //Если число не подходит
                            Console.WriteLine("Ошибка! Число не входит в заданный диапазон! Повторите ввод.");

                            //Затираем то, что введено в консоль, и возвращаем курсор в положение до ввода
                            Console.SetCursorPosition(left, top);
                            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                            Console.SetCursorPosition(0, top);
                        }
                        else
                        {
                            notOK = false;
                        }
                    }

                    //Форматирование элемента двумерного массива
                    string formattedNumber = matrix[i, j].ToString("0." + new string('#', 99));
                    matrix[i, j] = double.Parse(formattedNumber);
                }
            }
        }

        public void PrepareConsole()
        {
            //Функция подготавливает консоль к использованию

            Console.Title = "Матричка";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(128, 30);
            Console.CursorVisible = false;

            Console.SetCursorPosition(54, 0);
            Console.Write("Калькулятор матриц");
            Console.SetCursorPosition(0, 2);
            Console.Write(
                "╔═══════════════╗ ╔═══════════════╗ ╔═══════════════╗ ╔═══════════════╗ ╔═══════════════╗ ╔═══════════════╗ ╔═══════════════╗\n" +
                "║    умножить   ║ ║    сложить    ║ ║    вычесть    ║ ║  перемножить  ║ ║     найти     ║ ║транспонировать║ ║     найти     ║\n" +
                "║    матрицу    ║ ║    матрицы    ║ ║    матрицы    ║ ║    матрицы    ║ ║ определитель  ║ ║    матрицу    ║ ║    обратную   ║\n" +
                "║    на число   ║ ║               ║ ║               ║ ║               ║ ║    матрицы    ║ ║               ║ ║    матрицу    ║\n" +
                "╚═══════════════╝ ╚═══════════════╝ ╚═══════════════╝ ╚═══════════════╝ ╚═══════════════╝ ╚═══════════════╝ ╚═══════════════╝\n");
            Console.SetCursorPosition(0, 10);
            Console.Write("\tВыберите действие! Используйте стрелочки на клавиатуре ← →, чтобы перемещаться. Используйте Enter для ввода.");
        }
        void PrintChoice(int choice)
        {
            //Функция выводит импровизированный курсор под выбранной в данный момент операцией с матрицами
            //Перед выводом строка с курсором затирается
            //Входные данные: choice - выбранная в данный момент операция

            Console.SetCursorPosition(0, 7);
            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
            Console.SetCursorPosition(17 * (choice - 1) + (choice - 1), 7);
            Console.Write(new string('#', 17));
            Console.SetCursorPosition(0, 0);
        }
        public int MakeChoice()
        {
            //Функция, позволяющая выбрать производимую над матрицами операцию
            //Выходные данные: число choice типа int

            int choice = 1;
            ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo();

            //Пока не нажат Enter
            while (consoleKeyInfo.Key != ConsoleKey.Enter)
            {
                //Вывод курсора под выбранной в данный момент операцией
                PrintChoice(choice);

                consoleKeyInfo = Console.ReadKey(true);

                //Реализация кольцевой промотки выбираемых элементов

                if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (choice == 7)
                    {
                        choice = 1;
                    }
                    else
                    {
                        choice++;
                    }
                }

                if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (choice == 1)
                    {
                        choice = 7;
                    }
                    else
                    {
                        choice--;
                    }
                }
            }

            Console.Clear();
            Console.CursorVisible = true;

            return choice;
        }
        void SetSizes(out int size, string type)
        {
            //Функция ввода размеров матрицы
            //Входные данные: число size типа int, строка type
            //Выходные данные: число size типа int

            size = 0;

            //notOk - флаг, означающий, что введены корректные данные
            //top, left - координаты консольного курсора
            bool notOK = true;
            int top = 0;
            int left;

            //Цикл, работающий, пока не введены корректные данные
            while (notOK)
            {
                Console.Write("Введите количество " + type + " матрицы (от 1 до 10): ");

                top = Console.CursorTop;
                left = Console.CursorLeft;

                //Проверка на возможность преобразования введённых символов в подходящее число
                if (!int.TryParse(Console.ReadLine(), out size))
                {
                    //Если введённые символы - не число, затираем предполагаемую ошибку в следующей строке
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    Console.SetCursorPosition(0, top + 1);

                    Console.WriteLine("Ошибка! Вы ввели не число, повторите ввод.");

                    //Затираем то, что введено в консоль, и возвращаем курсор в положение до ввода
                    Console.SetCursorPosition(left, top);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    Console.SetCursorPosition(0, top);
                }
                else if (size < 1 || size > 10)
                {
                    //Если число не подходит
                    Console.WriteLine("Ошибка! Вы ввели некорректный размер! Повторите ввод.");

                    //Затираем то, что введено в консоль, и возвращаем курсор в положение до ввода
                    Console.SetCursorPosition(left, top);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    Console.SetCursorPosition(0, top);
                }
                else
                {
                    notOK = false;
                }
            }

            //Затирание ошибки в следующей строке консоли
            Console.SetCursorPosition(0, top + 1);
            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
            Console.SetCursorPosition(0, top + 1);
        }
        public void PrintMatrix(double[,] matrix, int width, int length)
        {
            //Метод вывода матрицы в консоль

            //Циклы по i, j проходятся по всем элементам двумерного массива
            for (int i = 0; i < width; i++)
            {
                Console.Write("|   ");

                for (int j = 0; j < length; j++)
                {
                    //Выбор подходящего формата вывода
                    if (Math.Abs(matrix[i, j]) < 0.001 && matrix[i, j] != 0)
                    {
                        if (matrix[i, j] > 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("  {0:0.000E+0}".PadLeft(11), matrix[i, j]);
                    }
                    else if (Math.Abs(matrix[i, j]) > 99999.999)
                    {
                        Console.Write(" {0:000.000E+0}".PadLeft(11), matrix[i, j]);
                    }
                    else
                    {
                        Console.Write(matrix[i, j].ToString("F3").PadLeft(11));
                    }

                    Console.Write("   ");
                }

                Console.WriteLine("|");
            }
        }
        public void SetMatrix(out Matrix matrix, bool first)
        {
            //Функция ввода матрицы
            //Входные данные: матрица matrix,
            //значения first типа bool, означаюшее, вводится ли первая матрица
            //Выходные данные: матрица matrix

            int width, length;

            if (first) { Console.WriteLine("Ввод размеров матрицы"); }
            else { Console.WriteLine("Ввод размеров второй матрицы"); }

            //ВВод размеров матрицы
            SetSizes(out width, "строк");
            SetSizes(out length, "столбцов");

            matrix = new Matrix(width, length);

            Console.Clear();

            if (first) { Console.WriteLine("Ввод матрицы"); }
            else { Console.WriteLine("Ввод второй матрицы"); }

            //Заполнение матрицы
            double[,] matr = new double[width, length];
            FillArray(matr, width, length);
            matrix.Fill(matr);

            //Вывод матрицы
            Console.Clear();
            Console.WriteLine("Ваша матрица");
            PrintMatrix(matrix.GetArray(), matrix.GetWidth(), matrix.GetLength());

            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            Console.Clear();
        }

        public void Operation1(Matrix matrix)
        {
            //Функция позволяет умножить матрицу на число
            //Входные данные: matrix - матрица

            //notOk - флаг, означающий, что введены корректные данные
            //top, left - координаты консольного курсора
            bool notOK = true;
            double x = 0;
            int top = 0;
            int left;

            //Пока не введено подходящее число
            while (notOK)
            {
                Console.Write("Введите действительное число от -100000 до 100000: ");

                top = Console.CursorTop;
                left = Console.CursorLeft;

                string str = Console.ReadLine();

                //Проверка на возможность преобразования введённых символов в подходящее число
                if (!(double.TryParse(str, out x) ||
                    double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out x)))
                {
                    //Если введённые символы - не число, затираем предполагаемую ошибку в следующей строке
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    Console.SetCursorPosition(0, top + 1);

                    Console.WriteLine("Ошибка! Вы ввели не число, повторите ввод.");

                    //Затираем то, что введено в консоль, и возвращаем курсор в положение до ввода
                    Console.SetCursorPosition(left, top);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    Console.SetCursorPosition(0, top);
                }
                else if (Math.Abs(x) > 100000)
                {
                    //Если число не подходит
                    Console.WriteLine("Ошибка! Число не входит в диапазон! Повторите ввод.");

                    //Затираем то, что введено в консоль, и возвращаем курсор в положение до ввода
                    Console.SetCursorPosition(left, top);
                    Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
                    Console.SetCursorPosition(0, top);
                }
                else
                {
                    notOK = false;
                }
            }

            //Затирание ошибки в следующей строке консоли
            Console.SetCursorPosition(0, top + 1);
            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
            Console.SetCursorPosition(0, top + 1);

            //Форматирование строки
            string formattedNumber = x.ToString("0." + new string('#', 99));
            x = double.Parse(formattedNumber);

            //Умножение матрицы на число
            matrix *= x;

            Console.Clear();

            //Вывод получившейся матрицы
            Console.WriteLine("Произведение исходной матрицы на чило " + x + "\n");
            PrintMatrix(matrix.GetArray(), matrix.GetWidth(), matrix.GetLength());
        }
        public void Operation2(Matrix matrix, Matrix matrix2)
        {
            //Функция позволяет сложить две матрицы
            //Входные данные: matrix, matrix2 - матрицы

            try
            {
                //Сложение матриц
                matrix += matrix2;

                //Вывод получившейся матрицы
                Console.WriteLine("Сумма исходных матриц\n");
                PrintMatrix(matrix.GetArray(), matrix.GetWidth(), matrix.GetLength());
            }
            catch
            {
                //Вывод ошибки
                Console.WriteLine("Нельзя сложить матрицы разных размеров!");
            }
        }
        public void Operation3(Matrix matrix, Matrix matrix2)
        {
            //Функция позволяет вычесть две матрицы
            //Входные данные: matrix, matrix2 - матрицы

            try
            {
                //Вычетание матриц
                matrix -= matrix2;

                //Вывод получившейся матрицы
                Console.WriteLine("Разность исходных матриц\n");
                PrintMatrix(matrix.GetArray(), matrix.GetWidth(), matrix.GetLength());
            }
            catch
            {
                //Вывод ошибки
                Console.WriteLine("Нельзя вычесть матрицы разных размеров!");
            }
        }
        public void Operation4(Matrix matrix, Matrix matrix2)
        {
            //Функция позволяет перемножить две матрицы
            //Входные данные: matrix, matrix2 - матрицы

            try
            {
                //Перемножение матриц
                matrix *= matrix2;

                //Вывод получившейся матрицы
                Console.WriteLine("Произведение исходных матриц\n");
                PrintMatrix(matrix.GetArray(), matrix.GetWidth(), matrix.GetLength());
            }
            catch
            {
                //Вывод ошибки
                Console.WriteLine("При умножении матриц количество столбцов первой матрицы" +
                    "должно быть равно количеству строк второй матрицы!");
            }
        }
        public void Operation5(Matrix matrix)
        {
            //Функция позволяет найти определитель матрицы
            //Входные данные: matrix - матрица

            try
            {
                //Нахождение определителя и его вывод
                Console.WriteLine("Определитель данной матрицы\n");
                Console.WriteLine(matrix.FindDeterminant());
            }
            catch
            {
                //Вывод ошибки
                Console.WriteLine("Определитель есть только у квадратной матрицы!");
            }
        }
        public void Operation6(Matrix matrix)
        {
            //Функция позволяет транспонировать матрицу
            //Входные данные: matrix - матрица

            //Транспонирование матрицы
            matrix.Transpose();

            //Вывод получившейся матрицы
            Console.WriteLine("Транспонированная матрица\n");
            PrintMatrix(matrix.GetArray(), matrix.GetWidth(), matrix.GetLength());
        }
        public void Operation7(Matrix matrix)
        {
            //Функция позволяет найти обратную матрицу
            //Входные данные: matrix - матрица

            try
            {
                //Нахождение обратной матрицы
                bool flag = matrix.Inverse();

                if (flag)
                {
                    //Вывод ошибки при поиске определителя
                    Console.WriteLine("Невозможно найти обратную матрицу, т.к. определитель матрицы равен нулю");
                }
                else
                {
                    //Вывод получившейся матрицы
                    Console.WriteLine("Обратная матрица для исходной\n");
                    PrintMatrix(matrix.GetArray(), matrix.GetWidth(), matrix.GetLength());
                }
            }
            catch
            {
                //Вывод ошибки
                Console.WriteLine("Чтобы найти обратную матрицу, матрица должна быть квадратной!");
            }
        }
    }
}
