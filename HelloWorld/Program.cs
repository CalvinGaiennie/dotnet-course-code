using System;
using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using HelloWorld.Data;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
          DataContextDapper dapper = new DataContextDapper();
          DataContextEF entityFramework = new DataContextEF();

          DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

            // Console.WriteLine(rightNow);

          Computer myComputer = new Computer()
          {
            Motherboard = "Z690",
            HasWifi = true,
            HasLTE = false,
            ReleaseDate = DateTime.Now,
            Price = 943.87m,
            VideoCard = "RTX 2060"
          };

          entityFramework.Add(myComputer);
          entityFramwork.SaveChanges();

          string formattedDate = myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss");

          string sql = @"INSERT INTO TutorialAppSchema.Computer (
              Motherboard,
              HasWifi,
              HasLTE,
              ReleaseDate,
              Price,
              VideoCard
           ) VALUES ('" + myComputer.Motherboard 
           + "','" + myComputer.HasWifi
           + "','" + myComputer.HasLTE
           + "','" + formattedDate
           + "','" + myComputer.Price
           + "','" + myComputer.HasWifi
           +"')";

            // Console.WriteLine(sql);

          bool result = dapper.ExecuteSql(sql);

          //  Console.WriteLine(result);

          string sqlSelect = @"
            SELECT 
              Computer.Motherboard,
              Computer.HasWifi,
              Computer.HasLTE,
              Computer.ReleaseDate,
              Computer.Price,
              Computer.VideoCard FROM TutorialAppSchema.Computer";

              IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

              foreach(Computer singleComputer in computers)
              {
                Console.WriteLine("'" + myComputer.Motherboard 
                  + "','" + myComputer.HasWifi
                  + "','" + myComputer.HasLTE
                  + "','" + formattedDate
                  + "','" + myComputer.Price
                  + "','" + myComputer.HasWifi
                  +"')");
          }
              IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

              if (computersEF != null)
              {
              foreach(Computer singleComputer in computersEf)
              {
                Console.WriteLine("'" + myComputer.Motherboard 
                  + "','" + myComputer.HasWifi
                  + "','" + myComputer.HasLTE
                  + "','" + formattedDate
                  + "','" + myComputer.Price
                  + "','" + myComputer.HasWifi
                  +"')");
          }
          }
        }
        
    }
}