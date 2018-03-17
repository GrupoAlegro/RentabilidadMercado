using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDeDatos
{
    public class CLS_Folio : ConexionBase
    {
        public string c_codigo_emp { get; set; }
        public string v_nombre_empacador { get; set; }
        public string c_codigo_tem { get; set; }
        public int n_folio_inicio { get; set; }
        public int n_folio_fin { get; set; }
        public int n_etiquetas_restantes { get; set; }
        public string c_codigo_usu { get; set; }
        public int b_folio_cerrado { get; set; }

        public void MtdSeleccionarFolio()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_AsingancionFolio_UltimoFolio_Select";
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
        public void MtdSeleccionar()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_AsignacionFolios_Select";
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
        public void MtdSeleccionarCN()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_AsignacionFoliosCN_Select";
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
        public void MtdSeleccionarTemporada()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_TemporadaActiva_Select";
                
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
                _conexion.NombreProcedimiento = "usp_AsignacionFolios_Insert";
                _dato.CadenaTexto = c_codigo_emp;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_emp");
                _dato.Entero = n_folio_inicio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_folio_inicio");
                _dato.Entero = n_folio_fin;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_folio_fin");
                _dato.Entero = n_etiquetas_restantes;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_etiquetas_restantes");
                _dato.CadenaTexto = c_codigo_usu;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_usu");
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_Codigo_tem");
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
                _conexion.NombreProcedimiento = "usp_AsignacionFolios_Update";
                _dato.CadenaTexto = c_codigo_emp;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_emp");
                _dato.Entero = n_folio_inicio;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_folio_inicio");
                _dato.Entero = n_folio_fin;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_folio_fin");
                _dato.Entero = n_etiquetas_restantes;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "n_etiquetas_restantes");
                _dato.CadenaTexto = c_codigo_usu;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_usu");
                _dato.CadenaTexto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_Codigo_tem");
                _dato.Entero = b_folio_cerrado;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "b_folio_cerrado");
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
