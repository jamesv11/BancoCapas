using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;


namespace BLL
{
    public class CuentaService
    {
        CuentaRepository cuentaRepository;
        MovimientoRepository movimientoRepository;
        public CuentaService()
        {
            cuentaRepository = new CuentaRepository();
            movimientoRepository = new MovimientoRepository();
        }

        public string Guardar(Cuenta cuenta)
        {
            try
            {
                if (cuentaRepository.Buscar(cuenta.NumeroCuenta) == null)
                {
                    cuentaRepository.Guardar(cuenta);
                    return $"Se ha guardado la cuenta {cuenta.ToString()}";
                }
                return $"Ya el numero de cuenta: {cuenta.NumeroCuenta} existe";

            }
            catch (Exception e)
            {

                return $"Ha ocurrido un error en los datos {e.Message}";
            }
        }
        public string Consultar(string numeroCuenta)
        {
            List<Movimiento> movimientos = new List<Movimiento>();
            try
            {
                Cuenta cuenta = cuentaRepository.Buscar(numeroCuenta);
                movimientos = movimientoRepository.Buscar(numeroCuenta);
                Console.WriteLine(cuenta.ToString());
                foreach (var item in movimientos)
                {
                    Console.WriteLine(item.ToString());
                }
                return $"Ha sido encontrada correctamente";

            }
            catch (Exception e)
            {

                return $"No ha sido encontrada " + e.Message;
            }
        
        }
        public Cuenta Buscar(string numeroCuenta)
        {
            try
            {
                return cuentaRepository.Buscar(numeroCuenta);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha ocurrido un error en los datos " + e.Message);
                return null;
            }
        }

        public string ConsignarCuenta(Cuenta cuenta,decimal valor)
        {
            try
            {
                if (cuenta.TipoCuenta.Equals("CA"))
                {
                    CuentaAhorroService cuentaAhorroService = new CuentaAhorroService();
                    cuentaAhorroService.ConsignarCuentaAhorro(cuenta, valor);
                    return $"La consignacion ha sido ejecutada con exito{cuenta.ToString()}";
                }
                else
                {
                    CuentaCorrienteService cuentaCorrienteService = new CuentaCorrienteService();
                    cuentaCorrienteService.ConsignarCuentaCorriente(cuenta, valor);
                    return $"La consignacion ha sido ejecutada con exito{cuenta.ToString()}";
                }
            }
            catch (Exception e)
            {

               return $"Ha ocurrido un error en los datos {e.Message}";
            }
           
        }
        public string RetirarCuenta(Cuenta cuenta, decimal valor)
        {
            try
            {
                if (cuenta.TipoCuenta.Equals("CA"))
                {
                    CuentaAhorroService cuentaAhorroService = new CuentaAhorroService();
                    cuentaAhorroService.RetirarCuentaAhorro(cuenta, valor);
                    return $"El retiro ha sido ejecutado con exito{cuenta.ToString()}";
                }
                else
                {
                    CuentaCorrienteService cuentaCorrienteService = new CuentaCorrienteService();
                    cuentaCorrienteService.RetirarCuentaCorriente(cuenta, valor);
                    return $"El retiro ha sido ejecutado con exito{cuenta.ToString()}";
                }
            }
            catch (Exception e)
            {

                return $"Ha ocurrido un error en los datos {e.Message}";
            }

        }
        public string GuardarMovimiento(Movimiento movimiento)
        {
            try
            {
                
                    movimientoRepository.Guardar(movimiento);
                    return $"Se ha guardado la cuenta {movimiento.ToString()}";
                

            }
            catch (Exception e)
            {

                return $"Ha ocurrido un error en los datos {e.Message}";
            }
        }
       
        public string Modificar(Cuenta cuenta)
        {
            try
            {
                if(cuentaRepository.Buscar(cuenta.NumeroCuenta) != null)
                {
                    cuentaRepository.Modificar(cuenta);
                    return "Modificacion realizada con exito";
                }
                return "No se ha podido realizar la modificacion";
            }
            catch (Exception e)
            {

                return "Error de datos" + e.Message;
            }
        }

          public string Eliminar(string numeroCuenta)
        {
            try
            {
                if(cuentaRepository.Buscar(numeroCuenta) != null)
                {
                    cuentaRepository.Eliminar(cuentaRepository.Buscar(numeroCuenta));
                    movimientoRepository.EliminarMovimientos(movimientoRepository.RetornoMovimiento(movimientoRepository.Buscar(numeroCuenta)));
                    return "La cuenta ha sido eliminada con exito";
                }
                return "La cuenta no existe";
            }
            catch (Exception e)
            {

                return "Error de datos" + e.Message;
            }
        }

        }
    }

