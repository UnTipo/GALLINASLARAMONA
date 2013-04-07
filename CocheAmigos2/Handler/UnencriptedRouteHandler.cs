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
            //***COMENTARIO


            foreach (var rd in requestContext.RouteData.Values.ToList())
            {
                var id = "";
                var pw = "";
                if (rd.Key.Equals("id"))
                {
                    id = rd.Value.ToString();
                    var decryptedid = !string.IsNullOrEmpty(id) ?
                   Crypto.Decrypt(id) :
                   string.Empty;
                    requestContext.RouteData.Values.Remove("id");
                    requestContext.RouteData.Values.Add("id", decryptedid);
                }
                if (rd.Key.Equals("pw"))
                {
                    pw = rd.Value.ToString();
                    var decryptedpw = !string.IsNullOrEmpty(pw) ?
              Crypto.Decrypt(pw) :
              string.Empty;
                    requestContext.RouteData.Values.Remove("pw");
                    requestContext.RouteData.Values.Add("pw", decryptedpw);
                }



            }
            return base.GetHttpHandler(requestContext);
        }
    }


    public class UnencriptedRouteHandler1 : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            //***COMENTARIO


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