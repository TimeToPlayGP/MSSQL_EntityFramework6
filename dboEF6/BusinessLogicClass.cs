using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dboEF6.EF;

namespace dboEF6
{
    class BusinessLogicClass
    {
        List<project> list_project;

        public IEnumerable<projectViewTable> GetProject()
        {
            GetData<project> data = new GetData<project>();

            list_project = data.getTable();

            var pr = list_project.Select(proj => new projectViewTable
            {
                Name = proj.name,
                DateStart = proj.dateStart,
                DateFinish = proj.dateFinish,
                Priority = proj.priority,
                Comment = proj.comment
            }).ToList();

            return pr;
        }

        public IEnumerable<companyCustomerViewTable> GetCompany_Customer()
        {
            GetData<companyCustomer> data = new GetData<companyCustomer>();

            return data.getTable().Select(comp=> new companyCustomerViewTable
            {
                Name = comp.name,
                Address = comp.address,
                email = comp.email
            });
        }

        public IEnumerable<companyPerformerViewTable> GetCompany_Performer()
        {
            GetData<companyPerformer> data = new GetData<companyPerformer>();

            return data.getTable().Select(comp=> new companyPerformerViewTable
            {
                Name=comp.name,
                Address = comp.address,
                email = comp.email,
                WebSite = comp.WebSite
            });
        }

        public IEnumerable<employeeViewTable> GetEmployee()
        {
            GetData<employee> data = new GetData<employee>();

            return data.getTable().Select(emp => new employeeViewTable
            {
                Surname = emp.surname,
                Name = emp.name,
                Middlename = emp.middlename_,
                Email = emp.email
            });
        }

        public IEnumerable<projectManagerViewTable> GetProject_Manager()
        {
            GetData<projectManager> data = new GetData<projectManager>();

            return data.getTable().Select(projm=>new projectManagerViewTable
            {
                Surname = projm.surname,
                Name = projm.name,
                Middlename = projm.middlename_,
                Email = projm.email
            });
        }
    }


    class projectViewTable
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public int Priority { get; set; }
        public string Comment { get; set; }
    }

    class companyCustomerViewTable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
    }

    class companyPerformerViewTable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public string WebSite { get; set; }
    }

    class employeeViewTable
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
    }

    class projectManagerViewTable
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
    }
}
