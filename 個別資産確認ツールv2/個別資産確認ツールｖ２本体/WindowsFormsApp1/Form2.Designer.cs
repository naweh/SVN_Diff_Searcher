namespace WindowsFormsApp1
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CM_選択 = new System.Windows.Forms.Button();
            this.CM_取消 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LST_対象資産 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ユーザ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.コメント = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.選択 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CM_選択
            // 
            this.CM_選択.Location = new System.Drawing.Point(509, 415);
            this.CM_選択.Name = "CM_選択";
            this.CM_選択.Size = new System.Drawing.Size(75, 23);
            this.CM_選択.TabIndex = 0;
            this.CM_選択.Text = "選択";
            this.CM_選択.UseVisualStyleBackColor = true;
            this.CM_選択.Click += new System.EventHandler(this.CM_選択_Click);
            // 
            // CM_取消
            // 
            this.CM_取消.Location = new System.Drawing.Point(590, 415);
            this.CM_取消.Name = "CM_取消";
            this.CM_取消.Size = new System.Drawing.Size(75, 23);
            this.CM_取消.TabIndex = 0;
            this.CM_取消.Text = "取消";
            this.CM_取消.UseVisualStyleBackColor = true;
            this.CM_取消.Click += new System.EventHandler(this.CM_取消_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ユーザ,
            this.時刻,
            this.コメント,
            this.選択});
            this.dataGridView1.Location = new System.Drawing.Point(6, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(659, 200);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // LST_対象資産
            // 
            this.LST_対象資産.FormattingEnabled = true;
            this.LST_対象資産.ItemHeight = 12;
            this.LST_対象資産.Location = new System.Drawing.Point(6, 241);
            this.LST_対象資産.Name = "LST_対象資産";
            this.LST_対象資産.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LST_対象資産.Size = new System.Drawing.Size(659, 160);
            this.LST_対象資産.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Folder / File Path";
            // 
            // No
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.Frozen = true;
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 48;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 48;
            // 
            // ユーザ
            // 
            this.ユーザ.HeaderText = "ユーザ";
            this.ユーザ.MinimumWidth = 80;
            this.ユーザ.Name = "ユーザ";
            this.ユーザ.ReadOnly = true;
            this.ユーザ.Width = 80;
            // 
            // 時刻
            // 
            this.時刻.HeaderText = "時刻";
            this.時刻.Name = "時刻";
            this.時刻.ReadOnly = true;
            // 
            // コメント
            // 
            this.コメント.HeaderText = "コメント";
            this.コメント.MinimumWidth = 390;
            this.コメント.Name = "コメント";
            this.コメント.ReadOnly = true;
            this.コメント.Width = 390;
            // 
            // 選択
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.選択.DefaultCellStyle = dataGridViewCellStyle3;
            this.選択.HeaderText = "";
            this.選択.MinimumWidth = 28;
            this.選択.Name = "選択";
            this.選択.ReadOnly = true;
            this.選択.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.選択.Text = "";
            this.選択.ToolTipText = "コミットされた資産一覧を表示します";
            this.選択.Width = 28;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LST_対象資産);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CM_取消);
            this.Controls.Add(this.CM_選択);
            this.MaximumSize = new System.Drawing.Size(693, 489);
            this.MinimumSize = new System.Drawing.Size(693, 489);
            this.Name = "Form2";
            this.Text = "リビジョンの選択";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CM_選択;
        private System.Windows.Forms.Button CM_取消;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox LST_対象資産;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ユーザ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 時刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn コメント;
        private System.Windows.Forms.DataGridViewButtonColumn 選択;
    }
}