using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable = 
            new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using NetworkStream stream = tcpClient.GetStream();

            List<byte> data = new List<byte>();
            int position = 0;
            byte[] buffer = new byte[HttpConstants.BufferSize];
            while (true)
            {
                int count = await stream.ReadAsync(buffer, position, buffer.Length);
                position += count;

                if (count < buffer.Length)
                {
                    var partialBuffer = new byte[count];
                    Array.Copy(buffer, partialBuffer, count);
                    data.AddRange(partialBuffer);
                    break;
                }
                else
                {
                    data.AddRange(buffer);
                }
            }

            var requestAsString = Encoding.UTF8.GetString(data.ToArray());

            Console.WriteLine(requestAsString);

            var responseHtml = "<h1>Welcome</h1>";

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            var responseHttp =
                "HTTP/1.1 200 OK" + HttpConstants.NewLine +
                "Server: SUS Server 1.0" + HttpConstants.NewLine +
                "Content-Type: text/html" + HttpConstants.NewLine +
                "Content-Length: " + responseBodyBytes.Length + HttpConstants.NewLine +
                HttpConstants.NewLine;

            var responseHeaderBytes = Encoding.UTF8.GetBytes(responseHttp);

            await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
            await stream.WriteAsync(responseBodyBytes, 0, responseBodyBytes.Length);

            tcpClient.Close();
        }
    }
}
