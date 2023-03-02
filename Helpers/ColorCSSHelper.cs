using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public static class ColorCSSHelper
    {
        /// <summary>
        /// 指定颜色和饱和度的背景色 背景颜色类名为 .mdui-color-[color]-[degree]。它在设置背景色的同时，还设置了背景色中的文本颜色和文本不透明度。
        /// </summary>
        /// <param name="color"></param>
        /// <param name="primaryDegree"></param>
        /// <returns></returns>
        public static string BGColor(Color color, Degree degree = Degree.Default)
        {
            if (color == Color.None) return string.Empty;
            return $"mdui-color-{color.GetDescription()}-{degree.GetDescription()}".TrimEnd('-');
        }
        /// <summary>
        /// 指定颜色和饱和度的文本色 mdui-text-color-[color]-[degree] 。
        /// </summary>
        /// <param name="color"></param>
        /// <param name="primaryDegree"></param>
        /// <returns></returns>
        public static string TextColor(Color color, Degree degree = Degree.Default) 
        {
            if (color == Color.None) return string.Empty;
            return $"mdui-text-color-{color.GetDescription()}-{degree.GetDescription()}".TrimEnd('-');
        }
        /// <summary>
        /// 浅色文本色，用在深色背景中
        /// </summary>
        /// <param name="textTransparency"></param>
        /// <returns></returns>
        public static string TextColorForDarkBG(TextTransparency textTransparency) 
        {
            if (textTransparency == TextTransparency.Default) return string.Empty;
            return $"mdui-text-color-white-{textTransparency.GetDescription()}";
        }
        /// <summary>
        /// 深色文本色，用在浅色背景中
        /// </summary>
        /// <param name="textTransparency"></param>
        /// <returns></returns>
        public static string TextColorForLightBG(TextTransparency textTransparency)
        {
            if (textTransparency == TextTransparency.Default) return string.Empty;
            return $"mdui-text-color-black-{textTransparency.GetDescription()}";
        }
        /// <summary>
        /// 根据主题色变化的深色或浅色文本色
        /// </summary>
        /// <param name="textTransparency"></param>
        /// <returns></returns>
        public static string TextColorForTheme(TextTransparency textTransparency) 
        {
            if (textTransparency == TextTransparency.Default) return string.Empty;
            return $"mdui-text-color-theme-{textTransparency.GetDescription()}";
        }
    }
}
