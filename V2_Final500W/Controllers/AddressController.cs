using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
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
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public AddressController(IGenericRepository<Address> addressRepository,
            UniversityDbContext context)
        {
            _addressRepository = addressRepository;

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
            var address = await _context.Addresses.FindAsync(id);

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
        public async Task AddAddress(AddressModel address)
        {
            await _addressRepository.AddAsync(new Address
            {
                Address1 = address.Address1,
                Address2 = address.Address2,
                StudentId = address.StudentId,
                TeacherId = address.TeacherId
            });
            await _addressRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular address choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddress(int id, AddressModel addr)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (AddressExists(id))
            {
                if(addr.TeacherId != 0)
                {
                    address.TeacherId = addr.TeacherId;
                }
                else
                {
                    address.TeacherId = address.TeacherId;
                }
                if (addr.StudentId != 0)
                {
                    address.StudentId = addr.StudentId;
                }
                else
                {
                    address.StudentId = address.StudentId;
                }
                if (addr.Address1 != "string")
                {
                    if (String.IsNullOrEmpty(addr.Address1))
                    {
                        return StatusCode(400, $"The Address1 field is required.");
                    }

                    address.Address1 = addr.Address1;
                }
              
                else
                {
                    address.Address1 = address.Address1;
                }
                if (addr.Address2 != "string")
                {
                    address.Address2 = addr.Address2;
                }
              else
                {
                    address.Address2 = address.Address2;
                }
                _context.Addresses.Update(address);
                await _context.SaveChangesAsync();

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
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }



     
        /// ///////////////////////////////////



        //[HttpPost("error")]

        //public async Task<ActionResult<Responce>> Error(int statusCode)
        //{
        //    var responce = await _context.Responces.FindAsync(statusCode);

        //    if (responce == null)
        //    {
        //        return NotFound();
        //    }

        //    return responce;
        //}





        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }


    }

}


