using Foundation;
using System;
using UIKit;
using UserControlTest.iOS.Services;

namespace UserControlTest.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUIGestureRecognizerDelegate
    {
        public static AppDelegate Current { get; private set; }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Current = this;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            var res = base.FinishedLaunching(app, options);
            app.KeyWindow.AddGestureRecognizer(new TouchCoordinatesRecognizer());
            return res;
        }

        public EventHandler globalTouchHandler;
    }
}
