using Owin;

namespace Triggers.Host.Middleware
{
    using System;

    public interface IOwinMiddleware
    {
        UInt16 Order { get; }
        void Attach(IAppBuilder appBuilder);
    }
}