using System;
using System.Collections.Generic;


class Pessoa{
  
  private string name;
  private int idade;
  private string genero;
  private bool preferencia;
  private float horas_na_lan; 


  public Pessoa(string name, int idade, string genero,float horas_na_lan){
    this.name = name.ToUpper();
    this.idade = idade;
    this.genero = genero.ToUpper();
    this.horas_na_lan = horas_na_lan;
  }
  
  public Pessoa(){
    name = "";
    idade = 0;
    genero = "";
    preferencia = false;   
    horas_na_lan = 0f;

  }


// Get e Set dos atributos:
  public string getName() {
    return this.name;
  }

  public void setName(string name) {
    this.name = name;
  }

  public int getIdade() {
    return this.idade;
  }

  public void setIdade(int idade) {
    if(idade > 0) {
      this.idade = idade;
    }else {
      Console.WriteLine("Idade não pode ser menor que 0!");
      this.idade = 0;
    }
    
  }

  public string getGenero() {
    if(genero == "F"){
      return "Feminino";
    }
    return "Masculino";
  }

  public void setGenero(string genero) {
    this.genero = genero;
  }

  public float getHorasNaLan() {
    return this.horas_na_lan;
  }

  public void setHorasNaLan(float horas_na_lan) {
    this.horas_na_lan = horas_na_lan;
  }
  
    public bool getPreferencia()
    {   
        return this.preferencia;
    }

    public void setPreferencia(bool preferencia)
    {
        this.preferencia = preferencia;

    }
  }

