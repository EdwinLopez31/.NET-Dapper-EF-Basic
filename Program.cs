// See https://aka.ms/new-console-template for more information
using System.Data;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Globalization;
using Microsoft.Extensions.Configuration;


IConfiguration config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();


DataContextDapper dapper = new DataContextDapper(config);
DataContextEF entityFramework = new DataContextEF(config);

DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
Console.WriteLine(rightNow);

Computer myComputer = new Computer()
{
  Motherboard = "ASUS B450M PRO Gaming",
  HasWifi = true,
  HasLTE = true,
  ReleaseDate = DateTime.Now,
  Price = 900.32m,
  VideoCard = "Intel Graphics UHD 4000"
};

entityFramework.Add(myComputer);
entityFramework.SaveChanges();

// string sql = @"INSERT INTO TutorialAppSchema.Computer (
//   Motherboard,
//   HasWifi,
//   HasLTE,
//   ReleaseDate,
//   Price,
//   VideoCard
// ) VALUES ('" + myComputer.Motherboard 
// + "','" + myComputer.HasWifi
// + "','" + myComputer.HasLTE
// + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
// + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
// + "','" + myComputer.VideoCard
// + "')";



// Console.WriteLine(sql);

// int res = dapper.ExecuteSql(sql);

// Console.WriteLine(res);

// string sqlSelect = @"SELECT
//   Computer.ComputerId
//   Computer.Motherboard,
//   Computer.CPUCores,
//   Computer.HasWifi,
//   Computer.HasLTE,
//   Computer.ReleaseDate,
//   Computer.Price,
//   Computer.VideoCard
// FROM TutorialAppSchema.Computer";

// IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);


// foreach (Computer singleComputer in computers)
// {
//   Console.WriteLine("'" + singleComputer.Motherboard
// + "','" + singleComputer.CPUCores
// + "','" + singleComputer.HasWifi
// + "','" + singleComputer.HasLTE
// + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
// + "','" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
// + "','" + singleComputer.VideoCard
// + "'");
// }


IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

if (computersEf != null)
{
  foreach (Computer singleComputer in computersEf)
  {
    Console.WriteLine("'" + singleComputer.ComputerId
      + "','" + singleComputer.Motherboard
  + "','" + singleComputer.CPUCores
  + "','" + singleComputer.HasWifi
  + "','" + singleComputer.HasLTE
  + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
  + "','" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
  + "','" + singleComputer.VideoCard
  + "'");
  }
}