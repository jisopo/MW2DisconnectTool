// Filename:  HttpServer.cs        
// Author:    Benjamin N. Summerton <define-private-public>        
// License:   Unlicense (http://unlicense.org/)

using System;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

namespace MW2DisconnectTool
{
    class HttpServer
    {
        public static HttpListener listener;
        public string[] urls;
        public static int pageViews = 0;
        public static int requestCount = 0;
        private static StringBuilder pageData = new StringBuilder(10024);
        private static StringBuilder ipBans = new StringBuilder(5048);

        public static async Task HandleIncomingConnections(string url)
        {
            bool runServer = true;

            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer)
            {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener.GetContextAsync();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                // If `shutdown` url requested w/ POST, then shutdown the server after serving the page
                if ((req.HttpMethod == "POST") && (req.Url.AbsolutePath == "/shutdown"))
                {
                    Console.WriteLine("Shutdown requested");
                    runServer = false;
                }

                if (req.Url.AbsolutePath.Contains("jisopo/kickHost"))
                {
                    MainForm.banIp();
                }

                if (req.Url.AbsoluteUri.Contains("jisopo/unban"))
                {
                    var splitted = req.Url.AbsoluteUri.Split(new string[] { "unban?" }, StringSplitOptions.None);

                    if(splitted.Length > 1)
                    {
                        string targetIp = splitted[1];

                        MainForm.removeIpBan(targetIp);
                    }
                }

                if (req.Url.AbsolutePath.Contains("jisopo/clearBans"))
                {
                    MainForm.removeAllIPBans();
                }

                ipBans.Clear();
                int count = 1;
                foreach (var host in MainForm.bannedHosts)
                {
                    ipBans.Append($"<tr><td>{count}</td><td>{host.time}</td><td>{host.targetIp}</td><td><form method=\"post\" action=\"jisopo\\unban?{host.targetIp}\"><button name=\"Test1\" value=\"Test1\">Unban</button></form></td></tr>");
                    count++;
                }

                pageData.Clear();
                pageData.Append("<!DOCTYPE html>" +
                                "<html>" +
                                "  <head>" +
                                $"    <title>MW2DisconnectToolVersion v{MainForm.MW2DisconnectToolVersion}</title>" +
                                "  </head>" +
                                "  <body style='background-color:black;'>" +
                                "    <form method=\"post\" action=\"kickHost\">" +
                                "      <input type=\"submit\" value=\"Force disconnect\" {1}>" +
                                "    </form>" +
                                "    <form method=\"post\" action=\"clearBans\">" +
                                "      <input type=\"submit\" value=\"Clear bans\" {1}>" +
                                "    </form>" +
                                "   <table border='1' style='background-color:white;'>" +
                                "<tr style='background-color:white;'>" +
                                "<th>¹</th>" +
                                "<th>Date/Time</th>" +
                                "<th>IP</th>" +
                                "<th></th>" + // Unban
                                ipBans.ToString() +
                                "</tr>" +
                                "</table>" +
                                "    </form>" +
                                "  </body>" +
                                "</html>");

                byte[] data = Encoding.UTF8.GetBytes(pageData.ToString());

                resp.ContentType = "text/html;charset=utf-8;";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                if(req.Url.AbsolutePath != "/jisopo/")
                {
                    resp.Redirect(url);
                }

                // Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }
        

        public HttpServer(string[] urls)
        {
            this.urls = urls;

            // Create a Http server and start listening for incoming connections
            listener = new HttpListener();

            foreach (var url in urls)
            {
                listener.Prefixes.Add(url);
            }

            listener.Start();

            // Handle requests
            Task listenTask = HandleIncomingConnections(this.urls.First());
            listenTask.GetAwaiter().GetResult();

            // Close the listener
            listener.Close();
        }
    }
}
