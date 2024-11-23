package ec.edu.moster.prueba

import ec.edu.moster.controlador.AuthController
import ec.edu.moster.modelo.AuthModel
import java.util.Scanner

/**
 * Clase de prueba interactiva para la autenticación de usuarios.
 */
fun main() {
    // Instanciar el modelo y el controlador
    val authModel = AuthModel()
    val authController = AuthController(authModel)
    val scanner = Scanner(System.`in`)

    println("=== Prueba de Autenticación de Usuarios ===")

    // Solicitar el nombre de usuario y la contraseña al usuario
    print("Ingrese el nombre de usuario: ")
    val username = scanner.nextLine()

    print("Ingrese la contraseña: ")
    val password = scanner.nextLine()

    // Intentar autenticar al usuario
    val loginResult = authController.login(username, password)

    // Mostrar el resultado
    if (loginResult) {
        println("\nAutenticación exitosa. ¡Bienvenido, $username!")
    } else {
        println("\nAutenticación fallida. Usuario o contraseña incorrectos.")
    }

    // Preguntar si el usuario quiere cerrar sesión
    println("\n¿Desea cerrar sesión? (sí/no): ")
    val logoutResponse = scanner.nextLine()

    if (logoutResponse.equals("sí", ignoreCase = true)) {
        authController.logout()
        println("Se ha cerrado la sesión correctamente.")
    } else {
        println("La sesión permanece activa.")
    }

    // Verificar si el usuario está autenticado
    val isAuthenticated = authController.isUserAuthenticated()
    println("\nEstado de autenticación: ${if (isAuthenticated) "Activo" else "Inactivo"}")

    scanner.close()
}
