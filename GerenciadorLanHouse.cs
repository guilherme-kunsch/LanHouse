using System;

class GerenciadorLanHouse

{
    LanHouse Otaku;
    public GerenciadorLanHouse()
    {
        Otaku = new LanHouse("Lan House Otaku", 10, 6.3f, 0f);
    }

    public void InitMenu()
    {

        string option = " ";
        while (option != "0")
        {
            void Logo()
            {
                Console.WriteLine(@"
                            
                ██╗░░░░░░█████╗░███╗░░██╗  ██╗░░██╗░█████╗░██╗░░░██╗░██████╗███████╗  ░█████╗░████████╗░█████╗░██╗░░██╗██╗░░░██╗
                ██║░░░░░██╔══██╗████╗░██║  ██║░░██║██╔══██╗██║░░░██║██╔════╝██╔════╝  ██╔══██╗╚══██╔══╝██╔══██╗██║░██╔╝██║░░░██║
                ██║░░░░░███████║██╔██╗██║  ███████║██║░░██║██║░░░██║╚█████╗░█████╗░░  ██║░░██║░░░██║░░░███████║█████═╝░██║░░░██║
                ██║░░░░░██╔══██║██║╚████║  ██╔══██║██║░░██║██║░░░██║░╚═══██╗██╔══╝░░  ██║░░██║░░░██║░░░██╔══██║██╔═██╗░██║░░░██║
                ███████╗██║░░██║██║░╚███║  ██║░░██║╚█████╔╝╚██████╔╝██████╔╝███████╗  ╚█████╔╝░░░██║░░░██║░░██║██║░╚██╗╚██████╔╝
                ╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝  ╚═╝░░╚═╝░╚════╝░░╚═════╝░╚═════╝░╚══════╝  ░╚════╝░░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝░╚═════╝░
                ");
            }
            void LimpaConsoleExibeLogo(){
              Console.Clear();
              Logo();
            }
            LimpaConsoleExibeLogo();
            Console.WriteLine("=====================================================");
            Console.WriteLine("Selecione uma opção abaixo: ");
            Console.WriteLine("0 - Sair.");
            Console.WriteLine("1 - PC Disponiveis para uso.");
            Console.WriteLine("2 - Cadastrar usuário.");
            Console.WriteLine("3 - Relatórios");
            Console.WriteLine("4 - Finalizar sessão do PC.");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.Write("Informe a opção desejada: ");
            option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    Console.WriteLine("Programa encerrado.");
                    return;
              
                case "1":
                    LimpaConsoleExibeLogo();
                    Otaku.Disponiveis(true);

                    break;

              
                case "2":
                    LimpaConsoleExibeLogo();
                    Console.Write("Informe o nome do(a) usuário(a):  ");
                    string name = Console.ReadLine()!;
                    Console.Write("Idade: ");
                    int idade = int.Parse(Console.ReadLine());
                    Console.Write("Genero [F] - [M]: ");
                    string genero = Console.ReadLine();
                    Console.Write("Quantidade de horas: ");
                    float horas_na_lan = float.Parse(Console.ReadLine()!);
                    Console.Clear();                  
              ///Verifica se é possivel adicionar uma pessoa à um computador, sendo verdadeiro ele adiciona e exibe o relatório de cadastro, caso contrário, informa que todos os PC's estão em uso;                    
                    Pessoa usuario_novo = new(name, idade, genero, horas_na_lan);
                    if (Otaku.AdicionarUsuario(usuario_novo))
                    {               
                      Logo();
                      Otaku.RelatorioDeCadastro(new(name, idade, genero, horas_na_lan));
                      Console.Write($"\n\nUsuário cadastrado com sucesso! Pressione qualquer tecla para continuar.");
                      Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Todos os PCs estão em uso.\n\nPressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                    break;

                case "3":
                    LimpaConsoleExibeLogo();
                    Console.WriteLine("1 - Faturamento.");
                    Console.WriteLine("2 - Estatística.");
                    Console.Write("\nInforme a opção desejada: ");
                    int escolha = int.Parse(Console.ReadLine());
              
              
                      switch(escolha){
                      case 1: 
                        LimpaConsoleExibeLogo();
                        Otaku.FaturamentoAtual();
                        break;
                        
                      case 2:
                        LimpaConsoleExibeLogo();
                        Otaku.EstatisticasIdade(); 
                        Console.Write("\n\nQualquer tecla pra voltar ao menu iniciar");
                        Console.ReadKey();
                        break;
                      default: Console.WriteLine("Opção inválida.\n\nPressione qualquer tecla para voltar ao início."); Console.ReadKey(); break;
                      }
                    break;              
                
                case "4": 
                    LimpaConsoleExibeLogo();
                    Otaku.Disponiveis(false);
              
                    Console.Write("\n\nNº do usuário a ser liberado: ");                    
                    int liberar_pc = int.Parse(Console.ReadLine());
                    Otaku.LiberarPC(liberar_pc);
                break;
              
            default: break;


            }
        }
    }

    public static void Main(string[] args)
    {

        //Cria um objeto do tipo GerenciadorLanHouse, que substitui a classe padrao Program.
        GerenciadorLanHouse meu_gerenciador = new GerenciadorLanHouse();

        //Apresenta o menu de opções do sistema para o usuário:    
        meu_gerenciador.InitMenu();

    }
}