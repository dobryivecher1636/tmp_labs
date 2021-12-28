using System;

namespace iterator
{
    class Program
    {
        class Movie //класс 'Фильм'
        {
            public string name {get; set;}
        }

        class Visitor //класс 'Посетитель'
        {
            public void MoviesList(Cinema cinema)
            {
                IMovIterator iterator = cinema.CreateNumerator();
                while (iterator.HasNext())
                {
                    Movie movie = iterator.Next();
                    Console.WriteLine(movie.name);
                }
            }
        }

        interface IMovIterator //интерфейс итератора
        {
            bool HasNext();
            Movie Next();
        }

        interface IMovNumerable //интерфейс, используемый для получения итератора для конкретного типа
        {
            IMovIterator CreateNumerator();
            int Count {get;}
            Movie this[int ind] {get;}
        }

        class Cinema : IMovNumerable //класс 'Кинотеатр'
        {
            public Movie[] movies;
            public Cinema()
            {
                movies = new Movie[]
                {
                    new Movie { name = "Терминатор" },
                    new Movie { name = "Звёздные Войны" },
                    new Movie { name  = "Крепкий Орешек" },
                    new Movie { name  = "Рокки" },
                    new Movie { name  = "Матрица "}
                };
            }
            public int Count
            {
                get { return movies.Length; }
            }

            public Movie this[int ind]
            { 
                get { return movies[ind]; } //возвращаем индекс фильма из списка
            }
            public IMovIterator CreateNumerator()
            {
                return new CinemaNumerator(this);
            }
        }

        class CinemaNumerator : IMovIterator //обход списка
        {
            IMovNumerable aggregate;
            int ind = 0;
            public CinemaNumerator(IMovNumerable a)
            {
                aggregate = a;
            }
            public bool HasNext()
            {
                return ind < aggregate.Count;
            }

            public Movie Next()
            {
                return aggregate[ind++];
            }
        }


        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();
            Visitor visitor = new Visitor();
            visitor.MoviesList(cinema);
        }
    }

}
