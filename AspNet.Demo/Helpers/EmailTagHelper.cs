using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Demo.Helpers
{
    //<email mail-to="roberto.ajolfi"></email>
    // ====>
    //<a href="mailto:roberto.ajolfi@icubed.it">Send a Mail</a>
    // -----
    //<email mail-to="roberto.ajolfi@icubed.it">Roberto Ajolfi</email>
    //<a href="mailto:roberto.ajolfi@icubed.it">Send Mail to Roberto Ajolfi</a>

    //<a href="">Roberto Ajolfi</a>

    //[HtmlTargetElement("div")]
    public class EmailTagHelper : TagHelper
    {
        //private const string Domain = "icubed.it";
        public string MailTo { get; set; }

        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    output.TagName = "a";

        //    output.Attributes.SetAttribute("href", "mailto:" + this.MailTo); // + "@" + Domain);

        //    output.Attributes.SetAttribute("style", "background-color: red; color: yellow; font-weight: bold;");

        //    output.Content.SetContent("Send a Mail");
        //}

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            output.Attributes.SetAttribute("href", "mailto:" + this.MailTo); // + "@" + Domain);

            output.Attributes.SetAttribute("style", "background-color: red; color: yellow; font-weight: bold;");

            var content = await output.GetChildContentAsync();

            output.Content.SetContent($"Send mail to {content.GetContent()}");
        }
    }
}
