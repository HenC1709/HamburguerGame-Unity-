using Hamburguesas.Services;

// Inicialización de servicio
var saveService = new SaveService();
var recetaService = new RecetaService();
var loginManager = new LoginManager(saveService); 

// Flujo Principal
var jugador = loginManager.IniciarSesion();
var game = new GameLoop(recetaService, saveService, jugador);

game.Iniciar();