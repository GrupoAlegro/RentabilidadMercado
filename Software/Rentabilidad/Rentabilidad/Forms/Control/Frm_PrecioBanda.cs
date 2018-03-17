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
    public partial class Frm_PrecioBanda : DevExpress.XtraEditors.XtraForm
    {
        private static Frm_PrecioBanda m_FormDefInstance;
        public static Frm_PrecioBanda DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_PrecioBanda();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public string c_codigo_usu { get; internal set; }

        public Frm_PrecioBanda()
        {
            InitializeComponent();
        }

        private void Frm_PrecioBanda_Shown(object sender, EventArgs e)
        {
            BuscarActualizacion();
            BuscarPreciosBanda();
            dtgValPrecioBanda.ExpandAllGroups();
        }

        private void BuscarPreciosBanda()
        {
            CLS_Precio_Banda selPrecios = new CLS_Precio_Banda();
            selPrecios.MtdSeleccionar();
            if (selPrecios.Exito)
            {
                dtgPrecioBanda.DataSource = selPrecios.Datos;
            }
        }

        private void BuscarActualizacion()
        {
            CLS_Precio_Banda selPrecios = new CLS_Precio_Banda();
            selPrecios.MtdSeleccionarActualizacion();
            if (selPrecios.Exito)
            {
                if(selPrecios.Datos.Rows.Count>0)
                {
                    dtFechaActualizacion.EditValue = Convert.ToDateTime(selPrecios.Datos.Rows[0][1]);
                }
            }
        }

        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BuscarPreciosBanda();
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Precio_Banda selPrecios = new CLS_Precio_Banda();
            selPrecios.MtdActualizar();
            if (selPrecios.Exito)
            {
                BuscarActualizacion();
                BuscarPreciosBanda();
                XtraMessageBox.Show("Se ha actualizado con exito");
            }
        }
    }
}