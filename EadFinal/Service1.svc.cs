using EadFinal.Data;
using EadFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EadFinal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private MyDbContext db = new MyDbContext();
        public bool AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Employee> SearchEmployees(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return db.Employees.Where(d => d.Department.ToLower().Contains(keyword.ToLower())).ToList();
            }
            return db.Employees.ToList();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
