using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// Snackbar 参数
    /// </summary>
    public class SnackbarOptions
    {
        /// <summary>
        /// Snackbar 的文本
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 在用户没有操作时多长时间自动隐藏，单位（毫秒）。为 0 时表示不自动关闭
        /// </summary>
        public int timeout { get; set; } = 4000;
        /// <summary>
        /// Snackbar 的位置
        /// bottom：下方
        /// top：上方
        /// left-top：左上角
        /// left-bottom：左下角
        /// right-top：右上角
        /// right-bottom：右下角
        /// </summary>
        public string position { get; set; } = "bottom";
        /// <summary>
        /// 按钮的文本
        /// </summary>
        public string buttonText { get; set; }
        /// <summary>
        /// 按钮的文本颜色，可以是颜色名或颜色值，如 red、#ffffff、rgba(255, 255, 255, 0.3) 等
        /// </summary>
        public string buttonColor { get; set; } = "#90CAF9";
        /// <summary>
        /// 点击按钮时是否关闭 Snackbar
        /// </summary>
        public bool closeOnButtonClick { get; set; } = true;
        /// <summary>
        /// 点击或触摸 Snackbar 以外的区域时是否关闭 Snackbar
        /// </summary>
        public bool closeOnOutsideClick { get; set; } = true;
        /// <summary>
        /// 在 Snackbar 上点击的回调
        /// </summary>
        public Action? onClick { get; set; }
        /// <summary>
        /// 点击 Snackbar 上的按钮时的回调
        /// </summary>
        public Action? onButtonClick { get; set; }
        /// <summary>
        /// Snackbar 开始打开时的回调
        /// </summary>
        public Action? onOpen { get; set; }
        /// <summary>
        /// Snackbar 打开后的回调
        /// </summary>
        public Action? onOpened { get; set; }
        /// <summary>
        /// Snackbar 开始关闭时的回调
        /// </summary>
        public Action? onClose { get; set; }
        /// <summary>
        /// Snackbar 关闭后的回调
        /// </summary>
        public Action? onClosed { get; set; }
    }
}
