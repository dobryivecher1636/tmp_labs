using System;

namespace bridge
{
    class Program
    {
        class Gender
        {
            public string _gender;
            public Gender(string gender) 
            {
                this._gender = gender;
            }
            public override string ToString()
            {
                return _gender;
            }
        }
        class Male : Gender 
        { 
            public Male() : base("Мужчина") 
            { 
            } 
        }
        class Female : Gender 
        { 
            public Female() : base("Женщина") 
            { 
            } 
        }

        class Race
        {
            public string _race;
            public Race(string race)
            {
                this._race = race;
            }
            public override string ToString()
            {
                return _race;
            }
        }
        class African : Race
        {
            public African() : base("Африканская")
            {
            }
        }
        class European : Race
        {
            public European() : base("Европеоидская")
            {
            }
        }
        class Asian : Race
        {
            public Asian() : base("Азиатская")
            {
            }
        }

        class Human
        {
            public Gender _gender;
            public Race _race;
            public Human(Gender gender, Race race)
            {
                this._gender = gender;
                this._race = race;
            }
            public void Info()
            {
                Console.WriteLine($"Пол человека: {_gender} \nРаса: {_race}");
            }
        }

        static void Main(string[] args)
        {
            Human human = new Human(new Female(), new Asian());
            human.Info();
        }
    }
}
