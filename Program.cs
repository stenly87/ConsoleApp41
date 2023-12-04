using System;
using System.Xml.Linq;

namespace ConsoleApp41
{
    class Program
    { 
        public static void Main(string[] args)
        {
            //Паттерн Синглтон (Singleton)
            //порождающий паттерн
            //гарантирует, что для заданного класса
            //на все приложение будет существовать только
            //один экземпляр
            // например это ссылка на базу данных

            // получение объекта через синглтон
            PPK ppk = PPK.GetInstance();
            // далее используем объект как обычно
            Console.WriteLine(ppk.Name);

            // пример использования
            List<Student> studs = StudentBase.
                GetInstance().GetStudents("Паша");

            // Строитель (Builder)
            // порождающий паттерн
            // Применяется в ситуациях, когда создаваемый
            // объект настраивается вариативным образом
            // билдер предоставляет методы для добавления
            // вариаций и создает конечный объект


            // пример использования билдера
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            Cooker cooker = new Cooker(burgerBuilder);
            var вкусныйСочныйБургерМечты = cooker.CookBurger();
            Console.WriteLine(вкусныйСочныйБургерМечты);
            BadCooker badCooker = new BadCooker(burgerBuilder);
            var НЕвкусныйСочныйБургерМечты = badCooker.CookBurger();
            Console.WriteLine(НЕвкусныйСочныйБургерМечты);
        }
    }

    public class PPK
    {
        // начало синглтон (простая реализация, без учета
        // потоков
        static PPK instance;

        private PPK() {
            Name = "КГА ПОУ ППК"; // пример
        }

        static object locker = new object(); // эта строка добавляется при реализации с учетом потоков
        public static PPK GetInstance()
        {
            lock (locker) // эта строка добавляется при реализации с учетом потоков
            {
                if (instance == null)
                    instance = new PPK();
                return instance;
            }
        }
        // конец синглтон

        // далее обычный класс с данными и функциями
        public string Name { get; private set; }
    }

    public class StudentBase
    {
        static StudentBase instance;

        private StudentBase()
        {
            // загрузка из файла List<Student>();
        }

        static object locker = new object(); // эта строка добавляется при реализации с учетом потоков
        public static StudentBase GetInstance()
        {
            lock (locker) // эта строка добавляется при реализации с учетом потоков
            {
                if (instance == null)
                    instance = new StudentBase();
                return instance;
            }
        }

        List<Student> students = new List<Student>();
        public List<Student> GetStudents(string search)
        {
            //  фильтрация
            return students;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        // и тп
    }

    public class Student
    {
    }
}