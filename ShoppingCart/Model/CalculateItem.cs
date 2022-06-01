using CommunityToolkit.Mvvm.Messaging;
using ShoppingCart.Message;

namespace ShoppingCart.Model
{
        public class CalculateItem: BaseItem
        {
                private int _Count = 0;

                public int Count
                {
                        get => _Count;
                        set
                        {
                                SetProperty(ref _Count, value);
                                SumarryPrice = Count * Price;
                        }
                }
                private int _SumarryPrice = 0;

                public int SumarryPrice
                {
                        get => _SumarryPrice;
                        set => SetProperty(ref _SumarryPrice, value);
                }

                public bool IsPossibleMinus()
                {
                        if (this.Count == 1) return false;

                        return true;
                }

                public void DisCountting() => this.Count--;
                public void Countting() => this.Count++;
        }
}
