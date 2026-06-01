# 🍔 HamburgerGame

Juego de consola en C# para practicar lógica y POO antes de migrar a Unity.

## Checklist consola
- [x] Estructura base con interfaz `IVerificable`
- [x] Validación de ingredientes disponibles
- [x] Vidas / intentos limitados (3 vidas)
- [x] Múltiples niveles con recetas de dificultad creciente
- [x] Receta oculta — el jugador adivina
- [x] Sistema de usuario (nombre, progreso)
- [x] Save/Load JSON en carpeta /Datos
- [x] Pistas en niveles altos
- [x] Contrarreloj con puntaje por velocidad
- [x] Ingredientes en orden aleatorio cada ronda
- [x] Auto-completar al llenar ingredientes (sin "listo")
- [x] Opción rendirse
- [x] Countdown épico + display de puntaje
- [ ] Refactor Program.cs — extraer GameLoop, LoginFlow a clases propias
- [ ] Refactor para Unity
## Roadmap hacia Unity

### Etapa 1 — Antes de Unity
- [ ] Herencia básica
- [ ] Clases abstractas  
- [ ] Enums
- [ ] Events y delegates
- [ ] **Refactor Main** — GameManager.cs + LoginManager.cs

### Etapa 2 — Unity fundamentos (sin juego aún)
- [ ] GameObjects y Components
- [ ] MonoBehaviour: Start(), Update()
- [ ] Prefabs
- [ ] Inspector y serialización de campos

### Etapa 3 — Migración del juego
- [ ] Hamburguesa y RecetaService se reutilizan
- [ ] SaveService: cambiar Path + JsonUtility
- [ ] Program.cs → GameManager.cs (MonoBehaviour)
- [ ] Console.ReadLine() → UI Buttons / TMP_InputField

### Etapa 4 — Unity juego completo
- [ ] UI con Canvas
- [ ] Drag & drop ingredientes
- [ ] Animaciones simples
- [ ] Escenas: Menú, Juego, GameOver

## Niveles
| Nivel | Ingredientes | Pista |
|-------|-------------|-------|
| 1 | 3 | — |
| 2 | 4 | — |
| 3 | 5 | Sí |
| 4 | 7 | Sí |

## Puntaje
Base: 1000 pts — 10 por cada segundo usado.

## Conceptos practicados
- Interfaces
- Clases y encapsulamiento
- Listas, HashSet, ordenamiento aleatorio
- Serialización JSON (System.Text.Json)
- Separación de responsabilidades
- Lógica de estado (vidas, niveles, save/load)
- Stopwatch, Thread.Sleep, countdown

## Correr el proyecto
dotnet run