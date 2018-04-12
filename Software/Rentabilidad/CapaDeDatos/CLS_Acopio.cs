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
        public string OrdenCorte { get; set; }
        public string v_nombre_hue { get; set; }
        public decimal? n_cajas_estimadas { get; set; }
        public decimal? n_cajas_recibidas { get; set; }
        public decimal? n_bono_completo { get; set; }
        public decimal? n_importe { get; set; }
        public decimal? n_32_est { get; set; }
        public decimal? n_36_est { get; set; }
        public decimal? n_40_est { get; set; }
        public decimal? n_48_est { get; set; }
        public decimal? n_60_est { get; set; }
        public decimal? n_70_est { get; set; }
        public decimal? n_84_est { get; set; }
        public decimal? n_96_est { get; set; }
        public decimal? n_32_pro { get; set; }
        public decimal? n_36_pro { get; set; }
        public decimal? n_40_pro { get; set; }
        public decimal? n_48_pro { get; set; }
        public decimal? n_60_pro { get; set; }
        public decimal? n_70_pro { get; set; }
        public decimal? n_84_pro { get; set; }
        public decimal? n_96_pro { get; set; }
        public decimal? n_cat1_est { get; set; }
        public decimal? n_cat2_est { get; set; }
        public decimal? n_Nac_est { get; set; }
        public decimal? n_cat1_pro { get; set; }
        public decimal? n_cat2_pro { get; set; }
        public decimal? n_Nac_pro { get; set; }
        public decimal n_porcentajeVolumen { get; set; }
        public string d_fecha_OrdenCorte { get; set; }
        public string c_codigo_pcal { get; set; }
        public string v_penalizacion_pcal { get; set; }
        public string c_codigo_pcali { get; set; }
        public string v_penalizacion_pcali { get; set; }

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
        public void MtdSeleccionarCapturasPendientes()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Acp_BonificacionCapturasPendientes_Select";
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
        public void MtdSeleccionarPenalizacionCalidad()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Penalizacion_Calidad_Select";
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
        public void MtdSeleccionarPenalizacionCalibres()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Penalizacion_Calibres_Select";
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
        public void MtdActualizarPenalizacionCalidad()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Penalizacion_Calidad_Update";

                _dato.CadenaTexto = c_codigo_pcal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pcal");
                _dato.CadenaTexto = v_penalizacion_pcal;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_penalizacion_pcal");
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
        public void MtdActualizarPenalizacionCalibres()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Penalizacion_Calibres_Update";

                _dato.CadenaTexto = c_codigo_pcali;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_pcali");
                _dato.CadenaTexto = v_penalizacion_pcali;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_penalizacion_pcali");
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
        public void MtdEliminarBonificaciones()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_Bonificaciones_Delete";
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
        public void MtdInsertarBonificacionVolumen()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_BonificacionVolumen_Insert";

                _dato.CadenaTexto = OrdenCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "OrdenCorte");
                _dato.CadenaTexto = d_fecha_OrdenCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "d_fecha_OrdenCorte");
                _dato.CadenaTexto = Acopiador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Acopiador");
                _dato.CadenaTexto = v_nombre_hue;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_hue");
                _dato.DecimalValor = n_cajas_estimadas;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cajas_estimadas");
                _dato.DecimalValor = n_cajas_recibidas;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cajas_recibidas");
                _dato.DecimalValor = n_porcentaje;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_porcentaje");
                _dato.DecimalValor = n_bono_completo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_bono_completo");
                _dato.DecimalValor = n_importe;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_importe");
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
        public void MtdInsertarBonificacionCalibre()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_BonificacionCalibres_Insert";

                _dato.CadenaTexto = OrdenCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "OrdenCorte");
                _dato.CadenaTexto = d_fecha_OrdenCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "d_fecha_OrdenCorte");
                _dato.CadenaTexto = Acopiador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Acopiador");
                _dato.CadenaTexto = v_nombre_hue;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_hue");
                _dato.DecimalValor = n_cajas_estimadas;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cajas_estimadas");
                _dato.DecimalValor = n_32_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_32_est");
                _dato.DecimalValor = n_36_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_36_est");
                _dato.DecimalValor = n_40_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_40_est");
                _dato.DecimalValor = n_48_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_48_est");
                _dato.DecimalValor = n_60_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_60_est");
                _dato.DecimalValor = n_70_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_70_est");
                _dato.DecimalValor = n_84_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_84_est");
                _dato.DecimalValor = n_96_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_96_est");
                _dato.DecimalValor = n_32_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_32_pro");
                _dato.DecimalValor = n_36_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_36_pro");
                _dato.DecimalValor = n_40_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_40_pro");
                _dato.DecimalValor = n_48_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_48_pro");
                _dato.DecimalValor = n_60_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_60_pro");
                _dato.DecimalValor = n_70_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_70_pro");
                _dato.DecimalValor = n_84_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_84_pro");
                _dato.DecimalValor = n_96_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_96_pro");
                _dato.DecimalValor = n_porcentaje;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_porcentaje");
                _dato.DecimalValor = n_porcentajeVolumen;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_porcentajeVolumen");
                _dato.DecimalValor = n_bono_completo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_bono_completo");
                _dato.DecimalValor = n_importe;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_importe");
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
        public void MtdInsertarBonificacionCalidad()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_BonificacionCalidad_Insert";
                _dato.CadenaTexto = OrdenCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "OrdenCorte");
                _dato.CadenaTexto = d_fecha_OrdenCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "d_fecha_OrdenCorte");
                _dato.CadenaTexto = Acopiador;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Acopiador");
                _dato.CadenaTexto = v_nombre_hue;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_nombre_hue");
                _dato.DecimalValor = n_cajas_estimadas;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cajas_estimadas");
                _dato.DecimalValor = n_cat1_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cat1_est");
                _dato.DecimalValor = n_cat2_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cat2_est");
                _dato.DecimalValor = n_Nac_est;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_Nac_est");
                _dato.DecimalValor = n_cat1_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cat1_pro");
                _dato.DecimalValor = n_cat2_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_cat2_pro");
                _dato.DecimalValor = n_Nac_pro;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_Nac_pro");
                _dato.DecimalValor = n_porcentaje;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_porcentaje");
                _dato.DecimalValor = n_porcentajeVolumen;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_porcentajeVolumen");
                _dato.DecimalValor = n_bono_completo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_bono_completo");
                _dato.DecimalValor = n_importe;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "n_importe");
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
        public void MtdSeleccionarPagoCamionBono()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Acp_MontoCamion_Select";
                _dato.CadenaTexto = v_tipo_camion;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "v_tipo_camion");
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
        public void MtdSeleccionarGrupoPagoBono()
        {
            TipoDato _dato = new TipoDato();
            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "usp_Rent_Acp_PorcentajeGrupo_Select";
                _dato.CadenaTexto = c_codigo_gru;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "c_codigo_gru");
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
