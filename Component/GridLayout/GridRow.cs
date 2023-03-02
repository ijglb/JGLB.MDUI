using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义行   必须包含在Container中
    /// </summary>
    public class GridRow : AbstractSimpleComponent
    {
        /// <summary>
        /// 消除列间距 默认在列之间会有 16px 的间距
        /// </summary>
        [Parameter]
        public bool Gapless { get; set; }
        /// <summary>
        /// 等分列 所有屏幕设备上都会生效，如手机、电脑等。 > 0
        /// </summary>
        [Parameter]
        public int XS { get; set; } = 0;
        /// <summary>
        /// 等分列 在小屏幕及以上的设备上生效，如平板电脑。 > 600px
        /// </summary>
        [Parameter]
        public int SM { get; set; } = 0;
        /// <summary>
        /// 等分列 在中等屏幕及以上的设备上生效，如笔记本电脑。 > 1024px
        /// </summary>
        [Parameter]
        public int MD { get; set; } = 0;
        /// <summary>
        /// 等分列 在大屏幕及以上的设备上生效，如台式电脑。 > 1440px
        /// </summary>
        [Parameter]
        public int LG { get; set; } = 0;
        /// <summary>
        /// 等分列 在特大屏幕设备上生效，如电视。 > 1920px
        /// </summary>
        [Parameter]
        public int XL { get; set; } = 0;

        protected override string _Tag => "div";

        protected override string _CSS => "";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-row", () => Invalid(XS) && Invalid(SM) && Invalid(MD) && Invalid(LG) && Invalid(XL))
                .GetIf(() => $"mdui-row-xs-{XS}", () => Valid(XS))
                .GetIf(() => $"mdui-row-sm-{SM}", () => Valid(SM))
                .GetIf(() => $"mdui-row-md-{MD}", () => Valid(MD))
                .GetIf(() => $"mdui-row-lg-{LG}", () => Valid(LG))
                .GetIf(() => $"mdui-row-xl-{XL}", () => Valid(XL))
                ;
        }

        private bool Valid(int col)
        {
            return col > 0 && col < 13;
        }

        private bool Invalid(int col)
        {
            return !Valid(col);
        }
    }
}
