using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N элементов последовательного ряда натуральных чисел, возведенных в 10 степень, 
 * и вывести ее на экран ТРИЖДЫ. Инвертировать порядок элементов при каждом последующем выводе.
 * Элементы коллекции разделять пробелом. 
 * Очередной вывод коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 2
 * 
 * Пример выходных данных:
 * 1 1024
 * 1024 1
 * 1 1024
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * В других ситуациях выбрасывайте 
*/
namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var value = int.Parse(Console.ReadLine());

                MyDigits myDigits = new MyDigits();
                IEnumerator enumerator = myDigits.MyEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("ooops");
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
            Console.ReadKey();
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            if (enumerator.MoveNext())
                Console.Write(enumerator.Current);

            while (enumerator.MoveNext())
                Console.Write(" " + enumerator.Current);
        }
    }

    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        int max;
        int current = 0;
        bool reverse = false;

        public object Current => (long)Math.Pow(current, 10);

        public bool MoveNext()
        {
            if ((!reverse && current + 1 > max) || (reverse && current - 1 <= 0))
            {
                Reset();
                return false;
            }
            if (reverse) current--;
            else current++;
            return true;
        }

        public void Reset()
        {
            reverse = !reverse;
            if (reverse) current = max + 1;
            else current = 0;
        }

        internal IEnumerator MyEnumerator(int value)
        {
            this.max = value;
            return this;
        }
    }
}
