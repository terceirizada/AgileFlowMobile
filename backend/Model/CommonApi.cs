using RestSharp;
using System.Net;

namespace AgileFlowMobile.backend.Model
{
    public class CommonApi
    {
        public static IRestResponse DoGetWithJson(string url)
        {
            //configura o protocolo de conexão TSL 1.2 (disponível apenas nas versões 3.5 do .NET)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //configura a requisição web por meio da RestSharp (API opensource)
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            // Adiciona o cabeçalho com o token obtido anteriormente
            string authToken = Preferences.Get("AuthToken", "", "");
            request.AddHeader("TokenApi", authToken);
            request.AddHeader("Content-Type", "application/json");

            //faz a chamada a API RESTFULL e processa os retornos
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse DoPostWithJson(string url, string jsonBody)
        {
            //configura o protocolo de conexão TSL 1.2 (disponível apenas nas versões 3.5 do .NET)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //configura a requisição web por meio da RestSharp (API opensource)
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            // Adiciona o cabeçalho com o token obtido anteriormente
            string authToken = Preferences.Get("AuthToken", "", "");
            request.AddHeader("TokenApi", authToken);
            request.AddHeader("Content-Type", "application/json");

            // Adiciona o JSON serializado no corpo da requisição
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            // Faz a chamada à API RESTful e processa os retornos
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse DoPutWithJson(string url, string jsonBody)
        {
            //configura o protocolo de conexão TSL 1.2 (disponível apenas nas versões 3.5 do .NET)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //configura a requisição web por meio da RestSharp (API opensource)
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.RequestFormat = DataFormat.Json;

            // Adiciona o cabeçalho com o token obtido anteriormente
            string authToken = Preferences.Get("AuthToken", "", "");
            request.AddHeader("TokenApi", authToken);
            request.AddHeader("Content-Type", "application/json");

            // Adiciona o JSON serializado no corpo da requisição
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            // Faz a chamada à API RESTful e processa os retornos
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse DoDeleteWithJson(string url, string jsonBody)
        {
            //configura o protocolo de conexão TSL 1.2 (disponível apenas nas versões 3.5 do .NET)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //configura a requisição web por meio da RestSharp (API opensource)
            var client = new RestClient(url);
            var request = new RestRequest(Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            // Adiciona o cabeçalho com o token obtido anteriormente
            string authToken = Preferences.Get("AuthToken", "", "");
            request.AddHeader("TokenApi", authToken);
            request.AddHeader("Content-Type", "application/json");

            //adiciona o json serializado no corpo da requisição
            request.AddParameter("application/json; charset=utf-8", jsonBody, ParameterType.RequestBody);

            //faz a chamada a API RESTFULL e processa os retornos
            IRestResponse response = client.Execute(request);

            return response;
        }

    }
}