using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework5
{
    internal static class Extensions
    {
        //Задание 2, подсчет символов в строке
        internal static int SymbolCount(this string someString, char symbol) => someString.Count(x => x == symbol);
        
        //Задание 3, подсчет элементов в списке
        internal static Dictionary<T, int> CountElements<T>(this List<T> list) => 
            list.GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.Count());
    }
}