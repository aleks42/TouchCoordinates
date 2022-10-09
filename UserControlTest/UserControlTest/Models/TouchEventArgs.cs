using System;

namespace UserControlTest.Models
{
    public class TouchEventArgs<T> : EventArgs
    {
        public T EventData { get; private set; }

        public TouchEventArgs(T EventData)
        {
            this.EventData = EventData;
        }
    }
}
