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
    public partial class Frm_PedidosMedicion : DevExpress.XtraEditors.XtraForm
    {
        private static Frm_PedidosMedicion m_FormDefInstance;
        public static Frm_PedidosMedicion DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_PedidosMedicion();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        DataTable TablePorcentaje = new DataTable();
        DataTable TableKilos = new DataTable();
        DataTable TablePrecios = new DataTable();
        DataColumn columna;
        DataRow fila;
        private int AcopioCajas;
        private int RecepcionCajas;
        private decimal Acopio32Cat1;
        private decimal Acopio36Cat1;
        private decimal Acopio40Cat1;
        private decimal Acopio48Cat1;
        private decimal Acopio60Cat1;
        private decimal Acopio70Cat1;
        private decimal Acopio84Cat1;
        private decimal Acopio96Cat1;
        private decimal Acopio32Cat2;
        private decimal Acopio36Cat2;
        private decimal Acopio40Cat2;
        private decimal Acopio48Cat2;
        private decimal Acopio60Cat2;
        private decimal Acopio70Cat2;
        private decimal Acopio84Cat2;
        private decimal Acopio96Cat2;
        private decimal AcopioSExtraNal;
        private decimal AcopioExtraNal;
        private decimal AcopioPrimeraNal;
        private decimal AcopioSegundaNal;
        private decimal AcopioComercialNal;
        private decimal AcopioDesechoNal;

        private decimal Recepcion32Cat1;
        private decimal Recepcion36Cat1;
        private decimal Recepcion40Cat1;
        private decimal Recepcion48Cat1;
        private decimal Recepcion60Cat1;
        private decimal Recepcion70Cat1;
        private decimal Recepcion84Cat1;
        private decimal Recepcion96Cat1;
        private decimal Recepcion32Cat2;
        private decimal Recepcion36Cat2;
        private decimal Recepcion40Cat2;
        private decimal Recepcion48Cat2;
        private decimal Recepcion60Cat2;
        private decimal Recepcion70Cat2;
        private decimal Recepcion84Cat2;
        private decimal Recepcion96Cat2;
        private decimal RecepcionSExtraNal;
        private decimal RecepcionExtraNal;
        private decimal RecepcionPrimeraNal;
        private decimal RecepcionSegundaNal;
        private decimal RecepcionComercialNal;
        private decimal RecepcionDesechoNal;

        private decimal Produccion32Cat1;
        private decimal Produccion36Cat1;
        private decimal Produccion40Cat1;
        private decimal Produccion48Cat1;
        private decimal Produccion60Cat1;
        private decimal Produccion70Cat1;
        private decimal Produccion84Cat1;
        private decimal Produccion96Cat1;
        private decimal Produccion32Cat2;
        private decimal Produccion36Cat2;
        private decimal Produccion40Cat2;
        private decimal Produccion48Cat2;
        private decimal Produccion60Cat2;
        private decimal Produccion70Cat2;
        private decimal Produccion84Cat2;
        private decimal Produccion96Cat2;
        private decimal ProduccionSExtraNal;
        private decimal ProduccionExtraNal;
        private decimal ProduccionPrimeraNal;
        private decimal ProduccionSegundaNal;
        private decimal ProduccionComercialNal;
        private decimal ProduccionDesechoNal;
        private string Elementos;
        private string Estibas;

        public Frm_PedidosMedicion()
        {
            InitializeComponent();
        }

        private void Frm_PedidosMedicion_Load(object sender, EventArgs e)
        {

        }

        private void Frm_PedidosMedicion_Shown(object sender, EventArgs e)
        {
            IniciarCampos();
            dtgValPorcentaje.ExpandAllGroups();
            dtgValKilos.ExpandAllGroups();
            dtgValPrecios.ExpandAllGroups();
            //Porcentaje
            colCajasPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colCajasPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            colPaletsPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colPaletsPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            colAcopioPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colAcopioPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            colRecpcionPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colRecpcionPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            colProduccionPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colProduccionPorcentaje.DisplayFormat.FormatString = "###0.00 %";
            //Kilos
            colCajasKilos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colCajasKilos.DisplayFormat.FormatString = "###,###0.00 kg";
            colPaletsKilos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colPaletsKilos.DisplayFormat.FormatString = "###,###0.00 kg";
            colAcopioKilos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colAcopioKilos.DisplayFormat.FormatString = "###,###0.00 kg";
            colRecepcionKilos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colRecepcionKilos.DisplayFormat.FormatString = "###,###0.00 kg";
            colProduccionKilos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colProduccionKilos.DisplayFormat.FormatString = "###,###0.00 kg";
            //Produccion
            colCajasPrecios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colCajasPrecios.DisplayFormat.FormatString = "c2";
            colPaletsPrecios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colPaletsPrecios.DisplayFormat.FormatString = "c2";
            colAcopioPrecios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colAcopioPrecios.DisplayFormat.FormatString = "c2";
            colRecepcionPrecios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colRecepcionPrecios.DisplayFormat.FormatString = "c2";
            colProduccionPrecios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            colProduccionPrecios.DisplayFormat.FormatString = "c2";
            dtgValPorcentaje.OptionsBehavior.Editable = false;
            dtgValPorcentaje.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValPorcentaje.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            dtgValPrecios.OptionsBehavior.Editable = false;
            dtgValPrecios.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValPrecios.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            dtgValKilos.OptionsBehavior.Editable = false;
            dtgValKilos.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValKilos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            txtKilosPedido.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtKilosPedido.Properties.DisplayFormat.FormatString = "###,###0.00 kg";
            txtKilosAcopio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtKilosAcopio.Properties.DisplayFormat.FormatString = "###,###0.00 kg";
            txtKilosRecepcion.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtKilosRecepcion.Properties.DisplayFormat.FormatString = "###,###0.00 kg";
            txtKilosProcesados.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtKilosProcesados.Properties.DisplayFormat.FormatString = "###,###0.00 kg";
        }

        private void IniciarCampos()
        {
            MakeDataTablePorcentaje();
            addPorcentajeCalibres();
            MakeDataTableKilos();
            addKilosCalibres();
            MakeDataTablePrecios();
            addPreciosCalibres();
            spAño.EditValue = Convert.ToString(DateTime.Now.Year);
            txtTemporada.Text = TemporadaActual();
            CargarAcopiadores(null);
            spSemana.EditValue = SemanaActual();
            icmbTipoFecha.EditValue = 1;

        }
        private void CargarAcopiadores(int? Valor)
        {
            CLS_PedidosMedicion bMtdMuestreo = new CLS_PedidosMedicion();
            bMtdMuestreo.MtdSeleccionarAcopiadores();
            if (bMtdMuestreo.Exito)
            {
                CargarCombo(bMtdMuestreo.Datos, Valor);
            }
        }
        private void CargarCombo(DataTable Datos, int? Valor)
        {
            lkUpAcopiador.Properties.DisplayMember = "v_nombre_zon";
            lkUpAcopiador.Properties.ValueMember = "c_codigo_zon";
            lkUpAcopiador.EditValue = Valor;
            lkUpAcopiador.Properties.DataSource = Datos;
        }
        private string TemporadaActual()
        {
            string valor = string.Empty;
            CLS_PedidosMedicion selTem = new CLS_PedidosMedicion();
            selTem.MtdSeleccionarTemporadaActual();
            if (selTem.Exito)
            {
                valor = selTem.Datos.Rows[0][0].ToString();
            }
            return valor;
        }
        private string SemanaActual()
        {
            string valor = string.Empty;
            CLS_PedidosMedicion selTem = new CLS_PedidosMedicion();
            selTem.MtdSeleccionarSemanaActual();
            if (selTem.Exito)
            {
                valor = selTem.Datos.Rows[0][0].ToString();
            }
            return valor;
        }
        private void MakeDataTablePorcentaje()
        {
            columna = new DataColumn();
            columna.DataType = typeof(string);
            columna.ColumnName = "NombreCategoria";
            columna.AutoIncrement = false;
            columna.Caption = "Nombre Categoria";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePorcentaje.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(string);
            columna.ColumnName = "NombreCalibre";
            columna.AutoIncrement = false;
            columna.Caption = "Nombre Calibre";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePorcentaje.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PedidoCajas";
            columna.AutoIncrement = false;
            columna.Caption = "Pedido Cajas";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePorcentaje.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PedidoPalet";
            columna.AutoIncrement = false;
            columna.Caption = "Pedido Palet";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePorcentaje.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeAcopio";
            columna.AutoIncrement = false;
            columna.Caption = "Acopio";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePorcentaje.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeRecepcion";
            columna.AutoIncrement = false;
            columna.Caption = "Recepcion";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePorcentaje.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeProduccion";
            columna.AutoIncrement = false;
            columna.Caption = "Produccion";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePorcentaje.Columns.Add(columna);

            dtgPorcentaje.DataSource = TablePorcentaje;
        }
        public void addPorcentajeCalibres()
        {
            //Categoria1
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "32";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "36";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "40";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "48";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "60";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "70";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "84";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat1";
            fila[1] = "96";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            //Categoria2
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "32";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "36";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "40";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "48";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "60";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "70";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "84";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Cat2";
            fila[1] = "96";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            //Nacional
            fila = TablePorcentaje.NewRow();
            fila[0] = "Nal";
            fila[1] = "Super Extra";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Nal";
            fila[1] = "Extra";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Nal";
            fila[1] = "Primera";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Nal";
            fila[1] = "Segunda";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Nal";
            fila[1] = "Comercial";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);
            fila = TablePorcentaje.NewRow();
            fila[0] = "Nal";
            fila[1] = "Desecho";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePorcentaje.Rows.Add(fila);

            dtgPorcentaje.DataSource = TablePorcentaje;

        }
        private void MakeDataTableKilos()
        {
            columna = new DataColumn();
            columna.DataType = typeof(string);
            columna.ColumnName = "NombreCategoria";
            columna.AutoIncrement = false;
            columna.Caption = "Nombre Categoria";
            columna.ReadOnly = false;
            columna.Unique = false;

            TableKilos.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(string);
            columna.ColumnName = "NombreCalibre";
            columna.AutoIncrement = false;
            columna.Caption = "Nombre Calibre";
            columna.ReadOnly = false;
            columna.Unique = false;

            TableKilos.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PedidoCajas";
            columna.AutoIncrement = false;
            columna.Caption = "Pedido Cajas";
            columna.ReadOnly = false;
            columna.Unique = false;

            TableKilos.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PedidoPalet";
            columna.AutoIncrement = false;
            columna.Caption = "Pedido Palet";
            columna.ReadOnly = false;
            columna.Unique = false;

            TableKilos.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeAcopio";
            columna.AutoIncrement = false;
            columna.Caption = "Acopio";
            columna.ReadOnly = false;
            columna.Unique = false;

            TableKilos.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeRecepcion";
            columna.AutoIncrement = false;
            columna.Caption = "Recepcion";
            columna.ReadOnly = false;
            columna.Unique = false;

            TableKilos.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeProduccion";
            columna.AutoIncrement = false;
            columna.Caption = "Produccion";
            columna.ReadOnly = false;
            columna.Unique = false;

            TableKilos.Columns.Add(columna);

            dtgKilos.DataSource = TableKilos;
        }
        public void addKilosCalibres()
        {
            //Categoria1
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "32";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "36";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "40";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "48";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "60";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "70";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "84";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat1";
            fila[1] = "96";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            //Categoria2
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "32";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "36";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "40";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "48";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "60";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "70";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "84";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Cat2";
            fila[1] = "96";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            //Nacional
            fila = TableKilos.NewRow();
            fila[0] = "Nal";
            fila[1] = "Super Extra";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Nal";
            fila[1] = "Extra";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Nal";
            fila[1] = "Primera";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Nal";
            fila[1] = "Segunda";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Nal";
            fila[1] = "Comercial";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);
            fila = TableKilos.NewRow();
            fila[0] = "Nal";
            fila[1] = "Desecho";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TableKilos.Rows.Add(fila);

            dtgKilos.DataSource = TableKilos;

        }
        private void MakeDataTablePrecios()
        {
            columna = new DataColumn();
            columna.DataType = typeof(string);
            columna.ColumnName = "NombreCategoria";
            columna.AutoIncrement = false;
            columna.Caption = "Nombre Categoria";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePrecios.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(string);
            columna.ColumnName = "NombreCalibre";
            columna.AutoIncrement = false;
            columna.Caption = "Nombre Calibre";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePrecios.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PedidoCajas";
            columna.AutoIncrement = false;
            columna.Caption = "Pedido Cajas";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePrecios.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PedidoPalet";
            columna.AutoIncrement = false;
            columna.Caption = "Pedido Palet";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePrecios.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeAcopio";
            columna.AutoIncrement = false;
            columna.Caption = "Acopio";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePrecios.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeRecepcion";
            columna.AutoIncrement = false;
            columna.Caption = "Recepcion";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePrecios.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = typeof(decimal);
            columna.ColumnName = "PorcentajeProduccion";
            columna.AutoIncrement = false;
            columna.Caption = "Produccion";
            columna.ReadOnly = false;
            columna.Unique = false;

            TablePrecios.Columns.Add(columna);

            dtgPrecios.DataSource = TablePrecios;
        }
        public void addPreciosCalibres()
        {
            //Categoria1
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "32";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "36";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "40";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "48";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "60";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "70";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "84";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat1";
            fila[1] = "96";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            //Categoria2
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "32";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "36";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "40";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "48";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "60";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "70";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "84";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Cat2";
            fila[1] = "96";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            //Nacional
            fila = TablePrecios.NewRow();
            fila[0] = "Nal";
            fila[1] = "Super Extra";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Nal";
            fila[1] = "Extra";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Nal";
            fila[1] = "Primera";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Nal";
            fila[1] = "Segunda";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Nal";
            fila[1] = "Comercial";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);
            fila = TablePrecios.NewRow();
            fila[0] = "Nal";
            fila[1] = "Desecho";
            fila[2] = "0";
            fila[3] = "0";
            fila[4] = "0";
            fila[5] = "0";
            fila[6] = "0";
            TablePrecios.Rows.Add(fila);

            dtgPrecios.DataSource = TablePrecios;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(spAño.Text) > 2000 || chkRegistros.Checked == true)
            {
                if ((Convert.ToInt32(spSemana.Text) > 0 && Convert.ToInt32(spSemana.Text) < 52) || chkRegistros.Checked == true)
                {
                    if (txtTemporada.Text != string.Empty)
                    {
                        if (Convert.ToDecimal(sePeso.EditValue.ToString()) > 0)
                        {
                            if (icmbTipoFecha.EditValue != null)
                            {
                                CLS_PedidosMedicion selpor = new CLS_PedidosMedicion();
                                selpor.Tipo_Fecha = Convert.ToInt32(icmbTipoFecha.EditValue);
                                selpor.c_codigo_tem = txtTemporada.Text;
                                if (chkRegistros.Checked == false)
                                {
                                    selpor.Year = spAño.Text;
                                    selpor.Week = Convert.ToInt32(spSemana.Text);
                                    if (lkUpAcopiador.EditValue != null)
                                    {
                                        selpor.Acopiador = lkUpAcopiador.EditValue.ToString();
                                    }
                                    else
                                    {
                                        selpor.Acopiador = string.Empty;
                                    }
                                    selpor.MtdSeleccionarPorcentajes();
                                }
                                else
                                {
                                    selpor.MtdSeleccionarPorcentajesTodos();
                                }

                                if (selpor.Exito)
                                {
                                    if (selpor.Datos.Rows.Count > 0 && !string.IsNullOrEmpty(selpor.Datos.Rows[0][0].ToString()))
                                    {
                                        CargarPedidos();
                                        CargarPorcentajes(selpor.Datos);
                                        Estibas = SeleccionarEstibas();
                                        CargarKilosAcopio();
                                        CargarPreciosAcopio();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("No existen Resultados para mostrar");
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show(selpor.Mensaje);
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Seleccione un tipo de Fecha");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ingrese un peso de caja valido o mayor a 0");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ingrese una temporada");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Ingrese un semana Valida");
                }
            }
            else
            {
                XtraMessageBox.Show("Ingrese un Año mayor a 2000");
            }
        }
        private void CargarPreciosAcopio()
        {
            decimal PreciokgVenta = PrecioVenta();
            decimal PreciokgLiquidacion = PrecioLiquidacion();
            decimal PreciokgBanda = PrecioBanda();

            txtPrecioKgLiquidacion.Text = PreciokgLiquidacion.ToString();
            txtPrecioKgBanda.Text = PreciokgBanda.ToString();
            txtPrecioKgVenta.Text = PreciokgVenta.ToString();

            for (int i = 0; i < dtgValKilos.RowCount - 3; i++)
            {
                string vCalibre = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                string vCategoria = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                decimal vCajas = decimal.Round(Convert.ToDecimal(dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"]).ToString()), 4);
                decimal vPalets = decimal.Round(Convert.ToDecimal(dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"]).ToString()), 4);
                decimal vAcopio = decimal.Round(Convert.ToDecimal(dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"]).ToString()), 4);
                decimal vRecepcion = decimal.Round(Convert.ToDecimal(dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"]).ToString()), 4);
                decimal vProduccion = decimal.Round(Convert.ToDecimal(dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"]).ToString()), 4);
                if (vCategoria == "Cat1")
                {
                    if (vCalibre == "32")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "32" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "36")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "36" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "40")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "40" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "48")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "48" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "60")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "60" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "70")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "70" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "84")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "84" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "96")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "96" && vCategoriaKg == "Cat1")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                }

                if (vCategoria == "Cat2")
                {
                    if (vCalibre == "32")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "32" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "36")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "36" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "40")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "40" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "48")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "48" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "60")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "60" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "70")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "70" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "84")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "84" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "96")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "96" && vCategoriaKg == "Cat2")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                }
                if (vCategoria == "Nal")
                {


                    if (vCalibre == "Super Extra")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Super Extra" && vCategoriaKg == "Nal")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Extra")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Extra" && vCategoriaKg == "Nal")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Primera")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Primera" && vCategoriaKg == "Nal")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Segunda")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Segunda" && vCategoriaKg == "Nal")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Comercial")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Comercial" && vCategoriaKg == "Nal")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Desecho")
                    {
                        for (int j = 0; j < dtgValPrecios.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Desecho" && vCategoriaKg == "Nal")
                            {
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoCajas"], vCajas * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PedidoPalet"], vPalets * PreciokgVenta);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeAcopio"], vAcopio * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeRecepcion"], vRecepcion * PreciokgLiquidacion);
                                dtgValPrecios.SetRowCellValue(i, dtgValPrecios.Columns["PorcentajeProduccion"], vProduccion * PreciokgBanda);
                                break;
                            }
                        }
                    }
                }
            }

        }
        private void CargarKilosAcopio()
        {
            decimal TotalKilosPedidos = KilosPedidos();
            decimal TotalKilosAcopio = Convert.ToInt32(sePeso.EditValue) * AcopioCajas;
            decimal TotalKilosRecepcion = Convert.ToInt32(sePeso.EditValue) * RecepcionCajas;
            decimal TotalKilosProceso = KilosProcesados();

            txtKilosPedido.Text = TotalKilosPedidos.ToString();
            txtKilosAcopio.Text = TotalKilosAcopio.ToString();
            txtKilosRecepcion.Text = TotalKilosRecepcion.ToString();
            txtKilosProcesados.Text = TotalKilosProceso.ToString();
            for (int i = 0; i < dtgValPorcentaje.RowCount - 3; i++)
            {
                string vCalibre = dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["NombreCalibre"]).ToString();
                string vCategoria = dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["NombreCategoria"]).ToString();
                decimal vCajas = decimal.Round(Convert.ToDecimal(dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"]).ToString()), 4);
                decimal vPalets = decimal.Round(Convert.ToDecimal(dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"]).ToString()), 4);
                decimal vAcopio = decimal.Round(Convert.ToDecimal(dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"]).ToString()), 4);
                decimal vRecepcion = decimal.Round(Convert.ToDecimal(dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"]).ToString()), 4);
                decimal vProduccion = decimal.Round(Convert.ToDecimal(dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"]).ToString()), 4);
                if (vCategoria == "Cat1")
                {
                    if (vCalibre == "32")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "32" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "36")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "36" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "40")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "40" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "48")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "48" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "60")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "60" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "70")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "70" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "84")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "84" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "96")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "96" && vCategoriaKg == "Cat1")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                }

                if (vCategoria == "Cat2")
                {
                    if (vCalibre == "32")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "32" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "36")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "36" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "40")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "40" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "48")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "48" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "60")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "60" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "70")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "70" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "84")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "84" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "96")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "96" && vCategoriaKg == "Cat2")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                }
                if (vCategoria == "Nal")
                {


                    if (vCalibre == "Super Extra")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Super Extra" && vCategoriaKg == "Nal")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Extra")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Extra" && vCategoriaKg == "Nal")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Primera")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Primera" && vCategoriaKg == "Nal")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Segunda")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Segunda" && vCategoriaKg == "Nal")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Comercial")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Comercial" && vCategoriaKg == "Nal")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                    if (vCalibre == "Desecho")
                    {
                        for (int j = 0; j < dtgValKilos.RowCount - 3; j++)
                        {
                            string vCalibreKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCalibre"]).ToString();
                            string vCategoriaKg = dtgValKilos.GetRowCellValue(i, dtgValKilos.Columns["NombreCategoria"]).ToString();
                            if (vCalibreKg == "Desecho" && vCategoriaKg == "Nal")
                            {
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoCajas"], vCajas * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PedidoPalet"], vPalets * TotalKilosPedidos);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeAcopio"], vAcopio * TotalKilosAcopio);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeRecepcion"], vRecepcion * TotalKilosRecepcion);
                                dtgValKilos.SetRowCellValue(i, dtgValKilos.Columns["PorcentajeProduccion"], vProduccion * TotalKilosProceso);
                                break;
                            }
                        }
                    }
                }
            }

        }

        private decimal PrecioBanda()
        {
            decimal kilosPedidos = 0;
            CLS_PedidosMedicion selkgpro = new CLS_PedidosMedicion();
            selkgpro.Elementos = Estibas;
            selkgpro.c_codigo_tem = txtTemporada.Text;
            selkgpro.MtdSeleccionarPrecioKgBanda();
            if (selkgpro.Exito)
            {
                if (selkgpro.Datos.Rows.Count > 0)
                {
                    kilosPedidos = Convert.ToDecimal(selkgpro.Datos.Rows[0][0]);
                }
            }
            else
            {
                XtraMessageBox.Show(selkgpro.Mensaje);
            }
            return kilosPedidos;
        }
        private decimal PrecioLiquidacion()
        {
            decimal kilosProcesados = 0;
            CLS_PedidosMedicion selkgpro = new CLS_PedidosMedicion();
            selkgpro.Elementos = Estibas;
            selkgpro.c_codigo_tem = txtTemporada.Text;
            selkgpro.MtdSeleccionarPrecioKgLiquidacion();
            if (selkgpro.Exito)
            {
                if (selkgpro.Datos.Rows.Count > 0)
                {
                    kilosProcesados = Convert.ToDecimal(selkgpro.Datos.Rows[0][0]);
                }
            }
            else
            {
                XtraMessageBox.Show(selkgpro.Mensaje);
            }
            return kilosProcesados;
        }
        private decimal PrecioVenta()
        {
            decimal kilosProcesados = 0;
            CLS_PedidosMedicion selkgpro = new CLS_PedidosMedicion();
            selkgpro.Elementos = Estibas;
            selkgpro.c_codigo_tem = txtTemporada.Text;
            selkgpro.MtdSeleccionarPrecioKgVenta();
            if (selkgpro.Exito)
            {
                if (selkgpro.Datos.Rows.Count > 0)
                {
                    kilosProcesados = Convert.ToDecimal(selkgpro.Datos.Rows[0][0]);
                }
            }
            else
            {
                XtraMessageBox.Show(selkgpro.Mensaje);
            }
            return kilosProcesados;
        }
        private decimal KilosPedidos()
        {
            decimal kilosPedidos = 0;
            CLS_PedidosMedicion selkgpro = new CLS_PedidosMedicion();
            selkgpro.Elementos = Estibas;
            selkgpro.c_codigo_tem = txtTemporada.Text;
            selkgpro.MtdSeleccionarKilosPedidos();
            if (selkgpro.Exito)
            {
                if (selkgpro.Datos.Rows.Count > 0)
                {
                    kilosPedidos = Convert.ToDecimal(selkgpro.Datos.Rows[0][0]);
                }
            }
            else
            {
                XtraMessageBox.Show(selkgpro.Mensaje);
            }
            return kilosPedidos;
        }
        private decimal KilosProcesados()
        {
            decimal kilosProcesados = 0;
            CLS_PedidosMedicion selkgpro = new CLS_PedidosMedicion();
            selkgpro.Elementos = Estibas;
            selkgpro.c_codigo_tem = txtTemporada.Text;
            selkgpro.MtdSeleccionarKilosProcesados();
            if (selkgpro.Exito)
            {
                if (selkgpro.Datos.Rows.Count > 0)
                {
                    kilosProcesados = Convert.ToDecimal(selkgpro.Datos.Rows[0][0]);
                }
            }
            else
            {
                XtraMessageBox.Show(selkgpro.Mensaje);
            }
            return kilosProcesados;
        }

        private string SeleccionarEstibas()
        {
            CLS_PedidosMedicion selpor = new CLS_PedidosMedicion();
            selpor.Tipo_Fecha = Convert.ToInt32(icmbTipoFecha.EditValue);
            selpor.c_codigo_tem = txtTemporada.Text;
            if (chkRegistros.Checked == false)
            {
                selpor.Year = spAño.Text;
                selpor.Week = Convert.ToInt32(spSemana.Text);
                if (lkUpAcopiador.EditValue != null)
                {
                    selpor.Acopiador = lkUpAcopiador.EditValue.ToString();
                }
                else
                {
                    selpor.Acopiador = string.Empty;
                }
                selpor.MtdSeleccionarEstibas();
            }
            else
            {
                selpor.MtdSeleccionarEstibasTodas();
            }
            if (selpor.Exito)
            {
                if (selpor.Datos.Rows.Count > 0)
                {
                    Elementos = string.Empty;
                    for (int i = 0; i < selpor.Datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            Elementos = selpor.Datos.Rows[i][0].ToString();
                        }
                        else
                        {
                            Elementos = Elementos + "," + selpor.Datos.Rows[i][0].ToString();
                        }
                    }
                }
            }
            return Elementos;
        }

        private void CargarPedidos()
        {
            CLS_PedidosMedicion selpor = new CLS_PedidosMedicion();
            selpor.MtdSeleccionarPedidos();
            if (selpor.Exito)
            {
                if (selpor.Datos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgValPorcentaje.RowCount - 3; i++)
                    {
                        string vCalibre = dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["NombreCalibre"]).ToString();
                        string vCategoria = dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["NombreCategoria"]).ToString();
                        if (vCategoria == "Cat1")
                        {
                            if (vCalibre == "32")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "32" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "36")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "36" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "40")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "40" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "48")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "48" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "60")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "60" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "70")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "70" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "84")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "84" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "96")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "96" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 1")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                        }
                        if (vCategoria == "Cat2")
                        {
                            if (vCalibre == "32")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "32" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "36")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "36" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "40")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "40" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "48")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "48" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "60")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "60" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "70")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "70" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "84")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "84" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                            if (vCalibre == "96")
                            {
                                for (int j = 0; j < selpor.Datos.Rows.Count; j++)
                                {
                                    if (selpor.Datos.Rows[j]["v_calibres"].ToString() == "96" && selpor.Datos.Rows[j]["v_codext_prc"].ToString() == "CAT 2")
                                    {
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoCajas"], Convert.ToDecimal(selpor.Datos.Rows[j]["PCajas"]) / 100);
                                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PedidoPalet"], Convert.ToDecimal(selpor.Datos.Rows[j]["PPalets"]) / 100);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CargarPorcentajes(DataTable datos)
        {
            AcopioCajas = Convert.ToInt32(datos.Rows[0]["EstCajas"]);
            RecepcionCajas = Convert.ToInt32(datos.Rows[0]["RecibCajas"]);
            //Porcentajes Acopio
            Acopio32Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est32"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio36Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est36"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio40Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est40"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio48Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est48"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio60Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est60"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio70Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est70"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio84Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est84"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio96Cat1 = (Convert.ToDecimal(datos.Rows[0]["Est96"]) * Convert.ToDecimal(datos.Rows[0]["EstCat1"])) / 100;
            Acopio32Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est32"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            Acopio36Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est36"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            Acopio40Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est40"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            Acopio48Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est48"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            Acopio60Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est60"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            Acopio70Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est70"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            Acopio84Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est84"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            Acopio96Cat2 = (Convert.ToDecimal(datos.Rows[0]["Est96"]) * Convert.ToDecimal(datos.Rows[0]["EstCat2"])) / 100;
            AcopioSExtraNal = (Convert.ToDecimal(datos.Rows[0]["Est40"]) * Convert.ToDecimal(datos.Rows[0]["EstNal"])) / 100;
            AcopioExtraNal = (Convert.ToDecimal(datos.Rows[0]["Est48"]) * Convert.ToDecimal(datos.Rows[0]["EstNal"])) / 100;
            AcopioPrimeraNal = (Convert.ToDecimal(datos.Rows[0]["Est60"]) * Convert.ToDecimal(datos.Rows[0]["EstNal"])) / 100;
            AcopioSegundaNal = (Convert.ToDecimal(datos.Rows[0]["Est70"]) * Convert.ToDecimal(datos.Rows[0]["EstNal"])) / 100;
            AcopioComercialNal = (Convert.ToDecimal(datos.Rows[0]["Est84"]) * Convert.ToDecimal(datos.Rows[0]["EstNal"])) / 100;
            AcopioDesechoNal = (Convert.ToDecimal(datos.Rows[0]["Est96"]) * Convert.ToDecimal(datos.Rows[0]["EstNal"])) / 100;

            //Porcentajes Recepcion
            Recepcion32Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec32"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion36Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec36"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion40Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec40"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion48Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec48"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion60Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec60"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion70Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec70"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion84Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec84"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion96Cat1 = (Convert.ToDecimal(datos.Rows[0]["Rec96"]) * Convert.ToDecimal(datos.Rows[0]["RecCat1"])) / 100;
            Recepcion32Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec32"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            Recepcion36Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec36"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            Recepcion40Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec40"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            Recepcion48Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec48"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            Recepcion60Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec60"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            Recepcion70Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec70"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            Recepcion84Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec84"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            Recepcion96Cat2 = (Convert.ToDecimal(datos.Rows[0]["Rec96"]) * Convert.ToDecimal(datos.Rows[0]["RecCat2"])) / 100;
            RecepcionSExtraNal = (Convert.ToDecimal(datos.Rows[0]["Rec40"]) * Convert.ToDecimal(datos.Rows[0]["RecNal"])) / 100;
            RecepcionExtraNal = (Convert.ToDecimal(datos.Rows[0]["Rec48"]) * Convert.ToDecimal(datos.Rows[0]["RecNal"])) / 100;
            RecepcionPrimeraNal = (Convert.ToDecimal(datos.Rows[0]["Rec60"]) * Convert.ToDecimal(datos.Rows[0]["RecNal"])) / 100;
            RecepcionSegundaNal = (Convert.ToDecimal(datos.Rows[0]["Rec70"]) * Convert.ToDecimal(datos.Rows[0]["RecNal"])) / 100;
            RecepcionComercialNal = (Convert.ToDecimal(datos.Rows[0]["Rec84"]) * Convert.ToDecimal(datos.Rows[0]["RecNal"])) / 100;
            RecepcionDesechoNal = (Convert.ToDecimal(datos.Rows[0]["Rec96"]) * Convert.ToDecimal(datos.Rows[0]["RecNal"])) / 100;

            //Porcentajes Produccion
            Produccion32Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro32"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion36Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro36"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion40Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro40"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion48Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro48"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion60Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro60"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion70Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro70"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion84Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro84"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion96Cat1 = (Convert.ToDecimal(datos.Rows[0]["Pro96"]) * Convert.ToDecimal(datos.Rows[0]["ProCat1"])) / 100;
            Produccion32Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro32"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            Produccion36Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro36"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            Produccion40Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro40"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            Produccion48Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro48"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            Produccion60Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro60"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            Produccion70Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro70"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            Produccion84Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro84"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            Produccion96Cat2 = (Convert.ToDecimal(datos.Rows[0]["Pro96"]) * Convert.ToDecimal(datos.Rows[0]["ProCat2"])) / 100;
            ProduccionSExtraNal = (Convert.ToDecimal(datos.Rows[0]["Pro40"]) * Convert.ToDecimal(datos.Rows[0]["ProNal"])) / 100;
            ProduccionExtraNal = (Convert.ToDecimal(datos.Rows[0]["Pro48"]) * Convert.ToDecimal(datos.Rows[0]["ProNal"])) / 100;
            ProduccionPrimeraNal = (Convert.ToDecimal(datos.Rows[0]["Pro60"]) * Convert.ToDecimal(datos.Rows[0]["ProNal"])) / 100;
            ProduccionSegundaNal = (Convert.ToDecimal(datos.Rows[0]["Pro70"]) * Convert.ToDecimal(datos.Rows[0]["ProNal"])) / 100;
            ProduccionComercialNal = (Convert.ToDecimal(datos.Rows[0]["Pro84"]) * Convert.ToDecimal(datos.Rows[0]["ProNal"])) / 100;
            ProduccionDesechoNal = (Convert.ToDecimal(datos.Rows[0]["Pro96"]) * Convert.ToDecimal(datos.Rows[0]["ProNal"])) / 100;

            //leer e insertar en una gridcontrol
            for (int i = 0; i < dtgValPorcentaje.RowCount - 3; i++)
            {
                string vCalibre = dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["NombreCalibre"]).ToString();
                string vCategoria = dtgValPorcentaje.GetRowCellValue(i, dtgValPorcentaje.Columns["NombreCategoria"]).ToString();
                if (vCategoria == "Cat1")
                {
                    if (vCalibre == "32")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio32Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion32Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion32Cat1 / 100);
                    }
                    if (vCalibre == "36")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio36Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion36Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion36Cat1 / 100);
                    }
                    if (vCalibre == "40")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio40Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion40Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion40Cat1 / 100);
                    }
                    if (vCalibre == "48")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio48Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion48Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion48Cat1 / 100);
                    }
                    if (vCalibre == "60")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio60Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion60Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion60Cat1 / 100);
                    }
                    if (vCalibre == "70")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio70Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion70Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion70Cat1 / 100);
                    }
                    if (vCalibre == "84")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio84Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion84Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion84Cat1 / 100);
                    }
                    if (vCalibre == "96")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio96Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion96Cat1 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion96Cat1 / 100);
                    }
                }
                if (vCategoria == "Cat2")
                {
                    if (vCalibre == "32")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio32Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion32Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion32Cat2 / 100);
                    }
                    if (vCalibre == "36")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio36Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion36Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion36Cat2 / 100);
                    }
                    if (vCalibre == "40")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio40Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion40Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion40Cat2 / 100);
                    }
                    if (vCalibre == "48")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio48Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion48Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion48Cat2 / 100);
                    }
                    if (vCalibre == "60")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio60Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion60Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion60Cat2 / 100);
                    }
                    if (vCalibre == "70")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio70Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion70Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion70Cat2 / 100);
                    }
                    if (vCalibre == "84")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio84Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion84Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion84Cat2 / 100);
                    }
                    if (vCalibre == "96")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], Acopio96Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], Recepcion96Cat2 / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], Produccion96Cat2 / 100);
                    }
                }
                if (vCategoria == "Nal")
                {
                    if (vCalibre == "Super Extra")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], AcopioSExtraNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], RecepcionSExtraNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], ProduccionSExtraNal / 100);
                    }
                    if (vCalibre == "Extra")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], AcopioExtraNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], RecepcionExtraNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], ProduccionExtraNal / 100);
                    }
                    if (vCalibre == "Primera")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], AcopioPrimeraNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], RecepcionPrimeraNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], ProduccionPrimeraNal / 100);
                    }
                    if (vCalibre == "Segunda")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], AcopioSegundaNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], RecepcionSegundaNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], ProduccionSegundaNal / 100);
                    }
                    if (vCalibre == "Comercial")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], AcopioComercialNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], RecepcionComercialNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], ProduccionComercialNal / 100);
                    }
                    if (vCalibre == "Desecho")
                    {
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeAcopio"], AcopioDesechoNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeRecepcion"], RecepcionDesechoNal / 100);
                        dtgValPorcentaje.SetRowCellValue(i, dtgValPorcentaje.Columns["PorcentajeProduccion"], ProduccionDesechoNal / 100);
                    }
                }
            }

        }

        private void chkRegistros_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegistros.Checked == false)
            {
                spAño.Enabled = true;
                spSemana.Enabled = true;
                lkUpAcopiador.Enabled = true;
            }
            else
            {
                spAño.Enabled = false;
                spSemana.Enabled = false;
                lkUpAcopiador.Enabled = false;
            }
        }

        private void spSemana_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(spSemana.EditValue.ToString()))
            {
                CLS_PedidosMedicion selpor = new CLS_PedidosMedicion();
                selpor.Year = spAño.Text;
                selpor.Week = Convert.ToInt32(spSemana.Text);
                selpor.MtdSeleccionarRangoFechas();
                if (selpor.Exito)
                {
                    if (selpor.Datos.Rows.Count > 0)
                    {
                        dtDesde.EditValue = Convert.ToDateTime(selpor.Datos.Rows[0][0]);
                        dtHasta.EditValue = Convert.ToDateTime(selpor.Datos.Rows[0][1]);
                    }
                }
            }
        }
    }
}
