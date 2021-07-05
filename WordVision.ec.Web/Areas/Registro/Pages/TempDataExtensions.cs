using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;

namespace WordVision.ec.Web.Areas.Registro.Pages
{
    public static class TempDataExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
         
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out var o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string) o);
        }
    }

}