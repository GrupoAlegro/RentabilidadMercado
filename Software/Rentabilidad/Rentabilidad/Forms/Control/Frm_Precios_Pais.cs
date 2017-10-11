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
    public partial class Frm_Precios_Pais : DevExpress.XtraEditors.XtraForm
    {
        public string c_codigo_usu { get; set; }
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
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
    }
}