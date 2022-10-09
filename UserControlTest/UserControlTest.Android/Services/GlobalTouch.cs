using System;
using UserControlTest.Droid.Services;
using UserControlTest.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(GlobalTouch))]
namespace UserControlTest.Droid.Services
{
    public class GlobalTouch : IGlobalTouch
    {
        public void Subscribe(EventHandler handler) => 
            (Platform.CurrentActivity as MainActivity).globalTouchHandler += handler;

        public void Unsubscribe(EventHandler handler) => 
            (Platform.CurrentActivity as MainActivity).globalTouchHandler -= handler;

        public Point GetPosition(VisualElement element)
        {
            var d = DeviceDisplay.MainDisplayInfo.Density;
            var view = Xamarin.Forms.Platform.Android.Platform.GetRenderer(element).View;
            return new Point(view.GetX() / d, view.GetY() / d);
        }

        public double GetSafeAreaBottom() => 0;

        public double GetSafeAreaTop() => 0;

        public int GetNavBarHeight()
        {
            var d = DeviceDisplay.MainDisplayInfo.Density;
            int statusBarHeight = -1;
            int resourceId = Platform.CurrentActivity.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                statusBarHeight = Platform.CurrentActivity.Resources.GetDimensionPixelSize(resourceId);
            }
            return (int)(statusBarHeight / d);
        }
    }
}