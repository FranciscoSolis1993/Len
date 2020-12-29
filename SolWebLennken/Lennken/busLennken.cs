using Lennken.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Lennken
{
    public class busLennken
    {
        public List<Producto> Obtener()
        {
            DatLennken datos = new DatLennken();
            List<Producto> ls = new List<Producto>();
            DataTable dt = datos.Obtener();
            foreach (DataRow dr in dt.Rows)
            {
                Producto dir = new Producto();
                dir.Name= dr["Nombre"].ToString();
                dir.Price=Convert.ToDecimal(dr["Price"]);
                dir.Creation=Convert.ToDateTime(dr["Creation"]);
                dir.Modification= Convert.ToDateTime(dr["Modification"]);
                ls.Add(dir);
            }
            return ls;
        }

        public void Agregar(Producto a)
        {
            DatLennken datos = new DatLennken();
            int filas = datos.Agregar(a.Name, a.Price, a.Creation, a.Modification);
            if (filas != 1)
            {
                throw new ApplicationException("Error al agregar");
            }
        }
        public Producto ObtenerProduto(int id)
        {
            DatLennken datobj = new DatLennken();
            DataRow dr = datobj.ObtenerProducto(id);
            Producto dir = new Producto();
            dir.Name = dr["Nombre"].ToString();
            dir.Price = Convert.ToDecimal(dr["Price"]);
            dir.Creation = Convert.ToDateTime(dr["Creation"]);
            dir.Modification = Convert.ToDateTime(dr["Modification"]);
            return dir;
        }

        public void Borrar(int id)
        {
            DatLennken datos = new DatLennken();
            int filas = datos.BorrarElemento(id);
            if (filas != 1)
            {
                throw new ApplicationException("Error al borrar");
            }
        }
        public void Editar(Producto a)
        {
            DatLennken datos = new DatLennken();
            int filas = datos.EditarProducto(a.Name, a.Price, a.Creation, a.Modification);
            if (filas != 1)
            {
                throw new ApplicationException("Error al editar");
            }
        }


    }
}