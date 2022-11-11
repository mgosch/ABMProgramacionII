# ABMProgramacionII
---

Como usuario del sistema  
Quiero hacer un abm un juego y comentarios
Para que pueda ser consultado por los clientes 

DADO un usuario  
CUANDO llama al servicio alta de juego
ENTONCES podrá dar de alta un juego con Nombre, Descripción, Precio, Porcentaje de Alquiler, Puntos Cooler, una Imagen y las categorias a las que pertenece.

DADO un usuario  
CUANDO llama al servicio de modificación de un juego 
ENTONCES podrá modificar cualquiera de los datos cargados en el alta.  

DADO un usuario  
CUANDO llama al servicio de eliminación de un juego 
ENTONCES podrá eliminar el juego. 

---------------------------------------------------------------------------------------------

Como usuario del sistema  
Quiero poder consultar la lista de juegos
Para obtener el catalogo de juegos disponibles

DADO un usuario  
CUANDO llama al servicio get de listado de juegos
ENTONCES podrá visualizar los juegos cargados con sus respectivas categorias.

---------------------------------------------------------------------------------------------

Como usuario del sistema  
Quiero poder consultar un juego en particular
Para poder visualizar los comentarios del mismo

DADO un usuario  
CUANDO llama al servicio get de un juego en particular
ENTONCES podrá visualizar los datos del juego y los comentarios

---------------------------------------------------------------------------------------------

Necesario para el funcionamiento del proyecto:
Internet Information Services (IIS)
.Net Core 6.0

Setup del ENV:
Instalando el IIS:
1). Dirigirnos al Panel de control de nuestro OS (Windows).
2). Dirigirnos a Programas.
3). Seleccionar la opción “Activar o desactivar las características de Windows”.
4). En la lista desplegada, tildar la opción “Internet Information Services” y chequear que queden marcadas las opciones “Herramientas de administración web” y “Servicios World Web Wide”, dentro de ellas, las opciones “Compatibilidad con la administración de IIS 6” y “Características de desarrollo de aplicaciones” respectivamente.
5). Si todo salió correctamente, en la raíz de nuestro OS nos aparecerá una carpeta llamada “inetpub”.
6). IMPORTANTE! En un navegador web, escribir “localhost”, si el server se instaló correctamente, veremos una landing page de bienvenida.

Instalando .Net Core 6
1). Dirigirnos a https://dotnet.microsoft.com/en-us/download y descargar .Net Core 6.0 x64 (64 bits).
2). Ejecutar el instalador descargado haciendo doble clic y seleccionar “Instalar”, con permisos de administración.
3). Si todo va correctamente, veremos el siguiente mensaje “La instalación se realizó correctamente.” seguido de la siguiente información:

Se instaló lo siguiente en: "C:\Program Files\dotnet\"
    • SDK de .NET 6.0.403
    • .NET Runtime 6.0.11
    • ASP.NET Core Runtime 6.0.11
    • .NET Windows Desktop Runtime 6.0.11

Publicar Proyecto:
1). Generar una carpeta con el nombre del proyecto, “ABMProgramacionII” en por ejemplo “Documentos” y copiar el path completo (C:\Users\Username\Documents\ABMProgramacionII).
2). Dirigirnos a Visual Studio y abrir la solución del proyecto.
3). Con la solución abierta, en el tab “Explorador de soluciones”, sobre el proyecto, realizamos un clic derecho y seleccionamos “Publicar”.
4). En la nueva venta que se abre, seleccionamos la opción “Carpeta” y le damos a siguiente.
5). En la siguiente ventana, pegamos el path copiado en el paso N°1 y le damos a finalizar y luego cerramos la ventana.
6). Ahora hacemos click “Publicar” y nuestro proyecto empezará a compilar.
7). Copiamos la carpeta con todos los archivos generados en el paso anterior y la pegamos en la ruta “C:\inetpub\wwwroot”.
8). Abrimos el “Administrador de Internet Information Services”.
9). En el panel izquierdo, desplegamos la lista, realizamos clic derecho sobre el ítem “Sitios” y seleccionamos la opción “Agregar sitio web…”.
10). En la ventana que se abre, realizamos la siguiente configuración:
•	Nombre del sitio: ABMProgramacionII
•	Ruta de acceso física: C:\inetpub\wwwroot\ABMProgramacionII
•	Puerto: 8080
11). Finalmente, en el panel derecho verificamos el correcto funcionamiento haciendo clic “Examinar *:8080 (http)”.

---------------------------------------------------------------------------------------------

Deuda técnica
Ampliar la cobertura de pruebas unitarias

