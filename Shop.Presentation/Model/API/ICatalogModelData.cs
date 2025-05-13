namespace Shop.Presentation.Model.API
{
    public interface ICatalogModelData
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
