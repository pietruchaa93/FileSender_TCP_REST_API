using System.Net.Sockets;
using System.Net;
using System.IO;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android;
using Android.Content.PM;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace FileSender_TCP_REST_API
{
    public class FileSender_TCP
    {


        public void Start()
        {

            // Adress IP i number port 
            IPAddress ipAddress = IPAddress.Parse("192.168.1.40");
            int port = 21136;

            // Connect
            TcpClient client = new TcpClient();
            Task connectTask = Task.Run(() => client.Connect(ipAddress, port));

            if (connectTask.Wait(TimeSpan.FromSeconds(3))) 
            {
                
                NetworkStream stream = client.GetStream();
                try
                {
                    
                    string filePath = "/storage/emulated/0/file.txt"; 

                    using (FileStream fileStream = File.OpenRead(filePath))
                    {

                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }

                    }

                }
                catch
                {

                }
                finally
                {
                    // close connections
                    stream.Close();
                    client.Close();
                }





            }
        }
    }
}
