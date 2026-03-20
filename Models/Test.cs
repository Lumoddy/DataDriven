// using System.Numerics;
// using Microsoft.Data.SqlClient;

// namespace data_driven.Models;

// public class Test
// {
//     static async Task Ras(string connectionString)
//     {
//         var result = new List<User>();

//         await using var connection = new SqlConnection(connectionString);
//         await connection.OpenAsync();

//         await using var command = new SqlCommand(
//             "SELECT Id, Name FROM Users",
//             connection
//         );

//         await using var reader = await command.ExecuteReaderAsync();

//         while (await reader.ReadAsync())
//         {
//             result.Add(new User
//             {
//                 Id = reader.GetInt32(0),
//                 Name = reader.GetString(1)
//             });
//         }

//         return result;
//     }
// }