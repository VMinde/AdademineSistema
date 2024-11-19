using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Net.Http.Headers;
using MySqlConnector;

namespace IS_SISTEMA.models {

    public class Subjects{

        public int id { get; set; }
        public string Subjectname { get; set; }

        public Subjects(string subjectname){
            this.Subjectname = subjectname;
        }

        public Subjects(int id, string subjectname){
            this.id = id;
            this.Subjectname = subjectname;
        }

        public static void CreateTable(MySqlConnection sql) {
            string query = @"
            CREATE TABLE IF NOT EXISTS subjects (
                id INT AUTO_INCREMENT PRIMARY KEY,
                subjectname VARCHAR(255) NOT NULL
            );
            
            CREATE TABLE IF NOT EXISTS subjects_users(
                id INT AUTO_INCREMENT PRIMARY KEY,
                subjects_id INT NOT NULL,
                users_id INT NOT NULL,
                FOREIGN KEY (subjects_id) REFERENCES subjects(id) ON DELETE CASCADE,
                FOREIGN KEY (users_id) REFERENCES users(id) ON DELETE CASCADE
            );
            ";

            using var cmd = new MySqlCommand(query, sql);
            cmd.ExecuteNonQuery();
        }

        public static void InsertTable(MySqlConnection sql, Subjects subjects) {
            string query = @"INSERT INTO subjects (subjectname) VALUE (@subjectname)";
            using var cmd = new MySqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@subjectname", subjects.Subjectname);

            cmd.ExecuteNonQuery();
        }

        public static void InsertProfessor(MySqlConnection sql, int user_id, int subject_id) {
            string query = @"INSERT INTO subjects_users (subjects_id, users_id) VALUES (@subjects_id, @users_id);";
            using var cmd = new MySqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@subjects_id", user_id);
            cmd.Parameters.AddWithValue("@users_id", subject_id);
            
            cmd.ExecuteNonQuery();
        }

        public static List<Subjects> GetAllSubjects(MySqlConnection sql){
            string query = "SELECT id, subjectname FROM subjects";
            var subjectsList = new List<Subjects>();

            using var cmd = new MySqlCommand(query, sql);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                subjectsList.Add(new Subjects(
                    reader.GetString("Subjectname")
           ) { id = reader.GetInt32("id") });
            }

            return subjectsList;
        }

        public static async Task<Subjects?> GetByIdAsync(MySqlConnection connection, int id)
        {
            string query = "SELECT id, subjectname FROM subjects WHERE id = @Id";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Subjects(
                    reader.GetString("Subjectname")
                ) { id = reader.GetInt32("id") };
            }

            return null; 
        }
        public static async Task DeleteByIdAsync(MySqlConnection connection, int id)
        {
            string query = "DELETE FROM subjects WHERE id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            
            cmd.Parameters.AddWithValue("@Id", id);


            await cmd.ExecuteNonQueryAsync(); 
        }

        public static List<(int SubjectId, int UserId)> GetSubjectUsers(MySqlConnection sql)
        {
            string query = "SELECT subjects_id, users_id FROM subjects_users";
            using var cmd = new MySqlCommand(query, sql);
            using var reader = cmd.ExecuteReader();

            var subjectUsers = new List<(int SubjectId, int UserId)>();
            while (reader.Read())
            {
                subjectUsers.Add((reader.GetInt32("subjects_id"), reader.GetInt32("users_id")));
            }
            return subjectUsers;
        }

    }

    

}