using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDeDatos
{
    public class CLS_PedidosMedicion:ConexionBase
    {
        public string c_codigo_tem { get; set; }
        public int Week { get; set; }
        public string Year { get; set; }
        public string Acopiador { get; set; }
        public int Tipo_Fecha { get; set; }
        public string Elementos { get; set; }

        public void MtdSeleccionarSemanaActual()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_SemanaActual_Select";
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
        public void MtdSeleccionarTemporadaActual()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_t_temporadaActual_Select";
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
        public void MtdSeleccionarAcopiadores()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_asszona_Select";
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
        public void MtdSeleccionarPorcentajes()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_AcoRecProPorcentaje_Select";
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
                _dato.Entero = Week;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Week");
                _dato.CadenaTexto = Year;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Year");
                _dato.CadenaTexto = Acopiador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Acopiador");
                _dato.Entero = Tipo_Fecha;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Tipo_Fecha");

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
        public void MtdSeleccionarPorcentajesTodos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_AcoRecProPorcentajeTodos_Select";
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
                _dato.Entero = Tipo_Fecha;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Tipo_Fecha");

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
        public void MtdSeleccionarPedidos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Pedidos_Select";
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
        public void MtdSeleccionarEstibas()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_AcoRecProEstibas_Select";
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
                _dato.Entero = Week;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Week");
                _dato.CadenaTexto = Year;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Year");
                _dato.CadenaTexto = Acopiador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Acopiador");
                _dato.Entero = Tipo_Fecha;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Tipo_Fecha");

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
        public void MtdSeleccionarEstibasTodas()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_AcoRecProEstibasTodas_Select";
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
                _dato.Entero = Tipo_Fecha;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Tipo_Fecha");

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
        public void MtdSeleccionarRangoFechas()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_RangoFechasSemana";
                _dato.Entero = Week;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "Week");
                _dato.CadenaTexto = Year;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Year");
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

        //Kilos
        public void MtdSeleccionarKilosProcesados()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_KilosProcesados_Select";
                _dato.CadenaTexto = Elementos;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Elementos");
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
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
        public void MtdSeleccionarKilosPedidos()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_KilosPedidos_Select";
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

        //Precios
        public void MtdSeleccionarPrecioKgBanda()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_PrecioKgBanda";
                _dato.CadenaTexto = Elementos;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Elementos");
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
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
        public void MtdSeleccionarPrecioKgLiquidacion()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_PrecioKgLiquidacion";
                _dato.CadenaTexto = Elementos;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Elementos");
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
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
        public void MtdSeleccionarPrecioKgVenta()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_PrecioKgVenta";
                _dato.CadenaTexto = Elementos;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Elementos");
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_tem");
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
