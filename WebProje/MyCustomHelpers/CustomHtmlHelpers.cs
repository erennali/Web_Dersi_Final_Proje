using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace WebProje.MyCustomHelpers
{
    public static class CustomHtmlHelpers
    {
        //Rezervasyon Index de kullanılan custom html helperlar
        //Ad Soyad
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string label)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<label for='{0}'>{1}</label>", name, label);
            builder.AppendFormat("<input type='text' id='{0}' name='{0}' class='form-control' />", name);
            builder.AppendFormat("<span class='text-danger' data-valmsg-for='{0}'></span>", name);
            return new HtmlString(builder.ToString());
        }
        //Telefon
        public static IHtmlContent CustomPhoneBox(this IHtmlHelper htmlHelper, string name, string label)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<label for='{0}'>{1}</label>", name, label);
            builder.AppendFormat("<input type='text' id='{0}' name='{0}' class='form-control' oninput='this.value = this.value.replace(/[^0-9]/g, \"\")' />", name);
            builder.AppendFormat("<span class='text-danger' data-valmsg-for='{0}'></span>", name);
            return new HtmlString(builder.ToString());
        }
        //E-Posta
        public static IHtmlContent CustomEmailBox(this IHtmlHelper htmlHelper, string name, string label)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<label for='{0}'>{1}</label>", name, label);
            builder.AppendFormat("<input type='email' id='{0}' name='{0}' class='form-control' />", name);
            builder.AppendFormat("<span class='text-danger' data-valmsg-for='{0}'></span>", name);
            return new HtmlString(builder.ToString());
        }

        //Kişi Sayısı
        public static IHtmlContent CustomDropDownList(this IHtmlHelper htmlHelper, string name, string label, List<SelectListItem> items)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<label for='{0}'>{1}</label>", name, label);
            builder.AppendFormat("<select id='{0}' name='{0}' class='form-control nice-select wide'>", name);

            foreach (var item in items)
            {
                var selected = item.Selected ? "selected" : "";
                var disabled = item.Disabled ? "disabled" : "";
                builder.AppendFormat("<option value='{0}' {1} {2}>{3}</option>", 
                    item.Value, selected, disabled, item.Text);
            }

            builder.Append("</select>");
            builder.AppendFormat("<span class='text-danger' data-valmsg-for='{0}'></span>", name);
            return new HtmlString(builder.ToString());
        }

        //Tarih
        public static IHtmlContent CustomDateTimePicker(this IHtmlHelper htmlHelper, string name, string label)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<label for='{0}'>{1}</label>", name, label);
            builder.AppendFormat("<input type='datetime-local' id='{0}' name='{0}' class='form-control' />", name);
            builder.AppendFormat("<span class='text-danger' data-valmsg-for='{0}'></span>", name);
            return new HtmlString(builder.ToString());
        }
    }
}