package ec.edu.moster.modelo

import okhttp3.RequestBody
import okhttp3.MediaType
import org.xmlpull.v1.XmlPullParser
import org.xmlpull.v1.XmlPullParserFactory
import java.io.StringReader
import java.math.BigDecimal
import java.math.RoundingMode

class ConversionModel {

    // Crear la solicitud SOAP para Fahrenheit y Kelvin
    fun createSoapRequest(conversionType: String, value: String): RequestBody {
        val soapRequest = """
           <?xml version="1.0" encoding="UTF-8"?>
           <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
              <soapenv:Header/>
              <soapenv:Body>
                 <tem:$conversionType>
                    <tem:c>$value</tem:c>
                 </tem:$conversionType>
              </soapenv:Body>
           </soapenv:Envelope>
       """.trimIndent()

        // Crear el RequestBody utilizando MediaType.parse()
        val mediaType = MediaType.parse("text/xml;charset=UTF-8")
        return RequestBody.create(mediaType, soapRequest)
    }

    // Analizar la respuesta SOAP para Fahrenheit y Kelvin
    fun parseSoapResponse(response: String): String {
        val factory = XmlPullParserFactory.newInstance()
        val parser = factory.newPullParser()
        parser.setInput(StringReader(response))

        var result = ""
        var eventType = parser.eventType
        while (eventType != XmlPullParser.END_DOCUMENT) {
            // Buscar los resultados de CentigradoAFarenheitResult o CentigradoAKelvinResult
            if (eventType == XmlPullParser.START_TAG && (parser.name == "CentigradoAFarenheitResult" || parser.name == "CentigradoAKelvinResult")) {
                parser.next()
                result = parser.text ?: ""
            }
            eventType = parser.next()
        }

        // Formatear el resultado como BigDecimal si es posible
        return try {
            val bigDecimalResult = BigDecimal(result).setScale(5, RoundingMode.HALF_UP)
            bigDecimalResult.stripTrailingZeros().toPlainString()
        } catch (e: NumberFormatException) {
            result
        }
    }
}
