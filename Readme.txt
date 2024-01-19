
Get data:
HTTP GET/{id}
https://localhost:7040/api/BotBustor/1
// Returns null or customer data.

Store data:
HTTP POST json payload
https://localhost:7040/api/BotBustor
{
    "customerId": 2,
    ...
}
//Returns the customerId of the stored data.
//If customerId is 0 a new unique id will be create and returned.


Initialize Data:
HTTP GET/-666
https://localhost:7040/api/BotBustor/-666
//Initializes customerId 1,2 and 3 to Hanna's defaults. 

Delete date
HTTP DELETE/{id}
https://localhost:7040/api/BotBustor/{id}

Clear all date:
HTTP DELETE/-666
https://localhost:7040/api/BotBustor/-666



