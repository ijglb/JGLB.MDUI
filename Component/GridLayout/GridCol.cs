using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义列
    /// </summary>
    public class GridCol : AbstractSimpleComponent
    {
        /// <summary>
        /// 所有屏幕设备上都会生效，如手机、电脑等。 > 0
        /// </summary>
        [Parameter]
        public int XS { get; set; } = 0;
        /// <summary>
        /// 在小屏幕及以上的设备上生效，如平板电脑。 > 600px
        /// </summary>
        [Parameter]
        public int SM { get; set; } = 0;
        /// <summary>
        /// 在中等屏幕及以上的设备上生效，如笔记本电脑。 > 1024px
        /// </summary>
        [Parameter]
        public int MD { get; set; } = 0;
        /// <summary>
        /// 在大屏幕及以上的设备上生效，如台式电脑。 > 1440px
        /// </summary>
        [Parameter]
        public int LG { get; set; } = 0;
        /// <summary>
        /// 在特大屏幕设备上生效，如电视。 > 1920px
        /// </summary>
        [Parameter]
        public int XL { get; set; } = 0;
        /// <summary>
        /// 列偏移 所有屏幕设备上都会生效，如手机、电脑等。 > 0
        /// </summary>
        [Parameter]
        public int OffsetXS { get; set; } = 0;
        /// <summary>
        /// 列偏移 在小屏幕及以上的设备上生效，如平板电脑。 > 600px
        /// </summary>
        [Parameter]
        public int OffsetSM { get; set; } = 0;
        /// <summary>
        /// 列偏移 在中等屏幕及以上的设备上生效，如笔记本电脑。 > 1024px
        /// </summary>
        [Parameter]
        public int OffsetMD { get; set; } = 0;
        /// <summary>
        /// 列偏移 在大屏幕及以上的设备上生效，如台式电脑。 > 1440px
        /// </summary>
        [Parameter]
        public int OffsetLG { get; set; } = 0;
        /// <summary>
        /// 列偏移 在特大屏幕设备上生效，如电视。 > 1920px
        /// </summary>
        [Parameter]
        public int OffsetXL { get; set; } = 0;

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
                .If("mdui-col", () => Invalid(XS) && Invalid(SM) && Invalid(MD) && Invalid(LG) && Invalid(XL))
                .GetIf(() => $"mdui-col-xs-{XS}", () => Valid(XS))
                .GetIf(() => $"mdui-col-sm-{SM}", () => Valid(SM))
                .GetIf(() => $"mdui-col-md-{MD}", () => Valid(MD))
                .GetIf(() => $"mdui-col-lg-{LG}", () => Valid(LG))
                .GetIf(() => $"mdui-col-xl-{XL}", () => Valid(XL))
                .GetIf(() => $"mdui-col-offset-xs-{OffsetXS}", () => Valid(OffsetXS))
                .GetIf(() => $"mdui-col-offset-sm-{OffsetSM}", () => Valid(OffsetSM))
                .GetIf(() => $"mdui-col-offset-md-{OffsetMD}", () => Valid(OffsetMD))
                .GetIf(() => $"mdui-col-offset-lg-{OffsetLG}", () => Valid(OffsetLG))
                .GetIf(() => $"mdui-col-offset-xl-{OffsetXL}", () => Valid(OffsetXL))
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
