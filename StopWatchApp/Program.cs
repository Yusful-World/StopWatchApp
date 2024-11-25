using System;

namespace StopWatchApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            StopWatch stopWatch = new StopWatch();

            while (true)
            {
                try
                {
                    stopWatch.Start();
                    Console.WriteLine("Stopwatch is running, press 'enter' to stop");
                    
                    Console.ReadLine();
                    stopWatch.Stop();

                    Console.WriteLine("Duration:" + stopWatch.Duration());

                    Console.WriteLine("Press enter to run the watch once more or...\n type EXIT to stop using watch");

                    userInput = Console.ReadLine();
                    if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid input: type EXIT or press enter");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public class StopWatch
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _isRunning;

        public void Start()
        {
            if (_isRunning)
            {
                throw new InvalidOperationException("Stop watch is already running");
            }
            _startTime = DateTime.Now;
            _isRunning = true;
        }

        public void Stop()
        {
            if (!_isRunning)
            {
                throw new InvalidOperationException("Stop watch is not running");
            }
            _endTime = DateTime.Now;
            _isRunning = false;
        }

        public TimeSpan Duration()
        {
            return _endTime - _startTime;
        }
    }
}
