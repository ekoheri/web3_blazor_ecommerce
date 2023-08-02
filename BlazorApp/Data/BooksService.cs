namespace BlazorApp.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public interface IBooksService
{
    Task <IEnumerable<Books>> GetBooksAsync();
    Task <IEnumerable<BookDetail>> GetBookDetailAsync(string Id = "");
    Task <ActionResult<ResponseModel>> PostLogin(PostModel Data);
}
public class BooksService : IBooksService
{
    private readonly HttpClient httpClient;
    public BooksService(HttpClient _httpClient){
        this.httpClient = _httpClient;
    }
    public async Task<IEnumerable<Books>> GetBooksAsync() 
    {
        IEnumerable<Books> ? Data = null;
        Data = await this.httpClient.GetFromJsonAsync<Books[]>("books");
        if(Data != null)
            return Data.ToList();
        else
            return Array.Empty<Books>();
    }
    public async Task <IEnumerable<BookDetail>> GetBookDetailAsync(string Id = "")
    {
        try
        {
            IEnumerable<BookDetail> ? Data = null;
            HttpResponseMessage response;
            response = await this.httpClient.GetAsync("bookdetail/" + Id);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Data = JsonSerializer.Deserialize<BookDetail[]>(
                    content, new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );
                if(Data == null)
                    return Array.Empty<BookDetail>();
                else
                    return Data.ToList();
            } else 
            {
                Console.WriteLine("Error Data Kosong");
                return Array.Empty<BookDetail>();
            }
        }catch(HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
            return Array.Empty<BookDetail>();
        }catch(NotSupportedException x)
        {
            Console.WriteLine(x.Message);
            return Array.Empty<BookDetail>();
        }
    }
    public async Task <ActionResult<ResponseModel>> PostLogin(PostModel Data)
    {
        HttpResponseMessage response;
        ResponseModel ? dataUser = null;
        response = await this.httpClient.PostAsJsonAsync("login", Data);
        if(response.IsSuccessStatusCode) {
            var content = await response.Content.ReadAsStringAsync();
            dataUser = JsonSerializer.Deserialize<ResponseModel> (
                content, new JsonSerializerOptions{PropertyNameCaseInsensitive=true}
            );
            if(dataUser == null) {
                Console.WriteLine("Tidak berhasil mengambil data user");
                return new OkObjectResult(new ResponseModel(){
                    status = false
                });
            } else {
                if(dataUser.status == true) {
                    //user & pass benar
                    Console.WriteLine("Login OK");
                    return new OkObjectResult(dataUser);
                } else {
                    //user atau pass salah
                    Console.WriteLine("Login Gagal");
                    return new OkObjectResult(new ResponseModel(){
                        status = false
                    });
                }
            }
        } else {
            Console.WriteLine("Error konek ke backend");
            return new OkObjectResult(new ResponseModel(){
                status = false
            });
        }
    }
}
