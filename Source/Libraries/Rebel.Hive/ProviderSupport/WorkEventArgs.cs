using System;

namespace Rebel.Hive.ProviderSupport
{
    public class WorkEventArgs : EventArgs
    {
        public WorkEventArgs(ProviderUnit providerUnit)
        {
            Unit = providerUnit;
        }

        public ProviderUnit Unit { get; protected set; }
    }
}