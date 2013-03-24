using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CocheAmigos2.Handler
{
    public class UnencriptedRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            
            foreach (var rd in requestContext.RouteData.Values.Where(x => x.Key.Equals("id")).ToList())
            {
                var value = rd.Value.ToString();
                var decrypted = !string.IsNullOrEmpty(value) ?
                    Crypto.Decrypt(value) :
                    string.Empty;
                requestContext.RouteData.Values.Remove(rd.Key);
              requestContext.RouteData.Values.Add("id", decrypted);
            }
            return base.GetHttpHandler(requestContext);
        }
    }
}