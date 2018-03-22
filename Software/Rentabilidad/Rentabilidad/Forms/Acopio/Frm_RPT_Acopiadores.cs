using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaDeDatos;

namespace Rentabilidad
{
    public partial class Frm_RPT_Acopiadores : DevExpress.XtraEditors.XtraForm
    {
        public Frm_RPT_Acopiadores()
        {
            InitializeComponent();
        }
        private static Frm_RPT_Acopiadores m_FormDefInstance;
        private int FilaSelect;

        public static Frm_RPT_Acopiadores DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_RPT_Acopiadores();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public string DosCeros1(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        public string c_codigo_usu { get; internal set; }
        public string Acopiador { get; private set; }
        public string FechaInicio { get; private set; }
        public string FechaFin { get; private set; }

        private void CargarAcopiadores(int? Valor)
        {
            CLS_Acopio bAcpopiadores = new CLS_Acopio();
            bAcpopiadores.MtdSeleccionarAcopiadores();
            if (bAcpopiadores.Exito)
            {
                CargarCombo(bAcpopiadores.Datos, Valor);
            }
        }
        private void CargarCombo(DataTable Datos, int? Valor)
        {
            lkUpAcopiador.Properties.DisplayMember = "c_acopiador_Cal";
            lkUpAcopiador.Properties.ValueMember = "c_codigo_zon";
            lkUpAcopiador.EditValue = Valor;
            lkUpAcopiador.Properties.DataSource = Datos;
        }

        private void Frm_RPT_Acopiadores_Shown(object sender, EventArgs e)
        {
            CargarAcopiadores(null);
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                CLS_Acopio cortesel = new CLS_Acopio();
                if (lkUpAcopiador.EditValue == null)
                {
                    Acopiador = string.Empty;
                }
                else
                {
                    Acopiador = lkUpAcopiador.Text;
                }
                FechaInicio = dtInicio.DateTime.Year + DosCeros1(dtInicio.DateTime.Month.ToString()) + DosCeros1(dtInicio.DateTime.Day.ToString());
                FechaFin = dtFin.DateTime.Year + DosCeros1(dtFin.DateTime.Month.ToString()) + DosCeros1(dtFin.DateTime.Day.ToString());
                cortesel.Acopiador = Acopiador;
                cortesel.FechaInicio = FechaInicio;
                cortesel.FechaFin = FechaFin;
                cortesel.MtdSeleccionarCortesAcopiadores();
                if (cortesel.Exito)
                {
                    if (cortesel.Datos.Rows.Count > 0)
                    {
                        BorrarBonificaciones();
                        InsertarBonificacionVolumen(cortesel.Datos);
                        //InsertarBonificacionCalidad(cortesel.Datos);
                        //InsertarBonificacionCalibre(cortesel.Datos);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccione un Acopiador");
            }
        }

        private bool ValidaDatos()
        {
            bool Valor = true;
            if (chkTodos.Checked == false)
            {
                if (lkUpAcopiador.EditValue != null)
                {
                    Valor = true;
                }
                else
                {
                    Valor = false;
                }
            }
            else
            {
                Valor = true;
            }
            return Valor;
        }

        private void InsertarBonificacionCalibre(DataTable datos)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

            }
        }

        private void InsertarBonificacionCalidad(DataTable datos)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

            }
        }

        private void InsertarBonificacionVolumen(DataTable datos)
        {
            string vOrdenCorte = string.Empty;
            string vAcopiador = string.Empty;
            string vv_nombre_hue = string.Empty;
            decimal vn_cajas_estimadas = 0;
            decimal vn_cajas_recibidas = 0;
            decimal vn_porcentaje = 0;
            decimal vn_bono_completo = 0;
            decimal vn_importe = 0;
            decimal vn_porcentajeGrupo = 0;

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                vOrdenCorte = datos.Rows[i]["OrderCorte"].ToString();
                vAcopiador= datos.Rows[i]["Acopiador"].ToString();
                vv_nombre_hue= datos.Rows[i]["Huerta"].ToString();
                vn_cajas_estimadas = Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString());
                vn_cajas_recibidas = Convert.ToDecimal(datos.Rows[i]["RecibCajas"].ToString());
                if(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString())>0)
                {
                    vn_porcentaje = Convert.ToDecimal(datos.Rows[i]["RecibCajas"].ToString()) / Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString());
                    if ((vn_porcentaje*100) >= 50)
                    {
                        vn_porcentajeGrupo = PorcentajeGrupo("01");
                        vn_bono_completo = MontoCompletoCamion(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()));
                        vn_importe = (vn_bono_completo * vn_porcentajeGrupo) * vn_porcentaje;
                    }
                    else
                    {
                        vn_bono_completo = MontoCompletoCamion(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()));
                        vn_importe = 0;
                    }
                }
                else
                {
                    vn_bono_completo = MontoCompletoCamion(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()));
                    vn_importe = 0;
                }
                try
                {
                    CLS_Acopio insDatos = new CLS_Acopio();
                    insDatos.OrdenCorte = vOrdenCorte;
                    insDatos.Acopiador = vAcopiador;
                    insDatos.v_nombre_hue = vv_nombre_hue;
                    insDatos.n_cajas_estimadas = vn_cajas_estimadas;
                    insDatos.n_cajas_recibidas = vn_cajas_recibidas;
                    insDatos.n_porcentaje = vn_porcentaje;
                    insDatos.n_bono_completo = vn_bono_completo;
                    insDatos.n_importe = vn_importe;
                    insDatos.MtdInsertarBonificacionVolumen();
                    if(!insDatos.Exito)
                    {
                        XtraMessageBox.Show(insDatos.Mensaje);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
                

            }
        }

        private decimal MontoCompletoCamion(decimal v)
        {
            decimal Valor = 0;
            CLS_Acopio selMCompleto = new CLS_Acopio();
            selMCompleto.v_tipo_camion = v.ToString();
            selMCompleto.MtdSeleccionarPagoCamionBono();
            if(selMCompleto.Exito)
            {
                if(selMCompleto.Datos.Rows.Count>0)
                {
                    Valor = Convert.ToDecimal(selMCompleto.Datos.Rows[0]["n_monto_pago"].ToString());
                }
                else
                {
                    Valor = 0;
                }
            }
            else
            {
                XtraMessageBox.Show(selMCompleto.Mensaje);
            }
            return Valor;
        }

        private decimal PorcentajeGrupo(string v)
        {
            decimal Valor = 0;
            CLS_Acopio selGrupo = new CLS_Acopio();
            selGrupo.c_codigo_gru = v.ToString();
            selGrupo.MtdSeleccionarGrupoPagoBono();
            if (selGrupo.Exito)
            {
                if (selGrupo.Datos.Rows.Count > 0)
                {
                    Valor = Convert.ToDecimal(selGrupo.Datos.Rows[0]["n_porcentaje"].ToString());
                }
                else
                {
                    XtraMessageBox.Show("No se encontraron Registro para este Grupo");
                }
            }
            else
            {
                XtraMessageBox.Show(selGrupo.Mensaje);
            }
            return Valor;
        }

        private void BorrarBonificaciones()
        {
            CLS_Acopio boniDel = new CLS_Acopio();
            boniDel.MtdEliminarBonificaciones();
            if(!boniDel.Exito)
            {
                XtraMessageBox.Show(boniDel.Mensaje);
            }
        }

        private void btnBonos_Click(object sender, EventArgs e)
        {
            Frm_BonosAcopio frmb = new Frm_BonosAcopio();
            frmb.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}