using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IShopping.Controller
{
    public class CompraAbertaDTO
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Criador { get; set; }
    }

    public class ItemCompraDTO
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Artigo { get; set; }
        public int Qtd_Prevista { get; set; }
        public int Qtd_Adquirida { get; set; }
        public decimal Preco_Unitario { get; set; }
        public decimal Subtotal { get; set; }
        public string Observacoes { get; set; }
    }

    public class CompraController
    {
        public List<CompraAbertaDTO> ObterComprasAbertas()
        {
            using (var context = new ShoppingContext())
            {
                return context.compras
                    .Include(c => c.userCriador)
                    .Where(c => c.estado == Estado.aberto)
                    .Select(c => new CompraAbertaDTO
                    {
                        id = c.id,
                        Nome = c.nome,
                        DataCriacao = c.dataCriacao,
                        Criador = c.userCriador != null ? c.userCriador.username : "Desconhecido"
                    }).ToList();
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

        public object ObterCategorias()
        {
            using (var context = new ShoppingContext())
            {
                return context.tipos.Select(t => new { id = t.Id, categoria = t.Categoria }).ToList();
            }
        }

        public object ObterArtigosPorCategoria(int tipoId)
        {
            using (var context = new ShoppingContext())
            {
                return context.artigos.Where(a => a.TipoArtigoId == tipoId).Select(a => new { id = a.Id, nome = a.Nome }).ToList();
            }
        }

        public List<ItemCompraDTO> ObterItensDaCompra(int compraId)
        {
            using (var context = new ShoppingContext())
            {
                return context.itemCompras
                    .Include(i => i.artigo)
                    .Where(i => i.compra.id == compraId)
                    .Select(i => new ItemCompraDTO
                    {
                        ID = i.id,
                        Tipo = i.IsPrevisto ? "Previsto" : "Não Previsto",
                        Artigo = i.artigo != null ? i.artigo.Nome : "Artigo Desconhecido",
                        Qtd_Prevista = i.quantidadePrevista,
                        Qtd_Adquirida = i.quantidadeAdquirida,
                        Preco_Unitario = i.precoUnitario,
                        Subtotal = i.quantidadeAdquirida * i.precoUnitario,
                        Observacoes = i.Observacoes
                    }).ToList();
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

                var novoItemExtra = new itemCompra
                {
                    compra = compraAtual,
                    artigo = artigoSelecionado,
                    quantidadePrevista = 0,
                    quantidadeAdquirida = qtd,
                    precoUnitario = preco,
                    IsPrevisto = false,
                    Observacoes = string.IsNullOrWhiteSpace(obs) ? "Compra por impulso" : obs,
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

                var orcamentoMes = context.orcamentos
                    .FirstOrDefault(o => o.mes.Month == mesAtual && o.mes.Year == anoAtual);

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