# OnionCrafter.Base

OnionCrafter.Base es una librer�a de c�digo libre desarrollada en .NET 7 para facilitar la implementaci�n de la arquitectura Onion en cualquier proyecto y mejorar la seguridad de las aplicaciones desde el principio gracias a las caracter�sticas de seguridad basadas en tipos fuertemente tipados.

La arquitectura Onion, tambi�n conocida como arquitectura hexagonal, es una forma de dise�ar sistemas que los hace m�s escalables, flexibles y f�ciles de mantener a largo plazo. OnionCrafter.Base incluye clases e interfaces base para entidades, configuraciones, validaciones, servicios, repositorios, DTOs, excepciones y wrappers, lo que permite la reutilizaci�n y reimplementaci�n de c�digo.

La librer�a OnionCrafter.Base tambi�n utiliza otras tecnolog�as como Automapper, FluentValidation y MediatR para mejorar la eficiencia y la calidad del c�digo.

## Caracter�sticas

OnionCrafter.Base incluye las siguientes caracter�sticas:

- Implementaci�n de la arquitectura Onion.
- Seguridad basada en tipos fuertemente tipados.
- Clases e interfaces base para la reutilizaci�n y reimplementaci�n.
- Incorporaci�n de otras tecnolog�as como Automapper, FluentValidation y MediatR.

## Tecnolog�as utilizadas

OnionCrafter.Base est� desarrollado en .NET 7 y utiliza las siguientes tecnolog�as:

- Automapper.
- FluentValidation.
- MediatR.

## Instalaci�n

Para instalar OnionCrafter.Base, puedes utilizar el Administrador de paquetes NuGet o descargar el paquete desde GitHub.

### Administrador de paquetes NuGet

```
Install-Package OnionCrafter.Base
```

### Descarga desde GitHub

Puedes descargar el paquete desde la secci�n de [releases](https://github.com/Dtopiast/onioncrafter.base/releases) en GitHub.

## Uso

Para utilizar OnionCrafter.Base en tu proyecto, debes agregar la referencia al paquete y utilizar las clases e interfaces base incluidas en la librer�a. Tambi�n puedes utilizar las tecnolog�as incorporadas como Automapper, FluentValidation y MediatR.

```csharp
// Ejemplo de uso de OnionCrafter.Base
using OnionCrafter.Base.Entities;
using OnionCrafter.Base.Services;

public class UserService : BaseService<User>
{
    // Implementaci�n del servicio de usuarios utilizando OnionCrafter.Base
}
```

## Contribuciones

Si deseas contribuir con el proyecto, por favor lee nuestras [directrices de contribuci�n](CONTRIBUTING.md) para obtener m�s informaci�n.

## Licencia

Este proyecto est� licenciado bajo la Licencia MIT - lee el archivo [LICENSE](LICENSE) para m�s detalles.