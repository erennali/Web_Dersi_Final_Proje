using Microsoft.AspNetCore.Razor.TagHelpers;


[HtmlTargetElement("custom-link")]
public class CustomLinkTagHelper : TagHelper
{
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Text { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a"; // Oluşturulan tag tipi
        output.Attributes.SetAttribute("class", "btn btn-light btn-lg mx-3");
        output.Attributes.SetAttribute("href", $"/{Controller}/{Action}");
        output.Content.SetContent(Text);
    }
}