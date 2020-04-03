using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class CuentaAhorroService:CuentaService
    {
        CuentaService cuentaService;
        Cuenta nuevaCuenta = new Cuenta();

        public CuentaAhorroService()
        {
            cuentaService = new CuentaService();
        }

        public string ConsignarCuentaAhorro(Cuenta cuenta, decimal valor)
        {

            Movimiento movimiento = new Movimiento();
            
            cuenta.Saldo += valor;
            nuevaCuenta.NumeroCuenta = cuenta.NumeroCuenta;
            nuevaCuenta.Cliente = cuenta.Cliente;
            nuevaCuenta.Saldo = cuenta.Saldo;
            nuevaCuenta.FechaApertura = cuenta.FechaApertura;
            nuevaCuenta.TipoCuenta = cuenta.TipoCuenta;
            nuevaCuenta.Deuda = cuenta.Deuda;
            cuentaService.Modificar(nuevaCuenta);
          

            movimiento.NumeroCuenta = cuenta.NumeroCuenta;
            movimiento.Cliente = cuenta.Cliente;
            movimiento.FechaApertura = DateTime.Now;
            movimiento.Saldo = cuenta.Saldo;
            movimiento.TipoMovimiento = "Consignar";
            movimiento.TipoCuenta = cuenta.TipoCuenta;
            cuentaService.GuardarMovimiento(movimiento);
            return $"Ha sido realizado con exito{movimiento.ToString()}";

        }

        public void RetirarCuentaAhorro(Cuenta cuenta, decimal valor)
        {
            if (valor < cuenta.Saldo)
            {
                cuenta.Saldo = cuenta.Saldo - valor;
                nuevaCuenta.NumeroCuenta = cuenta.NumeroCuenta;
                nuevaCuenta.Cliente = cuenta.Cliente;
                nuevaCuenta.Saldo = cuenta.Saldo;
                nuevaCuenta.FechaApertura = cuenta.FechaApertura;
                nuevaCuenta.TipoCuenta = cuenta.TipoCuenta;
                nuevaCuenta.Deuda = cuenta.Deuda;
                cuentaService.Modificar(nuevaCuenta);

                Movimiento movimiento = new Movimiento();
                movimiento.NumeroCuenta = cuenta.NumeroCuenta;
                movimiento.Cliente = cuenta.Cliente;
                movimiento.FechaApertura = DateTime.Now;
                movimiento.Saldo = cuenta.Saldo;
                movimiento.TipoMovimiento = "Retirar";
                movimiento.TipoCuenta = cuenta.TipoCuenta;
                
                cuentaService.GuardarMovimiento(movimiento);
                Console.WriteLine("RETIRO REALIZADA CON EXITO");
            }
            else
            {
                Console.WriteLine("No se ha podido ejecutar la operacion");
            }



        }
    }
}
