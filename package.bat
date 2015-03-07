cd SimpleInjectorMiddleware
cd SimpleInjector.WebApi.Middleware
nuget pack SimpleInjector.Integration.WebApi.Extensions.nuspec -Build -Properties Configuration=Debug
nuget push SimpleInjector.Integration.WebApi.Extensions.1.0.0-alpha.nupkg