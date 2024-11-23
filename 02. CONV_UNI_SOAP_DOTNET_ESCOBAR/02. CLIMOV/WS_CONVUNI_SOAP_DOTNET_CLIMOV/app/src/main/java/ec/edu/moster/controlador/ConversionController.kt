package ec.edu.moster.controlador

import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import ec.edu.moster.modelo.ConversionModel
import ec.edu.moster.servicios.ApiClient
import android.util.Log

class ConversionController(private val model: ConversionModel) {

    fun convert(conversionType: String, value: String, onResult: (String) -> Unit) {
        try {
            Log.d("ConversionController", "Iniciando conversión con tipo: $conversionType y valor: $value")

            // Crear el cuerpo de la solicitud SOAP
            val requestBody = model.createSoapRequest(conversionType, value)
            Log.d("ConversionController", "Cuerpo de la solicitud creado: $requestBody")

            // Inicializar el servicio SOAP
            val soapService = ApiClient.soapService
            Log.d("ConversionController", "Servicio SOAP inicializado")

            // Llamar al servicio correspondiente según el tipo de conversión
            val call: Call<String> = when (conversionType) {
                "CentigradoAFarenheit" -> soapService.centigradoAFarenheit(requestBody)
                "CentigradoAKelvin" -> soapService.centigradoAKelvin(requestBody)
                else -> {
                    onResult("Conversión no soportada")
                    return
                }
            }

            Log.d("ConversionController", "Llamada al servicio SOAP preparada")

            // Ejecutar la llamada al servicio SOAP
            call.enqueue(object : Callback<String> {
                override fun onResponse(call: Call<String>, response: Response<String>) {
                    if (response.isSuccessful) {
                        // Analizar la respuesta SOAP
                        val result = response.body()?.let { model.parseSoapResponse(it) } ?: "Error en la conversión"
                        Log.d("ConversionController", "Respuesta exitosa: $result")
                        onResult(result)
                    } else {
                        Log.e("ConversionController", "Error en la respuesta: ${response.code()}")
                        onResult("Error en la respuesta")
                    }
                }

                override fun onFailure(call: Call<String>, t: Throwable) {
                    Log.e("ConversionController", "Fallo en la llamada: ${t.message}", t)
                    onResult("Fallo en la llamada: ${t.message}")
                }
            })
        } catch (e: Exception) {
            Log.e("ConversionController", "Error en convert: ${e.message}", e)
        }
    }
}
