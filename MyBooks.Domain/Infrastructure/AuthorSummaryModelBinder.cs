using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBooks.Domain.Entities;

namespace MyBooks.Domain.Infrastructure
{
    public class AuthorSummaryModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext context, ModelBindingContext bindingContext)
        {
            Author auth = (Author)bindingContext.Model ?? new Author();
            auth.author_id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("author_id"));
            auth.fname = GetValue(bindingContext, "fname");
            auth.lname = GetValue(bindingContext, "lname");
            return auth;


        }

        public string GetValue(ModelBindingContext context, string name)
        {
           // name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
            ModelMetadata a;
            var c = context.PropertyMetadata.TryGetValue(name, out a);
            ValueProviderResult res = context.ValueProvider.GetValue(name);
            if (res == null || res.AttemptedValue == "")
            {
                return "Not specified";
            }
            else
            {
                return (string)res.AttemptedValue;
            }
        }
    }
}