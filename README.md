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
- [x] Hamburguesa Doble con herencia y override
- [x] Hamburguesa Vegana con herencia y override
- [ ] Migración a Unity
```
## Estructura
HamburgerGame/
├── Models/
│   ├── Ingrediente.cs
│   ├── HamburguesaDoble.cs
│   ├── HamburuesaVegana.cs
│   ├── HamburguesaNormal.cs
│   ├── Hamburguesa.cs
│   └── Jugador.cs
├── Interfaces/
│    └── IVerificable.cs
├── Enums/
│   ├── TipoHamburguesa
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
- [x] Clases abstractas
- [x] Enums
- [x] Events y delegates

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
| 10 | La Tex-Mex | 9 |
| 11 | La Doble Infernal | 10 |
| 12 | La Chef Secreta | 10 |
| 13 | El Monstruo | 12 |
| 14 | La Última Cena | 13 |

## Puntaje
Base: 1000 pts — 10 por cada segundo usado.

## Conceptos practicados
- Interfaces
- Clases y encapsulamiento
- Herencia y polimorfismo (Hamburguesa → Normal, Doble, Vegana)
- Clases abstractas
- Enums y switch expressions
- Events y delegates
- Listas, HashSet, LINQ (OrderBy, Distinct)
- Serialización JSON (System.Text.Json)
- Separación de responsabilidades
- Inyección de dependencias (constructor injection)
- Lógica de estado (vidas, niveles, save/load)
- Stopwatch y countdown
- Refactor: Single Responsibility por clase

## Correr el proyecto
dotnet run
