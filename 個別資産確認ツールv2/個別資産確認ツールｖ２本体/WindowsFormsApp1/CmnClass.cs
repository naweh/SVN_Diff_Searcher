using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CmnClass
    {
        public class コミットログ
        {
            public int Int_リビジョン番号 { get; set; }
            public string Str_ユーザー { get; set; }
            public DateTime Dtm_コミット日時 { get; set; }
            public int Int_行数Ofコメント { get; set; }
            public string Str_コメント { get; set; }
        }
    }
}
