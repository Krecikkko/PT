namespace Shop.Service.API
{
    public interface IUserServiceData
    {
        int Id
        {
            get;
            set;
        }

        string FirstName
        {
            get;
            set;
        }

        string LastName
        {
            get;
            set;
        }

        string Address
        {
            get;
            set;
        }
    }
}
