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
    public partial class Frm_Calibres : DevExpress.XtraEditors.XtraForm
    {
        public string c_codigo_usu { get; set; }

        public Frm_Calibres()
        {
            InitializeComponent();
        }
        private static Frm_Calibres m_FormDefInstance;
        public static Frm_Calibres DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Calibres();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
       
        

        public void mtdBuscarPais(string valCodigo, string ValNombre)
        {
            CLS_Pais selpais = new CLS_Pais();
            selpais.c_codigo_pai = valCodigo;
            selpais.v_nombre_pai = ValNombre;
            selpais.MtdSeleccionarCodigoNombre();
            if (selpais.Exito)
            {
                if (selpais.Datos.Rows.Count > 0)
                {
                    txtCodigoPai.Text = selpais.Datos.Rows[0][0].ToString();
                    txtNombrePai.Text = selpais.Datos.Rows[0][1].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(selpais.Mensaje);
            }
        }
        public void mtdBuscarTratamiento(string valCodigo, string ValNombre)
        {
            CLS_Tratamiento seltratamiento = new CLS_Tratamiento();
            seltratamiento.c_codigo_tra = valCodigo;
            seltratamiento.v_nombre_tra = ValNombre;
            seltratamiento.MtdSeleccionarCodigoNombre();
            if (seltratamiento.Exito)
            {
                if (seltratamiento.Datos.Rows.Count > 0)
                {
                    txtCodigoTra.Text = seltratamiento.Datos.Rows[0][0].ToString();
                    txtNombreTra.Text = seltratamiento.Datos.Rows[0][1].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(seltratamiento.Mensaje);
            }
        }
        public void mtdBuscarCategorias(string valCodigo, string ValNombre)
        {
            CLS_Categorias selCategorias = new CLS_Categorias();
            selCategorias.c_codigo_cat = valCodigo;
            selCategorias.v_nombre_cat = ValNombre;
            selCategorias.MtdSeleccionarCodigoNombre();
            if (selCategorias.Exito)
            {
                if (selCategorias.Datos.Rows.Count > 0)
                {
                    txtCodigoCat.Text = selCategorias.Datos.Rows[0][0].ToString();
                    txtNombreCat.Text = selCategorias.Datos.Rows[0][1].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(selCategorias.Mensaje);
            }
        }

        private void txtCodigoPai_TextChanged(object sender, EventArgs e)
        {
            txtNombrePai.Text = string.Empty;
        }
        private void txtCodigoCat_TextChanged(object sender, EventArgs e)
        {
            txtNombreCat.Text = string.Empty;
        }
        private void txtCodigoTra_TextChanged(object sender, EventArgs e)
        {
            txtNombreTra.Text = string.Empty;
        }

        private void btnImpCategoria_Click(object sender, EventArgs e)
        {
            Frm_Categorias aa = new Frm_Categorias();
            aa.c_codigo_usu = c_codigo_usu;
            aa.FrmCalibre = this;
            aa.Width = 1000;
            aa.MaximizeBox = true;
            aa.MinimizeBox = false;
            aa.Height = 650;
            aa.Top = (Screen.PrimaryScreen.WorkingArea.Height - aa.Height) / 2;
            aa.Left = (Screen.PrimaryScreen.WorkingArea.Width - aa.Width) / 2;
            aa.WindowState = System.Windows.Forms.FormWindowState.Normal;
            aa.ShowDialog();
        }
        private void btnImpPais_Click(object sender, EventArgs e)
        {
            Frm_Pais aa = new Frm_Pais();
            aa.c_codigo_usu = c_codigo_usu;
            aa.FrmCalibre = this;
            aa.Width = 1000;
            aa.MaximizeBox = true;
            aa.MinimizeBox = false;
            aa.Height = 650;
            aa.Top = (Screen.PrimaryScreen.WorkingArea.Height - aa.Height) / 2;
            aa.Left = (Screen.PrimaryScreen.WorkingArea.Width - aa.Width) / 2;
            aa.WindowState = System.Windows.Forms.FormWindowState.Normal;
            aa.ShowDialog();
        }
        private void btnImpTratamiento_Click(object sender, EventArgs e)
        {
            Frm_Tratamiento aa = new Frm_Tratamiento();
            aa.c_codigo_usu = c_codigo_usu;
            aa.FrmCalibre = this;
            aa.Width = 1000;
            aa.MaximizeBox = true;
            aa.MinimizeBox = false;
            aa.Height = 650;
            aa.Top = (Screen.PrimaryScreen.WorkingArea.Height - aa.Height) / 2;
            aa.Left = (Screen.PrimaryScreen.WorkingArea.Width - aa.Width) / 2;
            aa.WindowState = System.Windows.Forms.FormWindowState.Normal;
            aa.ShowDialog();
        }

        private void SiguienteFoco(int Actual)
        {
            switch (Actual)
            {
                case 0:
                    txtCodigoCal.Focus();
                    break;
                case 1:
                    txtNombreCal.Focus();
                    break;
                case 2:
                    txtCodigoPai.Focus();
                    break;
                case 3:
                    txtCodigoCat.Focus();
                    break;
                case 4:
                    txtCodigoTra.Focus();
                    break;
                case 5:
                    spDesde.Focus();
                    break;
                case 6:
                    spHasta.Focus();
                    break;
            }
        }
        
        private void txtCodigoCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SiguienteFoco(1);
            }
        }
        private void txtNombreCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SiguienteFoco(2);
            }
        }
        private void txtCodigoPai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoPai.Text != string.Empty)
                {
                    mtdBuscarPais(txtCodigoPai.Text, txtNombrePai.Text);
                }
                SiguienteFoco(3);
            }
        }
        private void txtCodigoCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoCat.Text != string.Empty)
                {
                    mtdBuscarCategorias(txtCodigoCat.Text, txtNombreCat.Text);
                }
                SiguienteFoco(4);
            }
        }
        private void txtCodigoTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtCodigoTra.Text != string.Empty)
                {
                    mtdBuscarTratamiento(txtCodigoTra.Text, txtNombreTra.Text);
                }
                SiguienteFoco(5);
            }
        }

        private void spDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SiguienteFoco(6);
            }
        }

        private void spHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SiguienteFoco(0);
            }
        }
    }
}