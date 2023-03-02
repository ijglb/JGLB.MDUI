using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public static class Ripple
    {
        public static string CSS() => "mdui-ripple";

        public static string CSS(Color color) => $"{CSS()} {CSS()}-{color.GetDescription()}";

        public static string Color(Color color) => $"{CSS()}-{color.GetDescription()}";
    }
}
