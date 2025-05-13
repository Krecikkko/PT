using Shop.Data.API;

namespace Shop.Service.Implementation
{
    internal class Return : IReturn
    {
        private IState _state;
        private IUser _user;
        public int Id { get; set; }
        public int StateId => _state.StateId;
        public int UserId => _user.Id;
        public int QuantityChanged { get; set; }

        public Return(IState state, IUser user, int quantityChanged)
        {
            _state = state;
            _user = user;
            QuantityChanged = quantityChanged;
        }
    }
}
