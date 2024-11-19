using System;
using System.ComponentModel;
using MySqlConnector;
using IS_SISTEMA.models;

class Dababase {
    public static MySqlConnection Connect() {
        string connectsrt = "Server=127.0.0.1;User=root;Password=admin;Database=mokykla;Pooling=false;";
        var sql = new MySqlConnection(connectsrt);

        try {

            sql.Open();
            Console.WriteLine(" SQL-Connected  ");

            //create tables;
            Users.CreateTable(sql);
            Groups.CreateTable(sql);
            Students.CreateTable(sql);
            Subjects.CreateTable(sql);


        } catch (Exception err) {
            Console.WriteLine(" SQL-Not-Connecting ");
            Console.WriteLine(err.Message);
        }

        return sql;

    }

    


}