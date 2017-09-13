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
    public partial class Frm_Categorias : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Calibres FrmCalibre;
        int FilaSelect = 0;
        Boolean IsEditCategorias;
        public string c_codigo_usu { get; set; }
        public Frm_Categorias()
        {
            InitializeComponent();
        }
        private static Frm_Categorias m_FormDefInstance;
        public static Frm_Categorias DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Categorias();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void dtgCategoria_Click(object sender, EventArgs e)
        {
            MtdsubeDatos(); 
        }
        private void MtdsubeDatos()
        {
            try
            {
                foreach (int i in this.dtgValCategoria.GetSelectedRows())
                {
                    FilaSelect = i;
                    IsEditCategorias = true;
                    DataRow row = dtgValCategoria.GetDataRow(i);
                    txtCodigoCat.Text = row["c_codigo_cat"].ToString();
                    txtNombreCat.Text = row["v_nombre_cat"].ToString();
                    txtCodigoCat.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Categorias_Shown(object sender, EventArgs e)
        {
            CargarGrid();

        }

        private void CargarGrid()
        {
            CLS_Categorias selcategorias = new CLS_Categorias();
            selcategorias.MtdSeleccionar();
            if (selcategorias.Exito)
            {
                dtgCategoria.DataSource = selcategorias.Datos;
            }
        }

        private void Frm_Categorias_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCodigoCat.Text = string.Empty;
            txtNombreCat.Text = string.Empty;
            IsEditCategorias = false;
            txtCodigoCat.Enabled = true;
            CargarGrid();
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCodigoCat.Text != string.Empty || txtNombreCat.Text != string.Empty)
            {
                CLS_Categorias selCategorias = new CLS_Categorias();
                selCategorias.c_codigo_cat = txtCodigoCat.Text;
                selCategorias.v_nombre_cat = txtNombreCat.Text;
                selCategorias.MtdSeleccionarCodigoNombre();
                if (selCategorias.Exito)
                {
                    dtgCategoria.DataSource = selCategorias.Datos;
                }
                else
                {
                    XtraMessageBox.Show(selCategorias.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No existen parametros de Busqueda");
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEditCategorias == true)
            {
                if (txtCodigoCat.Text != string.Empty && txtNombreCat.Text != string.Empty)
                {
                    CLS_Categorias selcat = new CLS_Categorias();
                    selcat.c_codigo_cat = txtCodigoCat.Text;
                    selcat.v_nombre_cat = txtNombreCat.Text;
                    selcat.c_codigo_usu = c_codigo_usu;
                    selcat.MtdActualizar();
                    if (selcat.Exito)
                    {
                        dtgCategoria.DataSource = selcat.Datos;
                        XtraMessageBox.Show("Registro Actualizado Exitosamente");
                    }
                    else
                    {
                        XtraMessageBox.Show(selcat.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Faltan datos por capturar");
                }
            }
            else
            {
                if (txtCodigoCat.Text != string.Empty && txtNombreCat.Text != string.Empty)
                {
                    CLS_Categorias selcat = new CLS_Categorias();
                    selcat.c_codigo_cat= txtCodigoCat.Text;
                    selcat.v_nombre_cat = txtNombreCat.Text;
                    selcat.c_codigo_usu = c_codigo_usu;
                    selcat.MtdInsertar();
                    if (selcat.Exito)
                    {
                        dtgCategoria.DataSource = selcat.Datos;
                        XtraMessageBox.Show("Registro Insertado Exitosamente");
                    }
                    else
                    {
                        XtraMessageBox.Show(selcat.Mensaje);
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
            if (IsEditCategorias == true)
            {
                DialogResult = XtraMessageBox.Show("¿Desea Eliminar el Registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    CLS_Pais selpais1 = new CLS_Pais();
                    selpais1.c_codigo_pai = txtCodigoCat.Text;
                    selpais1.MtdEliminar();
                    if (selpais1.Exito)
                    {
                        dtgCategoria.DataSource = selpais1.Datos;
                        XtraMessageBox.Show("Registro Eliminado Exitosamente");
                    }
                    else
                    {
                        XtraMessageBox.Show(selpais1.Mensaje);
                    }
                    CargarGrid();
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccione un elemento para eliminar");
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEditCategorias == true)
            {
                if (FrmCalibre != null)
                {
                    FrmCalibre.mtdBuscarCategorias(txtCodigoCat.Text, txtNombreCat.Text);
                    Close();
                }
            }
        }
    }
    }
