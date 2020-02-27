using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelagatesLambda
{
    class Program
    {
        delegate double MyDelegate (double a, double b, double c);
        delegate int Rand();
        delegate double ArrDelegate(Rand[] r);
        static Random random = new Random();

        static void Main(string[] args)
        {
            #region Task 1 
            // 1)  Создайте анонимный метод, который принимает в качестве параметров три целочисленных аргумента и
            //возвращает среднее арифметическое этих аргументов.

            MyDelegate average = delegate (double a, double b, double c) { return (a + b + c) / 3.0; }; // просто анонимный метод
            average = (double a, double b, double c) => (a + b + c) / 3.0; //  и с исспользованием лямбда выражений
            #endregion

            #region Task 2
            // 2) Создайте четыре лямбда оператора для выполнения арифметических действий: (Add – сложение, Sub –
            //вычитание, Mul – умножение, Div – деление). Каждый лямбда оператор должен принимать два аргумента и
            //возвращать результат вычисления.Лямбда оператор деления должен делать проверку деления на ноль.
            //Написать программу, которая будет выполнять арифметические действия указанные пользователем.
            MyMath myMath = new MyMath();
            myMath.Add(2,3);
            myMath.Sub(2, 2);
            #endregion

            #region Task 3
            // 3) Создайте анонимный метод, который принимает в качестве аргумента массив делегатов и возвращает среднее
            //арифметическое возвращаемых значений методов сообщенных с делегатами в массиве.Методы, сообщенные с
            //делегатами из массива, возвращают случайное значение типа int.

           
            Rand[] rands = new Rand[10];
            for (int i = 0; i < rands.Length; i++)
            {
                rands[i] = () => random.Next(1,100);
                Console.WriteLine(rands[i]());
            }

            Console.WriteLine("Average = " + AverageIt(rands) );

            #endregion


            Console.ReadKey();
        }

        static ArrDelegate AverageIt = (Rand[] dels) =>
        {
            int sum = 0;
            foreach (Rand i in dels)
            {
                sum += i();
            }

            return sum / dels.Length;
        };
    }
}
