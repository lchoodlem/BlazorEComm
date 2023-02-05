using Microsoft.AspNetCore.Components;

namespace BlazorEComm.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private HttpClient _http;
        private AuthenticationStateProvider _authStateProvider;
        private NavigationManager _navigationManager;

        public OrderService(HttpClient http,
            AuthenticationStateProvider authStateProvider,
            NavigationManager navigationManager)
        {
            _http = http;
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
        }

        public async Task<List<OrderOverviewResponse>> GetOrders()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
            return result.Data;
        }

        public async Task PlaceOrder()
        {
           if (await IsUserAuthenticated())
            {
                await _http.PostAsync("api/order", null);
            }
           else
            {
                _navigationManager.NavigateTo("Login");
            }
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

    }
}
