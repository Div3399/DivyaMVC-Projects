using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.Intrinsics.X86;
using WelMVCC.Entities;
using WelMVCC.Model;

namespace WelMVCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DBContext DBContext;

        public EmployeeController(DBContext DBContext)
        {
            this.DBContext = DBContext;

        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetEmployee()
        {
            var List = await DBContext.Employees.Select(
                s => new EmployeeDTO
                {
                    EmployeeId = s.EmployeeId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Gender= s.Gender,
                    Age = s.Age

                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetEmployeebyId")]
        
        public async Task<ActionResult<EmployeeDTO>> GetEmployeebyId(int EmployeeId)
        {
            var emp= await DBContext.Employees.Select(
                  s=> new EmployeeDTO
                  {
                      EmployeeId = s.EmployeeId,
                      FirstName = s.FirstName,
                      LastName= s.LastName,
                      Gender= s.Gender,
                      Age= s.Age
                  }
                ).FirstOrDefaultAsync(s=>s.EmployeeId==EmployeeId);

             if(emp==null) 
             {
                return NotFound();
             }
             else 
            {
                return emp;
            
            }
        }


        [HttpPost("InsertEmployee")]
        public async Task<HttpStatusCode> InsertEmployee([FromBody] InsertEmployeeDTO objemp)
        {
            var entity = new Employee();
            {

                entity.FirstName = objemp.FirstName;

                entity.LastName = objemp.LastName;

                entity.Gender = objemp.Gender;

                entity.Age = objemp.Age;

            }
            DBContext.Employees.Add(entity);
            await DBContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }


        [HttpPut("UpdateEmployee")]
        public async Task<HttpStatusCode> UpdateEmployee([FromForm] InsertEmployeeDTO objemp)

        {
            var entity= await DBContext.Employees.FirstOrDefaultAsync
                (s=>s.EmployeeId==objemp.EmployeeId);
            {
                entity.FirstName=objemp.FirstName;
                entity.LastName=objemp.LastName;
                entity.Gender=objemp.Gender;
                entity.Age=objemp.Age;

                await DBContext.SaveChangesAsync();
                return HttpStatusCode.Created;


            }

        }

        [HttpDelete("DeleteEmployee")]

        public async Task<HttpStatusCode> DeleteEmployee(int EmployeeId)
        {
            var entity = new Employee()
            {
                EmployeeId = EmployeeId 
            };

            DBContext.Employees.Attach(entity);
            DBContext.Employees.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.NoContent;
        }

        [HttpGet("GetComman")]

        public async Task<ActionResult<CommonData>> GetComman()
        {
            checkcommandata checkcommandata = new checkcommandata();
            CommonData COdata = new CommonData();
            List<BloodgroupDTO> listblood = new List<BloodgroupDTO>();
            List<CasteDTO>listcaste= new List<CasteDTO>();

            var blood = from B1 in DBContext.BloodGroups
                        select new
                        {
                            B1.BloodGroupId,
                            B1.BGName,
                        };

            var listb = await blood.ToListAsync().ConfigureAwait(false);

            BloodgroupDTO objbdto = null;
            foreach (var item in listb)
            {
                objbdto = new BloodgroupDTO();
                objbdto.BloodGroupId = item.BloodGroupId;
                objbdto.BGName = item.BGName;
                listblood.Add(objbdto);
            }

            var caste = from C1 in DBContext.Castes
                        select new
                        {
                            C1.CasteId,
                            C1.CasteName,
                        };

            var listc = await caste.ToListAsync().ConfigureAwait(false);

            CasteDTO objcdto = null;
            foreach(var item in listc)
            {
                objcdto = new CasteDTO();
                objcdto.CasteId=item.CasteId;
                objcdto.CasteName=item.CasteName;
                listcaste.Add(objcdto);
            }

            checkcommandata.Castes = listcaste;
            checkcommandata.Bloodgroups=listblood;

            COdata.data = checkcommandata;
            COdata.message = "success";
            COdata.status = true;

            return COdata;



        }



    }
}
