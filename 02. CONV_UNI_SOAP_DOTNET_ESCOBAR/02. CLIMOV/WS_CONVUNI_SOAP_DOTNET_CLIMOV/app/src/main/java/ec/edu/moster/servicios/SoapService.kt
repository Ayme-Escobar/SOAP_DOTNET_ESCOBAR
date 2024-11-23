package ec.edu.moster.servicios

import okhttp3.RequestBody
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.Headers
import retrofit2.http.POST

interface SoapService {

    @POST("ConvUniServices.svc")
    @Headers(
        "Content-Type: text/xml;charset=UTF-8",
        "SOAPAction: http://tempuri.org/IConvUniServices/CentigradoAFarenheit"
    )
    fun centigradoAFarenheit(@Body requestBody: RequestBody): Call<String>

    @POST("ConvUniServices.svc")
    @Headers(
        "Content-Type: text/xml;charset=UTF-8",
        "SOAPAction: http://tempuri.org/IConvUniServices/CentigradoAKelvin"
    )
    fun centigradoAKelvin(@Body requestBody: RequestBody): Call<String>
}
