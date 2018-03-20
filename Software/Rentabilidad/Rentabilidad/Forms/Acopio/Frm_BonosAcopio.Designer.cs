namespace Rentabilidad
{
    partial class Frm_BonosAcopio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BonosAcopio));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dtgGrupoPago = new DevExpress.XtraGrid.GridControl();
            this.dtgValGrupoPago = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgPagoCamion = new DevExpress.XtraGrid.GridControl();
            this.dtgValPagoCamion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValGrupoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCamion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPagoCamion)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(839, 344);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(20, 274);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(95, 47);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Guardar";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panelControl3);
            this.groupControl2.Location = new System.Drawing.Point(444, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(6);
            this.groupControl2.Size = new System.Drawing.Size(383, 247);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Grupos de Pago";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.dtgGrupoPago);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(8, 26);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(367, 213);
            this.panelControl3.TabIndex = 1;
            // 
            // dtgGrupoPago
            // 
            this.dtgGrupoPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgGrupoPago.Location = new System.Drawing.Point(2, 2);
            this.dtgGrupoPago.MainView = this.dtgValGrupoPago;
            this.dtgGrupoPago.Name = "dtgGrupoPago";
            this.dtgGrupoPago.Size = new System.Drawing.Size(363, 209);
            this.dtgGrupoPago.TabIndex = 1;
            this.dtgGrupoPago.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValGrupoPago});
            // 
            // dtgValGrupoPago
            // 
            this.dtgValGrupoPago.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.dtgValGrupoPago.GridControl = this.dtgGrupoPago;
            this.dtgValGrupoPago.Name = "dtgValGrupoPago";
            this.dtgValGrupoPago.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Codigo";
            this.gridColumn5.FieldName = "c_codigo_gru";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Grupo Pago";
            this.gridColumn6.FieldName = "v_grupopago";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Porcentaje";
            this.gridColumn7.FieldName = "n_porcentaje";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(6);
            this.groupControl1.Size = new System.Drawing.Size(426, 247);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Pago por Tipo Camion";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgPagoCamion);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(8, 26);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(410, 213);
            this.panelControl2.TabIndex = 0;
            // 
            // dtgPagoCamion
            // 
            this.dtgPagoCamion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPagoCamion.Location = new System.Drawing.Point(2, 2);
            this.dtgPagoCamion.MainView = this.dtgValPagoCamion;
            this.dtgPagoCamion.Name = "dtgPagoCamion";
            this.dtgPagoCamion.Size = new System.Drawing.Size(406, 209);
            this.dtgPagoCamion.TabIndex = 0;
            this.dtgPagoCamion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValPagoCamion});
            // 
            // dtgValPagoCamion
            // 
            this.dtgValPagoCamion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.dtgValPagoCamion.GridControl = this.dtgPagoCamion;
            this.dtgValPagoCamion.Name = "dtgValPagoCamion";
            this.dtgValPagoCamion.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "c_pago_camion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tipo Cambio";
            this.gridColumn2.FieldName = "v_tipo_camion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Porcentaje Pago";
            this.gridColumn3.FieldName = "n_porcentaje_pago";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Monto Pago";
            this.gridColumn4.FieldName = "n_monto_pago";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // Frm_BonosAcopio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 344);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_BonosAcopio";
            this.Text = "Frm_BonosAcopio";
            this.Shown += new System.EventHandler(this.Frm_BonosAcopio_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValGrupoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCamion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPagoCamion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl dtgGrupoPago;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValGrupoPago;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dtgPagoCamion;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValPagoCamion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}