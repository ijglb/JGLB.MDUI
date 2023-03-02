using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public abstract class MDUIComponentBase : ComponentBase, IDisposable
    {
        [Parameter]
        public string Id { get; set; }

        private string _class;
        /// <summary>
        /// 组件css
        /// </summary>
        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassMapper.OriginalClass = value;
            }
        }
        private string _style;
        /// <summary>
        /// 组件style
        /// </summary>
        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                if (!string.IsNullOrWhiteSpace(_style) && !_style.EndsWith(";"))
                {
                    _style += ";";
                }
                //this.StateHasChanged();
            }
        }
        /// <summary>
        /// 背景色
        /// </summary>
        [Parameter]
        public Color BGColor { get; set; } = Color.None;
        /// <summary>
        /// 背景色饱和度 需设置背景色BGColor
        /// </summary>
        [Parameter]
        public Degree BGDegree { get; set; } = Degree.Default;
        /// <summary>
        /// 文本颜色
        /// </summary>
        [Parameter]
        public Color TextColor { get; set; } = Color.None;
        /// <summary>
        /// 文本颜色饱和度 需设置文本颜色TextColor
        /// </summary>
        [Parameter]
        public Degree TextDegree { get; set; } = Degree.Default;


        public ElementReference Ref { get; set; }

        [Inject]
        protected IJSRuntime Js { get; set; }

        protected ClassMapper ClassMapper { get; } = new ClassMapper();

        protected override void OnInitialized()
        {
            Id ??= "mdui-blazor-" + Guid.NewGuid();
            base.OnInitialized();
            ClassMapper.Clear()
                .GetIf(() => ColorCSSHelper.BGColor(BGColor, BGDegree), () => BGColor != Color.None)
                .GetIf(() => ColorCSSHelper.TextColor(TextColor, TextDegree), () => TextColor != Color.None)
                ;
        }

        protected bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            IsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MDUIComponentBase()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
    }
}
