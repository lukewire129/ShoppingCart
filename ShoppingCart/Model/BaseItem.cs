using CommunityToolkit.Mvvm.ComponentModel;

namespace ShoppingCart.Model
{
        public class BaseItem : ObservableObject
        {      
                public int key { get; set; }
                public string Name { get; set; }
                public int Price { get; set; } = 0;
        }
}
