using ManagerService.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ManagerService.Repositories.Impl
{
    public class ListenerCustomerDAOImpl : IListenerCustomerDAO
    {
        TcpListener tcp;
        bool listener = false;
        public Thread listenThread;

        private IUserDAO userDAO;
        private ITerminalAdministratorDAO terminalAdministratorDAO;
        public ListenerCustomerDAOImpl(IUserDAO _userDAO, ITerminalAdministratorDAO _terminalAdministratorDAO)
        {
            this.terminalAdministratorDAO = _terminalAdministratorDAO;
            this.userDAO = _userDAO;
        }

        public void ListenCustomers()
        {
            Int32 port = 8089;
            IPAddress ip = IPAddress.Parse("192.168.20.230");
            try
            {
                tcp = new TcpListener(ip, port);
                tcp.Start();
                Debug.WriteLine("Listening Customers For Connect...");
                listener = true;
                while (listener)
                {
                    Socket socket = null;
                    try
                    {
                        socket = tcp.AcceptSocket();
                        Thread.Sleep(500);
                        byte[] info = new byte[1024 * 1024 * 2];
                        int i = socket.Receive(info);
                        DataTerminal dataterminal = this.terminalAdministratorDAO.GetDataTerminal(socket, info);

                        // Decoder(sock, a);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" Excepcion " + e.Message.ToString());
                        throw;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(" Excepcion " + e.Message.ToString());
                throw new Exception(" Excepcion " + e.Message.ToString());
            }
        }
        private void Decoder(Socket sock, byte[] a)
        {
            string data = Encoding.UTF8.GetString(a);
            var vva = this.userDAO.GetUsers();
            GetUrl(data);


            Debug.WriteLine(" Data Received " + data);
            var splitt = data.Split('/');
            var splitt2 = splitt.GetValue(2).ToString().Split('?');
            string valor = splitt2.GetValue(0).ToString();
            if (valor.Equals("getrequest"))
            {
                // response2(sock, a);
                response(sock, a);
            }
            else
            {
                response(sock, a);
            }

        }
        private static void GetUrl(string data)
        {
            string[] headerAndBody = Regex.Split(data, "\r\n\r\n");
            string[] responseArray = Regex.Split(data, "\r\n");
            if ((responseArray.Length) > 0)
            {
                var statusCode = responseArray[0].Split(' ')[1];
                var b = GetParams(statusCode);
            }
        }
        private static Dictionary<string, string> GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            var keyValues = new Dictionary<string, string>(matches.Count);
            foreach (Match m in matches)
                keyValues.Add(Uri.UnescapeDataString(m.Groups[2].Value), Uri.UnescapeDataString(m.Groups[3].Value));

            return keyValues;
        }
        private void response2(Socket sock, byte[] a)
        {
            string sStatusCode = "200 OK";
            string sDataStr = "C:1231907854123453:DATA QUERY USERINFO PIN=2";
            byte[] bData = Encoding.GetEncoding("UTF-8").GetBytes(sDataStr);
            string sHeader = "HTTP/1.1 " + sStatusCode + "\r\n";
            sHeader = sHeader + "Content-Type: text/plain\r\n";
            sHeader = sHeader + "Accept-Ranges: bytes\r\n";
            sHeader = sHeader + "Date: " + DateTime.Now.ToUniversalTime().ToString("r") + "\r\n";
            sHeader = sHeader + "Content-Length: " + bData.Length + "\r\n\r\n";
            byte[] sHeader2 = Encoding.GetEncoding("UTF-8").GetBytes(sHeader);

            sock.Send(sHeader2, sHeader2.Length, 0);
            sock.Send(bData, bData.Length, 0);

        }
        private void response(Socket sock, byte[] a)
        {
            string sStatusCode = "200 OK";
            string sDataStr = "OK";
            byte[] bData = Encoding.GetEncoding("UTF-8").GetBytes(sDataStr);
            string sHeader = "HTTP/1.1 " + sStatusCode + "\r\n";
            sHeader = sHeader + "Content-Type: text/plain\r\n";
            sHeader = sHeader + "Accept-Ranges: bytes\r\n";
            sHeader = sHeader + "Date: " + DateTime.Now.ToUniversalTime().ToString("r") + "\r\n";
            sHeader = sHeader + "Content-Length: " + bData.Length + "\r\n\r\n";
            byte[] sHeader2 = Encoding.GetEncoding("UTF-8").GetBytes(sHeader);

            sock.Send(sHeader2, sHeader2.Length, 0);
            sock.Send(bData, bData.Length, 0);
            //MessageBox.Show("System", " llamada enviada ");
        }
    }
}
