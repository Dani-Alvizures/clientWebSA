using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteSOA.Objetos
{
    public class ConsultaMesaa
    {
        private string NumeroEmpadronamiento;
        private string NumeroMesa;
        private string Opcion;

        public ConsultaMesaa(string numeroEm, string NumeroMes, string Op)
        {
            this.NumeroEmpadronamiento = numeroEm;
            this.NumeroMesa = NumeroMes;
            this.Opcion = Op;
        }
    }
}