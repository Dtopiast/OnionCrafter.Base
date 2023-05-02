[![.NET Core](https://github.com/Dtopiast/OnionCrafter.Base/workflows/.NET%20Core/badge.svg)](https://github.com/Dtopiast/OnionCrafter.Base/actions)

# OnionCrafter.Base
![](https://github.com/Dtopiast/OnionCrafter.Base/blob/main/Images/Logo.png)

OnionCrafter.Base es una librería de código libre desarrollada en .NET 7 para facilitar la implementación de la arquitectura Onion en cualquier proyecto y mejorar la seguridad de las aplicaciones desde el principio gracias a las características de seguridad basadas en tipos fuertemente tipados.

La arquitectura Onion, también conocida como arquitectura hexagonal, es una forma de diseñar sistemas que los hace más escalables, flexibles y fáciles de mantener a largo plazo. OnionCrafter.Base incluye clases e interfaces base para entidades, configuraciones, servicios, DTOs y wrappers, lo que permite la reutilización y reimplementación de código.

La librería OnionCrafter.Base también utiliza otras tecnologías como MediatR para mejorar la eficiencia y la calidad del código.

## Características

OnionCrafter.Base incluye las siguientes características:

- Implementación de la arquitectura Onion.
- Seguridad basada en tipos fuertemente tipados.
- Clases e interfaces base para la reutilización y reimplementación.
- Incorporación de otras tecnologías como MediatR.

## Tecnologías utilizadas

OnionCrafter.Base está desarrollado en .NET 7 y utiliza las siguientes tecnologías:

- DependencyInjection.
- AuditableObjects.
- MediatR.

## Instalación

Para instalar OnionCrafter.Base, puedes utilizar el Administrador de paquetes NuGet o descargar el paquete desde GitHub.

### Administrador de paquetes NuGet

```
Install-Package OnionCrafter.Base
```

### Descarga desde GitHub

Puedes descargar el paquete desde la sección de [releases](https://github.com/Dtopiast/onioncrafter.base/releases) en GitHub.

## Uso

Para utilizar OnionCrafter.Base en tu proyecto, debes agregar la referencia al paquete y utilizar las clases e interfaces base incluidas en la librería. También debes implementar las tecnologías incorporadas como MediatR.

Se mostrara la creacion de un servicio llamado MyService que requiere ser configurado para ser implementado.

Se crea la clase de configuracion que hereda de IServiceOptions que necesita una key para una api
```csharp
using OnionCrafter.Base.Services;

public class MyServiceOptions : IServiceOptions
{
    public string ApiKey { get; set; }
}
```

Se crea la interfaz que usara la implementacion del servicio, esta hedera de IService y lleva un parametro generico con la clase de opciones que usa (este puede no necesitar).
```csharp
using OnionCrafter.Base.Services;

public interface MyService : IService<MyServiceOptions>
{
    public void Send();
}
```

Implementacion del servicio en una clase que obtiene acceso directo a las opciones de configuracion.
```csharp
using OnionCrafter.Base.Services;

public class MyImplementationService : MyService
{
    public MyImplementationService(IOptions<MyServiceOptions> options) 
    {
        _config = options.Value;
    }  
    public void Send()
    {
    // Implementación del servicio  utilizando OnionCrafter.Base
    }
    
}
```

Se registra el servicio en el startup.
```csharp
var builder = WebApplication.CreateBuilder(args);
Builder.Services.AddTypedScopedWithOptions(typeof(MyService), typeof(MyImplementationService), opt=>
{
    opt.ApiKey = "YOUR_API_KEY";
});
//...
```


## Contribuciones

Si deseas contribuir con el proyecto, por favor lee nuestras [directrices de contribución](CONTRIBUTING.md) para obtener más información.

## Licencia

Este proyecto está licenciado bajo la Licencia Apache 2.0 - lee el archivo [LICENSE](LICENSE.txt)
 para más detalles.
