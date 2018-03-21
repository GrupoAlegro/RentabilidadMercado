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
    public partial class Frm_BonosAcopio : DevExpress.XtraEditors.XtraForm
    {
        public bool PrimeraEdicion { get; private set; }

        public Frm_BonosAcopio()
        {
            InitializeComponent();
        }

        private void Frm_BonosAcopio_Shown(object sender, EventArgs e)
        {
            PrimeraEdicion = false;
            ColTipoCamionPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ColTipoCamionPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            ColTipoCamionPago.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ColTipoCamionPago.DisplayFormat.FormatString = "c2";
            ColGrupoPagoPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ColGrupoPagoPorcentaje.DisplayFormat.FormatString = "###0.00 %";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dtgPagoCamion.FocusedView.CloseEditor();
                dtgGrupoPago.FocusedView.CloseEditor();
                ActualizarDatosGruposPagos();
                ActualizarDatosPagoCamion();
                XtraMessageBox.Show("Datos Guardados con Exito");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
           
        }
        private void ActualizarDatosPagoCamion()
        {
            int x = 1;
            for (int i = 0; i < dtgValPagoCamion.RowCount; i++)
            {
                CLS_Acopio artprecio = new CLS_Acopio();
                artprecio.c_pago_camion = dtgValPagoCamion.GetRowCellValue(i, dtgValPagoCamion.Columns["c_pago_camion"]).ToString();
                artprecio.v_tipo_camion = dtgValPagoCamion.GetRowCellValue(i, dtgValPagoCamion.Columns["v_tipo_camion"]).ToString();
                artprecio.n_porcentaje_pago = Convert.ToDecimal(dtgValPagoCamion.GetRowCellValue(i, dtgValPagoCamion.Columns["n_porcentaje_pago"]).ToString());
                artprecio.n_monto_pago = Convert.ToDecimal(dtgValPagoCamion.GetRowCellValue(i, dtgValPagoCamion.Columns["n_monto_pago"]).ToString());
                artprecio.MtdActualizarPagoCamion();
                if (!artprecio.Exito)
                {
                    XtraMessageBox.Show(artprecio.Mensaje);
                }
            }

        }
        private void ActualizarDatosGruposPagos()
        {
            int x = 1;
            for (int i = 0; i < dtgValGrupoPago.RowCount; i++)
            {
                CLS_Acopio artprecio = new CLS_Acopio();
                artprecio.c_codigo_gru = dtgValGrupoPago.GetRowCellValue(i, dtgValGrupoPago.Columns["c_codigo_gru"]).ToString();
                artprecio.v_grupopago = dtgValGrupoPago.GetRowCellValue(i, dtgValGrupoPago.Columns["v_grupopago"]).ToString();
                artprecio.n_porcentaje = Convert.ToDecimal(dtgValGrupoPago.GetRowCellValue(i, dtgValGrupoPago.Columns["n_porcentaje"]).ToString());
                artprecio.MtdActualizarGrupoPago();
                if (!artprecio.Exito)
                {
                    XtraMessageBox.Show(artprecio.Mensaje);
                }
            }

        }

        private void dtgValPagoCamion_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicion)
            {
                PrimeraEdicion = true;
                GridView gv = sender as GridView;
                decimal Camion = Convert.ToDecimal(gv.GetRowCellValue(e.RowHandle, gv.Columns["v_tipo_camion"]).ToString());
                decimal Porcentaje = Convert.ToDecimal(gv.GetRowCellValue(e.RowHandle, gv.Columns["n_porcentaje_pago"]).ToString());
                decimal vPVenta = Camion * Porcentaje;
                gv.SetRowCellValue(e.RowHandle, gv.Columns["n_monto_pago"], vPVenta);
                PrimeraEdicion = false;
            }
        }
    }
}