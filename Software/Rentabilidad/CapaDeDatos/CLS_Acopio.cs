using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDeDatos
{
    public class CLS_Acopio : ConexionBase
    {
        public string Acopiador { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string c_codigo_gru { get; set; }
        public string v_grupopago { get; set; }
        public decimal? n_porcentaje { get; set; }
        public string c_pago_camion { get; set; }
        public decimal? n_porcentaje_pago { get; set; }
        public string v_tipo_camion { get; set; }
        public decimal? n_monto_pago { get; set; }

        public void MtdSeleccionarAcopiadores()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_AcopiadoresSelect";
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
        public void MtdSeleccionarCortesAcopiadores()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_BonoAcopiadores_Select";
                _dato.CadenaTexto = Acopiador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Acopiador");
                _dato.CadenaTexto = FechaInicio;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaInicio");
                _dato.CadenaTexto = FechaFin;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "FechaFin");
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
        public void MtdSeleccionarPagoCamion()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Pago_Camion_Select";
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
        public void MtdSeleccionarGrupoPago()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Grupos_Pago_Select";
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
        public void MtdActualizarGrupoPago()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Grupos_Pago_Update";

                _dato.CadenaTexto = c_codigo_gru;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_gru");
                _dato.CadenaTexto = v_grupopago;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_grupopago");
                _dato.DecimalValor = n_porcentaje;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_porcentaje");
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
        public void MtdActualizarPagoCamion()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Pago_Camion_Update";

                _dato.CadenaTexto = c_pago_camion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_pago_camion");
                _dato.CadenaTexto = v_tipo_camion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_tipo_camion");
                _dato.DecimalValor = n_porcentaje_pago;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_porcentaje_pago");
                _dato.DecimalValor = n_monto_pago;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_monto_pago");
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
