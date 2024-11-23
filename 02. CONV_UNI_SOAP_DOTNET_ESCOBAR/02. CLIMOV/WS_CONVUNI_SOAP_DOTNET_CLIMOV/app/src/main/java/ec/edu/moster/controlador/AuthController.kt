package ec.edu.moster.controlador
import ec.edu.moster.modelo.AuthModel

class AuthController(private val model: AuthModel) {
    private var isAuthenticated = false

    fun login(username: String, password: String): Boolean {
        isAuthenticated = model.authenticate(username, password)
        return isAuthenticated
    }

    fun logout() {
        isAuthenticated = false
    }

    fun isUserAuthenticated(): Boolean {
        return isAuthenticated
    }
}