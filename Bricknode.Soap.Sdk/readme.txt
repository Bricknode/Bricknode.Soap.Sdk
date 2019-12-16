------------------------------------------------------------
Bricknode.Soap.Sdk
------------------------------------------------------------

To start using this package simply add AddBfsApiClient(bfsApiConfiguration) to Startup in ConfigureServices.

The bfsApiConfiguration contains your credentials to your BFS site, the endpoint and the identifier and could look like this:

 _serviceCollection.AddBfsApiClient(bfsApiConfiguration =>
                {
                    bfsApiConfiguration.Credentials = new Credentials
                    {
                        UserName = options.Credentials.UserName,
                        Password = options.Credentials.Password
                    };
                    bfsApiConfiguration.EndpointAddress = options.EndpointAddress;
                    bfsApiConfiguration.Identifier = options.Identifier;
                }
            );

There is a service for each API section as defined here: http://api.bricknode.com

For example, simply inject the service IBfsAccountService in each class where you want to use it.