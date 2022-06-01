using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ShoppingCart.Message.ValueChanged
{
        public class SummaryPriceValueMessage : ValueChangedMessage<int>
        {
                public SummaryPriceValueMessage(int value) : base(value)
                {

                }
        }
}
