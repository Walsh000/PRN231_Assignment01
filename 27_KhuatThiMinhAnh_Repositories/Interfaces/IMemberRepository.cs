using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_Repositories.Interfaces
{
    public interface IMemberRepository
    {
        List<Member> GetMembers();
        Member GetMemberById(int id);
        Member GetMemberByEmail(string email);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
        Member Login(string email, string password);
    }
}
