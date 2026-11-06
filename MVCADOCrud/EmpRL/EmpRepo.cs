using Microsoft.Data.SqlClient;
namespace MVCADOCrud.EmpRL
{
    
    public class EmpRepo
    {
        string? constring;
        public EmpRepo(IConfiguration configuration)
        {
            constring = configuration.GetConnectionString("getcon");
        }
        public int SaveEmployee(Models.Employee emp)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query= "insert into emp values('"+emp.Eno+"','"+emp.Ename+"','"+emp.BasicSalary+"','"+emp.Da+"','"+emp.Hra+"','"+emp.Tsal+"')";
            SqlCommand cmd = new SqlCommand(query,con);
           int i= cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<Models.Employee> GetEmps()
        {
            List<Models.Employee> emps = new List<Models.Employee>();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from emp", con);
            SqlDataReader dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Models.Employee emp = new Models.Employee();
                    emp.Eno =Convert.ToInt32(dr[0]);
                    emp.Ename = dr[1].ToString();
                    emp.BasicSalary = Convert.ToDouble(dr[2]);
                    emp.Da = Convert.ToDouble(dr[3]);
                    emp.Hra = Convert.ToDouble(dr[4]);
                    emp.Tsal = Convert.ToDouble(dr[5]);
                    emps.Add(emp);
                }
                dr.Close();
            }
            return emps;
        }
        public int DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "delete from emp where eno="+id;
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public Models.Employee SearchEmployee(int id)
        {
            Models.Employee emp = new Models.Employee();
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from emp where eno="+id, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    emp.Eno = Convert.ToInt32(dr[0]);
                    emp.Ename = dr[1].ToString();
                    emp.BasicSalary = Convert.ToDouble(dr[2]);
                }
                dr.Close();
            }
            return emp;
        }
        public int UpdateEmployee(Models.Employee emp)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "update emp set ename='"+emp.Ename+"',bsal='"+emp.BasicSalary+"',da='"+emp.Da+"',hra='"+emp.Hra+"',tsal='"+emp.Tsal+"' where eno="+emp.Eno;
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
