using Shop.Service.API;
using Shop.Service.Implementation;

namespace Shop.Service.Test
{
    [TestClass]
    public sealed class ServiceUnitTest
    {
        [TestMethod]
        public void CatalogTest()
        {
            IShopService serviceRepo = IShopService.CreateNewService(new MockDataLayer());
            serviceRepo.AddCatalog(1, "Sofa", 199);
            Assert.IsNotNull(serviceRepo.GetAllCatalogs());

        }
        [TestMethod]

        public void UserTests()
        {
            IShopService serviceRepo = IShopService.CreateNewService(new MockDataLayer());
            serviceRepo.AddUser(1, "Filip", "Testt", "Testing");
            Assert.IsNotNull(serviceRepo.GetAllUsers());

        }

        [TestMethod]
        public void StateTests()
        {
            IShopService serviceRepo = IShopService.CreateNewService(new MockDataLayer());
            serviceRepo.AddCatalog(2, "Sofa", 199);
            serviceRepo.AddState(1, 5, 2);
            Assert.IsNotNull(serviceRepo.GetAllStates());
        }

        [TestMethod]
        public void EventTests()
        {
            IShopService serviceRepo = IShopService.CreateNewService(new MockDataLayer());
            serviceRepo.AddCatalog(2, "Sofa", 199);
            serviceRepo.AddState(1, 5, 2);
            serviceRepo.AddUser(1, "Filip", "Testt", "Testing");
            serviceRepo.SellItem(1, 1, 1, 2);
            Assert.IsNotNull(serviceRepo.GetAllEvents());
        }
    }
}
