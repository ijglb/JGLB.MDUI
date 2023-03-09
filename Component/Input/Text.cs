//https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputText.cs
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 单行文本框
    /// </summary>
    public class Text : MduiInputBase<string?>
    {
        /// <summary>
        /// input class
        /// </summary>
        [Parameter]
        public bool InputClass { get; set; }
        private string _InputStyle;
        /// <summary>
        /// input style
        /// </summary>
        [Parameter]
        public string InputStyle
        {
            get => _InputStyle;
            set
            {
                _InputStyle = value;
                if (!string.IsNullOrWhiteSpace(_InputStyle) && !_InputStyle.EndsWith(";"))
                {
                    _InputStyle += ";";
                }
                //this.StateHasChanged();
            }
        }
        /// <summary>
        /// 标签
        /// </summary>
        [Parameter]
        public string Label { get; set; }
        /// <summary>
        /// 使标签浮动
        /// </summary>
        [Parameter]
        public bool FloatingLabel { get; set; }
        /// <summary>
        /// 可展开文本框
        /// </summary>
        [Parameter]
        public bool Expandable { get; set; }
        /// <summary>
        /// 验证不通过
        /// </summary>
        [Parameter]
        public bool Invalid { get; set; }
        /// <summary>
        /// 帮助文本
        /// </summary>
        [Parameter]
        public string Helper { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [Parameter]
        public string Error { get; set; }
        /// <summary>
        /// ICON
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public ElementReference InputRef { get; set; }
        public string InputId => $"{Id}-input";

        protected virtual string InputTag => "input";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-textfield-floating-label", () => FloatingLabel)
                .If("mdui-textfield-expandable", () => Expandable)
                .If("mdui-textfield-invalid", () => Invalid)
                ;
        }

        /// <summary>
        /// 验证无效
        /// </summary>
        /// <returns></returns>
        public async Task SetInvalid()
        {
            if (!Invalid)
            {
                Invalid = true;
                await InvokeAsync(StateHasChanged);
            }
        }
        /// <summary>
        /// 验证有效
        /// </summary>
        /// <returns></returns>
        public async Task SetValid()
        {
            if (Invalid)
            {
                Invalid = false;
                await InvokeAsync(StateHasChanged);
            }
        }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "id", Id);
            builder.AddAttribute(2, "class", ClassMapper);
            builder.AddAttribute(3, "style", Style);
            builder.AddElementReferenceCapture(4, x => Ref = x);
            builder.AddContent(5, ChildContent);//icon
            //label
            if (!string.IsNullOrEmpty(Label))
            {
                builder.AddContent(6, builder2 =>
                {
                    builder2.OpenElement(0, "label");
                    builder2.AddAttribute(1, "class", "mdui-textfield-label");
                    builder2.AddContent(2, Label);
                    builder2.CloseElement();
                });
            }
            //input
            builder.AddContent(7, builder2 =>
            {
                builder2.OpenElement(0, InputTag);
                builder2.AddMultipleAttributes(1, AdditionalAttributes);
                builder2.AddAttribute(2, "class", $"mdui-textfield-input {InputClass} {CssClass}");
                builder2.AddAttribute(3, "style", InputStyle);
                builder2.AddAttribute(4, "id", InputId);
                builder2.AddAttribute(5, "value", CurrentValueAsString);
                builder2.AddAttribute(6, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
                builder2.SetUpdatesAttributeName("value");
                builder2.AddElementReferenceCapture(7, __inputReference => InputRef = __inputReference);
                builder2.CloseElement();
            });
            //error
            if (!string.IsNullOrEmpty(Error))
            {
                builder.AddContent(8, builder2 =>
                {
                    builder2.OpenElement(0, "div");
                    builder2.AddAttribute(1, "class", "mdui-textfield-error");
                    builder2.AddContent(2, Error);
                    builder2.CloseElement();
                });
            }
            //helper
            if (!string.IsNullOrEmpty(Helper))
            {
                builder.AddContent(9, builder2 =>
                {
                    builder2.OpenElement(0, "div");
                    builder2.AddAttribute(1, "class", "mdui-textfield-helper");
                    builder2.AddContent(2, Helper);
                    builder2.CloseElement();
                });
            }
            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
