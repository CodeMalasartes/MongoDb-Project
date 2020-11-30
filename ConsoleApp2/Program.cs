// PROJETO .NET CORE

using ClassLibrary2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Neste projeto, por ser Core, vou instalar o Package NuGet Entity Framework CORE

            //Neste projeto poderei também (referenciar) Adicionar Dependencias para 
            //todas as ClassLibraries que quiser
            //(minhas ou de outros) desde que sejam também .Net CORE
            //Click-direito no ramo Dependencies > Add Project Reference > selecionar o projeto/DLL

            //VOU AGORA USAR A BD Entity Framework com .Net CORE:
            //(FIZ COPY-PASTE DESTE CÓDIGO A PARTIR DO PROJETO ConsoleApp1 não Core):
            using (BaseDeDados bd = new BaseDeDados())
            {
                Console.WriteLine("Total de produtos na BD: " + bd.Produtos.Count()); // NECESSÁRIO EM CORE: using System.Linq;
                Console.ReadLine();
            }
        }
    }

    //(FIZ COPY-PASTE DESTE CÓDIGO A PARTIR DO PROJETO ConsoleApp1 não Core):
    class BaseDeDados : DbContext // Necessário: Microsoft.EntityFrameworkCore; (E NÃO: using System.Data.Entity;)
    {
        //Reparem que nestas propriedades as classes Produto e Categorias são reconhecidas
        //como válidas pois existe a referencia neste projeto ConsoleApp para a respetiva
        //ClassLibrary:
        public DbSet<Produto> Produtos { get; set; } // Necessário: using ClassLibrary2; ( e não using ClassLibrary1;)
        public DbSet<Categoria> categorias { get; set; }


        //MUITA ATENÇÃO: QUANDO, NUM PROJETO CORE, SE QUER ACEDER A UMA BD COM ENTITY FRAMEWORK CORE
        //É NECESSÁRIO CONFIGUAR O PROVIDER E CONNECTION STRING:
        //(VER: https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
            //VOU ANTES USAR ESTA CONNECTION STRING:
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ConsoleApp2.BaseDeDados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //MUITA ATENÇÃO: PARA USAR O MÉTODO UseSqlServer deveremos instalar também o Package NuGet
            //Microsoft.EntityFrameworkCore.SqlServer !!!!!

            //ATENÇÃO: ANTES DE FAZER AS MIGRAÇÕES VAMOS COLOCAR ESTE PROJETO COMO STARTUP

            //ATENÇÃO AO PASSO SEGUINTE: Fazer a migração inicial e update da bd:
            //Para isso é necessário instalar o Package Microsoft.EntityFrameworkCore.Tools
            //e Microsoft.EntityFrameworkCore.Design
            //add-migration Inicial
            //update-database –verbose
        }

    }
}
