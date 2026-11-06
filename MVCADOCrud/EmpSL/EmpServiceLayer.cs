using MVCADOCrud.EmpRL;

namespace MVCADOCrud.EmpSL
{
    public class EmpServiceLayer
    {
        EmpRL.EmpRepo _emprepo;
        public EmpServiceLayer(EmpRepo emprepo)
        {
            _emprepo=emprepo;   
        }
        public int SaveEmployee(Models.Employee emp)
        {
            emp.Da=0.2*emp.BasicSalary;
            emp.Hra=0.4*emp.BasicSalary;
            emp.Tsal = emp.BasicSalary + emp.Da + emp.Hra;
           int i= _emprepo.SaveEmployee(emp);
            return i;
        }
        public List<Models.Employee> GetEmps()
        { 
              List<Models.Employee> emps=_emprepo.GetEmps();
                return emps;
        }
        public int DeleteEmployee(int id)
        {
            return _emprepo.DeleteEmployee(id);
        }
        public Models.Employee SearchEmployee(int id)
        {
            Models.Employee emp = _emprepo.SearchEmployee(id);
            return emp;
        }
        public int UpdateEmployee(Models.Employee emp)
        {
            emp.Da = 0.2 * emp.BasicSalary;
            emp.Hra = 0.4 * emp.BasicSalary;
            emp.Tsal = emp.BasicSalary + emp.Da + emp.Hra;
            int i= _emprepo.UpdateEmployee(emp);
            return i;
        }
        }
    }