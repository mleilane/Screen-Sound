// Screen Sound
string mensagemDeBoasVindas = "Seja bem vindo ao Screen Sound";

//Criando dicionario para inclusao das listas 
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

//Atribuindo ao projetos duas bandas 
bandasRegistradas.Add("Melim", new List<int> { 10, 9, 5 }); //Banda ja avalaida
bandasRegistradas.Add("Rosa de Saron", new List<int>()); //Banda sem avaliacao

//Criando a funcao logo 
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

//Criando a funcao menu de opcoes
void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 - Para registrar uma banda");
    Console.WriteLine("Digite 2 - Para mostrar todas as bandas");
    Console.WriteLine("Digite 3 - Para avaliar uma banda");
    Console.WriteLine("Digite 4 - Para exibir a média de uma banda");
    Console.WriteLine("Digite 0 - Para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!; 
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); 

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMedia();
            break;
        case 0:
            Console.WriteLine("Programa encerrado!");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

//Criando a funcao de registro das bandas
void RegistrarBanda()
{
    Console.Clear(); //limpar o console
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>()); //adicionando nome da banda ao dicionario
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(4000); 
    Console.Clear();
    ExibirOpcoesDoMenu(); //voltamos ao menu para dar mais opcoes 
}

//funcao para exibir as bandas registradas
void MostrarBandasRegistradas()
{
    Console.Clear(); //limpar o console
    ExibirTituloDaOpcao("Bandas registradas: ");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();//voltamos ao menu para dar mais opcoes 

}

//Criando a funcao com layout predefinido do cabeçalho, de acordo com a quantidade de caracteres
void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length; //mostra a quantidade de caracteres do titulo 
    string linha = string.Empty.PadLeft(quantidadeDeLetras, '_'); // vai incluir um  "_" para cada caracter do titulo
    Console.WriteLine(linha);
    Console.WriteLine(titulo);
    Console.WriteLine(linha + "\n");
}

//funcao para avaliacao das bandas
void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    // se a banda exitir no dicionario >> atribuir uma nota
    // senão, volta ao menu principal

    Console.Clear(); //limpar console 
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Digite a nota que deseja atribuir a Banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!); //a ! indica que nao aceitamos valores nulos
        bandasRegistradas[nomeDaBanda].Add(nota); //adicionando a avaliacao no dicionario 
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu(); //voltamos ao menu para dar mais opcoes 
    }
    else //caso digite uma banda que ainda não foi registrada 
    {
        Console.WriteLine($"\n A banda {nomeDaBanda} não foi encontrada!"); //aviso sobre banda nao regitrada 
        Console.WriteLine("Digite uma tecla para voltar ao menu principal"); 
        Console.ReadKey();
        Console.Clear(); //limpar console 
        ExibirOpcoesDoMenu(); //voltamos ao menu para dar mais opcoes 
    }

}

//funcao para calcular a media de avaliacoes para cada banda
void ExibirMedia()
{
    Console.Clear(); // limpar console
    ExibirTituloDaOpcao("Exibir média da banda");
    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda)) //caso a banda seja localizada no dicionario, será executado esse bloco 
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}


ExibirOpcoesDoMenu();