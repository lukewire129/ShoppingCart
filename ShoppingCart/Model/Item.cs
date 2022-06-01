using CommunityToolkit.Mvvm.Messaging;
using ShoppingCart.Message.ValueChanged;

namespace ShoppingCart.Model
{
        public class Item:BaseItem
        {
                private bool _IsSelected = true;

                public bool IsSelected
                {
                        get => _IsSelected;
                        set => SetProperty(ref _IsSelected, value);
                }

                public void ButtonInActive()
                {
                        IsSelected = false;
                        WeakReferenceMessenger.Default.Send(new ItemAddMessage(this));
                }
                public void ButtonActive()
                {
                        IsSelected = true;
                }
        }
}
