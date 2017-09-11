using System;
using System.Web;
using System.Web.Mvc;

namespace web.Models.Binders
{
    public class EnumModelBinder<T> : DefaultModelBinder where T : struct, IConvertible
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value != null)
            {
                var rawValues = value.RawValue as string[];

                if (rawValues != null)
                {
                    T result;
                    if (Enum.TryParse<T>(string.Join(",", rawValues), out result)) return result;
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}