using System;

namespace WebAPI.Models
{
    public class ProdutoModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Quantidade { get; set; }
    }
}