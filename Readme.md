# Bricknode.Soap.Sdk
[![Build Status](https://bricknode.visualstudio.com/BricknodeBroker/_apis/build/status/Bricknode.Bricknode.Soap.Sdk?branchName=master)](https://bricknode.visualstudio.com/BricknodeBroker/_build/latest?definitionId=2&branchName=master)

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
The available services are the following:
```
BfsAccountService
BfsAllocationProfileService
BfsAssetService
BfsAuthenticationService
BfsBankIdService
BfsBusinessEventService
BfsCurrencyService
BfsDealService
BfsFileService
BfsInstructionService
BfsInsuranceService
BfsLegalEntitiesService
BfsOrderService
BfsPositionService
BfsPowerOfAttorneyService
BfsPriceService
BfsTransactionService
BfsTransferReceiverService
BfsTrsService
BfsWhiteLabelService
````