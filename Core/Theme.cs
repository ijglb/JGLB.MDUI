using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 主题
    /// </summary>
    public enum Theme
    {
        /// <summary>
        /// 浅色
        /// </summary>
        [Description("")]
        Light,
        /// <summary>
        /// 深色
        /// </summary>
        [Description("mdui-theme-layout-dark")]
        Dark,
        /// <summary>
        /// 根据操作系统的主题自动调整
        /// </summary>
        [Description("mdui-theme-layout-auto")]
        Auto
    }
}
