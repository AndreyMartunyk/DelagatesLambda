using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelagatesLambda
{
    class MyMath
    {
        // я тут немного поигрался с разными вариациями лямбда выражений

        public delegate double MathDelegate(double a, double b);

        //public MathDelegate Add = (double a, double b) => a + b;
        public MathDelegate Add // 4) вот тут я немног поигрался, мне стало интересто можно ли сделать скрытый делегат от подписки
        {                       // оказалось можно, но я так и не придумал зачем?))
            get                 // хотя если представить наши делегаты лишь набор действий/свойств присущие обьекту
            {                   // и мы складываем и выкладывам их из контейнера этих делегатов при опред. условиях, меняя его поведение
                return (double a, double b) => a + b;  //так делают? или бред какой-то?)
            }
            private set { }
        }
        public double Sub(double a, double b) => a - b; // 1) тот случай когда лябда выражение просто "укорачивает" запись, никакого отношения к делегатам тут нет.
        public MathDelegate Mul = (double a, double b) => a * b; // 2) самый тривиальный случай исспользования лямбды
        public MathDelegate Div = (double a, double b) => // 3) тут пришлось прибегнуть к скобкам, так как не получается сделать все в одну строчку*
        {                                                 // *вообще можно было бы исспользовать тернарный оператор, но я читал что это так себе практика и лучше ею не пользоваться, да и мне не очень нравится. Одно дело когда это пишу я, другое когда читаю чужой тернарник
            if (a == 0)
            {
                return 0;
            }

            return a / b;
        };
    }
}
