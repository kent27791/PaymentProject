using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Payment.Common
{
    public static class StringHelper
    {
        public static string ConvertObjectToQueryString<T>(T obj)
        {
            StringBuilder data = new StringBuilder();
            Type type = obj.GetType();
            //var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            //    .Where(p => p.IsDefined(typeof(JsonPropertyAttribute)))
            //    .OrderBy(p => p.GetCustomAttribute<JsonPropertyAttribute>().Order);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.IsDefined(typeof(FromQueryAttribute)));
            foreach (PropertyInfo prop in props)
            {
                var jsonAttr = prop.GetCustomAttribute<FromQueryAttribute>();
                var key = jsonAttr.Name;
                var value = prop.GetValue(obj);
                if (value != null)
                {
                    data.Append(key + "=" + HttpUtility.UrlEncode(Convert.ToString(value)) + "&");
                }
            }
            //remove trailing & from string
            if (data.Length > 0)
                data.Remove(data.Length - 1, 1);

            return data.ToString();

        }
    }
}
