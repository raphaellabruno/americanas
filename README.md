# americanas
Este tese consiste em realizar um novo cadastro no site americanas.com e simular uma compra

É necesário executar os testes do modo debug, na criação de conta é necessário resolver os captchas por esse motivo foram colocados alguns breakpoints que precisam ser respeitados, quando o teste pausar resolva os captchas e em seguida dê continuidade aos testes.
Para o teste ser executado mais de uma vez com sucesso é preciso alterar as seguintes informações:
Linha 59 - TestSearch.cs - Alterar o CPF
Linha 52 - TestSignup.cs - Colocar o mesmo CPF inderido na linha acima
Linha 43 - TestSignup.cs - Alterar o email

Ferramentas utilizadas:
C#
Selenium
Visual Studio 2017
