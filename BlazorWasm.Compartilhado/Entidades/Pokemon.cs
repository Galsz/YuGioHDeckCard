using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm.Compartilhado.Entidades
{
    public class YuGioH : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string GolpePrincipal { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public string ImgUrl { get; set; }
    }
}
