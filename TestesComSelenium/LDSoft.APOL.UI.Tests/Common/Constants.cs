namespace LDSoft.APOL.UI.Tests.Common
{
    public static class Constants
    {
        public const string LoginInternoPageUrl = "loga_apol.asp";
        public const string PrincipalMarcasPageUrl = "main.asp";
        public const string GetCaptchaPageUrl = "test-captcha.asp";
        public const string EnvolvidosPageUrl = "controle_env.asp";
        public const string EnvolvidoDetalhePageUrl = "edit_env.asp";
        public const string VerAnexoPageUrl = "ver_anexo.asp";
        public const string ProcessoPageUrl = "processo.asp";
        public const string EditArquivoPageUrl = "edit_arquivo.asp";
        public const string EditAnexoPageUrl = "edit_anexo.asp";
        public const string SubDiretorioImagens = @"Resources\imagem\";

        public static class Intranet
        {
            public const string InicioPageUrl = "main.asp";
            public const string LoginPageUrl = "meio.asp";
            public const string AdministracaoApolPageUrl = "lista_setup.asp";

            public static class Modulo
            {
                public const string Todos = "Todos";
                public const string Marca = "Marca";
                public const string Patente = "Patente";
                public const string Juridico = "Jurídico";
                public const string Contrato = "Contrato";
            }
        }

        public static class Juridico
        {
            public const string JuridicoSigla = "C";
        }

        public static class Marcas
        {
            public const string MarcasSigla = "M";
        }

        public static class Patentes
        {
            public const string ProcessoDetalhePageUrl = "detalhe_pat.asp";
            public const string PesquisaWebseekPageUrl = "pesquisa_webseek_patente.asp";
            public const string PatenteSigla = "P";
        }

        public static class ModuloConsulta
        {
            public static class Clientes
            {
                public const string Interno = "consulta/index.asp";
                public const string Camelier = "camelier/index.asp";
                public const string CPQD = "cpqd/index.asp";
                public const string DPortilho = "d_portilho/index.asp";
                public const string Vale = "vale/index.asp";
            }

            public static class Pastas
            {
                public const string Comum = "consulta";
                public const string Camelier = "camelier";
                public const string CPQD = "cpqd";
                public const string DPortilho = "d_portilho";
                public const string Vale = "vale";
            }

            public static class Modulo
            {
                public const string Marca = "marca";
                public const string MarcaInternacional = "marcainternacional";
                public const string Patente = "patente";
                public const string PatenteInternacional = "patenteinternacional";
                public const string Dominio = "dominio";
                public const string Software = "software";
                public const string DireitoAutoral = "direitoautoral";
            }

            public static class TipoDeConsulta
            {
                public const string Resumida = "Resumido";
                public const string Detalhada = "Detalhado";
            }

            public const string ConsultaDireitosAutorais = "consulta_dir_autorais.asp";

        }

        public static class Webseek
        {
            public const string LoginInternoPageUrl = "loga_webseek.asp";
            public const string PrincipalPageUrl = "principal_webseek.asp";
            public const string GetCaptchaPageUrl = "test-captcha.asp";

            public const string DetalheProcessoMarcaPageUrl = "processo.asp";
            public const string DetalheProcessoPatentePageUrl = "det_procp.asp";
        }

        public static class PortalLD
        {
            public const string InicioPageUrl = "home.asp";
            public const string LoginApolPageUrl = "escolhe_apol.asp";
        }
    }
}