namespace Rentabilidad
{
    partial class Frm_PenalizacionAcopio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PenalizacionAcopio));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dtgPenalizacionCalibres = new DevExpress.XtraGrid.GridControl();
            this.dtgValPenalizacionCalibres = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCalibresPorcentaje = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgPenalizacionCalidad = new DevExpress.XtraGrid.GridControl();
            this.dtgValPenalizacionCalidad = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCalidadPorcentaje = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPenalizacionCalibres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPenalizacionCalibres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPenalizacionCalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPenalizacionCalidad)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnGuardar);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(839, 348);
            this.panelControl1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(22, 289);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 47);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panelControl3);
            this.groupControl2.Location = new System.Drawing.Point(444, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(6);
            this.groupControl2.Size = new System.Drawing.Size(383, 271);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Penalizacion Calibres";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.dtgPenalizacionCalibres);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(8, 26);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(367, 237);
            this.panelControl3.TabIndex = 1;
            // 
            // dtgPenalizacionCalibres
            // 
            this.dtgPenalizacionCalibres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPenalizacionCalibres.Location = new System.Drawing.Point(2, 2);
            this.dtgPenalizacionCalibres.MainView = this.dtgValPenalizacionCalibres;
            this.dtgPenalizacionCalibres.Name = "dtgPenalizacionCalibres";
            this.dtgPenalizacionCalibres.Size = new System.Drawing.Size(363, 233);
            this.dtgPenalizacionCalibres.TabIndex = 1;
            this.dtgPenalizacionCalibres.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValPenalizacionCalibres});
            // 
            // dtgValPenalizacionCalibres
            // 
            this.dtgValPenalizacionCalibres.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.ColCalibresPorcentaje});
            this.dtgValPenalizacionCalibres.GridControl = this.dtgPenalizacionCalibres;
            this.dtgValPenalizacionCalibres.Name = "dtgValPenalizacionCalibres";
            this.dtgValPenalizacionCalibres.OptionsView.ShowFooter = true;
            this.dtgValPenalizacionCalibres.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Codigo";
            this.gridColumn5.FieldName = "c_codigo_pcali";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Calibre";
            this.gridColumn6.FieldName = "v_penalizacion_pcali";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // ColCalibresPorcentaje
            // 
            this.ColCalibresPorcentaje.Caption = "Porcentaje Mayor a";
            this.ColCalibresPorcentaje.FieldName = "n_porcentaje";
            this.ColCalibresPorcentaje.Name = "ColCalibresPorcentaje";
            this.ColCalibresPorcentaje.Visible = true;
            this.ColCalibresPorcentaje.VisibleIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(6);
            this.groupControl1.Size = new System.Drawing.Size(426, 271);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Penalizacion Calidad";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgPenalizacionCalidad);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(8, 26);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(410, 237);
            this.panelControl2.TabIndex = 0;
            // 
            // dtgPenalizacionCalidad
            // 
            this.dtgPenalizacionCalidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPenalizacionCalidad.Location = new System.Drawing.Point(2, 2);
            this.dtgPenalizacionCalidad.MainView = this.dtgValPenalizacionCalidad;
            this.dtgPenalizacionCalidad.Name = "dtgPenalizacionCalidad";
            this.dtgPenalizacionCalidad.Size = new System.Drawing.Size(406, 233);
            this.dtgPenalizacionCalidad.TabIndex = 2;
            this.dtgPenalizacionCalidad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValPenalizacionCalidad});
            // 
            // dtgValPenalizacionCalidad
            // 
            this.dtgValPenalizacionCalidad.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.ColCalidadPorcentaje});
            this.dtgValPenalizacionCalidad.GridControl = this.dtgPenalizacionCalidad;
            this.dtgValPenalizacionCalidad.Name = "dtgValPenalizacionCalidad";
            this.dtgValPenalizacionCalidad.OptionsView.ShowFooter = true;
            this.dtgValPenalizacionCalidad.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "c_codigo_pcal";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Calidad";
            this.gridColumn2.FieldName = "v_penalizacion_pcal";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // ColCalidadPorcentaje
            // 
            this.ColCalidadPorcentaje.Caption = "Porcentaje Mayor a";
            this.ColCalidadPorcentaje.FieldName = "n_porcentaje";
            this.ColCalidadPorcentaje.Name = "ColCalidadPorcentaje";
            this.ColCalidadPorcentaje.Visible = true;
            this.ColCalidadPorcentaje.VisibleIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(150, 307);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(623, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Nota: Los porcentajes que se  encuentren en 0.00% no se tomaran en cuenta para pe" +
    "nalización";
            // 
            // Frm_PenalizacionAcopio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 348);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_PenalizacionAcopio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Penalizacion Acopio";
            this.Shown += new System.EventHandler(this.Frm_BonosAcopio_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPenalizacionCalibres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPenalizacionCalibres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPenalizacionCalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPenalizacionCalidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl dtgPenalizacionCalibres;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValPenalizacionCalibres;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn ColCalibresPorcentaje;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dtgPenalizacionCalidad;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValPenalizacionCalidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn ColCalidadPorcentaje;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}