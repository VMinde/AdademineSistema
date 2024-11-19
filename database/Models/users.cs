using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace IS_SISTEMA.models
{
    public class Users
    {
        public int id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }

        public Users(string vardas, string pavarde, string email, string phonenumber)
        {
            this.Vardas = vardas;
            this.Pavarde = pavarde;
            this.Email = email;
            this.Phonenumber = phonenumber;
        }

        public Users(int id, string vardas, string pavarde, string email, string phonenumber)
        {
            this.id = id;
            this.Vardas = vardas;
            this.Pavarde = pavarde;
            this.Email = email;
            this.Phonenumber = phonenumber;
        }

        public static void CreateTable(MySqlConnection sql)
        {
            string query = @"CREATE TABLE IF NOT EXISTS users (
                id INT AUTO_INCREMENT PRIMARY KEY,
                vardas VARCHAR(255) NOT NULL,
                pavarde VARCHAR(255) NOT NULL,
                email VARCHAR(255) NOT NULL,
                phonenumber VARCHAR(255) NOT NULL
            )";

            using var cmd = new MySqlCommand(query, sql);
            cmd.ExecuteNonQuery();
        }

        public static void InsertTable(MySqlConnection sql, Users user)
        {
            string query = @"INSERT INTO users (vardas, pavarde, email, phonenumber) VALUE (@vardas, @pavarde, @email, @phonenumber)";
            using var cmd = new MySqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@vardas", user.Vardas);
            cmd.Parameters.AddWithValue("@pavarde", user.Pavarde);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@phonenumber", user.Phonenumber);
            cmd.ExecuteNonQuery();
        }

        public static List<Users> GetAllUsers(MySqlConnection sql)
        {
            string query = "SELECT id, vardas, pavarde, email, phonenumber FROM users";
            var userList = new List<Users>();

            using var cmd = new MySqlCommand(query, sql);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userList.Add(new Users(
                    reader.GetString("vardas"),
                    reader.GetString("pavarde"),
                    reader.GetString("email"),
                    reader.GetString("phonenumber")
                ) { id = reader.GetInt32("id") });
            }

            return userList;
        }

      
        public static async Task<Users?> GetByIdAsync(MySqlConnection connection, int id)
        {
            // await connection.OpenAsync();
            string query = "SELECT id, vardas, pavarde, email, phonenumber FROM users WHERE id = @Id";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Users(
                    reader.GetString("vardas"),
                    reader.GetString("pavarde"),
                    reader.GetString("email"),
                    reader.GetString("phonenumber")
                ) { id = reader.GetInt32("id") };
            }

            return null; 
        }

       
        public static async Task DeleteByIdAsync(MySqlConnection connection, int id)
        {
            // await connection.OpenAsync();
            string query = "DELETE FROM users WHERE id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            
            cmd.Parameters.AddWithValue("@Id", id);


            await cmd.ExecuteNonQueryAsync(); 
        }


        

    }
}
