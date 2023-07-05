using Newtonsoft.Json;
using System.Net;

public class BitlyShortener
{
    private string apiKey;

    public BitlyShortener(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public string ShortenUrl(string longUrl)
    {
        using (var client = new WebClient())
        {
            client.Headers.Add("Authorization", $"Bearer {apiKey}");
            client.Headers.Add("Content-Type", "application/json");

            var requestData = new { long_url = longUrl };
            
            string requestBody = JsonConvert.SerializeObject(requestData);

            try
            {
                string response = client.UploadString("https://api-ssl.bitly.com/v4/shorten", "POST", requestBody);
                dynamic responseData = JsonConvert.DeserializeObject(response);
                string shortUrl = responseData.link;

                return shortUrl;
            }
            catch (WebException ex)
            {
                Console.WriteLine("Erro na solicitação: " + ex.Message);
            }
        }

        return null;
    }
}
