using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;


namespace mcv_demo.Models
{
    public class StudentModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "enter name")]
        public string Name { get; set; }
        [Range(20, 60, ErrorMessage = "Invalid DOB")]
        public string City { get; set; }
        public string Address { get; set; }
        
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["studentDB"].ToString();
            con = new SqlConnection(constring);
        }
        public bool AddStudent(StudentModel smodel)
        {
                connection();             
            var get = (Getstudent().Find(e => e.Id == smodel.Id));
            if (get != null)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@StdId", get.Id);
                cmd.Parameters.AddWithValue("@Name", smodel.Name);
                cmd.Parameters.AddWithValue("@City", smodel.City);
                cmd.Parameters.AddWithValue("@Address", smodel.Address);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            else  {
                SqlCommand cmd = new SqlCommand("AddNewStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", smodel.Name);
                cmd.Parameters.AddWithValue("@City", smodel.City);
                cmd.Parameters.AddWithValue("@Address", smodel.Address);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            //cmd.Parameters.AddWithValue("@Hobbies", smodel.Hobbies_id);
            
        }
        public List<StudentModel> Getstudent()
        {
            connection();
            List<StudentModel> studentlist = new List<StudentModel>();
            SqlCommand cmd = new SqlCommand("GetStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter st = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            st.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                //var date = DateTime.Parse(dr["Student_DOB"].ToString());
                studentlist.Add(
                    new StudentModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                        //Hobbies_name = Convert.ToString(dr["Hobbies_name"]),
                    }); 
            }
            return studentlist;
        }

        public StudentModel EditData(int Id)
        {
            string Message = "";

            connection();
            //List<StudentModel> studentlist = new List<StudentModel>();
            //SqlCommand cmd = new SqlCommand("GetStudentDetails", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter st = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //con.Open();
            //st.Fill(dt);
            //con.Close();
            var ed=(Getstudent().Find(e => e.Id == Id));
            //var editData = con..Where(p => p.ID == Id).FirstOrDefault();
            if (ed != null)
            {
                Id = ed.Id;
                Name = ed.Name;
                City = ed.City;
                Address = ed.Address;
            }

            Message = "Record get Successfully";
            return ed ;
        }

    }
}