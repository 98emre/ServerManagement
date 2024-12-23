using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServerManagement.Models;

namespace ServerManagement.StateStore
{
    public class SessionStorage
    {
        private readonly ProtectedSessionStorage _ProtectedSessionStorage;

        public SessionStorage(ProtectedSessionStorage protectedSessionStorage)
        {
            this._ProtectedSessionStorage = protectedSessionStorage;
        }

        public async Task<Server?> GetServerAsync()
        {
            var result = await this._ProtectedSessionStorage.GetAsync<Server>("server");

            if(result.Success)
            {
                return result.Value;
            }

            else
            {
                return null;
            }
        }

        public async Task SetServerAsync(Server? server)
        {
            await this._ProtectedSessionStorage.SetAsync("server", server);
        }

        public async Task<Server?> GetCityAsync()
        {
            var result = await this._ProtectedSessionStorage.GetAsync<Server>("city");

            if (result.Success)
            {
                return result.Value;
            }

            else
            {
                return null;
            }
        }

        public async Task SetCityAsync(string cityName)
        {
            await this._ProtectedSessionStorage.SetAsync("city", cityName);
        }
    }
}
