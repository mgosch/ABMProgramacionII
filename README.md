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

