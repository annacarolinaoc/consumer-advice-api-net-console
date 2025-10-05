using System.Data.Common;
using System.Text.Json;
using ConsumerAdviceApi.Models;
using static System.Console;

var enderecoUrl = "https://api.adviceslip.com/advice";

var client = new HttpClient();

try
{
    HttpResponseMessage? respostaAPi = await client.GetAsync(enderecoUrl);

    respostaAPi.EnsureSuccessStatusCode();

    string respostaAPiJson = await respostaAPi.Content.ReadAsStringAsync();

    var conselho = JsonSerializer.Deserialize<Conselho>(respostaAPiJson);

    WriteLine("Conselho do dia: ");
    Console.WriteLine(conselho?.slip.advice);
   
    

}
catch (System.Exception e)
{

    WriteLine("Aconteceu um erro:\n" + e.Message);
}