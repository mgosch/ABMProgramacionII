# ABMProgramacionII
---

Como usuario del sistema
Quiero poder dar de alta categorias de juegos
Para poder dar alta juegos

DADO un usuario
CUANDO ingresa a Categorias
ENTONCES podrá visualizará las categorias cargadas con la opción de editarlas y eliminarlas.

DADO un usuario
CUANDO ingresa a Categorias
ENTONCES tendrá la opción de crear categorias

DADO un usuario
CUANDO ingresa a Categorias y presiona crear
ENTONCES visualizará una pantalla para cargar la descripción y la opción de guardar.

DADO un usuario
CUANDO carga la descripción de una categoria y presiona guardar
ENTONCES visualizará la nueva categoria en el listado de categorias.

DADO un usuario
CUANDO modifica una categoria
ENTONCES modificará la descripción de la misma.

DADO un usuario
CUANDO elimina la categoria
ENTONCES la eliminará del listado de categorias.

-----------------------------------------------------------------------------------------

Como usuario del sistema
Quiero poder dar de alta juegos
Para que los clientes puedan jugarlos y hacerles comentarios.

DADO un usuario
CUANDO ingresa a Juegos
ENTONCES podrá visualizará los juegos cargados con la opción de editarlos y eliminarlos.

DADO un usuario
CUANDO ingresa a crear juego
ENTONCES visualizará una pantalla para cargar Nombre, Descripción, Precio, Porcentaje de Alquiler, Puntos Cooler, una Imagen y las categorias a las que pertenece el juego y la opción de guardar.

DADO un usuario
CUANDO cargo los datos para el alta de un juego y presiona guardar
ENTONCES visualizará el nuevo juego en el listado de juegos.

DADO un usuario
CUANDO modifica un juego
ENTONCES podrá modificar cualquiera de los datos cargados en el alta.

DADO un usuario
CUANDO elimina un juego
ENTONCES lo eliminará del listado de juegos.

-----------------------------------------------------------------------------------------

Como cliente
Quiero visualizar los juegos disponibles 
Para jugar y agregar un comentario.

DADO un cliente
CUANDO ingresa a Juegos
ENTONCES podrá visualizará los juegos cargados y tendrá un filtro por nombre y categoría.

DADO un cliente
CUANDO ingresa al detalle de un juego
ENTONCES podrá visualizar los comentarios y agregar un comentario.
