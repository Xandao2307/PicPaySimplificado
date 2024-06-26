﻿using PicPaySimplificado.Services.Services.Authorize.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.Authorize
{
    public class AuthorizeService
    {
        private string _urlMock = "https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc";
        public async Task<bool> Authorizer()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_urlMock);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = JsonSerializer.Deserialize<ResponseHttp>(await response.Content.ReadAsStringAsync());
                        if (json != null || json.message.Trim() == "Autorizado") 
                            return true;

                    }
                    else
                        throw new UnauthorizeException("Unauthotize");
                }
                catch (Exception e)
                {
                    throw new UnauthorizeException("Error in request" + e.Message);
                }
                return false;
            }

        }

        private class ResponseHttp
        {
            public string message { get; set; }
        }


    }
}
