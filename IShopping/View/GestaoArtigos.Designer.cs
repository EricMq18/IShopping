namespace IShopping.View
{
    partial class GestaoArtigos
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
            this.cbSelectCategoria = new System.Windows.Forms.ComboBox();
            this.txtNameArtigo = new System.Windows.Forms.TextBox();
            this.btnAddArtigo = new System.Windows.Forms.Button();
            this.btnDeleteArtigo = new System.Windows.Forms.Button();
            this.btnEditArtigo = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.cbPesquisar = new System.Windows.Forms.ComboBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstArtigos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nome :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Lista de Artigos";
            // 
            // cbSelectCategoria
            // 
            this.cbSelectCategoria.FormattingEnabled = true;
            this.cbSelectCategoria.Location = new System.Drawing.Point(361, 152);
            this.cbSelectCategoria.Name = "cbSelectCategoria";
            this.cbSelectCategoria.Size = new System.Drawing.Size(172, 24);
            this.cbSelectCategoria.TabIndex = 21;
            // 
            // txtNameArtigo
            // 
            this.txtNameArtigo.Location = new System.Drawing.Point(361, 124);
            this.txtNameArtigo.Name = "txtNameArtigo";
            this.txtNameArtigo.Size = new System.Drawing.Size(309, 22);
            this.txtNameArtigo.TabIndex = 20;
            // 
            // btnAddArtigo
            // 
            this.btnAddArtigo.Location = new System.Drawing.Point(436, 192);
            this.btnAddArtigo.Name = "btnAddArtigo";
            this.btnAddArtigo.Size = new System.Drawing.Size(165, 23);
            this.btnAddArtigo.TabIndex = 19;
            this.btnAddArtigo.Text = "Adicionar";
            this.btnAddArtigo.UseVisualStyleBackColor = true;
            this.btnAddArtigo.Click += new System.EventHandler(this.btnAddArtigo_Click);
            // 
            // btnDeleteArtigo
            // 
            this.btnDeleteArtigo.Location = new System.Drawing.Point(436, 250);
            this.btnDeleteArtigo.Name = "btnDeleteArtigo";
            this.btnDeleteArtigo.Size = new System.Drawing.Size(165, 23);
            this.btnDeleteArtigo.TabIndex = 18;
            this.btnDeleteArtigo.Text = "Eliminar";
            this.btnDeleteArtigo.UseVisualStyleBackColor = true;
            this.btnDeleteArtigo.Click += new System.EventHandler(this.btnDeleteArtigo_Click);
            // 
            // btnEditArtigo
            // 
            this.btnEditArtigo.Location = new System.Drawing.Point(439, 221);
            this.btnEditArtigo.Name = "btnEditArtigo";
            this.btnEditArtigo.Size = new System.Drawing.Size(162, 23);
            this.btnEditArtigo.TabIndex = 17;
            this.btnEditArtigo.Text = "Guardar Alterações";
            this.btnEditArtigo.UseVisualStyleBackColor = true;
            this.btnEditArtigo.Click += new System.EventHandler(this.btnEditArtigo_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(542, 49);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(128, 23);
            this.btnPesquisar.TabIndex = 15;
            this.btnPesquisar.Text = "Procurar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // cbPesquisar
            // 
            this.cbPesquisar.FormattingEnabled = true;
            this.cbPesquisar.Location = new System.Drawing.Point(361, 49);
            this.cbPesquisar.Name = "cbPesquisar";
            this.cbPesquisar.Size = new System.Drawing.Size(175, 24);
            this.cbPesquisar.TabIndex = 14;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(28, 49);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(321, 22);
            this.txtPesquisar.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Gestão Artigos";
            // 
            // lstArtigos
            // 
            this.lstArtigos.FormattingEnabled = true;
            this.lstArtigos.ItemHeight = 16;
            this.lstArtigos.Location = new System.Drawing.Point(28, 105);
            this.lstArtigos.Name = "lstArtigos";
            this.lstArtigos.Size = new System.Drawing.Size(321, 356);
            this.lstArtigos.TabIndex = 24;
            this.lstArtigos.SelectedIndexChanged += new System.EventHandler(this.lstArtigos_SelectedIndexChanged);
            // 
            // GestaoArtigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 478);
            this.Controls.Add(this.lstArtigos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSelectCategoria);
            this.Controls.Add(this.txtNameArtigo);
            this.Controls.Add(this.btnAddArtigo);
            this.Controls.Add(this.btnDeleteArtigo);
            this.Controls.Add(this.btnEditArtigo);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.cbPesquisar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.label1);
            this.Name = "GestaoArtigos";
            this.Text = "GestaoArtigos";
            this.Load += new System.EventHandler(this.GestaoArtigos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSelectCategoria;
        private System.Windows.Forms.TextBox txtNameArtigo;
        private System.Windows.Forms.Button btnAddArtigo;
        private System.Windows.Forms.Button btnDeleteArtigo;
        private System.Windows.Forms.Button btnEditArtigo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ComboBox cbPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstArtigos;
    }
}