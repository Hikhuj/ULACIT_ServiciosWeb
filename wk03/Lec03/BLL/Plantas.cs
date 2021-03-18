using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Plantas
    {

        #region properties

        public string _nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int _tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private int _cantidad;

        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        private int _num_error;

        public int num_error
        {
            get { return _num_error; }
            set { _num_error = value; }
        }

        #region variables privadas

        SqlCommand conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #endregion

        #region metodos
        public List<Plantas> cargar_lista_plantas(ref string mensaje_error, ref int numero_error)
        {
            conexion = cls_DAL.trae_conexion("ServiciosWeb", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                // El string que le quiero pasar
                sql = "usp_trae_lista_plantas";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return;
                }
                else
                {
                    return procesarDataTable(ds.Tables[0]);
                }
            }
        }

        private List<Plantas> procesarDataTable(DataTable dt)
        {
            return (
                    from dr in dt.Rows
                    select new Plantas()
                    {
                        codigo = Convert.ToInt32(dr["cod_planta"]),
                        nombre = dr["nombre_planta"].ToString(),
                        cantidad = Convert.ToInt32(dr["cantidad"])
                    });
        }

        **** PERDIO EN LA CLASE AL TIEMPO 1:50:00

        #endregion
    }
}
