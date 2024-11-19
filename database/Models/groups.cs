using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Net.Http.Headers;
using MySqlConnector;

namespace IS_SISTEMA.models {

    public class Groups {

        public int id { get; set; }
        public string Name { get; set; } 

        public Groups(string name){
            this.Name = name;
        }

        public static void CreateTable(MySqlConnection sql) {
            string query = @"CREATE TABLE IF NOT EXISTS groups (
                id INT AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(255) NOT NULL
            );

            CREATE TABLE IF NOT EXISTS groups_students(
                id INT AUTO_INCREMENT PRIMARY KEY,
                groups_id INT NOT NULL,
                students_id INT NOT NULL,
                FOREIGN KEY (groups_id) REFERENCES groups(id) ON DELETE CASCADE,
                FOREIGN KEY (students_id) REFERENCES students(id) ON DELETE CASCADE
            );
            ";

            using var cmd = new MySqlCommand(query, sql);
            cmd.ExecuteNonQuery();
        }

        public static void InsertTable(MySqlConnection sql, Groups group) {
            string query = @"INSERT INTO groups (name) VALUE (@name)";
            using var cmd = new MySqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@name", group.Name);

            cmd.ExecuteNonQuery();
        }

        public static void InsertStudents(MySqlConnection sql, int students_id, int groups_id)
        {
            string query = @"INSERT INTO groups_students (groups_id, students_id) VALUES (@groups_id, @students_id);";
            using var cmd = new MySqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@groups_id", groups_id);
            cmd.Parameters.AddWithValue("@students_id", students_id);
            
            cmd.ExecuteNonQuery();
        }

        public static List<Groups> GetAllGroups(MySqlConnection sql)
        {
            string query = "SELECT id, name FROM groups";
            var userList = new List<Groups>();

            using var cmd = new MySqlCommand(query, sql);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userList.Add(new Groups(
                    reader.GetString("Name")
                ) { id = reader.GetInt32("id") });
            }

            return userList;
        }


        public static async Task<Groups?> GetByIdAsync(MySqlConnection connection, int id)
        {
            string query = "SELECT id, name FROM groups WHERE id = @Id";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Groups(
                    reader.GetString("name")
                ) { id = reader.GetInt32("id") };
            }

            return null; 
        }
    
        public static async Task DeleteByIdAsync(MySqlConnection connection, int id)
        {
            string query = "DELETE FROM groups WHERE id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            
            cmd.Parameters.AddWithValue("@Id", id);


            await cmd.ExecuteNonQueryAsync(); 
        }



    }

}