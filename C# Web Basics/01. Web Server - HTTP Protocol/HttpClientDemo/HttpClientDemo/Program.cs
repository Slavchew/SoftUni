using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    internal class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();
        const string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
                // ProcessClient(client);
            }
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            using var stream = client.GetStream();

            byte[] buffer = new byte[1000000];
            var length = await stream.ReadAsync(buffer, 0, buffer.Length);

            string requestString = Encoding.UTF8.GetString(buffer, 0, length);
            Console.WriteLine(requestString);

            var sid = Guid.NewGuid().ToString();
            var match = Regex.Match(requestString, @"sid=[^\n]*\r\n");
            if (match.Success)
            {
                sid = match.Value.Substring(4);
            }

            if (!SessionStorage.ContainsKey(sid))
            {
                SessionStorage.Add(sid, 0);
            }

            SessionStorage[sid]++;

            string html = $"<h1>Hello from IcetoServer {DateTime.Now} for the {SessionStorage[sid]} time<h1>" +
                $"<form action=/tweet method=post><input name=username /><input name=password />" +
                $"<input type=submit /></form>";

            string response = "HTTP/1.1 200 OK" + NewLine +
                "Server: IcetoServer 2022" + NewLine +
                // "Location: https://www.google.com" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
                "X-Server-Version: 1.0" + NewLine +
                $"Set-Cookie: sid={sid}; HttpOnly; Max-Age=" + (100 * 24 * 60 * 60) + NewLine +
                // "Content-Disposition: attachment; filename=text.txt" + NewLine +
                "Content-Length: " + html.Length + NewLine +
                NewLine +
                html +
                NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(responseBytes);

            Console.WriteLine(new string('=', 70));
        }

        public static void ProcessClient(TcpClient client)
        {
            using var stream = client.GetStream();

            byte[] buffer = new byte[1000000];
            var length = stream.Read(buffer, 0, buffer.Length);

            string requestString = Encoding.UTF8.GetString(buffer, 0, length);
            Console.WriteLine(requestString);

            string html = $"<h1>Hello from IcetoServer {DateTime.Now}<h1>" +
                $"<form action=/tweet method=post><input name=username /><input name=password />" +
                $"<input type=submit /></form>";

            string response = "HTTP/1.1 200 OK" + NewLine +
                "Server: IcetoServer 2022" + NewLine +
                // "Location: https://www.google.com" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
                // "Content-Disposition: attachment; filename=text.txt" + NewLine +
                "Content-Length: " + html.Length + NewLine +
                NewLine +
                html +
                NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes);

            Console.WriteLine(new string('=', 70));
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/curriculum";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}
