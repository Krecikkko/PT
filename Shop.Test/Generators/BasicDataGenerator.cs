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
            dataRepository.AddUser(new User("C001", "Jan", "Kowalski", "Nowy Swiat 67, 00-001 Warszawa"));
            dataRepository.AddUser(new User("C002", "Anna", "Nowak", "Piotrkowska 157, 90-440 Lodz"));
            dataRepository.AddUser(new User("C003", "Piotr", "Zielinski", "Wroclawska 23, 50-095 Mirkow"));
            dataRepository.AddUser(new User("C004", "Katarzyna", "Wojcik", "Plac Zdrojowy 2, 81-723 Sopot"));
            dataRepository.AddUser(new User("W001", "Tomasz", "Kowalczyk", "Bulwar Nadmorski 2, 84-150 Hel"));
            dataRepository.AddUser(new User("W002", "Marta", "Kowal", "Powstańców Wielkopolskich 15, 64-735 Miały"));

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

            dataRepository.AddState(new State("Q001", 24, c1));
            dataRepository.AddState(new State("Q002", 44, c2));
            dataRepository.AddState(new State("Q003", 20, c3));
            dataRepository.AddState(new State("Q004", 12, c4));
            dataRepository.AddState(new State("Q005", 10, c5));
            dataRepository.AddState(new State("Q006", 10, c6));
            dataRepository.AddState(new State("Q007", 10, c7));

            dataRepository.AddEvent(new Sell("Q001", "C001", 2));
            dataRepository.AddEvent(new Sell("Q002", "C002", 1));
            dataRepository.AddEvent(new Sell("Q003", "C004", 5));
            dataRepository.AddEvent(new Supply("Q004", "W001", 10));
            dataRepository.AddEvent(new Return("Q005", "W001", 2));
        }
    }
}
