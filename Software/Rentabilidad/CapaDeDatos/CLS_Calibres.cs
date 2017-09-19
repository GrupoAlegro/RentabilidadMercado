using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Calibres:ConexionBase
    {
        public string c_codigo_cal { get; set; }
        public string v_nombre_cal { get; set; }
        public string c_codigo_pai { get; set; }
        public string c_codigo_cat { get; set; }
        public string c_codigo_tra { get; set; }
        public decimal n_gramaje_desde { get; set; }
        public decimal n_gramaje_hasta { get; set; }
        public string c_codigo_usu { get; set; }

        public void MtdSeleccionar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_Calibres_Select";

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
                _conexion.NombreProcedimiento = "usp_Rent_t_Calibres_CN_Select";
                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
                _dato.CadenaTexto = v_nombre_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_cal");
                _dato.CadenaTexto = c_codigo_cat;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cat");
                _dato.CadenaTexto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
                _dato.CadenaTexto = c_codigo_tra;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tra");

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
        public void MtdEliminar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_Calibres_Delete";

                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
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
        public void MtdInsertar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_Calibres_Insert";

                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
                _dato.CadenaTexto = v_nombre_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_cal");
                _dato.CadenaTexto = c_codigo_cat;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cat");
                _dato.CadenaTexto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
                _dato.CadenaTexto = c_codigo_tra;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tra");
                _dato.DecimalValor = n_gramaje_desde;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "n_gramaje_desde");
                _dato.DecimalValor = n_gramaje_hasta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "n_gramaje_hasta");
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
        public void MtdActualizar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_categorias_Update";

                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
                _dato.CadenaTexto = v_nombre_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_cal");
                _dato.CadenaTexto = c_codigo_cat;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cat");
                _dato.CadenaTexto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
                _dato.CadenaTexto = c_codigo_tra;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tra");
                _dato.DecimalValor = n_gramaje_desde;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "n_gramaje_desde");
                _dato.DecimalValor = n_gramaje_hasta;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "n_gramaje_hasta");
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
