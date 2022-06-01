using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ShoppingCart.Message.ValueChanged;
using ShoppingCart.Model;
using System.Collections.ObjectModel;

namespace ShoppingCart.Compenents.ViewModel
{
        public class ItemViewModel: ObservableRecipient
        {
                private ObservableCollection<Item> _shoppingItems = new ObservableCollection<Item>()
                        {
                                new Item()
                                {
                                        key = 1,
                                        Name = "칸쵸",
                                        Price = 500
                                },
                                new Item()
                                {
                                        key = 2,
                                        Name = "포카칩",
                                        Price= 1000
                                },
                                new Item()
                                {
                                        key =3,
                                        Name = "포카리스웨트",
                                        Price = 1500
                                }
                        };
                public ObservableCollection<Item> shoppingItems
                {
                        get => _shoppingItems;
                        set => SetProperty(ref _shoppingItems, value);
                }
                public ItemViewModel()
                {
                        Messenger.Register<ItemDeleteMessage>(this, (e, o) =>
                        {
                                shoppingItems.FirstOrDefault(x => x.key == o.Value).ButtonActive();
                        });
                }                                
                public RelayCommand<Item> SelectItem => new RelayCommand<Item>((e) =>
                {
                        e.ButtonInActive();
                });
        }
}
