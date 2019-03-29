using DataBelli.Loteria.Dominio;
using System;
using System.Linq;

namespace DataBelli.Loteria.Apresentacao
{
    class Program
    {
        static void Main(string[] args)
        {
            var opcao = default(string);
            var jogo = new JogoSena(new Sorteador());
            var sair = false;
            while (!sair)
            {
                Console.WriteLine("Lista de Opções:");
                Console.WriteLine("1 - Adicionar Jogo");
                Console.WriteLine("2 - Sortear");
                Console.WriteLine("3 - Listar Vencedores");
                Console.WriteLine("4 - Adicionar Supresinha");
                Console.WriteLine("9 - Listar Perdedores");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("");
                Console.WriteLine("Escolha uma opção:");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        {
                            sair = true;
                        }break;

                    case "1":
                        {
                            var aposta = new ApostaSena();
                            for (int i = 0; i < 6; i++)
                            {
                                Console.WriteLine($"Entre com o número {i + 1} (1-60):");
                                //Console.WriteLine("Entre com o número {0} {1}(1-60):", "op1", "op2");
                                //Convert.ToInt32
                                //aposta.AdicionarNumero(int.Parse(Console.ReadLine()));

                                var numero = default(int);

                                if (!int.TryParse(Console.ReadLine(), out numero))
                                {
                                    Console.WriteLine("Número inválido!");
                                }

                                aposta.AdicionarNumero(numero);
                            }
                            jogo.AdicionarApostas(aposta);
                        }break;

                    case "2":
                        {
                            jogo.Sortear();

         
                            Console.WriteLine("Sorteio realizado com sucesso!");

                            Console.WriteLine($"Números Sorteados: {string.Join(',', jogo.NumerosSorteados)}");

                        }break;

                    case "3":
                        {
                            jogo.ObterVencedores().ToList().ForEach(a =>
                            {
                                Console.WriteLine($"Aposta: {a.Identificador} - Números: {string.Join(',', a.Nuneros)}");
                            });
                        }break;

                    case "4":
                        {
                            Console.WriteLine("Informe a quantidade de surpresinhas:");
                            var numero = default(int);

                            if (int.TryParse(Console.ReadLine(), out numero) && (numero > 0))
                            {
                                jogo.GerarSurpresinha(numero);
                            }
                        }
                        break;


                    case "9":
                        {
                            jogo.ObterPededores().ToList().ForEach(a =>
                            {
                                Console.WriteLine($"Aposta: {a.Identificador} - Números: {string.Join(',', a.Nuneros)}");
                                //Console.WriteLine($"Aposta: {a.Identificador}");
                                //Console.WriteLine($"Números: {string.Join(',', a.Nuneros)}");
                            });
                        }
                        break;

                    default:
                        break;
                }
            }
            Console.Read();
        }
    }
}
