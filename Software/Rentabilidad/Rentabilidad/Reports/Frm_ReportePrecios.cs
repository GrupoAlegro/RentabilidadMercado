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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CapaDeDatos;

namespace Rentabilidad
{
    public partial class Frm_ReportePrecios : DevExpress.XtraEditors.XtraForm
    {
        public string c_codigo_usu { get; set; }
        ConnectionInfo oConexInfo = new ConnectionInfo();
        const string NombreProyecto = "Agro_IntelliTrace";
        public Frm_ReportePrecios()
        {
            InitializeComponent();
        }

        private static Frm_ReportePrecios m_FormDefInstance;
        public static Frm_ReportePrecios DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_ReportePrecios();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        private void Parametros_basededatos()
        {
            MSRegistro RegOut = new MSRegistro();
            Crypto DesencriptarTexto = new Crypto();
            string valServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "Server"));
            string valDB = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBase"));
            string valLogin = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "User"));
            string valPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "Password"));

            oConexInfo.ServerName = valServer;
            oConexInfo.DatabaseName = valDB;
            oConexInfo.UserID = valLogin;
            oConexInfo.Password = valPass;
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
        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DateTime FechaInicio = Convert.ToDateTime(dtFechaInicio.EditValue.ToString());
            DateTime FechaFin = Convert.ToDateTime(dtFechaFin.EditValue.ToString());
            int result = DateTime.Compare(FechaInicio, FechaFin);
            if (result > 0)
            {
                XtraMessageBox.Show("La fecha de Inicio debe ser menor que la fecha Fin");
            }
            else
            {
                string vd_fecha_preIni = dtFechaInicio.DateTime.Year + DosCeros1(dtFechaInicio.DateTime.Month.ToString()) + DosCeros1(dtFechaInicio.DateTime.Day.ToString());
                string vd_fecha_preFin = dtFechaFin.DateTime.Year + DosCeros1(dtFechaFin.DateTime.Month.ToString()) + DosCeros1(dtFechaFin.DateTime.Day.ToString());
                Parametros_basededatos();
                Reports.rpt_Precios_PaisDistribuidorFecha RCatalogoP = new Reports.rpt_Precios_PaisDistribuidorFecha();
                Tables RPTTablas = RCatalogoP.Database.Tables;

                foreach (Table oTabla in RPTTablas)
                {
                    TableLogOnInfo oTablaConexInfo = oTabla.LogOnInfo;
                    oTablaConexInfo.ConnectionInfo = oConexInfo;
                    oTabla.ApplyLogOnInfo(oTablaConexInfo);
                }
                try
                {
                    RCatalogoP.Refresh();
                    RCatalogoP.DataDefinition.FormulaFields["Fecha_Inicio"].Text = "'"+ DosCeros1(dtFechaInicio.DateTime.Day.ToString()) +"/" + DosCeros1(dtFechaInicio.DateTime.Month.ToString()) +"/"+ +dtFechaInicio.DateTime.Year + "'";
                    RCatalogoP.DataDefinition.FormulaFields["Fecha_Fin"].Text = "'" + DosCeros1(dtFechaFin.DateTime.Day.ToString()) + "/" + DosCeros1(dtFechaFin.DateTime.Month.ToString()) + "/" + +dtFechaFin.DateTime.Year + "'";
                    RCatalogoP.SetParameterValue("@c_codigo_pai", txtCodigoPai.Text);
                    RCatalogoP.SetParameterValue("@c_codigo_dis", txtCodigoDis.Text);
                    RCatalogoP.SetParameterValue("@d_Fecha_preIni", vd_fecha_preIni);
                    RCatalogoP.SetParameterValue("@d_Fecha_preFin", vd_fecha_preFin);

                    CRViewer.ReportSource = RCatalogoP;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Descripcion : " + ex.Message);
                }
            }
        }

        private void btnImpPais_Click(object sender, EventArgs e)
        {
            Frm_Pais aa = new Frm_Pais();
            aa.c_codigo_usu = c_codigo_usu;
            aa.FrmReportePrecios = this;
            aa.Width = 1000;
            aa.MaximizeBox = true;
            aa.MinimizeBox = false;
            aa.Height = 650;
            aa.Top = (Screen.PrimaryScreen.WorkingArea.Height - aa.Height) / 2;
            aa.Left = (Screen.PrimaryScreen.WorkingArea.Width - aa.Width) / 2;
            aa.WindowState = System.Windows.Forms.FormWindowState.Normal;
            aa.ShowDialog();
        }
        public void mtdBuscarPais(string valCodigo, string ValNombre)
        {
            CLS_Pais selpais = new CLS_Pais();
            selpais.c_codigo_pai = valCodigo;
            selpais.v_nombre_pai = ValNombre;
            selpais.MtdSeleccionarCodigoNombre();
            if (selpais.Exito)
            {
                if (selpais.Datos.Rows.Count > 0)
                {
                    txtCodigoPai.Text = selpais.Datos.Rows[0][0].ToString();
                    txtNombrePai.Text = selpais.Datos.Rows[0][1].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(selpais.Mensaje);
            }
        }

        private void btnImpDis_Click(object sender, EventArgs e)
        {
            Frm_BDistribuidores frm = new Frm_BDistribuidores();
            frm.c_codigo_dis = string.Empty;
            frm.v_nombre_dis = string.Empty;
            frm.ShowDialog();
            txtCodigoDis.Text = frm.c_codigo_dis;
            txtNombreDistribuidor.Text = frm.v_nombre_dis;
        }

        private void txtCodigoPai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoPai.Text != string.Empty)
                {
                    mtdBuscarPais(txtCodigoPai.Text, txtNombrePai.Text);
                    txtCodigoDis.Focus();
                }
            }
        }

        private void txtCodigoDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoPai.Text != string.Empty)
                {
                    mtdBuscarDistribuidor(txtCodigoDis.Text);
                }
                dtFechaInicio.Focus();
            }
        }
        public void mtdBuscarDistribuidor(string valCodigo)
        {
            CLS_Distribuidor seldistribuidor = new CLS_Distribuidor();
            seldistribuidor.c_codigo_dis = valCodigo;
            seldistribuidor.MtdSeleccionar();
            if (seldistribuidor.Exito)
            {
                if (seldistribuidor.Datos.Rows.Count > 0)
                {
                    txtCodigoDis.Text = seldistribuidor.Datos.Rows[0][0].ToString();
                    txtNombreDistribuidor.Text = seldistribuidor.Datos.Rows[0][1].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(seldistribuidor.Mensaje);
            }
        }

        private void txtCodigoPai_TextChanged(object sender, EventArgs e)
        {
            txtNombrePai.Text = string.Empty;
        }

        private void txtCodigoDis_TextChanged(object sender, EventArgs e)
        {
            txtNombreDistribuidor.Text = string.Empty;
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Limpiar();
        }

        private void Frm_ReportePrecios_Shown(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodigoPai.Text = string.Empty;
            txtCodigoDis.Text = string.Empty;
            dtFechaInicio.DateTime = DateTime.Now;
            dtFechaFin.DateTime = DateTime.Now;
        }
    }
}