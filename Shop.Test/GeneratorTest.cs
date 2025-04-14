using Shop.Data.API;
using Shop.Data.Generators;
using Shop.Data.Implementation;
using Shop.Test.Generators;
using System.Threading.Tasks;

namespace Shop.Test
{
    [TestClass]
    public sealed class GeneratorTest
    {
        [TestMethod]
        public void BasicDataGenerator_generateData_RepoContainsAllEntities()
        {
            IDataRepository dataRepository = new DataRepository(new BasicDataGenerator());
            Assert.AreEqual(dataRepository.GetAllUsers().Count(), 6);
            Assert.AreEqual(dataRepository.GetAllCatalogs().Count(), 7);
            Assert.AreEqual(dataRepository.GetAllStates().Count(), 7);
            Assert.AreEqual(dataRepository.GetAllEvents().Count(), 5);

        }

        [TestMethod]
        public void ExtendedDataGenerator_generateData_RepoContainsAllEntities()
        {
            IDataRepository dataRepository = new DataRepository(new ExtendedDataGenerator());
            Assert.AreEqual(dataRepository.GetAllUsers().Count(), 6);
            Assert.AreEqual(dataRepository.GetAllCatalogs().Count(), 8);
            Assert.AreEqual(dataRepository.GetAllStates().Count(), 8);
            Assert.AreEqual(dataRepository.GetAllEvents().Count(), 7);

        }
    }

}
