// PROJETO CLASS LIBRARY FRAMEWORK .NET (Não Core)

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
    //Neste projeto, por ser NÃO Core, vou instalar o Package NuGet Entity Framework 6
    //ATENÇÃO: Terei que instalar AQUI TAMBÉM o Package - pois quero usar o atributo ForeignKey

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