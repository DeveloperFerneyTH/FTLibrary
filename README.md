# FTLibrary
## Test for Bluesoft

### Configuración
* Crear la base de datos BluesoftLibrary en el motor de datos **SQL Server**, Version 2012+. 
* Cambiar la cadena de conexión en el archivo **appsettings.json** del proyecto **FT.Library.API**, por la conexión a la base de datos creada anteriormente.
* Se debe dejar como proyectos de inicio **FT.Library.API** y **FT.Library.Web**.
* Si las tablas no se crean en la primera ejecución, se debe ejecutar el comando `update-database -migration InitialCreate` en la consola del administrador de paquetes, seleccionando como proyecto predeterminado **FT.Library.Core.**
