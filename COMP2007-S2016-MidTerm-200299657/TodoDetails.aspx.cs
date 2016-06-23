using COMP2007_S2016_MidTerm_200299657.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP2007_S2016_MidTerm_200299657
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }
        protected void GetTodo()
        {
            // populate teh form with existing data from the database
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a Department object instance with the DepartmentID from the URL Parameter
                Todo updatedTodo = (from Todos in db.Todos
                                                where Todos.TodoID == TodoID
                                                select Todos).FirstOrDefault();

                // map the Department properties to the form controls
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
                    if (updatedTodo.Completed == true)
                    {
                        todoCheckBox.Checked = true;
                    }
                    else
                    {
                        todoCheckBox.Checked = false;
                    }
                }
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Departments page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (TodoConnection db = new TodoConnection())
            {

                // save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0)
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current student from EF DB
                    newTodo = (from Todo in db.Todos
                                     where Todo.TodoID == TodoID
                                     select Todo).FirstOrDefault();
                }

                // add form data to new record
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                if (todoCheckBox.Checked == true)
                {
                    newTodo.Completed = true;
                }
                else
                {
                    newTodo.Completed = false;
                }


                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();


                Response.Redirect("~/TodoList.aspx");
            }
            }

        protected void todoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}