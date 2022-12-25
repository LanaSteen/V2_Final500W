using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using V2_Final500W.Common;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Address Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
  
    public class AddressController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Address> _addressRepository;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public AddressController(IGenericRepository<Address> addressRepository, 
            IGenericRepository<Student> studentRepository,
            IGenericRepository<Teacher> teacherRepository,
            UniversityDbContext context)
        {
            _addressRepository = addressRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Addresses
        /// </summary>
        /// <returns>The List of Addresses</returns>
        [HttpGet]
        public async Task<IEnumerable<AddressModel>> GetAllAddresses()
        {
            List<AddressModel> adressModel = new();
            Expression<Func<Address, object>> includes = exp => exp.Student;
            Expression<Func<Address, object>> includes2 = exp2 => exp2.Teacher;

            var addresses = await _addressRepository.GetAllAsync(null, new[] { includes, includes2 });

            return addresses.Select(x => new AddressModel
            {
                Address1 = x.Address1,
                Address2 = x.Address2,
                StudentId = x.Student?.Id,
                TeacherId = x.Teacher?.Id

            });
        }



        /// <summary>
        /// Controller for getting the particular address through existing id 
        /// </summary>
        /// <returns>The one particular address model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressModel>> GetAddress(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address == null)
            {
                 return StatusCode(500, $"Wrong Id number");

            }

            return Ok(address);
        }

        /// <summary>
        /// Controller for inserting the one particular address 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
    


        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressModel address)
        {
            await _addressRepository.AddAsync(new Address
            {
                Address1 = address.Address1,
                Address2 = address.Address2,
                StudentId = address.StudentId,
                TeacherId = address.TeacherId
            });

            if (StudentExists(address.StudentId) == false && address.StudentId!=null && address.StudentId != 0)
            {
                return StatusCode(500, $"Student by {address.StudentId} Id number does not exists, if it is unknown yet write null or 0");
            }

            else if (TeacherExists(address.TeacherId) == false && address.TeacherId != null && address.TeacherId !=0)
            {
                return StatusCode(500, $"Teacher by {address.TeacherId} Id number does not exists, if it is unknown yet write null or 0");
            }
            else
            {
                await _addressRepository.SaveAsync();
            }
            return NoContent();

        }




        /// <summary>
        /// Controller for editing the one particular address choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddress(int id, AddressModel addr)
        {
          //  var address = await _context.Addresses.FindAsync(id);

            var address2 = await _addressRepository.GetByIdAsync(id);


            if (AddressExists(id))
            {
                if(addr.TeacherId != 0)
                {
                    address2.TeacherId = addr.TeacherId;
                }
                else
                {
                    address2.TeacherId = address2.TeacherId;
                }
                if (addr.StudentId != 0)
                {
                    address2.StudentId = addr.StudentId;
                }
                else
                {
                    address2.StudentId = address2.StudentId;
                }
                if (addr.Address1 != "string")
                {
                    if (String.IsNullOrEmpty(addr.Address1))
                    {
                        return StatusCode(400, $"The Address1 field is required.");
                    }

                    address2.Address1 = addr.Address1;
                }
              
                else
                {
                    address2.Address1 = address2.Address1;
                }
                if (addr.Address2 != "string")
                {
                    address2.Address2 = addr.Address2;
                }
              else
                {
                    address2.Address2 = address2.Address2;
                }
                //_context.Addresses.Update(address2);
                _addressRepository.Update(address2);
                //await _context.SaveChangesAsync();
                await _addressRepository.SaveAsync();


            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular address choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>

        // DELETE: api/Addresses1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

           _addressRepository.Delete2(address);  
            await _addressRepository.SaveAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            // return _context.Addresses.Any(e => e.Id == id);
            return _addressRepository.GetByIdAsyncBool(id);
        }



        private bool StudentExists(int? id)
        {
            // return _context.Students.Any(e => e.Id == id);
            return _studentRepository.GetByIdAsyncBool(id);
        }
        private bool TeacherExists(int? id)
        {
            // return _context.Teachers.Any(e => e.Id == id);
            return _teacherRepository.GetByIdAsyncBool(id);
        }

        private Responce GetResponce(int? id)
        {
           Responce resp = _context.Responces.First(e => e.StatusCode == id);
            return resp;
        } //ამას არ ვიყენებ მაგრამ ვფიქრობდი რომ ასე ერორ ჰენდლერი უფრო სწორი იყო და
          //ვიფიქრე გავაკეთებდი მაგრამ რადგანაც ყველა ჰენდლერის დაწერას მაინც ვერ მოვასწრებდი გავჩერდი,
          //თუმცა ეს რომ მოვიფიქრე მაინც პლიუსია ხო? :D რადგან არ ვიყენებ რეპოზიტორზეც არ გადავაკეთებ
    }

}


