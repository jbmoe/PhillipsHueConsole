using System.Net.Http;
using System.Threading.Tasks;

namespace PhillipsHueConsole.controller {
    class NetworkController {
        #region singleton
        private static NetworkController _instance;
        public static NetworkController GetInstance() {
            if (_instance == null) {
                _instance = new NetworkController();
            }
            return _instance;
        }
        private NetworkController() { }
        #endregion
        #region network fields
        HttpClient client = new HttpClient();
        const string URL = "http://192.168.87.124/api/5plLWq0PmCMOrBATXB2CEBonBb3OsRHtsZK2n7FQ/";
        #endregion
        #region network methods
        public async Task<HttpResponseMessage> Put(string url, HttpContent content) {
            HttpResponseMessage response = await client.PutAsync(URL + url, content);

            string responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent.Contains("error")) throw new HttpRequestException("Fejl i request:\n" + responseContent);

            return response;
        }
        public async Task<string> Get(string url) {
            string response = await client.GetStringAsync(URL + url);
            return response;
        }
        #endregion
    }
}
