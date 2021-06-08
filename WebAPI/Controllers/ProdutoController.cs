using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private static readonly List<ProdutoModel> listaProdutos = new List<ProdutoModel>();

        [AcceptVerbs("POST")]
        [Route("CadastreProduto")]
        public void CadastreProduto(ProdutoModel produto) =>
            listaProdutos.Add(produto);

        [AcceptVerbs("PUT")]
        [Route("AltereProduto")]
        public void AltereProduto(ProdutoModel produto) => 
            listaProdutos.Where(p => p.Codigo == produto.Codigo)
                         .Select(p =>
                         {
                             p.Codigo = produto.Codigo;
                             p.Nome = produto.Nome;
                             p.DataPublicacao = produto.DataPublicacao;
                             p.Preco = produto.Preco;
                             p.Quantidade = produto.Quantidade;
                             
                             return p;
                         }).ToList();

        [AcceptVerbs("DELETE")]
        [Route("ExcluaProduto")]
        public void ExcluaProduto(int codigo)
        {
            var produto = listaProdutos.Where(p => p.Codigo == codigo).First();
            listaProdutos.Remove(produto);
        }

        [AcceptVerbs("GET")]
        [Route("ConsulteProduto")]
        public ProdutoModel ConsulteProduto(int codigo) =>
            listaProdutos.Where(p => p.Codigo == codigo).FirstOrDefault();

        [AcceptVerbs("GET")]
        [Route("ConsulteProdutos")]
        public List<ProdutoModel> ConsulteProdutos() =>
            listaProdutos;
    }
}
