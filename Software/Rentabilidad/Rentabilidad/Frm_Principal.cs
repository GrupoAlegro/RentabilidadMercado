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
    }
}
