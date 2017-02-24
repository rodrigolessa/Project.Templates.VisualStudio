using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgScaffold
{
    public static class Constantes
    {
        public static class Pastas
        {
            public const string Modelos = "Models";
            public const string Controles = "Controllers";
            public const string Telas = "Views";
            public const string Servicos = "Services";
            public const string Repositorios = "Repositories";
            public const string ContextosDeBanco = "UnitOfWork";
        }

        public static class Camadas
        {
            public static string[] Nomes = new string[] { "UI", "Web", "Application", "Domain", "Infrastructure", "Data", "UnitOfWork" };

            public const string ApresentacaoWeb = "UI.Web";
            public const string ServicosDistribuidos = "DistributedServices";
            public const string Aplicacao = "Application";
            public const string Dominio = "Domain";
            public const string InfraEstruturaVertical = "Infrastructure";
            public const string InfraEstruturaDePersistenia = "Infrastructure.Data";
        }
    }
}
