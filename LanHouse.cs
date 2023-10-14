using System;
using System.Collections.Generic;
class LanHouse

{
    private string name;
    private int qtd_pc;
    private float preco;
    private float faturamento_total;

  
    private float quantidade_pessoas;
    private float soma_idade;
    float media_idades;

//Lista de objetos para mostrar a relação de usuários e pc disponiveis.
    private List<Pessoa> usuarios_ativos;

    public LanHouse()
    {
        name = "Sem nome";
        qtd_pc = 10;
        preco = 0f;        
        usuarios_ativos = new List<Pessoa>();
    }

    public LanHouse(string name, int qtd_pc, float preco, float faturamento_total)
    {
        this.name = name;
        this.qtd_pc = qtd_pc;
        this.preco = preco; 
      
        quantidade_pessoas = 0;  
        soma_idade = 0;
        media_idades = 0;
        usuarios_ativos = new List<Pessoa>();
    }


    ///Get e Set da Classe:
    public string getName()
    {
        return this.name;
    }
    public void setName(string name)
    {
        this.name = name;
    }

    public int getQtdPc()
    {
        return this.qtd_pc;
    }

    public void setQtdPc(int qtdPc)
    {
        this.qtd_pc = qtdPc;
    }

    public float getPreco()
    {    
        return this.preco;
    }

    public void setPreco(float preco)
    {
        this.preco = preco;
    }

    public float getFaturamentoTotal(){
      return this.faturamento_total;
    }
    public void setFaturamentoTotal(float faturamento_total){
      this.faturamento_total = faturamento_total;      
    }

///Metodo para retornar o faturamento atual:
  public void FaturamentoAtual(){
      Console.WriteLine("=====================================================");
      Console.WriteLine("♦                 FATURAMENTO ATUAL                 ♦");
      Console.WriteLine("=====================================================\n");
      Console.WriteLine($"R${getFaturamentoTotal():F2}");
      Console.Write("\n\nQualquer tecla pra voltar ao menu iniciar");
      Console.ReadKey();
  }
  

///Metodo pra exibir a estatistica da média de idade dos frequentadores da lan house; 
  public void EstatisticasIdade(){
    
    Console.WriteLine("=====================================================");
    Console.WriteLine("♦                    ESTATÍSTICAS                   ♦");
    Console.WriteLine("=====================================================\n");
    
    if(quantidade_pessoas == 0){
      Console.WriteLine("Ainda não há estatísticas.");
    }else{
    media_idades = soma_idade / quantidade_pessoas;    
    Console.WriteLine($"A média de idade dos frequentadores da Lan House é de {media_idades:F0} anos!\n");
    }
    
  }
  
  
///Método para adicionar um usuario à um Pc disponivel; 
    public bool AdicionarUsuario(Pessoa p){ 
      
      if(usuarios_ativos.Count < qtd_pc){
        usuarios_ativos.Add(p);
        
        //Calcular o Faturamento:
        float valor_pagar = CalcularPrecoHora(p);
        faturamento_total += valor_pagar; 
        
        //Calcular as Estatisticas -> IDADE:
        soma_idade += p.getIdade(); 
        quantidade_pessoas += 1;     
        
        //Calcular as Estatisticas -> Genero:
        return true;
      }      
      return false;
    }  

///Relatório de cadastro de usuario: 
    public void RelatorioDeCadastro(Pessoa x){   

      Console.WriteLine("=====================================================");  
      Console.WriteLine("♦                   FICHA DO USUARIO                 ♦");
      Console.WriteLine("=====================================================");

      Console.WriteLine($"{name}\nPreço: R${preco}/h.\n\n\n");

      Console.Write($"Usuário: {x.getName()}\nIdade: {x.getIdade()}\nGênero: {x.getGenero()}\nHoras: {x.getHorasNaLan()}\nTotal à pagar: R${CalcularPrecoHora(x):F2}");
       
    }  

///Metodo para verificar a disponibilidade dos PCs
    public void Disponiveis(bool interacao = false){      
      int disponivel = qtd_pc;
      int em_uso = 0;
      int posicao = 1;    
      
      Console.WriteLine("=====================================================");
      Console.WriteLine("♦                Usuários Conectados                ♦");
      Console.WriteLine("=====================================================\n");
      foreach(Pessoa x in usuarios_ativos){
        if(x != null){            
          Console.WriteLine($"\n► {posicao} - {x.getName()}");
          posicao++;
          em_uso++;
          disponivel--;
        }
      }      
      
      Console.WriteLine("\n=====================================================");
      Console.WriteLine("♦                   Disponibilidade                  ♦");
      Console.WriteLine("=====================================================");
      Console.WriteLine($"\n\nEm uso: {em_uso}\nLivres: {disponivel}");
      
      if(interacao == true){
       Console.Write("\nPressione qualquer tecla para voltar ao menu inicial.");
       Console.ReadKey();
      }        

    }

  
/// Metodo pra calcular o preco que o usuario vai pagar:
    public float CalcularPrecoHora(Pessoa x){
      float hora = x.getHorasNaLan() * preco;
      return hora;      
  }

  

///Metodo do case 4: Liberar um pc que está em uso.
    public void LiberarPC(int i){      
      int liberar = i;
      
      if(liberar > 0 && liberar <= usuarios_ativos.Count){    
        
        usuarios_ativos.RemoveAt(liberar-1);
        Console.WriteLine($"Usuário {liberar} liberado.");
        Console.Write("\nPressione qualquer tecla para voltar ao menu inicial.");
        Console.ReadKey();
        
      }else{
        Console.WriteLine("Este PC não está em uso.");
        Console.Write("\n\n\nPressione qualquer tecla para voltar ao menu inicial.");
        Console.ReadKey();
      }
      
    }


  
}