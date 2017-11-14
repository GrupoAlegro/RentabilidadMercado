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
    }
}
