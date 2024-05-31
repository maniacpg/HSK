namespace QLYCafe
{
    partial class fAdmin
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
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpBill = new System.Windows.Forms.TabPage();
            this.tpFood = new System.Windows.Forms.TabPage();
            this.tpFoodCategory = new System.Windows.Forms.TabPage();
            this.tpTable = new System.Windows.Forms.TabPage();
            this.tpAccount = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvBill = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtgvFood = new System.Windows.Forms.DataGridView();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnDelFood = new System.Windows.Forms.Button();
            this.btnEditFood = new System.Windows.Forms.Button();
            this.btnReadFood = new System.Windows.Forms.Button();
            this.txbSearchFoodName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txbFoodID = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txbFoodName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcAdmin.SuspendLayout();
            this.tpBill.SuspendLayout();
            this.tpFood.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpBill);
            this.tcAdmin.Controls.Add(this.tpFood);
            this.tcAdmin.Controls.Add(this.tpFoodCategory);
            this.tcAdmin.Controls.Add(this.tpTable);
            this.tcAdmin.Controls.Add(this.tpAccount);
            this.tcAdmin.Location = new System.Drawing.Point(12, 12);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1017, 557);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpBill
            // 
            this.tpBill.Controls.Add(this.panel2);
            this.tpBill.Controls.Add(this.panel1);
            this.tpBill.Location = new System.Drawing.Point(4, 25);
            this.tpBill.Name = "tpBill";
            this.tpBill.Padding = new System.Windows.Forms.Padding(3);
            this.tpBill.Size = new System.Drawing.Size(1009, 528);
            this.tpBill.TabIndex = 0;
            this.tpBill.Text = "Doanh thu";
            this.tpBill.UseVisualStyleBackColor = true;
            // 
            // tpFood
            // 
            this.tpFood.Controls.Add(this.panel6);
            this.tpFood.Controls.Add(this.panel5);
            this.tpFood.Controls.Add(this.panel4);
            this.tpFood.Controls.Add(this.panel3);
            this.tpFood.Location = new System.Drawing.Point(4, 25);
            this.tpFood.Name = "tpFood";
            this.tpFood.Padding = new System.Windows.Forms.Padding(3);
            this.tpFood.Size = new System.Drawing.Size(1009, 528);
            this.tpFood.TabIndex = 1;
            this.tpFood.Text = "Đồ uống";
            this.tpFood.UseVisualStyleBackColor = true;
            // 
            // tpFoodCategory
            // 
            this.tpFoodCategory.Location = new System.Drawing.Point(4, 25);
            this.tpFoodCategory.Name = "tpFoodCategory";
            this.tpFoodCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tpFoodCategory.Size = new System.Drawing.Size(1009, 528);
            this.tpFoodCategory.TabIndex = 2;
            this.tpFoodCategory.Text = "Danh mục";
            this.tpFoodCategory.UseVisualStyleBackColor = true;
            // 
            // tpTable
            // 
            this.tpTable.Location = new System.Drawing.Point(4, 25);
            this.tpTable.Name = "tpTable";
            this.tpTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpTable.Size = new System.Drawing.Size(1009, 528);
            this.tpTable.TabIndex = 3;
            this.tpTable.Text = "Bàn";
            this.tpTable.UseVisualStyleBackColor = true;
            // 
            // tpAccount
            // 
            this.tpAccount.Location = new System.Drawing.Point(4, 25);
            this.tpAccount.Name = "tpAccount";
            this.tpAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccount.Size = new System.Drawing.Size(1009, 528);
            this.tpAccount.TabIndex = 4;
            this.tpAccount.Text = "Tài khoản";
            this.tpAccount.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnViewBill);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 69);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvBill);
            this.panel2.Location = new System.Drawing.Point(7, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 440);
            this.panel2.TabIndex = 1;
            // 
            // dtgvBill
            // 
            this.dtgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBill.Location = new System.Drawing.Point(3, 3);
            this.dtgvBill.Name = "dtgvBill";
            this.dtgvBill.RowHeadersWidth = 51;
            this.dtgvBill.RowTemplate.Height = 24;
            this.dtgvBill.Size = new System.Drawing.Size(990, 434);
            this.dtgvBill.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(362, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(631, 22);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(362, 22);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // btnViewBill
            // 
            this.btnViewBill.Location = new System.Drawing.Point(462, 17);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(89, 30);
            this.btnViewBill.TabIndex = 2;
            this.btnViewBill.Text = "Thống Kê";
            this.btnViewBill.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvFood);
            this.panel3.Location = new System.Drawing.Point(6, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(575, 429);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnReadFood);
            this.panel4.Controls.Add(this.btnEditFood);
            this.panel4.Controls.Add(this.btnDelFood);
            this.panel4.Controls.Add(this.btnAddFood);
            this.panel4.Location = new System.Drawing.Point(7, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(574, 80);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(588, 96);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(415, 426);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Controls.Add(this.txbSearchFoodName);
            this.panel6.Location = new System.Drawing.Point(588, 7);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(415, 80);
            this.panel6.TabIndex = 3;
            // 
            // dtgvFood
            // 
            this.dtgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFood.Location = new System.Drawing.Point(4, 3);
            this.dtgvFood.Name = "dtgvFood";
            this.dtgvFood.RowHeadersWidth = 51;
            this.dtgvFood.RowTemplate.Height = 24;
            this.dtgvFood.Size = new System.Drawing.Size(568, 423);
            this.dtgvFood.TabIndex = 0;
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(4, 4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(92, 73);
            this.btnAddFood.TabIndex = 0;
            this.btnAddFood.Text = "Thêm";
            this.btnAddFood.UseVisualStyleBackColor = true;
            // 
            // btnDelFood
            // 
            this.btnDelFood.Location = new System.Drawing.Point(155, 4);
            this.btnDelFood.Name = "btnDelFood";
            this.btnDelFood.Size = new System.Drawing.Size(92, 73);
            this.btnDelFood.TabIndex = 0;
            this.btnDelFood.Text = "Xóa";
            this.btnDelFood.UseVisualStyleBackColor = true;
            // 
            // btnEditFood
            // 
            this.btnEditFood.Location = new System.Drawing.Point(313, 3);
            this.btnEditFood.Name = "btnEditFood";
            this.btnEditFood.Size = new System.Drawing.Size(92, 73);
            this.btnEditFood.TabIndex = 0;
            this.btnEditFood.Text = "Sửa";
            this.btnEditFood.UseVisualStyleBackColor = true;
            this.btnEditFood.Click += new System.EventHandler(this.btnEditFood_Click);
            // 
            // btnReadFood
            // 
            this.btnReadFood.Location = new System.Drawing.Point(465, 4);
            this.btnReadFood.Name = "btnReadFood";
            this.btnReadFood.Size = new System.Drawing.Size(92, 73);
            this.btnReadFood.TabIndex = 0;
            this.btnReadFood.Text = "Xem";
            this.btnReadFood.UseVisualStyleBackColor = true;
            this.btnReadFood.Click += new System.EventHandler(this.btnEditFood_Click);
            // 
            // txbSearchFoodName
            // 
            this.txbSearchFoodName.Location = new System.Drawing.Point(19, 32);
            this.txbSearchFoodName.Name = "txbSearchFoodName";
            this.txbSearchFoodName.Size = new System.Drawing.Size(276, 22);
            this.txbSearchFoodName.TabIndex = 0;
            this.txbSearchFoodName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(319, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txbFoodID);
            this.panel7.Controls.Add(this.UserName);
            this.panel7.Location = new System.Drawing.Point(19, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(384, 62);
            this.panel7.TabIndex = 2;
            // 
            // txbFoodID
            // 
            this.txbFoodID.Location = new System.Drawing.Point(55, 21);
            this.txbFoodID.Name = "txbFoodID";
            this.txbFoodID.ReadOnly = true;
            this.txbFoodID.Size = new System.Drawing.Size(320, 22);
            this.txbFoodID.TabIndex = 1;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(5, 23);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(23, 18);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "ID";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txbFoodName);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Location = new System.Drawing.Point(19, 84);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(384, 62);
            this.panel8.TabIndex = 3;
            // 
            // txbFoodName
            // 
            this.txbFoodName.Location = new System.Drawing.Point(55, 21);
            this.txbFoodName.Name = "txbFoodName";
            this.txbFoodName.ReadOnly = true;
            this.txbFoodName.Size = new System.Drawing.Size(320, 22);
            this.txbFoodName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 581);
            this.Controls.Add(this.tcAdmin);
            this.Name = "fAdmin";
            this.Text = "Admin";
            this.tcAdmin.ResumeLayout(false);
            this.tpBill.ResumeLayout(false);
            this.tpFood.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tpBill;
        private System.Windows.Forms.TabPage tpFood;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tpFoodCategory;
        private System.Windows.Forms.TabPage tpTable;
        private System.Windows.Forms.TabPage tpAccount;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvFood;
        private System.Windows.Forms.Button btnEditFood;
        private System.Windows.Forms.Button btnDelFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txbSearchFoodName;
        private System.Windows.Forms.Button btnReadFood;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txbFoodID;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txbFoodName;
        private System.Windows.Forms.Label label1;
    }
}