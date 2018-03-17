using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rentabilidad
{
    public partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string c_codigo_usu { get; set; }
        public Frm_Principal()
        {
            InitializeComponent();
        }
        private void btnPais_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Pais.DefInstance.MdiParent = this;
            Frm_Pais.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_Pais.DefInstance.Show();
        }

        private void btnCategorias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Categorias.DefInstance.MdiParent = this;
            Frm_Categorias.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_Categorias.DefInstance.Show();
        }

        private void btrnCalibres_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Calibres.DefInstance.MdiParent = this;
            Frm_Calibres.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_Calibres.DefInstance.Show();
        }

        private void btnTratamiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Tratamiento.DefInstance.MdiParent = this;
            Frm_Tratamiento.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_Tratamiento.DefInstance.Show();
        }

        private void Frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPrecioFecha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Precios_Fechas.DefInstance.MdiParent = this;
            Frm_Precios_Fechas.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_Precios_Fechas.DefInstance.Show();
        }

        private void btnPrecioPais_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Precios_Pais.DefInstance.MdiParent = this;
            Frm_Precios_Pais.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_Precios_Pais.DefInstance.Show();
        }

        private void btnPreciosPais_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_ReportePrecios.DefInstance.MdiParent = this;
            Frm_ReportePrecios.DefInstance.Show();
        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            MSRegistro RegIn = new MSRegistro();
            Crypto EncriptarTexto = new Crypto();
            RegIn.SaveSetting("ConexionSQL", "Sking", SkinForm.LookAndFeel.SkinName);
        }

        private void btnAnalisis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_PedidosMedicion.DefInstance.MdiParent = this;
            Frm_PedidosMedicion.DefInstance.Show();
        }

        private void btnEmpacadoras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Empleados.DefInstance.MdiParent = this;
            Frm_Empleados.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_Empleados.DefInstance.Show();
        }

        private void btnEtiquetas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_AsignacionEtiquetas.DefInstance.MdiParent = this;
            Frm_AsignacionEtiquetas.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_AsignacionEtiquetas.DefInstance.Show();
        }

        private void btnPrecioBanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_PrecioBanda.DefInstance.MdiParent = this;
            Frm_PrecioBanda.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_PrecioBanda.DefInstance.Show();
        }

        private void btn_RP_Acopiadores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_RPT_Acopiadores.DefInstance.MdiParent = this;
            Frm_RPT_Acopiadores.DefInstance.c_codigo_usu = c_codigo_usu;
            Frm_RPT_Acopiadores.DefInstance.Show();
        }
    }
}
