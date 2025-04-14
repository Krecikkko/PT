using Shop.Data.API;
using Shop.Data.Implementation;
using Shop.Logic.API;
using Shop.Logic.Implementation;

namespace Shop.Data.Generators
{
    internal class ExtendedDataGenerator : IDataGenerator
    {
        public void Generate(IDataRepository dataRepository)
        {
            // --- USERS ---
            var customers = new List<IUser>
            {
                new User("C101", "Barbara", "Kwiatkowska", "Zielona 15, 00-100 Warszawa"),
                new User("C102", "Kamil", "Lewandowski", "Polna 10, 90-001 Lodz"),
                new User("C103", "Dominika", "Pawlak", "Szeroka 5, 80-001 Gdansk"),
                new User("C104", "Marek", "Adamski", "Wąska 12, 35-001 Rzeszow")
            };

            var suppliers = new List<IUser>
            {
                new User("S101", "Joanna", "Mazur", "Fabryczna 9, 60-100 Poznan"),
                new User("S102", "Rafal", "Nowicki", "Morska 25, 70-200 Szczecin")
            };

            customers.ForEach(dataRepository.AddUser);
            suppliers.ForEach(dataRepository.AddUser);

            // --- CATALOG ---
            var items = new List<ICatalog>
            {
                new Catalog("P101", "Ceramiczny Kubek", 14.99f),
                new Catalog("P102", "Szklana Butelka", 19.49f),
                new Catalog("P103", "Stalowy Garnek", 79.99f),
                new Catalog("P104", "Patelnia Nieklejąca", 59.90f),
                new Catalog("P105", "Nożyczki Kuchenne", 24.00f),
                new Catalog("P106", "Deska do Krojenia", 18.75f),
                new Catalog("P107", "Koszyk na Chleb", 29.90f),
                new Catalog("P108", "Młynek do Pieprzu", 39.99f)
            };

            items.ForEach(dataRepository.AddCatalog);

            // --- STATE (INVENTORY) ---
            var states = new List<IState>
            {
                new State("Q101", 15, items[0]),
                new State("Q102", 30, items[1]),
                new State("Q103", 5,  items[2]),
                new State("Q104", 12, items[3]),
                new State("Q105", 25, items[4]),
                new State("Q106", 18, items[5]),
                new State("Q107", 9,  items[6]),
                new State("Q108", 6,  items[7])
            };

            states.ForEach(dataRepository.AddState);

            // --- EVENTS ---
            dataRepository.AddEvent(new Sell(states[0], customers[0], 2));
            dataRepository.AddEvent(new Sell(states[3], customers[1], 1));
            dataRepository.AddEvent(new Sell(states[4], customers[2], 3));
            dataRepository.AddEvent(new Sell(states[6], customers[3], 2));

            dataRepository.AddEvent(new Supply(states[3], suppliers[0], 10));
            dataRepository.AddEvent(new Supply(states[7], suppliers[1], 4));

            dataRepository.AddEvent(new Return(states[4], customers[3], 1));
        }
    }
}
