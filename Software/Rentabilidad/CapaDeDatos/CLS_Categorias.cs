using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Categorias:ConexionBase
    {
        public string c_codigo_cat { get; set; }
        public string v_nombre_cat { get; set; }
        public string c_codigo_usu { get; set; }


        public void MtdSeleccionar()
        {


            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_categorias_Select";

                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }


        }

        public void MtdSeleccionarCodigoNombre()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_categorias_CN_select";
                _dato.CadenaTexto = c_codigo_cat;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cat");
                _dato.CadenaTexto = v_nombre_cat;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_cat");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }


        }
        public void MtdActualizar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_categorias_Update";

                _dato.CadenaTexto = c_codigo_cat;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cat");
                _dato.CadenaTexto = v_nombre_cat;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_cat");
                _dato.CadenaTexto = c_codigo_usu;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_usu");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }
    }

}
