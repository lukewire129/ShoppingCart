using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShoppingCart.Message.ValueChanged;
using ShoppingCart.Model;
using System.Collections.ObjectModel;

namespace ShoppingCart.Compenents.ViewModel
{
        public class ItemsBascketViewModel : ObservableRecipient
        {
                private ObservableCollection<CalculateItem> _shoppingItems;

                public ObservableCollection<CalculateItem> shoppingItems
                {
                        get => _shoppingItems;
                        set => SetProperty(ref _shoppingItems, value);
                }

                public ItemsBascketViewModel()
                {
                        shoppingItems = new ObservableCollection<CalculateItem>();
                        

                        Messenger.Register<ItemAddMessage>(this, (e, o) =>
                        {
                                shoppingItems.Add(new CalculateItem()
                                {
                                        key = o.Value.key,
                                        Name = o.Value.Name,
                                        Price = o.Value.Price,
                                        Count = 1
                                });

                                PriceValueUpdate();
                        });
                }

                public RelayCommand<CalculateItem> DeleteItem => new RelayCommand<CalculateItem>((e) =>
                {
                        ItemDelete(e);
                        PriceValueUpdate();
                });

                public RelayCommand<CalculateItem> MinusItem => new RelayCommand<CalculateItem>((e) =>
                {
                        if (e.IsPossibleMinus() == false) return;

                        e.DisCountting();
                        PriceValueUpdate();

                });
                public RelayCommand<CalculateItem> PlusItem => new RelayCommand<CalculateItem>((e) =>
                {
                        e.Countting();
                        PriceValueUpdate();
                });

                private void ItemDelete(CalculateItem item)
                {
                        this.shoppingItems.Remove(item);
                        WeakReferenceMessenger.Default.Send(new ItemDeleteMessage(item.key));
                }

                private void PriceValueUpdate()
                {
                        WeakReferenceMessenger.Default.Send(new SummaryPriceValueMessage(this.shoppingItems.Sum(x => x.SumarryPrice)));
                }
        }
}
