# Scripts - Movimiento Rectlíneo 1

## 1. Crear un script que mueva el objeto hacia un punto fijo que se marque como objetivo utilizando el método *Translate* de la clase *Transform*. El objetivo debe ser una variable pública, de esta forma conseguimos manipularla en el inspector y ver el efecto de distintos valores en las coordenadas. Utilizar ``this.transform.Translate(goal)`` en el start, solo se mueve una vez. Experimentar las siguientes opciones:

![script1](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate.gif)

[Script Start](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate.cs)

### a. Añadir ``this.transform.Translate(goal);`` al Update e ir multiplicando ``goal = goal * 0.5f;`` en el start para dar saltos más pequeños cada vez.

![script Update1](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20update.gif)

[Script Update](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate.cs)

### b. Configurar la coordenada Y del Objetivo en 0.

![FotoY0](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/CoordenadaY0.jpg)

![Script Update2](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20update2.gif)

### c. Poner al Objetivo una coordenada Y distinta de cero.

![FotoY2](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/CoordenadaY2.jpg)

![script Update3](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20update3.gif)

### d. Modificar el script para que el objeto despegue del suelo y vuele como un avión.

Para lograr esto lo que debemos hacer es dejar la coordeanada **X** del `goal` a 0 y que las coordenadas **Y** y **Z** sean mayor a 0.

![FotoDespegue](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/CoordenadaDespegue.jpg)

![Script Despegue](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20despegue.gif)

### e. Duplicar los valores de X, Y, Z del Objetivo. ¿Es consistente el movimiento?.

El movimento que se obtiene no es consistente, por lo que la sensación de movimiento no es suave sino brusca.

## 2 .El Objetivo no es un objetivo propiamente dicho, sino una dirección en la que queremos movernos. La información relevante de un vector es la dirección. Los vectores normalizados, conservan la misma dirección pero su escala no afecta al movimiento. Se debe conseguir un movimiento consistente de forma que la escala no afecte a la traslación. Del mismo modo, se debe conseguir que el recorrido realizado por el personaje entre un frame y otro no tenga aberraciones espacio-temporales. Para ello se debe considerar la relación entre la velocidad, el espacio y el tiempo. Por otra parte, el tiempo que transcurre entre un frame y otro se obtiene con: `Time.deltaTime`.
![Transición](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/Transici%C3%B3n.jpg)
### En este ejercicio se pretende dotar de esa consistencia al movimiento que hacer el personaje para ello: 

### a. Sustituir la dirección del movimiento por su equivalente normalizada. Esto se consigue con el método normalized de la clase Vector3: this.transform.Translate(goal.normalized);
### b. Con el vector normalizado, lo podemos multiplicar por un valor de velocidad para determinar cómo de rápido va el personaje. `public float speed = 0.1f` y `transform.Translate(goal.normalized*speed)`
### c. A pesar de que esas velocidades puedan parecer ahora que son consistentes, no lo son, porque dependen de la velocidad a la que se produzca el update. El tiempo entre dos updates no es necesariamente siempre el mismo, con lo que se pueden tener inconsistencias en la velocidad, y a pesar de que en aplicaciones con poca complejidad no lo notemos, se debe usar: `transform.Translate(goal.normalized * speed*Time.deltaTime);` para suavizar el movimiento ya que `Time.deltaTime` es el tiempo que ha pasado desde el último frame. 

![Script Punto2](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20punto2.gif)

[Script Punto 2](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate2.cs)

## 3. En lugar de seguir usando una dirección como objetivo, vamos a movernos ahora hacia una verdadera posición objetivo. Lo agregarermos como un campo público en la clase para poder configurarlo desde le Inspector. También agregaremos un campo para configurar la velocidad del personaje desde el propio Inspector. Aunque queramos desplazarnos hacia un punto en el espacio, el método Translate debe recibir la dirección del movimiento. La dirección que une dos puntos se obtiene restando el más lejano al más cercano. Por último, si el personaje no está encarando el objetivo (podría incluso estar de espaldas a él), el desplazamiento será suave pero la orientación de su malla no será consistente. Por esta razón será necesario rotarlo de forma que su eje z local (forward) apunte hacia el objetivo. La función `LookAt` del `Transform` nos ayudará con esto. En este caso, por tanto, para movernos hacia un punto en el espacio que configuramos a una velocidad dada: 
### a. Hacemos el objetivo una variable pública `public Transform goal` y añadimos un `public float speed = 1.0f`. 
### b. Giramos al personaje para lograr que su movimiento sea hacia delante utilizando `this.transform.LookAt(goal.position)` en el Start para que gire primero y luego se mueva. 
### c. La dirección en la que nos tenemos que mover viene determinada por la diferencia entre la posición del objetivo y nuestra posición.

``Vector3 direction = goal.position - this.transform.position;``

``this.transform.Translate(direction.normalized * speed * Time.deltaTime)``

![Script punto 3](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20a%20otro%20objeto.gif)

[Script Punto 3](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate3.cs)


## 4. Añadir ``Debug.DrawRay(this.transform.position,direction,Color.red)`` para depuración para comprobar que la dirección está correctamente calculada. 

![Script punto 4](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20a%20otro%20objeto%20con%20linea.gif)

[Script punto 4](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate4.cs)

## 5. Agregar un cubo en la escena que hará de objetivo, que debe ser movido usando el controlador de los Starter Assets. Sobre la escena que has trabajado ubica un personaje que va a seguir al cubo. 

Añadiremos un gameObjecto (un cubo) y le daremos los siguientes componentes para que poueda ser controlado. `Character Controller`, `Player Input`, `Third Person Controller (Script)` ,  `Starter Assets Inputs (Script)`

### a. Crear un script que haga que el personaje siga al cubo continuamente sin aplicar simulación física.
### b. Agregar un campo público que permita graduar la velocidad del movimiento desde el inspector de objetos.
### c. Utilizar la tecla de espaciado para incrementar la velocidad del desplazamiento en el tiempo de juego.

![Script punto 5](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20seguimiento%20objeto.gif)

[Script punto 5](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate5.cs)

## 6. En esta sesión se trabaja el Movimiento rectilíneo hacia el objeti haciendo avanzar al personaje siempre en línea recta hacia adelante.  Para ello, el personaje debe rotar hacia el objetivo y luego avanzar en la dirección foward. En este caso hay  que destacar que el método Translate de la clase Transform tiene dos formas de realizar la traslación. Esto lo podemos resolver rotando al personaje hacia su objetivo (LookAt) y trasladándolo en el eje forward, respecto al sistema de referencia local, lo que corresponde al valor por defecto del parámetro de Translate: relativeTo. Sin embargo, imagina que el personaje está dentro de un vehículo que también se está moviendo. Si solo avanzamos en el eje Z local, el personaje se moverá hacia adelante en relación al vehículo, pero no necesariamente hacia el objetivo en el mundo. Para resolver esto lo que debemos hacer es movernos en la dirección correcta con respecto a sistema de referencia mundial, que corresponde al valor Space.World del parámetro relativeTo de la clase Transform. En este ejercicio experimentamos con estas cuestiones:
### a. Realizar un script que gire al personaje hacia su objetivo para llegar hasta él desplazándose sobre su vector forward local.

![Script punto 6](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20punto%206.gif)

[Script punto 6](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate6.cs)

### b. Realizar un script que gire al personaje y lo desplace hacia su objetivo sobre la dirección que lo une con su objetivo. Normarlizar la dirección para evitar la influencia de la magnitud del vector
![Script punto 6b](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20punto%206b.gif)

[Script punto 6b](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate6b.cs)
## 7. Cuando ejecutamos el script, el personaje calcula la dirección hacia el objetivo y se mueve hacia él, pero no puede dejar de moverse y se produce jittering. La razón es que todavía estamos dentro del bucle, calculando la dirección y moviéndonos hacia él. En la mayoría de los casos no vamos a conseguir que nuestro personaje se mueva a la posición exacta del objetivo, con lo que continuamente oscila en torno a esa posición. Por eso, debemos tener algún cálculo del tipo de rango de tolerancia. Incluimos una variable global pública, `public float accuracy = 0.01f`; y una condición `if(direction.magnitude > accuracy)`. Aún con el accuracy, el personaje puede hacer jitter si la velocidad es muy alta.
### a. Controlar el jittering utilizando la magnitud de la dirección.

![Script punto 7](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20punto%207.gif)

[Script punto 7](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate7.cs)

### b. Dado que la dirección nos la da la separación entre el objetivo y el personaje, también podemos controlar el jittering utilizando la distancia entre los dos puntos.

El resultado es el mismo que en el punto 7.

![Script punto 7b](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20punto%207.gif)

[Script punto 7b](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate7b.cs)

## 8. En esta sesión se trabaja el Movimiento rectilíneo haciendo avanzar al personaje siempre en línea recta hacia adelante introduciendo una mejora. El uso de la función `LookAt` hace que el personaje gire instantáneamente hacia el objetivo, provocando cambios bruscos. Se aconseja realizar una transición suave a lo largo de diferentes frames. Para ello, en lugar de computar una rotación del ángulo necesario, se realizan sucesivas rotaciones donde el ángulo en cada frame viene dado por los valores intermedios al interpolar la dirección original y la final. Para esto utilizaremos la función `Slerp` de la clase `Quaternion`. Un quaternion es un instrumento matemático que facilita el cálculo de rotaciones evitando el Gimbal Lock.

![Script punto 8](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20punto%208.gif)

[Script punto 8](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate8.cs)


## 10. En esta sección se trabaja un sistema básico de Waypoints. Se debe crear un circuito en una escena con la colección de puntos que conforman el circuito. Cada punto del circuito será un objeto 3D al que se le asigne la etiqueta “waypoint”. También se agregará un objeto personaje que será el que recorra los objetivos. Este objeto debe implementar el script con la mecánica de recorrido del circuito. Para ello, debe recuperar la referencia a cada uno de los objetivo y realizar los desplazamientos de un objetivo a otro aplicando el trabajo anterior. En la lógica se debe incluir la gestión de obtener quién es el siguiente objetivo.

Para este apartado necesitaremos crear un gameObject vacío, el cual contendrá los puntos (waypoints) por los que pasará el objeto.

![Waypoints](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/Waypoints.PNG)

El script se asocia a un objeto personaje y requiere un conjunto de waypoints dentro de un objeto vacío llamado Circuit. Cada `waypoint` es un objeto 3D independiente que se encuentra dentro de este contenedor y se interpreta como un objetivo a alcanzar en el orden establecido dentro de la jerarquía de Unity. Al ejecutar la escena, el personaje se moverá a través de estos puntos, cambiando de color el `waypoint` al que se dirige para una mejor visualización y mostrando en la consola el nombre de cada objetivo alcanzado. Cuando se llega al último waypoint, el personaje vuelve a iniciar el recorrido, formando un ciclo de movimiento ininterrumpido.

Al iniciarse la escena, el script comienza identificando la posición inicial del personaje y creando una lista de `waypoints` a partir de los hijos del objeto Circuit. Esta lista define el orden en el que el personaje debe visitar cada punto de control. El script, mediante la función `Update()`, mueve al personaje hacia el `waypoint` actual usando la interpolación `Vector3.MoveTowards`, garantizando un movimiento fluido y constante entre los puntos.

Cada vez que el personaje alcanza un `waypoint` , el índice del waypoint actual `(currentWaypointIndex)` se incrementa, y el script comienza a dirigir al personaje hacia el siguiente punto en la lista.

el primer paso es capturar la posición inicial del personaje `initialPosition` para tener una referencia en caso de querer restaurar la posición en algún momento posterior. Luego, utiliza un bucle `foreach` para recorrer todos los hijos del objeto Circuit y agrega sus Transform a la lista waypoints. Es importante destacar que este método preserva el orden de los waypoints tal como aparecen en la jerarquía, garantizando que el personaje siga la ruta deseada.

Cuando el personaje llega a la posición del waypoint (es decir, cuando la distancia entre el personaje y el waypoint es menor a 0.1 unidades), se imprime en la consola el nombre del waypoint actual, y se actualiza el índice `currentWaypointIndex` para dirigirse al siguiente punto. La fórmula `currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count` asegura que el índice se restablezca a 0 cuando llega al final de la lista, creando un ciclo.

el método `HighlightWaypoint(Transform waypoint)` se utiliza para cambiar el color del `waypoint` actual y hacer un seguimiento visual del punto hacia el que se está moviendo el personaje. Al cambiar de `waypoint`, restaura el color del `waypoint` anterior a su color original (blanco) y establece el nuevo `waypoint` en color rojo. Para hacer esto, utiliza el componente `Renderer` de cada `waypoint` y guarda una referencia (previousRenderer) que permite restaurar el color la próxima vez que se cambie de objetivo.

![WaypointsFuncionamiento](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20translate%20punto%2010.gif)

[Script completo](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Waypoint.cs)


## 11. En esta sección se trabaja con el sistema de Waypoints de Unity. Para ello debes importar como asset en el proyecto la carpeta Utility. Configura el circuito, agrega el objetivo que debe perseguir el personaje y añade al personaje que recorrerá el circuito el script WaypointProgressTracker. Finalmente agrega un script al personaje que lo haga perseguir al objetivo. El sistema moverá el objetivo alejándolo del personaje moviéndose de un punto a otro del circuito. El personaje intenta perseguir al objetivo con nuestro script, por tanto, está “obligando” al objetivo a ir de un punto a otro a la par que lo persigue.

Lo primero que tenemos que hacer será añadir el script `WaypointCircuit` al objeto Circuito que creamos en el punto anterior. Una vez añadido, seleccionaremos el botón **Assign usign all child objects** para hacer que todos los hijos del objeto sean "waypoints".

![WaypointsHijos](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/punto11.PNG)

Ahora, lo que debemos hacer es añadir el script `WaypointProgressTracker` al personaje qe va a recorrer el circuito. Tras eso, debemos asignar desde el inspector las variables `Target` y `Circuit`. A la variable `Target` debemos asignarle el objeto que va a perseguir (otro objeto con el script `WaypointCircuit`) y a la variable `Circuit` debemos asignarle el circuito creado.

![WaypointProgressTracker](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/punto11.2.PNG)

Después, debemos realizar un script que contenga la lógica para poder seguir al objetivo.

[Script Punto 11](https://github.com/Alu0101030562/Scripts-MovimientoRectilineo1/blob/main/Assets/Scripts/Translate11.cs)

![Script Punto 11](https://github.com/Alu0101030562/Screenshots/blob/main/Screenshots/Scripts-Movimiento%20Rectilineo/script%20waypoint%20punto%2011.gif)
