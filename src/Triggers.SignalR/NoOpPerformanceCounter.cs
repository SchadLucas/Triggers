namespace Triggers.SignalR
{
    using System.Diagnostics;
    using System.Threading;
    using Microsoft.AspNet.SignalR.Infrastructure;

    public class NoOpPerformanceCounterManager : IPerformanceCounterManager
    {
        private static readonly IPerformanceCounter _noOpCounter = new NoOpPerformanceCounter();

        public IPerformanceCounter ConnectionsConnected
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionsReconnected
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionsDisconnected
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionsCurrentForeverFrame
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionsCurrentLongPolling
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionsCurrentServerSentEvents
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionsCurrentWebSockets
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionsCurrent
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionMessagesReceivedTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionMessagesSentTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionMessagesReceivedPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ConnectionMessagesSentPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusMessagesReceivedTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusMessagesReceivedPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ScaleoutMessageBusMessagesReceivedPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusMessagesPublishedTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusMessagesPublishedPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusSubscribersCurrent
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusSubscribersTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusSubscribersPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusAllocatedWorkers
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusBusyWorkers
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter MessageBusTopicsCurrent
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsAllTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsAllPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsHubResolutionTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsHubResolutionPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsHubInvocationTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsHubInvocationPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsTransportTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ErrorsTransportPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ScaleoutStreamCountTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ScaleoutStreamCountOpen
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ScaleoutStreamCountBuffering
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ScaleoutErrorsTotal
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ScaleoutErrorsPerSec
        {
            get { return _noOpCounter; }
        }

        public IPerformanceCounter ScaleoutSendQueueLength
        {
            get { return _noOpCounter; }
        }

        public void Initialize(string instanceName, CancellationToken hostShutdownToken) {}

        public IPerformanceCounter LoadCounter(string categoryName, string counterName, string instanceName, bool isReadOnly)
        {
            return _noOpCounter;
        }
    }

    public class NoOpPerformanceCounter : IPerformanceCounter
    {
        public string CounterName
        {
            get { return this.GetType().Name; }
        }

        public long RawValue
        {
            get { return 0L; }
            set { }
        }

        public long Decrement()
        {
            return 0L;
        }

        public long Increment()
        {
            return 0L;
        }

        public long IncrementBy(long value)
        {
            return 0L;
        }

        public void Close() {}
        public void RemoveInstance() {}

        public CounterSample NextSample()
        {
            return CounterSample.Empty;
        }
    }
}