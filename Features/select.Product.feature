#language: pt
Funcionalidade: Selecionar Produto na Loja
    @Loja
    Cenario: Selecao de Produto com Sucesso
        Dado que acesso a página inicial do site
        Quando preencho o usuário "standard_user"
        E a senha "secret_sauce" e clico no botao Login
        Entao exibe "Products" no titulo da secao
        Quando adiciono o produto "Sauce Labs Backpack" ao carrinho
        E clico no icone do carrinho de compras
        Entao exibe a pagina do carrinho com a quantidade como "1"
        E nome do produto "Sauce Labs Backpack"
        E o preco como "$29.99"

    Esquema do Cenario: Selecao de Produto com Sucesso DDT
        Dado que acesso a página inicial do site
        Quando preencho o usuário <usuario>
        E a senha <senha> e clico no botao Login
        Entao exibe <tituloSecao> no titulo da secao
        Quando adiciono o produto <produto> ao carrinho
        E clico no icone do carrinho de compras
        Entao exibe a pagina do carrinho com a quantidade como <quantidade>
        E nome do produto <produto>
        E o preco como <preco>

        Exemplos:
        | usuario        | senha            | tituloSecao | produto                 | quantidade | preco    |
        |"standard_user" | "secret_sauce"   | "Products"  | "Sauce Labs Backpack"   | "1"        | "$29.99" |
        |"visual_user"   | "secret_sauce"   | "Products"  | "Sauce Labs Bike Light" | "1"        | "$9.99"  |  