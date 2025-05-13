namespace Shop.Service.API
{
    public interface IEventServiceData
    {
        int Id
        {
            get;
        }

        int StateId
        {
            get;
        }

        int UserId
        {
            get;
        }

        int QuantityChanged
        {
            get;
            set;
        }
    }
}
