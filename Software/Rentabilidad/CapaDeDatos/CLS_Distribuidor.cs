using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_Distribuidor:ConexionBase
    {
        public string c_codigo_dis { get; set; }
        public string Tipo { get; set; }
        public int Elementos { get; set; }
        public string TextoBusqueda { get; set; }

        public void MtdSeleccionarCodigoNombre()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_distribuidores_CN_Select";
                _dato.CadenaTexto = Tipo;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Tipo");
                _dato.CadenaTexto = TextoBusqueda;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "TextoBusqueda");
                _dato.Entero = Elementos;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Elementos");
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
        public void MtdSeleccionar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_distribuidores_select";
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
    }
}
