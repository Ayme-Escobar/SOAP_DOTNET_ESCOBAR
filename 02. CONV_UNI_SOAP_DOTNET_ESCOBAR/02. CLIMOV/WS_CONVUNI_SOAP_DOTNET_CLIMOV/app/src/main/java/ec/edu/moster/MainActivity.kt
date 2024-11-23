package ec.edu.moster

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import ec.edu.moster.ui.theme.WS_CONVUNI_SOAP_JAVA_CLIMOVTheme
import ec.edu.moster.controlador.AuthController
import ec.edu.moster.controlador.ConversionController
import ec.edu.moster.modelo.AuthModel
import ec.edu.moster.modelo.ConversionModel
import ec.edu.moster.vista.ConversionScreen
import ec.edu.moster.vista.LoginScreen

class MainActivity : ComponentActivity() {
    private val authController = AuthController(AuthModel())
    private val conversionController = ConversionController(ConversionModel())

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            WS_CONVUNI_SOAP_JAVA_CLIMOVTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    var isAuthenticated by remember { mutableStateOf(authController.isUserAuthenticated()) }

                    if (isAuthenticated) {
                        ConversionScreen(
                            controller = conversionController,
                            onLogout = {
                                authController.logout()
                                isAuthenticated = authController.isUserAuthenticated()
                            }
                        )
                    } else {
                        LoginScreen(authController) {
                            isAuthenticated = authController.isUserAuthenticated()
                        }
                    }
                }
            }
        }
    }
}
