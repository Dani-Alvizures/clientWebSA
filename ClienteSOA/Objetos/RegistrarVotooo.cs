using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteSOA.Objetos
{
    public class RegistrarVotooo
    {
        private string Dpi_Votante;
        private string Codigo_Partido;

        public RegistrarVotooo(string dpiVot, string codPart)
        {
            this.Dpi_Votante = dpiVot;
            this.Codigo_Partido = codPart;
        }
    }
}