using System;
using System.Threading;

namespace DIO.Banco
{
    public class Conta
    {
        //atributos
        private TipoConta TipoConta {get; set; }
        private string Nome {get ;set; } //propriedade pode ser alterada. Altera o atributo.
        private double Credito {get ; set ; }
        private double Saldo {get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        { //construtor: é um método que é chamado no momento que é criado o objeto. Tem o nome da classe sempre.
            //quando instanciar já tem que colocar os parâmetros.
            //quando instanciar nao tem mais como mudar pois estao como private.
            this.TipoConta = tipoConta;
            this.Credito = credito;
            this.Nome = nome;
            this.Saldo = saldo;
            //o "this" indica que vai alterar apenas da instância e não da classe toda.
        }

        public bool Sacar(double valorSaque)
        {
            //validação de saldo suficiente
            if (this.Saldo - valorSaque <= (this.Credito * -1))
            {
                Console.WriteLine("\nSaldo insuficiente! Operação cancelada.");
                Thread.Sleep(1000);
                return false;
            }
            //não tem "else" pq se acontecer o "return" superior já finaliza o método.
            this.Saldo -= valorSaque;
            
            System.Console.WriteLine("Saldo atual da conta do cliente {0} é: {1}", this.Nome, this.Saldo); //uma outra forma de formatar
            return true;
        }

        public void Depositar(double valorDeposito) //void não precisa de tipo
        {
            this.Saldo += valorDeposito;

            System.Console.WriteLine($"Saldo atual da conta do cliente {this.Nome} é: {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)) //se for  possivel tirar a quantia ..
            {
                contaDestino.Depositar(valorTransferencia);
                System.Console.WriteLine($"\nTransferência de {valorTransferencia} reais realizada com sucesso!");
                Thread.Sleep(500);
            }
        }

        public override string ToString() //override sobrescreve um método pré-existente na classe mãe, no caso é a "object" que é padrão.
        {
            string retorno = $"Tipo de conta: {this.TipoConta}\n";
            retorno += $"Nome do cliente: {this.Nome}\nSaldo: R$:{this.Saldo}\n";
            retorno += $"Crédito: R$:{this.Credito}";
            return retorno;
        }
    }
}

/*
Encapsulados (private). Se precisar mudar o saldo, cria-se um metodo que altera o 
saldo tendo controle de onde ta vindo a alteração. 
*/