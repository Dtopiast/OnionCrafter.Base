# OnionCrafter.Base
![](https://github.com/Dtopiast/OnionCrafter.Base/blob/main/LogoMakr-3fgVzt.png)
OnionCrafter.Base es una librería de código libre desarrollada en .NET 7 para facilitar la implementación de la arquitectura Onion en cualquier proyecto y mejorar la seguridad de las aplicaciones desde el principio gracias a las características de seguridad basadas en tipos fuertemente tipados.

La arquitectura Onion, también conocida como arquitectura hexagonal, es una forma de diseñar sistemas que los hace más escalables, flexibles y fáciles de mantener a largo plazo. OnionCrafter.Base incluye clases e interfaces base para entidades, configuraciones, validaciones, servicios, repositorios, DTOs, excepciones y wrappers, lo que permite la reutilización y reimplementación de código.

La librería OnionCrafter.Base también utiliza otras tecnologías como Automapper, FluentValidation y MediatR para mejorar la eficiencia y la calidad del código.

## Características

OnionCrafter.Base incluye las siguientes características:

- Implementación de la arquitectura Onion.
- Seguridad basada en tipos fuertemente tipados.
- Clases e interfaces base para la reutilización y reimplementación.
- Incorporación de otras tecnologías como Automapper, FluentValidation y MediatR.

## Tecnologías utilizadas

OnionCrafter.Base está desarrollado en .NET 7 y utiliza las siguientes tecnologías:

- Automapper.
- FluentValidation.
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

Para utilizar OnionCrafter.Base en tu proyecto, debes agregar la referencia al paquete y utilizar las clases e interfaces base incluidas en la librería. También puedes utilizar las tecnologías incorporadas como Automapper, FluentValidation y MediatR.

```csharp
// Ejemplo de uso de OnionCrafter.Base
using OnionCrafter.Base.Entities;
using OnionCrafter.Base.Services;

public class UserService : BaseService<User>
{
    // Implementación del servicio de usuarios utilizando OnionCrafter.Base
}
```

## Contribuciones

Si deseas contribuir con el proyecto, por favor lee nuestras [directrices de contribución](CONTRIBUTING.md) para obtener más información.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - lee el archivo [LICENSE](LICENSE) para más detalles.
