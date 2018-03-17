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
    public partial class Frm_Empleados : DevExpress.XtraEditors.XtraForm
    {
        Boolean IsEditEmpleados;
        public Frm_AsignacionEtiquetas FrmAsignacionEtiquetas;
        public string c_codigo_usu { get; set; }

        public Frm_Empleados()
        {
            InitializeComponent();
        }
        private static Frm_Empleados m_FormDefInstance;
        private int FilaSelect;

        public static Frm_Empleados DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Empleados();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        private void Frm_Tratamiento_Shown(object sender, EventArgs e)
        {
            CargarGrid();
            if (FrmAsignacionEtiquetas != null)
            {
                this.btnImportar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                this.btnImportar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void CargarGrid()
        {
            CLS_Empleado selTratamiento = new CLS_Empleado();
            selTratamiento.MtdSeleccionar();
            if (selTratamiento.Exito)
            {
                dtgEmpleado.DataSource = selTratamiento.Datos;
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCodigoEmp.Text != string.Empty || txtNombreEmp.Text != string.Empty)
            {
                CLS_Empleado selTratamiento = new CLS_Empleado();
                selTratamiento.c_codigo_emp = txtCodigoEmp.Text;
                selTratamiento.v_nombre_empacador = txtNombreEmp.Text;
                selTratamiento.MtdSeleccionarCodigoNombre();
                if (selTratamiento.Exito)
                {
                    dtgEmpleado.DataSource = selTratamiento.Datos;
                }
                else
                {
                    XtraMessageBox.Show(selTratamiento.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No existen parametros de Busqueda");
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCodigoEmp.Text = string.Empty;
            txtNombreEmp.Text = string.Empty;
            IsEditEmpleados = false;
            txtCodigoEmp.Enabled = true;
            CargarGrid();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEditEmpleados == true)
            {
                if (txtCodigoEmp.Text != string.Empty && txtNombreEmp.Text != string.Empty)
                {
                    CLS_Empleado seltratamiento = new CLS_Empleado();
                    seltratamiento.c_codigo_emp = txtCodigoEmp.Text;
                    seltratamiento.v_nombre_empacador = txtNombreEmp.Text;
                    seltratamiento.c_codigo_usu = c_codigo_usu;
                    seltratamiento.MtdActualizar();
                    if (seltratamiento.Exito)
                    {
                        dtgEmpleado.DataSource = seltratamiento.Datos;
                        XtraMessageBox.Show("Registro Actualizado Exitosamente");
                    }
                    else
                    {
                        XtraMessageBox.Show(seltratamiento.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Faltan datos por capturar");
                }
            }
            else
            {
                if (txtCodigoEmp.Text != string.Empty && txtNombreEmp.Text != string.Empty)
                {
                    CLS_Empleado selpais = new CLS_Empleado();
                    selpais.c_codigo_emp = txtCodigoEmp.Text;
                    selpais.v_nombre_empacador = txtNombreEmp.Text;
                    selpais.c_codigo_usu = c_codigo_usu;
                    selpais.MtdInsertar();
                    if (selpais.Exito)
                    {
                        dtgEmpleado.DataSource = selpais.Datos;
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

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEditEmpleados == true)
            {
                if (FrmAsignacionEtiquetas != null)
                {
                    FrmAsignacionEtiquetas.mtdBuscarEmpleado(txtCodigoEmp.Text, txtNombreEmp.Text);
                    Close();
                }
            }
        }

        private void dtgTratamiento_Click(object sender, EventArgs e)
        {
            MtdSubeDatos();
        }
        private void MtdSubeDatos()
        {
            try
            {
                foreach (int i in this.dtgValEmpleado.GetSelectedRows())
                {
                    FilaSelect = i;
                    IsEditEmpleados = true;
                    DataRow row = dtgValEmpleado.GetDataRow(i);
                    txtCodigoEmp.Text = row["c_codigo_emp"].ToString();
                    txtNombreEmp.Text = row["v_nombre_empacador"].ToString();
                    txtCodigoEmp.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Tratamiento_Load(object sender, EventArgs e)
        {

        }
    }
}