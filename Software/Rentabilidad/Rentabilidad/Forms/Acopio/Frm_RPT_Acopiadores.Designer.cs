namespace Rentabilidad
{
    partial class Frm_RPT_Acopiadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RPT_Acopiadores));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnBonos = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.lkUpAcopiador = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ProgressB = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.chkTodos = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.RPT_Viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkUpAcopiador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(1055, 170);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnBonos);
            this.groupControl1.Controls.Add(this.btnLimpiar);
            this.groupControl1.Controls.Add(this.lkUpAcopiador);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.ProgressB);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dtFin);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dtInicio);
            this.groupControl1.Controls.Add(this.radioGroup1);
            this.groupControl1.Controls.Add(this.chkTodos);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1039, 154);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Parametros - Fecha de Corte";
            // 
            // btnBonos
            // 
            this.btnBonos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBonos.ImageOptions.Image")));
            this.btnBonos.Location = new System.Drawing.Point(586, 39);
            this.btnBonos.Name = "btnBonos";
            this.btnBonos.Size = new System.Drawing.Size(102, 45);
            this.btnBonos.TabIndex = 13;
            this.btnBonos.Text = "Bonos";
            this.btnBonos.Click += new System.EventHandler(this.btnBonos_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(694, 39);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 45);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lkUpAcopiador
            // 
            this.lkUpAcopiador.EditValue = "Selecciones Acopiador";
            this.lkUpAcopiador.Location = new System.Drawing.Point(121, 41);
            this.lkUpAcopiador.Name = "lkUpAcopiador";
            this.lkUpAcopiador.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkUpAcopiador.Properties.NullText = "Seleccione Acopiador";
            this.lkUpAcopiador.Properties.View = this.gridLookUpEdit1View;
            this.lkUpAcopiador.Size = new System.Drawing.Size(211, 20);
            this.lkUpAcopiador.TabIndex = 11;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Codigo";
            this.gridColumn3.FieldName = "c_codigo_zon";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Acopiador";
            this.gridColumn4.FieldName = "c_acopiador_Cal";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(59, 122);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Progreso";
            // 
            // ProgressB
            // 
            this.ProgressB.EditValue = 50;
            this.ProgressB.Location = new System.Drawing.Point(121, 119);
            this.ProgressB.Name = "ProgressB";
            this.ProgressB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ProgressB.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ProgressB.Size = new System.Drawing.Size(325, 18);
            this.ProgressB.TabIndex = 9;
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(478, 39);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(102, 45);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(72, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Hasta";
            // 
            // dtFin
            // 
            this.dtFin.EditValue = new System.DateTime(2018, 3, 12, 10, 20, 50, 0);
            this.dtFin.Location = new System.Drawing.Point(121, 93);
            this.dtFin.Name = "dtFin";
            this.dtFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Size = new System.Drawing.Size(100, 20);
            this.dtFin.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(72, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Desde";
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = new System.DateTime(2018, 3, 12, 10, 20, 45, 0);
            this.dtInicio.Location = new System.Drawing.Point(121, 67);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Size = new System.Drawing.Size(100, 20);
            this.dtInicio.TabIndex = 4;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(350, 67);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Concetrado"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Detallado")});
            this.radioGroup1.Size = new System.Drawing.Size(96, 46);
            this.radioGroup1.TabIndex = 3;
            // 
            // chkTodos
            // 
            this.chkTodos.Location = new System.Drawing.Point(350, 42);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Properties.Caption = "Todos";
            this.chkTodos.Size = new System.Drawing.Size(75, 19);
            this.chkTodos.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(43, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Acopiadores";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.RPT_Viewer);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 170);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(1055, 270);
            this.panelControl2.TabIndex = 1;
            // 
            // RPT_Viewer
            // 
            this.RPT_Viewer.ActiveViewIndex = -1;
            this.RPT_Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPT_Viewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPT_Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPT_Viewer.Location = new System.Drawing.Point(8, 8);
            this.RPT_Viewer.Name = "RPT_Viewer";
            this.RPT_Viewer.ShowCloseButton = false;
            this.RPT_Viewer.ShowCopyButton = false;
            this.RPT_Viewer.ShowGroupTreeButton = false;
            this.RPT_Viewer.ShowLogo = false;
            this.RPT_Viewer.ShowParameterPanelButton = false;
            this.RPT_Viewer.ShowTextSearchButton = false;
            this.RPT_Viewer.Size = new System.Drawing.Size(1039, 254);
            this.RPT_Viewer.TabIndex = 0;
            this.RPT_Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_RPT_Acopiadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 440);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_RPT_Acopiadores";
            this.Text = "Reporte Acopiadores";
            this.Shown += new System.EventHandler(this.Frm_RPT_Acopiadores_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkUpAcopiador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtFin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.CheckEdit chkTodos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ProgressBarControl ProgressB;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPT_Viewer;
        private DevExpress.XtraEditors.GridLookUpEdit lkUpAcopiador;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraEditors.SimpleButton btnBonos;
    }
}