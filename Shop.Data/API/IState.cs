namespace Shop.Data.API
{
    public interface IState
    {
        int CatalogId { get; }
        int StateId { get; set; }
        int Quantity { get; set; }
    }
}
