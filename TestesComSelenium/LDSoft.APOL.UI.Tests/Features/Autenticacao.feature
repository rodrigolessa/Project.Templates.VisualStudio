Funcionalidade: Autenticacao
	In order to autenticar na intranet
	As a math idiot
	I want to be told the sum of two numbers

Cenário: Navegar para tela de login
	Quando I navigate to login page
	Então I should be on the login page

Cenário: Usuario autentica com sucesso
	Dado I am on the login page
	E I have filled out the form as follows
	   | Usuario    | Senha		|
	   | susane		| 123		|
	Quando I press Entrar
	Então I should see a screen principal
