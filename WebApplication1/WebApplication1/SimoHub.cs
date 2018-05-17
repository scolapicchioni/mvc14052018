using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication1
{
    public class SimoHub : Hub
    {
        public void ServerMethod1(string parameter1, int parameter2)
        {
            Clients.All.clientMethod("hi from the server...");
        }
    }
}