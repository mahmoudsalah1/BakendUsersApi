using AutoMapper;
using BackendUsers.BL.Interfaces;
using BackendUsers.Models;
using BackendUsers.Models.Database;
using BackendUsers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUsers.BL.Repository
{
    public class EmployeeRep : IEmployeeRepo
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer db , IMapper _mapper)
        {
            this.db = db;
            this.mapper = _mapper;
        }


        public IQueryable<EmployeeVM> Get()
        {

            IQueryable<EmployeeVM> data = GetAllEmps();
            return data;
        }


        public EmployeeVM GetById(int id)
        {
            EmployeeVM data = GetEmployeeByID(id);
            return data;
        }


        public void Add(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);

            db.Employee.Add(data);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeletedObject = db.Employee.Find(id);

            db.Employee.Remove(DeletedObject);
            db.SaveChanges();
        }





        private EmployeeVM GetEmployeeByID(int id)
        {
            return db.Employee.Where(a => a.Id == id)
                                    .Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary })
                                    .FirstOrDefault();
        }

        private IQueryable<EmployeeVM> GetAllEmps()
        {
            return db.Employee
                       .Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary, });
        }



    }
}
