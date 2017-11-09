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

namespace Rentabilidad
{
    public partial class Frm_ReportePrecios : DevExpress.XtraEditors.XtraForm
    {
        ConnectionInfo oConexInfo = new ConnectionInfo();
        const string NombreProyecto = "Agro_IntelliTrace";
        public Frm_ReportePrecios()
        {
            InitializeComponent();
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
    }
}