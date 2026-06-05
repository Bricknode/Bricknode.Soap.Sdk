using BfsApi;

namespace Bricknode.Soap.Sdk.Configuration
{
    public class BfsApiConfiguration
    {
        public Credentials Credentials { get; set; }
        public string Identifier { get; set; }

        /// <summary>
        /// Base address of the Bricknode REST API (e.g. https://api.bricknode.com/).
        /// Kept named <c>EndpointAddress</c> for drop-in compatibility with the SOAP SDK.
        /// </summary>
        public string EndpointAddress { get; set; }
    }
}
