using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ShoppingCart.Message.ValueChanged;

namespace ShoppingCart.ViewModel
{
        public class MainPageViewModel: ObservableRecipient
        {
                private int _SumarryPrice = 0;

                public int SumarryPrice
                {
                        get => _SumarryPrice;
                        set => SetProperty(ref _SumarryPrice, value);
                }

                public MainPageViewModel()
                {
                        Messenger.Register<SummaryPriceValueMessage>(this, (e, o) =>
                        {
                                SumarryPrice = o.Value;
                        });
                }
        }
}
