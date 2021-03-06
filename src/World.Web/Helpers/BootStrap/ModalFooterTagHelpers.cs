﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using TagHelpersSamples.Bootstrap;

namespace TagHelpersSamples.Bootstrap
{
    [HtmlTargetElement("modal-footer", ParentTag = "modal")]
    public class ModalFooterTagHelper : TagHelper
    {
        public bool ShowDismiss { get; set; } = true;

        public string DismissText { get; set; } = "Cancel";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (ShowDismiss)
            {
                output.PreContent.AppendFormat(@"<button type='button' class='btn btn-default' data-dismiss='modal'>{0}</button>", DismissText);
            }
            var childContent = await output.GetChildContentAsync();
            var footerContent = new DefaultTagHelperContent();
            if (ShowDismiss)
            {
                footerContent.AppendFormat(@"<button type='button' class='btn btn-default' data-dismiss='modal'>{0}</button>", DismissText);
            }
            footerContent.AppendHtml(childContent);
            var modalContext = (ModalContext)context.Items[typeof(ModalTagHelper)];
            modalContext.Footer = footerContent;
            output.SuppressOutput();
        }
    }
}