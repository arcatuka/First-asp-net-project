using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Linq;
using OnlyFanSite;

class OnlyFanDAO
    {
        //string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        DataClasses1DataContext db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

    public List<OnlyFan> SelectAll()
    {
        List<OnlyFan> onlyFans = db.OnlyFans.ToList();
        return onlyFans;
    }
        //selectAll no LINQ
        /*
        public List<OnlyFan> SelectAll()
        {
            List<OnlyFan> users = new List<OnlyFan>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string strCom = "select * from OnlyFan";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                OnlyFan onlyFan = new OnlyFan()
                {
                    ID = (int)dr["ID"],
                    Name = (string)dr["Name"],
                    Gender = (string)dr["Gender"],
                    Age = (int)dr["Age"],
                    Price = (int)dr["Price"]

                };
                users.Add(onlyFan);
            }
            con.Close();
            return users;
        }
        */


        public OnlyFan SelectByID(int ID)
        {
            OnlyFan onlyFans = db.OnlyFans.SingleOrDefault(x => x.ID == ID);
            return onlyFans;
        }
        /*
            public OnlyFan SelectByID(int ID)
        {
            OnlyFan user = null;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string strCom = "SELECT * FROM OnlyFan where ID=@ID";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@ID", ID));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                user = new OnlyFan()
                {
                    ID = (int)dr["ID"],
                    Name = (string)dr["Name"],
                    Gender = (string)dr["Gender"],
                    Age = (int)dr["Age"],
                    Price = (int)dr["Price"]
                };
            }
            con.Close();
            return user;
        }
        */






        public List<OnlyFan> SelectByKeyword(string Keyword)
        {
            List<OnlyFan> onlyFans = db.OnlyFans.Where(b=> b.Name.Contains(Keyword)).ToList();
            return onlyFans;
        }
        /*
        public List<OnlyFan> SelectByKeyword(string Keyword)
        {
            List<OnlyFan> users = new List<OnlyFan>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string strCom = "SELECT * FROM OnlyFan where Name LIKE @Keyword ";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Keyword", "%" + Keyword + "%"));
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                OnlyFan user = new OnlyFan()
                {
                    ID = (int)dr["ID"],
                    Name = (string)dr["Name"],
                    Gender = (string)dr["Gender"],
                    Age = (int)dr["Age"],
                    Price = (int)dr["Price"]
                };
                users.Add(user);
            }
            con.Close();
            return users;
        }
        */





        public bool Insert(OnlyFan newUser)
        {
            try
            {
                db.OnlyFans.InsertOnSubmit(newUser);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        /*
        public bool Insert(OnlyFan newUser)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string strCom = "INSERT INTO OnlyFan(Name,Gender,Age,Price) VALUES (@Name,@Gender,@Age,@Price)";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Name", newUser.Name));
            com.Parameters.Add(new SqlParameter("@Gender", newUser.Gender));
            com.Parameters.Add(new SqlParameter("@Age", newUser.Age));
            com.Parameters.Add(new SqlParameter("@Price", newUser.Price));
            try { result = com.ExecuteNonQuery() > 0; }
            catch { result = false; }
            con.Close();
            return result;
        }
        */



        public bool Update(OnlyFan newUser)
        {
            OnlyFan onlyFan = db.OnlyFans.SingleOrDefault(x => x.ID == newUser.ID);
            if(onlyFan != null)
            {
                try
                {
                    onlyFan.Name = newUser.Name;
                    onlyFan.Gender = newUser.Gender;
                    onlyFan.Age = newUser.Age;  
                    onlyFan.Price = newUser.Price;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false;}
                
            }    
            return false;
        }
        /*
        public bool Update(OnlyFan newUser)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string strCom = "UPDATE OnlyFan SET Name=@Name,Gender=@Gender,Age=@Age,Price=@Price WHERE ID=@ID";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Name", newUser.Name));
            com.Parameters.Add(new SqlParameter("@Gender", newUser.Gender));
            com.Parameters.Add(new SqlParameter("@Age", newUser.Age));
            com.Parameters.Add(new SqlParameter("@Price", newUser.Price));
            com.Parameters.Add(new SqlParameter("@ID", newUser.ID));
            try { result = com.ExecuteNonQuery() > 0; }
            catch { result = false; }
            con.Close();
            return result;
        }
        */




        public bool Delete(int ID)
        {
            OnlyFan onlyFan = db.OnlyFans.SingleOrDefault(b=>b.ID == ID);
            if(onlyFan != null)
            {
                try
                {
                    db.OnlyFans.DeleteOnSubmit(onlyFan);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false;}  

            }
            return false;
        }

            /*
            public bool Delete(int ID)
            {
                bool result = false;
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                string strCom = "DELETE FROM OnlyFan where ID=@ID";
                SqlCommand com = new SqlCommand(strCom, con);
                com.Parameters.Add(new SqlParameter("@ID", ID));
                try { result = com.ExecuteNonQuery() > 0; }
                catch { result = false; }
                con.Close();
                return result;
            }
            */
        }

