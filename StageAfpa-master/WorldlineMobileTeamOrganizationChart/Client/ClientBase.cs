using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorldlineMobileTeamOrganizationChart.Common;


namespace WorldlineMobileTeamOrganizationChart.Client
{
   class ClientBase
   {
        
        UserAccount UserAccount = new UserAccount();
        static string page = Constants.API_BASE_URI;

      

       public static async Task<List<UserAccount>> GetAccountPageAsync()
       {

            using (var httpClient = new HttpClient())
            using (HttpResponseMessage responseMessage = await httpClient.GetAsync(page))
            using (HttpContent httpContent = responseMessage.Content)
            {
                string result = await httpContent.ReadAsStringAsync();
                List<UserAccount> userAccounts = JsonConvert.DeserializeObject<List<UserAccount>>(result);
                return userAccounts;
            };
       }

         
        
            
       
       

        


    }
}
