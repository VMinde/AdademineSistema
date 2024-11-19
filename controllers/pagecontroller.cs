using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using IS_SISTEMA.models;
using System.Collections.Generic;
using System.Net.Quic;

public class PageController : Controller {

    public IActionResult Index() {

        return View("~/views/admin/index.cshtml");
    }

    public IActionResult Deleteprof() {

        MySqlConnection sql = Dababase.Connect();
        var users = Users.GetAllUsers(sql);

        return View("~/views/admin/professor/deleteprof.cshtml", users);
    }

    public IActionResult StudentsByGroup(string groupName)
    {
    MySqlConnection sql = Dababase.Connect();
    var students = Students.GetStudentsByGroup(sql, groupName);

    return View("~/views/admin/students/studentsbygroup.cshtml", students);
    }


     public IActionResult Groupss() {

        MySqlConnection sql = Dababase.Connect();
        var groups = Groups.GetAllGroups(sql);

        return View("~/views/admin/groups/groupss.cshtml", groups);
        }

        public IActionResult Addstudentgroup() {

        return View("~/views/admin/groups/addstudentgroup.cshtml");
        }

        public IActionResult Addsubjectgroup() {

        return View("~/views/admin/groups/addsubjectgroup.cshtml");
        }

        public IActionResult Addsubpro() {

        MySqlConnection sql = Dababase.Connect();
        var subjects = Subjects.GetAllSubjects(sql);

        return View("~/views/admin/subjects/addsubjectprofessor.cshtml", subjects);
    }
    public IActionResult Editgrouplast() {

        MySqlConnection sql = Dababase.Connect();
        var groups = Groups.GetAllGroups(sql);

        return View("~/views/admin/groups/editgrouplast.cshtml", groups);
    }
     public IActionResult Editgroupp() {

        MySqlConnection sql = Dababase.Connect();
        var groups = Groups.GetAllGroups(sql);

        return View("~/views/admin/groups/editgroup.cshtml", groups);
    }

    public IActionResult Addprofessor() {
        return View("~/views/admin/professor/addprofessor.cshtml");
    }
    public IActionResult Addgroup() {
        return View("~/views/admin/groups/addgroup.cshtml");
    }
    public IActionResult Deletegroup() {
        MySqlConnection sql = Dababase.Connect();
        var groups = Groups.GetAllGroups(sql);
        return View("~/views/admin/groups/deletegroup.cshtml", groups);
    }
    public IActionResult Editprofessor() {
            
        MySqlConnection sql = Dababase.Connect();
        var users = Users.GetAllUsers(sql);

        return View("~/views/admin/professor/editprofessor.cshtml", users);
    }
    public IActionResult Editproflast() {

    MySqlConnection sql = Dababase.Connect();
    var users = Users.GetAllUsers(sql);

    return View("~/views/admin/professor/editproflast.cshtml"); 
    }

    public IActionResult Studentss(){    

        MySqlConnection sql = Dababase.Connect();
        var students = Students.GetAllStudents(sql);

        return View("~/views/admin/students/studentss.cshtml", students);
    }
        public IActionResult Subjectss(){    

        MySqlConnection sql = Dababase.Connect();
        var subjects = Subjects.GetAllSubjects(sql);

        return View("~/views/admin/subjects/subject.cshtml", subjects);
    }

        public IActionResult Deletesubject(){    

        MySqlConnection sql = Dababase.Connect();
        var subjects = Subjects.GetAllSubjects(sql);

        return View("~/views/admin/subjects/deletesubject.cshtml", subjects);
    }

    public IActionResult Addsubject(){    

        return View("~/views/admin/subjects/addsubject.cshtml");
    }


    public IActionResult Deletestudent(){    

        MySqlConnection sql = Dababase.Connect();
        var students = Students.GetAllStudents(sql);

        return View("~/views/admin/students/deletestudent.cshtml", students);
    }    

        public IActionResult Addstudent(){    

        return View("~/views/admin/students/addstudent.cshtml");
    }

    public IActionResult Professors(){ 

        MySqlConnection sql = Dababase.Connect();
        var users = Users.GetAllUsers(sql);

        return View("~/views/admin/professor/professors.cshtml", users);

    }

    public async Task<IActionResult> Subjectprofessor(int id){
        MySqlConnection sql = Dababase.Connect();

        string query = @"
                SELECT u.id, u.vardas, u.pavarde, u.email, u.phonenumber
                FROM subjects_users ss
                JOIN users u ON ss.users_id = u.id
                WHERE ss.subjects_id = @subjects_id;
        ";

        using var cmd = new MySqlCommand(query, sql);
        cmd.Parameters.AddWithValue("@subjects_id", id);

        using var reader = cmd.ExecuteReader();

        var users = new List<Users>();

        while (reader.Read()) {
            users.Add(new Users(
                reader.GetInt32("id"),
                reader.GetString("vardas"),
                reader.GetString("pavarde"),
                reader.GetString("email"),
                reader.GetString("phonenumber")
            ));
        } 

        reader.Close();
        cmd.Dispose();

        MySqlConnection sql2 = Dababase.Connect();
        string query2 = @" SELECT u.id, u.sname, u.lecture
            FROM subjects_users st
            JOIN users u ON st.subjects_id = u.id
            WHERE st.subjects_id = @subjects_id";

        using var cmd2 = new MySqlCommand(query2, sql2);
        cmd2.Parameters.AddWithValue("@subjects_id", id);

        using var reader2 = await cmd2.ExecuteReaderAsync();

        var subjects = new List<Subjects>();

        while (reader2.Read()) {
            subjects.Add(new Subjects(
                reader2.GetInt32("id"),
                reader2.GetString("subjectname")
            ));
        }

        reader2.Close();
        cmd2.Dispose();

        var response = new {
            status = "succes",
            users = users,
            subjects = subjects
        };


        return View("~/views/admin/index.cshtml", response);

    }



}