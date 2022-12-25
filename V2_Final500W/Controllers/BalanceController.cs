using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using V2_Final500W.Models;
using V2_Final500W.Repositories;
using V2_Final500W.ViewModels;

namespace V2_Final500W.Controllers
{
    /// <summary>
    /// Balance Controller with CRUD actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class BalanceController : ControllerBase
    {

        private readonly UniversityDbContext _context;

        private readonly IGenericRepository<Balance> _balanceRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public BalanceController(IGenericRepository<Balance> balanceRepository,
            UniversityDbContext context)
        {
            _balanceRepository = balanceRepository;

            _context = context;

        }
        /// <summary>
        /// Controller for getting the list of all Balances
        /// </summary>
        /// <returns>The List of Balances</returns>
        [HttpGet]
        public async Task<IEnumerable<BalanceModel>> GetAllBalances()
        {
            List<BalanceModel> balanceModel = new();
            Expression<Func<Balance, object>> includes = exp => exp.Student;
            Expression<Func<Balance, object>> includes2 = exp2 => exp2.Semester;

            var balances = await _balanceRepository.GetAllAsync(null, new[] { includes, includes2 });

            return balances.Select(x => new BalanceModel
            {
                Amount = x.Amount,
                Debth = x.Debth,
                
                StudentId = x.Student?.Id,
                SemesterId = x.Semester?.Id

            });
        }

        /// <summary>
        /// Controller for getting the particular Balance through existing id 
        /// </summary>
        /// <returns>The one particular Balance model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BalanceModel>> GetBalance(int id)
        {
            var balance = await _balanceRepository.GetByIdAsync(id);

            if (balance == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(balance);
        }

        /// <summary>
        /// Controller for inserting the one particular address 
        /// </summary>
        /// <returns>Status ok if it was inserted</returns>
        [HttpPost]
        public async Task AddBalance(BalanceModel balance)
        {
            await _balanceRepository.AddAsync(new Balance
            {
                Amount = balance.Amount,
                Debth = balance.Debth,
                StudentId = balance.StudentId,
                SemesterId = balance.SemesterId
            });
            await _balanceRepository.SaveAsync();
        }

        /// <summary>
        /// Controller for editing the one particular Balance choose by id
        /// </summary>
        /// <returns>Status ok if it was updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBalance(int id, BalanceModel bal)
        {
            var balance = await _balanceRepository.GetByIdAsync(id);
            if (BalanceExists(id))
            {
                if (bal.SemesterId != 0)
                {
                    balance.SemesterId = bal.SemesterId;
                }
                //else if(SemestertExists(bal.SemesterId)){
                //    return StatusCode(500, $"This semester Id does not exists");
                //}
                else
                {
                    balance.SemesterId = balance.SemesterId;
                }
                if (bal.StudentId != 0)
                {
                    balance.StudentId = bal.StudentId;
                }
                //else if (StudentExists(bal.StudentId))
                //{
                //    return StatusCode(500, $"This student Id does not exists");
                //}
                else
                {
                    balance.StudentId = balance.StudentId;
                }
                if (bal.Amount != 0)
                {
                    if (bal.Amount== null)
                    {
                        return StatusCode(400, $"The Amount field is required.");
                    }

                    balance.Amount = bal.Amount;
                }

                else
                {
                    balance.Amount = balance.Amount;
                }
                if (bal.Debth != null)
                {
                    balance.Debth = bal.Debth;
                }
                else
                {
                    balance.Debth = balance.Debth;
                }

                _balanceRepository.Update(balance);
                await _balanceRepository.SaveAsync();
            }
            else
            {
                return StatusCode(500, $"Wrong Parameters");

            }

            return NoContent();
        }

        /// <summary>
        /// Controller for deleting the one particular Balance choose by id
        /// </summary>
        /// <returns>Status ok if it was deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBalance(int id)
        {
            var balance = await _balanceRepository.GetByIdAsync(id);
            if (balance == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }
            _balanceRepository.Delete2(balance);
            await _balanceRepository.SaveAsync();

            return NoContent();
        }


        private bool BalanceExists(int id)
        {
            //return _context.Balances.Any(e => e.Id == id);
            return _balanceRepository.GetByIdAsyncBool(id);
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


