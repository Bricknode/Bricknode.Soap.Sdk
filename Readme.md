# Bricknode.Soap.Sdk
[![Build Status](https://dev.azure.com/Bricknode-BFS/BricknodeBroker/_apis/build/status/Bricknode.Bricknode.Soap.Sdk?branchName=master)](https://dev.azure.com/Bricknode-BFS/BricknodeBroker/_build/latest?definitionId=2&branchName=master)

Bricknode.Soap.Sdk is a wrapper for the Bricknode SOAP API described here: http://api.bricknode.com with some added documentation.

# How to get started?
Bricknode.Soap.Sdk is available as a NuGet package here: https://www.nuget.org/packages/Bricknode.Soap.Sdk/

Dependency injection is used so simply add the following code to your service collection to add all the BFS API services.

```c
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
```
The credentials that you are adding including Username and Password are obtained from Bricknode and once you have an instance running of Bricknode Financial Systems you can create new users in the admin role which can be used to log on to the API.

The EndpointAddress and Identifier are also obtained from Bricknode when your instance is created.

In the classes where you want to use any of the BFS API Services you can then simply inject the services like for example:

```c
public class MyClass
{
    private IBfsLegalEntitiesService _bfsLegalEntitiesService;
    
    public MyClass(IBfsLegalEntitiesService bfsLegalEntitiesService)
    {
        _bfsLegalEntitiesService = bfsLegalEntitiesService;
    }
    
    public async Task GetHouseInformation()
    {
         var houseInformation = await _bfsLegalEntitiesService.GetHouseInformationAsync();
    }
}
```
# Multi client support
If you want to target multiple BFS API instances in the same application you can use the multi client feature provided in this package. This feature allows you to inject multiple named BFS clients in the DI container.

```c
 services.AddMultiBfsApiClient()
      .AddNamedBfsApiClient("client1", configuration =>
      {
          configuration.EndpointAddress = "https://bfs1.bricknode.com/test1/api/bfsapi.asmx";
          configuration.Identifier = "123";
          configuration.Credentials = new Credentials
          {
              UserName = "test1",
              Password = "test1"
          };
        }).AddNamedBfsApiClient("client2", configuration =>
        {
              configuration.EndpointAddress = "https://bfs1.bricknode.com/test2/api/bfsapi.asmx";
              configuration.Identifier = "1234";
              configuration.Credentials = new Credentials
              {
                  UserName = "test2",
                  Password = "test2"
              };
          }).BuildClients();
```
To target one of the injected BFS clients simply provide the name used when registering the client with AddNamedBfsApiClient() extension method when calling a service method. 

```c
public class MyClass
{
    private IBfsLegalEntitiesService _bfsLegalEntitiesService;
    
    public MyClass(IBfsLegalEntitiesService bfsLegalEntitiesService)
    {
        _bfsLegalEntitiesService = bfsLegalEntitiesService;
    }
    
    public async Task GetHouseInformation()
    {
         var houseInformation = await _bfsLegalEntitiesService.GetHouseInformationAsync(bfsApiClientName: "client1");
    }
}
```
# Available services
The available services are the following:
```
BfsAccountService
BfsAllocationProfileService
BfsAssetService
BfsAuthenticationService
BfsBankIdService
BfsBusinessEventService
BfsCountryService
BfsCurrencyService
BfsDealService
BfsFileService
BfsInstructionService
BfsInsuranceService
BfsLegalEntitiesService
BfsMessageService
BfsNoteService
BfsOrderService
BfsPositionService
BfsPowerOfAttorneyService
BfsPriceService
BfsReservationService
BfsTaskService
BfsTaxService
BfsTransactionNoteService
BfsTransactionService
BfsTransferReceiverService
BfsTrsService
BfsWhiteLabelService
BfsWebhookService
````
