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
    public partial class Form2 : Form
    {
        #region メンバの宣言
        public int Selectedリビジョン番号 = 0;
        private Settings1 settings1 = new Settings1();
        #endregion

        #region 初期化処理
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string str_リポジトリパス = settings1.対象リポジトリroot + settings1.PKGリポジトリfolder;
            List<CmnClass.コミットログ> lst_obj_コミットログ = new List<CmnClass.コミットログ>();

            CmnModule.ModGetコミットログ(str_リポジトリパス, out lst_obj_コミットログ);

            dataGridView1.Rows.Clear();
            lst_obj_コミットログ.ForEach(
                obj => dataGridView1.Rows.Add(obj.Int_リビジョン番号, obj.Str_ユーザー, obj.Dtm_コミット日時.ToString("yy-MM-dd hh:mm"), obj.Str_コメント, "→"));


            string str_リビジョン番号 = dataGridView1.SelectedRows[0].Cells["No"].Value.ToString();
            List<string> lst_資産一覧 = new List<string>();

            CmnModule.ModGet資産一覧fromリポジトリパス(str_リポジトリパス, str_リビジョン番号, out lst_資産一覧);

            LST_対象資産.Items.Clear();
            lst_資産一覧.ForEach(s => LST_対象資産.Items.Add(s));
        }
        #endregion

        #region イベントハンドラ
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView obj_DataGridView = (DataGridView)sender;

            switch (obj_DataGridView.Columns[e.ColumnIndex].Name)
            {
                case "選択":
                    // 「→」ボタン押下時は選択行のリビジョン番号を保存して画面を閉じる
                    Selectedリビジョン番号 = Convert.ToInt32(obj_DataGridView.Rows[e.RowIndex].Cells["No"].Value.ToString());
                    this.Close();
                    break;

                default:
                    // それ以外
                    break;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView obj_DataGridView = (DataGridView)sender;

            // 選択行のリビジョンでコミットされた資産を表示する
            string str_リビジョン番号 = obj_DataGridView.Rows[e.RowIndex].Cells["No"].Value.ToString();
            string str_リポジトリパス = settings1.対象リポジトリroot + settings1.PKGリポジトリfolder;
            List<string> lst_資産一覧 = new List<string>();

            CmnModule.ModGet資産一覧fromリポジトリパス(str_リポジトリパス, str_リビジョン番号, out lst_資産一覧);

            LST_対象資産.Items.Clear();
            lst_資産一覧.ForEach(s => LST_対象資産.Items.Add(s));
        }

        private void CM_選択_Click(object sender, EventArgs e)
        {
            Selectedリビジョン番号 = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["No"].Value.ToString());
            this.Close();
        }

        private void CM_取消_Click(object sender, EventArgs e)
        {
            Selectedリビジョン番号 = 0;
            this.Close();
        }
        #endregion

        #region モジュール
        
        #endregion
    }
}
