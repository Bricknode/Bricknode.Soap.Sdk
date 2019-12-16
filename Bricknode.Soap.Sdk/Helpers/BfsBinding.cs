using System;
using System.ServiceModel;

namespace Bricknode.Soap.Sdk.Helpers
{
    public static class BfsBinding
    {
        public static BasicHttpsBinding GetBfsBinding()
        {
            return new BasicHttpsBinding
            {
                MaxReceivedMessageSize = int.MaxValue,
                SendTimeout = TimeSpan.MaxValue
            };
        }
    }
}