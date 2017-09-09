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
        public Frm_Tratamiento()
        {
            InitializeComponent();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Tratamiento_Shown(object sender, EventArgs e)
        {
            CLS_Tratamiento selTratamiento = new CLS_Tratamiento();
            selTratamiento.MtdSeleccionar();
            if (selTratamiento.Exito)
            {
                dtgTratamiento.DataSource = selTratamiento.Datos;
            }
        }
}
}