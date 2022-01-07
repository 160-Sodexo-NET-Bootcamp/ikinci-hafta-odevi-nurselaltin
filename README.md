# GarbageCollectSystem Project

This project is with garbage collection system..

This project formed  of tiers of DataAccess , Entities ,  UI .

#Entities Tier

 - Vehicle and Container class corresponds to the table in the database.I marked this class by IEntity interfaces.Because , I  report classes which marked by IEntity are table of databases.

#DataAccess Tier 

 - I defined operations which I do on the database in IRepositoryBase.
 - I used Entity Framework for connect to database.But you can use Dapper Library for connect.You should fill with  operations of  Dapper  to Dapper Repository classes.
 - I used Unit of Work and Repository Pattern in here.
 - I used  MSSQL  as database.

#UI Tier

  I created Web Api project in here . This api is doing operation with datas of vehicle and container.

 ##GarbageCollectSystemAPI

The GarbageCollectSystem Web API is described below.

#VEHICLE CONTROLLER

## Get Vehicle List

### Request

`GET /Vehicle/`

    curl -X GET " https://localhost:44396/api/Vehicle/" -H  "accept: */*" -d ""

    #### Request URL
    https://localhost:44396/api/Vehicle

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


## Change a Vehicle

### Request
`PUT /Vehicle/id`

  curl -X PUT "https://localhost:44392/api/Vehicle/2" -H  
  
  #### Request URL
  https://localhost:44392/api/Vehicle/2

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:31 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 74

## Delete a Vehicle

### Request

`DELETE /Vehicle/id`

    curl -i -H 'Accept: application/json' -X POST -d'_method=DELETE' http://localhost:7000/Vehicle/2/
    
    #### Request URL
    https://localhost:44392/api/Vehicle/2

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


## Create a new Vehicle

### Request

`POST /Vehicle/`

    curl -X POST "https://localhost:44392/api/Vehicle" 

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


#CONTAINER CONTROLLER

## Get Containers Of Vehicle

### Request

`GET /Container/GetVehicleContainers`

    curl -X GET " https://localhost:44396/api/Container/GetVehicleContainers" -H  "accept: */*" -d ""

    #### Request URL
    https://localhost:44396/api/Container/GetVehicleContainers/2

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8

    ## Get Container  List Of Vehicle

### Request

`POST /Container/`

    curl -X POST " https://localhost:44396/api/Container/" -H  "accept: */*" -d ""

    #### Request URL
    https://localhost:44396/api/Container

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


## Change a Container

### Request
`PUT /Container/id`

  curl -X PUT "https://localhost:44392/api/Container/2" -H  
  
  #### Request URL
  https://localhost:44392/api/Container/2

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:31 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 74

## Delete a Container

### Request

`DELETE /Container/id`

    curl -i -H 'Accept: application/json' -X POST -d'_method=DELETE' http://localhost:7000/Container/2/
    
    #### Request URL
    https://localhost:44392/api/Container/2

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


## Create a new Container

### Request

`POST /Container/`

    curl -X POST "https://localhost:44392/api/Container" 

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8

