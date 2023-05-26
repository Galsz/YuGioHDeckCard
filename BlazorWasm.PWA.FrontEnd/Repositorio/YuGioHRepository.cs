using BlazorWasm.Compartilhado.Entidades;
using BlazorWasm.FrontEnd.Helpers;
using BlazorWasm.FrontEnd.Repositorio;

namespace BlazorWasm.PWA.FrontEnd.Repositorio
{
    public class YuGioHRepository : IRepository<YuGioH>
    {
        private readonly IHttpService httpService;
        private string url = "api/YuGioH";

        public YuGioHRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<YuGioH>> Get()
        {
            var response = await httpService.Get<List<YuGioH>>(url);

            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task<YuGioH> Get(int Id)
        {
            var response = await httpService.Get<YuGioH>($"{url}/{Id}");
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }


        public async Task Add(YuGioH item)
        {

            var response = await httpService.Post(url, item);
            if (response.Sucesso == false)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task<int> AddAndGetId(YuGioH item)
        {
            var response = await httpService.Post<YuGioH, int>(url, item);
            if (response.Sucesso == false)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }


        public async Task Update(YuGioH item)
        {
            var response = await httpService.Put(url, item);
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Delete(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }


    }
}
