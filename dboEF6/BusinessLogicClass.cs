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
        //Хранит всю информацию о таблице проект
        static List<project> list_project;
        //Хранит всю информацию о таблице компания-заказчик
        static List<companyCustomer> list_companyCustomer;
        //Хранит всю информацию о таблице компания-исполнитель
        static List<companyPerformer> list_companyPerformer;
        //Хранит всю информацию о таблице сотрудник
        static List<employee> list_employee;
        //Хранит всю информацию о таблице руководитель проекта
        static List<projectManager> list_projectManager;

        /// <summary>
        /// Показывает определенные данные для пользователя
        /// Например, скрывает id и внешнии ключи
        /// </summary>
        /// <returns>Данные таблицы проект</returns>
        public IEnumerable<projectViewTable> GetProject()
        {
            GetData<project> data = new GetData<project>();

            list_project = data.getTable();

            return list_project.Select(proj => new projectViewTable
            {
                Name = proj.name,
                DateStart = proj.dateStart,
                DateFinish = proj.dateFinish,
                Priority = proj.priority,
                Comment = proj.comment
            }).ToList();
        }

        /// <summary>
        /// Показывает определенные данные для пользователя
        /// Например, скрывает id и внешнии ключи
        /// </summary>
        /// <returns>Данные таблицы компания-заказчик</returns>
        public IEnumerable<companyCustomerViewTable> GetCompany_Customer(int a=-1)
        {
            GetData<companyCustomer> data = new GetData<companyCustomer>();

            list_companyCustomer = data.getTable();

            var result = list_companyCustomer.Select(comp => new companyCustomerViewTable
                {
                    Name = comp.name,
                    Address = comp.address,
                    email = comp.email
                }).ToList();

            if (a == -1) return result;

            int id_project = list_project[a].projID;

            List <companyCustomerViewTable> lists = new List<companyCustomerViewTable>();

            foreach (var companyC in list_companyCustomer)
            {
                foreach (var proj in companyC.projects)
                {
                    if (id_project == proj.projID) lists.Add(new companyCustomerViewTable
                    {
                        Name = companyC.name,
                        Address = companyC.address,
                        email = companyC.email
                    });
                }
            }
            return lists;
        }

        /// <summary>
        /// Показывает определенные данные для пользователя
        /// Например, скрывает id и внешнии ключи
        /// </summary>
        /// <returns>Данные таблицы компания-исполнитель</returns>
        public IEnumerable<companyPerformerViewTable> GetCompany_Performer(int a=-1)
        {
            GetData<companyPerformer> data = new GetData<companyPerformer>();

            list_companyPerformer = data.getTable();

            var result = list_companyPerformer.Select(comp=> new companyPerformerViewTable
            {
                Name=comp.name,
                Address = comp.address,
                email = comp.email,
                WebSite = comp.WebSite
            }).ToList();

            if (a == -1) return result;

            int id_project = list_project[a].projID;

            List<companyPerformerViewTable> lists = new List<companyPerformerViewTable>();

            foreach (var companyP in list_companyPerformer)
            {
                foreach (var proj in companyP.projects)
                {
                    if (id_project == proj.projID) lists.Add(new companyPerformerViewTable
                    {
                        Name = companyP.name,
                        Address = companyP.address,
                        email = companyP.email,
                        WebSite = companyP.WebSite
                    });
                }
            }
            return lists;
        }

        /// <summary>
        /// Показывает определенные данные для пользователя
        /// Например, скрывает id и внешнии ключи
        /// </summary>
        /// <returns>Данные таблицы сотрудник</returns>
        public IEnumerable<employeeViewTable> GetEmployee(int a=-1)
        {
            GetData<employee> data = new GetData<employee>();

            list_employee = data.getTable();

            var result = list_employee.Select(emp => new employeeViewTable
            {
                Surname = emp.surname,
                Name = emp.name,
                Middlename = emp.middlename_,
                Email = emp.email
            }).ToList();

            if (a == -1) return result;

            int id_project = list_project[a].projID;

            List<employeeViewTable> lists = new List<employeeViewTable>();

            foreach (var employee in list_employee)
            {
                foreach (var proj in employee.projects)
                {
                    if (id_project == proj.projID) lists.Add(new employeeViewTable
                    {
                        Surname = employee.surname,
                        Name = employee.name,
                        Middlename = employee.middlename_,
                        Email = employee.email
                    });
                }
            }
            return lists;
        }

        /// <summary>
        /// Показывает определенные данные для пользователя
        /// Например, скрывает id и внешнии ключи
        /// </summary>
        /// <returns>Данные таблицы руководитель проекта</returns>
        public IEnumerable<projectManagerViewTable> GetProject_Manager(int a=-1)
        {
            GetData<projectManager> data = new GetData<projectManager>();

            list_projectManager = data.getTable();

            var result = list_projectManager.Select(projm=>new projectManagerViewTable
            {
                Surname = projm.surname,
                Name = projm.name,
                Middlename = projm.middlename_,
                Email = projm.email
            }).ToList();

            if (a == -1) return result;

            int id_project = list_project[a].projID;

            List<projectManagerViewTable> lists = new List<projectManagerViewTable>();

            foreach (var projectM in list_projectManager)
            {
                foreach (var proj in projectM.projects)
                {
                    if (id_project == proj.projID) lists.Add(new projectManagerViewTable
                    {
                        Surname = projectM.surname,
                        Name = projectM.name,
                        Middlename = projectM.middlename_,
                        Email = projectM.email
                    });
                }
            }
            return lists;
        }
    }

    /// <summary>
    /// Данные для отображения таблицы проект
    /// </summary>
    public class projectViewTable
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public int Priority { get; set; }
        public string Comment { get; set; }
    }

    /// <summary>
    /// Данные для отображения таблицы компания-заказчик
    /// </summary>
    public class companyCustomerViewTable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
    }

    /// <summary>
    /// Данные для отображения таблицы компания-исполнитель
    /// </summary>
    public class companyPerformerViewTable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public string WebSite { get; set; }
    }

    /// <summary>
    /// Данные для отображения таблицы сотрудник
    /// </summary>
    public class employeeViewTable
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
    }

    /// <summary>
    /// Данные для отображения таблицы руководитель проекта
    /// </summary>
    public class projectManagerViewTable
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
    }
}
