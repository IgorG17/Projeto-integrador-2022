//using System;
//using System.Web;
//using System.Web.Mvc;

//[AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
//AllowMultiple = true)]
//public class AuthorizeAttribute : FilterAttribute,
//IAuthorizationFilter

//{
//    public AuthorizeAttribute() { }
  
//    protected virtual bool AuthorizeCore(HttpContextBase httpContext) { }
 
//    public virtual void OnAuthorization(AuthorizationContext filterContext);

//protected void HandleUnauthorizedRequest(AuthorizationContext filterContext);
  
//}