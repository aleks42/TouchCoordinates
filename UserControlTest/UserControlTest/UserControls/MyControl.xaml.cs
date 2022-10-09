using System.Diagnostics;
using UserControlTest.Models;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserControlTest.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyControl : ContentView
    {
        TouchInteractionStatus touchInteractionStatus = TouchInteractionStatus.Completed;
        int touchStartX = -1;
        IGlobalTouch service;
        Grid item;
        private int screenWidth => (int)(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);

        public MyControl()
        {
            InitializeComponent();

            service = DependencyService.Get<IGlobalTouch>();
            DependencyService.Get<IGlobalTouch>().Subscribe((sender, e) =>
            {
                //Debug.WriteLine($"globalTouchHandler");

                if (touchInteractionStatus == TouchInteractionStatus.Completed) return;

                var touchPoint = (e as TouchEventArgs<Point>).EventData;
                var touchX = touchPoint.X;
                var touchY = touchPoint.Y;

                if (touchStartX == -1) touchStartX = (int)touchX;

                var viewPosition = service.GetPosition(this);
                var navBarHeight = service.GetNavBarHeight();
                var viewX = viewPosition.X;
                var viewY = viewPosition.Y + navBarHeight;

                if (touchX >= viewX && touchX <= viewX + Width
                && touchY >= viewY && touchY <= viewY + Height)
                {
                    item.TranslationX = touchPoint.X - screenWidth / 2;
                }
            });

            Init();
        }

        public void Init()
        {
            item = new Grid();
            item.WidthRequest = 100;
            item.HeightRequest = 100;
            item.BackgroundColor = Color.LightSkyBlue;
            item.HorizontalOptions = LayoutOptions.Center;
            item.VerticalOptions = LayoutOptions.Center;
            mainGrid.Children.Add(item);
        }

        private void TouchEffect_Completed(object sender, TouchCompletedEventArgs e)
        {
            Debug.WriteLine($"Completed");
        }

        private void TouchEffect_LongPressCompleted(object sender, LongPressCompletedEventArgs e)
        {
            Debug.WriteLine($"LongPressCompleted");
        }

        private void TouchEffect_StateChanged(object sender, TouchStateChangedEventArgs e)
        {
            Debug.WriteLine($"StateChanged {e.State}");
        }

        private void TouchEffect_StatusChanged(object sender, TouchStatusChangedEventArgs e)
        {
            Debug.WriteLine($"StatusChanged {e.Status}");
        }

        private void TouchEffect_HoverStateChanged(object sender, HoverStateChangedEventArgs e)
        {
            Debug.WriteLine($"HoverStateChanged {e.State}");
        }

        private void TouchEffect_HoverStatusChanged(object sender, HoverStatusChangedEventArgs e)
        {
            Debug.WriteLine($"HoverStatusChanged {e.Status}");
        }

        private void TouchEffect_InteractionStatusChanged(object sender, TouchInteractionStatusChangedEventArgs e)
        {
            Debug.WriteLine($"InteractionStatusChanged {e.TouchInteractionStatus}");
            touchInteractionStatus = e.TouchInteractionStatus;
            if (touchInteractionStatus == TouchInteractionStatus.Completed) touchStartX = -1;
        }
    }
}