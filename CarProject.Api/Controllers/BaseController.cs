using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarProject.Api.Controllers
{
    public class BaseController : Controller
    {
        internal void SetError(string error)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            HttpContext.Items.Add("exceptionMessage", error);
        }
        internal void SetMessage(string error)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            HttpContext.Items.Add("message", error);
        }
        public string RemoteIp { 
            get {
                return Request.HttpContext.Connection.RemoteIpAddress.ToString();
            } 
        }
    }
}
