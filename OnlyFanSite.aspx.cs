using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ApplicationServices;



namespace OnlyFanSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                List<OnlyFan> list = new OnlyFanBUS().GetAll();
                gvOnlyFan.DataSource = list;
                gvOnlyFan.DataBind();
            }
        }

        protected void gvOnlyFan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(gvOnlyFan.SelectedRow.Cells[1].Text.Trim());
            OnlyFan onlyFan = new OnlyFanBUS().GetDetails(ID);
            if(onlyFan != null)
            {
                txtID.Text = onlyFan.ID.ToString();
                txtName.Text = onlyFan.Name;
                txtGender.Text = onlyFan.Gender;   
                txtAge.Text = onlyFan.Age.ToString();
                txtPrice.Text = onlyFan.Price.ToString();  
            }    
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            OnlyFan onlyFan = new OnlyFan()
            {
                ID = 0,
                Name = txtName.Text.Trim(),
                Gender = txtGender.Text.Trim(),
                Age =int.Parse(txtAge.Text.Trim()),
                Price = int.Parse(txtPrice.Text.Trim())
            };
            bool result = new OnlyFanBUS().AddNew(onlyFan);
            if(result)
            {
                List<OnlyFan> list = new OnlyFanBUS().GetAll();
                gvOnlyFan.DataSource = list;
                gvOnlyFan.DataBind();
            }
            else
            {
                WebMsgBox.Show("SORRY BABY!");
            }    
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            OnlyFan onlyFan = new OnlyFan()
            {
                ID = int.Parse(txtID.Text.Trim()),
                Name = txtName.Text.Trim(),
                Gender = txtGender.Text.Trim(),
                Age = int.Parse(txtAge.Text.Trim()),
                Price = int.Parse(txtPrice.Text.Trim())
            };
            bool result = new OnlyFanBUS().Update(onlyFan);
            if (result)
            {
                List<OnlyFan> list = new OnlyFanBUS().GetAll();
                gvOnlyFan.DataSource = list;
                gvOnlyFan.DataBind();
            }
            else
            {
                WebMsgBox.Show("SORRY BABY!");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text.Trim());
            bool result = new OnlyFanBUS().Delete(id);
            if (result)
            {
                List<OnlyFan> list = new OnlyFanBUS().GetAll();
                gvOnlyFan.DataSource = list;
                gvOnlyFan.DataBind();
            }
            else
            {
                WebMsgBox.Show("SORRY BABY!");
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<OnlyFan> onlyFans = new OnlyFanBUS().Search(keyword);
            gvOnlyFan.DataSource = onlyFans;
            gvOnlyFan.DataBind();
        }
    }
    
}