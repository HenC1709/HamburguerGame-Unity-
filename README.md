# 🍔 HamburgerGame

Juego de consola en C# para practicar lógica y POO antes de migrar a Unity.

## Estado actual
- [x] Estructura base con interfaz `IVerificable`
- [x] Validación de ingredientes disponibles
- [x] Vidas / intentos limitados (3 vidas)
- [x] Múltiples niveles con recetas de dificultad creciente
- [x] Receta oculta — el jugador adivina
- [ ] Refactor para Unity

## Niveles
| Nivel | Ingredientes |
|-------|-------------|
| 1 | 3 ingredientes |
| 2 | 4 ingredientes |
| 3 | 5 ingredientes |
| 4 | 7 ingredientes |

## Conceptos practicados
- Interfaces
- Clases y encapsulamiento
- Listas, HashSet
- Separación de responsabilidades (Models / Services)
- Lógica de estado (vidas, niveles, game loop)

## Correr el proyecto
dotnet run