AHORA — Consola
├── ✅ Clases, interfaces, listas
├── ✅ Save/Load JSON
├── ✅ Game loop, estado
└── 🔲 Pulir: auto-listo, carpeta Datos

PRÓXIMO — C# que falta antes de Unity
├── Herencia básica (extends)
├── Clases abstractas
├── Enums (para estados: GameState, NivelState)
└── Events y delegates (Unity los usa mucho)

UNITY FUNDAMENTOS — sin juego aún
├── Qué es un GameObject y un Component
├── MonoBehaviour: Start(), Update()
├── Prefabs
└── Inspector y serialización de campos

MIGRACIÓN — llevar este juego a Unity
├── Hamburguesa y RecetaService se reutilizan tal cual
├── SaveService cambia Path + JsonUtility
├── Program.cs se reemplaza por GameManager.cs (MonoBehaviour)
└── Input: Console.ReadLine() → UI Buttons / TMP_InputField

UNITY JUEGO COMPLETO
├── UI con Canvas
├── Drag & drop ingredientes
├── Animaciones simples
└── Escenas (Menú, Juego, GameOver)