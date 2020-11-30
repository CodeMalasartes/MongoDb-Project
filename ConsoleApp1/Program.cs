// PROJETO FRAMEWORK .NET (Não Core)

using ClassLibrary1;
using System;
using System.Data.Entity;
using System.Linq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Neste projeto, por ser NÃO Core, vou instalar o Package NuGet Entity Framework 6

            //Neste projeto poderei também referenciar todas as ClassLibraries que quiser
            //(minhas ou de outros) desde que sejam também .Net Framework (não Core)
            //Click-direito no ramo Referencies > Add Reference > selecionar o projeto/DLL

            //VOU AGORA USAR A BD Entity Framework com Framework .Net (não Core):
            using (BaseDeDados bd = new BaseDeDados())
            {
                Console.WriteLine("Total de produtos na BD: " + bd.Produtos.Count());
                Console.ReadLine();
            }
        }
    }
    class BaseDeDados : DbContext // Necessário: using System.Data.Entity;
    {
        //Reparem que nestas propriedades as classes Produto e Categorias são reconhecidas
        //como válidas pois existe a referencia neste projeto ConsoleApp para a respetiva
        //ClassLibrary:
        public DbSet<Produto> Produtos { get; set; } // Necessário: using ClassLibrary1;
        public DbSet<Categoria> categorias { get; set; }
    }
}
