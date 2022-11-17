namespace Demo.Server
#nowarn "20"
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open System.Text.Json.Serialization

module Program =
    [<EntryPoint>]
    let main args =
        let builder = WebApplication.CreateBuilder(args)
        
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()
        
        builder
            .Services
            .AddControllers()
            // Configure JSON serialization for F# types            
            .AddJsonOptions(fun options ->
                options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString
                options.JsonSerializerOptions.Converters.Add(
                    JsonFSharpConverter(unionEncoding = ( JsonUnionEncoding.ThothLike ||| JsonUnionEncoding.UnwrapOption))
                )   
            )
        
        let app = builder.Build()
        app.UseHttpsRedirection()
        app.UseSwagger()
        app.UseSwaggerUI()        
        app.MapControllers()

        app.Run()

        0