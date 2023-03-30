using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace FileSender_TCP_REST_API
{
    public partial class Uploader
    {
        
        public async void SendButton_Clicked()
        {
            string message = "Example"; // przykładowy string do wysłania
            string url = "http://192.168.1.40:21136/api/message"; // adres URL aplikacji konsolowej

            HttpClient client = new HttpClient();
            StringContent content = new StringContent(message, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Odebrano odpowiedź z serwera: " + responseString);
            }
            else
            {
                Console.WriteLine("Błąd podczas wysyłania wiadomości.");
            }
        }
    }
}