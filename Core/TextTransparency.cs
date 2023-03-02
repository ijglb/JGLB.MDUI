using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public enum TextTransparency
    {
        [Description("")]
        Default,
        [Description("text")]
        Text,
        [Description("secondary")]
        Secondary,
        [Description("disabled")]
        Disabled,
        [Description("divider")]
        Divider,
        [Description("icon")]
        Icon,
        [Description("icon-disabled")]
        IconDisabled
    }
}
