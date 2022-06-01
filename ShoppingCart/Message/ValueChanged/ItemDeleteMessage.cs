using CommunityToolkit.Mvvm.Messaging.Messages;
using ShoppingCart.Model;

namespace ShoppingCart.Message.ValueChanged
{
        public class ItemDeleteMessage : ValueChangedMessage<int>
        {
                public ItemDeleteMessage(int item) : base(item)
                {

                }
        }
}
