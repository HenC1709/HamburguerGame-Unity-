# 🍔 HamburgerGame

Juego de consola en C# para practicar lógica y POO antes de migrar a Unity.

## Checklist consola
- [x] Estructura base con interfaz `IVerificable`
- [x] Validación de ingredientes con HashSet
- [x] Vidas / intentos limitados
- [x] Múltiples niveles con dificultad creciente (9 niveles)
- [x] Receta oculta — el jugador adivina
- [x] Pistas en niveles altos
- [x] Save/Load JSON por jugador en /Datos
- [x] Selección de múltiples usuarios
- [x] Contrarreloj con puntaje por velocidad
- [x] Ingredientes en orden aleatorio
- [x] Auto-completar al llenar ingredientes
- [x] Opción rendirse
- [x] Countdown épico + display de puntaje
- [x] Refactor Main — LoginManager + GameLoop
- [x] Ingredientes por nivel en orden aleatorio sin duplicados
- [x] Nombre del nivel en pantalla
- [ ] Hamburguesa Doble | Hamburgesa Vegana
- [ ] Migración a Unity
```
## Estructura
HamburgerGame/
├── Models/
│   ├── Ingrediente.cs
│   ├── Hamburguesa.cs
│   └── Jugador.cs
├── Interfaces/
│   └── IVerificable.cs
├── Services/
│   ├── RecetaService.cs
│   ├── SaveService.cs
│   ├── LoginManager.cs
│   └── GameLoop.cs
├── Datos/
│   └── [jugador].json
└── Program.cs
```
## Roadmap hacia Unity
### Etapa 1 — C# pendiente
- [x] Herencia básica
- [ ] Clases abstractas
- [ ] Enums
- [ ] Events y delegates

### Etapa 2 — Unity fundamentos
- [ ] GameObjects y Components
- [ ] MonoBehaviour: Start(), Update()
- [ ] Prefabs
- [ ] Inspector y serialización

### Etapa 3 — Migración
- [ ] Reutilizar Hamburguesa y RecetaService
- [ ] SaveService: Path + JsonUtility
- [ ] GameLoop → GameManager : MonoBehaviour
- [ ] Input → UI Buttons / TMP_InputField

### Etapa 4 — Unity completo
- [ ] UI con Canvas
- [ ] Drag & drop ingredientes
- [ ] Animaciones simples
- [ ] Escenas: Menú, Juego, GameOver

## Niveles
| Nivel | Nombre | Ingredientes |
|-------|--------|-------------|
| 1 | La Clásica | 3 |
| 2 | Cheeseburger | 4 |
| 3 | Bacon Burger | 5 |
| 4 | Pollo Picante | 5 |
| 5 | Veggie Completa | 6 |
| 6 | Breakfast Burger | 6 |
| 7 | BBQ Especial | 7 |
| 8 | Todo Terreno | 8 |
| 9 | Desafío del Chef | 10 |

## Puntaje
Base: 1000 pts — 10 por cada segundo usado.

## Conceptos practicados
- Interfaces
- Clases y encapsulamiento
- Listas, HashSet, ordenamiento aleatorio
- Serialización JSON (System.Text.Json)
- Separación de responsabilidades
- Inyección de dependencias (constructor injection)
- Lógica de estado (vidas, niveles, save/load)
- Stopwatch y countdown
- Refactor: Single Responsibility por clase

## Correr el proyecto
dotnet run
