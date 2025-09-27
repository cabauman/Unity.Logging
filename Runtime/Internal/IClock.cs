using System;

namespace GameCtor.ULogging
{
    internal interface IClock
    {
        DateTime Now { get; }
    }
}
