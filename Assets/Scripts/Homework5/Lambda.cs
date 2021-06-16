using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework5
{
    //Задание 4, преобразовать код с помощью лямбды
    public class Lambda
    {
        static void ConvertWithLambda()
        {
            var dict = new Dictionary<string, int>()
            {
                { "four" , 4 },
                { "two" , 2 },
                { "one" , 1 },
                { "three" , 3 } ,
            }.OrderBy(pair => pair.Value);
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}