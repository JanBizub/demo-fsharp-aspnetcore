namespace Demo.Server.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Demo.Server

[<ApiController>]
[<Route("[controller]")>]
type PersonController (logger : ILogger<PersonController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() =
        { Name = "Vatnik"
          Alignment = Alignment.Evil
          GenderTransition = "Died duting operation" |> Error }
        
    [<HttpGet>]
    member _.Get(id) =
        { Name = "Vatnik"
          Alignment = Alignment.Evil
          GenderTransition = "Died duting operation" |> Error }