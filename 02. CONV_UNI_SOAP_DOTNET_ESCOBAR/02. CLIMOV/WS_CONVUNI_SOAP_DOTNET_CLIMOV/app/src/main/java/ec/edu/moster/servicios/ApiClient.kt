package ec.edu.moster.servicios

import retrofit2.Retrofit
import retrofit2.converter.scalars.ScalarsConverterFactory

object ApiClient {
    private const val BASE_URL = "http://10.240.0.214/ServiceConvUni/"

    val retrofit: Retrofit = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(ScalarsConverterFactory.create())
        .build()

    val soapService: SoapService = retrofit.create(SoapService::class.java)
}
