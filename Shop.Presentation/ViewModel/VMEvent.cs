using Shop.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Shop.Presentation.Test")]
namespace Shop.Presentation.ViewModel
{
    internal class VMEvent : PropertyChange
    {
        private int id;
        private int stateId;
        private int userId;
        private int quantityChanged;

        public VMEvent()
        {
            id = 0;
            stateId = 0;
            userId = 0;
            quantityChanged = 0;
        }

        public VMEvent(int id, int stateId, int userId, int quantityChanged)
        {
            this.id = id;
            this.stateId = stateId;
            this.userId = userId;
            this.quantityChanged = quantityChanged;
        }

        public int Id
        {
            get => id;

            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int StateId
        {
            get => stateId;
            set
            {
                stateId = value;

                OnPropertyChanged(nameof(StateId));
            }
        }

        public int UserID
        {
            get => userId;
            set
            {
                userId = value;

                OnPropertyChanged(nameof(UserID));
            }
        }

        public int QuantityChanged
        {
            get => quantityChanged;
            set
            {
                quantityChanged = value;

                OnPropertyChanged(nameof(QuantityChanged));
            }
        }
    }
}
