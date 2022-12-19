using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Department Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class DepartmentController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Department> _departmentRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public DepartmentController(IGenericRepository<Department> departmentRepository,
            UniversityDbContext context)
        {
            _departmentRepository = departmentRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Departments
        /// </summary>
        /// <returns>The List of Departments</returns>
        [HttpGet]
        public async Task<IEnumerable<DepartmentModel>> GetAllDepartments()
        {
            
           // Expression<Func<Department, object>> includes = exp => exp.Student;
            Expression<Func<Department, object>> includes2 = exp2 => exp2.Semester;

            var departments = await _departmentRepository.GetAllAsync(null, new[] {  includes2 });

            return departments.Select(x => new DepartmentModel
            {
                Name = x.Name,
                CurrentAmount = x.CurrentAmount,

                MaxNumberOfStudents = x.MaxNumberOfStudents,
                SemesterId = x.Semester?.Id

            });
        }

        /// <summary>
        /// Controller for getting the particular Department through existing id 
        /// </summary>
        /// <returns>The one particular Department model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(department);
        }

        /// <summary>
        /// Controller for inserting the one particular Department 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddDepartment(DepartmentModel2 department)
        {
            await _departmentRepository.AddAsync(new Department
            {
                Name = department.Name,
               
                MaxNumberOfStudents = department.MaxNumberOfStudents,

                CurrentAmount = department.CurrentAmount,
                SemesterId = department.SemesterId
            });
            await _departmentRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular Department choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditDepartment(int id, DepartmentModel2 dep)
        {
            var department = await _context.Departments.FindAsync(id);
            if (DepartmentExists(id))
            {
                if (dep.SemesterId != 0)
                {
                    department.SemesterId = dep.SemesterId;
                }
                //else if(SemestertExists(bal.SemesterId)){
                //    return StatusCode(500, $"This semester Id does not exists");
                //}
                else
                {
                    department.SemesterId = department.SemesterId;
                }
                if (dep.Name != "string")
                {
                    if (String.IsNullOrEmpty(dep.Name))
                    {
                        return StatusCode(400, $"The Address1 field is required.");
                    }

                    department.Name = dep.Name;
                }
                else
                {
                    department.Name = department.Name;
                }

                if (dep.MaxNumberOfStudents != 0)
                {
                    if (dep.MaxNumberOfStudents == null)
                    {
                        return StatusCode(400, $"The  field is required.");
                    }

                    department.MaxNumberOfStudents = dep.MaxNumberOfStudents;
                }
                else
                {
                    department.MaxNumberOfStudents = department.MaxNumberOfStudents;
                }


                if (dep.CurrentAmount != 0)
                {
                    if (dep.CurrentAmount == null)
                    {
                        return StatusCode(400, $"The  field is required.");
                    }

                    department.CurrentAmount = dep.CurrentAmount;
                }

                else
                {
                    department.CurrentAmount = department.CurrentAmount;
                }

              
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();

            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Department choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }

        //private bool StudentExists(int? id)
        //{
        //    return _context.Students.Any(e => e.Id == id);
        //}

        //private bool SemestertExists(int? id)
        //{
        //    return _context.Semesters.Any(e => e.Id == id);
        //}


    }

}


