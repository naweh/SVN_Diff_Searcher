using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length > 0)
            {
                #region バッチモード
                /********************************************************************************
                 * 受け付けるコマンドライン引数の形式                                           *
                 * 　-r  リビジョン番号                                                         *
                 * 　-rt コミット日付F:コミット日付T                                            *
                 * 　-f  対象資産格納フォルダパス                                               *
                 *   ※[-r],[-rt],[-f]はいずれかの指定が必須                                    *
                 *                                                                              *
                 *   -m  メールアドレス                                                         *
                 *   ※[-m]を指定すると比較結果を指定アドレスに送信する                         *
                 *                                                                              *
                 *   -t  比較結果格納パス                                                       *
                 ********************************************************************************/

                List<string> lst_str_リビジョン番号 = new List<string>();
                string str_対象資産格納パス = string.Empty;
                string str_メールアドレス = string.Empty;
                string str_比較結果格納パス = string.Empty;
                DateTime dtm_コミット日付F = DateTime.MaxValue;
                DateTime dtm_コミット日付T = DateTime.MinValue;
                int int_資産種別 = 0;
                string str_hr = "─────────────────────────────";

                #region コマンドライン引数の検証
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-r":
                            int_資産種別 = CmnCD.int_資産種別.リビジョン;
                            lst_str_リビジョン番号.Add(args[++i]);
                            if (!int.TryParse(args[i], out int int_void))
                            {
                                Console.WriteLine("-r " + args[i] + "の指定が不正です");
                                return;
                            }
                            
                            break;

                        case "-rt":
                            int_資産種別 = CmnCD.int_資産種別.リビジョン;
                            i++;

                            if (args[i].StartsWith("Last"))
                            {
                                // LastNdays指定
                                int int_日数 = Convert.ToInt32(Regex.Replace(args[i], "\\D", ""));
                                dtm_コミット日付T = DateTime.Now;
                                dtm_コミット日付F = DateTime.Now.AddDays((-1) * int_日数);
                            }
                            else
                            {
                                string[] str_rt = args[++i].Split(':');
                                if (str_rt.Length != 2
                                    || !DateTime.TryParse(str_rt[0].Substring(1, str_rt[0].Length - 2), out dtm_コミット日付F)
                                    || !DateTime.TryParse(str_rt[1].Substring(1, str_rt[1].Length - 2), out dtm_コミット日付T))
                                {
                                    Console.WriteLine("-rt " + args[i] + "の指定が不正です");
                                }

                                // コミット日付Tはその日の終わりまでを含むものとする
                                dtm_コミット日付T = dtm_コミット日付T.AddDays(1);
                            }

                            break;

                        case "-f":
                            int_資産種別 = CmnCD.int_資産種別.フォルダ;
                            str_対象資産格納パス = args[++i];
                            break;

                        case "-m":
                            str_メールアドレス = args[++i];
                            break;

                        case "-t":
                            str_比較結果格納パス = args[++i];
                            break;

                        default:
                            Console.WriteLine("コマンドライン引数の指定が不正です。                ");
                            Console.WriteLine("                                                    ");
                            Console.WriteLine("[受け付けるコマンドライン引数の形式]                ");
                            Console.WriteLine("　-r  リビジョン番号                                ");
                            Console.WriteLine("　-rt コミット日付F:コミット日付T                   ");
                            Console.WriteLine("　-f  対象資産格納フォルダパス                      ");
                            Console.WriteLine("  ※[-r],[-rt],[-f]はいずれかの指定が必須           ");
                            Console.WriteLine("                                                    ");
                            Console.WriteLine("  -m  メールアドレス                                ");
                            Console.WriteLine("  ※[-m]を指定すると比較結果を指定アドレスに送信する");
                            Console.WriteLine("                                                    ");
                            Console.WriteLine("  -t  比較結果格納パス                              ");
                            Console.WriteLine("                                                    ");
                            return;
                    }
                }

                if (lst_str_リビジョン番号.Count == 0
                    && str_対象資産格納パス == string.Empty
                    && (dtm_コミット日付F == DateTime.MaxValue && dtm_コミット日付T == DateTime.MinValue))
                {
                    Console.WriteLine("[-r],[-rt],[-f]のいずれかを指定してください");
                    return;
                }

                if (!(lst_str_リビジョン番号.Count > 0
                      ^ str_対象資産格納パス != string.Empty
                      ^ (dtm_コミット日付F != DateTime.MaxValue || dtm_コミット日付T != DateTime.MinValue)))
                {
                    Console.WriteLine("[-r],[-rt],[-f]のいずれか１つのみを指定してください");
                    return;
                }
                #endregion

                List<List<string>> lst_資産一覧 = new List<List<string>>();
                List<string> ret_資産一覧 = new List<string>();
                Settings1 settings1 = new Settings1();
                string str_リポジトリパス = settings1.対象リポジトリroot + settings1.PKGリポジトリfolder;
                List<string> lst_str_output = new List<string>();
                string str_output = string.Empty;


                // コミット日付を指定している場合、期間内のコミット履歴を取得し
                // 対象のリビジョン分、個別資産比較を繰り返し実行する
                List<CmnClass.コミットログ> lst_コミットログ = new List<CmnClass.コミットログ>();
                if (dtm_コミット日付F != DateTime.MaxValue && dtm_コミット日付T != DateTime.MinValue)
                {
                    CmnModule.ModGetコミットログ(str_リポジトリパス, dtm_コミット日付F, dtm_コミット日付T, out lst_コミットログ);
                    lst_コミットログ.ForEach(obj => lst_str_リビジョン番号.Add(obj.Int_リビジョン番号.ToString()));
                }

                // 対象資産一覧を取得
                switch (int_資産種別)
                {
                    case CmnCD.int_資産種別.フォルダ:
                        
                        CmnModule.ModGet資産一覧fromフォルダパス(str_対象資産格納パス, out ret_資産一覧);
                        lst_資産一覧.Add(ret_資産一覧);

                        #region EDT:実行結果
                        str_output = string.Empty;
                        str_output += str_hr + Environment.NewLine;
                        str_output += str_対象資産格納パス + "に含まれる対象資産" + Environment.NewLine;
                        ret_資産一覧.ForEach(s => str_output += "　□" + Regex.Replace(s, ".*\\\\", "") + Environment.NewLine);
                        str_output += str_hr + Environment.NewLine;

                        lst_str_output.Add(str_output);
                        #endregion
                        break;

                    case CmnCD.int_資産種別.リビジョン:

                        foreach (string str_リビジョン番号 in lst_str_リビジョン番号)
                        {
                            CmnModule.ModGet資産一覧fromリポジトリパス(str_リポジトリパス, str_リビジョン番号, out ret_資産一覧);
                            lst_資産一覧.Add(ret_資産一覧);

                            #region EDT:実行結果
                            str_output = string.Empty;
                            str_output += str_hr + Environment.NewLine;

                            CmnClass.コミットログ obj_コミットログ = lst_コミットログ.Find(obj => obj.Int_リビジョン番号.ToString() == str_リビジョン番号);
                            if (obj_コミットログ != null)
                            {
                                str_output += "r" + str_リビジョン番号;
                                str_output += " comitted by " + obj_コミットログ.Str_ユーザー + Environment.NewLine;
                                str_output += obj_コミットログ.Str_コメント;
                                str_output += Environment.NewLine;
                            }
                            else
                            {
                                str_output += "r" + str_リビジョン番号;
                                str_output += "に含まれる対象資産" + Environment.NewLine;
                            }

                            ret_資産一覧.ForEach(s => str_output += "　□" + Regex.Replace(s, ".*\\\\", "") + Environment.NewLine);
                            str_output += str_hr + Environment.NewLine;
                            lst_str_output.Add(str_output);
                            #endregion
                        }
                        break;

                    default:
                        return;
                }

                // リポジトリごとの個別資産一覧を取得→比較する
                string[] ary_str_対象リポジトリfolder = settings1.対象リポジトリfolder.Split(',');
                foreach (string str_対象リポジトリfolder in ary_str_対象リポジトリfolder)
                {
                    str_リポジトリパス = settings1.対象リポジトリroot + str_対象リポジトリfolder;
                    List<string> lst_個別資産一覧;
                    List<string> lst_result;

                    CmnModule.ModGet資産一覧fromリポジトリパス(str_リポジトリパス, out lst_個別資産一覧);

                    for (int i = 0; i < lst_資産一覧.Count; i++)
                    {
                        CmnModule.ModCompare資産一覧(lst_資産一覧[i], lst_個別資産一覧, out lst_result);

                        #region EDT:実行結果
                        str_output = string.Empty;
                        str_output += str_対象リポジトリfolder + "上の個別資産" + Environment.NewLine;

                        if (lst_result.Count > 0)
                            lst_result.ForEach(s => str_output += "　□" + s + Environment.NewLine);
                        else
                            str_output += "　■個別資産なし" + Environment.NewLine;

                        lst_str_output[i] += Environment.NewLine + str_output + Environment.NewLine;
                        #endregion
                    }
                }

                #region OUT:実行結果
                // とりあえず標準出力
                lst_str_output.ForEach(s => Console.WriteLine(s));

                // 比較結果格納パス[-t]が指定されている場合、ファイル保存する
                if (str_比較結果格納パス != string.Empty)
                {
                    StreamWriter obj_StreamWriter = new StreamWriter(
                        str_比較結果格納パス + "\\資産比較結果" + DateTime.Now.ToString("_yyyyMMdd") + ".log",
                        false,
                        Encoding.GetEncoding("shift-jis"));

                    str_output = string.Empty;
                    lst_str_output.ForEach(s => str_output += s);
                    obj_StreamWriter.Write(str_output);
                    obj_StreamWriter.Close();
                }

                // メールアドレス[-m]が指定されている場合、メール送信する
                if (str_メールアドレス != string.Empty)
                {
                    string str_送信メールアドレス = "eisei_checkresult_autosend@k-js.co.jp";
                    string str_宛先メールアドレス = str_メールアドレス;
                    string str_件名 = "[" + DateTime.Now.ToShortDateString() + "] 個別資産確認ログ (自動送信メール)";
                    string str_内容 = string.Empty;

                    // 内容編集：ヘッダ部分
                    str_内容 = "個別資産確認ツール実行条件" + Environment.NewLine;
                    if (dtm_コミット日付F != DateTime.MaxValue)
                        str_内容 += "・対象期間（F)：" + dtm_コミット日付F.ToShortDateString() + Environment.NewLine;
                    if (dtm_コミット日付T != DateTime.MinValue)
                        str_内容 += "・対象期間（T）：" + dtm_コミット日付T.AddDays(-1).ToShortDateString() + Environment.NewLine;
                    str_内容 += "・対象リビジョン番号：" + string.Join(", ", lst_str_リビジョン番号.ToArray()) + Environment.NewLine;
                    str_内容 += Environment.NewLine;

                    // 内容編集：比較結果部分
                    lst_str_output.ForEach(s => str_内容 += s + Environment.NewLine);

                    System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient()
                    {
                        Host = settings1.SMTPサーバ,
                        Port = Convert.ToInt32(settings1.SMTPポート番号),
                        DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    };

                    sc.Send(str_送信メールアドレス, str_宛先メールアドレス, str_件名, str_内容);
                    sc.Dispose();
                }
                #endregion

                #endregion
            }
            else
            {
                // Windowsモード
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
