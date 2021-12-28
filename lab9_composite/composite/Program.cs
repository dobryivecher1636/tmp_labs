using System;
using System.Collections.Generic;

namespace composite
{
    class Program
    {
        interface IFigure
        {
            public string figure {get; set;} //название фигуры
            public void Move(); //перемещение фигуры по рабочей области
        }

        class Figure : IFigure
        {
            public string figure {get; set;}
            public void Move()
            {
                Console.WriteLine($"Фигура {figure} перемещена");
            }
        }

        class Group : IFigure
        {
            public string figure {get; set;}

            public List<IFigure> Figures = new List<IFigure>();
            public Group(params IFigure[] f)
            {
                Append(f);
            }
            public void Append(params IFigure[] f) //захват определенного кол-ва фигур
            {
                foreach (var item in f) Figures.Add(item);
            }
            public void Move() //перемещение фигур по рабочей области
            {
                foreach (var item in Figures) item.Move();
            }
        }

        static void Main(string[] args)
        {
            Figure round = new Figure() {figure = "Круг"}; //перемещение фигур по одной 
            round.Move();
            Figure square = new Figure() {figure = "Квадрат"};
            square.Move();
            Figure parallelepiped = new Figure() {figure = "Параллелепипед"};
            parallelepiped.Move();
            Console.WriteLine("\n");
            Group group_of_figures = new Group(round, square, parallelepiped); //перемещение группы фигур
            group_of_figures.Move();
        }
    }
}
