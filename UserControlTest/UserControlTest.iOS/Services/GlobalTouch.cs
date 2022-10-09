using System;
using UIKit;
using UserControlTest.iOS.Services;
using UserControlTest.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(GlobalTouch))]
namespace UserControlTest.iOS.Services
{
    public class GlobalTouch : IGlobalTouch
    {
        public void Subscribe(EventHandler handler) => AppDelegate.Current.globalTouchHandler += handler;

        public void Unsubscribe(EventHandler handler) => AppDelegate.Current.globalTouchHandler -= handler;

        public Point GetPosition(VisualElement element)
        {
            var view = Xamarin.Forms.Platform.iOS.Platform.GetRenderer(element).NativeView;
            var rect = view.Superview.ConvertPointToView(view.Frame.Location, null);
            return new Point(Math.Round(rect.X), Math.Round(rect.Y));
        }

        public double GetSafeAreaBottom()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                UIWindow window = UIApplication.SharedApplication.Delegate.GetWindow();
                var bottomPadding = window.SafeAreaInsets.Bottom;
                return bottomPadding;
            }
            return 0;
        }

        public double GetSafeAreaTop()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                UIWindow window = UIApplication.SharedApplication.Delegate.GetWindow();
                var topPadding = window.SafeAreaInsets.Top;
                return topPadding;
            }
            return 0;
        }

        public int GetNavBarHeight() => 0;
    }
}