using System;
using System.Collections;
using System.Collections.Generic;

/* На вход подается число N.
 * На каждой из следующих N строках записаны ФИО человека, 
 * разделенные одним пробелом. Отчество может отсутствовать.
 * Используя собственноручно написанный итератор, выведите имена людей,
 * отсортированные в лексико-графическом порядке в формате 
 *      <Фамилия_с_большой_буквы> <Заглавная_первая_буква_имени>.
 * Затем выведите имена людей в исходном порядке.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield.
 * 
 * Пример входных данных:
 * 3
 * Banana Bill Bananovich
 * Apple Alex Applovich
 * Carrot Clark Carrotovich
 * 
 * Пример выходных данных:
 * Apple A.
 * Banana B.
 * Carrot C.
 * 
 * Banana B.
 * Apple A.
 * Carrot C.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int N = int.Parse(Console.ReadLine());
                Person[] people = new Person[N];

                for (int i = 0; i < N; i++) people[i] = new Person(Console.ReadLine());

                People peopleList = new People(people);

                foreach (Person p in peopleList)
                    Console.WriteLine(p);

                foreach (Person p in peopleList.GetPeople)
                    Console.WriteLine(p);
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
            Console.ReadLine();
        }
    }

    public class Person: IComparable
    {
        public string firstName;
        public string lastName;
        private string v;

        public Person(string input)
        {
            firstName = input.Split()[1];
            lastName = input.Split()[0];
        }

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int CompareTo(object o)
        {
            Person person2 = o as Person;
            return this.ToString().CompareTo(person2.ToString());
        }

        public override string ToString()
        {
            return $"{lastName} {firstName[0]}.";
        }


    }


    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] people)
        {
            _people = people;
        }

        public Person[] GetPeople
        {
            get {
                return _people;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }
    
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;
        int position = -1;

        public PeopleEnum(Person[] people)
        {
            var peopleNew = new List<Person>();
            foreach (Person person in people)
            {
                peopleNew.Add(person);
            }
            peopleNew.Sort();
            _people = peopleNew.ToArray();
        }

        public bool MoveNext()
        {
            if (position < _people.Length - 1)
            {
                position++;
                return true;
            }
            return false;

        }

        public void Reset()
        {
            position = -1;
        }


        public Person Current => _people[position];

        object IEnumerator.Current => throw new NotImplementedException();
    }
}
