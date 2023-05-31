using BlazorWasm.Compartilhado.Entidades;
using BlazorWasmServer.Server.Helpers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWasmServer.Server.Controllers
{
    [ApiController]

    [Route("api/YuGioH")]
    public class YuGioHController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService _fileStorageService;
        public YuGioHController(ApplicationDbContext context, IFileStorageService fileStorageService)
        {
            this.context = context;
            _fileStorageService = fileStorageService;

        }

        #region Teste
        //[HttpGet("teste/{nome}")]
        //public async Task<ActionResult<int>> Teste(string Nome)
        //{
        //    Pokemon pokemon = new Pokemon();
        //    pokemon.Nome = Nome;
        //    context.Pokemons.Add(pokemon);
        //    await context.SaveChangesAsync();
        //    return pokemon.Id;
        //}
        #endregion

        [HttpGet]
        public async Task<ActionResult<List<YuGioH>>> Get()
        {
            return await context.Cards.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<YuGioH>> Get(int id)
        {
            var resp = await context.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (resp == null) { return NotFound(); }
            return resp;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(YuGioH yuGioH)
        {
            if (!string.IsNullOrEmpty(yuGioH.ImgUrl))
            {
                var img = Convert.FromBase64String(yuGioH.ImgUrl);
                yuGioH.ImgUrl = await _fileStorageService.SaveFile(img, "jpg", "img");
            }

            context.Cards.Add(yuGioH);
            await context.SaveChangesAsync();
            return yuGioH.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(YuGioH yuGioH)
        {
            context.Attach(yuGioH).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var yuGioH = await context.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (yuGioH == null)
            {
                return NotFound();
            }

            context.Remove(yuGioH);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}
