namespace Shop.Data.API
{
    public interface IDataGenerator
    {
        public abstract void Generate(IDataRepository dataRepository);
    }
}
