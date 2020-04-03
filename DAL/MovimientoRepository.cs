using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class MovimientoRepository
    {
        string ruta = @"Movimiento.txt";
        List<Movimiento> movimientos = new List<Movimiento>();

        public void Guardar(Movimiento movimiento)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(fileStream);
            escritor.WriteLine(movimiento.ToString());
            escritor.Close();
            fileStream.Close();
        }
        public List<Movimiento> Consultar()
        {
            movimientos.Clear();
            
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(fileStream);

            string linea = string.Empty;
            while ((linea = lector.ReadLine()) != null)
            {
                Movimiento movimiento = MapearMovimiento(linea);
                movimientos.Add(movimiento);

            }
            fileStream.Close();
            lector.Close(); 
            return movimientos;
        }

        private static Movimiento MapearMovimiento(string linea)
        {
            Movimiento movimiento = new Movimiento();
            string[] matrizmovimiento = linea.Split(';');
            movimiento.NumeroCuenta = matrizmovimiento[0];
            movimiento.Cliente = matrizmovimiento[1];
            movimiento.FechaApertura = DateTime.Parse(matrizmovimiento[2]);
            movimiento.TipoMovimiento = matrizmovimiento[3];
            movimiento.TipoCuenta = matrizmovimiento[4];
            movimiento.Saldo = int.Parse(matrizmovimiento[5]);
            movimiento.Deuda = int.Parse(matrizmovimiento[6]);
            return movimiento;
        }

        public List<Movimiento> Buscar(string numeroCuenta)
        {
            
            
            movimientos.Clear();
            List<Movimiento> movimientosCuenta = new List<Movimiento>();
            movimientos = Consultar();
            foreach (var item in movimientos)
            {
                if (item.NumeroCuenta.Equals(numeroCuenta))
                {
                    movimientosCuenta.Add(item);
                    
                }
                
            }
            return movimientosCuenta;
        }
        public void EliminarMovimientos(Movimiento movimiento)
        {
            movimientos.Clear();
            movimientos = Consultar();
            FileStream filestream = new FileStream(ruta,FileMode.Create);
            filestream.Close();
            foreach (var item in movimientos)
            {
                if(item.NumeroCuenta != movimiento.NumeroCuenta)
                {
                    Guardar(item);
                }
            }

        }
        public Movimiento RetornoMovimiento(List<Movimiento> listaMovimientos)
        {
            
            

            for (int i = 0; i < listaMovimientos.Count; i++)
            {
                return listaMovimientos[i];
            }
            return null;
        }
    }
}
