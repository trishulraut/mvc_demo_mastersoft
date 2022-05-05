using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mcv_demo.Models;

namespace mcv_demo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddStudent(StudentModel smodel)
        {
            try
            {           
                    return Json(new { Message = (new StudentModel().AddStudent(smodel)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult liststudent()
        {
                try
                {
                    return Json(new { model = (new StudentModel().Getstudent()) }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception Ex)
                {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetEditData(int ID)
        {
            try
            {
                return Json(new { model = (new StudentModel().EditData(ID)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult getclasses()
        //{
        //    try
        //    {
        //        return Json(new { model = (new StudentModel().getclass()) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public ActionResult gethobbies()
        //{
        //    try
        //    {
        //        return Json(new { model = (new StudentModel().getHobbies()) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}