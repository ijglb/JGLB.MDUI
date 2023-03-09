//https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputRadioContext.cs
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// Describes context for an <see cref="InputRadio{TValue}"/> component.
    /// </summary>
    internal sealed class InputRadioContext
    {
        public InputRadioContext? ParentContext { get; }
        public EventCallback<ChangeEventArgs> ChangeEventCallback { get; }

        // Mutable properties that may change any time an InputRadioGroup is rendered
        public string? GroupName { get; set; }
        public object? CurrentValue { get; set; }
        public string? FieldClass { get; set; }

        /// <summary>
        /// Instantiates a new <see cref="InputRadioContext" />.
        /// </summary>
        /// <param name="parentContext">The parent context, if any.</param>
        /// <param name="changeEventCallback">The event callback to be invoked when the selected value is changed.</param>
        public InputRadioContext(InputRadioContext? parentContext, EventCallback<ChangeEventArgs> changeEventCallback)
        {
            ParentContext = parentContext;
            ChangeEventCallback = changeEventCallback;
        }

        /// <summary>
        /// Finds an <see cref="InputRadioContext"/> in the context's ancestors with the matching <paramref name="groupName"/>.
        /// </summary>
        /// <param name="groupName">The group name of the ancestor <see cref="InputRadioContext"/>.</param>
        /// <returns>The <see cref="InputRadioContext"/>, or <c>null</c> if none was found.</returns>
        public InputRadioContext? FindContextInAncestors(string groupName)
            => string.Equals(GroupName, groupName) ? this : ParentContext?.FindContextInAncestors(groupName);
    }
}
