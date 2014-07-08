using System;
using System.Web.Mvc;

using Newtonsoft.Json;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     JsonResult����չ����NewtonJson�����л�
    /// </summary>
    public class NewtonJsonResult : JsonResult
    {
        /// <summary>
        ///     ����NewtonJsonResult
        /// </summary>
        public NewtonJsonResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }
        /// <summary>
        ///     ����NewtonJsonResult
        /// </summary>
        /// <param name="obj"></param>
        public NewtonJsonResult(object obj)
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            Data = obj;
        }
        /// <summary>
        ///     ����NewtonJsonResult
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="jsonSerializerSettings"></param>
        public NewtonJsonResult(object obj, JsonSerializerSettings jsonSerializerSettings)
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            Data = obj;
            JsonSerializerSettings = jsonSerializerSettings;
        }
        /// <summary>
        ///     JsonConvert.SerializeObject�ĵڶ�������
        /// </summary>
        public JsonSerializerSettings JsonSerializerSettings { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((JsonRequestBehavior == JsonRequestBehavior.DenyGet)
                && (string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("�ķ�����ǰ������ʹ��Get");
            }
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                var strJson = JsonConvert.SerializeObject(Data, JsonSerializerSettings);
                response.Write(strJson);
                response.End();
            }
        }
    }
}