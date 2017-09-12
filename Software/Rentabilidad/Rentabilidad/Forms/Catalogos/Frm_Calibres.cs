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

        private void txtCodigoPai_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCodigoPai_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                if(txtCodigoPai.Text!=string.Empty)
                {
                    mtdBuscarPais(txtCodigoPai.Text,txtNombrePai.Text);
                }
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

        private void txtCodigoPai_TextChanged(object sender, EventArgs e)
        {
            txtNombrePai.Text = string.Empty;
        }

        private void Frm_Calibres_Shown(object sender, EventArgs e)
        {
            
        }
    }
}