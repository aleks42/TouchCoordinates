using System;
using Xamarin.Forms;

namespace UserControlTest.Models
{
    //https://stackoverflow.com/questions/41215689/xamarin-forms-global-tapped-event-on-application-level
    //https://social.msdn.microsoft.com/Forums/en-US/dda740d6-3f9a-4a6f-a9de-a87b27e8d2f1/how-to-get-the-coordinates-where-there-is-a-control-on-the-screen?forum=xamarinforms
    public interface IGlobalTouch
    {
        void Subscribe(EventHandler handler);
        void Unsubscribe(EventHandler handler);
        Point GetPosition(VisualElement element);
        double GetSafeAreaTop();
        double GetSafeAreaBottom();
        int GetNavBarHeight();
    }
}
