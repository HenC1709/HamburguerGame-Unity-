# 🍔 HamburgerGame — Unity 6

Migración del juego de hamburguesas de consola C# a Unity 6 (Universal 2D).  
El jugador arma hamburguesas por capas siguiendo una receta, contra el reloj y con vidas limitadas.

---

## 🗂️ Estructura del proyecto

```
Assets/
├── Scripts/
│   ├── Enums/
│   │   └── TipoHamburguesa.cs
│   ├── Interfaces/
│   │   └── IVerificable.cs
│   ├── Models/
│   │   ├── Ingrediente.cs
│   │   ├── Hamburguesa.cs          ← clase abstracta
│   │   ├── HamburguesaNormal.cs
│   │   ├── HamburguesaDoble.cs
│   │   ├── HamburguesaVegana.cs
│   │   └── Jugador.cs
│   ├── Services/
│   │   ├── RecetaService.cs
│   │   ├── SaveService.cs
│   │   └── GameManager.cs          ← MonoBehaviour principal
│   └── UI/                         ← pendiente
│
├── Scenes/                         ← pendiente
├── Sprites/
│   ├── Ingredients/                ← craft-a-burger (pixdio, itch.io)
│   ├── UI/
│   └── Backgrounds/
├── Audio/
│   ├── SFX/
│   └── Music/
├── Prefabs/                        ← pendiente
└── Fonts/
```

---

## 📦 Dependencias

| Paquete | Versión | Uso |
|---|---|---|
| `com.unity.nuget.newtonsoft-json` | latest | Serialización JSON para saves |

---

## 🧠 Arquitectura

### Clases principales

**`Ingrediente`**  
Modelo simple. Tiene `Nombre` (string). Se agrega a la hamburguesa capa por capa.

**`Hamburguesa` (abstracta)**  
Base de todos los tipos. Maneja la lista de ingredientes y la verificación por orden.  
Implementa `IVerificable`.

**`HamburguesaNormal`**  
Hereda `Hamburguesa` sin cambios. Usa la verificación base.

**`HamburguesaDoble`**  
Override de `Verificar`: requiere mínimo 5 ingredientes y que el segundo sea `"doble"`.

**`HamburguesaVegana`**  
Override de `Verificar`: falla si contiene `"carne"`, `"tocino"` o `"huevo"`. Requiere `"tomate"` y `"lechuga"`.

**`Jugador`**  
Modelo de datos del jugador: `Nombre`, `NivelActual`, `MejorNivel`, `PartidasJugadas`, `MejorPuntaje`.

**`RecetaService`**  
Lógica pura (sin MonoBehaviour). Gestiona los 14 niveles, recetas, pistas, nombres e ingredientes aleatorios.  
Métodos clave: `SetNivel()`, `SiguienteNivel()`, `ObtenerTipo()`, `EsValido()`, `IngredientesAleatorios()`.

**`SaveService`**  
Serializa/deserializa `Jugador` en JSON usando Newtonsoft.  
Ruta: `Application.persistentDataPath/{nombre}.json`.

**`GameManager`** ← MonoBehaviour  
Corazón del juego. Reemplaza el GameLoop de consola.  
Se adjunta a un GameObject en la escena de juego.

| Método | Descripción |
|---|---|
| `Awake()` | Inicializa RecetaService y SaveService |
| `IniciarJuego(Jugador)` | Entry point del juego, recibe el jugador desde la UI |
| `IniciarRonda()` | Crea la hamburguesa y registra el tiempo de inicio |
| `AgregarIngrediente(string)` | Llamado por la UI al presionar un botón de ingrediente |
| `CrearHamburguesa(List<string>)` | Instancia el tipo correcto según la receta |
| `ProcesarResultado()` | Verifica la hamburguesa, actualiza stats y lanza eventos |

### Eventos del GameManager

```csharp
public event Action OnNivelCompletado;
public event Action OnJuegoCompletado;
public event Action OnGameOver;
```

La UI se suscribe a estos eventos para navegar entre escenas o actualizar la pantalla.

---

## 🔄 Diferencias clave: Consola → Unity

| Consola | Unity |
|---|---|
| `Console.ReadLine()` | Botón en UI llama `AgregarIngrediente()` |
| `while (vidas > 0)` | Estado gestionado por `GameManager` |
| `Thread.Sleep(700)` | Coroutine + `WaitForSeconds` (pendiente) |
| `Console.WriteLine()` | `Debug.Log()` o texto en UI |
| `Stopwatch` | `Time.time - _tiempoInicio` |
| Ruta relativa `"Data/"` | `Application.persistentDataPath` |
| `System.Text.Json` | `Newtonsoft.Json` |

---

## 🎮 Niveles

| # | Nombre | Ingredientes |
|---|---|---|
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

---

## 🗺️ Roadmap

- [x] Migrar modelos, enums e interfaces
- [x] Migrar RecetaService y SaveService
- [x] Construir GameManager (MonoBehaviour)
- [x] Assets: sprite sheet de ingredientes (craft-a-burger, pixdio)
- [x] Crear escenas: Menu, Juego, GameOver
- [x] Construir Canvas UI (vidas, nivel, puntaje, pista)
- [x] Botones de ingredientes conectados a `AgregarIngrediente()`
- [ ] Drag & drop de ingredientes
- [ ] Sistema de sonidos (SFX + música)
- [ ] Countdown animado (Coroutine 3, 2, 1, GO!)
- [ ] Pantalla de login / selección de jugador

---

## 🛠️ Setup

1. Unity 6, plantilla **Universal 2D**
2. Instalar Newtonsoft.Json: `Window → Package Manager → + → Add by name → com.unity.nuget.newtonsoft-json`
3. Abrir el proyecto en VS Code: `Edit → Preferences → External Tools → Open C# Project`

---

*Proyecto de portafolio — migración consola → Unity*