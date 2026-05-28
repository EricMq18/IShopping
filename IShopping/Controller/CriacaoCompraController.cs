using IShopping.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IShopping.Controller
{
    public class CriacaoCompraController
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
        public Compra ObterCabecalhoCompra(int compraId)
        {
            using (var context = new ShoppingContext())
            {
                return context.compras.FirstOrDefault(c => c.id == compraId);
            }
        }

        public List<ArtigoPrevisto> ObterItensPlaneados(int compraId)
        {
            if (compraId == 0) return new List<ArtigoPrevisto>();

            using (var context = new ShoppingContext())
            {
                // CORREÇÃO: Filtra apenas pelos artigos previstos 
                return context.itemCompras
                    .OfType<ArtigoPrevisto>()
                    .Include(i => i.artigo)
                    .Where(i => i.compra.id == compraId)
                    .ToList();
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
                        nome = string.IsNullOrWhiteSpace(nomeCompra) ? "Nova Lista Planeada" : nomeCompra,
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
                        compraExistente.nome = string.IsNullOrWhiteSpace(nomeCompra) ? "Lista Planeada" : nomeCompra;
                        compraExistente.DataAlteracao = DateTime.Now;
                    }
                }
                context.SaveChanges();
            }
        }
        public ArtigoPrevisto ObterDetalhesItem(int itemId)
        {
            using (var context = new ShoppingContext())
            {
                return context.itemCompras
                    .OfType<ArtigoPrevisto>()
                    .Include(i => i.artigo)
                    .FirstOrDefault(i => i.id == itemId);
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
                
                var novoItem = new ArtigoPrevisto
                {
                    compra = compraAtual,
                    artigo = artigoSelecionado,
                    qntPrevista = qtd,
                    quantidadeAdquirida = 0,
                    precoUnitario = 0,
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
                var itemParaAtualizar = context.itemCompras.OfType<ArtigoPrevisto>().FirstOrDefault(i => i.id == itemId);
                var novoArtigo = context.artigos.Find(novoArtigoId);

                if (itemParaAtualizar != null && novoArtigo != null)
                {
                    itemParaAtualizar.artigo = novoArtigo;
                    itemParaAtualizar.qntPrevista = novaQtd;
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
    }
}