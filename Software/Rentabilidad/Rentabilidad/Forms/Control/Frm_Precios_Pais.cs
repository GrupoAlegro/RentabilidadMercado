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
using System.Globalization;

namespace Rentabilidad
{
    public partial class Frm_Precios_Pais : DevExpress.XtraEditors.XtraForm
    {
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");
        int c_codigo_pre = 0;
        public string c_codigo_usu { get; set; }
        private static Frm_Precios_Pais m_FormDefInstance;
        public static Frm_Precios_Pais DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Precios_Pais();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Precios_Pais()
        {
            InitializeComponent();
        }

        private void Frm_Precios_Pais_Shown(object sender, EventArgs e)
        {
            dtFechaInicio.Enabled = false;
            dtFechaFin.Enabled = false;
            dtFechaUnica.Enabled = true;
            rdbFechas.SelectedIndex = 0;
            dtgValPrecios.ExpandAllGroups();
            colPrecioVenta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colPrecioVenta.DisplayFormat.FormatString = "c2";
            colPrecioBanda.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colPrecioBanda.DisplayFormat.FormatString = "c2";
            colGramDesde.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colGramDesde.DisplayFormat.FormatString = "###,###0.000 kg";
            colGramHasta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colGramHasta.DisplayFormat.FormatString = "###,###0.000 kg";
            dtgValPrecios.OptionsBehavior.Editable = true;
            dtgValPrecios.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValPrecios.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            dtFechaInicio.DateTime = DateTime.Now;
            dtFechaFin.DateTime = DateTime.Now;
            dtFechaUnica.DateTime = DateTime.Now;
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCodigoPai.Text = string.Empty;
            txtCodigoDis.Text = string.Empty;
            txtNombreDistribuidor.Text = string.Empty;
            txtNombrePai.Text = string.Empty;
            LimpiarCalibres(txtCodigoPai.Text);
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidaDatos())
            {
                int Cont = 0;
                for (int x = 0; x < dtgValPrecios.DataRowCount; x++)
                {
                    if (rdbFechas.SelectedIndex == 0)
                    {
                        CLS_Precios_Fechas selFecha = new CLS_Precios_Fechas();
                        selFecha.c_codigo_cal = dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["c_codigo_cal"]).ToString();
                        selFecha.c_codigo_dis = txtCodigoDis.Text;
                        DateTime FActual = dtFechaUnica.DateTime;
                        selFecha.d_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                        selFecha.MtdSeleccionarCalDisFecha();
                        if (selFecha.Exito)
                        {
                            int vOpcion = 1;
                            string vc_codigo_cal = dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["c_codigo_cal"]).ToString();
                            string vc_codigo_dis = txtCodigoDis.Text;
                            string vd_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                            decimal vPreciosBanda = 0;
                            Decimal.TryParse(dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["n_preciobanda_pre"]).ToString(), style, culture, out vPreciosBanda);
                            decimal vn_preciobanda_pre = vPreciosBanda;
                            decimal vPreciosEstimado = 0;
                            Decimal.TryParse(dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["n_precioventa_pre"]).ToString(), style, culture, out vPreciosEstimado);
                            decimal vn_precioventa_pre = vPreciosEstimado;
                            string vd_fecha_preIni = string.Empty;
                            string vd_fecha_preFin = string.Empty;
                            string vc_codigo_usu = c_codigo_usu;
                            if (vPreciosBanda > 0 || vPreciosEstimado > 0)
                            {
                                if (selFecha.Datos.Rows.Count == 0)
                                {
                                    if (insertar(vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vn_preciobanda_pre, vn_precioventa_pre, vc_codigo_usu))
                                    {
                                        Cont++;
                                    }
                                }
                                else
                                {
                                    c_codigo_pre = Convert.ToInt32(selFecha.Datos.Rows[0][0].ToString());
                                    if (modificar(c_codigo_pre, vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vn_preciobanda_pre, vn_precioventa_pre, vc_codigo_usu))
                                    {
                                        Cont++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(selFecha.Mensaje);
                        }
                    }
                    else
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
                            string FechaIni = string.Format("{0}-{1}-{2}", dtFechaInicio.DateTime.Year, DosCeros1(dtFechaInicio.DateTime.Month.ToString()), DosCeros1(dtFechaInicio.DateTime.Day.ToString()));
                            string FechaF = string.Format("{0}-{1}-{2}", dtFechaFin.DateTime.Year, DosCeros1(dtFechaFin.DateTime.Month.ToString()), DosCeros1(dtFechaFin.DateTime.Day.ToString()));
                            int vOpcion = 2;
                            List<String> Fechas = new List<string>();
                            Fechas = CrearRangoFecha(FechaIni, FechaF);

                            FechaIni = dtFechaInicio.DateTime.Year + DosCeros1(dtFechaInicio.DateTime.Month.ToString()) + DosCeros1(dtFechaInicio.DateTime.Day.ToString());
                            FechaF = dtFechaFin.DateTime.Year + DosCeros1(dtFechaFin.DateTime.Month.ToString()) + DosCeros1(dtFechaFin.DateTime.Day.ToString());
                            string vc_codigo_cal = dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["c_codigo_cal"]).ToString();
                            string vc_codigo_dis = txtCodigoDis.Text;

                            for (int i = 0; i < Fechas.Count; i++)
                            {
                                CLS_Precios_Fechas selFecha = new CLS_Precios_Fechas();
                                selFecha.c_codigo_cal = dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["c_codigo_cal"]).ToString();
                                selFecha.c_codigo_dis = txtCodigoDis.Text;
                                DateTime FActual = Convert.ToDateTime(Fechas[i]);
                                selFecha.d_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                                selFecha.MtdSeleccionarCalDisFecha();
                                if (selFecha.Exito)
                                {
                                    string vd_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                                    decimal vPreciosBanda = 0;
                                    Decimal.TryParse(dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["n_preciobanda_pre"]).ToString(), style, culture, out vPreciosBanda);
                                    decimal vn_preciobanda_pre = vPreciosBanda;
                                    decimal vPreciosEstimado = 0;
                                    Decimal.TryParse(dtgValPrecios.GetRowCellValue(x, dtgValPrecios.Columns["n_precioventa_pre"]).ToString(), style, culture, out vPreciosEstimado);
                                    decimal vn_precioventa_pre = vPreciosEstimado;
                                    string vc_codigo_usu = c_codigo_usu;
                                    if (vPreciosBanda > 0 || vPreciosEstimado > 0)
                                    {
                                        if (selFecha.Datos.Rows.Count == 0)
                                        {
                                            if (insertar(vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vn_preciobanda_pre, vn_precioventa_pre, vc_codigo_usu))
                                            {
                                                Cont++;
                                            }
                                        }
                                        else
                                        {
                                            c_codigo_pre = Convert.ToInt32(selFecha.Datos.Rows[0][0].ToString());
                                            if (modificar(c_codigo_pre, vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vn_preciobanda_pre, vn_precioventa_pre, vc_codigo_usu))
                                            {
                                                Cont++;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show(selFecha.Mensaje);
                                }
                            }
                        }
                    }
                }
                XtraMessageBox.Show("Se han procesado " + Cont + " Registros");
            }
            else
            {
                XtraMessageBox.Show("Faltan datos por Capturar Pais o Distribuidor");
            }
        }

        
        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
        private void SiguienteFoco(int Actual)
        {
            switch (Actual)
            {
                case 0:
                    txtCodigoPai.Focus();
                    break;
                case 1:
                    txtCodigoDis.Focus();
                    break;
            }
        }
        private void btnImpPais_Click(object sender, EventArgs e)
        {
            Frm_Pais aa = new Frm_Pais();
            aa.c_codigo_usu = c_codigo_usu;
            aa.FrmPreciosPais = this;
            aa.Width = 1000;
            aa.MaximizeBox = true;
            aa.MinimizeBox = false;
            aa.Height = 650;
            aa.Top = (Screen.PrimaryScreen.WorkingArea.Height - aa.Height) / 2;
            aa.Left = (Screen.PrimaryScreen.WorkingArea.Width - aa.Width) / 2;
            aa.WindowState = System.Windows.Forms.FormWindowState.Normal;
            aa.ShowDialog();
            if (txtNombrePai.Text != string.Empty)
            {
                CargarCalibres(txtCodigoPai.Text);
            }
        }
        private void CargarCalibres(string c_codigo_pai)
        {
            CLS_Calibres selcal = new CLS_Calibres();
            selcal.c_codigo_pai = txtCodigoPai.Text;
            selcal.MtdSeleccionarCalibrePais();
            if(selcal.Exito)
            {
                if (selcal.Datos.Rows.Count > 0)
                {
                    dtgPrecios.DataSource = selcal.Datos;
                    dtgValPrecios.ExpandAllGroups();
                }
                else
                {
                    XtraMessageBox.Show("No existen Calibres para este Pais");
                }
            }
        }
        private void LimpiarCalibres(string c_codigo_pai)
        {
            CLS_Calibres selcal = new CLS_Calibres();
            selcal.c_codigo_pai = txtCodigoPai.Text;
            selcal.MtdSeleccionarCalibrePais();
            if (selcal.Exito)
            {
                dtgPrecios.DataSource = selcal.Datos;
                dtgValPrecios.ExpandAllGroups();
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
                    if (txtNombrePai.Text != string.Empty)
                    {
                        CargarCalibres(txtCodigoPai.Text);
                    }
                }
                SiguienteFoco(1);
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
        private void rdbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbFechas.SelectedIndex == 0)
            {
                dtFechaInicio.Enabled = false;
                dtFechaFin.Enabled = false;
                dtFechaUnica.Enabled = true;
            }
            else
            {
                dtFechaInicio.Enabled = true;
                dtFechaFin.Enabled = true;
                dtFechaUnica.Enabled = false;
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
        private bool ValidaDatos()
        {
            Boolean Valor = true;
            if (dtgValPrecios.RowCount==0)
            {
                Valor = false;
            }
            if ((txtCodigoDis.Text == string.Empty || txtNombreDistribuidor.Text == string.Empty) || (txtCodigoPai.Text == string.Empty || txtNombrePai.Text == string.Empty))
            {
                Valor = false;
            }
            return Valor;
        }
        private List<string> CrearRangoFecha(string FechaInicio, string FechaFin)
        {
            List<string> Fechas = new List<string>();
            DateTime fechainicio = Convert.ToDateTime(FechaInicio);
            DateTime fechafin = Convert.ToDateTime(FechaFin);

            TimeSpan diferencia = fechafin.Subtract(fechainicio);

            for (int i = 0; i < diferencia.TotalDays + 1; i++)
            {
                DateTime fecha = fechainicio.AddDays(i);
                fecha.ToShortDateString();
                Fechas.Add(fecha.ToString());
            }
            return Fechas;
        }
        private bool modificar(int c_codigo_pre, string c_codigo_cal, string c_codigo_dis, string d_fecha_pre, decimal n_preciobanda_pre, decimal n_precioventa_pre, string c_codigo_uss)
        {
            bool Valor = true;
            try
            {
                CLS_Precios_Fechas insPre = new CLS_Precios_Fechas();
                insPre.c_codigo_pre = c_codigo_pre;
                insPre.c_codigo_cal = c_codigo_cal;
                insPre.c_codigo_dis = c_codigo_dis;
                insPre.d_fecha_pre = d_fecha_pre;
                insPre.n_preciobanda_pre = n_preciobanda_pre;
                insPre.n_precioventa_pre = n_precioventa_pre;
                insPre.c_codigo_usu = c_codigo_uss;
                insPre.MtdActualizar();
                if (!insPre.Exito)
                {
                    Valor = false;
                    XtraMessageBox.Show(insPre.Mensaje);
                }
            }
            catch (Exception ex)
            {
                Valor = false;
                XtraMessageBox.Show(ex.Message);
            }
            return Valor;
        }
        private bool insertar(string c_codigo_cal, string c_codigo_dis, string d_fecha_pre, decimal n_preciobanda_pre, decimal n_precioventa_pre, string c_codigo_uss)
        {
            bool Valor = true;
            try
            {
                CLS_Precios_Fechas insPre = new CLS_Precios_Fechas();
                insPre.c_codigo_pre = c_codigo_pre;
                insPre.c_codigo_cal = c_codigo_cal;
                insPre.c_codigo_dis = c_codigo_dis;
                insPre.d_fecha_pre = d_fecha_pre;
                insPre.n_preciobanda_pre = n_preciobanda_pre;
                insPre.n_precioventa_pre = n_precioventa_pre;
                insPre.c_codigo_usu = c_codigo_uss;
                insPre.MtdInsertar();
                if (!insPre.Exito)
                {
                    Valor = false;
                    XtraMessageBox.Show(insPre.Mensaje);
                }
            }
            catch (Exception ex)
            {
                Valor = false;
                XtraMessageBox.Show(ex.Message);
            }
            return Valor;
        }
        private bool buscar(string c_codigo_cal, string c_codigo_dis, string d_fecha_pre, string d_fecha_preIni, string d_fecha_preFin, int Opcion)
        {
            bool Valor = true;
            try
            {
                CLS_Precios_Fechas insPre = new CLS_Precios_Fechas();
                insPre.c_codigo_pre = c_codigo_pre;
                insPre.c_codigo_cal = c_codigo_cal;
                insPre.c_codigo_dis = c_codigo_dis;
                insPre.d_fecha_pre = d_fecha_pre;
                insPre.d_fecha_preIni = d_fecha_preIni;
                insPre.d_fecha_preFin = d_fecha_preFin;
                insPre.Opcion = Opcion;
                insPre.MtdSeleccionarCodigoNombre();
                if (insPre.Exito)
                {
                    if (insPre.Datos.Rows.Count > 0)
                    {
                        dtgPrecios.DataSource = insPre.Datos;
                    }
                    else
                    {
                        XtraMessageBox.Show("No existen datos para mostrar");
                    }
                }
                else
                {
                    XtraMessageBox.Show(insPre.Mensaje);
                }
            }
            catch (Exception ex)
            {
                Valor = false;
                XtraMessageBox.Show(ex.Message);
            }
            return Valor;
        }

        private void txtCodigoDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoPai.Text != string.Empty)
                {
                    mtdBuscarDistribuidor(txtCodigoDis.Text);
                }
                SiguienteFoco(1);
            }
        }
    }
}