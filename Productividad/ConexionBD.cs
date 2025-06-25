using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//2. Importar:
using System.Data.Odbc;


namespace Productividad
{


    public class ConexionBD
    {
        //3. Declarar objeto conexion
        public OdbcConnection conexion { get; set; }
        public ConexionBD()
        {
            //Ir al web.config para traer los datos de conexion
            //4. Declarar objeto para comunicarnos con el webconfig
            System.Configuration.Configuration webConfig;
            //5. Abrir el web.config
            webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Productividad");
            //6. Declarar objeto para guardar el string de conexion
            System.Configuration.ConnectionStringSettings stringDeConexion;
            //7. Extraer el string de conexion del objeto de configuracion ligado al web.config
            //necesitamos el nombre del string de conexion del web.config
            stringDeConexion = webConfig.ConnectionStrings.ConnectionStrings["BDProductividad"];
            //8. Instanciar la conexion con el string de conexion
            conexion = new OdbcConnection(stringDeConexion.ToString());
            //9. Abrir la conexion
            conexion.Open();
        }
    }

}
