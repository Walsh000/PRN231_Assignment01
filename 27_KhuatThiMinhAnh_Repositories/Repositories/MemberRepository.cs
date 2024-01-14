using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using _27_KhuatThiMinhAnh_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_Repositories.Repositories
{
    public class MemberRepository : Interfaces.IMemberRepository
    {
        public void AddMember(Member member) => MemberDAO.AddMember(member);

        public void DeleteMember(Member member) => MemberDAO.DeleteMember(member);

        public Member GetMemberByEmail(string email) => MemberDAO.GetMemberByEmail(email);

        public Member GetMemberById(int id) => MemberDAO.GetMemberByID(id);

        public List<Member> GetMembers() => MemberDAO.GetMembers();

        public Member Login(string email, string password) => MemberDAO.Login(email, password);

        public void UpdateMember(Member member) => MemberDAO.UpdateMember(member);
    }
}
