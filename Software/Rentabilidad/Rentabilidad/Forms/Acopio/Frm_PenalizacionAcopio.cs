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
using DevExpress.XtraGrid.Views.Grid;

namespace Rentabilidad
{
    public partial class Frm_PenalizacionAcopio : DevExpress.XtraEditors.XtraForm
    {
        public bool PrimeraEdicion { get; private set; }

        public Frm_PenalizacionAcopio()
        {
            InitializeComponent();
        }

        private void Frm_BonosAcopio_Shown(object sender, EventArgs e)
        {
            PrimeraEdicion = false;
            ColCalidadPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ColCalidadPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            ColCalibresPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ColCalibresPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            CargarPagoCamion();
            CargarGrupoPago();
        }

        private void CargarGrupoPago()
        {
            CLS_Acopio selGrupo = new CLS_Acopio();
            selGrupo.MtdSeleccionarGrupoPago();
            if (selGrupo.Exito)
            {
                dtgPenalizacionCalibres.DataSource = selGrupo.Datos;
            }
        }

        private void CargarPagoCamion()
        {
            CLS_Acopio selCamion = new CLS_Acopio();
            selCamion.MtdSeleccionarPagoCamion();
            if (selCamion.Exito)
            {
                dtgPenalizacionCalidad.DataSource = selCamion.Datos;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dtgPenalizacionCalidad.FocusedView.CloseEditor();
                dtgPenalizacionCalibres.FocusedView.CloseEditor();
                ActualizarDatosPenalizacionCalidad();
                ActualizarDatosPenalizacionCalibres();
                XtraMessageBox.Show("Datos Guardados con Exito");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
           
        }
        private void ActualizarDatosPenalizacionCalidad()
        {
            for (int i = 0; i < dtgValPenalizacionCalidad.RowCount; i++)
            {
                CLS_Acopio artprecio = new CLS_Acopio();
                artprecio.c_codigo_pcal = dtgValPenalizacionCalidad.GetRowCellValue(i, dtgValPenalizacionCalidad.Columns["c_codigo_pcal"]).ToString();
                artprecio.v_penalizacion_pcal = dtgValPenalizacionCalidad.GetRowCellValue(i, dtgValPenalizacionCalidad.Columns["v_penalizacion_pcal"]).ToString();
                artprecio.n_porcentaje_pago = Convert.ToDecimal(dtgValPenalizacionCalidad.GetRowCellValue(i, dtgValPenalizacionCalidad.Columns["n_porcentaje"]).ToString());
                artprecio.MtdActualizarPenalizacionCalidad();
                if (!artprecio.Exito)
                {
                    XtraMessageBox.Show(artprecio.Mensaje);
                }
            }

        }
        private void ActualizarDatosPenalizacionCalibres()
        {
            int x = 1;
            for (int i = 0; i < dtgValPenalizacionCalibres.RowCount; i++)
            {
                CLS_Acopio artprecio = new CLS_Acopio();
                artprecio.c_codigo_pcali = dtgValPenalizacionCalibres.GetRowCellValue(i, dtgValPenalizacionCalibres.Columns["c_codigo_pcali"]).ToString();
                artprecio.v_penalizacion_pcali = dtgValPenalizacionCalibres.GetRowCellValue(i, dtgValPenalizacionCalibres.Columns["v_penalizacion_pcali"]).ToString();
                artprecio.n_porcentaje = Convert.ToDecimal(dtgValPenalizacionCalibres.GetRowCellValue(i, dtgValPenalizacionCalibres.Columns["n_porcentaje"]).ToString());
                artprecio.MtdActualizarPenalizacionCalibres();
                if (!artprecio.Exito)
                {
                    XtraMessageBox.Show(artprecio.Mensaje);
                }
            }

        }
    }
}