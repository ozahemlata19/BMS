﻿using BMSWPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPF.ViewModel.Helpers
{
    class PreviousAppliedLoanHelper
    {
        public const string BASE_URL = "http://localhost:34911/api/";
        public const string GET_URL = "ApplyLoan/all/{0}";
        public const string ADMIN_GET_URL = "ApplyLoan/all";

        public static async Task<IEnumerable<LoanDetail>> GetUserLoanDetail(string userName)
        {
            List<LoanDetail> loanDetail;
            string URL = BASE_URL + string.Format(GET_URL, userName);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                loanDetail = JsonConvert.DeserializeObject<List<LoanDetail>>(json);
            };

            return loanDetail;
        }

        public static async Task<IEnumerable<LoanDetail>> GetAdminLoanDetail()
        {
            List<LoanDetail> loanDetail;
            string URL = BASE_URL + ADMIN_GET_URL;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                loanDetail = JsonConvert.DeserializeObject<List<LoanDetail>>(json);
            };

            return loanDetail;
        }

    }
}
