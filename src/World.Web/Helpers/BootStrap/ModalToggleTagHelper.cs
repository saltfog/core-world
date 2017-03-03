using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersSamples.Bootstrap
{
    [HtmlTargetElement(Attributes = ModalTargetAttributeName)]
    public class ModalToggleTagHelper : TagHelper
    {
        public const string ModalTargetAttributeName = "bs-toggle-modal";
        
        [HtmlAttributeName(ModalTargetAttributeName)]
        public string ToggleModal { get; set; }

      
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("data-toggle", "modal");
            output.Attributes.SetAttribute("data-target", $"#{ToggleModal}");
        }
    }
}
