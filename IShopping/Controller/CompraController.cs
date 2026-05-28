using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IShopping.Controller
{
    public class CompraController
    {
        public List<TipoArtigo> ObterCategorias()
        {
            using (var context = new ShoppingContext())
            {
                return context.tipos.ToList();
            }
        }

        public List<Artigo> ObterArtigosPorCategoria(int tipoId)
        {
            using (var context = new ShoppingContext())
            {
                return context.artigos.Where(a => a.TipoArtigoId == tipoId).ToList();
            }
        }
        public List<Compra> ObterComprasAbertas()
        {
            using (var context = new ShoppingContext())
            {
                return context.compras.Include(c => c.userCriador).Where(c => c.estado == Estado.aberto).ToList();
            }
        }

        public string ObterNomeCompra(int compraId)
        {
            using (var context = new ShoppingContext())
            {
                var compra = context.compras.Find(compraId);
                return compra != null ? compra.nome : "";
            }
        }

        public List<itemCompra> ObterItensDaCompra(int compraId)
        {
            using (var context = new ShoppingContext())
            {
                return context.itemCompras
                    .Include(i => i.artigo)
                    .Where(i => i.compra.id == compraId)
                    .ToList();
            }
        }

        public void AtualizarItemAdquirido(int itemId, int qtdAdquirida, decimal precoUnitario, int compraId)
        {
            using (var context = new ShoppingContext())
            {
                var item = context.itemCompras.Find(itemId);
                if (item != null)
                {
                    item.quantidadeAdquirida = qtdAdquirida;
                    item.precoUnitario = precoUnitario;
                    item.DataAlteracao = DateTime.Now;

                    var compra = context.compras.Find(compraId);
                    if (compra != null) compra.DataAlteracao = DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        public void AdicionarItemExtra(int compraId, int artigoId, int qtd, decimal preco, string obs)
        {
            using (var context = new ShoppingContext())
            {
                var compraAtual = context.compras.Find(compraId);
                var artigoSelecionado = context.artigos.Find(artigoId);
                
                var novoItemExtra = new ArtigoNaoPrevisto
                {
                    compra = compraAtual,
                    artigo = artigoSelecionado,
                    quantidadeAdquirida = qtd,
                    precoUnitario = preco,
                    descricao = string.IsNullOrWhiteSpace(obs) ? "Compra por impulso" : obs,
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                };

                context.itemCompras.Add(novoItemExtra);
                if (compraAtual != null) compraAtual.DataAlteracao = DateTime.Now;

                context.SaveChanges();
            }
        }

        public decimal CalcularSaldoDisponivel(int compraId)
        {
            using (var context = new ShoppingContext())
            {
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                var orcamentoMes = context.orcamentos.FirstOrDefault(o => o.mes.Month == mesAtual && o.mes.Year == anoAtual);
                decimal valorDisponivel = orcamentoMes != null ? orcamentoMes.valor_max : 250.00m;

                decimal totalGastoCompra = context.itemCompras
                    .Where(i => i.compra.id == compraId)
                    .Sum(i => (decimal?)(i.quantidadeAdquirida * i.precoUnitario)) ?? 0;

                return valorDisponivel - totalGastoCompra;
            }
        }

        public void FecharCompra(int compraId)
        {
            using (var context = new ShoppingContext())
            {
                var compra = context.compras.Find(compraId);
                if (compra != null)
                {
                    compra.estado = Estado.fechado;
                    compra.DataAlteracao = DateTime.Now;
                    compra.dataFechar = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
    }
}