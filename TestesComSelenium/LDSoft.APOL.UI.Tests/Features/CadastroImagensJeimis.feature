Funcionalidade: Cadastro Imagens Jeimis
	Na tentativa de fazer um Apol mais bonito
	Como um usuário do sistema
	Eu gostaria de visualizar uma imagem diferente ao logar em cada módulo do Apol

Contexto:
	Dado Que Estou na Tela de Listagem de Imagens do Jeimis


@paraTelaDeConsultaSucesso
Cenário: Consultar imagem do Jeimis para todos os módulos
	Dado que existe a imagem "default.jpg"
	Quando acesso a lista de imagens do Jeimis no "1" registro
	Então visualizo o nome "default.jpg" e o módulo " " da imagem

@paraTelaDeConsultaSucesso
Cenário: Consultar imagem do Jeimis para o módulo de Patente
	Dado que existe a imagem "patente.jpg"
	Quando acesso a lista de imagens do Jeimis para o módulo "Patente"
	Então visualizo o nome "patente.jpg" e o módulo "Patente" da imagem

@paraTelaDeConsultaSucesso
Cenário: Excluir imagem para o módulo de Marca
	Dado que cadastrei uma imagem para o módulo de Marca
	Quando clico em excluir o registro do Jeimis para a imagem "marca.jpg"
	Então visualizo a mensagem "Imagem excluida com sucesso!" na tela

@paraTelaDeConsultaFalha
Cenário: Consultar imagem para o módulo de Contratos
	Dado que não existe imagem para o módulo "Contratos"
	Quando acesso a lista de imagens do Jeimis para o módulo "Contratos"
	Então obtenho um item nulo para a imagem do Jeimis

@paraTelaDeConsultaFalha
Cenário: Proibir a exclusão de uma imagem para o módulo Todos
	Dado que existe a imagem "default.jpg"
	Quando clico em excluir o registro do Jeimis para a imagem "default.jpg"
	Então visualizo a mensagem "Não é possivel excluir uma imagem do módulo Todos!" na tela



@paraTelaDeCadastroSucesso
Cenário: Cadastrar Imagem para o Módulo de Marca
	Dado que acesso a tela de cadastrado do Jeimis
	E informo a imagem "D:\temp\marca.jpg"
	E seleciono o módulo "Marca"
	Quando clico em salvar imagem do Jeimis
	Então visualizo a mensagem "Imagem salva com sucesso!" na tela

@paraTelaDeCadastroFalha
Cenário: Cadastrar Imagem para o Módulo de Patente Sem informar o endereço
	Dado que acesso a tela de cadastrado do Jeimis
	E informo a imagem ""
	E seleciono o módulo "Patente"
	Quando clico em salvar imagem do Jeimis
	Então visualizo a mensagem "O campo Arquivo é obrigatório!" na tela