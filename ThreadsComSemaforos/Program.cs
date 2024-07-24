//aula 227
using System;
using System.Threading;

//Usando com threadPool

namespace ThreadsComSemaforos
{
    class Program
    {
        // Define o Semaphore aqui
        private static Semaphore threadPool = new Semaphore(3, 5);

        static void Main(string[] args)
        {
            Console.WriteLine("Controlando threads com semáforos");
            Console.WriteLine("Usando ThreadPool\n");
            for (int i = 0; i < 10; i++)
            {
                Thread threadObject = new Thread(new ThreadStart(ProcessarOperacao));
                threadObject.Name = "Thread: " + i;
                threadObject.Start();
            }
            Console.ReadLine();
        }

        private static void ProcessarOperacao()
        {
            threadPool.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} entrou na sessão critica...");
            Thread.Sleep(10000);
            threadPool.Release();
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} foi liberada...");
        }
    }
}

//Usando com SemaphoreSlim

//namespace SemaphoreSlimExample
//{
//    class Program
//    {
//        private static SemaphoreSlim semaforoSlim = new SemaphoreSlim(4);

//        private static void Main(string[] args)
//        {
//            Console.WriteLine("Usando SemaphoreSlim\n");
//            for (int i = 1; i <= 6; i++)
//            {
//                string threadName = "Thread: " + i;
//                int espera = 2 + 2 * i;
//                var t = new Thread(() => AcessarBancoDados(threadName, espera));
//                t.Start();
//            }

//            Console.ReadLine(); // Para manter a aplicação aberta até pressionar Enter
//        }

//        private static void AcessarBancoDados(string nome, int seconds)
//        {
//            Console.WriteLine($"{nome} aguardando acesso ao banco de dados...");
//            semaforoSlim.Wait();
//            Console.WriteLine($"{nome} autorizada a acessar o banco de dados");
//            Thread.Sleep(TimeSpan.FromSeconds(seconds));
//            Console.WriteLine($"{nome} concluída...");
//            semaforoSlim.Release();
//        }
//    }
//}

//Usando com semaphore.Release

//namespace SemaphoreExample
//{
//    class Program
//    {
//        private static Semaphore semaphore;

//        static void Main()
//        {
//            Console.WriteLine("Usando Release\n");
//            // Cria um semáforo que permite no máximo 2 threads
//            semaphore = new Semaphore(1, 2);

//            Console.WriteLine("Incluiu a thread no semáforo");

//            // Inclui a thread no semáforo usando WaitOne
//            semaphore.WaitOne();

//            // Executa o método
//            Console.WriteLine("Executou o Método");

//            // Libera a thread do semáforo
//            semaphore.Release();
//            Console.WriteLine("Liberou a thread do semáforo");

//            Console.ReadLine(); // Para manter a aplicação aberta até pressionar Enter
//        }
//    }
//}
