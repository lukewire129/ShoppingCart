using ShoppingCart.ViewModel;

namespace ShoppingCart;

public partial class MainPage : ContentPage
{
        private MainPageViewModel vm;
        private double BascketViewTranslateY;
        
        public MainPage()
	{
		InitializeComponent();
                var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                this.ShoppingBascketView.Margin = new Thickness(0, 0);
                this.ShoppingBascketView.TranslationY = BascketViewTranslateY  = (mainDisplayInfo.Height + (this.CalculateView.HeightRequest*2)) - mainDisplayInfo.Height;
                Items.HeightRequest = (BascketViewTranslateY / 2) - 10;
                vm = (MainPageViewModel)this.BindingContext;
                vm.PropertyChanged += MainPage_PropertyChanged;
	}

        private void MainPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
                if (e.PropertyName == nameof(vm.SumarryPrice))
                {
                        if (vm.SumarryPrice == 0)
                        {
                                this.ShoppingBascketView.Margin = new Thickness(0, 0);                                
                                ShoppingBascketView.TranslateTo(0, BascketViewTranslateY);
                        }
                        else
                        {
                                if (ShoppingBascketView.TranslationY == BascketViewTranslateY/2) return;
                                this.ShoppingBascketView.Margin = new Thickness(20, 20);
                                ShoppingBascketView.TranslateTo(0, BascketViewTranslateY/2);
                        }
                }
        }
}

