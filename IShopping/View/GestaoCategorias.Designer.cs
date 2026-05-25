namespace IShopping.View
{
    partial class GestaoCategorias
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstCategorias = new System.Windows.Forms.ListBox();
            this.btnAddCategoria = new System.Windows.Forms.Button();
            this.btnDeleteCategoria = new System.Windows.Forms.Button();
            this.btnEditCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Nome :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Lista de Categorias";
            // 
            // txtNameCategoria
            // 
            this.txtNameCategoria.Location = new System.Drawing.Point(297, 112);
            this.txtNameCategoria.Name = "txtNameCategoria";
            this.txtNameCategoria.Size = new System.Drawing.Size(270, 22);
            this.txtNameCategoria.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Gestão Tipo de Artigos";
            // 
            // lstCategorias
            // 
            this.lstCategorias.FormattingEnabled = true;
            this.lstCategorias.ItemHeight = 16;
            this.lstCategorias.Location = new System.Drawing.Point(28, 93);
            this.lstCategorias.Name = "lstCategorias";
            this.lstCategorias.Size = new System.Drawing.Size(263, 356);
            this.lstCategorias.TabIndex = 31;
            this.lstCategorias.SelectedIndexChanged += new System.EventHandler(this.lstCategorias_SelectedIndexChanged);
            // 
            // btnAddCategoria
            // 
            this.btnAddCategoria.Location = new System.Drawing.Point(351, 150);
            this.btnAddCategoria.Name = "btnAddCategoria";
            this.btnAddCategoria.Size = new System.Drawing.Size(165, 23);
            this.btnAddCategoria.TabIndex = 34;
            this.btnAddCategoria.Text = "Adicionar";
            this.btnAddCategoria.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategoria
            // 
            this.btnDeleteCategoria.Location = new System.Drawing.Point(351, 208);
            this.btnDeleteCategoria.Name = "btnDeleteCategoria";
            this.btnDeleteCategoria.Size = new System.Drawing.Size(165, 23);
            this.btnDeleteCategoria.TabIndex = 33;
            this.btnDeleteCategoria.Text = "Eliminar";
            this.btnDeleteCategoria.UseVisualStyleBackColor = true;
            // 
            // btnEditCategoria
            // 
            this.btnEditCategoria.Location = new System.Drawing.Point(354, 179);
            this.btnEditCategoria.Name = "btnEditCategoria";
            this.btnEditCategoria.Size = new System.Drawing.Size(162, 23);
            this.btnEditCategoria.TabIndex = 32;
            this.btnEditCategoria.Text = "Guardar alterações";
            this.btnEditCategoria.UseVisualStyleBackColor = true;
            // 
            // GestaoCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 478);
            this.Controls.Add(this.btnAddCategoria);
            this.Controls.Add(this.btnDeleteCategoria);
            this.Controls.Add(this.btnEditCategoria);
            this.Controls.Add(this.lstCategorias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameCategoria);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GestaoCategorias";
            this.Text = "GestaoCategorias";
            this.Load += new System.EventHandler(this.GestaoCategorias_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstCategorias;
        private System.Windows.Forms.Button btnAddCategoria;
        private System.Windows.Forms.Button btnDeleteCategoria;
        private System.Windows.Forms.Button btnEditCategoria;
    }
}