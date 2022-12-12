using BMSWPF.Model;
using BMSWPF.Model.RequestData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPF.ViewModel.Helpers
{
    public class LoginSecurityHelper
    {
        public const string BASE_URL = "Http://localhost:34911/api/";
        public const string GET_URL = "Login/{0}";
        public const string POST_URL = "Login";

        public static async Task<UserDetail> GetUserDetail(string userName)
        {
            UserDetail userDetail;

            string URL = BASE_URL + string.Format(GET_URL, userName);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                userDetail = JsonConvert.DeserializeObject<UserDetail>(json);
            };
            return userDetail;
        }

        public static async Task<string> LoginAgent(LoginDetail loginDetail)
        {
            string agent;
            string URL = BASE_URL + POST_URL;

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(URL, loginDetail, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json.ToString();
            }
            return agent;
        }
    }
}

