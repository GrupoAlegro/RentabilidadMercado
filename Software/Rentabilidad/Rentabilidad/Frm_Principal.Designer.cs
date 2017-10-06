namespace Rentabilidad
{
    partial class Frm_Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnPais = new DevExpress.XtraBars.BarButtonItem();
            this.btnCategorias = new DevExpress.XtraBars.BarButtonItem();
            this.btrnCalibres = new DevExpress.XtraBars.BarButtonItem();
            this.btnTratamiento = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrecioFecha = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrecioPais = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.SkinForm = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnPais,
            this.btnCategorias,
            this.btrnCalibres,
            this.btnTratamiento,
            this.btnPrecioFecha,
            this.btnPrecioPais});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(758, 146);
            // 
            // btnPais
            // 
            this.btnPais.Caption = "Pais";
            this.btnPais.Id = 1;
            this.btnPais.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPais.ImageOptions.LargeImage")));
            this.btnPais.Name = "btnPais";
            this.btnPais.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPais_ItemClick);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Caption = "Categorias";
            this.btnCategorias.Id = 2;
            this.btnCategorias.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCategorias.ImageOptions.LargeImage")));
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategorias_ItemClick);
            // 
            // btrnCalibres
            // 
            this.btrnCalibres.Caption = "Calibres";
            this.btrnCalibres.Id = 3;
            this.btrnCalibres.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btrnCalibres.ImageOptions.LargeImage")));
            this.btrnCalibres.Name = "btrnCalibres";
            this.btrnCalibres.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btrnCalibres_ItemClick);
            // 
            // btnTratamiento
            // 
            this.btnTratamiento.Caption = "Tratamiento";
            this.btnTratamiento.Id = 4;
            this.btnTratamiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTratamiento.ImageOptions.LargeImage")));
            this.btnTratamiento.Name = "btnTratamiento";
            this.btnTratamiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTratamiento_ItemClick);
            // 
            // btnPrecioFecha
            // 
            this.btnPrecioFecha.Caption = "Precio x Fecha";
            this.btnPrecioFecha.Id = 5;
            this.btnPrecioFecha.Name = "btnPrecioFecha";
            this.btnPrecioFecha.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrecioFecha_ItemClick);
            // 
            // btnPrecioPais
            // 
            this.btnPrecioPais.Caption = "Precios x Pais";
            this.btnPrecioPais.Id = 6;
            this.btnPrecioPais.Name = "btnPrecioPais";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Catalogos";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPais);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCategorias);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTratamiento);
            this.ribbonPageGroup1.ItemLinks.Add(this.btrnCalibres);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Catalogos";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Precios";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPrecioFecha);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPrecioPais);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Precios";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Reportes";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Generales";
            // 
            // SkinForm
            // 
            this.SkinForm.LookAndFeel.SkinName = "Money Twins";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // Frm_Principal
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 545);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "Frm_Principal";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Principal_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel SkinForm;
        private DevExpress.XtraBars.BarButtonItem btnPais;
        private DevExpress.XtraBars.BarButtonItem btnCategorias;
        private DevExpress.XtraBars.BarButtonItem btrnCalibres;
        private DevExpress.XtraBars.BarButtonItem btnTratamiento;
        private DevExpress.XtraBars.BarButtonItem btnPrecioFecha;
        private DevExpress.XtraBars.BarButtonItem btnPrecioPais;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}

