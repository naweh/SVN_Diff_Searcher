namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TC_出力ウィンドウ = new System.Windows.Forms.TabControl();
            this.TP_ログ = new System.Windows.Forms.TabPage();
            this.TX_ログ出力 = new System.Windows.Forms.TextBox();
            this.TP_実行結果 = new System.Windows.Forms.TabPage();
            this.TX_実行結果 = new System.Windows.Forms.TextBox();
            this.CM_フォルダ参照 = new System.Windows.Forms.Button();
            this.CM_リビジョン参照 = new System.Windows.Forms.Button();
            this.TX_対象資産 = new System.Windows.Forms.MaskedTextBox();
            this.CKL_対象リポジトリ = new System.Windows.Forms.CheckedListBox();
            this.CM_実行 = new System.Windows.Forms.Button();
            this.PIC_FileDownload = new System.Windows.Forms.PictureBox();
            this.PIC_Delete = new System.Windows.Forms.PictureBox();
            this.TC_出力ウィンドウ.SuspendLayout();
            this.TP_ログ.SuspendLayout();
            this.TP_実行結果.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_FileDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Delete)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TC_出力ウィンドウ
            // 
            this.TC_出力ウィンドウ.Controls.Add(this.TP_ログ);
            this.TC_出力ウィンドウ.Controls.Add(this.TP_実行結果);
            this.TC_出力ウィンドウ.Location = new System.Drawing.Point(18, 19);
            this.TC_出力ウィンドウ.Name = "TC_出力ウィンドウ";
            this.TC_出力ウィンドウ.SelectedIndex = 0;
            this.TC_出力ウィンドウ.Size = new System.Drawing.Size(385, 397);
            this.TC_出力ウィンドウ.TabIndex = 1;
            // 
            // TP_ログ
            // 
            this.TP_ログ.Controls.Add(this.TX_ログ出力);
            this.TP_ログ.Location = new System.Drawing.Point(4, 22);
            this.TP_ログ.Name = "TP_ログ";
            this.TP_ログ.Padding = new System.Windows.Forms.Padding(3);
            this.TP_ログ.Size = new System.Drawing.Size(377, 371);
            this.TP_ログ.TabIndex = 0;
            this.TP_ログ.Text = "ログ";
            this.TP_ログ.UseVisualStyleBackColor = true;
            // 
            // TX_ログ出力
            // 
            this.TX_ログ出力.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TX_ログ出力.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TX_ログ出力.Location = new System.Drawing.Point(2, 2);
            this.TX_ログ出力.Multiline = true;
            this.TX_ログ出力.Name = "TX_ログ出力";
            this.TX_ログ出力.ReadOnly = true;
            this.TX_ログ出力.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TX_ログ出力.Size = new System.Drawing.Size(372, 366);
            this.TX_ログ出力.TabIndex = 0;
            this.TX_ログ出力.WordWrap = false;
            // 
            // TP_実行結果
            // 
            this.TP_実行結果.Controls.Add(this.TX_実行結果);
            this.TP_実行結果.Location = new System.Drawing.Point(4, 22);
            this.TP_実行結果.Name = "TP_実行結果";
            this.TP_実行結果.Padding = new System.Windows.Forms.Padding(3);
            this.TP_実行結果.Size = new System.Drawing.Size(377, 371);
            this.TP_実行結果.TabIndex = 1;
            this.TP_実行結果.Text = "実行結果";
            this.TP_実行結果.UseVisualStyleBackColor = true;
            // 
            // TX_実行結果
            // 
            this.TX_実行結果.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TX_実行結果.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TX_実行結果.Location = new System.Drawing.Point(2, 2);
            this.TX_実行結果.Multiline = true;
            this.TX_実行結果.Name = "TX_実行結果";
            this.TX_実行結果.ReadOnly = true;
            this.TX_実行結果.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TX_実行結果.Size = new System.Drawing.Size(372, 366);
            this.TX_実行結果.TabIndex = 1;
            this.TX_実行結果.WordWrap = false;
            // 
            // CM_フォルダ参照
            // 
            this.CM_フォルダ参照.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CM_フォルダ参照.Location = new System.Drawing.Point(447, 45);
            this.CM_フォルダ参照.Name = "CM_フォルダ参照";
            this.CM_フォルダ参照.Size = new System.Drawing.Size(150, 73);
            this.CM_フォルダ参照.TabIndex = 2;
            this.CM_フォルダ参照.Text = "リリースフォルダを指定";
            this.CM_フォルダ参照.UseVisualStyleBackColor = false;
            this.CM_フォルダ参照.Click += new System.EventHandler(this.CM_フォルダ参照_Click);
            // 
            // CM_リビジョン参照
            // 
            this.CM_リビジョン参照.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CM_リビジョン参照.Location = new System.Drawing.Point(621, 45);
            this.CM_リビジョン参照.Name = "CM_リビジョン参照";
            this.CM_リビジョン参照.Size = new System.Drawing.Size(150, 73);
            this.CM_リビジョン参照.TabIndex = 2;
            this.CM_リビジョン参照.Text = "リビジョンを指定";
            this.CM_リビジョン参照.UseVisualStyleBackColor = false;
            this.CM_リビジョン参照.Click += new System.EventHandler(this.CM_リビジョン参照_Click);
            // 
            // TX_対象資産
            // 
            this.TX_対象資産.Enabled = false;
            this.TX_対象資産.Location = new System.Drawing.Point(447, 124);
            this.TX_対象資産.Name = "TX_対象資産";
            this.TX_対象資産.Size = new System.Drawing.Size(324, 19);
            this.TX_対象資産.TabIndex = 3;
            // 
            // CKL_対象リポジトリ
            // 
            this.CKL_対象リポジトリ.CheckOnClick = true;
            this.CKL_対象リポジトリ.FormattingEnabled = true;
            this.CKL_対象リポジトリ.IntegralHeight = false;
            this.CKL_対象リポジトリ.Location = new System.Drawing.Point(449, 177);
            this.CKL_対象リポジトリ.Name = "CKL_対象リポジトリ";
            this.CKL_対象リポジトリ.Size = new System.Drawing.Size(147, 234);
            this.CKL_対象リポジトリ.TabIndex = 4;
            // 
            // CM_実行
            // 
            this.CM_実行.BackColor = System.Drawing.SystemColors.Control;
            this.CM_実行.Location = new System.Drawing.Point(621, 332);
            this.CM_実行.Name = "CM_実行";
            this.CM_実行.Size = new System.Drawing.Size(150, 73);
            this.CM_実行.TabIndex = 2;
            this.CM_実行.Text = "実行";
            this.CM_実行.UseVisualStyleBackColor = false;
            this.CM_実行.Click += new System.EventHandler(this.CM_実行_Click);
            // 
            // PIC_FileDownload
            // 
            this.PIC_FileDownload.Image = ((System.Drawing.Image)(resources.GetObject("PIC_FileDownload.Image")));
            this.PIC_FileDownload.Location = new System.Drawing.Point(405, 365);
            this.PIC_FileDownload.Name = "PIC_FileDownload";
            this.PIC_FileDownload.Size = new System.Drawing.Size(19, 19);
            this.PIC_FileDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PIC_FileDownload.TabIndex = 5;
            this.PIC_FileDownload.TabStop = false;
            this.PIC_FileDownload.Click += new System.EventHandler(this.PIC_FileDownload_Click);
            // 
            // PIC_Delete
            // 
            this.PIC_Delete.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PIC_Delete.ErrorImage")));
            this.PIC_Delete.Image = ((System.Drawing.Image)(resources.GetObject("PIC_Delete.Image")));
            this.PIC_Delete.Location = new System.Drawing.Point(405, 390);
            this.PIC_Delete.Name = "PIC_Delete";
            this.PIC_Delete.Size = new System.Drawing.Size(19, 19);
            this.PIC_Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PIC_Delete.TabIndex = 5;
            this.PIC_Delete.TabStop = false;
            this.PIC_Delete.Click += new System.EventHandler(this.PIC_Delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PIC_Delete);
            this.Controls.Add(this.PIC_FileDownload);
            this.Controls.Add(this.CKL_対象リポジトリ);
            this.Controls.Add(this.TX_対象資産);
            this.Controls.Add(this.CM_リビジョン参照);
            this.Controls.Add(this.CM_実行);
            this.Controls.Add(this.CM_フォルダ参照);
            this.Controls.Add(this.TC_出力ウィンドウ);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "個別資産確認ツール";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TC_出力ウィンドウ.ResumeLayout(false);
            this.TP_ログ.ResumeLayout(false);
            this.TP_ログ.PerformLayout();
            this.TP_実行結果.ResumeLayout(false);
            this.TP_実行結果.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_FileDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Delete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl TC_出力ウィンドウ;
        private System.Windows.Forms.TabPage TP_ログ;
        private System.Windows.Forms.TextBox TX_ログ出力;
        private System.Windows.Forms.TabPage TP_実行結果;
        private System.Windows.Forms.TextBox TX_実行結果;
        private System.Windows.Forms.Button CM_フォルダ参照;
        private System.Windows.Forms.Button CM_リビジョン参照;
        private System.Windows.Forms.MaskedTextBox TX_対象資産;
        private System.Windows.Forms.CheckedListBox CKL_対象リポジトリ;
        private System.Windows.Forms.Button CM_実行;
        private System.Windows.Forms.PictureBox PIC_FileDownload;
        private System.Windows.Forms.PictureBox PIC_Delete;
    }
}

