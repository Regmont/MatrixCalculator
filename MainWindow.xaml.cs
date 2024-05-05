using System;
using System.Windows;

namespace MatrixCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Подготовка консоли
            MyConsole myConsole = new MyConsole();
            myConsole.PrepareConsole();

            Matrix matrix = null;
            Matrix matrix2;

            //Выбор действия
            int choice = myConsole.MakeChoice();

            //Заполнение первой матрицы
            myConsole.SetMatrix(out matrix, true);

            //Заполнение второй матрицы при действии с двумя матрицами
            if (choice > 1 && choice < 5) { myConsole.SetMatrix(out matrix2, false); }
            else { matrix2 = new Matrix(0, 0); }

            //Вызов функции, соответствующей действию
            switch (choice)
            {
                case 1:
                    myConsole.Operation1(matrix);
                    break;
                case 2:
                    myConsole.Operation2(matrix, matrix2);
                    break;
                case 3:
                    myConsole.Operation3(matrix, matrix2);
                    break;
                case 4:
                    myConsole.Operation4(matrix, matrix2);
                    break;
                case 5:
                    myConsole.Operation5(matrix);
                    break;
                case 6:
                    myConsole.Operation6(matrix);
                    break;
                case 7:
                    myConsole.Operation7(matrix);
                    break;
            }

            Console.WriteLine("\n");
        }
    }
}