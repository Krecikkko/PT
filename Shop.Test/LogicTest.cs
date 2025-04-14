using Shop.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Data.Implementation;
using System.Threading.Tasks;
using Shop.Logic.API;
using Shop.Logic.Implementation;

namespace Shop.Test
{
    [TestClass]
    public sealed class LogicTest
    {
        [TestMethod]
        public void ShopService_sellItem_StateChangedAccordingly()
        {
            IDataRepository dataRepository = new DataRepository(null);
            IShopService shopService = new ShopService(dataRepository);

            dataRepository.AddUser(new User("U001", "John", "Doe", "123 Main St"));
            
            ICatalog catalog = new Catalog("C001", "Test Item", 10.00f);
            dataRepository.AddCatalog(catalog);

            IState state = new State("S001", 100, catalog);
            dataRepository.AddState(state);

            shopService.SellItem("U001", "S001", 5);

            Assert.AreEqual(dataRepository.GetState("S001").Quantity, 95);
        }

        [TestMethod]
        public void ShopService_supplyItem_StateChangedAccordingly()
        {
            IDataRepository dataRepository = new DataRepository(null);
            IShopService shopService = new ShopService(dataRepository);

            dataRepository.AddUser(new User("U001", "John", "Doe", "123 Main St"));

            ICatalog catalog = new Catalog("C001", "Test Item", 10.00f);
            dataRepository.AddCatalog(catalog);

            IState state = new State("S001", 100, catalog);
            dataRepository.AddState(state);

            shopService.SupplyItem("U001", "S001", 10);

            Assert.AreEqual(dataRepository.GetState("S001").Quantity, 110);
        }

        [TestMethod]
        public void ShopService_returnItem_StateChangedAccordingly()
        {
            IDataRepository dataRepository = new DataRepository(null);
            IShopService shopService = new ShopService(dataRepository);

            dataRepository.AddUser(new User("U001", "John", "Doe", "123 Main St"));

            ICatalog catalog = new Catalog("C001", "Test Item", 10.00f);
            dataRepository.AddCatalog(catalog);

            IState state = new State("S001", 100, catalog);
            dataRepository.AddState(state);

            shopService.SellItem("U001", "S001", 5);
            shopService.ReturnItem("U001", "S001", 3);

            Assert.AreEqual(dataRepository.GetState("S001").Quantity, 98);
        }
    }
}
