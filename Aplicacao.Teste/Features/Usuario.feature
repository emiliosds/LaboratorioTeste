#language: pt-br

Funcionalidade: Cadastro de usuário
	Para utilizar o sistema
	Desejo cadastrar um usuário

Cenário: Criar um usuário com os dados corretos
	Dado que o usuário informa o e-mail marcelo.silva@domain.com.br
	E a senha Re5V#ipT
	Quando submeter os dados
	Então a conta será criada e uma identificação aleatória será gerada