using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
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

           using StreamWriter openFile = new("log.txt", append: true);

           openFile.WriteLine(sql);
        }
    }
}
