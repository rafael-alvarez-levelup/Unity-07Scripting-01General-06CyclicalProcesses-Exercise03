**Requisitos:**
- Unity 2020.x.
- Visual Studio.

**Objetivos:**
1. Utilizar métodos delegados y eventos para la comunicación entre un sistema de vida y la interfaz gráfica.
3. Estructurar y comentar el código correctamente.
4. Compilar el proyecto de Unity para Windows.


**Procedimientos:**
1. Crear un sistema de de vida que almacene la vida del jugador, el evento de cambio de cantidad de vida y métodos auxiliares pertinentes.
2. Crear un controlador del botón de aplicar daño que implemente la interfaz IPointerClickHandler para escuchar el evento de pulsación del botón para aplicar la reducción de vida al sistema de vida.
Información relacionada: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.IPointerClickHandler.html
3. Crear un comportamiento que actualice el valor de la vida con el nuevo valor que se muestra en la interfaz gráfica.
4. Estructurar y comentar el código utilizando las regiones adecuadas y comentarios.
5. El proyecto se debe compilar para ser ejecutado en Windows. La compilación del proyecto se debe guardar en una carpeta llamada "build" en la raíz del proyecto de Unity.