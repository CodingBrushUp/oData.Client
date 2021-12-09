# oData Client

a simple C# Console application utilizing public OData API from:
https://www.odata.org/odata-services/ (use v4).

* In this project, I concentrated on selecting a library to deal with oData.

* In a real project, it would be implemented as a component, module, Extension or a Middleware.

* This project also needs to be refactored based on the needs of your project and the architecture you've adopted. 

    Listing people
    Allow searching/filtering people
    Show details on a specific Person
    Modifying data
    Using xUnitTest to cover Requirements
    Using Typed and ODataDynamic Expression 

### Built With

* [.Net 6](https://dotnet.microsoft.com/download/dotnet/6.0/)
* [Simple.OData.V4.Client](https://www.nuget.org/packages/Simple.OData.V4.Client/)
* [xUnit](https://xunit.net/)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

* download .Net 6 runtime from this address: https://dotnet.microsoft.com/download/dotnet/6.0/

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/CodingBrushUp/oData.Client.git
   ```



go to the project root folder, run `cmd` on url bar to open command prompt

# to build and run project:

run these commands:
```sh
dotnet restore
dotnet build
dotnet run --project ./oData.Client/2.oData.Client.csproj
```

# to test project:

```sh
dotnet test
```
<p align="right">(<a href="#top">back to top</a>)</p>
