using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System;
using UserControlTest.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UserControlTest.Droid
{
    [Activity(Label = "UserControlTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public EventHandler globalTouchHandler;
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            var d = DeviceDisplay.MainDisplayInfo.Density;
            globalTouchHandler?.Invoke(null, new TouchEventArgs<Point>(new Point(e.GetX() / d, e.GetY() / d)));
            return base.DispatchTouchEvent(e);
        }
    }
}