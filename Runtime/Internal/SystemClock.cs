using System;

namespace GameCtor.ULogging
{
    internal class SystemClock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
