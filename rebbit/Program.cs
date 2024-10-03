using System;
using System.Threading;

class AnimalThread
{
    private string name;
    private int priority;
    private int distanceCovered = 0;
    private Random random = new Random();

    public AnimalThread(string name, int priority)
    {
        this.name = name;
        this.priority = priority;
    }

    public void Run()
    {
        while (distanceCovered < 100)
        {
            int step = random.Next(1, 10); // шаг от 1 до 9 метров
            distanceCovered += step;

            Console.WriteLine($"{name} пробежал {distanceCovered} метров.");

            // Изменение приоритета, если отстал
            if (distanceCovered < 50)
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest; // Увеличить приоритет
            }
            else
            {
                Thread.CurrentThread.Priority = ThreadPriority.Normal; // Снизить приоритет
            }

            Thread.Sleep(100); // задержка для имитации времени на преодоление расстояния
        }

        Console.WriteLine($"{name} достиг 100 метров!");
    }
}

class RabbitAndTurtle
{
    public static void Main()
    {
        AnimalThread rabbit = new AnimalThread("Кролик", (int)ThreadPriority.Normal);
        AnimalThread turtle = new AnimalThread("Черепаха", (int)ThreadPriority.Normal);

        // Запуск потоков
        Thread rabbitThread = new Thread(new ThreadStart(rabbit.Run));
        Thread turtleThread = new Thread(new ThreadStart(turtle.Run));

        rabbitThread.Start();
        turtleThread.Start();

        // Ожидание завершения потоков
        rabbitThread.Join();
        turtleThread.Join();

        Console.WriteLine("Соревнование завершено!");
    }
}