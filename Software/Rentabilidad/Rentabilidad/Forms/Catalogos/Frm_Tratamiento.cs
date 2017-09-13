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
    public partial class Frm_Tratamiento : DevExpress.XtraEditors.XtraForm
    {
        Boolean IsEditTratamiento;
        public Frm_Calibres FrmCalibre;
        public string c_codigo_usu { get; private set; }

        public Frm_Tratamiento()
        {
            InitializeComponent();
        }
        private void Frm_Tratamiento_Shown(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            CLS_Tratamiento selTratamiento = new CLS_Tratamiento();
            selTratamiento.MtdSeleccionar();
            if (selTratamiento.Exito)
            {
                dtgTratamiento.DataSource = selTratamiento.Datos;
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCodigoTra.Text != string.Empty || txtNombreTra.Text != string.Empty)
            {
                CLS_Tratamiento selTratamiento = new CLS_Tratamiento();
                selTratamiento.c_codigo_tra = txtCodigoTra.Text;
                selTratamiento.v_nombre_tra = txtNombreTra.Text;
                selTratamiento.MtdSeleccionarCodigoNombre();
                if (selTratamiento.Exito)
                {
                    dtgTratamiento.DataSource = selTratamiento.Datos;
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
            txtCodigoTra.Text = string.Empty;
            txtNombreTra.Text = string.Empty;
            IsEditTratamiento = false;
            txtCodigoTra.Enabled = true;
            CargarGrid();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsEditTratamiento == true)
            {
                if (txtCodigoTra.Text != string.Empty && txtNombreTra.Text != string.Empty)
                {
                    CLS_Tratamiento seltratamiento = new CLS_Tratamiento();
                    seltratamiento.c_codigo_tra = txtCodigoTra.Text;
                    seltratamiento.v_nombre_tra = txtNombreTra.Text;
                    seltratamiento.c_codigo_usu = c_codigo_usu;
                    seltratamiento.MtdActualizar();
                    if (seltratamiento.Exito)
                    {
                        dtgTratamiento.DataSource = seltratamiento.Datos;
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
                if (txtCodigoTra.Text != string.Empty && txtNombreTra.Text != string.Empty)
                {
                    CLS_Tratamiento selpais = new CLS_Tratamiento();
                    selpais.c_codigo_tra = txtCodigoTra.Text;
                    selpais.v_nombre_tra = txtNombreTra.Text;
                    selpais.c_codigo_usu = c_codigo_usu;
                    selpais.MtdInsertar();
                    if (selpais.Exito)
                    {
                        dtgTratamiento.DataSource = selpais.Datos;
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
            if (IsEditTratamiento == true)
            {
                if (FrmCalibre != null)
                {
                    FrmCalibre.mtdBuscarTratamiento(txtCodigoTra.Text, txtNombreTra.Text);
                    Close();
                }
            }
        }
    }
}