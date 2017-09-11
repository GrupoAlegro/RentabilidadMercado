using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Pais:ConexionBase
    {
        public string c_codigo_pai { get; set; }
        public string v_nombre_pai { get; set; }
        public string c_codigo_usu { get; set; }

        public void MtdSeleccionar()
        {


            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_pais_select";

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
                _conexion.NombreProcedimiento = "usp_Rent_pais_CN_select";
                _dato.CadenaTexto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
                _dato.CadenaTexto = v_nombre_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_pai");
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
                _conexion.NombreProcedimiento = "usp_Rent_pais_Delete";

                _dato.CadenaTexto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
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
                _conexion.NombreProcedimiento = "usp_Rent_pais_Insert";

                _dato.CadenaTexto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
                _dato.CadenaTexto = v_nombre_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_pai");
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
                _conexion.NombreProcedimiento = "usp_Rent_pais_Update";

                _dato.CadenaTexto = c_codigo_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pai");
                _dato.CadenaTexto = v_nombre_pai;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_pai");
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
