# americanas
Este tese consiste em realizar um novo cadastro no site americanas.com e simular uma compra

É necesário executar os testes do modo debug, na criação de conta é necessário resolver os captchas por esse motivo foram colocados alguns breakpoints que precisam ser respeitados, quando o teste pausar resolva os captchas e em seguida dê continuidade aos testes. <br> <br>
Para o teste ser executado mais de uma vez com sucesso é preciso alterar as seguintes informações: <br>
Linha 59 - TestSearch.cs - Alterar o CPF <br>
Linha 52 - TestSignup.cs - Colocar o mesmo CPF inderido na linha acima <br>
Linha 43 - TestSignup.cs - Alterar o email <br>
Linha 116 - Utils - Alterar o valor da varivável screenshotsFolder para o caminho que foi feito o checkout do projeto no seu computador. <br> <br> 

Ferramentas utilizadas:
C# <br>
Selenium <br>
Visual Studio 2017 <br>
