using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CuentaCorriente : Cuenta
    {  
        public CuentaCorriente(string numeroCuenta, string cliente, decimal saldo)
        {
            NumeroCuenta = numeroCuenta;
            Cliente = cliente;
            FechaApertura = DateTime.Now;
            TipoCuenta = "CC";
            Saldo = saldo;
            Deuda = 0;
            
        }
       
        
    }
}
