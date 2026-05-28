using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IShopping.Controller
{
    public class ItemPlaneadoDTO
    {
        public int ID { get; set; }
        public string Produto { get; set; }
        public int Qtd_Prevista { get; set; }
    }

    public class DetalheItemDTO
    {
        public int TipoArtigoId { get; set; }
        public int ArtigoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class CabecalhoCompraDTO
    {
        public string Nome { get; set; }
        public Estado EstadoCompra { get; set; }
    }

    public class CriacaoCompraController
    {
        public object ObterCategorias()
        {
            using (var context = new ShoppingContext())
            {
                return context.tipos.Select(t => new { Id = t.Id, Categoria = t.Categoria }).ToList();
            }
        }

        public object ObterArtigosPorCategoria(int tipoId)
        {
            using (var context = new ShoppingContext())
            {
                return context.artigos.Where(a => a.TipoArtigoId == tipoId).Select(a => new { Id = a.Id, Nome = a.Nome }).ToList();
            }
        }

        public CabecalhoCompraDTO ObterCabecalhoCompra(int compraId)
        {
            using (var context = new ShoppingContext())
            {
                var compra = context.compras.FirstOrDefault(c => c.id == compraId);
                if (compra != null)
                {
                    return new CabecalhoCompraDTO { Nome = compra.nome, EstadoCompra = compra.estado };
                }
                return null;
            }
        }

        public List<ItemPlaneadoDTO> ObterItensPlaneados(int compraId)
        {
            if (compraId == 0) return new List<ItemPlaneadoDTO>();

            using (var context = new ShoppingContext())
            {
                return context.itemCompras
                    .Include(i => i.artigo)
                    .Where(i => i.compra.id == compraId && i.IsPrevisto == true)
                    .Select(i => new ItemPlaneadoDTO
                    {
                        ID = i.id,
                        Produto = i.artigo != null ? i.artigo.Nome : "Desconhecido",
                        Qtd_Prevista = i.quantidadePrevista
                    }).ToList();
            }
        }

        public DetalheItemDTO ObterDetalhesItem(int itemId)
        {
            using (var context = new ShoppingContext())
            {
                var item = context.itemCompras.Include(i => i.artigo).FirstOrDefault(i => i.id == itemId);
                if (item != null && item.artigo != null)
                {
                    return new DetalheItemDTO
                    {
                        TipoArtigoId = item.artigo.TipoArtigoId,
                        ArtigoId = item.artigo.Id,
                        Quantidade = item.quantidadePrevista
                    };
                }
                return null;
            }
        }

        public int AdicionarItem(int compraId, string nomeCompra, int artigoId, int qtd, int utilizadorId)
        {
            using (var context = new ShoppingContext())
            {
                Compra compraAtual;

                if (compraId == 0)
                {
                    var utilizadorAtual = context.users.Find(utilizadorId);
                    compraAtual = new Compra
                    {
                        nome = nomeCompra,
                        estado = Estado.aberto,
                        dataCriacao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        userCriador = utilizadorAtual
                    };

                    context.compras.Add(compraAtual);
                    context.SaveChanges();
                    compraId = compraAtual.id;
                }
                else
                {
                    compraAtual = context.compras.Find(compraId);
                }

                var artigoSelecionado = context.artigos.Find(artigoId);
                var utilizadorAcao = context.users.Find(utilizadorId);

                var novoItem = new itemCompra
                {
                    compra = compraAtual,
                    artigo = artigoSelecionado,
                    quantidadePrevista = qtd,
                    quantidadeAdquirida = 0,
                    precoUnitario = 0,
                    IsPrevisto = true,
                    DataCriacao = DateTime.Now,
                    DataAlteracao = DateTime.Now,
                    userCriador = utilizadorAcao
                };

                context.itemCompras.Add(novoItem);
                if (compraAtual != null) compraAtual.DataAlteracao = DateTime.Now;

                context.SaveChanges();

                return compraId;
            }
        }

        public void AtualizarItem(int itemId, int novoArtigoId, int novaQtd, int compraId)
        {
            using (var context = new ShoppingContext())
            {
                var itemParaAtualizar = context.itemCompras.Find(itemId);
                var novoArtigo = context.artigos.Find(novoArtigoId);

                if (itemParaAtualizar != null && novoArtigo != null)
                {
                    itemParaAtualizar.artigo = novoArtigo;
                    itemParaAtualizar.quantidadePrevista = novaQtd;
                    itemParaAtualizar.DataAlteracao = DateTime.Now;

                    var compra = context.compras.Find(compraId);
                    if (compra != null) compra.DataAlteracao = DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        public void RemoverItem(int itemId, int compraId)
        {
            using (var context = new ShoppingContext())
            {
                var itemParaRemover = context.itemCompras.Find(itemId);
                if (itemParaRemover != null)
                {
                    context.itemCompras.Remove(itemParaRemover);

                    var compra = context.compras.Find(compraId);
                    if (compra != null) compra.DataAlteracao = DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        public void GuardarCompra(int compraId, string nomeCompra, int utilizadorId)
        {
            using (var context = new ShoppingContext())
            {
                if (compraId == 0)
                {
                    var utilizadorAtual = context.users.Find(utilizadorId);
                    var novaCompra = new Compra
                    {
                        nome = nomeCompra,
                        estado = Estado.aberto,
                        dataCriacao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        userCriador = utilizadorAtual
                    };
                    context.compras.Add(novaCompra);
                }
                else
                {
                    var compraExistente = context.compras.Find(compraId);
                    if (compraExistente != null)
                    {
                        compraExistente.nome = nomeCompra;
                        compraExistente.DataAlteracao = DateTime.Now;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}