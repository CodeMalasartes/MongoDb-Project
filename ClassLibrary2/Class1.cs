// PROJETO CLASS LIBRARY .NET CORE

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary2
{

    //Neste projeto, por ser Core, vou instalar o Package NuGet Entity Framework CORE
    //ATENÇÃO: Terei que instalar AQUI TAMBÉM o Package - pois quero usar o atributo ForeignKey

    //FIZ COPY-PASTE DO PROJETO NÃO CORE:
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        //Campo gerado na BD para relacionar produto com Categoria
        [ForeignKey("Categoria")] // Necessário: using System.ComponentModel.DataAnnotations.Schema;
        public int IdCategoria { get; set; }
        //Propriedade (C#) de navegação para a Categoria
        public Categoria Categoria { get; set; }
    }
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //Propriedade (C#) de navegação para os Produtos de cada Categoria
        public List<Produto> Produtos { get; set; } // Necessário: using System.Collections.Generic;
    }
    //VER O DbContext no respetivo projeto Console!!!
}
