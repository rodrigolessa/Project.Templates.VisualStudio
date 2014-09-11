Project.Templates.VisualStudio
==============================

Templates de Projetos do Visual Studio para DDD

--------------- Divisão Estrutural --------------- 

* 0 - Gerenciamento de Dependências
* 1 - Arquitetura e Design
-	NomeDaEmpresa.NomeDoProjeto.Analise
* 2 - Camadas
* 2.1 - Apresentação
-	NomeDaEmpresa.NomeDoProjeto.UI.Web
-	NomeDaEmpresa.NomeDoProjeto.UI.Web.Controller
* 2.2 - Serviços Distribuidos
-	NomeDaEmpresa.NomeDoProjeto.ServicoDistribuido
* 2.3 - Aplicação
-	NomeDaEmpresa.NomeDoProjeto.Aplicacao
* 2.4 - Domínio
-	NomeDaEmpresa.NomeDoProjeto.Dominio
-	NomeDaEmpresa.NomeDoProjeto.Dominio.BindContext
* 2.5 - Infraestrutura de Persistência
-	NomeDaEmpresa.NomeDoProjeto.Infraestrutura.Persistencia
* 2.6 - Infraestrutura Vertical
-	NomeDaEmpresa.NomeDoProjeto.Infraestrutura.Comuns
* 3 - Qualidade
* 3.1 - Testes Unitários
-	NomeDaEmpresa.NomeDoProjeto.UI.Web.Tests
-	NomeDaEmpresa.NomeDoProjeto.UI.Web.Controller.Tests
-	NomeDaEmpresa.NomeDoProjeto.Dominio.Tests
-	NomeDaEmpresa.NomeDoProjeto.Infraestrutura.Comuns.Tests
-	NomeDaEmpresa.NomeDoProjeto.Infraestrutura.Persistencia.Tests
* 3.2 - Testes de Carga
* 3.3 - Testes Automatizados

--------------- Tecnologias para Implementação ---------------

* 0 - Gerenciamento de Dependências
* 1 - Arquitetura e Design
* 2 - Camadas
* 2.1 - Apresentação
-		- Sample.NomeDoProjeto.UI.Web (MVC 5 Application)
-			* H5BP 4.1.0 -> Template simples e responsive do HTML 5 Boilerplate.
-			* CSS 3
-			* Modernizr 2.6.2 -> Biblioteca em JavaScript para detectar quais implementações novas o browser tem suporte (user-configurable [navigation.userAgent] property).
-		- Sample.NomeDoProjeto.UI.Web.Controller (Class Library)
* 2.2 - Serviços Distribuidos
-		- Sample.NomeDoProjeto.ServicoDistribuido (WCF Application Service)
* 2.3 - Aplicação
* 2.4 - Domínio
* 2.5 - Infraestrutura de Persistência
* 2.6 - Infraestrutura Vertical
* 3 - Qualidade
* 3.1 - Testes Unitários
* 3.2 - Testes de Carga
* 3.3 - Testes Automatizados
-	Sample.NomeDoProjeto.UI.Web.Selenium (Selenium WebDriver)
