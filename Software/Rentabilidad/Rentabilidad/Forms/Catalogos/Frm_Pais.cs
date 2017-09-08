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
        public Frm_Pais()
        {
            InitializeComponent();
        }

        private void Frm_Pais_Shown(object sender, EventArgs e)
        {
            CLS_Pais selpais = new CLS_Pais();
            selpais.MtdSeleccionar();
            if (selpais.Exito)
            {
                dtgPais.DataSource = selpais.Datos;
            }

        }
    }
}