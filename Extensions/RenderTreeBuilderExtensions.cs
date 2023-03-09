using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public static class RenderTreeBuilderExtensions
    {
        /// <summary>
        /// 创建级联值组件 为所有后代组件提供级联值
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="builder"></param>
        /// <param name="seq"></param>
        /// <param name="value">要提供的值</param>
        /// <param name="childContent">应向其提供值的内容</param>
        /// <param name="isFixed">如果为 true，则表示 Value 不会更改。 这是一种性能优化，允许框架跳过设置更改通知。仅当在组件的生存期内不会更改 Value 时，才设置此标志。</param>
        /// <param name="name">（可选）为提供的值指定一个名称。后代组件可以通过指定此名称来接收值。如果未指定名称，则子代组件将根据所请求的值类型接收值。</param>
        public static void CreateCascadingValue<TValue>(this RenderTreeBuilder builder, ref int seq, TValue value, RenderFragment childContent, bool isFixed = false, string? name = null)
        {
            builder.OpenComponent<CascadingValue<TValue>>(seq++);
            builder.AddAttribute(seq++, "Value", value);
            builder.AddAttribute(seq++, "IsFixed", isFixed);
            builder.AddAttribute(seq++, "ChildContent", childContent);
            if (string.IsNullOrEmpty(name))
            {
                builder.AddAttribute(seq++, "Name", name);
            }
            builder.CloseComponent();
        }
    }
}
