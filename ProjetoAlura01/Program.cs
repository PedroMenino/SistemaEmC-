

 // Radio Pirata
string mensagemDeBoasVindas = "Boas vindas a Radio Pirata";
string opcaoEscolhida;
int opcaoEscolhidaNumerica;
string nomeDaBanda;
//List<string> ListaDasBandas = new List<string> {"Menos é Mais", "Aviões do Forro", "Slipknot", "Kevin o Chris" };

Dictionary<string, List<int>> notasRegistroBandas = new Dictionary<string, List<int>>();
notasRegistroBandas.Add("Aviões do Forro", new List<int> { 10, 9, 10 });
notasRegistroBandas.Add("Menos é Mais", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
██████╗░░█████╗░██████╗░██╗░█████╗░  ██████╗░██╗██████╗░░█████╗░████████╗░█████╗░
██╔══██╗██╔══██╗██╔══██╗██║██╔══██╗  ██╔══██╗██║██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗
██████╔╝███████║██║░░██║██║██║░░██║  ██████╔╝██║██████╔╝███████║░░░██║░░░███████║
██╔══██╗██╔══██║██║░░██║██║██║░░██║  ██╔═══╝░██║██╔══██╗██╔══██║░░░██║░░░██╔══██║
██║░░██║██║░░██║██████╔╝██║╚█████╔╝  ██║░░░░░██║██║░░██║██║░░██║░░░██║░░░██║░░██║
╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░╚═╝░╚════╝░  ╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝
");   
    Console.WriteLine(mensagemDeBoasVindas);
    
}


// MENU DE OPÇÕES 
void ExibirOpcoesDoMenu()
{
    ExibirLogo();

    Console.WriteLine("\nDigite 1 salvar uma banda.");
    Console.WriteLine("Digite 2 para listar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a media de uma banda.");
    Console.WriteLine("Digite 0 para sair.");

    Console.Write("\nDigite uma opção: ");
    opcaoEscolhida = Console.ReadLine()!;
    opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:RegistrarBanda();
            break;
        case 2:MostraBandasRegistradas();
            break;
        case 3:AvaliarBandas();
            break;
        case 4:MediaDeNotas();
            break;
        case 0:ExibirMensagemSaida();
            break;
        default:Console.WriteLine("Opção invalida, tente novamente!");
            break;
    
    }       

}

// FUNÇÃO 1 DO MENU DE OPÇÕES,REGISTRA AS BUNDAS NO DICIONARIO
void RegistrarBanda()
{

    Console.Clear();
    ExibirTituloDaOpcao("REGISTRO DE BANDAS");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    nomeDaBanda = Console.ReadLine()!;
    notasRegistroBandas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(3000);
    Console.Clear();
    ExibirOpcoesDoMenu();



}
// FUNÇÃO 2 DO MENU DE OPÇÕES, LISTA TODAS AS BUNDAS REGISTRADAS
void MostraBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("LISTA DAS BANDAS");
    /*for (int i = 0; i < ListaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {ListaDasBandas[i]}");
    }*/

    foreach (string banda in notasRegistroBandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nPrecione Enter, para retornar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

// FUNÇÃO PARA PADRONIZAR O CABEÇALHO DE TODAS AS FUNÇÕES
void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

// FUNÇÃO 3 DO MENU DE OPÇÕES, AVALIAÇÃO DAS BANDAS COM 5 NOTAS 
void AvaliarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("AVALIAR UMA BANDA");
    Console.WriteLine("\nAs bandas serão avalidas em 5 notas, de 0 a 10.");
    Console.Write("\nDigite a banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (notasRegistroBandas.ContainsKey(nomeDaBanda))
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Digite a nota {i}ª para a {nomeDaBanda}: ");
            if (int.TryParse(Console.ReadLine(), out int nota))
            {
                notasRegistroBandas[nomeDaBanda].Add(nota);
                Console.WriteLine($"Carreando nota...\n");
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
                i--; 
            }
        }

        Console.WriteLine("\nTodas as notas foram registradas com sucesso!");
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não encontrada, volte na opção 1 e registre a banda!");
        Console.WriteLine("Pressione Enter, para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

// FUNÇÃO 4 DO MENU DE OPÇÕES, PUXA A MEDIA DAS NOTAS 
void MediaDeNotas()
{
    Console.Clear();
    ExibirTituloDaOpcao("MEDIA DE NOTA");
    Console.Write("Digite a banda que deseja ver a Media: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (notasRegistroBandas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = notasRegistroBandas[nomeDaBanda];
        double mediaDasNotas = Math.Round(notasDaBanda.Average(), 2);
        Console.WriteLine($"\nA media de notas da banda: {nomeDaBanda} é: {mediaDasNotas}.");
        Console.WriteLine("Pressione Enter, para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não encontrada, volte na opção 1 e registre a banda!");
        Console.WriteLine("Pressione Enter, para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

// FUNÇÃO 5 DO MENU DE OPÇÕES,MENSAGEM SAINDO DO SISTEMA
void ExibirMensagemSaida()
{
    Console.Clear();
    Console.WriteLine("Saindo do programa... Obrigado por usar nosso sistema!");
    Thread.Sleep(2000);
    Environment.Exit(0);
}

ExibirLogo();
ExibirOpcoesDoMenu(); 





