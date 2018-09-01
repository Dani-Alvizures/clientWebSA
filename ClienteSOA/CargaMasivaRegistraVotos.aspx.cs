using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Net;
using System.Web.Script.Serialization;


namespace ClienteSOA
{
    public partial class CargaMasivaRegistraVotos : System.Web.UI.Page
    {
        public class MensajeError
        {
            public string Mensaje { get; set; }
            public string EsError { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Boton para realizar la carga masiva
        protected void RealizarCarga_Click(object sender, EventArgs e)
        {
            var postString = CargaM.Text;
            byte[] Data = UTF8Encoding.UTF8.GetBytes(postString);
            HttpWebRequest Request;
            Request = WebRequest.Create("Ruta_ws") as HttpWebRequest;
            Request.Timeout = 10 * 1000;
            Request.Method = "POST";
            Request.ContentLength = Data.Length;
            Request.ContentType = "application/json; charset=utf-8";

            //Si el WS tiene credencialaes
            string Credenciales = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("usuario;clave"));
            Request.Headers.Add("Authorization", "Basic " + Credenciales);

            Stream PostStream = Request.GetRequestStream();
            PostStream.Write(Data, 0, Data.Length);
            HttpWebResponse Respuesta = Request.GetResponse() as HttpWebResponse;
            StreamReader Reader = new StreamReader(Respuesta.GetResponseStream());
            string Cuerpo = Reader.ReadToEnd();

            //Se captura el JSon
            JavaScriptSerializer Sc = new JavaScriptSerializer();
            List<MensajeError> Objeto = (List<MensajeError>)Sc.Deserialize(Cuerpo, typeof(List<MensajeError>));

            //Se muestran los datos
            DataTable DataT = new DataTable();
            DataColumn Columna;
            DataRow Fila;

            //Se crea una nueva columna
            Columna = new DataColumn();
            Columna.DataType = System.Type.GetType("System.String");
            Columna.ColumnName = "mensaje";
            DataT.Columns.Add(Columna);

            //Se crea otra columna
            DataColumn Columna2 = new DataColumn();
            Columna2.DataType = System.Type.GetType("System.String");
            Columna2.ColumnName = "EsError";
            DataT.Columns.Add(Columna2);

            foreach (MensajeError Ob in Objeto)
            {
                Fila = DataT.NewRow();
                Fila["mensaje"] = Ob.Mensaje;
                Fila["EsError"] = Ob.EsError;
                DataT.Rows.Add(Fila);
            }

            TablaDatos.DataSource = DataT;
            TablaDatos.DataBind();

        }
    }
}