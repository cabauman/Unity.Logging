using System;

namespace GameCtor.ULogging
{
    public class MockClock : IClock
    {
        public DateTime Now { get; set; }
    }
}
