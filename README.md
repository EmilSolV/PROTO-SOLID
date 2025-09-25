# PROTO-SOLID

Prototipo para implementar los principios SOLID de single responsability e Inversión de dependencias :)

## ♥ Principio de Responsabilidad Única ♥

Cada clase en el proyecto tiene una única responsabilidad:

- **PlayerInput**: Gestiona la entrada del usuario (movimiento y disparo).
- **Shooter**: Se encarga de la lógica de disparo de proyectiles (de un arma en especifico).
- **Projectile**: Controla el comportamiento de un tipo de proyectil (movimiento y colisión).
- **IShootable**: Define la interfaz para objetos que pueden ser disparados.
- **IWeapon**: Define la interfaz para objetos que pueden disparar.
  Esta separación asegura que cada clase tenga una única razón para cambiar, facilitando la mantenibilidad y la escalabilidad del código, así como su entendimiento ♦

## ♥ Principio de Inversión de Dependencias ♥

El proyecto utiliza interfaces para desacoplar las dependencias entre clases:

- **PlayerInput** depende de la abstracción `IWeapon` en vez de una implementación concreta. Esto permite cambiar la lógica de disparo sin modificar la clase de entrada.
- **Shooter** implementa la interfaz `IWeapon`, permitiendo que cualquier clase que implemente esa interfaz pueda ser utilizada por `PlayerInput`.
- **Projectile** implementa la interfaz `IShootable`, permitiendo que cualquier objeto que pueda ser disparado siga la misma abstracción.

Este enfoque facilita la extensión y el testeo del código, ya que las dependencias están invertidas hacia interfaces. De esta manera a futuro se pueden seguir agregando tipos de armas y de proyectiles sin problemas si así se lo quisiera ☻
