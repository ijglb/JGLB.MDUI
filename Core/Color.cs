using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 颜色
    /// </summary>
    public enum Color
    {
        [Description("")]
        None,
        /// <summary>
        /// 主题颜色
        /// </summary>
        [Description("theme")]
        Theme,
        [Description("red")]
        Red,
        [Description("pink")]
        Pink,
        [Description("purple")]
        Purple,
        [Description("deep-purple")]
        DeepPurple,
        [Description("indigo")]
        Indigo,
        [Description("blue")]
        Blue,
        [Description("light-blue")]
        LightBlue,
        [Description("cyan")]
        Cyan,
        [Description("teal")]
        Teal,
        [Description("green")]
        Green,
        [Description("light-green")]
        LightGreen,
        [Description("lime")]
        Lime,
        [Description("yellow")]
        Yellow,
        [Description("amber")]
        Amber,
        [Description("orange")]
        Orange,
        [Description("deep-orange")]
        DeepOrange,
        /// <summary>
        /// 主题中仅主色Primary
        /// </summary>
        [Description("brown")]
        Brown,
        /// <summary>
        /// 主题中仅主色Primary
        /// </summary>
        [Description("grey")]
        Grey,
        /// <summary>
        /// 主题中仅主色Primary
        /// </summary>
        [Description("blue-grey")]
        BlueGrey,
        /// <summary>
        /// 黑
        /// </summary>
        [Description("black")]
        Black,
        /// <summary>
        /// 白
        /// </summary>
        [Description("white")]
        White,
        /// <summary>
        /// 透明
        /// </summary>
        [Description("transparent")]
        Transparent
    }
}
