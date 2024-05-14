namespace MatrixCalculator
{
    class Matrix
    {
        //Класс Matrix позволяет хранить в себе матрицу чисел типа double и производить действия с ней

        //matrix - двумерный массив чисел типа double
        //width, length - количество строк и столбцов матрицы (ширина и длина)
        double[,] matrix;
        int width, length;

        public Matrix(int width, int length)
        {
            //Конструктор класса Matrix
            //Выделяется память под двумерный массив matrix

            this.width = width;
            this.length = length;
            matrix = new double[width, length];
        }

        public override string ToString()
        {
            string str = string.Empty;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    str += matrix[i, j] + "\t";
                }
                str += "\n";
            }
            return str;
        }

        public void Fill(double[,] matr)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    matrix[i, j] = matr[i, j];
                }
            }
        }
        public double[,] GetArray() { return matrix; }
        public int GetWidth() { return width; }
        public int GetLength() { return length; }

        public void Transpose()
        {
            //Метод транспонирования матрицы

            double[,] tempMatrix = new double[length, width];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //Присвоение элементам новой матрицы значений элементов текущей матрицы
                    //в соответствии с правилом транспонирования
                    tempMatrix[j, i] = matrix[i, j];
                }
            }

            int temp = width;
            width = length;
            length = temp;

            matrix = tempMatrix;
        }
        void FillAlgCompl(double[,] matr, int y, int x)
        {
            //Метод заполнения матрицы для расчета алгебраического дополнения
            //Входные данные: matr - двумерный массив,
            //y - номер столбца, который не надо включать в матрицу,
            //x - номер строки, которую не надо включать в матрицу

            bool flag = false;

            //Цикслы по i, j проходятся по всем элементам двумерного массива matr
            for (int i = 0, i2 = 0; i <= length; i++)
            {
                for (int j = 0, j2 = 0; j <= length; j++)
                {
                    //Проверка, чтобы не включать в matrix выбранные строку и столбец
                    if (!(i == y || j == x))
                    {
                        matrix[i2, j2] = matr[i, j];
                        j2++;
                        flag = true;
                    }
                }

                if (flag)
                {
                    i2++;
                    flag = false;
                }
            }
        }
        public bool Inverse()
        {
            //Метод, вычисляющий обратную матрицу
            //Выходные данные: значение типа double, означающее, прошла ли операция успешно

            //Если определитель матрицы равен нулю, выходим из метода, сообщая о невозможности нахождения обратной матрицы
            if (FindDeterminant() == 0)
            {
                return true;
            }

            double x = 1 / FindDeterminant();

            //Матрица транспонируется
            Transpose();

            double[,] algComplMatrix = new double[width, length];

            //Находится матрица алгебраических дополнений всех элементов матрицы
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Matrix tempMatrix = new Matrix(length - 1, length - 1);
                    tempMatrix.FillAlgCompl(matrix, i, j);

                    algComplMatrix[i, j] = tempMatrix.FindDeterminant();
                    if ((i + j) % 2 != 0)
                    {
                        algComplMatrix[i, j] = -algComplMatrix[i, j];
                    }
                }
            }

            matrix = algComplMatrix;
            Matrix temp = this * x;
            matrix = temp.matrix;

            return false;
        }
        public double FindDeterminant()
        {
            //Метод, считающий определить матрицы прямым и обратным методом Гаусса
            //Выходные данные: число det типа double

            //Если в процессе расчетавозникает деление на ноль, в месте вызова данного метода ловится ошибка, означающая, что
            //определитель матрицы равен нулю

            double[,] temp = new double[length, length];

            //Элементам двумерного массива temp присваиваются элементы двумерного массива matrix
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    temp[i, j] = matrix[i, j];
                }
            }

            double x = 0;
            bool flag = true;

            //С помощью вычитания строк, умноженных на вычисляемые коэффициенты матрица приводится к треугольной
            for (int k = 0; k < length - 1; k++)
            {
                for (int i = 1 + k; i < length; i++)
                {
                    for (int j = k; j < length; j++)
                    {
                        if (flag)
                        {
                            if (temp[k, k] == 0) { return 0; }
                            x = temp[i, k] / temp[k, k];
                            flag = false;
                        }
                        temp[i, j] -= x * temp[k, j];
                    }
                    flag = true;
                }
            }

            flag = true;
            int y = length - 1;

            //С помощью вычитания строк, умноженных на вычисляемые коэффициенты матрица приводится к диагональной
            for (int k = length - 1; k > 0; k--)
            {
                for (int i = length - 2 - y + k; i >= 0; i--)
                {
                    for (int j = length - 1 - y + k; j >= 0; j--)
                    {
                        if (flag)
                        {
                            if (temp[k, k] == 0) { return 0; }
                            x = temp[i, k] / temp[k, k];
                            flag = false;
                        }
                        temp[i, j] -= x * temp[k, j];
                    }
                    flag = true;
                }
            }

            double det = 1;

            //Определитель считается как произведение диагональных элементов
            for (int i = 0; i < length; i++)
            {
                det *= temp[i, i];
            }

            return det;
        }

        public static Matrix operator *(Matrix m, double digit)
        {
            //Перегрузка оператора "*"
            //Матрица умножается на число
            //Входные данные: m - матрица, digit - число
            //Выходные данные: матрица temp

            Matrix temp = new Matrix(m.width, m.length);

            //Все элементы матрицы m умножаются на число digit
            for (int i = 0; i < temp.width; i++)
            {
                for (int j = 0; j < temp.length; j++)
                {
                    temp.matrix[i, j] = m.matrix[i, j] * digit;
                }
            }

            return temp;
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            //Перегрузка оператора "+"
            //Складываются две матрицы
            //Входные данные: m1, m2 - матрицы
            //Выходные данные: матрица sum

            //Проверка на возможность сложения матриц данных размеров
            if (!(m1.width == m2.width && m1.length == m2.length))
            {
                return null;
            }

            Matrix sum = new Matrix(m1.width, m1.length);

            //Сложение соответствующих элементов матриц m1 и m2
            for (int i = 0; i < m1.width; i++)
            {
                for (int j = 0; j < m1.length; j++)
                {
                    sum.matrix[i, j] = m1.matrix[i, j] + m2.matrix[i, j];
                }
            }

            return sum;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            //Перегрузка оператора "-"
            //Матрица m2 вычитается из матрицы m1
            //Входные данные: m1, m2 - матрицы
            //Выходные данные: матрица

            //Матрица m1 складывается с матрицей m2, умноженной на -1
            return m1 + m2 * (-1);
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            //Перегрузка оператора "*"
            //Матрица m1 умножается на матрицу m2
            //Входные данные: m1, m2 - матрицы
            //Выходные данные: матрица product

            //Проверка на возможность перемножения матриц данных размеров
            if (m1.length != m2.width)
            {
                return null;
            }

            Matrix product = new Matrix(m1.width, m2.length);

            //Происходит перемножение двух матриц в соответствии с правилами умножения матриц
            for (int i = 0; i < product.width; i++)
            {
                for (int j = 0; j < product.length; j++)
                {
                    product.matrix[i, j] = 0;

                    for (int k = 0; k < m1.length; k++)
                    {
                        product.matrix[i, j] += m1.matrix[i, k] * m2.matrix[k, j];
                    }
                }
            }

            return product;
        }
    }
}