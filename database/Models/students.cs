using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Net.Http.Headers;
using MySqlConnector;

namespace IS_SISTEMA.models {

    public class Students {

        public int id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        


        public Students(string name, string lastname, string email, string phonenumber){
            this.Name = name;
            this.Lastname = lastname;
            this.Email = email;
            this.Phonenumber = phonenumber;
        }

        public static void CreateTable(MySqlConnection sql) {
            string query = @"CREATE TABLE IF NOT EXISTS students (
                id INT AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(255) NOT NULL,
                lastname VARCHAR(255) NOT NULL,
                email VARCHAR(255) NOT NULL,
                phonenumber VARCHAR(255) NOT NULL
                );

            CREATE TABLE IF NOT EXISTS students_subjects(
                id INT AUTO_INCREMENT PRIMARY KEY,
                students_id INT NOT NULL,
                subjects_id INT NOT NULL,
                FOREIGN KEY (students_id) REFERENCES students(id) ON DELETE CASCADE,
                FOREIGN KEY (subjects_id) REFERENCES subjects(id) ON DELETE CASCADE

            );
            ";
            using var cmd = new MySqlCommand(query, sql);
            cmd.ExecuteNonQuery();
        }


         public static void InsertTable(MySqlConnection sql, Students students) {
            string query = @"INSERT INTO students (name, lastname, email, phonenumber) VALUE (@name, @lastname, @email, @phonenumber)";
            using var cmd = new MySqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@name", students.Name);
            cmd.Parameters.AddWithValue("@lastname", students.Lastname);
            cmd.Parameters.AddWithValue("@email", students.Email);
            cmd.Parameters.AddWithValue("@phonenumber", students.Phonenumber);


            cmd.ExecuteNonQuery();
        }

        public static void InsertStudentSubject(MySqlConnection sql, int studentId, int subjectId)
        {
            string query = @"INSERT INTO students_subjects (students_id, subjects_id) VALUES (@studentId, @subjectId);";
            using var cmd = new MySqlCommand(query, sql);

            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);

            cmd.ExecuteNonQuery();
        }


        public static List<Students> GetAllStudents(MySqlConnection sql)
        {
            string query = "SELECT id, name, lastname, email, phonenumber FROM students";
            var studentList = new List<Students>();

            using var cmd = new MySqlCommand(query, sql);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                studentList.Add(new Students(
                    reader.GetString("Name"),
                    reader.GetString("Lastname"),
                    reader.GetString("Email"),
                    reader.GetString("Phonenumber")
                ) { id = reader.GetInt32("id") });
            }

            return studentList;
        }

        public static async Task<Students?> GetByIdAsync(MySqlConnection connection, int id)
        {
            string query = "SELECT id, name, lastname, email, phonenumber FROM students WHERE id = @Id";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Students(
                    reader.GetString("Name"),
                    reader.GetString("Lastname"),
                    reader.GetString("Email"),
                    reader.GetString("Phonenumber")
                ) { id = reader.GetInt32("id") };
            }

            return null; 
        }

        public static async Task DeleteByIdAsync(MySqlConnection connection, int id)
        {
            string query = "DELETE FROM students WHERE id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            
            cmd.Parameters.AddWithValue("@Id", id);


            await cmd.ExecuteNonQueryAsync(); 
        }


        public static List<Students> GetStudentsByGroup(MySqlConnection sql, string groupName)
        {
    string query = "SELECT id, name, lastname, email, phonenumber FROM students WHERE groupe = @groupName";
    var studentList = new List<Students>();

    using var cmd = new MySqlCommand(query, sql);
    cmd.Parameters.AddWithValue("@groupName", groupName);

    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        studentList.Add(new Students(
            reader.GetString("Name"),
            reader.GetString("Lastname"),
            reader.GetString("Email"),
            reader.GetString("Phonenumber")
        ) { id = reader.GetInt32("id") });
    }

    return studentList;
    }
    

    }


}