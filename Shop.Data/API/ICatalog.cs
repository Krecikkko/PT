namespace Shop.Data.API
{
    public interface ICatalog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
