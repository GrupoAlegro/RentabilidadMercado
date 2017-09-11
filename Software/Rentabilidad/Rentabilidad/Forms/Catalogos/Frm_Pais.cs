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
    public partial class Frm_Pais : DevExpress.XtraEditors.XtraForm
    {
        int FilaSelect = 0;
        Boolean IsEditPais;
        public string c_codigo_usu { get; set; }
        public Frm_Pais()
        {
            InitializeComponent();
        }
        private static Frm_Pais m_FormDefInstance;
        public static Frm_Pais DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Pais();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        private void Frm_Pais_Shown(object sender, EventArgs e)
        {
            CargarGrid();

        }

        private void CargarGrid()
        {
            CLS_Pais selpais = new CLS_Pais();
            selpais.MtdSeleccionar();
            if (selpais.Exito)
            {
                dtgPais.DataSource = selpais.Datos;
            }
        }

        private void dtgPais_Click(object sender, EventArgs e)
        {
            MtdSubeDatos();
        }
        private void MtdSubeDatos()
        {
            try
            {
                foreach (int i in this.dtgValPais.GetSelectedRows())
                {
                    FilaSelect = i;
                    IsEditPais = true;
                    DataRow row = dtgValPais.GetDataRow(i);
                    txtCodigoPai.Text = row["c_codigo_pai"].ToString();
                    txtNombrePai.Text = row["v_nombre_pai"].ToString();
                    txtCodigoPai.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCodigoPai.Text = string.Empty;
            txtNombrePai.Text = string.Empty;
            IsEditPais = false;
            txtCodigoPai.Enabled = true;
            CargarGrid();
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCodigoPai.Text != string.Empty || txtNombrePai.Text != string.Empty)
            {
                CLS_Pais selpais = new CLS_Pais();
                selpais.c_codigo_pai = txtCodigoPai.Text;
                selpais.v_nombre_pai = txtNombrePai.Text;
                selpais.MtdSeleccionarCodigoNombre();
                if (selpais.Exito)
                {
                    dtgPais.DataSource = selpais.Datos;
                }
                else
                {
                    XtraMessageBox.Show(selpais.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No existen parametros de Busqueda");
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEditPais == true)
            {
                if (txtCodigoPai.Text != string.Empty && txtNombrePai.Text != string.Empty)
                {
                    CLS_Pais selpais = new CLS_Pais();
                    selpais.c_codigo_pai = txtCodigoPai.Text;
                    selpais.v_nombre_pai = txtNombrePai.Text;
                    selpais.c_codigo_usu = c_codigo_usu;
                    selpais.MtdActualizar();
                    if (selpais.Exito)
                    {
                        dtgPais.DataSource = selpais.Datos;
                        XtraMessageBox.Show("Registro Actualizado Exitosamente");
                    }
                    else
                    {
                        XtraMessageBox.Show(selpais.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Faltan datos por capturar");
                }
            }
            else
            {
                if (txtCodigoPai.Text != string.Empty && txtNombrePai.Text != string.Empty)
                {
                    CLS_Pais selpais = new CLS_Pais();
                    selpais.c_codigo_pai = txtCodigoPai.Text;
                    selpais.v_nombre_pai = txtNombrePai.Text;
                    selpais.c_codigo_usu = c_codigo_usu;
                    selpais.MtdInsertar();
                    if (selpais.Exito)
                    {
                        dtgPais.DataSource = selpais.Datos;
                        XtraMessageBox.Show("Registro Insertado Exitosamente");
                    }
                    else
                    {
                        XtraMessageBox.Show(selpais.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Faltan datos por capturar");
                }
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEditPais == true)
            {
                CLS_Pais selpais = new CLS_Pais();
                selpais.c_codigo_pai = txtCodigoPai.Text;
                selpais.MtdEliminar();
                if (selpais.Exito)
                {
                    dtgPais.DataSource = selpais.Datos;
                    XtraMessageBox.Show("Registro Eliminado Exitosamente");
                    CargarGrid();
                }
                else
                {
                    XtraMessageBox.Show(selpais.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccione un elemento para eliminar");
            }
        }
    }
}