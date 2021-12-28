using System;

namespace decorator
{
    class Program
    {
        static Random rand = new Random();
        class Player //основной класс Игрок, который мы будем декорировать
        {
            public virtual string Option()
            {
                string[] names = {"Michael Jordan", "Lebron James", "Steph Curry", "Kobe Bryant", "Shaquille O'Neal"};
                string name = names[rand.Next(0, names.Length)];
                return "Игрок: " + name + "\n";
            }
        }
        class Role : Player
        {
            Player player;
            public Role(Player player)
            {
                this.player = player;
            }
            public override string Option()
            {
                string[] roles = {"PG", "SG", "C", "SF", "PF"};
                string role = roles[rand.Next(0, roles.Length)];
                return player.Option() + "Позиция: " + role + "\n";
            }
        }
        class Height : Player
        {
            Player player;
            public Height(Player player)
            {
                this.player = player;
            }
            public override string Option()
            {
                string height = Convert.ToString(rand.Next(180, 220));
                return player.Option() + "Рост: " + height + " см.\n";
            }
        }
        class Weight : Player
        {
            Player player;
            public Weight(Player player)
            {
                this.player = player;
            }
            public override string Option()
            {
                string weight = Convert.ToString(rand.Next(80, 130));
                return player.Option() + "Вес: " + weight + " кг.\n";
            }
        }
        class Number : Player
        {
            Player player;
            public Number(Player player)
            {
                this.player = player;
            }
            public override string Option()
            {
                string number = Convert.ToString(rand.Next(0, 99));
                return player.Option() + "Игровой номер: " + number + "\n";
            }
        }
        class Team : Player
        {
            Player player;
            public Team(Player player)
            {
                this.player = player;
            }
            public override string Option()
            {
                string[] teams = {"LA Lakers", "Chicago Bulls", "Boston Celtics", "NY Knicks", "SA Spurs"};
                string team = teams[rand.Next(0, teams.Length)];
                return player.Option() + "Команда: " + team + "\n";
            }
        }
        static void Main(string[] args)
        {
            var PlayerWithRoleParameter = new Role(new Player());
            Console.WriteLine(PlayerWithRoleParameter.Option());

            var PlayerWithRoleNumberTeamParameters = new Number(new Team(new Role(new Player())));
            Console.WriteLine(PlayerWithRoleNumberTeamParameters.Option());

            var PlayerWithRoleHeightWeightNumberTeamParameters = new Height(new Weight(new Number(new Team(new Role(new Player())))));
            Console.WriteLine(PlayerWithRoleHeightWeightNumberTeamParameters.Option());
        }
    }
}
