using InvoiceMaker.Data;
using InvoiceMaker.Initialization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace InvoiceMaker
{
    public class InvoiceMakerApplication : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Debug.WriteLine("Application_Start");
            RouteConfiguration.AddRoutes(RouteTable.Routes);

            // Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            Database.SetInitializer(new DatabaseInitializer());
        }

        protected void HandleBeginRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("HandleBeginRequest");
        }

        protected void HandleAuthenticateRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("HandleAuthenticateRequest");
        }
        protected void HandlePostAuthenticateRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("HandlePostAuthenticateRequest");
        }
        protected void HandleAuthorizeRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("HandleAuthorizeRequest");
        }
        protected void HandlePostAuthorizeRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("HandlePostAuthorizeRequest");
        }
        protected void HandleResolveRequestCache(object sender, EventArgs e)
        {
            Debug.WriteLine("HandleResolveRequestCache");
        }
        protected void HandlePostResolveRequestCache(object sender, EventArgs e)
        {
            Debug.WriteLine("HandlePostResolveRequestCache");
        }
        protected void HandleMapRequestHandler(object sender, EventArgs e)
        {
            Debug.WriteLine("HandleMapRequestHandler");
        }
        protected void HandlePostMapRequestHandler(object sender, EventArgs e)
        {
            Debug.WriteLine("HandlePostMapRequestHandler");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_End");
        }


        public override void Init()
        {
            base.Init();
            BeginRequest += HandleBeginRequest;
            AuthenticateRequest += HandleAuthenticateRequest;
            PostAuthenticateRequest += HandlePostAuthenticateRequest;
            AuthorizeRequest += HandleAuthorizeRequest;
            PostAuthorizeRequest += HandlePostAuthorizeRequest;
            ResolveRequestCache += HandleResolveRequestCache;
            PostResolveRequestCache += HandlePostResolveRequestCache;
            MapRequestHandler += HandleMapRequestHandler;
            PostMapRequestHandler += HandlePostMapRequestHandler;
            // Uncomment these and subscribe to them like above
            //AcquireRequestState 
            //PostAcquireRequestState
            //PreRequestHandlerExecute
            //PostRequestHandlerExecute
            //ReleaseRequestState
            //PostReleaseRequestState
            //UpdateRequestCache
            //PostUpdateRequestCache
            //LogRequest
            //PostLogRequest
            //EndRequest
        }
    }
}