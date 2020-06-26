using ManagerService.Entities.Entities;
using ManagerService.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace ManagerService.Repositories.Impl
{
    public class TerminalAdministratorDAOImpl : ITerminalAdministratorDAO
    {
        public DataTerminal GetDataTerminal(Socket socket, byte[] info)
        {
            DecoderInfo(socket, info);
            DataTerminal resp = new DataTerminal();
            return resp;
        }
        private void DecoderInfo(Socket sock, byte[] a)
        {
            DataTerminal resp = new DataTerminal();
            //return resp;
            string data = Encoding.UTF8.GetString(a);

            resp.Header = DecoderHeader(data);
            resp.Body = DecoderBody(data);
            //string cdata = Enum.GetName(typeof(Enums.Command), Enums.Command.Cdata);
            //Enum.GetName(typeof(Command),Command.Cdata).ToLower()
            string command = (string.IsNullOrEmpty(resp.Header.Command)) ? Commands.NotValid : resp.Header.Command;
            string typeRequest = resp.Header.TypeRequest;
            switch (command)
            {
                case Commands.Cdata:
                    if ("GET".Equals(typeRequest))
                    {
                        var _v = "";
                    }
                    else if ("POST".Equals(typeRequest))
                    {
                        var _vv = "";
                    }
                    break;
                case Commands.GetRequest:
                    if ("GET".Equals(typeRequest))
                    {
                        var vv = "";
                    }
                    break;
                case Commands.DeviceCMD:

                    break;
                case Commands.Fdata:
                    if ("POST".Equals(typeRequest))
                    {
                        var vvv = "";
                    }
                    break;
                case Commands.Login:

                    break;
                case Commands.Registry:

                    break;
                case Commands.RtData:

                    break;
                case Commands.QueryData:

                    break;
                default:

                    break;
            }

            if (resp.Header.Command.Equals("getrequest"))
            {
                // response2(sock, a);
                response(sock, a);
            }
            else
            {
                response(sock, a);
            }

        }
        public static DataTerminalHeader DecoderHeader(string data)
        {
            string[] headerAndBody = Regex.Split(data, "\r\n\r\n");
            string header = headerAndBody[0];
            string[] responseArray = Regex.Split(header, "\r\n");
            DataTerminalHeader resp = new DataTerminalHeader();
            string typeRequest = responseArray[0].Split(' ')[0];
            resp.TypeRequest = typeRequest;
            string versionHTTP = responseArray[0].Split(' ')[2];
            resp.VersionHTTP = versionHTTP;
            string commandParams = responseArray[0].Split(' ')[1];
            var splitt = commandParams.Split('/');
            var splitt2 = splitt.GetValue(2).ToString().Split('?');
            string command = splitt2.GetValue(0).ToString();
            resp.Command = command;
            resp.Parameters = GetParams(commandParams);
            return resp;
        }
        public static DataTerminalBody DecoderBody(string data)
        {
            string[] headerAndBody = Regex.Split(data, "\r\n\r\n");
            string body = headerAndBody[1];
            DataTerminalBody resp = new DataTerminalBody();
            resp.Data = body;
            return resp;
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
