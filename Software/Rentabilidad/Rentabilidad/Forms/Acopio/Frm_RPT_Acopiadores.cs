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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Rentabilidad
{
    public partial class Frm_RPT_Acopiadores : DevExpress.XtraEditors.XtraForm
    {
        ConnectionInfo oConexInfo = new ConnectionInfo();
        const string NombreProyecto = "Agro_IntelliTrace";
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
                        InsertarBonificacionCalidad(cortesel.Datos);
                        InsertarBonificacionCalibre(cortesel.Datos);
                        MostrarReporte();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccione un Acopiador");
            }
        }

        private void MostrarReporte()
        {
            Parametros_basededatos();
            Reports.rpt_Bonificacion_Acopiadores_Detallado RCatalogoP = new Reports.rpt_Bonificacion_Acopiadores_Detallado();
            Tables RPTTablas = RCatalogoP.Database.Tables;

            foreach (Table oTabla in RPTTablas)
            {
                TableLogOnInfo oTablaConexInfo = oTabla.LogOnInfo;
                oTablaConexInfo.ConnectionInfo = oConexInfo;
                oTabla.ApplyLogOnInfo(oTablaConexInfo);
            }
            RCatalogoP.Refresh();
            RPT_Viewer.ReportSource = RCatalogoP;
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
        private void Parametros_basededatos()
        {
            MSRegistro RegOut = new MSRegistro();
            Crypto DesencriptarTexto = new Crypto();
            string ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "Server"));
            string ValDB = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBase"));
            string ValLogin = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "User"));
            string ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "Password"));

            oConexInfo.ServerName = ValServer;
            oConexInfo.DatabaseName = ValDB;
            oConexInfo.UserID = ValLogin;
            oConexInfo.Password = ValPass;
        }

        private void InsertarBonificacionCalibre(DataTable datos)
        {
            string vOrdenCorte = string.Empty;
            string vAcopiador = string.Empty;
            string vv_nombre_hue = string.Empty;
            decimal vn_cajas_estimadas = 0;
            decimal vn_cajas_recibidas = 0;
            decimal vn_porcentaje = 0;
            decimal vn_porcentajeVolumen = 0;
            decimal vn_bono_completo = 0;
            decimal vn_importe = 0;

            decimal vn_32_est = 0;
            decimal vn_36_est = 0;
            decimal vn_40_est = 0;
            decimal vn_48_est = 0;
            decimal vn_60_est = 0;
            decimal vn_70_est = 0;
            decimal vn_84_est = 0;
            decimal vn_96_est = 0;

            decimal vn_32_pro = 0;
            decimal vn_36_pro = 0;
            decimal vn_40_pro = 0;
            decimal vn_48_pro = 0;
            decimal vn_60_pro = 0;
            decimal vn_70_pro = 0;
            decimal vn_84_pro = 0;
            decimal vn_96_pro = 0;

            decimal vn_porcentaje32 = 0;
            decimal vn_porcentaje36 = 0;
            decimal vn_porcentaje40 = 0;
            decimal vn_porcentaje48 = 0;
            decimal vn_porcentaje60 = 0;
            decimal vn_porcentaje70 = 0;
            decimal vn_porcentaje84 = 0;
            decimal vn_porcentaje96 = 0;

            decimal vn_porcentajeGrupo = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                vOrdenCorte = datos.Rows[i]["OrderCorte"].ToString();
                vAcopiador = datos.Rows[i]["Acopiador"].ToString();
                vv_nombre_hue = datos.Rows[i]["Huerta"].ToString();
                vn_cajas_estimadas = Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString());
                vn_cajas_recibidas = Convert.ToDecimal(datos.Rows[i]["RecibCajas"].ToString());

                vn_32_est = Convert.ToDecimal(datos.Rows[i]["Est32"].ToString());
                vn_36_est = Convert.ToDecimal(datos.Rows[i]["Est36"].ToString());
                vn_40_est = Convert.ToDecimal(datos.Rows[i]["Est40"].ToString());
                vn_48_est = Convert.ToDecimal(datos.Rows[i]["Est48"].ToString());
                vn_60_est = Convert.ToDecimal(datos.Rows[i]["Est60"].ToString());
                vn_70_est = Convert.ToDecimal(datos.Rows[i]["Est70"].ToString());
                vn_84_est = Convert.ToDecimal(datos.Rows[i]["Est84"].ToString());
                vn_96_est = Convert.ToDecimal(datos.Rows[i]["Est96"].ToString());

                vn_32_pro = Convert.ToDecimal(datos.Rows[i]["Pro32"].ToString());
                vn_36_pro = Convert.ToDecimal(datos.Rows[i]["Pro36"].ToString());
                vn_40_pro = Convert.ToDecimal(datos.Rows[i]["Pro40"].ToString());
                vn_48_pro = Convert.ToDecimal(datos.Rows[i]["Pro48"].ToString());
                vn_60_pro = Convert.ToDecimal(datos.Rows[i]["Pro60"].ToString());
                vn_70_pro = Convert.ToDecimal(datos.Rows[i]["Pro70"].ToString());
                vn_84_pro = Convert.ToDecimal(datos.Rows[i]["Pro84"].ToString());
                vn_96_pro = Convert.ToDecimal(datos.Rows[i]["Pro96"].ToString());

                if (Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()) > 0)
                {
                    vn_porcentajeVolumen = Convert.ToDecimal(datos.Rows[i]["RecibCajas"].ToString()) / Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString())*100;
                    if ((vn_porcentajeVolumen) >= 50)
                    {
                        if (Convert.ToDecimal(datos.Rows[i]["Est32"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["Pro32"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est32"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est32"].ToString()) / 100) > 0)
                            {
                                vn_porcentaje32 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["Pro32"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est32"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est32"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentaje32 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentaje32 = 0;
                        }

                        if (Convert.ToDecimal(datos.Rows[i]["Est36"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["Pro36"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est36"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est36"].ToString()) / 100) > 0)
                            {
                                vn_porcentaje36 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["Pro36"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est36"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est36"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentaje36 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentaje36 = 0;
                        }

                        if (Convert.ToDecimal(datos.Rows[i]["Est40"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["Pro40"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est40"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est40"].ToString()) / 100) > 0)
                            {
                                vn_porcentaje40 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["Pro40"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est40"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est40"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentaje40 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentaje40 = 0;
                        }

                        if (Convert.ToDecimal(datos.Rows[i]["Est48"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["Pro48"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est48"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est48"].ToString()) / 100) > 0)
                            {
                                vn_porcentaje48 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["Pro48"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est48"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est48"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentaje48 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentaje48 = 0;
                        }

                        if (Convert.ToDecimal(datos.Rows[i]["Est60"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["Pro60"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est60"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est60"].ToString()) / 100) > 0)
                            {
                                vn_porcentaje60 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["Pro60"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est60"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est60"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentaje60 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentaje60 = 0;
                        }

                        if (Convert.ToDecimal(datos.Rows[i]["Est84"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["Pro84"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est84"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est84"].ToString()) / 100) > 0)
                            {
                                vn_porcentaje84 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["Pro84"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est84"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est84"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentaje84 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentaje84 = 0;
                        }

                        if (Convert.ToDecimal(datos.Rows[i]["Est96"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["Pro96"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est96"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est96"].ToString()) / 100) > 0)
                            {
                                vn_porcentaje96 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["Pro96"].ToString()) / Convert.ToDecimal(datos.Rows[i]["Est96"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["Est96"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentaje96 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentaje96 = 0;
                        }

                        vn_porcentaje = vn_porcentaje32 + vn_porcentaje36 + vn_porcentaje40 + vn_porcentaje48 + vn_porcentaje60 + vn_porcentaje70 + vn_porcentaje84 + vn_porcentaje96;

                        if (vn_porcentaje <= 20)
                        {
                            vn_porcentajeGrupo = PorcentajeGrupo("03");
                            vn_bono_completo = MontoCompletoCamion(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()));
                            vn_importe = (vn_bono_completo * vn_porcentajeGrupo) * (100 - (vn_porcentaje * 4)) / 100;
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
                }
                else
                {
                    vn_bono_completo = MontoCompletoCamion(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()));
                    vn_importe = 0;
                }
                try
                {
                     CLS_Acopio insCalibre = new CLS_Acopio();
                    insCalibre.OrdenCorte = vOrdenCorte;
                    insCalibre.Acopiador = vAcopiador;
                    insCalibre.v_nombre_hue = vv_nombre_hue;
                    insCalibre.n_cajas_estimadas = vn_cajas_estimadas;
                    insCalibre.n_32_est = vn_32_est;
                    insCalibre.n_36_est = vn_36_est;
                    insCalibre.n_40_est = vn_40_est;
                    insCalibre.n_48_est = vn_48_est;
                    insCalibre.n_60_est = vn_60_est;
                    insCalibre.n_70_est = vn_70_est;
                    insCalibre.n_84_est = vn_84_est;
                    insCalibre.n_96_est = vn_96_est;
                    insCalibre.n_32_pro = vn_32_pro;
                    insCalibre.n_36_pro = vn_36_pro;
                    insCalibre.n_40_pro = vn_40_pro;
                    insCalibre.n_48_pro = vn_48_pro;
                    insCalibre.n_60_pro = vn_60_pro;
                    insCalibre.n_70_pro = vn_70_pro;
                    insCalibre.n_84_pro = vn_84_pro;
                    insCalibre.n_96_pro = vn_96_pro;
                    insCalibre.n_porcentaje = vn_porcentaje;
                    insCalibre.n_porcentajeVolumen = vn_porcentajeVolumen;
                    insCalibre.n_bono_completo = vn_bono_completo;
                    insCalibre.n_importe = vn_importe;
                    insCalibre.MtdInsertarBonificacionCalibre();
                    if (!insCalibre.Exito)
                    {
                        XtraMessageBox.Show(insCalibre.Mensaje);
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertarBonificacionCalidad(DataTable datos)
        {
            string vOrdenCorte = string.Empty;
            string vAcopiador = string.Empty;
            string vv_nombre_hue = string.Empty;
            decimal vn_cajas_estimadas = 0;
            decimal vn_cajas_recibidas = 0;
            decimal vn_porcentaje = 0;
            decimal vn_porcentajeVolumen = 0;
            decimal vn_bono_completo = 0;
            decimal vn_importe = 0;
            decimal vn_cat1_est = 0;
            decimal vn_cat2_est = 0;
            decimal vn_Nac_est = 0;
            decimal vn_cat1_pro = 0;
            decimal vn_cat2_pro = 0;
            decimal vn_Nac_pro = 0;
            decimal vn_porcentajeCat1 = 0;
            decimal vn_porcentajeCat2 = 0;
            decimal vn_porcentajeNal = 0;
            decimal vn_porcentajeGrupo = 0;

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                vOrdenCorte = datos.Rows[i]["OrderCorte"].ToString();
                vAcopiador = datos.Rows[i]["Acopiador"].ToString();
                vv_nombre_hue = datos.Rows[i]["Huerta"].ToString();
                vn_cajas_estimadas = Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString());
                vn_cajas_recibidas = Convert.ToDecimal(datos.Rows[i]["RecibCajas"].ToString());
                vn_cat1_est = Convert.ToDecimal(datos.Rows[i]["EstCat1"].ToString());
                vn_cat2_est = Convert.ToDecimal(datos.Rows[i]["EstCat2"].ToString());
                vn_Nac_est = Convert.ToDecimal(datos.Rows[i]["EstNal"].ToString());
                vn_cat1_pro = Convert.ToDecimal(datos.Rows[i]["ProCat1"].ToString());
                vn_cat2_pro = Convert.ToDecimal(datos.Rows[i]["ProCat2"].ToString());
                vn_Nac_pro = Convert.ToDecimal(datos.Rows[i]["ProNal"].ToString());
                if (Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()) > 0)
                {
                    vn_porcentajeVolumen = Convert.ToDecimal(datos.Rows[i]["RecibCajas"].ToString()) / Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString())*100;
                    if ((vn_porcentajeVolumen) >= 50)
                    {
                        if (Convert.ToDecimal(datos.Rows[i]["EstCat1"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["ProCat1"].ToString()) / Convert.ToDecimal(datos.Rows[i]["EstCat1"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["EstCat1"].ToString()) / 100) > 0)
                            {
                                vn_porcentajeCat1 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["ProCat1"].ToString()) / Convert.ToDecimal(datos.Rows[i]["EstCat1"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["EstCat1"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentajeCat1 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentajeCat1 = 0;
                        }
                        if (Convert.ToDecimal(datos.Rows[i]["EstCat2"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["ProCat2"].ToString()) / Convert.ToDecimal(datos.Rows[i]["EstCat2"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["EstCat2"].ToString()) / 100) > 0)
                            {
                                vn_porcentajeCat2 = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["ProCat2"].ToString()) / Convert.ToDecimal(datos.Rows[i]["EstCat2"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["EstCat2"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentajeCat2 = 0;
                            }
                        }
                        else
                        {
                            vn_porcentajeCat2 = 0;
                        }
                        if (Convert.ToDecimal(datos.Rows[i]["EstNal"].ToString()) > 0)
                        {
                            if ((100 - (((Convert.ToDecimal(datos.Rows[i]["ProNal"].ToString()) / Convert.ToDecimal(datos.Rows[i]["EstNal"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["EstNal"].ToString()) / 100) > 0)
                            {
                                vn_porcentajeNal = Math.Abs(100 - (((Convert.ToDecimal(datos.Rows[i]["ProNal"].ToString()) / Convert.ToDecimal(datos.Rows[i]["EstNal"].ToString())) * 100))) * (Convert.ToDecimal(datos.Rows[i]["EstNal"].ToString()) / 100);
                            }
                            else
                            {
                                vn_porcentajeNal = 0;
                            }
                        }
                        else
                        {
                            vn_porcentajeNal = 0;
                        }
                        vn_porcentaje = vn_porcentajeCat1 + vn_porcentajeCat2 + vn_porcentajeNal;

                        if (vn_porcentaje <= 10)
                        {
                            vn_porcentajeGrupo = PorcentajeGrupo("02");
                            vn_bono_completo = MontoCompletoCamion(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()));
                            vn_importe = (vn_bono_completo * vn_porcentajeGrupo) * (100 - (vn_porcentaje * 5)) / 100;
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
                }
                else
                {
                    vn_bono_completo = MontoCompletoCamion(Convert.ToDecimal(datos.Rows[i]["n_cajas_pcd"].ToString()));
                    vn_importe = 0;
                }
                try
                {
                    CLS_Acopio insCalibre = new CLS_Acopio();
                    insCalibre.OrdenCorte = vOrdenCorte;
                    insCalibre.Acopiador = vAcopiador;
                    insCalibre.v_nombre_hue = vv_nombre_hue;
                    insCalibre.n_cajas_estimadas = vn_cajas_estimadas;
                    insCalibre.n_cat1_est = vn_cat1_est;
                    insCalibre.n_cat2_est = vn_cat2_est;
                    insCalibre.n_Nac_est = vn_Nac_est;
                    insCalibre.n_cat1_pro = vn_cat1_pro;
                    insCalibre.n_cat2_pro = vn_cat2_pro;
                    insCalibre.n_Nac_pro = vn_Nac_pro;
                    insCalibre.n_porcentaje = vn_porcentaje;
                    insCalibre.n_porcentajeVolumen = vn_porcentajeVolumen;
                    insCalibre.n_bono_completo = vn_bono_completo;
                    insCalibre.n_importe = vn_importe;
                    insCalibre.MtdInsertarBonificacionCalidad();
                    if (!insCalibre.Exito)
                    {
                        XtraMessageBox.Show(insCalibre.Mensaje);
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }
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