using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;


namespace BancoCapas
{
    class Program
    {
        static string numeroCuenta;
        public static int opcion = 0;
        static void Main(string[] args)
        {


            EjecutarOpcionesMenu(MostrarMenu()); 


        }

        public static int MostrarMenu()
        {
            
            Console.WriteLine("Menu:\n 1 - Registrar cuenta \n 2 - Consultar cuenta" +
                " \n 3 - Consignar \n 4 - Retirar \n 5 - Eliminar \n 6 - Modificar \n 7 - salir \n");
            do
            {
                Console.WriteLine("Digite una opcion: ");
                opcion = int.Parse(Console.ReadLine());

            } while (opcion < 1 || opcion > 6);
            return opcion;
        }
        public static void EjecutarOpcionesMenu(int opcion)
        {

            switch (opcion)
            {
                case 1:
                    RegistrarCuenta();
                    break;
                case 2:
                    ConsultarCuenta();
                    break;
                case 3:
                    ConsignarCuenta();
                    break;
                case 4:
                    RetirarCuenta();
                    break;
                case 5:
                    EliminarCuenta();
                    break;
                case 6:
                    ModificarCuenta();
                    break;
                case 7:
                    MostrarMenu();
                    break;

            }
        }
        public static void RegistrarCuenta()
        {
            CuentaAhorroService cuentaAhorroService = new CuentaAhorroService();
            CuentaCorrienteService cuentaCorrienteService = new CuentaCorrienteService();
            string nombre;
            decimal cantidad;
            string numeroCuenta;
            Console.WriteLine("Digite el tiempo de cuenta: \n 1 - Ahorro \n 2 - Corriente");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Digite el numero de cuenta: ");
                    numeroCuenta = Console.ReadLine();
                    Console.WriteLine("Digite su nombre: ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Digite la cantidad inicial de la cuenta: ");
                    cantidad = int.Parse(Console.ReadLine());

                    CuentaAhorro cuentaAhorro = new CuentaAhorro(numeroCuenta, nombre, cantidad);
                    Console.WriteLine(cuentaAhorroService.Guardar(cuentaAhorro)); 
                    break;
                case 2:

                    Console.WriteLine("Digite el numero de cuenta: ");
                    numeroCuenta = Console.ReadLine();
                    Console.WriteLine("Digite su nombre: ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Digite la cantidad inicial de la cuenta: ");
                    cantidad = int.Parse(Console.ReadLine());
                    CuentaCorriente cuentaCorriente = new CuentaCorriente(numeroCuenta, nombre, cantidad);
                    Console.WriteLine(cuentaCorrienteService.Guardar(cuentaCorriente)); 
                    break;

                default: RegistrarCuenta();
                    break;

            }

            EjecutarOpcionesMenu(MostrarMenu());
        }
        public static void ConsignarCuenta()
        {
            CuentaService cuenta = new CuentaService();
            Console.WriteLine("Ingrese el numero de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            Console.WriteLine("Digite el valor a consignar: ");
            decimal valor = int.Parse(Console.ReadLine());
            
            
            if(cuenta.Buscar(numeroCuenta) != null)
            {

                Console.WriteLine(cuenta.ConsignarCuenta(cuenta.Buscar(numeroCuenta), valor)); 
            }
            Console.ReadKey();
            EjecutarOpcionesMenu(MostrarMenu());

        }
        public static void RetirarCuenta()
        {
            CuentaService cuenta = new CuentaService();
            Console.WriteLine("Ingrese el numero de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            Console.WriteLine("Digite el valor a retirar: ");
            decimal valor = int.Parse(Console.ReadLine());


            if (cuenta.Buscar(numeroCuenta) != null)
            {

                Console.WriteLine(cuenta.RetirarCuenta(cuenta.Buscar(numeroCuenta), valor));
            }
            Console.ReadKey();
            EjecutarOpcionesMenu(MostrarMenu());

        }
        public static void ConsultarCuenta()
        {
            CuentaService cuenta = new CuentaService();
            
            Console.WriteLine("Digite el numero de cuenta: ");
            numeroCuenta = Console.ReadLine();
            Console.WriteLine(cuenta.Consultar(numeroCuenta)); 
            EjecutarOpcionesMenu(MostrarMenu());
        }
        public static void EliminarCuenta()
        {
            CuentaService cuenta = new CuentaService();
            Console.WriteLine("ELIMINAR \n");    
            Console.WriteLine("Digite el numero de cuenta: ");
            numeroCuenta = Console.ReadLine();
            Console.WriteLine(cuenta.Eliminar(numeroCuenta));
            EjecutarOpcionesMenu(MostrarMenu());
        }
        public static void ModificarCuenta()
        {
            CuentaService cuenta = new CuentaService();
            Cuenta nuevaCuenta = new Cuenta();
            Console.WriteLine("Digite el numero de cuenta: ");
            numeroCuenta = Console.ReadLine();
            Console.WriteLine(cuenta.Consultar(numeroCuenta));
            var cuentaModificada = cuenta.Buscar(numeroCuenta);
            Console.WriteLine("Digite el nuevo nombre de la cuenta: ");
            string nuevoNombreCuenta = Console.ReadLine();
            CrearNuevaCuenta(cuenta, nuevaCuenta, cuentaModificada, nuevoNombreCuenta);
            EjecutarOpcionesMenu(MostrarMenu());
        }

        private static void CrearNuevaCuenta(CuentaService cuenta, Cuenta nuevaCuenta, Cuenta cuentaModificada, string nuevoNombreCuenta)
        {
            nuevaCuenta.NumeroCuenta = cuentaModificada.NumeroCuenta;
            nuevaCuenta.Cliente = nuevoNombreCuenta;
            nuevaCuenta.Saldo = cuentaModificada.Saldo;
            nuevaCuenta.FechaApertura = cuentaModificada.FechaApertura;
            nuevaCuenta.TipoCuenta = cuentaModificada.TipoCuenta;
            nuevaCuenta.Deuda = cuentaModificada.Deuda;
            cuenta.Modificar(nuevaCuenta);
        }
    }
}
