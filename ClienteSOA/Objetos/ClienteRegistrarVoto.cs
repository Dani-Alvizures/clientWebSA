using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace ClienteSOA.Objetos
{
    public class ClienteRegistrarVoto
    {
        private string RutaServicio = "";
        public string DpiRec;
        public string CodigoPar;

        public ClienteRegistrarVoto(string Dpi,string CodioP)
        {
            this.DpiRec = Dpi;
            this.CodigoPar = CodioP;
        }

        public void HacerPeticion()
        {
            
        }

        

    }

    

}