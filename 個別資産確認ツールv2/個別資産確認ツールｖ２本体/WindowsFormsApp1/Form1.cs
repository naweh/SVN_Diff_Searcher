using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region メンバの宣言
        private int int_資産種別 = 0;
        private Settings1 settings1 = new Settings1();
        private int int_ログ番号 = 0;
        #endregion

        #region 初期化処理
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> lst_対象リポジトリfolder = settings1.対象リポジトリfolder.Split(',').ToList<string>();
            lst_対象リポジトリfolder.ForEach(s => CKL_対象リポジトリ.Items.Add(s, CheckState.Checked));

            CM_フォルダ参照.BackColor = Color.WhiteSmoke;
            CM_リビジョン参照.BackColor = Color.WhiteSmoke;
        }
        #endregion

        #region イベントハンドラ
        private void CM_実行_Click(object sender, EventArgs e)
        {
            string str_対象資産 = TX_対象資産.Text;
            List<string> lst_資産一覧 = new List<string>();

            TC_出力ウィンドウ.SelectedTab = TP_ログ;

            // 対象資産一覧を取得
            ModOutログ出力("個別資産確認処理を実行します");

            if (TX_対象資産.Text == string.Empty)
            {
                ModOutログ出力("【ERR】対象資産格納フォルダ または リビジョン番号を指定してください");
                return;
            }

            switch (int_資産種別)
            {
                case CmnCD.int_資産種別.フォルダ:
                    ModOutログ出力(TX_対象資産.Text + "配下の資産の一覧を取得します");
                    CmnModule.ModGet資産一覧fromフォルダパス(str_対象資産, out lst_資産一覧);
                    break;

                case CmnCD.int_資産種別.リビジョン:
                    string str_リポジトリパス = settings1.対象リポジトリroot + settings1.PKGリポジトリfolder;
                    string str_リビジョン番号 = str_対象資産;

                    ModOutログ出力("r" + TX_対象資産.Text + "にてコミットされた資産の一覧を取得します");
                    CmnModule.ModGet資産一覧fromリポジトリパス(str_リポジトリパス, str_リビジョン番号, out lst_資産一覧);
                    break;
            }

            ModOutログ出力("対象資産一覧の取得完了");

            // 個別資産リポジトリごとの資産一覧を取得→比較する
            #region OUT:実行結果
            TX_実行結果.Text = string.Empty;
            TX_実行結果.Text += (int_資産種別 == CmnCD.int_資産種別.リビジョン ? "r" : "") + TX_対象資産.Text + "に含まれる対象資産" + Environment.NewLine;
            lst_資産一覧.ForEach(s => TX_実行結果.Text += "　□" + Regex.Replace(s, ".*\\\\", "") + Environment.NewLine);
            TX_実行結果.Text += "----------------------------------------------------" + Environment.NewLine + Environment.NewLine;
            #endregion

            foreach (object obj_CheckedItem in CKL_対象リポジトリ.CheckedItems)
            {
                string str_リポジトリパス = settings1.対象リポジトリroot + obj_CheckedItem.ToString();
                List<string> lst_個別資産一覧;
                List<string> lst_result;

                ModOutログ出力(str_リポジトリパス + "の個別資産一覧を取得します");
                CmnModule.ModGet資産一覧fromリポジトリパス(str_リポジトリパス, out lst_個別資産一覧);
                ModOutログ出力("個別資産一覧の取得完了");

                ModOutログ出力("取得した個別資産一覧と対象資産一覧の比較を行います");
                CmnModule.ModCompare資産一覧(lst_資産一覧, lst_個別資産一覧, out lst_result);
                ModOutログ出力("取得した個別資産一覧と対象資産一覧の比較完了");

                #region OUT:実行結果
                TX_実行結果.Text += obj_CheckedItem.ToString() + "上の個別資産" + Environment.NewLine;

                if (lst_result.Count > 0)
                    lst_result.ForEach(s => TX_実行結果.Text += "　□" + s + Environment.NewLine);
                else
                    TX_実行結果.Text += "　個別資産なし" + Environment.NewLine;

                TX_実行結果.Text += Environment.NewLine;
                #endregion
            }

            TC_出力ウィンドウ.SelectedTab = TP_実行結果;
        }

        private void CM_フォルダ参照_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog obj_CommonOpenFileDialog = new CommonOpenFileDialog("リリースフォルダを選択");
            obj_CommonOpenFileDialog.IsFolderPicker = true;

            if (obj_CommonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                TX_対象資産.Text = obj_CommonOpenFileDialog.FileName;
                TX_対象資産.TextAlign = HorizontalAlignment.Left;
                TX_対象資産.ImeMode = ImeMode.NoControl;

                int_資産種別 = CmnCD.int_資産種別.フォルダ;
                CM_フォルダ参照.BackColor = Color.Gainsboro;
                CM_リビジョン参照.BackColor = Color.WhiteSmoke;
            }
        }

        private void CM_リビジョン参照_Click(object sender, EventArgs e)
        {
            Form2 obj_Form2 = new Form2();
            obj_Form2.ShowDialog();
            if (obj_Form2.Selectedリビジョン番号 != 0)
            {
                TX_対象資産.Text = obj_Form2.Selectedリビジョン番号.ToString();
                TX_対象資産.TextAlign = HorizontalAlignment.Right;
                TX_対象資産.ImeMode = ImeMode.Alpha;

                int_資産種別 = CmnCD.int_資産種別.リビジョン;
                CM_フォルダ参照.BackColor = Color.WhiteSmoke;
                CM_リビジョン参照.BackColor = Color.Gainsboro;
            }

            obj_Form2.Dispose();
        }

        private void PIC_Delete_Click(object sender, EventArgs e)
        {
            DialogResult obj_DialogResult;
            TabPage obj_TabPage = TC_出力ウィンドウ.SelectedTab;

            obj_DialogResult = MessageBox.Show(obj_TabPage.Text + "の表示内容を削除します", "確認", MessageBoxButtons.OKCancel);

            if (obj_DialogResult == DialogResult.OK)
            {
                switch (obj_TabPage.Text)
                {
                    case "ログ":
                        TX_ログ出力.Text = string.Empty;
                        break;

                    case "実行結果":
                        TX_実行結果.Text = string.Empty;
                        break;

                    default:
                        break;
                }
            }
        }

        private void PIC_FileDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog obj_SaveFileDialog = new SaveFileDialog();
            DialogResult obj_DialogResult;
            TabPage obj_TabPage = TC_出力ウィンドウ.SelectedTab;
         
            string str_output = string.Empty;
            switch (obj_TabPage.Text)
            {
                case "ログ":
                    obj_SaveFileDialog.FileName = "Log_" + DateTime.Now.ToString("yyyyMMddhhmm") + ".txt";
                    str_output = TX_ログ出力.Text;
                    break;

                case "実行結果":
                    obj_SaveFileDialog.FileName = "Result_" + DateTime.Now.ToString("yyyyMMddhhmm") + ".txt";
                    str_output = TX_実行結果.Text;
                    break;

                default:
                    break;
            }

            obj_DialogResult = obj_SaveFileDialog.ShowDialog();
            if (obj_DialogResult == DialogResult.OK)
            {
                System.IO.Stream obj_Stream = obj_SaveFileDialog.OpenFile();
                if (obj_Stream == null) return;

                System.IO.StreamWriter obj_StreamWriter = new System.IO.StreamWriter(obj_Stream);
                obj_StreamWriter.Write(str_output);

                obj_StreamWriter.Close();
                obj_Stream.Close();
            }
        }
        #endregion

        #region モジュール
        private CmnCD.実行結果 ModOutログ出力(string str_メッセージ)
        {
            TX_ログ出力.AppendText("[" + (++int_ログ番号).ToString("D2") + "] [" + DateTime.Now.ToString("hh:mm:ss") + "] " + str_メッセージ + Environment.NewLine);
            return CmnCD.実行結果.OK;
        }
        #endregion
    }
}
