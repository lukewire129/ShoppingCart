using CommunityToolkit.Mvvm.Messaging.Messages;
using ShoppingCart.Model;

namespace ShoppingCart.Message.ValueChanged
{
        public class ItemAddMessage: ValueChangedMessage<Item>
        {
                public ItemAddMessage(Item item):base(item)
                {

                }
        }
}
