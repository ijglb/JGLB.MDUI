using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public enum Degree
    {
        /// <summary>
        /// 默认主色
        /// </summary>
        [Description("")]
        Default,
        [Description("50")]
        The50,
        [Description("100")]
        The100,
        [Description("200")]
        The200,
        [Description("300")]
        The300,
        [Description("400")]
        The400,
        [Description("500")]
        The500,
        [Description("600")]
        The600,
        [Description("700")]
        The700,
        [Description("800")]
        The800,
        [Description("900")]
        The900,
        /// <summary>
        /// 强调色
        /// </summary>
        [Description("accent")]
        Accent,
        [Description("a100")]
        A100,
        [Description("a200")]
        A200,
        [Description("a400")]
        A400,
        [Description("a700")]
        A700
    }
}
