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
    public partial class Frm_BDistribuidores: DevExpress.XtraEditors.XtraForm
    {
        public string c_codigo_dis { get; set; }
        public string v_nombre_dis { get; set; }
        public Frm_BDistribuidores()
        {
            InitializeComponent();
        }
        private void BuscarArticulos()
        {
            CLS_Distribuidor busq = new CLS_Distribuidor();
            string vTipo = string.Empty;
            if(rdbTipoBusqueda.SelectedIndex==0)
            {
                vTipo = "Descripcion";
            }
            busq.Tipo = vTipo;
            busq.Elementos = Convert.ToInt32(cmbElementos.Text);
            busq.TextoBusqueda = txtBusqueda.Text;
            busq.MtdSeleccionarCodigoNombre();
            if (busq.Exito)
            {
                dtgDistribuidores.DataSource = busq.Datos;
            }
            else
            {
                XtraMessageBox.Show(busq.Mensaje);
            }
        }
        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                BuscarArticulos();
                if (dtgValDistribuidores.RowCount == 0)
                {
                    XtraMessageBox.Show("No se Encontraron Registros");
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValDistribuidores.GetSelectedRows())
                {
                    DataRow row = dtgValDistribuidores.GetDataRow(i);
                    c_codigo_dis = row["c_codigo_dis"].ToString();
                    v_nombre_dis = row["v_nombre_dis"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_BArticulos_Load(object sender, EventArgs e)
        {
            dtgValDistribuidores.OptionsBehavior.Editable = false;
            // Prevent the focused cell from being highlighted.
            dtgValDistribuidores.OptionsSelection.EnableAppearanceFocusedCell = false;
            // Draw a dotted focus rectangle around the entire row.
            dtgValDistribuidores.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            cmbElementos.SelectedIndex = 0;
            rdbTipoBusqueda.SelectedIndex = 0;
            txtBusqueda.Focus();
            BuscarArticulos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}