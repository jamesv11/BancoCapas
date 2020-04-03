using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cuenta
    {
        public Cuenta( )
        {
            
        }


        public string NumeroCuenta { get; set; }
        public string Cliente { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaApertura { get; set; }
        public string TipoCuenta { get; set; }
        public decimal Deuda { get; set; }
        

        public override string ToString()
        {
            return $"{NumeroCuenta};{Cliente};{Saldo};{FechaApertura};{TipoCuenta};{Deuda}";

        }

      
    }
}
