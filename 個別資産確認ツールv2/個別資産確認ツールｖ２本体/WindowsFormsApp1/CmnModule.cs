using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CmnModule
    {
        public static CmnCD.実行結果 ModGet資産一覧fromフォルダパス(string prm_str_フォルダパス, out List<string> ret_資産一覧)
        {
            ret_資産一覧 = new List<string>();
            Process obj_Process = new Process();
            ProcessStartInfo obj_ProcessStartInfo = new ProcessStartInfo();

            obj_ProcessStartInfo.UseShellExecute = false;
            obj_ProcessStartInfo.RedirectStandardOutput = true;
            obj_ProcessStartInfo.RedirectStandardInput = false;
            obj_ProcessStartInfo.CreateNoWindow = true;

            // コマンドをセット　→　/C dir /B /S %FolderPath%
            obj_ProcessStartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            obj_ProcessStartInfo.Arguments = @"/C dir /B /S /A-D " + prm_str_フォルダパス;

            // コマンドを実行
            obj_Process.StartInfo = obj_ProcessStartInfo;
            obj_Process.Start();

            // 実行結果を取得
            string str_readLine;
            while ((str_readLine = obj_Process.StandardOutput.ReadLine() ?? "") != "")
            {
                ret_資産一覧.Add(str_readLine);
            }

            // プロセスを終了
            obj_Process.WaitForExit();
            obj_Process.Close();

            return CmnCD.実行結果.OK;
        }

        public static CmnCD.実行結果 ModGet資産一覧fromリポジトリパス(string prm_str_リポジトリパス, out List<string> ret_資産一覧)
        {
            ret_資産一覧 = new List<string>();
            Process obj_Process = new Process();
            ProcessStartInfo obj_ProcessStartInfo = new ProcessStartInfo();

            obj_ProcessStartInfo.UseShellExecute = false;
            obj_ProcessStartInfo.RedirectStandardOutput = true;
            obj_ProcessStartInfo.RedirectStandardInput = false;
            obj_ProcessStartInfo.CreateNoWindow = true;

            // コマンドをセット　→　/C svn list -R file://%RepositoryPath%
            obj_ProcessStartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            obj_ProcessStartInfo.Arguments = @"/C svn list -R file://" + prm_str_リポジトリパス;

            // コマンドを実行
            obj_Process.StartInfo = obj_ProcessStartInfo;
            obj_Process.Start();

            // 実行結果を取得
            string str_readLine;
            while ((str_readLine = obj_Process.StandardOutput.ReadLine() ?? "") != "")
            {
                // フォルダ名のみの場合は処理しない
                if (str_readLine.EndsWith("/")) continue;

                ret_資産一覧.Add(str_readLine);
            }

            // プロセスを終了
            obj_Process.WaitForExit();
            obj_Process.Close();

            return CmnCD.実行結果.OK;
        }

        public static CmnCD.実行結果 ModGet資産一覧fromリポジトリパス(string prm_str_リポジトリパス, string prm_str_リビジョン番号, out List<string> ret_資産一覧)
        {
            ret_資産一覧 = new List<string>();
            Process obj_Process = new Process();
            ProcessStartInfo obj_ProcessStartInfo = new ProcessStartInfo();

            obj_ProcessStartInfo.UseShellExecute = false;
            obj_ProcessStartInfo.RedirectStandardOutput = true;
            obj_ProcessStartInfo.RedirectStandardInput = false;
            obj_ProcessStartInfo.CreateNoWindow = true;

            // コマンドをセット　→　/C svn list -R file://%RepositoryPath%
            obj_ProcessStartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            obj_ProcessStartInfo.Arguments = @"/C svn log -v -q file://" + prm_str_リポジトリパス;
            obj_ProcessStartInfo.Arguments += prm_str_リビジョン番号 == "0" ? "" : " -r " + prm_str_リビジョン番号;

            // コマンドを実行
            obj_Process.StartInfo = obj_ProcessStartInfo;
            obj_Process.Start();

            // 実行結果を取得
            string str_readLine;
            while ((str_readLine = obj_Process.StandardOutput.ReadLine() ?? "") != "")
            {
                // ファイルパス以外は処理しない
                if (!Regex.IsMatch(str_readLine, "   [M|A|D] /.*\\..*")) continue;

                ret_資産一覧.Add(str_readLine.Substring(5));
            }

            // プロセスを終了
            obj_Process.WaitForExit();
            obj_Process.Close();

            return CmnCD.実行結果.OK;
        }

        public static CmnCD.実行結果 ModGetコミットログ(string prm_str_リポジトリパス, out List<CmnClass.コミットログ> ret_コミットログ)
        {
            ret_コミットログ = new List<CmnClass.コミットログ>();
            return ModGetコミットログ(prm_str_リポジトリパス, DateTime.MaxValue, DateTime.MinValue, out ret_コミットログ);
        }

        public static CmnCD.実行結果 ModGetコミットログ(string prm_str_リポジトリパス, DateTime prm_dtm_コミット期間F, DateTime prm_dtm_コミット期間T, out List<CmnClass.コミットログ> ret_コミットログ)
        {
            ret_コミットログ = new List<CmnClass.コミットログ>();
            Process obj_Process = new Process();
            ProcessStartInfo obj_ProcessStartInfo = new ProcessStartInfo();

            obj_ProcessStartInfo.UseShellExecute = false;
            obj_ProcessStartInfo.RedirectStandardOutput = true;
            obj_ProcessStartInfo.RedirectStandardInput = false;
            obj_ProcessStartInfo.CreateNoWindow = true;

            // コマンドをセット　→　/C svn log -l 50 %repositoryPath%
            obj_ProcessStartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            obj_ProcessStartInfo.Arguments = @"/C svn log -l 50 file://" + prm_str_リポジトリパス;
            if (prm_dtm_コミット期間F != DateTime.MaxValue && prm_dtm_コミット期間T != DateTime.MinValue)
            {
                obj_ProcessStartInfo.Arguments += " -r {" + prm_dtm_コミット期間F.ToString("yyyy-MM-dd")
                    + "}:{" + prm_dtm_コミット期間T.ToString("yyyy-MM-dd") + "}";
            }

            // コマンドを実行
            obj_Process.StartInfo = obj_ProcessStartInfo;
            obj_Process.Start();

            // 実行結果を取得
            CmnClass.コミットログ obj_コミットログ = new CmnClass.コミットログ();
            string str_readLine = obj_Process.StandardOutput.ReadLine();
            while ((str_readLine = obj_Process.StandardOutput.ReadLine()) != null)
            {
                if (str_readLine == string.Empty) continue;
                if (str_readLine == "------------------------------------------------------------------------")
                {
                    // リビジョンが変わるタイミングで、前のリビジョンの値を保存する
                    ret_コミットログ.Add(obj_コミットログ);
                    obj_コミットログ = new CmnClass.コミットログ();
                    continue;
                }

                // 値を読み込む
                if (Regex.IsMatch(str_readLine, @"^r\d+(.*)\d line"))
                {
                    // リビジョン番号 | ユーザー | コミット時刻 | n lines
                    string[] str_readBlock = str_readLine.Split('|');

                    obj_コミットログ.Int_リビジョン番号 = Convert.ToInt32(str_readBlock[0].Trim().Substring(1));
                    obj_コミットログ.Str_ユーザー = str_readBlock[1].Trim();
                    obj_コミットログ.Dtm_コミット日時 = Convert.ToDateTime(str_readBlock[2].Trim().Substring(0, 19));
                    obj_コミットログ.Int_行数Ofコメント = Convert.ToInt32(Regex.Replace(str_readBlock[3], "[a-z|A-Z]", "").Trim());
                }
                else
                {
                    // コメント
                    obj_コミットログ.Str_コメント += str_readLine + ' ';
                }
            }

            // プロセスを終了
            obj_Process.WaitForExit();
            obj_Process.Close();

            return CmnCD.実行結果.OK;
        }

        public static CmnCD.実行結果 ModCompare資産一覧(List<string> prm_lst_対象資産一覧, List<string> prm_lst_個別資産一覧, out List<string> ret_比較結果)
        {
            ret_比較結果 = new List<string>();

            // 線形探索（TODO:探索アルゴリズムの改善）
            foreach (string str_対象資産 in prm_lst_対象資産一覧)
            {
                // パス部分を削除
                string str_wk_対象資産 = Regex.Replace(str_対象資産.Replace('\\', '/'), ".*/", "");

                // 資産名変更のコミット対応
                // "変更後資産名.拡張子(from 変更前資産名.拡張子)"の形式でログ出力されるので、変更前資産名を抽出する
                str_wk_対象資産 = Regex.Replace(str_wk_対象資産, @":\d+\)", "");

                if (prm_lst_個別資産一覧.Exists(s => Regex.IsMatch(s, ".*" + str_wk_対象資産 + "$")))
                {
                    ret_比較結果.Add(str_wk_対象資産);
                }
            }

            return CmnCD.実行結果.OK;
        }
    }
}
