namespace Rentabilidad
{
    partial class Frm_BDistribuidores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BDistribuidores));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.dtgDistribuidores = new DevExpress.XtraGrid.GridControl();
            this.dtgValDistribuidores = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.rdbTipoBusqueda = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBusqueda = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbElementos = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDistribuidores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValDistribuidores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbTipoBusqueda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbElementos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSalir);
            this.panelControl2.Controls.Add(this.btnConsultar);
            this.panelControl2.Controls.Add(this.dtgDistribuidores);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 88);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 70);
            this.panelControl2.Size = new System.Drawing.Size(634, 476);
            this.panelControl2.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Appearance.Options.UseFont = true;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.Location = new System.Drawing.Point(323, 424);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(122, 42);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Appearance.Options.UseFont = true;
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(195, 424);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(122, 42);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Seleccionar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtgDistribuidores
            // 
            this.dtgDistribuidores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDistribuidores.Location = new System.Drawing.Point(12, 12);
            this.dtgDistribuidores.MainView = this.dtgValDistribuidores;
            this.dtgDistribuidores.Name = "dtgDistribuidores";
            this.dtgDistribuidores.Size = new System.Drawing.Size(610, 392);
            this.dtgDistribuidores.TabIndex = 0;
            this.dtgDistribuidores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValDistribuidores});
            this.dtgDistribuidores.Click += new System.EventHandler(this.dtgArticulos_Click);
            // 
            // dtgValDistribuidores
            // 
            this.dtgValDistribuidores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CodigoBarras,
            this.Descripcion});
            this.dtgValDistribuidores.GridControl = this.dtgDistribuidores;
            this.dtgValDistribuidores.Name = "dtgValDistribuidores";
            this.dtgValDistribuidores.OptionsView.ShowGroupPanel = false;
            // 
            // CodigoBarras
            // 
            this.CodigoBarras.Caption = "Codigo Distribuidor";
            this.CodigoBarras.FieldName = "c_codigo_dis";
            this.CodigoBarras.Name = "CodigoBarras";
            this.CodigoBarras.OptionsColumn.AllowEdit = false;
            this.CodigoBarras.OptionsColumn.ReadOnly = true;
            this.CodigoBarras.OptionsColumn.ShowInExpressionEditor = false;
            this.CodigoBarras.Visible = true;
            this.CodigoBarras.VisibleIndex = 0;
            this.CodigoBarras.Width = 100;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Nombre Distribuidor";
            this.Descripcion.FieldName = "v_nombre_dis";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.OptionsColumn.AllowEdit = false;
            this.Descripcion.OptionsColumn.ReadOnly = true;
            this.Descripcion.OptionsColumn.ShowInExpressionEditor = false;
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 1;
            this.Descripcion.Width = 502;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.rdbTipoBusqueda);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtBusqueda);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cmbElementos);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(634, 88);
            this.panelControl1.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Tipo Busqueda:";
            // 
            // rdbTipoBusqueda
            // 
            this.rdbTipoBusqueda.Location = new System.Drawing.Point(110, 5);
            this.rdbTipoBusqueda.Name = "rdbTipoBusqueda";
            this.rdbTipoBusqueda.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdbTipoBusqueda.Properties.Appearance.Options.UseBackColor = true;
            this.rdbTipoBusqueda.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdbTipoBusqueda.Properties.Columns = 1;
            this.rdbTipoBusqueda.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Nombre Distribuidor"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Codigo Distribuidor")});
            this.rdbTipoBusqueda.Size = new System.Drawing.Size(135, 54);
            this.rdbTipoBusqueda.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Texto Busqueda:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(110, 59);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(286, 20);
            this.txtBusqueda.TabIndex = 3;
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(251, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Elementos:";
            // 
            // cmbElementos
            // 
            this.cmbElementos.Location = new System.Drawing.Point(314, 10);
            this.cmbElementos.Name = "cmbElementos";
            this.cmbElementos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbElementos.Properties.Appearance.Options.UseFont = true;
            this.cmbElementos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbElementos.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000"});
            this.cmbElementos.Size = new System.Drawing.Size(82, 20);
            this.cmbElementos.TabIndex = 1;
            // 
            // Frm_BArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 564);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_BArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de Articulos";
            this.Load += new System.EventHandler(this.Frm_BArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDistribuidores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValDistribuidores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbTipoBusqueda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusqueda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbElementos.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.GridControl dtgDistribuidores;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValDistribuidores;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup rdbTipoBusqueda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtBusqueda;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbElementos;
    }
}