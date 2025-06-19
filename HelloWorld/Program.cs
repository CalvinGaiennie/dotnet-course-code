using System;
using System.Data;
using System.Collections.Generic;
using System.Text.Json;
using Dapper;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
          IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
          DataContextDapper dapper = new DataContextDapper(config);

          // string formattedDate = myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss");

          // string sql = @"INSERT INTO TutorialAppSchema.Computer (
          //     Motherboard,
          //     HasWifi,
          //     HasLTE,
          //     ReleaseDate,
          //     Price,
          //     VideoCard
          //  ) VALUES ('" + myComputer.Motherboard 
          //  + "','" + myComputer.HasWifi
          //  + "','" + myComputer.HasLTE
          //  + "','" + formattedDate
          //  + "','" + myComputer.Price
          //  + "','" + myComputer.HasWifi
          //  +"')\n";

          //  using StreamWriter openFile = new("log.txt", append: true);

          //  openFile.WriteLine(sql);

          //  openFile.Close();

          //  string fileText = File.ReadAllText("log.txt");

          string computersJson = File.ReadAllText("Computers.json");

          // Console.WriteLine(computersJson);


          JsonSerializerOptions options = new JsonSerializerOptions()
          {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
          };

          // IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

          IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

          if (computers != null)
          {
            foreach( Computer computer in computers)
            {
              // Console.WriteLine(computer.Motherboard);
            };
          }

          JsonSerializerSettings settings = new JsonSerializerSettings()
          {
            ContractResolver = new CamelCasePropertyNamesContracResolver()
          };

          string computersCopyNewtonsoft = JsonConvert.SerializeObject(computers, settings);

          File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);
        }
    }
}
