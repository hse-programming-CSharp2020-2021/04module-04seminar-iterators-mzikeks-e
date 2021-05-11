using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N квадратов последовательного ряда натуральных чисел 
 * и вывести ее на экран дважды. Элементы коллекции разделять пробелом. 
 * Выводы всей коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 3
 * 
 * Пример выходных данных:
 * 1 4 9
 * 1 4 9
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int value = int.Parse(Console.ReadLine());
                if (value < 1) throw new ArgumentException();
                
                MyInts myInts = new MyInts();
                IEnumerator enumerator = myInts.MyEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
            Console.ReadLine();
            
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            if (enumerator.MoveNext())
                Console.Write(enumerator.Current);

            while (enumerator.MoveNext())
                Console.Write(" " + enumerator.Current);
        }
    }

    class MyInts : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        int value;
        int current = 0;

        internal IEnumerator MyEnumerator(int value)
        {
            this.value = value;
            return this;
        }

        public bool MoveNext()
        {
            if (current + 1 > value)
            {
                Reset();
                return false;
            }
            current++;
            return true;
        }

        public void Reset()
        {
            current = 0;
        }

        public object Current => current * current;
    }
}
