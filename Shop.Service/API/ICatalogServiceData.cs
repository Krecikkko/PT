namespace Shop.Service.API
{
    public interface ICatalogServiceData
    {
        int Id
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        double Price
        {
            get;
            set;
        }
    }
}
