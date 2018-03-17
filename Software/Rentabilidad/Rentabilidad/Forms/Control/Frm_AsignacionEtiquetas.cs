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
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;

namespace Rentabilidad
{
    public partial class Frm_AsignacionEtiquetas : DevExpress.XtraEditors.XtraForm
    {
        public string c_codigo_usu { get; set; }
        public string c_codigo_tem { get; set; }
        public Frm_AsignacionEtiquetas()
        {
            InitializeComponent();
        }
        private static Frm_AsignacionEtiquetas m_FormDefInstance;
        private int FilaSelect;
        private bool isEditEtiquetas;
        PrinterSettings ImpresoraActual = new PrinterSettings();
        
        private int PrimeraEti;
        private int SegundaEti;

        public static Frm_AsignacionEtiquetas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_AsignacionEtiquetas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void btnImportarEmpleado_Click(object sender, EventArgs e)
        {
            Frm_Empleados aa = new Frm_Empleados();
            aa.c_codigo_usu = c_codigo_usu;
            aa.FrmAsignacionEtiquetas = this;
            aa.Width = 1000;
            aa.MaximizeBox = true;
            aa.MinimizeBox = false;
            aa.Height = 650;
            aa.Top = (Screen.PrimaryScreen.WorkingArea.Height - aa.Height) / 2;
            aa.Left = (Screen.PrimaryScreen.WorkingArea.Width - aa.Width) / 2;
            aa.WindowState = System.Windows.Forms.FormWindowState.Normal;
            aa.ShowDialog();
        }
        public void mtdBuscarEmpleado(string valCodigo, string ValNombre)
        {
            CLS_Empleado selEmpleado = new CLS_Empleado();
            selEmpleado.c_codigo_emp = valCodigo;
            selEmpleado.v_nombre_empacador = ValNombre;
            selEmpleado.MtdSeleccionarCodigoNombre();
            if (selEmpleado.Exito)
            {
                if (selEmpleado.Datos.Rows.Count > 0)
                {
                    txtCodigoEmp.Text = selEmpleado.Datos.Rows[0][0].ToString();
                    txtNombreEmp.Text = selEmpleado.Datos.Rows[0][1].ToString();
                    txtCantidad.Focus();
                }
                else
                {
                    XtraMessageBox.Show("No se Encontraron registros");
                }
            }
            else
            {
                XtraMessageBox.Show(selEmpleado.Mensaje);
            }
        }
        public void mtdBuscarTemporada()
        {
            CLS_Folio selFolio = new CLS_Folio();
            selFolio.MtdSeleccionarTemporada();
            if (selFolio.Exito)
            {
                if (selFolio.Datos.Rows.Count > 0)
                {
                    c_codigo_tem = selFolio.Datos.Rows[0][0].ToString();
                }
                else
                {
                    XtraMessageBox.Show("No se Encontraron Temporada Activa");
                }
            }
            else
            {
                XtraMessageBox.Show(selFolio.Mensaje);
            }
        }
        public void mtdBuscarFolio()
        {
            CLS_Folio selFolio = new CLS_Folio();
            selFolio.c_codigo_tem = c_codigo_tem;
            selFolio.MtdSeleccionarFolio();
            if (selFolio.Exito)
            {
                if (selFolio.Datos.Rows.Count > 0)
                {
                    txtDesde.Text = selFolio.Datos.Rows[0][0].ToString();
                }
                else
                {
                    XtraMessageBox.Show("No se Encontraron Temporada Activa");
                }
            }
            else
            {
                XtraMessageBox.Show(selFolio.Mensaje);
            }
        }
        private void txtCodigoEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoEmp.Text != string.Empty)
                {
                    mtdBuscarEmpleado(txtCodigoEmp.Text, txtNombreEmp.Text);
                }
            }
        }
        private void txtNombreEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoEmp.Text != string.Empty)
                {
                    mtdBuscarEmpleado(txtCodigoEmp.Text, txtNombreEmp.Text);
                }
            }
        }
        private void Frm_AsignacionEtiquetas_Shown(object sender, EventArgs e)
        {
            isEditEtiquetas = false;
            mtdBuscarTemporada();
            mtdBuscarFolio();
            CargarFolio();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            Validar_Campos valida = new Validar_Campos();
            valida.Solo_Numeros(sender, e, txtCantidad.Text);
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != string.Empty)
            {
                txtHasta.Text = Convert.ToString(Convert.ToInt32(txtDesde.Text) - 1 + Convert.ToInt32(txtCantidad.Text));
                if (!isEditEtiquetas)
                {
                    txtEttiquetaRest.Text = Convert.ToString(Convert.ToInt32(txtCantidad.Text));
                }
            }
            else
            {
                txtEttiquetaRest.Text = string.Empty;
                txtHasta.Text = string.Empty;
            }
        }

        public void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
            mtdBuscarTemporada();
            mtdBuscarFolio();
            CargarFolio();
            BloquearCampos(true);
        }

        private void CargarFolio()
        {
            CLS_Folio insFolio = new CLS_Folio();
            insFolio.MtdSeleccionar();
            if (insFolio.Exito)
            {
                dtgFolios.DataSource = insFolio.Datos;
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoEmp.Text = string.Empty;
            txtNombreEmp.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;
            txtEttiquetaRest.Text = string.Empty;
            txtCodigoEmp.Focus();
        }

        protected void btnAsignar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validar_campos())
            {
                CLS_Folio insFolio = new CLS_Folio();
                insFolio.c_codigo_emp = txtCodigoEmp.Text;
                insFolio.n_folio_inicio = Convert.ToInt32(txtDesde.Text);
                insFolio.n_folio_fin = Convert.ToInt32(txtHasta.Text);
                insFolio.n_etiquetas_restantes = Convert.ToInt32(txtEttiquetaRest.Text);
                insFolio.c_codigo_usu = c_codigo_usu;
                insFolio.c_codigo_tem = c_codigo_tem;
                insFolio.MtdInsertar();
                if (insFolio.Exito)
                {
                    if (insFolio.Datos.Rows.Count > 0)
                    {
                        dtgFolios.DataSource = insFolio.Datos;
                        XtraMessageBox.Show("Folios asignados con exito");
                        LimpiarCampos();
                        DialogResult = XtraMessageBox.Show("¿Desea imprimir las etiquetas?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (DialogResult == DialogResult.Yes)
                        {

                        }
                    }
                }
            }
        }

        private Boolean validar_campos()
        {
            Boolean Valor = true;
            if (txtCodigoEmp.Text != string.Empty && txtNombreEmp.Text != string.Empty)
            {
                if (Convert.ToInt32(txtCantidad.Text) > 0 && Convert.ToInt32(txtCantidad.Text) % 2 == 0)
                {
                    Valor = true;
                }
                else
                {
                    XtraMessageBox.Show("La cantidad de etiquetas debe ser mayor a 0 o la cantidad debe ser Par");
                    Valor = false;
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha definido Empacador");
                Valor = false;
            }
            return Valor;
        }

        private void txtCodigoEmp_TextChanged(object sender, EventArgs e)
        {
            txtNombreEmp.Text = string.Empty;
        }

        private void dtgFolios_Click(object sender, EventArgs e)
        {
            MtdSubeDatos();
            BloquearCampos(false);
        }

        private void BloquearCampos(Boolean Valor)
        {
            txtCodigoEmp.Enabled = Valor;
            txtNombreEmp.Enabled = Valor;
            txtCantidad.Enabled = Valor;
            btnImportarEmpleado.Enabled = Valor;
        }

        private void MtdSubeDatos()
        {
            try
            {
                foreach (int i in this.dtgValFolios.GetSelectedRows())
                {
                    FilaSelect = i;
                    isEditEtiquetas = true;
                    DataRow row = dtgValFolios.GetDataRow(i);
                    txtCodigoEmp.Text = row["c_codigo_emp"].ToString();
                    txtNombreEmp.Text = row["v_nombre_empacador"].ToString();
                    txtDesde.Text = row["n_folio_inicio"].ToString();
                    txtHasta.Text = row["n_folio_fin"].ToString();
                    txtCantidad.Text = row["n_total"].ToString();
                    txtEttiquetaRest.Text = row["n_etiquetas_restantes"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Folio udpFolio = new CLS_Folio();
            udpFolio.c_codigo_emp = txtCodigoEmp.Text;
            udpFolio.n_etiquetas_restantes = Convert.ToInt32(txtEttiquetaRest.Text);
            udpFolio.b_folio_cerrado = 1;
            udpFolio.c_codigo_usu = c_codigo_usu;
            udpFolio.n_folio_inicio = Convert.ToInt32(txtDesde.Text);
            udpFolio.n_folio_fin = Convert.ToInt32(txtHasta.Text);
            udpFolio.c_codigo_tem = c_codigo_tem;
            udpFolio.MtdActualizar();
            if (udpFolio.Exito)
            {
                XtraMessageBox.Show("Se ha actualizado el registro con exito");
            }
            btnLimpiar.PerformClick();
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Folio insFolio = new CLS_Folio();
            insFolio.c_codigo_emp = txtCodigoEmp.Text;
            insFolio.v_nombre_empacador = txtNombreEmp.Text;
            insFolio.MtdSeleccionarCN();
            if (insFolio.Exito)
            {
                if (insFolio.Datos.Rows.Count > 0)
                {
                    dtgFolios.DataSource = insFolio.Datos;
                }
            }
        }
        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrimeraEti = Convert.ToInt32(txtDesde.Text);
            SegundaEti = PrimeraEti + 1;
            vistaprevia();
            for (int i = Convert.ToInt32(txtDesde.Text); i < Convert.ToInt32(txtHasta.Text); i++)
            {
                PrimeraEti = i;
                i++;
                SegundaEti = i;
                prdoDocumento.Print();
                Thread.Sleep(100);
            }
        }
        private void ConfiguraEtiqueta()
        {
            short vAncho = 310;
            short vAlto = 63;
            PaperSize TamañoPersonal = new PaperSize();
            try
            {
                TamañoPersonal = new PaperSize("personal", vAncho, vAlto);

                prdoDocumento.PrinterSettings = ImpresoraActual;
                prdoDocumento.DefaultPageSettings.PaperSize = TamañoPersonal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK);
            }
        }
        private void CreaCodigoBarras(string Cadena, string AltoTamaño)
        {
            if (Cadena == string.Empty)
            {
                MessageBox.Show("No existe Codigo a Generar");
            }
            else
            {
                try
                {
                    Single alto = 0;
                    if (AltoTamaño != string.Empty)
                    {
                        alto = Convert.ToSingle(AltoTamaño);
                    }
                    Bitmap bm = Codigos.Codigos128(Cadena, false, alto);
                    pictureEdit2.Image = bm;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void prdoDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            ConfiguraEtiqueta();
            Font font;
            font = new Font("Arial", 8, GraphicsUnit.Pixel);
            var tabDataForeColor = System.Drawing.Color.Black;
            //Bitmap bitmap1;
            CreaCodigoBarras(PrimeraEti.ToString(), "30");
            e.Graphics.DrawImage(pictureEdit2.Image, 10, 5, 122, 40);
            CreaCodigoBarras(SegundaEti.ToString(), "30");
            e.Graphics.DrawImage(pictureEdit2.Image, 175, 5, 122, 40);
            e.Graphics.DrawString(PrimeraEti.ToString(), font, new SolidBrush(tabDataForeColor), 60, 50);
            e.Graphics.DrawString(SegundaEti.ToString(), font, new SolidBrush(tabDataForeColor), 230, 50);
            e.HasMorePages = false;
        }
        private void vistaprevia()
        {
            ((ToolStripButton)((ToolStrip)ppdDocumento.Controls[1]).Items[0]).Visible = false;
            //PrintDialog printDialog1 = new PrintDialog();
            //printDialog1.Document = prdoDocumento;
            //printDialog1.PrinterSettings.Copies = 1;
            //DialogResult result = printDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
                ConfiguraEtiqueta();
                ppdDocumento.FindForm().StartPosition = FormStartPosition.CenterScreen;
                ppdDocumento.ShowDialog(this);
           // }
        }
    }
}