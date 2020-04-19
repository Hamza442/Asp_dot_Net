using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;//this is the classlaibrary which we added in the references of MVCDemo vedio 11 for reference

namespace MVCDemo1.Controllers
{
    public class EmployeeController : Controller
    { /*there are 3 different ways to add data in create
       1.through Formcollection
       2.through passing whole model Employee as parameter
       3.through UpdatetoModel function . it inspects all the HTTP requests
       and when we changed the name of create from to create_post && create_get then we use ActionName property
       * watch vedio 16 to understand update model and tryupdate model
       */
        
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        [HttpGet]//this means that this conrroller action method will only responed to a get request of the URL vedio 12
        [ActionName("Create")]//as we changed the name of get and post methods so now we have to tell it on create following action should be preformed
        public ActionResult Create_Get()
        {
            return View();
        }
        [HttpPost]//this will responde to create request this means that when you post any thing on the server this action method of the controller will be invoked or in simple words when any thing is added
        [ActionName("Create")]
        public ActionResult Create_Post(/*FormCollection formCollection*/Employee employee)//the formcollection object will receive all the data from the form in the form of key values paires
        {/*
            //this looping is actually returning values from the object formcollection
            foreach (string key in formCollection.AllKeys)//the allkeys is returning a string array and we are looping through all the keys
            {
                Response.Write("Key = " + key + " ");
                Response.Write(formCollection[key]);
                Response.Write("</br>");
            }
          */
            //this code will add data to the database above is only to view reference vedio 13 7:59
            //form collection returns value stored in a particular key as we have seen above
            //watch vedio 14 for model binders
            /*Employee employee = new Employee();
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
            employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);*/
            //now we will add EmployeeBusinessLayer because this layer has the AddEmployee method
            if (ModelState.IsValid)//we have passed whole model as parameter and stores its value in object employee and checking if model state is valid now we dont have to do the above donkey work
            {
                //Employee employee = new Employee();
                //UpdateModel(employee);//as we use word new the value of object employee will be null but as this line is executed the whole model will be update again
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);//the object employee is passed becasue it has the data from the form
                return RedirectToAction("Index");
            }
            return View();//if model state is not valid then this will return the same view so that the user can correct its errors
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {  //its view will have scaffold tempalate of edit
            //vedio 19 for reference
            //this to show employee and the base of the id 
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
             Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.ID == id);
             return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.SaveEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {//it is not good to delete using Get request because it has some security issues vedio 23 reference
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
            
        }
	}
}