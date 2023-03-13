using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 警告框可选参数
    /// </summary>
    public class AlertDialogOptions
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 确认按钮的文本
        /// </summary>
        public string confirmText { get; set; } = "ok";
        /// <summary>
        /// 是否监听 hashchange 事件，为 true 时可以通过 Android 的返回键或浏览器后退按钮关闭对话框
        /// </summary>
        public bool history { get; set; } = true;
        /// <summary>
        /// 是否模态化对话框。为 false 时点击对话框外面的区域时关闭对话框，否则不关闭
        /// </summary>
        public bool modal { get; set; } = false;
        /// <summary>
        /// 按下 Esc 键时是否关闭对话框
        /// </summary>
        public bool closeOnEsc { get; set; } = true;
        /// <summary>
        /// 是否在按下确认按钮时是否关闭对话框
        /// </summary>
        public bool closeOnConfirm { get; set; } = true;
        /// <summary>
        /// 点击确认按钮的回调
        /// </summary>
        public Action? onConfirm { get; set; }
    }
}
