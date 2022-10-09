using Foundation;
using System;
using System.Linq;
using UIKit;
using UserControlTest.Models;
using Xamarin.Forms;

namespace UserControlTest.iOS.Services
{
    public class TouchCoordinatesRecognizer : UIGestureRecognizer
    {
        public EventHandler globalTouchHandler;

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            SendCoords(touches);
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            SendCoords(touches);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            SendCoords(touches);
        }

        public override void TouchesCancelled(NSSet touches, UIEvent evt)
        {
            base.TouchesCancelled(touches, evt);
            SendCoords(touches);
        }

        void SendCoords(NSSet touches)
        {
            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;

                AppDelegate.Current.globalTouchHandler?.Invoke(null,
                    new TouchEventArgs<Point>(
                        new Point(
                            touch.LocationInView(vc.View).X,
                            touch.LocationInView(vc.View).Y)));
                return;
            }
        }
    }
}