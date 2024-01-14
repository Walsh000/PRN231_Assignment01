using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using _27_KhuatThiMinhAnh_Repositories.Interfaces;
using _27_KhuatThiMinhAnh_Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_KhuatThiMinhAnh_Asignment01.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository repository = new MemberRepository();

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers() => repository.GetMembers();

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = repository.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Member member)
        {
            if (id != member.MemberID)
            {
                return BadRequest();
            }

            try
            {
                member.Email = repository.GetMemberById(id).Email;
                repository.UpdateMember(member);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            if(repository.GetMemberByEmail(member.Email) != null)
            {
                return BadRequest();
            }
            repository.AddMember(member);

            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Member>> Login(Member member)
        {
            var memberLogin = repository.Login(member.Email, member.Password);
            //await Console.Out.WriteLineAsync("Login API 1 : " + memberLogin.Email + "  " + memberLogin.Password);
            if (memberLogin == null)
            {
                return NotFound();
            }
            await Console.Out.WriteLineAsync("Login API : " + memberLogin.MemberID);
            return memberLogin;
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            if(!MemberExists(id))
            {
                return NotFound();
            }
            repository.DeleteMember(repository.GetMemberById(id));

            return NoContent();
        }

        private bool MemberExists(int id)
        {
            return repository.GetMemberById(id) != null;
        }
    }
}
