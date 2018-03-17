using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
   public class CLS_Empleado:ConexionBase
    {
        public string c_codigo_emp { get; set; }
        public string v_nombre_empacador { get; set; }
        public string c_codigo_usu { get; set; }

        public void MtdSeleccionar()
        {


            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Empacadores_Select";

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
                _conexion.NombreProcedimiento = "usp_EmpacadoresCodigo_Select";
                _dato.CadenaTexto = c_codigo_emp;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_emp");
                _dato.CadenaTexto = v_nombre_empacador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_empacador");
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
                _conexion.NombreProcedimiento = "usp_Empacadores_Delete";

                _dato.CadenaTexto = c_codigo_emp;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_emp");
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
                _conexion.NombreProcedimiento = "usp_Empacadores_Insert";

                _dato.CadenaTexto = c_codigo_emp;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_emp");
                _dato.CadenaTexto = v_nombre_empacador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_empacador");
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
                _conexion.NombreProcedimiento = "usp_Empacadores_Update";

                _dato.CadenaTexto = c_codigo_emp;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_emp");
                _dato.CadenaTexto = v_nombre_empacador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_empacador");
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
