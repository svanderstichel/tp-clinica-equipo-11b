using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CoberturaNegocio
    {
        public List<Cobertura> ListarPorObraSocial(int idOS)
        {
            List<Cobertura> lista = new List<Cobertura>();
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("SELECT IdCobertura, IdObraSocial, Nombre, Descripcion FROM Cobertura WHERE Estado = 1 AND IdObraSocial = @IdOS");
            datos.setearParametro("@IdOS", idOS);

            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {
                Cobertura c = new Cobertura();
                c.IdCobertura = (int)datos.Lector["IdCobertura"];
                c.IdObraSocial = (int)datos.Lector["IdObraSocial"];
                c.Nombre = datos.Lector["Nombre"].ToString();
                c.Descripcion = datos.Lector["Descripcion"].ToString();
           //     c.Estado = (bool)datos.Lector["Estado"];

                lista.Add(c);
            }

            datos.CerrarConexion();
            return lista;
        }
    }
}

