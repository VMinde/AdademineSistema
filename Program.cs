using System.Text.Json;
using Microsoft.AspNetCore.Http;
using IS_SISTEMA.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using MySqlConnector;

var mysqlconnection = Dababase.Connect();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();

// Pagrindinis puslapis
app.MapGet("/", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Index();


    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

// Kiti maršrutai
app.MapGet("/admin/professor/deleteprof", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Deleteprof();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/subjects/addsubjectprofessor", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Addsubpro();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/subjects/subject", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Subjectss();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/subjects/deletesubject", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Deletesubject();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/subjects/addsubject", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Addsubject();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/professor/editprofessor", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Editprofessor();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/professor/editproflast", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Editproflast();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/students/studentss", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Studentss();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/students/addstudent", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Addstudent();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/students/deletestudent", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Deletestudent();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/groups/groupss", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Groupss();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/groups/addgroup", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Addgroup();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/groups/addstudentgroup", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Addstudentgroup();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/groups/addsubjectgroup", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Addsubjectgroup();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/groups/deletegroup", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Deletegroup();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/groups/editgroup", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Editgroupp();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });     
});

app.MapGet("/admin/groups/editgrouplast", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Editgrouplast();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/professor/professors", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Professors();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapGet("/admin/professor/addprofessor", async (HttpContext context) => {
    var controller = new PageController();
    var page = controller.Addprofessor();
    await page.ExecuteResultAsync(new ActionContext {
        HttpContext = context,
        RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
        ActionDescriptor = new ActionDescriptor()
    });
});

app.MapPost("/api/new-user", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();

    var user = new Users(
        form["Vardas"].FirstOrDefault() ?? string.Empty,
        form["Pavarde"].FirstOrDefault() ?? string.Empty,
        form["Email"].FirstOrDefault() ?? string.Empty,
        form["Phonenumber"].FirstOrDefault() ?? string.Empty
    );

    Users.InsertTable(mysqlconnection, user);

    context.Response.Redirect("/admin/professor/professors");
});

app.MapPost("/api/new-students", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();

    var students = new Students(
        form["Name"].FirstOrDefault() ?? string.Empty,
        form["Lastname"].FirstOrDefault() ?? string.Empty,
        form["Email"].FirstOrDefault() ?? string.Empty,
        form["Phonenumber"].FirstOrDefault() ?? string.Empty
    );

    Students.InsertTable(mysqlconnection, students);

    context.Response.Redirect("/admin/students/studentss");
});

app.MapPost("/api/new-group", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();

    var group = new Groups(
        form["Name"].FirstOrDefault() ?? string.Empty
    );

    Groups.InsertTable(mysqlconnection, group);

    context.Response.Redirect("/admin/groups/groupss");

});

app.MapPost("/api/new-subjects", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();

    var subjects = new Subjects(
        form["Subjectname"].FirstOrDefault() ?? string.Empty
    );

    Subjects.InsertTable(mysqlconnection, subjects);

    context.Response.Redirect("/admin/subjects/subject");

});


app.MapPost("/api/delete-user", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync(); 
    var idString = form["id"].FirstOrDefault(); 

    if (string.IsNullOrEmpty(idString) || !int.TryParse(idString, out int id))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid ID provided.");
        return;
    }

    var user = await Users.GetByIdAsync(mysqlconnection, id);
    if (user == null) 
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("User not found.");
        return;
    }

    await Users.DeleteByIdAsync(mysqlconnection, id);

    context.Response.Redirect("/admin/professor/deleteprof");
});

app.MapPost("/api/delete-student", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync(); 
    var idString = form["id"].FirstOrDefault(); 

    if (string.IsNullOrEmpty(idString) || !int.TryParse(idString, out int id))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid ID provided.");
        return;
    }

    var student = await Students.GetByIdAsync(mysqlconnection, id);
    if (student == null) 
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("User not found.");
        return;
    }

    await Students.DeleteByIdAsync(mysqlconnection, id);

    context.Response.Redirect("/admin/students/deletestudent");
});

app.MapPost("/api/delete-subjects", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync(); 
    var idString = form["id"].FirstOrDefault(); 

    if (string.IsNullOrEmpty(idString) || !int.TryParse(idString, out int id))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid ID provided.");
        return;
    }

    var subject = await Subjects.GetByIdAsync(mysqlconnection, id);
    if (subject == null) 
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("User not found.");
        return;
    }

    await Subjects.DeleteByIdAsync(mysqlconnection, id);

    context.Response.Redirect("/admin/subjects/deletesubject");
});

app.MapPost("/api/delete-group", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync(); 
    var idString = form["id"].FirstOrDefault(); 

    if (string.IsNullOrEmpty(idString) || !int.TryParse(idString, out int id))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid ID provided.");
        return;
    }

    var group = await Groups.GetByIdAsync(mysqlconnection, id);
    if (group == null) 
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("User not found.");
        return;
    }

    await Groups.DeleteByIdAsync(mysqlconnection, id);

    context.Response.Redirect("/admin/groups/deletegroup");
});


app.MapPost("/api/assign-professor", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();

    var subjectIdString = form["subjects_id"].FirstOrDefault();
    var userIdString = form["users_id"].FirstOrDefault();


    if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId) ||
        string.IsNullOrEmpty(subjectIdString) || !int.TryParse(subjectIdString, out int subjectId))
    {
        context.Response.StatusCode = 400; 
        await context.Response.WriteAsync("Invalid user or subject ID.");
        return;
    }

    var user = await Users.GetByIdAsync(mysqlconnection, userId);
    var subject = await Subjects.GetByIdAsync(mysqlconnection, subjectId);

    Subjects.InsertProfessor(mysqlconnection, subjectId, userId);

    context.Response.Redirect("/admin/subjects/subject");

});

app.MapPost("/api/assign-student", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();

    var groupsIdString = form["groups_id"].FirstOrDefault();
    var studentsIdString = form["students_id"].FirstOrDefault();


    if (string.IsNullOrEmpty(studentsIdString) || !int.TryParse(studentsIdString, out int studentsId) ||
        string.IsNullOrEmpty(groupsIdString) || !int.TryParse(groupsIdString, out int groupsId))
    {
        context.Response.StatusCode = 400; 
        await context.Response.WriteAsync("Invalid user or subject ID.");
        return;
    }

    var user = await Users.GetByIdAsync(mysqlconnection, studentsId);
    var subject = await Subjects.GetByIdAsync(mysqlconnection, groupsId);

    Groups.InsertStudents(mysqlconnection, groupsId, studentsId);

    context.Response.Redirect("/admin/groups/groupss");

});

app.MapPost("/api/student-subject", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();

    var subjectsIdString = form["subjects_id"].FirstOrDefault();
    var studentsIdString = form["students_id"].FirstOrDefault();

    if (string.IsNullOrEmpty(studentsIdString) || !int.TryParse(studentsIdString, out int students_id) ||
        string.IsNullOrEmpty(subjectsIdString) || !int.TryParse(subjectsIdString, out int subjects_id))
    {
        context.Response.StatusCode = 400; 
        await context.Response.WriteAsync("Invalid student or subject ID.");
        return;
    }

    var student = await Users.GetByIdAsync(mysqlconnection, students_id);
    var subject = await Subjects.GetByIdAsync(mysqlconnection, subjects_id);

    if (student == null || subject == null)
    {
        context.Response.StatusCode = 404; 
        await context.Response.WriteAsync("Student or subject not found.");
        return;
    }

    Students.InsertStudentSubject(mysqlconnection, students_id, subjects_id);

    context.Response.Redirect("/admin/groups/groupss"); 
});


 app.MapGet("/api/subject-users", async (HttpContext context) =>
   {
       var subjectUsers = Subjects.GetSubjectUsers(mysqlconnection);

       // Convert to a list of objects with properties 
       var result = subjectUsers.Select(su => new { SubjectId = su.SubjectId, UserId = su.UserId });

       context.Response.ContentType = "application/json"; // Set Content-Type to JSON
       await context.Response.WriteAsJsonAsync(result);
   });

app.Run();
