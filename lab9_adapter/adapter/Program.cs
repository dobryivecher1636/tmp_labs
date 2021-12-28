using System;

namespace adapter
{
    class Program
    {
        interface IOffense
        {
            void Score();
        }

        class OffenseAct : IOffense //класс 'действие в атаке' с функцией броска мяча в кольцо
        {
            public void Score()
            {
                Console.WriteLine("Действие: игрок забросил мяч");
            }
        }
        class Player //класс игрока, который умеет только бросать мяч в кольцо
        {
            public void Action(IOffense attack)
            {
                attack.Score();
            }
        }

        interface IDefense
        {
            void Rebound();
        }
         
        class DefenseAct : IDefense //класс 'действие в защите' с функцией подбора
        {
            public void Rebound()
            {
                Console.WriteLine("Действие: игрок сделал подбор");
            }
        }

        class Adapter : IOffense //адаптер, который позволяет игроку научиться подбирать мяч
        {
            DefenseAct defenseact;
            public Adapter (DefenseAct c)
            {
                defenseact = c;
            }

            public void Score()
            {
                defenseact.Rebound();
            }
        }


        static void Main(string[] args)
        {
            Player player = new Player(); //игрок
            OffenseAct offenseact = new OffenseAct(); //действие в атаке
            player.Action(offenseact); //игрок бросает мяч в кольцо
            DefenseAct defenseact = new DefenseAct(); //нужно сделать подбор
            IOffense guardAction = new Adapter(defenseact); //используем адаптер
            player.Action(guardAction); //игрок делает подбор
        }
    }
}
