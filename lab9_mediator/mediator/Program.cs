using System;

namespace mediator
{
    class Program
    {
        abstract class Mediator //интерфейс взаимодействия с объектами Partner
        {
            public abstract void Send(string message, Partner employee);
        }

        abstract class Partner //интерфейс взаимодействия с объектами Mediator
        {
            public Mediator mediator;
            public Partner(Mediator mediator)
            {
                this.mediator = mediator;
            }
            public virtual void Send(string message)
            {
                mediator.Send(message, this);
            }
            public abstract void Notice(string message);
        }

        class Client : Partner //заказчик
        {
            public Client(Mediator mediator)
            : base(mediator)
            {}
            public override void Notice(string message)
            {
                Console.WriteLine("Сообщение заказчику: " + message);
            }
        }

        class Programmer : Partner //программист
        {
            public Programmer(Mediator mediator)
            : base(mediator)
            {}
            public override void Notice(string message)
            {
                Console.WriteLine("Сообщение программисту: " + message);
            }
        }

        class Tester : Partner //тестер
        {
            public Tester(Mediator mediator)
            : base(mediator)
            {}
            public override void Notice(string message)
            {
                Console.WriteLine("Сообщение тестеру: " + message);
            }
        }

        class ManagerMediator : Mediator
        {
            public Partner Customer {get; set;}
            public Partner Programmer {get; set;}
            public Partner Tester {get; set;}
            public override void Send(string message, Partner employee)
            {
                if (employee == Customer) //если заказчик, то отправляем сообщение программисту
                    Programmer.Notice(message);
                if (employee == Programmer) //если программист, то отправляем сообщение тестеру
                    Tester.Notice(message);
                if (employee == Tester) //если тестер, то отправляем сообщение заказчику
                    Customer.Notice(message);
            }
        }

        static void Main(string[] args)
        {
            ManagerMediator mediator = new ManagerMediator();
            Partner customer = new Client(mediator);
            Partner tester = new Tester(mediator);
            Partner programmer = new Programmer(mediator);

            mediator.Customer = customer;
            mediator.Tester = tester;
            mediator.Programmer = programmer;

            customer.Send("Я хочу заказать разработку программы.");
            programmer.Send("Программа готова.");
            tester.Send("Программа протестирована, заказ готов.");
        }
    }

}
