using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Binders
{
    public class FormModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            var dic = GroupFormKeys(form);

            var deserializeXForm = DeserializeXForm(dic, form);

            bindingContext.ModelMetadata.Model = new PaymentModel
            {
                content =  deserializeXForm,
                communication_id = form["communication_id"],
                content_size = form["content_size"]
            };

            return bindingContext.ModelMetadata.Model;
        }


        private static List<SampleModel> DeserializeXForm(IEnumerable<IGrouping<string, string>> dic, NameValueCollection form)
        {
            var deserializeXForm = new List<SampleModel>();
            foreach (var item in dic)
            {
                var sampleModel = new SampleModel();
                var reflectionType = typeof (SampleModel);
                foreach (var items in item)
                {
                    var startIndex = items.LastIndexOf("[", StringComparison.Ordinal);
                    var propertyName = items.Substring(startIndex + 1, items.Length - 2 - startIndex);
                    var property = reflectionType.GetProperty(propertyName);
                    var propertyValue = Convert.ChangeType(form[items], property.PropertyType);
                    property.SetValue(sampleModel, propertyValue);
                }
                deserializeXForm.Add(sampleModel);
            }
            return deserializeXForm;
        }

        private static IEnumerable<IGrouping<string, string>> GroupFormKeys(NameValueCollection form)
        {
            var dic = form.AllKeys.Take(form.Count - 2)
                .GroupBy(x => x.Substring(0, x.IndexOf("]") + 1));
            return dic;
        }
    }
}