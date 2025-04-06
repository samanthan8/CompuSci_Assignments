using System.Diagnostics;
using ParallelProcessing;

const int nNumbers = 100000000;
long sum = 0;

//Measure time process takes
var watch = new Stopwatch();
watch.Start();

var adder1 = new Adder(0, nNumbers / 2);
var adder2 = new Adder(nNumbers / 2, nNumbers);

var thread1 = new Thread(adder1.Run);
var thread2 = new Thread(adder2.Run);

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();

sum = adder1.Sum + adder2.Sum;

for (int i = 0; i < nNumbers; i++)
{
    sum += i;
}

//Stop measuring time
watch.Stop();

Console.WriteLine($"Sum of numbers from 0 to {nNumbers - 1} is {sum}");
Console.WriteLine($"Time taken: {watch.ElapsedMilliseconds / 1000.0} s");