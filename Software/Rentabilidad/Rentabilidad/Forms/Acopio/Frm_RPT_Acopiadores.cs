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
    public partial class Frm_RPT_Acopiadores : DevExpress.XtraEditors.XtraForm
    {
        public Frm_RPT_Acopiadores()
        {
            InitializeComponent();
        }
        private static Frm_RPT_Acopiadores m_FormDefInstance;
        private int FilaSelect;

        public static Frm_RPT_Acopiadores DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_RPT_Acopiadores();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public string c_codigo_usu { get; internal set; }
        public string Acopiador { get; private set; }

        private void CargarAcopiadores(int? Valor)
        {
            CLS_Acopio bAcpopiadores = new CLS_Acopio();
            bAcpopiadores.MtdSeleccionarAcopiadores();
            if (bAcpopiadores.Exito)
            {
                CargarCombo(bAcpopiadores.Datos, Valor);
            }
        }
        private void CargarCombo(DataTable Datos, int? Valor)
        {
            lkUpAcopiador.Properties.DisplayMember = "c_acopiador_Cal";
            lkUpAcopiador.Properties.ValueMember = "c_codigo_zon";
            lkUpAcopiador.EditValue = Valor;
            lkUpAcopiador.Properties.DataSource = Datos;
        }

        private void Frm_RPT_Acopiadores_Shown(object sender, EventArgs e)
        {
            CargarAcopiadores(null);
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(chkTodos.Checked==false)
            {
                if(lkUpAcopiador.EditValue!=null)
                {
                    Acopiador = lkUpAcopiador.EditValue.ToString();
                }
            }
        }
    }
}