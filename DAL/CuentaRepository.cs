using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entity;

namespace DAL
{
    public class CuentaRepository
    {
        private String ruta = @"cuenta.txt";
        private List<Cuenta> cuentas = new List<Cuenta>();
        

        public void Guardar(Cuenta cuenta)
        {
            FileStream fileStream = new FileStream(ruta,FileMode.Append);
            StreamWriter escritor = new StreamWriter(fileStream);

            escritor.WriteLine(cuenta.ToString());
           
            escritor.Close();
            fileStream.Close();
        }
        public List<Cuenta> Consultar()
        {
            cuentas.Clear();
            string linea = string.Empty;
            FileStream fileStream = new FileStream(ruta,FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(fileStream);
            while ((linea = lector.ReadLine()) != null)
                {
                Cuenta cuenta = new Cuenta();
                String[] matrizcuentas = linea.Split(';');
                cuenta.NumeroCuenta = matrizcuentas[0];
                cuenta.Cliente = matrizcuentas[1];
                cuenta.Saldo = int.Parse(matrizcuentas[2]);
                cuenta.FechaApertura = DateTime.Parse( matrizcuentas[3]);
                cuenta.TipoCuenta = matrizcuentas[4];
                cuenta.Deuda = int.Parse(matrizcuentas[5]);
                cuentas.Add(cuenta);
                }
            lector.Close();
            fileStream.Close();
            
            return cuentas;

        }

        public Cuenta Buscar(string numeroCuenta)
        {
            cuentas.Clear();
            cuentas = Consultar();
            foreach (var item in cuentas)
            {
                if(item.NumeroCuenta.Equals(numeroCuenta))
                {
                    return item;
                }
               
            }

            return null;
        }
        public void Modificar(Cuenta cuenta)
        {
            cuentas.Clear();
            cuentas = Consultar();
            FileStream fileStream = new FileStream(ruta,FileMode.Create);
            fileStream.Close();
            foreach (var item in cuentas)
            {
                if(item.NumeroCuenta != cuenta.NumeroCuenta)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(cuenta);
                }
            }
        }
        public void Eliminar(Cuenta cuenta)
        {
            cuentas.Clear();
            cuentas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in cuentas)
            {
                if (item.NumeroCuenta != cuenta.NumeroCuenta)
                 {
                    Guardar(item);
                }
            }
        }


    }
}
