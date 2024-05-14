using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MatrixCalculator
{
    public partial class MainWindow : Window
    {
        TextBox[,] boxes, boxes2;
        Matrix matrix, matrix2;

        public MainWindow()
        {
            InitializeComponent();

            boxes = new TextBox[10, 10]
            {
                { tbFirst_0_0, tbFirst_0_1, tbFirst_0_2, tbFirst_0_3, tbFirst_0_4,
                    tbFirst_0_5, tbFirst_0_6, tbFirst_0_7, tbFirst_0_8, tbFirst_0_9 },
                { tbFirst_1_0, tbFirst_1_1, tbFirst_1_2, tbFirst_1_3, tbFirst_1_4,
                    tbFirst_1_5, tbFirst_1_6, tbFirst_1_7, tbFirst_1_8, tbFirst_1_9 },
                { tbFirst_2_0, tbFirst_2_1, tbFirst_2_2, tbFirst_2_3, tbFirst_2_4,
                    tbFirst_2_5, tbFirst_2_6, tbFirst_2_7, tbFirst_2_8, tbFirst_2_9 },
                { tbFirst_3_0, tbFirst_3_1, tbFirst_3_2, tbFirst_3_3, tbFirst_3_4,
                    tbFirst_3_5, tbFirst_3_6, tbFirst_3_7, tbFirst_3_8, tbFirst_3_9 },
                { tbFirst_4_0, tbFirst_4_1, tbFirst_4_2, tbFirst_4_3, tbFirst_4_4,
                    tbFirst_4_5, tbFirst_4_6, tbFirst_4_7, tbFirst_4_8, tbFirst_4_9 },
                { tbFirst_5_0, tbFirst_5_1, tbFirst_5_2, tbFirst_5_3, tbFirst_5_4,
                    tbFirst_5_5, tbFirst_5_6, tbFirst_5_7, tbFirst_5_8, tbFirst_5_9 },
                { tbFirst_6_0, tbFirst_6_1, tbFirst_6_2, tbFirst_6_3, tbFirst_6_4,
                    tbFirst_6_5, tbFirst_6_6, tbFirst_6_7, tbFirst_6_8, tbFirst_6_9 },
                { tbFirst_7_0, tbFirst_7_1, tbFirst_7_2, tbFirst_7_3, tbFirst_7_4,
                    tbFirst_7_5, tbFirst_7_6, tbFirst_7_7, tbFirst_7_8, tbFirst_7_9 },
                { tbFirst_8_0, tbFirst_8_1, tbFirst_8_2, tbFirst_8_3, tbFirst_8_4,
                    tbFirst_8_5, tbFirst_8_6, tbFirst_8_7, tbFirst_8_8, tbFirst_8_9 },
                { tbFirst_9_0, tbFirst_9_1, tbFirst_9_2, tbFirst_9_3, tbFirst_9_4,
                    tbFirst_9_5, tbFirst_9_6, tbFirst_9_7, tbFirst_9_8, tbFirst_9_9 }
            };
            boxes2 = new TextBox[10, 10]
            {
                { tbSecond_0_0, tbSecond_0_1, tbSecond_0_2, tbSecond_0_3, tbSecond_0_4,
                    tbSecond_0_5, tbSecond_0_6, tbSecond_0_7, tbSecond_0_8, tbSecond_0_9 },
                { tbSecond_1_0, tbSecond_1_1, tbSecond_1_2, tbSecond_1_3, tbSecond_1_4,
                    tbSecond_1_5, tbSecond_1_6, tbSecond_1_7, tbSecond_1_8, tbSecond_1_9 },
                { tbSecond_2_0, tbSecond_2_1, tbSecond_2_2, tbSecond_2_3, tbSecond_2_4,
                    tbSecond_2_5, tbSecond_2_6, tbSecond_2_7, tbSecond_2_8, tbSecond_2_9 },
                { tbSecond_3_0, tbSecond_3_1, tbSecond_3_2, tbSecond_3_3, tbSecond_3_4,
                    tbSecond_3_5, tbSecond_3_6, tbSecond_3_7, tbSecond_3_8, tbSecond_3_9 },
                { tbSecond_4_0, tbSecond_4_1, tbSecond_4_2, tbSecond_4_3, tbSecond_4_4,
                    tbSecond_4_5, tbSecond_4_6, tbSecond_4_7, tbSecond_4_8, tbSecond_4_9 },
                { tbSecond_5_0, tbSecond_5_1, tbSecond_5_2, tbSecond_5_3, tbSecond_5_4,
                    tbSecond_5_5, tbSecond_5_6, tbSecond_5_7, tbSecond_5_8, tbSecond_5_9 },
                { tbSecond_6_0, tbSecond_6_1, tbSecond_6_2, tbSecond_6_3, tbSecond_6_4,
                    tbSecond_6_5, tbSecond_6_6, tbSecond_6_7, tbSecond_6_8, tbSecond_6_9 },
                { tbSecond_7_0, tbSecond_7_1, tbSecond_7_2, tbSecond_7_3, tbSecond_7_4,
                    tbSecond_7_5, tbSecond_7_6, tbSecond_7_7, tbSecond_7_8, tbSecond_7_9 },
                { tbSecond_8_0, tbSecond_8_1, tbSecond_8_2, tbSecond_8_3, tbSecond_8_4,
                    tbSecond_8_5, tbSecond_8_6, tbSecond_8_7, tbSecond_8_8, tbSecond_8_9 },
                { tbSecond_9_0, tbSecond_9_1, tbSecond_9_2, tbSecond_9_3, tbSecond_9_4,
                    tbSecond_9_5, tbSecond_9_6, tbSecond_9_7, tbSecond_9_8, tbSecond_9_9 }
            };
        }

        bool CheckValue(TextBox[,] tb, double[,] matr, int width, int length)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            SolidColorBrush brushError = new SolidColorBrush(Colors.Red);

            bool flag = false;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!(double.TryParse(tb[i, j].Text, out matr[i, j]) ||
                        double.TryParse(tb[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr[i, j])))
                    {
                        tb[i, j].Background = brushError;
                        flag =  true;
                    }
                    else
                    {
                        tb[i, j].Background = brush;
                    }
                }
            }

            return flag;
        }
        bool SetSizes(TextBox tbWidth, TextBox tbLength, TextBox[,] tb)
        {
            int width, length;
            int.TryParse(tbWidth.Text, out width);
            int.TryParse(tbLength.Text, out length);

            bool flag1 = false, flag2 = false;
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            SolidColorBrush brushError = new SolidColorBrush(Colors.Red);

            if (width < 1 || width > 10) { tbWidth.Background = brushError; flag1 = true; }
            else { tbWidth.Background = brush; flag1 = false; }

            if (length < 1 || length > 10) { tbLength.Background = brushError; flag2 = true; }
            else { tbLength.Background = brush; flag2 = false; }

            if (flag1 || flag2) { return false; }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i < width && j < length)
                    {
                        tb[i, j].IsEnabled = true;
                    }
                    else
                    {
                        tb[i, j].Text = string.Empty;
                        tb[i, j].IsEnabled = false;
                    }
                }
            }

            return true;
        }
        void ClearMatr(TextBox tbWidth, TextBox tbLength, TextBox[,] tb)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);

            tbWidth.Text = string.Empty;
            tbLength.Text = string.Empty;
            tbWidth.Background = brush;
            tbLength.Background = brush;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tb[i, j].Text = string.Empty;
                    tb[i, j].Background = brush;
                    tb[i, j].IsEnabled = false;
                }
            }
        }
        void PrintMatr(Matrix matr, TextBox tbWidth, TextBox tbLength, TextBox[,] tb)
        {
            ClearMatr(tbWidth, tbLength, tb);

            tbWidth.Text = matr.GetWidth().ToString();
            tbLength.Text = matr.GetLength().ToString();

            for (int i = 0; i < matr.GetWidth(); i++)
            {
                for (int j = 0; j < matr.GetLength(); j++)
                {
                    tb[i, j].IsEnabled = true;
                    tb[i, j].Text = matr.GetArray()[i, j].ToString();
                }
            }
        }

        private void btnSwap_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brushError = new SolidColorBrush(Colors.Red);
             
            int width, width2, length, length2;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);
            int.TryParse(tbSecondWidth.Text, out width2);
            int.TryParse(tbSecondLength.Text, out length2);

            if (!tbFirst_0_0.IsEnabled && !tbSecond_0_0.IsEnabled) { return; }

            double[,] matr, matr2;
            bool flag, flag2;

            if (!tbFirst_0_0.IsEnabled)
            {
                matr2 = new double[width2, length2];
                if (CheckValue(boxes2, matr2, width2, length2)) { return; }

                for (int i = 0; i < width2; i++)
                {
                    for (int j = 0; j < length2; j++)
                    {
                        if (!double.TryParse(boxes2[i, j].Text, out matr2[i, j]))
                        {
                            double.TryParse(boxes2[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr2[i, j]);
                        }
                    }
                }

                ClearMatr(tbSecondWidth, tbSecondLength, boxes2);

                matrix = new Matrix(width2, length2);
                matrix.Fill(matr2);
                PrintMatr(matrix, tbFirstWidth, tbFirstLength, boxes);

                tbSecondWidth.Text = string.Empty;
                tbSecondLength.Text = string.Empty;
                btnFirstEnter.IsEnabled = false;
                tbFirstWidth.IsEnabled = false;
                tbFirstLength.IsEnabled = false;
                btnSecondEnter.IsEnabled = true;
                tbSecondWidth.IsEnabled = true;
                tbSecondLength.IsEnabled = true;

                return;
            }

            if (!tbSecond_0_0.IsEnabled)
            {
                matr = new double[width, length];
                if (CheckValue(boxes, matr, width, length)) { return; }

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (!double.TryParse(boxes[i, j].Text, out matr[i, j]))
                        {
                            double.TryParse(boxes[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr[i, j]);
                        }
                    }
                }

                ClearMatr(tbFirstWidth, tbFirstLength, boxes);

                matrix2 = new Matrix(width, length);
                matrix2.Fill(matr);
                PrintMatr(matrix2, tbSecondWidth, tbSecondLength, boxes2);

                tbFirstWidth.Text = string.Empty;
                tbFirstLength.Text = string.Empty;
                btnFirstEnter.IsEnabled = true;
                tbFirstWidth.IsEnabled = true;
                tbFirstLength.IsEnabled = true;
                btnSecondEnter.IsEnabled = false;
                tbSecondWidth.IsEnabled = false;
                tbSecondLength.IsEnabled = false;

                return;
            }

            if (width < 0 || width > 10 || length < 0 || length > 10) { return; }
            if (width2 < 0 || width2 > 10 || length2 < 0 || length2 > 10) { return; }

            matr = new double[width, length];
            matr2 = new double[width2, length2];
            flag = CheckValue(boxes, matr, width, length);
            flag2 = CheckValue(boxes2, matr2, width2, length2);

            if (flag || flag2) { return; }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!double.TryParse(boxes[i, j].Text, out matr[i, j]))
                    {
                        double.TryParse(boxes[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr[i, j]);
                    }
                }
            }

            for (int i = 0; i < width2; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    if (!double.TryParse(boxes2[i, j].Text, out matr2[i, j]))
                    {
                        double.TryParse(boxes2[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr2[i, j]);
                    }
                }
            }

            matrix = new Matrix(width2, length2);
            matrix2 = new Matrix(width, length);

            matrix.Fill(matr2);
            matrix2.Fill(matr);

            PrintMatr(matrix, tbFirstWidth, tbFirstLength, boxes);
            PrintMatr(matrix2, tbSecondWidth, tbSecondLength, boxes2);
        }
        private void btnMultNumber_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            SolidColorBrush brushError = new SolidColorBrush(Colors.Red);

            int width, length;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);

            if (width < 1 || width > 10 || length < 1 || length > 10) { return; }

            double[,] matr = new double[width, length];
            if (CheckValue(boxes, matr, width, length)) { return; }

            double number;
            if (!(double.TryParse(tbNumber.Text, out number) ||
                double.TryParse(tbNumber.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out number)))
            {
                tbNumber.Background = brushError;
                return;
            }
            else
            {
                tbNumber.Background = brush;
            }

            matrix = new Matrix(width, length);
            matrix.Fill(matr);

            MessageBox.Show((matrix * number).ToString(), "Произведение матрицы на число", MessageBoxButton.OK);
        }

        private void btnDeterm_Click(object sender, RoutedEventArgs e)
        {
            int width, length;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);

            if (width < 1 || width > 10 || length < 1 || length > 10) { return; }

            double[,] matr = new double[width, length];
            if (CheckValue(boxes, matr, width, length)) { return; }

            if (width != length)
            {
                MessageBox.Show("Определитель есть только у квадратной матрицы!", "Определитель матрицы", MessageBoxButton.OK);
                return;
            }

            matrix = new Matrix(width, length);
            matrix.Fill(matr);

            MessageBox.Show(matrix.FindDeterminant().ToString(), "Определитель матрицы", MessageBoxButton.OK);
        }
        private void btnTransp_Click(object sender, RoutedEventArgs e)
        {
            int width, length;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);

            if (width < 1 || width > 10 || length < 1 || length > 10) { return; }

            double[,] matr = new double[width, length];
            if (CheckValue(boxes, matr, width, length)) { return; }

            matrix = new Matrix(width, length);
            matrix.Fill(matr);
            matrix.Transpose();

            MessageBox.Show(matrix.ToString(), "Транспонированная матрица", MessageBoxButton.OK);
        }
        private void btnInverse_Click(object sender, RoutedEventArgs e)
        {
            int width, length;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);

            if (width < 1 || width > 10 || length < 1 || length > 10) { return; }

            double[,] matr = new double[width, length];
            if (CheckValue(boxes, matr, width, length)) { return; }

            if (width != length)
            {
                MessageBox.Show("Матрица должна быть квадратной!", "Обратная матрицы", MessageBoxButton.OK);
                return;
            }

            matrix = new Matrix(width, length);
            matrix.Fill(matr);
            bool flag = matrix.Inverse();

            if (flag)
            {
                MessageBox.Show("Невозможно найти обратную матрицу,\nт.к. определитель данной матрицы\nравен нулю",
                    "Обратная матрицы", MessageBoxButton.OK);
                return;
            }
            MessageBox.Show(matrix.ToString(), "Обратная матрицы", MessageBoxButton.OK);
        }

        private void btnSum_Click(object sender, RoutedEventArgs e)
        {
            int width, width2, length, length2;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);
            int.TryParse(tbSecondWidth.Text, out width2);
            int.TryParse(tbSecondLength.Text, out length2);

            if (width < 1 || width > 10 || length < 1 || length > 10 ||
                width2 < 1 || width2 > 10 || length2 < 1 || length2 > 10) { return; }

            double[,] matr, matr2;
            bool flag, flag2;

            matr = new double[width, length];
            matr2 = new double[width2, length2];
            flag = CheckValue(boxes, matr, width, length);
            flag2 = CheckValue(boxes2, matr2, width2, length2);

            if (width != width2 || length != length2)
            {
                MessageBox.Show("Можно сложить только матрицы одинаковых размеров!", "Сумма матриц", MessageBoxButton.OK);
                return;
            }

            if (flag || flag2) { return; }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!double.TryParse(boxes[i, j].Text, out matr[i, j]))
                    {
                        double.TryParse(boxes[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr[i, j]);
                    }
                }
            }

            for (int i = 0; i < width2; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    if (!double.TryParse(boxes2[i, j].Text, out matr2[i, j]))
                    {
                        double.TryParse(boxes2[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr2[i, j]);
                    }
                }
            }

            matrix = new Matrix(width2, length2);
            matrix2 = new Matrix(width, length);

            matrix.Fill(matr2);
            matrix2.Fill(matr);

            MessageBox.Show((matrix + matrix2).ToString(), "Сумма матриц", MessageBoxButton.OK);
        }
        private void btnDif_Click(object sender, RoutedEventArgs e)
        {
            int width, width2, length, length2;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);
            int.TryParse(tbSecondWidth.Text, out width2);
            int.TryParse(tbSecondLength.Text, out length2);

            if (width < 1 || width > 10 || length < 1 || length > 10 ||
                width2 < 1 || width2 > 10 || length2 < 1 || length2 > 10) { return; }

            double[,] matr, matr2;
            bool flag, flag2;

            matr = new double[width, length];
            matr2 = new double[width2, length2];
            flag = CheckValue(boxes, matr, width, length);
            flag2 = CheckValue(boxes2, matr2, width2, length2);

            if (width != width2 || length != length2)
            {
                MessageBox.Show("Можно получить разность только матрицы одинаковых размеров!", "Разность матриц", MessageBoxButton.OK);
                return;
            }

            if (flag || flag2) { return; }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!double.TryParse(boxes[i, j].Text, out matr[i, j]))
                    {
                        double.TryParse(boxes[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr[i, j]);
                    }
                }
            }

            for (int i = 0; i < width2; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    if (!double.TryParse(boxes2[i, j].Text, out matr2[i, j]))
                    {
                        double.TryParse(boxes2[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr2[i, j]);
                    }
                }
            }

            matrix = new Matrix(width2, length2);
            matrix2 = new Matrix(width, length);

            matrix.Fill(matr2);
            matrix2.Fill(matr);

            MessageBox.Show((matrix - matrix2).ToString(), "Разность матриц", MessageBoxButton.OK);
        }
        private void btnProd_Click(object sender, RoutedEventArgs e)
        {
            int width, width2, length, length2;
            int.TryParse(tbFirstWidth.Text, out width);
            int.TryParse(tbFirstLength.Text, out length);
            int.TryParse(tbSecondWidth.Text, out width2);
            int.TryParse(tbSecondLength.Text, out length2);

            if (width < 1 || width > 10 || length < 1 || length > 10 ||
                width2 < 1 || width2 > 10 || length2 < 1 || length2 > 10) { return; }

            double[,] matr, matr2;
            bool flag, flag2;

            matr = new double[width, length];
            matr2 = new double[width2, length2];
            flag = CheckValue(boxes, matr, width, length);
            flag2 = CheckValue(boxes2, matr2, width2, length2);

            if (width != length2 || length != width2)
            {
                MessageBox.Show("При перемножении матриц количество столбцов первой матрицы\n" +
                    "должно быть равно количеству строк второй матрицы!", "Произведение матриц", MessageBoxButton.OK);
                return;
            }

            if (flag || flag2) { return; }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!double.TryParse(boxes[i, j].Text, out matr[i, j]))
                    {
                        double.TryParse(boxes[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr[i, j]);
                    }
                }
            }

            for (int i = 0; i < width2; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    if (!double.TryParse(boxes2[i, j].Text, out matr2[i, j]))
                    {
                        double.TryParse(boxes2[i, j].Text, NumberStyles.Float, CultureInfo.InvariantCulture, out matr2[i, j]);
                    }
                }
            }

            matrix = new Matrix(width2, length2);
            matrix2 = new Matrix(width, length);

            matrix.Fill(matr2);
            matrix2.Fill(matr);

            MessageBox.Show((matrix * matrix2).ToString(), "Произведение матриц", MessageBoxButton.OK);
        }

        private void btnFirstClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMatr(tbFirstWidth, tbFirstLength, boxes);
            tbFirstWidth.IsEnabled = true;
            tbFirstLength.IsEnabled = true;
            btnFirstEnter.IsEnabled = true;
        }
        private void btnSecondClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMatr(tbSecondWidth, tbSecondLength, boxes2);
            tbSecondWidth.IsEnabled = true;
            tbSecondLength.IsEnabled = true;
            btnSecondEnter.IsEnabled = true;
        }

        private void btnFirstEnter_Click(object sender, RoutedEventArgs e)
        {
            if (SetSizes(tbFirstWidth, tbFirstLength, boxes))
            {
                btnFirstEnter.IsEnabled = false;
                tbFirstWidth.IsEnabled = false;
                tbFirstLength.IsEnabled = false;
            }
        }
        private void btnSecondEnter_Click(object sender, RoutedEventArgs e)
        {
            if (SetSizes(tbSecondWidth, tbSecondLength, boxes2))
            {
                btnSecondEnter.IsEnabled = false;
                tbSecondWidth.IsEnabled = false;
                tbSecondLength.IsEnabled = false;
            }
        }
    }
}