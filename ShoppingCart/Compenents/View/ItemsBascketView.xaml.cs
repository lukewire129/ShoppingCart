using CommunityToolkit.Mvvm.Messaging;
using ShoppingCart.Compenents.ViewModel;
using ShoppingCart.Message.ValueChanged;

namespace ShoppingCart.Compenents.View;

public partial class ItemsBascketView : ContentView
{
        public ItemsBascketViewModel vm;
        public ItemsBascketView()
        {
                InitializeComponent();
                vm = (ItemsBascketViewModel)this.BindingContext;
                WeakReferenceMessenger.Default.Register<ItemAddMessage>(this, (o, e) =>
                {
                        // 아이템 추가 알림 시 해당 컨트롤 좌우좌우 흔드는 기능
                        new Animation {
                                { 0, 0.1, new Animation(v => this.TranslationX = v, 0, 3) },
                                { 0.1, 0.2, new Animation(v => this.TranslationX = v, 3, 0) },
                                { 0.2, 0.3, new Animation(v => this.TranslationX = v, 0, -3) },
                                { 0.3, 0.4, new Animation(v => this.TranslationX = v, -3, 0) },
                                { 0.4, 0.5, new Animation(v => this.TranslationX = v, 0, 3) },
                                { 0.5, 0.6, new Animation(v => this.TranslationX = v, 3, 0) },
                                { 0.6, 0.7, new Animation(v => this.TranslationX = v, 0, -3) },
                        }.Commit(this, "ChildAnimations", 16, 250, null, (v, c) => this.TranslationX = 0);
                });
        }
}