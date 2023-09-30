using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        ToDoListEntities1 ObjTodolist = new ToDoListEntities1();
        // GET: Task
        public ActionResult List(TaskList objta)
        {
            if(objta == null) 
            {
                return View(objta);
            }
            else
            {
                return View();

            }
            
        }

        [HttpPost]
        public ActionResult AddTask(TaskList model)
        { 
            TaskList objTalist = new TaskList();
            objTalist.TaskTitle = model.TaskTitle;
            objTalist.TaskDescription = model.TaskDescription;
            objTalist.CreateDate = model.CreateDate;

            ObjTodolist.TaskLists.Add(objTalist);
            ObjTodolist.SaveChanges();

            return View("List");
        }

        [HttpGet]
        public ActionResult Tolist()
        {
            var tlist=ObjTodolist.TaskLists.ToList();
            return View(tlist);
        }
    }
}