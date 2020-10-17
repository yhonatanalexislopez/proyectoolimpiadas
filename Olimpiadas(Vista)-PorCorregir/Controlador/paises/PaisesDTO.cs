using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador.paises
{
    public class PaisesDTO
    {
        private byte idpais;
        private string nombrepais;

        public void setIdpais(byte valor) {
            this.idpais = valor;
        }

        public byte getIdpais() {
            return this.idpais;
        }

        public void setNombrepais(string valor) {
            this.nombrepais = valor;
        }

        public string getNombrepais() {
            return this.nombrepais;
        }

    }
}
