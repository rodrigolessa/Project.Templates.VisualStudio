namespace LDSoft.APOL.UI.Tests.Navigation.APOL
{
    public interface IModuloMenuNavigation
    {
        Administracao.InicioPage IrParaModuloAdministracao();

        Juridico.InicioPage IrParaModuloJuridico();

        Marcas.InicioPage IrParaModuloMarcas();

        Patentes.InicioPage IrParaModuloPatentes();

    }
}
