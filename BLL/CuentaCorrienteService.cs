using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class CuentaCorrienteService:CuentaService
    {
        CuentaService cuentaService;
        Cuenta nuevaCuenta = new Cuenta();

        public CuentaCorrienteService()
        {
            cuentaService = new CuentaService();
        }
        public void ConsignarCuentaCorriente(Cuenta cuenta, decimal valor)
        {
            if (valor <= cuenta.Deuda)
            {
                cuenta.Deuda -= valor;
                cuenta.Saldo += valor;
                ModificarCuenta(cuenta);

                Movimiento movimiento = new Movimiento();
                movimiento.NumeroCuenta = cuenta.NumeroCuenta;
                movimiento.Cliente = cuenta.Cliente;
                movimiento.FechaApertura = DateTime.Now;
                movimiento.Saldo = cuenta.Saldo;
                movimiento.TipoMovimiento = "Consignar";
                movimiento.TipoCuenta = cuenta.TipoCuenta;
                
                cuentaService.GuardarMovimiento(movimiento);
                Console.WriteLine("CONSIGNACION REALIZADO CON EXITO");


            }
            else
            {
                Console.WriteLine("No se ha podido realizar la operación");
            }
        }

        public void RetirarCuentaCorriente(Cuenta cuenta, decimal valor)
        {
            if (valor <= cuenta.Saldo)
            {
                cuenta.Deuda += valor;
                cuenta.Saldo -= valor;
                ModificarCuenta(cuenta);

                Movimiento movimiento = new Movimiento();
                movimiento.NumeroCuenta = cuenta.NumeroCuenta;
                movimiento.Cliente = cuenta.Cliente;
                movimiento.FechaApertura = DateTime.Now;
                movimiento.Saldo = cuenta.Saldo;
                movimiento.TipoMovimiento = "Reirar";
                movimiento.TipoCuenta = cuenta.TipoCuenta;

                cuentaService.GuardarMovimiento(movimiento);
                Console.WriteLine("RETIRO REALIZADA CON EXITO");


            }
            else
            {
                Console.WriteLine("No se ha podido realizar la operación");
            }
        }

        private void ModificarCuenta(Cuenta cuenta)
        {
            nuevaCuenta.NumeroCuenta = cuenta.NumeroCuenta;
            nuevaCuenta.Cliente = cuenta.Cliente;
            nuevaCuenta.Saldo = cuenta.Saldo;
            nuevaCuenta.FechaApertura = cuenta.FechaApertura;
            nuevaCuenta.TipoCuenta = cuenta.TipoCuenta;
            nuevaCuenta.Deuda = cuenta.Deuda;
            cuentaService.Modificar(nuevaCuenta);
        }
    }
}
