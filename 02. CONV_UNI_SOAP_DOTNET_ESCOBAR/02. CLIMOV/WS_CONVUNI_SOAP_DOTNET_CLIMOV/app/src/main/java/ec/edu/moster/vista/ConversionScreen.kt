package ec.edu.moster.vista

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ExitToApp
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import ec.edu.moster.controlador.ConversionController
import ec.edu.moster.R

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun ConversionScreen(controller: ConversionController, onLogout: () -> Unit) {
    var inputValue by remember { mutableStateOf("") }
    var conversionResult by remember { mutableStateOf("Resultado") }
    var selectedConversion by remember { mutableStateOf("CentigradoAFarenheit") }

    Box(
        modifier = Modifier.fillMaxSize()
    ) {
        Image(
            painter = painterResource(id = R.drawable.file3),
            contentDescription = null,
            modifier = Modifier.fillMaxSize(),
            contentScale = ContentScale.Crop
        )

        Column(
            modifier = Modifier
                .fillMaxSize()
                .background(Color.White.copy(alpha = 0.75f))
                .padding(24.dp),
            verticalArrangement = Arrangement.Top,
            horizontalAlignment = Alignment.CenterHorizontally
        ) {
            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.End
            ) {
                IconButton(onClick = onLogout) {
                    Icon(
                        imageVector = Icons.Default.ExitToApp,
                        contentDescription = "Cerrar Sesión",
                        tint = MaterialTheme.colorScheme.primary
                    )
                }
            }

            Spacer(modifier = Modifier.height(16.dp))

            // Título
            Text(
                text = "Conversor de Temperatura",
                style = MaterialTheme.typography.headlineMedium,
                color = MaterialTheme.colorScheme.primary,
                modifier = Modifier.padding(bottom = 16.dp),
                textAlign = TextAlign.Center
            )

            OutlinedTextField(
                value = inputValue,
                onValueChange = { text ->
                    if (text.isNotEmpty() && text != "." && text.count { it == '.' } <= 1 &&
                        (text.all { it.isDigit() || it == '.' } || (text.startsWith("-") && text.drop(1).all { it.isDigit() || it == '.' }))) {
                        inputValue = text
                    } else if (text.isEmpty()) {
                        inputValue = ""
                    }
                },
                label = { Text("Ingrese el valor en grados Centígrados") },
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(bottom = 16.dp),
                textStyle = LocalTextStyle.current.copy(fontSize = 18.sp),
                keyboardOptions = KeyboardOptions.Default.copy(
                    keyboardType = KeyboardType.Number
                ),
                colors = TextFieldDefaults.outlinedTextFieldColors(
                    focusedTextColor = Color.Black,
                    unfocusedTextColor = Color.Black,
                    focusedBorderColor = MaterialTheme.colorScheme.primary,
                    unfocusedBorderColor = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.5f)
                )
            )

            Text(
                text = "Seleccione la conversión deseada:",
                style = MaterialTheme.typography.bodyMedium,
                color = MaterialTheme.colorScheme.primary,
                modifier = Modifier.padding(bottom = 8.dp)
            )

            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.SpaceEvenly
            ) {
                Column {
                    RadioButtonOption("CentigradoAFarenheit", "Fahrenheit", selectedConversion) { selectedConversion = it }
                    RadioButtonOption("CentigradoAKelvin", "Kelvin", selectedConversion) { selectedConversion = it }
                }
            }

            Spacer(modifier = Modifier.height(16.dp))

            Button(
                onClick = {
                    if (inputValue.isNotBlank()) {
                        controller.convert(selectedConversion, inputValue) { result ->
                            conversionResult = "$result ${getUnitSuffix(selectedConversion)}"
                        }
                    } else {
                        conversionResult = "Por favor, ingrese un valor válido"
                    }
                },
                modifier = Modifier
                    .fillMaxWidth()
                    .height(50.dp)
            ) {
                Text("Convertir", fontSize = 18.sp)
            }

            Spacer(modifier = Modifier.height(16.dp))

            Text(
                text = conversionResult,
                style = MaterialTheme.typography.bodyLarge,
                color = Color.Black,
                textAlign = TextAlign.Center,
                modifier = Modifier
                    .fillMaxWidth()
                    .background(MaterialTheme.colorScheme.surfaceVariant)
                    .padding(16.dp)
            )
        }
    }
}

fun getUnitSuffix(conversionType: String): String {
    return when (conversionType) {
        "CentigradoAFarenheit" -> "°F"
        "CentigradoAKelvin" -> "K"
        else -> ""
    }
}

@Composable
fun RadioButtonOption(value: String, label: String, selectedValue: String, onSelect: (String) -> Unit) {
    Row(
        verticalAlignment = Alignment.CenterVertically,
        modifier = Modifier.padding(vertical = 4.dp)
    ) {
        RadioButton(
            selected = selectedValue == value,
            onClick = { onSelect(value) }
        )
        Text(text = label, modifier = Modifier.padding(start = 8.dp))
    }
}
