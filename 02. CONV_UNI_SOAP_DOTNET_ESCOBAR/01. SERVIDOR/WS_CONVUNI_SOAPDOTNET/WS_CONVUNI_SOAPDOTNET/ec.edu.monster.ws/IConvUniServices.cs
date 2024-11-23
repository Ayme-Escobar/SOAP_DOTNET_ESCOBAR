using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WS_CONVUNI_SOAPDOTNET
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IConvUniServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IConvUniServices
    {
        [OperationContract]
        double CentigradoAFarenheit (double c);

        [OperationContract]
        double CentigradoAKelvin(double c);        
    }
}
