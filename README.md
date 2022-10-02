

# Portafolio

Este proyecto es un portafolio que esta realizado con la tecnología ASP.NET Core 6, cuyo fin es servir de plantilla para quienes desean plasmar sus proyectos que quieran mostrar al público. Por último, el proyecto cuenta con un módulo de contacto que envia emails de forma nativa sin la gestion de algún servicio externo.
___
## Tecnologías
* .NET 6
* MailKit
___
## Dependencias
* MailKit (3.3.0)
___
### Configuracion del archivo *appsettings.json*

``` json
{
  "SEND_NOMBRE": "Nombre de contacto",
  "SEND_TO": "correo_destino@gmail.com",
  "GMAIL_USER": "correo_usuario@gmail.com",
  "PASS_APP": "ñlksjdfikkjdudns",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Portafolio.Controllers": "Error",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}

```
* __SEND_NOMBRE__: Nombre de contacto del correo electrónico de destino.
* __SEND_TO__: Correo de destino que recibirá el formulario de contacto.
* __GMAIL_USER__: Correo electrónico de usuario.
* __PASS_APP__: Contraseña de aplicación asociada al correo electrónico de usuario.

___

