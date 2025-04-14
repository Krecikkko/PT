using Shop.Data.API;

namespace Shop.Logic.Implementation
{
    internal class Sell : ISell
    {
        private IState _state;
        private IUser _user;
        public string StateId => _state.StateId;
        public string UserId => _user.Id;
        public int QuantityChanged { get; set; }

        public Sell(IState state, IUser user, int quantityChanged)
        {
            _state = state;
            _user = user;
            QuantityChanged = quantityChanged;
        }
    }
}
