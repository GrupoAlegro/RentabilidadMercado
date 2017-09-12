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
    public partial class Frm_Categorias : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Calibres FrmCalibre;
        int FilaSelect = 0;
        Boolean IsEditPais;
        public string c_codigo_usu { get; set; }
        public Frm_Categorias()
        {
            InitializeComponent();
        }
        private static Frm_Categorias m_FormDefInstance;
        public static Frm_Categorias DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Categorias();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void dtgCategoria_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Frm_Categorias_Shown(object sender, EventArgs e)
        {
            CLS_Categorias selcategorias = new CLS_Categorias();
            selcategorias.MtdSeleccionar();
            if (selcategorias.Exito)
            {
                dtgCategoria.DataSource = selcategorias.Datos;
            }

        }
    }
}