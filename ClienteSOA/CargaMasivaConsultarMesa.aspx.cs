using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Data;
using System.Net;

namespace ClienteSOA
{
    public partial class CargaMasivaConsultarMesa : System.Web.UI.Page
    {
        public class ResultJason
        {
            public string CodigoDepartamento { get; set; }
            public string CodigoMunicipio { get; set; }
            public string CodigoCentroVotacion { get; set; }
            public string Direccion { get; set; }
            public string NumeroMesa { get; set; }
            public string NumeroLinea { get; set; }
            public string Mensaje { get; set; }
            public string EsError { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //------------------------------- Metodo para realizar la carga masiva
        protected void RealizarCarga_Click(object sender, EventArgs e)
        {
            var postString = CargaM.Text;
            byte[] Data = UTF8Encoding.UTF8.GetBytes(postString);
            HttpWebRequest Request;
            Request = WebRequest.Create("Ruta_ws") as HttpWebRequest;
            Request.Timeout = 10 * 1000;
            Request.Method = "GET";
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

            //Se muestra el resultado del JSON
            JavaScriptSerializer Sc = new JavaScriptSerializer();
            List<ResultJason> Objeto = (List<ResultJason>)Sc.Deserialize(Cuerpo, typeof(List<ResultJason>));

            //SE muestra el resultado del Json
            DataTable DataT = new DataTable();
            DataColumn Columna;
            DataRow Fila;


            //Se crea una nueva columna
            Columna = new DataColumn();
            Columna.DataType = System.Type.GetType("System.String");
            Columna.ColumnName = "Departamento";
            DataT.Columns.Add(Columna);
            //Se crea otra columna
            DataColumn Columna2 = new DataColumn();
            Columna2.DataType = System.Type.GetType("System.String");
            Columna2.ColumnName = "Municipio";
            DataT.Columns.Add(Columna2);

            //Se crea otra columna
            DataColumn Columna3 = new DataColumn();
            Columna3.DataType = System.Type.GetType("System.String");
            Columna3.ColumnName = "Centro_Votacion";
            DataT.Columns.Add(Columna3);

            //Se crea otra columna
            DataColumn Columna4 = new DataColumn();
            Columna4.DataType = System.Type.GetType("System.String");
            Columna4.ColumnName = "Direccion";
            DataT.Columns.Add(Columna4);

            //Se crea otra columna
            DataColumn Columna5 = new DataColumn();
            Columna5.DataType = System.Type.GetType("System.String");
            Columna5.ColumnName = "Mesa";
            DataT.Columns.Add(Columna5);

            //Se crea otra columna
            DataColumn Columna6 = new DataColumn();
            Columna6.DataType = System.Type.GetType("System.String");
            Columna6.ColumnName = "Linea";
            DataT.Columns.Add(Columna6);

            foreach (ResultJason Ob in Objeto)
            {
                Fila = DataT.NewRow();
                Fila["Departamento"] = Ob.CodigoDepartamento;
                Fila["Municipio"] = Ob.CodigoMunicipio;
                Fila["Centro_Votacion"] = Ob.CodigoCentroVotacion;
                Fila["Direccion"] = Ob.Direccion;
                Fila["Mesa"] = Ob.NumeroMesa;
                Fila["Linea"] = Ob.NumeroLinea;
                DataT.Rows.Add(Fila);
            }
            TablaDatos.DataSource = DataT;
            TablaDatos.DataBind();

        }
    }
}