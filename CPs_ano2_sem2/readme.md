## Objetivo: Desenvolver um aplicativo de console em C# que faça o web crawling de uma página de jogo específica no site Metacritic e extraia as seguintes informações: nome do jogo, nota do público e nota do crítico.

### Ferramentas e Tecnologias:

* #### Linguagem de Programação: C#
* #### Ambiente de Desenvolvimento: Visual Studio ou .NET CLI
* #### Bibliotecas: HtmlAgilityPack (para parsing de HTML)
* #### .NET Core SDK

## Instruções:

### Configuração do Ambiente:

* Certifique-se de que o .NET Core SDK está instalado em sua máquina.
* Crie um novo projeto de aplicativo de console em C# utilizando o Visual Studio ou o .NET CLI.
* Adicione a biblioteca HtmlAgilityPack ao projeto usando o NuGet Package Manager ou o comando CLI dotnet add package HtmlAgilityPack.

### Estrutura do Projeto:

* No método Main, adicione o código necessário para solicitar ao usuário que insira a URL de uma página de jogo no Metacritic.
* Valide a URL para garantir que ela corresponda ao formato esperado de uma página de jogo no Metacritic.

### Implementação do Web Crawler:

* Utilize a classe HttpClient para realizar uma solicitação HTTP GET para a URL fornecida e obter o HTML da página.
* Utilize a classe HtmlDocument do HtmlAgilityPack para carregar o HTML obtido.
* Utilize os métodos de seleção do HtmlAgilityPack para localizar os elementos específicos da página que contêm o nome do jogo, a nota do público e a nota do crítico. (Dica: Inspecione o HTML da página do Metacritic para encontrar os seletores corretos.)
* Extraia o conteúdo de texto desses elementos e armazene-os em variáveis.

### Saída do Programa:

* Exiba o nome do jogo, a nota do público e a nota do crítico no console.
* Implemente tratamento de erros adequado para lidar com possíveis exceções, como URLs inválidas, problemas de rede ou mudanças na estrutura do site do Metacritic que possam afetar o parsing do HTML.

### Testes:

* Teste o aplicativo com diferentes URLs de páginas de jogos do Metacritic para garantir que ele esteja funcionando corretamente.
* Verifique se o aplicativo lida adequadamente com entradas inválidas e situações de erro.

## Entrega:
#### Gravação do Vídeo:

* Inicie o vídeo apresentando o objetivo do exercício.
* Crie um novo projeto de aplicativo de console em C# e vá explicando cada passo enquanto você escreve o código, incluindo a instalação e o uso da biblioteca HtmlAgilityPack.
* Durante o vídeo, explique o processo de web crawling, como você extrai os dados específicos e como você lida com possíveis exceções.
* O código deve ser escrito durante o vídeo, mas você pode fazer cortes e edições conforme necessário, desde que todos os passos de desenvolvimento e codificação sejam claramente mostrados e explicados.
* Conclua o vídeo resumindo o que foi feito e destacando quaisquer desafios enfrentados e como foram solucionados.