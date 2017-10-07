using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Precios_Fechas : ConexionBase
    {
        public int c_codigo_pre { get; set; }
        public string c_codigo_cal { get; set; }
        public string c_codigo_dis { get; set; }
        public string d_fecha_pre { get; set; }
        public decimal n_preciobanda_pre { get; set; }
        public decimal n_precioventa_pre { get; set; }
        public string c_codigo_usu { get; set; }

        
        public void MtdSeleccionar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_PreciosFecha_select";
                _dato.CadenaTexto = d_fecha_pre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "d_fecha_pre");
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
                _conexion.NombreProcedimiento = "usp_Rent_t_PreciosFecha_CN_select";
                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
                _dato.CadenaTexto = c_codigo_dis;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_dis");
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
        public void MtdSeleccionarCalDisFecha()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_PreciosFecha_CDF_select";
                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
                _dato.CadenaTexto = c_codigo_dis;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_dis");
                _dato.CadenaTexto = d_fecha_pre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "d_fecha_pre");
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
                _conexion.NombreProcedimiento = "usp_Rent_t_PreciosFecha_Delete";

                //_dato.CadenaTexto = c_codigo_pai;
                //_conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
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
                _conexion.NombreProcedimiento = "usp_Rent_t_PreciosFecha_Insert";
                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
                _dato.CadenaTexto = c_codigo_dis;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_dis");
                _dato.CadenaTexto = d_fecha_pre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "d_fecha_pre");
                _dato.DecimalValor= n_preciobanda_pre;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_preciobanda_pre");
                _dato.DecimalValor = n_precioventa_pre;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_precioventa_pre");
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
                _conexion.NombreProcedimiento = "usp_Rent_t_PreciosFecha_Update";
                _dato.Entero = c_codigo_pre;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "c_codigo_pre");
                _dato.CadenaTexto = c_codigo_cal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_cal");
                _dato.CadenaTexto = c_codigo_dis;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_dis");
                _dato.CadenaTexto = d_fecha_pre;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "d_fecha_pre");
                _dato.DecimalValor = n_preciobanda_pre;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_preciobanda_pre");
                _dato.DecimalValor = n_precioventa_pre;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_precioventa_pre");
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
