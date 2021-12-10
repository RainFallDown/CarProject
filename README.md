
# Car Project
**Used technologies and techniques** 

 - .Net 6 used for Web API and services. 
 - PostgreSql -Npgsql
 - Dapper
 - RabbitMQ
 - EasyNetQ
 - AutoMapper
 - Docker - Docker-Compose
 - Dependency Injection
 - Exception and Response Middlewares

This project can be expanded with FluentValidation, Authorization, JWT, Logging etc.

## Build

Docker-compose will build and deploy all the required services and create database, tables, indexes. 

    docker-compose up --build


After build Swagger can be usable for testing.


## Swagger
```
http://localhost:81/swagger
```
## Advert/All

This enpoint can be used for querying adverts via dynamic parameters with sorting and paging features. Enumerations for this model can be found below.

  **Request Model**

  
    {
      "categoryId": 0,
      "priceLow": 0,
      "priceMax": 0,
      "gear": 0,
      "fuel": 0,
      "sort": 0,
      "sortDirection": 0,
      "page": 0,
      "pageSize": 0
    }

Example Request Model for  **Advert/All**  endpoint
```
{
	"sort": 0, // Sort Price
	"sortDirection": 1, // Ascending Sort
	"gear":1, // Gear filter "Düz"
	"page": 1,
	"pageSize": 10,
	"priceMax":200000, // Maximum and Minimum price filter 
	"pricelow":45000 // Price filters can be use separately
}
```


## Enumerations
These Enumerations should use as a parameters 


     public enum SortField
    {
        [Display(Name = "price")]
        Price,

        [Display(Name = "year")]
        Year,

        [Display(Name = "km")]
        Km
    }
    public enum SortDirection
    {
        [Display(Name = "ASC")]
        ASC,

        [Display(Name = "DESC")]
        DESC
    }
    public enum Gear
    {
        [Display(Name = "Düz")]
        Duz,

        [Display(Name = "Otomatik")]
        Otomatik,

        [Display(Name = "Yarı Otomatik")]
        YariOtomatik
    }
    public enum Fuel
    {
        [Display(Name = "Benzin")]
        Benzin,

        [Display(Name = "Dizel")]
        Dizel,

        [Display(Name = "LPG & Benzin")]
        LpgBenzin
    }

