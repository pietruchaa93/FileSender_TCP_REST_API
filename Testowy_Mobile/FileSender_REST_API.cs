using System.Net.Sockets;
using System.Net;
using System.IO;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android;
using Android.Content.PM;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace FileSender_TCP_REST_API
{

    public class FileSender_REST_API
        {
        public static async Task Start()
        {
            var filePath = "/storage/emulated/0/pirometryJSW.db3";
            try
            {
                if (File.Exists(filePath))
                {
                    FileAttributes attributes = File.GetAttributes(filePath);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        //Console.WriteLine("Plik jest tylko do odczytu.");
                    }
                    else
                    {
                        var fileStream = File.OpenRead(filePath);
                        // dalsza część kodu, np. wysyłanie pliku przez sieć
                    }
                }
                else
                {
                    //Console.WriteLine("Plik nie istnieje.");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
            var fileName = Path.GetFileName(filePath);
            var url = "http://192.168.1.40:21136/upload"; // adres URL aplikacji konsolowej na komputerze docelowym

            using (var client = new HttpClient())
            {
                using (var formData = new MultipartFormDataContent())
                {
                    var fileStream = File.OpenRead(filePath);
                    formData.Add(new StreamContent(fileStream), "file", fileName);

                    var response = await client.PostAsync(url, formData);

                    if (response.IsSuccessStatusCode)
                    {
                        //Console.WriteLine("Plik został wysłany pomyślnie.");
                    }
                    else
                    {
                        //Console.WriteLine("Wystąpił błąd podczas wysyłania pliku.");
                    }
                }
            }
        }

    }
    }

    

    //public async Task UploadFile(string filePath)
    //{
    //    using (var client = new HttpClient())
    //    {
    //        var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
    //        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
    //        {
    //            FileName = Path.GetFileName(filePath)
    //        };

    //        var formData = new MultipartFormDataContent();
    //        formData.Add(fileContent);

    //        var response = await client.PostAsync("http://192.168.0.2:5000/upload", formData);
    //        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
    //    }





    
