package ec.edu.moster.modelo

import java.security.MessageDigest

class AuthModel {
    private val validUsername = "Monster"
    private val hashedPassword = hashPassword("Monster9")

    fun authenticate(username: String, password: String): Boolean {
        val hashedInputPassword = hashPassword(password)
        return username == validUsername && hashedInputPassword == hashedPassword
    }

    // Función para generar el hash SHA-256
    private fun hashPassword(password: String): String {
        val digest = MessageDigest.getInstance("SHA-256")
        val hashBytes = digest.digest(password.toByteArray())
        return hashBytes.joinToString("") { "%02x".format(it) }
    }
}
