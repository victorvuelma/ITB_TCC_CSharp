﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BURGUER_SHACK_DESKTOP
{
    public class clnPedidoProdutoIngrediente
    {

        private int _pedidoProduto;
        private int _ingrediente;

        private int _quantidade;
        
        public int Ingrediente { get => _ingrediente; set => _ingrediente = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }
        public int PedidoProduto { get => _pedidoProduto; set => _pedidoProduto = value; }

        public clnPedidoProdutoIngrediente localizaPorPedidoProduto()
        {
            clnPedidoProdutoIngrediente pedidoIngrediente = new clnPedidoProdutoIngrediente();

            pedidoIngrediente.PedidoProduto = PedidoProduto;
            pedidoIngrediente.Ingrediente = 1;
            pedidoIngrediente.Quantidade = 1;

            return pedidoIngrediente;
        }

    }
}
