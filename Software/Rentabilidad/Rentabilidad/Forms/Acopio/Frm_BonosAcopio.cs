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
    public partial class Frm_BonosAcopio : DevExpress.XtraEditors.XtraForm
    {
        public Frm_BonosAcopio()
        {
            InitializeComponent();
        }

        private void Frm_BonosAcopio_Shown(object sender, EventArgs e)
        {
            CargarPagoCamion();
            CargarGrupoPago();
        }

        private void CargarGrupoPago()
        {
            CLS_Acopio selGrupo = new CLS_Acopio();
            selGrupo.MtdSeleccionarGrupoPago();
            if (selGrupo.Exito)
            {
                dtgGrupoPago.DataSource = selGrupo.Datos;
            }
        }

        private void CargarPagoCamion()
        {
            CLS_Acopio selCamion = new CLS_Acopio();
            selCamion.MtdSeleccionarPagoCamion();
            if (selCamion.Exito)
            {
                dtgPagoCamion.DataSource = selCamion.Datos;
            }
        }
    }
}