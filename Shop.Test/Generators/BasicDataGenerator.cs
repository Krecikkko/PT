using Shop.Data.API;
using Shop.Data.Implementation;
using Shop.Logic.API;
using Shop.Logic.Implementation;

namespace Shop.Test.Generators
{
    internal class BasicDataGenerator : IDataGenerator
    {
        public void Generate(IDataRepository dataRepository)
        {
            IUser u1 = new User("C001", "Jan", "Kowalski", "Nowy Swiat 67, 00-001 Warszawa");
            IUser u2 = new User("C002", "Anna", "Nowak", "Piotrkowska 157, 90-440 Lodz");
            IUser u3 = new User("C003", "Piotr", "Zielinski", "Wroclawska 23, 50-095 Mirkow");
            IUser u4 = new User("C004", "Katarzyna", "Wojcik", "Plac Zdrojowy 2, 81-723 Sopot");
            IUser u5 = new User("W001", "Tomasz", "Kowalczyk", "Bulwar Nadmorski 2, 84-150 Hel");
            IUser u6 = new User("W002", "Marta", "Kowal", "Powstańców Wielkopolskich 15, 64-735 Miały");

            dataRepository.AddUser(u1);
            dataRepository.AddUser(u2);
            dataRepository.AddUser(u3);
            dataRepository.AddUser(u4);
            dataRepository.AddUser(u5);
            dataRepository.AddUser(u6);

            ICatalog c1 = new Catalog("P001", "LILLHAVET Durszlak", 9.99f);
            ICatalog c2 = new Catalog("P002", "UPPFYLLD Tarka z pojemnikiem", 19.99f);
            ICatalog c3 = new Catalog("P003", "GUBBRÖRA Łopatka gumowa", 4.99f);
            ICatalog c4 = new Catalog("P004", "LÄTTBAKAD Szpatułka do ciasta", 14.99f);
            ICatalog c5 = new Catalog("P005", "NORRSJÖN Durszlak", 59.99f);
            ICatalog c6 = new Catalog("P006", "BAKTRADITION Mata silikonowa", 29.99f);
            ICatalog c7 = new Catalog("P007", "SUMPCYPRESS Miska z pokrywką", 69.99f);

            dataRepository.AddCatalog(c1);
            dataRepository.AddCatalog(c2);
            dataRepository.AddCatalog(c3);
            dataRepository.AddCatalog(c4);
            dataRepository.AddCatalog(c5);
            dataRepository.AddCatalog(c6);
            dataRepository.AddCatalog(c7);

            IState s1 = new State("Q001", 24, c1);
            IState s2 = new State("Q002", 44, c2);
            IState s3 = new State("Q003", 20, c3);
            IState s4 = new State("Q004", 12, c4);
            IState s5 = new State("Q005", 10, c5);
            IState s6 = new State("Q006", 10, c6);
            IState s7 = new State("Q007", 10, c7);

            dataRepository.AddState(s1);
            dataRepository.AddState(s2);
            dataRepository.AddState(s3);
            dataRepository.AddState(s4);
            dataRepository.AddState(s5);
            dataRepository.AddState(s6);
            dataRepository.AddState(s7);

            dataRepository.AddEvent(new Sell(s1, u1, 2));
            dataRepository.AddEvent(new Sell(s2, u2, 1));
            dataRepository.AddEvent(new Sell(s3, u4, 5));
            dataRepository.AddEvent(new Supply(s4, u6, 10));
            dataRepository.AddEvent(new Return(s5, u6, 2));
        }
    }
}
