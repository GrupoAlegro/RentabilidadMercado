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
    public partial class Frm_Precios_Fechas : DevExpress.XtraEditors.XtraForm
    {
        private static Frm_Precios_Fechas m_FormDefInstance;
        private int FilaSelect;
        int c_codigo_pre = 0;
        public string c_codigo_usu { get; set; }
        bool IsEditPrecios = false;

        public static Frm_Precios_Fechas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Precios_Fechas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Precios_Fechas()
        {
            InitializeComponent();
        }
        private void Frm_Precios_Fechas_Shown(object sender, EventArgs e)
        {
            buscarInicio();
            Limpiar();
            txtPrecioBanda.Properties.Mask.EditMask = "$ ###,###0.00";
            txtPrecioBanda.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioEstimado.Properties.Mask.EditMask = "$ ###,###0.00";
            txtPrecioEstimado.Properties.Mask.UseMaskAsDisplayFormat = true;
            PrecioBanda.DisplayFormat.FormatString = "$ ###,###0.00";
            PrecioEstimado.DisplayFormat.FormatString = "$ ###,###0.00";
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Limpiar();
            buscarInicio();

        }
        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string vc_codigo_cal = string.Empty;
            string vc_codigo_dis = string.Empty;
            string vd_fecha_pre = string.Empty;
            string vd_fecha_preIni = string.Empty;
            string vd_fecha_preFin = string.Empty;
            int vOpcion = 0;

            vc_codigo_cal = txtCodigoCal.Text;
            vc_codigo_dis = txtCodigoDis.Text;
            if (rdbFechas.SelectedIndex == 0)
            {
                vd_fecha_pre = dtFechaUnica.DateTime.Year + DosCeros1(dtFechaUnica.DateTime.Month.ToString()) + DosCeros1(dtFechaUnica.DateTime.Day.ToString());
                vd_fecha_preIni = string.Empty;
                vd_fecha_preFin = string.Empty;
                vOpcion = 1;
                buscar(vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vd_fecha_preIni, vd_fecha_preFin, vOpcion);
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
                    vd_fecha_pre = string.Empty;
                    vd_fecha_preIni = dtFechaInicio.DateTime.Year + DosCeros1(dtFechaInicio.DateTime.Month.ToString()) + DosCeros1(dtFechaInicio.DateTime.Day.ToString());
                    vd_fecha_preFin = dtFechaFin.DateTime.Year + DosCeros1(dtFechaFin.DateTime.Month.ToString()) + DosCeros1(dtFechaFin.DateTime.Day.ToString());
                    vOpcion = 2;
                    buscar(vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vd_fecha_preIni, vd_fecha_preFin, vOpcion);
                }
            }
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidaDatos())
            {
                if (rdbFechas.SelectedIndex == 0)
                {
                    CLS_Precios_Fechas selFecha = new CLS_Precios_Fechas();
                    selFecha.c_codigo_cal = txtCodigoCal.Text;
                    selFecha.c_codigo_dis = txtCodigoDis.Text;
                    DateTime FActual = dtFechaUnica.DateTime;
                    selFecha.d_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                    selFecha.MtdSeleccionarCalDisFecha();
                    if (selFecha.Exito)
                    {
                        if (selFecha.Datos.Rows.Count == 0)
                        {
                            int vOpcion = 1;
                            string vc_codigo_cal = txtCodigoCal.Text;
                            string vc_codigo_dis = txtCodigoDis.Text;
                            string vd_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                            decimal vn_preciobanda_pre = Convert.ToDecimal(txtPrecioBanda.Value);
                            decimal vn_precioventa_pre = Convert.ToDecimal(txtPrecioEstimado.Value);
                            string vd_fecha_preIni = string.Empty;
                            string vd_fecha_preFin = string.Empty;
                            string vc_codigo_usu = c_codigo_usu;
                            if (insertar(vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vn_preciobanda_pre, vn_precioventa_pre, vc_codigo_usu))
                            {
                                XtraMessageBox.Show("Se ha insertado el registro con exito");
                                buscar(vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vd_fecha_preIni, vd_fecha_preFin, vOpcion);
                            }
                        }
                        else
                        {
                            int vOpcion = 1;
                            string vc_codigo_cal = txtCodigoCal.Text;
                            string vc_codigo_dis = txtCodigoDis.Text;
                            string vd_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                            decimal vn_preciobanda_pre = Convert.ToDecimal(txtPrecioBanda.Value);
                            decimal vn_precioventa_pre = Convert.ToDecimal(txtPrecioEstimado.Value);
                            string vd_fecha_preIni = string.Empty;
                            string vd_fecha_preFin = string.Empty;
                            string vc_codigo_usu = c_codigo_usu;
                            if (modificar(c_codigo_pre, vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vn_preciobanda_pre, vn_precioventa_pre, vc_codigo_usu))
                            {
                                XtraMessageBox.Show("Se ha modificado el registro con exito");
                                buscar(vc_codigo_cal, vc_codigo_dis, vd_fecha_pre, vd_fecha_preIni, vd_fecha_preFin, vOpcion);
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
                        string FechaIni = dtFechaInicio.DateTime.Year + "-" + DosCeros1(dtFechaInicio.DateTime.Month.ToString()) + "-" + DosCeros1(dtFechaInicio.DateTime.Day.ToString());
                        string FechaF = dtFechaFin.DateTime.Year + "-" + DosCeros1(dtFechaFin.DateTime.Month.ToString()) + "-" + DosCeros1(dtFechaFin.DateTime.Day.ToString());
                        int vOpcion = 2;
                        List<String> Fechas = new List<string>();
                        Fechas = CrearRangoFecha(FechaIni, FechaF);
                        int Cont = 0;
                        FechaIni = dtFechaInicio.DateTime.Year + DosCeros1(dtFechaInicio.DateTime.Month.ToString()) + DosCeros1(dtFechaInicio.DateTime.Day.ToString());
                        FechaF = dtFechaFin.DateTime.Year + DosCeros1(dtFechaFin.DateTime.Month.ToString()) + DosCeros1(dtFechaFin.DateTime.Day.ToString());
                        string vc_codigo_cal = txtCodigoCal.Text;
                        string vc_codigo_dis = txtCodigoDis.Text;

                        for (int i = 0; i < Fechas.Count; i++)
                        {
                            CLS_Precios_Fechas selFecha = new CLS_Precios_Fechas();
                            selFecha.c_codigo_cal = txtCodigoCal.Text;
                            selFecha.c_codigo_dis = txtCodigoDis.Text;
                            DateTime FActual = Convert.ToDateTime(Fechas[i]);
                            selFecha.d_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                            selFecha.MtdSeleccionarCalDisFecha();

                            string vd_fecha_pre = FActual.Year + DosCeros1(FActual.Month.ToString()) + DosCeros1(FActual.Day.ToString());
                            decimal vn_preciobanda_pre = Convert.ToDecimal(txtPrecioBanda.Value);
                            decimal vn_precioventa_pre = Convert.ToDecimal(txtPrecioEstimado.Value);
                            string vc_codigo_usu = c_codigo_usu;
                            if (selFecha.Exito)
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
                            else
                            {
                                XtraMessageBox.Show(selFecha.Mensaje);
                            }
                        }
                        if (Cont == Fechas.Count)
                        {
                            XtraMessageBox.Show("Se han Procesado Todos los Registros");
                            buscar(vc_codigo_cal, vc_codigo_dis, string.Empty, FechaIni, FechaF, vOpcion);
                        }
                        else
                        {
                            XtraMessageBox.Show("han faltado de Procesar algunos Registros");
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan datos por Capturar oalguno de los precios estan en 0");
            }
        }
        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        private void btnImpCalibre_Click(object sender, EventArgs e)
        {
            Frm_Calibres aa = new Frm_Calibres();
            aa.c_codigo_usu = c_codigo_usu;
            aa.FrmPrecioFechas = this;
            aa.Width = 1000;
            aa.MaximizeBox = true;
            aa.MinimizeBox = false;
            aa.Height = 650;
            aa.Top = (Screen.PrimaryScreen.WorkingArea.Height - aa.Height) / 2;
            aa.Left = (Screen.PrimaryScreen.WorkingArea.Width - aa.Width) / 2;
            aa.WindowState = System.Windows.Forms.FormWindowState.Normal;
            aa.ShowDialog();
        }
        private void btnImpDistribuidor_Click(object sender, EventArgs e)
        {
            Frm_BDistribuidores frm = new Frm_BDistribuidores();
            frm.c_codigo_dis = string.Empty;
            frm.v_nombre_dis = string.Empty;
            frm.ShowDialog();
            txtCodigoDis.Text = frm.c_codigo_dis;
            txtNombreDistribuidor.Text = frm.v_nombre_dis;
        }

        private void txtCodigoCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                BuscarCalibres(txtCodigoCal.Text);
                SiguienteFoco(1);
            }
        }
        private void txtCodigoDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodigoDis.Text != string.Empty && e.KeyValue == 13)
            {
                BuscarDistribuidor(txtCodigoDis.Text);
                SiguienteFoco(2);
            }
        }
        private void txtPrecioBanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SiguienteFoco(3);
            }
        }
        private void txtPrecioEstimado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SiguienteFoco(0);
            }
        }
        private void txtCodigoCal_TextChanged(object sender, EventArgs e)
        {
            txtNombreCalibre.Text = string.Empty;
            txtNombreCategoria.Text = string.Empty;
            txtNombrePais.Text = string.Empty;
            txtNombreTratamiento.Text = string.Empty;
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

        private void dtgPrecios_Click(object sender, EventArgs e)
        {
            MtdSubeDatos();
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
            if(txtCodigoCal.Text==string.Empty || txtNombreCalibre.Text==string.Empty)
            {
                Valor = false;
            }
            if (txtCodigoDis.Text == string.Empty || txtNombreDistribuidor.Text == string.Empty)
            {
                Valor = false;
            }
            if(txtPrecioBanda.Value<=0 || txtPrecioEstimado.Value<=0)
            {
                Valor = false;
            }

            return Valor;
        }
        private bool modificar(int c_codigo_pre,string c_codigo_cal, string c_codigo_dis, string d_fecha_pre, decimal n_preciobanda_pre, decimal n_precioventa_pre, string c_codigo_uss)
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
                if(!insPre.Exito)
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
        private bool insertar(string c_codigo_cal, string c_codigo_dis,string d_fecha_pre, decimal n_preciobanda_pre, decimal n_precioventa_pre,string c_codigo_uss)
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
        private void Limpiar()
        {
            txtCodigoCal.Text = string.Empty;
            txtNombreCalibre.Text = string.Empty;
            txtNombreCategoria.Text = string.Empty;
            txtNombrePais.Text = string.Empty;
            txtNombreTratamiento.Text = string.Empty;
            txtCodigoDis.Text = string.Empty;
            txtNombreDistribuidor.Text = string.Empty;
            spDesde.Value = 0;
            spHasta.Value = 0;
            txtPrecioBanda.Text = string.Empty;
            txtPrecioEstimado.Text = string.Empty;
            dtFechaInicio.Enabled = false;
            dtFechaFin.Enabled = false;
            dtFechaUnica.Enabled = true;
            rdbFechas.SelectedIndex = 0;
            dtFechaUnica.DateTime = DateTime.Now;
            dtFechaInicio.DateTime = DateTime.Now;
            dtFechaFin.DateTime = DateTime.Now;
            IsEditPrecios = false;
            c_codigo_pre = 0;
        }
        private void buscarInicio()
        {
            try
            {
                CLS_Precios_Fechas insPre = new CLS_Precios_Fechas();
                insPre.MtdSeleccionar();
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
                XtraMessageBox.Show(ex.Message);
            }
        }
        public void BuscarCalibres(string c_codigo_cal)
        {
            if (c_codigo_cal != string.Empty)
            {
                CLS_Calibres selCal = new CLS_Calibres();
                selCal.c_codigo_cal = c_codigo_cal;
                selCal.v_nombre_cal = string.Empty;
                selCal.c_codigo_pai = string.Empty;
                selCal.c_codigo_cat = string.Empty;
                selCal.c_codigo_tra = string.Empty;
                selCal.MtdSeleccionarCodigoNombre();
                if (selCal.Exito)
                {
                    if (selCal.Datos.Rows.Count > 0)
                    {
                        txtCodigoCal.Text = selCal.Datos.Rows[0][0].ToString();
                        txtNombreCalibre.Text = selCal.Datos.Rows[0][1].ToString();
                        txtNombrePais.Text = selCal.Datos.Rows[0][3].ToString();
                        txtNombreCategoria.Text = selCal.Datos.Rows[0][7].ToString();
                        txtNombreTratamiento.Text = selCal.Datos.Rows[0][5].ToString();
                        spDesde.EditValue = selCal.Datos.Rows[0][8].ToString();
                        spHasta.EditValue = selCal.Datos.Rows[0][9].ToString();
                        SiguienteFoco(2);
                    }
                }
                else
                {
                    XtraMessageBox.Show(selCal.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No existen parametros de Busqueda");
            }
        }
        private void BuscarDistribuidor(string c_codigo_dis)
        {
            CLS_Distribuidor seldis = new CLS_Distribuidor();
            seldis.c_codigo_dis = c_codigo_dis;
            seldis.MtdSeleccionar();
            if (seldis.Exito)
            {
                if (seldis.Datos.Rows.Count > 0)
                {
                    txtCodigoDis.Text = seldis.Datos.Rows[0][0].ToString();
                    txtNombreDistribuidor.Text = seldis.Datos.Rows[0][1].ToString();
                }
                else
                {
                    XtraMessageBox.Show("No se encontraron Registros");
                }
            }
        }
        private void MtdSubeDatos()
        {
            try
            {
                foreach (int i in this.dtgValPrecios.GetSelectedRows())
                {
                    FilaSelect = i;
                    IsEditPrecios = true;
                    DataRow row = dtgValPrecios.GetDataRow(i);
                    c_codigo_pre = Convert.ToInt32(row["c_codigo_pre"].ToString());
                    txtCodigoCal.Text = row["c_codigo_cal"].ToString();
                    BuscarCalibres(txtCodigoCal.Text);
                    txtCodigoDis.Text = row["c_codigo_dis"].ToString();
                    BuscarDistribuidor(txtCodigoDis.Text);
                    txtPrecioBanda.Value= Convert.ToDecimal(row["n_preciobanda_pre"].ToString());
                    txtPrecioEstimado.Value = Convert.ToDecimal(row["n_precioventa_pre"].ToString());
                    rdbFechas.SelectedIndex = 0;
                    IsEditPrecios = true;
                    dtFechaUnica.DateTime = Convert.ToDateTime(row["d_fecha_pre"].ToString());
                    SiguienteFoco(0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void SiguienteFoco(int Actual)
        {
            switch (Actual)
            {
                case 0:
                    txtCodigoCal.Focus();
                    break;
                case 1:
                    txtCodigoDis.Focus();
                    break;
                case 2:
                    txtPrecioBanda.Focus();
                    break;
                case 3:
                    txtPrecioEstimado.Focus();
                    break;
            }
        }
    }
}