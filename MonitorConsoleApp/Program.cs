using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorConsoleApp
{
    class Program
    {
        const string SERVICE_URL = "http://localhost:44356";
        static readonly TimeSpan DELAY = TimeSpan.FromMinutes(5);
        static async Task Main(string[] args)
        {
            bool threatFlag = false;
            if (args.Length == 0 || args[0] == "threat")
                threatFlag = true;
            var httpClient = new HttpClient();
            Console.WriteLine("Введите логин");
            var login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            var password = Console.ReadLine();
            Console.WriteLine("Подключение к серверу...");

            var values = new Dictionary<string, string>
                {
                    { "login", login },
                {"password", password }
                };

            var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(SERVICE_URL + "/api/measurement/auth?login=" + login + "&password=" + password, content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (int.TryParse(responseString, out int hostId))
            {
                var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"); ;
                var ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

                while (true)
                {
                    long tickCountMs = Environment.TickCount;
                    var uptime = TimeSpan.FromMilliseconds(tickCountMs);
                    var cpuPercent = cpuCounter.NextValue();
                    var ramPercent = ramCounter.NextValue();
                    var measurementValues = new Dictionary<string, string>
                    {
                        {"uptime", ((int)Math.Round(uptime.TotalMinutes)).ToString() },
                        {"cpuUsage", ((int)Math.Round(cpuPercent)).ToString() },
                        {"ramUsage", ((int)Math.Round(ramPercent)).ToString() },
                        {"monitorUserId", hostId.ToString() },
                        {"threatFlag", threatFlag.ToString() }
                    };
                    var measurementContent = new StringContent(JsonConvert.SerializeObject(measurementValues), Encoding.UTF8, "application/json");
                    var measurementResponse = await httpClient.PostAsync(SERVICE_URL + "/api/measurement/saveMeasurement", measurementContent);
                    Console.WriteLine($"Метрики переданы; Время передачи - {DateTime.Now}");
                    Thread.Sleep(DELAY);
                }
            }
            else
            {
                Console.WriteLine("Регистрация в системе завершилась неудачно. Попробуйте позже");
                Console.ReadKey();
            }

        }
    }
}
