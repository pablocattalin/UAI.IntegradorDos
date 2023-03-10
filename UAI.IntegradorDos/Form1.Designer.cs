namespace UAI.IntegradorDos
{
    partial class Form1
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
            this.dgVInversor = new System.Windows.Forms.DataGridView();
            this.dgvInversiones = new System.Windows.Forms.DataGridView();
            this.dgvAcciones = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.txtBoxTotalClienteComun = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxPremiumHasta20 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxPremiumSupera20 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxComisionTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgVInversor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInversiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVInversor
            // 
            this.dgVInversor.AllowUserToAddRows = false;
            this.dgVInversor.AllowUserToDeleteRows = false;
            this.dgVInversor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVInversor.Location = new System.Drawing.Point(82, 69);
            this.dgVInversor.Name = "dgVInversor";
            this.dgVInversor.ReadOnly = true;
            this.dgVInversor.Size = new System.Drawing.Size(495, 150);
            this.dgVInversor.TabIndex = 0;
            this.dgVInversor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnClick_SelectedInversor);
            // 
            // dgvInversiones
            // 
            this.dgvInversiones.AllowUserToAddRows = false;
            this.dgvInversiones.AllowUserToDeleteRows = false;
            this.dgvInversiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInversiones.Location = new System.Drawing.Point(82, 299);
            this.dgvInversiones.Name = "dgvInversiones";
            this.dgvInversiones.ReadOnly = true;
            this.dgvInversiones.Size = new System.Drawing.Size(495, 150);
            this.dgvInversiones.TabIndex = 1;
            // 
            // dgvAcciones
            // 
            this.dgvAcciones.AllowUserToAddRows = false;
            this.dgvAcciones.AllowUserToDeleteRows = false;
            this.dgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcciones.Location = new System.Drawing.Point(672, 69);
            this.dgvAcciones.Name = "dgvAcciones";
            this.dgvAcciones.ReadOnly = true;
            this.dgvAcciones.Size = new System.Drawing.Size(553, 150);
            this.dgvAcciones.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(82, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Inversor Comun";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClick_AltaComun);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(183, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Inversor Premium";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnClick_AltaPremium);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(672, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Alta accion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnClick_AltaAccion);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(776, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Modificar accion";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnClick_ModificarAccion);
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(880, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Eliminar accion";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnClick_EliminarAccion);
            // 
            // button6
            // 
            this.button6.AutoSize = true;
            this.button6.Location = new System.Drawing.Point(287, 27);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Modificar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnClick_ModificarInversor);
            // 
            // button7
            // 
            this.button7.AutoSize = true;
            this.button7.Location = new System.Drawing.Point(368, 27);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Eliminar";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnClick_EliminarInversor);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(82, 261);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(108, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Comprar";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnClick_Comprar);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(205, 261);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(117, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "Vender";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btnClick_Vender);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(605, 377);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 12;
            this.button10.Text = "DatosFAke";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btnClick_CargarFake);
            // 
            // txtBoxTotalClienteComun
            // 
            this.txtBoxTotalClienteComun.Location = new System.Drawing.Point(774, 245);
            this.txtBoxTotalClienteComun.Name = "txtBoxTotalClienteComun";
            this.txtBoxTotalClienteComun.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTotalClienteComun.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Total recaudado cliente comun";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total recaudado hasta 20000 cliente premium";
            // 
            // txtBoxPremiumHasta20
            // 
            this.txtBoxPremiumHasta20.Location = new System.Drawing.Point(831, 271);
            this.txtBoxPremiumHasta20.Name = "txtBoxPremiumHasta20";
            this.txtBoxPremiumHasta20.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPremiumHasta20.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Total recaudado mas de  20000 cliente premium";
            // 
            // txtBoxPremiumSupera20
            // 
            this.txtBoxPremiumSupera20.Location = new System.Drawing.Point(842, 297);
            this.txtBoxPremiumSupera20.Name = "txtBoxPremiumSupera20";
            this.txtBoxPremiumSupera20.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPremiumSupera20.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(602, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Total comisiones";
            // 
            // txtBoxComisionTotal
            // 
            this.txtBoxComisionTotal.Location = new System.Drawing.Point(695, 323);
            this.txtBoxComisionTotal.Name = "txtBoxComisionTotal";
            this.txtBoxComisionTotal.Size = new System.Drawing.Size(100, 20);
            this.txtBoxComisionTotal.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 617);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxComisionTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxPremiumSupera20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxPremiumHasta20);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxTotalClienteComun);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvAcciones);
            this.Controls.Add(this.dgvInversiones);
            this.Controls.Add(this.dgVInversor);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgVInversor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInversiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVInversor;
        private System.Windows.Forms.DataGridView dgvInversiones;
        private System.Windows.Forms.DataGridView dgvAcciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox txtBoxTotalClienteComun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPremiumHasta20;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxPremiumSupera20;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxComisionTotal;
    }
}

