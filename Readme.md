# Level6Resellers project [https://github.com/lexog26/Level6Resellers.git]

# Project Structure

## Level6Resellers.Domain [src/Level6Resellers.Domain]
	- Domain entitites
## Level6Resellers.DataTransferObjects [src/Level6Resellers.DataTransferObjects]
	- Data transfer objects for REST Service web exchanges or others, based on domain entities
## Level6Resellers.DataLayer [src/Level6Resellers.DataLayer]
	- Database context definitions
	- Domain entities db mapping configurations using Fluent API
	- Repository design pattern
	- Unit of Work design pattern
	- Migrations
## Level6Resellers.BusinessLogic [src/Level6Resellers.BusinessLogic]
	- Mapper definition for dto <--> entitites mapping
	- Business logic services. For instance: GatewayService
## Level6Resellers.Api [src/Level6Resellers.GatewayApi]
	- Resellers Api definition with CRUD methods

## Output project Level6Resellers.Api

#Instalation Guides

1- Clone the project [https://github.com/lexog26/Level6Resellers.git]
2- Build the solution
3- Set database in Level6Resellers.Api project
Change field InMemoryDb in appsettings.json file, set it to true if you want to use db in memory or false to use mssql db

{
	........

  "InMemoryDB": true

    .........
}

If you want to use mssql db, need to specify mssql database connection string in appsettings.json file

{
	........

  "InMemoryDB": false,
  "ConnectionStrings": {
    "ResellersConnectionString": "Data Source=DESKTOP-N8TAT47;Database=resellers;Connect Timeout=30;Trusted_Connection=True;MultipleActiveResultSets=true"
  }

    .........
}

Also needs to run migrations defined in Level6Resellers.DataLayer project [src/Level6Resellers.DataLayer/Migrations]

4- Set authorization configuration in appsettings.json file [Auth section], this project uses IdentityServer4 nuget package 
as Oauth2 and OpenId implementation with client credentials flow and Bearer authorization scheme. By default it has
values defined in IdentityConfig.cs file [src/Level6Resellers.Api/IdentityConfig.cs].

Default auth configuration

{
	........

  "Auth": {
    "Authority": "http://localhost:5000",
    "ClientId": "Level6ResellersApiSwagger",
    "ClientSecret": "resellersSecret",
    "Scope": "resellersApi"
  }

    .........
}
**For default auth configuration the field "Auth:Authority" must be equal to Level6Resellers.Api project's url

Custom Oauth2 and OpenId implementation

{
	........

  "Auth": {
    "Authority": "your authority provider url",
    "ClientId": "your client_id",
    "ClientSecret": "your client_secret",
    "Scope": "your scope"
  }

    .........
}

5- Run the Level6Resellers.Api project

# Default UI
 
SwaggerUI is the default Level6Resellers.Api project UI, using Swashbucle.AspNetCore nuget package. This tool provides
api documentation and can use for test the api endpoints. Also used authorization flow described in step 4.