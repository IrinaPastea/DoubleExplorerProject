
namespace Total_Commander
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_partitie_1 = new System.Windows.Forms.ComboBox();
            this.lv_locatie_1 = new System.Windows.Forms.ListView();
            this.tb_path_1 = new System.Windows.Forms.TextBox();
            this.lv_locatie_2 = new System.Windows.Forms.ListView();
            this.cb_partitie_2 = new System.Windows.Forms.ComboBox();
            this.tb_path_2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cb_partitie_1
            // 
            this.cb_partitie_1.FormattingEnabled = true;
            this.cb_partitie_1.Location = new System.Drawing.Point(0, 0);
            this.cb_partitie_1.Name = "cb_partitie_1";
            this.cb_partitie_1.Size = new System.Drawing.Size(49, 23);
            this.cb_partitie_1.TabIndex = 0;
            this.cb_partitie_1.SelectedIndexChanged += new System.EventHandler(this.cb_partitions_1_SelectedIndexChanged);
            // 
            // lv_locatie_1
            // 
            this.lv_locatie_1.HideSelection = false;
            this.lv_locatie_1.Location = new System.Drawing.Point(0, 56);
            this.lv_locatie_1.Name = "lv_locatie_1";
            this.lv_locatie_1.Size = new System.Drawing.Size(121, 97);
            this.lv_locatie_1.TabIndex = 1;
            this.lv_locatie_1.UseCompatibleStateImageBehavior = false;
            this.lv_locatie_1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_locatie_1_MouseDoubleClick);
            // 
            // tb_path_1
            // 
            this.tb_path_1.Location = new System.Drawing.Point(0, 27);
            this.tb_path_1.Name = "tb_path_1";
            this.tb_path_1.ReadOnly = true;
            this.tb_path_1.Size = new System.Drawing.Size(361, 23);
            this.tb_path_1.TabIndex = 2;
            this.tb_path_1.TextChanged += new System.EventHandler(this.tb_path_1_TextChanged);
            // 
            // lv_locatie_2
            // 
            this.lv_locatie_2.HideSelection = false;
            this.lv_locatie_2.Location = new System.Drawing.Point(975, 56);
            this.lv_locatie_2.Name = "lv_locatie_2";
            this.lv_locatie_2.Size = new System.Drawing.Size(121, 97);
            this.lv_locatie_2.TabIndex = 3;
            this.lv_locatie_2.UseCompatibleStateImageBehavior = false;
            this.lv_locatie_2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_locatie_2_MouseDoubleClick);
            // 
            // cb_partitie_2
            // 
            this.cb_partitie_2.FormattingEnabled = true;
            this.cb_partitie_2.Location = new System.Drawing.Point(1047, 0);
            this.cb_partitie_2.Name = "cb_partitie_2";
            this.cb_partitie_2.Size = new System.Drawing.Size(49, 23);
            this.cb_partitie_2.TabIndex = 4;
            this.cb_partitie_2.SelectedIndexChanged += new System.EventHandler(this.cb_partitie_2_SelectedIndexChanged);
            // 
            // tb_path_2
            // 
            this.tb_path_2.Location = new System.Drawing.Point(735, 27);
            this.tb_path_2.Name = "tb_path_2";
            this.tb_path_2.ReadOnly = true;
            this.tb_path_2.Size = new System.Drawing.Size(361, 23);
            this.tb_path_2.TabIndex = 5;
            this.tb_path_2.TextChanged += new System.EventHandler(this.tb_path_2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 686);
            this.Controls.Add(this.tb_path_2);
            this.Controls.Add(this.cb_partitie_2);
            this.Controls.Add(this.lv_locatie_2);
            this.Controls.Add(this.tb_path_1);
            this.Controls.Add(this.lv_locatie_1);
            this.Controls.Add(this.cb_partitie_1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Double File Explorer Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_partitie_1;
        private System.Windows.Forms.ListView lv_locatie_1;
        private System.Windows.Forms.TextBox tb_path_1;
        private System.Windows.Forms.ListView lv_locatie_2;
        private System.Windows.Forms.ComboBox cb_partitie_2;
        private System.Windows.Forms.TextBox tb_path_2;
    }
}

