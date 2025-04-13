using Shop.Data.API;
using Shop.Data.Implementation;
using Shop.Logic.Implementation;
using System.Diagnostics.Metrics;

namespace Shop.Test
{
    [TestClass]
    public sealed class DataTest
    {
        [TestMethod]
        public void IDataRepository_createRepoWithoutGen_NoEntities()
        {
            IDataRepository dataRepository = new DataRepository(null);
            Assert.IsNotNull(dataRepository);
            Assert.IsTrue(dataRepository.GetAllCatalogs().Count() == 0);
            Assert.IsTrue(dataRepository.GetAllEvents().Count() == 0);
            Assert.IsTrue(dataRepository.GetAllStates().Count() == 0);
            Assert.IsTrue(dataRepository.GetAllUsers().Count() == 0);
        }

        [TestMethod]
        public void Catalog_createAndOperateOnCatalogEnt_resultCorrect()
        {
            IDataRepository dataRepository = new DataRepository(null);
            ICatalog catalogEntity = new Catalog("C001", "milk", 5.00f);
            dataRepository.AddCatalog(catalogEntity);
            Assert.AreEqual(dataRepository.GetCatalog("C001").Id, "C001");
            Assert.AreEqual(dataRepository.GetCatalog("C001").Name, "milk");
            Assert.AreEqual(dataRepository.GetCatalog("C001").Price, 5.00f);

            Assert.IsTrue(dataRepository.GetAllCatalogs().Count() == 1);
            dataRepository.RemoveCatalog("C001");
            Assert.IsTrue(dataRepository.GetAllCatalogs().Count() == 0);
        }

        [TestMethod]
        public void User_createAndOperateOnUser_resultCorrect()
        {
            IDataRepository dataRepository = new DataRepository(null);
            IUser user = new User("C001", "Katarzyna", "Wojcik", "Plac Zdrojowy 2, 81-723 Sopot");
            dataRepository.AddUser(user);
            Assert.AreEqual(dataRepository.GetUser("C001").Id, "C001");
            Assert.AreEqual(dataRepository.GetUser("C001").FirstName, "Katarzyna");
            Assert.AreEqual(dataRepository.GetUser("C001").LastName, "Wojcik");
            Assert.AreEqual(dataRepository.GetUser("C001").Address, "Plac Zdrojowy 2, 81-723 Sopot");

            Assert.IsTrue(dataRepository.GetAllUsers().Count() == 1);
            dataRepository.RemoveUser("C001");
            Assert.IsTrue(dataRepository.GetAllUsers().Count() == 0);
        }

        [TestMethod]
        public void State_createAndOperateOnState_resultCorrect()
        {
            IDataRepository dataRepository = new DataRepository(null);
            ICatalog catalog = new Catalog("C001", "cookie", 4.00f);
            IState state = new State("S001", 50, catalog);
            dataRepository.AddState(state);

            Assert.AreEqual(dataRepository.GetState("S001").StateId, "S001");
            Assert.AreEqual(dataRepository.GetState("S001").Quantity, 50);

            Assert.IsTrue(dataRepository.GetAllStates().Count() == 1);
            dataRepository.RemoveState("S001");
            Assert.IsTrue(dataRepository.GetAllStates().Count() == 0);
        }

        [TestMethod]
        public void Event_createAndOperateOnEvent_resultCorrect()
        {
            IDataRepository dataRepository = new DataRepository(null);
            ICatalog catalog = new Catalog("C001", "cookie", 4.00f);
            IState state = new State("S001", 50, catalog);
            IUser user = new User("C001", "Katarzyna", "Wojcik", "Plac Zdrojowy 2, 81-723 Sopot");
            IEvent ev = new Sell(state, user, -5);

            dataRepository.AddEvent(ev);

            Assert.IsTrue(dataRepository.GetAllEvents().Count() == 1);
            dataRepository.RemoveEvent(ev);
            Assert.IsTrue(dataRepository.GetAllEvents().Count() == 0);
        }

        [TestMethod]
        public void QuantityChangeMethod_invokeMethod_correctResult()
        {
            IDataRepository dataRepository = new DataRepository(null);
            ICatalog catalog = new Catalog("C001", "cookie", 4.00f);
            IState state = new State("S001", 50, catalog);

            dataRepository.AddCatalog(catalog);
            dataRepository.AddState(state);
            dataRepository.ChangeQuantity("S001", 5);

            Assert.AreEqual(dataRepository.GetState("C001").Quantity, 55);
        }


    }
}
