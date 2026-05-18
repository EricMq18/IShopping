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
            this.btnAddCategoria = new System.Windows.Forms.Button();
            this.btnDeleteCategoria = new System.Windows.Forms.Button();
            this.btnEditCategoria = new System.Windows.Forms.Button();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 153);
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
            this.txtNameCategoria.Location = new System.Drawing.Point(369, 172);
            this.txtNameCategoria.Name = "txtNameCategoria";
            this.txtNameCategoria.Size = new System.Drawing.Size(270, 22);
            this.txtNameCategoria.TabIndex = 28;
            // 
            // btnAddCategoria
            // 
            this.btnAddCategoria.Location = new System.Drawing.Point(369, 200);
            this.btnAddCategoria.Name = "btnAddCategoria";
            this.btnAddCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnAddCategoria.TabIndex = 27;
            this.btnAddCategoria.Text = "Adicionar";
            this.btnAddCategoria.UseVisualStyleBackColor = true;
            this.btnAddCategoria.Click += new System.EventHandler(this.btnAddCategoria_Click);
            // 
            // btnDeleteCategoria
            // 
            this.btnDeleteCategoria.Location = new System.Drawing.Point(369, 116);
            this.btnDeleteCategoria.Name = "btnDeleteCategoria";
            this.btnDeleteCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCategoria.TabIndex = 26;
            this.btnDeleteCategoria.Text = "Eliminar";
            this.btnDeleteCategoria.UseVisualStyleBackColor = true;
            this.btnDeleteCategoria.Click += new System.EventHandler(this.btnDeleteCategoria_Click);
            // 
            // btnEditCategoria
            // 
            this.btnEditCategoria.Location = new System.Drawing.Point(369, 87);
            this.btnEditCategoria.Name = "btnEditCategoria";
            this.btnEditCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnEditCategoria.TabIndex = 25;
            this.btnEditCategoria.Text = "Editar";
            this.btnEditCategoria.UseVisualStyleBackColor = true;
            this.btnEditCategoria.Click += new System.EventHandler(this.btnEditCategoria_Click);
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(28, 87);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.RowHeadersWidth = 51;
            this.dgvCategorias.RowTemplate.Height = 24;
            this.dgvCategorias.Size = new System.Drawing.Size(335, 362);
            this.dgvCategorias.TabIndex = 24;
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
            // GestaoCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 478);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameCategoria);
            this.Controls.Add(this.btnAddCategoria);
            this.Controls.Add(this.btnDeleteCategoria);
            this.Controls.Add(this.btnEditCategoria);
            this.Controls.Add(this.dgvCategorias);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GestaoCategorias";
            this.Text = "GestaoCategorias";
            this.Load += new System.EventHandler(this.GestaoCategorias_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameCategoria;
        private System.Windows.Forms.Button btnAddCategoria;
        private System.Windows.Forms.Button btnDeleteCategoria;
        private System.Windows.Forms.Button btnEditCategoria;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Label label1;
    }
}