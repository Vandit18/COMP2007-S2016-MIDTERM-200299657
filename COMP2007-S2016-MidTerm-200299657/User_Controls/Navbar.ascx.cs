using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**
 @author: Vandit Kothari
    @date: June 23,2016 
    @Website Name : http://comp2007-s2016-midterm-200299657.azurewebsites.net/
    @updated SetActivePage Method to include Todo List
    @version = 1.0
*/


namespace COMP2007_S2016_MidTerm_200299657
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Todo List":
                    todo.Attributes.Add("class", "active");
                    break;
                case "Todo Details":
                    todoDetail.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}