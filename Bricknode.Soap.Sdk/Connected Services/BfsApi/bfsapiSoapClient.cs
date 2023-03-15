using System.ServiceModel;
using System;

namespace BfsApi
{
    public partial class bfsapiSoapClient : IDisposable
    {
        ~bfsapiSoapClient()
        {
            Dispose(false);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            try
            {
                if (State != CommunicationState.Faulted)
                {
                    Close();
                }
            }
            finally
            {
                if (State != CommunicationState.Closed)
                {
                    Abort();
                }
            }
        }
    }
}