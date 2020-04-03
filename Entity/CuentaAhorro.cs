using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CuentaAhorro : Cuenta
    {

        public CuentaAhorro(string numeroCuenta, string cliente, decimal saldo) 
        {
            NumeroCuenta = numeroCuenta;
            Cliente = cliente;        
            FechaApertura = DateTime.Now;
            TipoCuenta = "CA";
            Saldo = saldo;
            Deuda = 0;
        }
        
    }
}
