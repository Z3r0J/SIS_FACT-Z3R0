using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_FACT_Z3R0.EnviarCorreo
{
    class SoporteCorreos:ServidorDeEmail
    {
        public SoporteCorreos()
        {
            RemitenteEmail = "spz3r0system@gmail.com";
            Password = "SistemaFact123";
            Servidor = "smtp.gmail.com";
            Puerto = 587;
            SSL = true;
            InicializacionServidor();

        }
    }
}
