#language: pt-BR
Funcionalidade: Atualizacao de Cliente
	Atualizacao de Cliente

Cenário: Atualiza informacao de cliente
	Dado que eu queira atualizar um cliente
	E que a tabela de genero esteja com o seguinte estado
		| Genero_id | Descricao |
		| 1         | Masculino |
		| 2         | Feminino  |
	E que a tabela de clientes esteja com o seguinte estado
		| Nome      | CPF         | Genero_id | Atualizado_em |
		| Guilherme | 42827626837 | 1         | NULL          |
	Quando atualizo o genero do cliente '42827626837' para 2
	Então o registro do cliente deveria ficar da seguinte forma
		| Nome      | CPF         | Genero_id | Atualizado_em |
		| Guilherme | 42827626837 | 2         | NULL          |