using _27_KhuatThiMinhAnh_BusinessObjects;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_DataAccess
{
    public class MemberDAO
    {
        /// <summary>
        /// GET ALL members
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Member> GetMembers()
        {
            var members = new List<Member>();
            try
            {
                using (var context = new AppDBContext())
                {
                    members = context.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        /// <summary>
        /// GET member by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Member GetMemberByID(int id)
        {
            var member = new Member();
            try
            {
                using (var context = new AppDBContext())
                {
                    member = context.Members.SingleOrDefault(x => x.MemberID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public static Member GetMemberByEmail(string email)
        {
            var member = new Member();
            try
            {
                using (var context = new AppDBContext())
                {
                    member = context.Members.SingleOrDefault(x => x.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        /// <summary>
        /// ADD new member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool AddMember(Member member)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Members.Add(member);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UPDATE member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool UpdateMember(Member member)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Entry(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DELETE member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static void DeleteMember(Member member)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var memberToDelete = context.Members.SingleOrDefault(x => x.MemberID == member.MemberID);
                    if (memberToDelete != null)
                    {
                        context.Members.Remove(memberToDelete);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// LOGIN
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Member Login(string email, string password)
        {
            var member = new Member();
            try
            {
                using (var context = new AppDBContext())
                {
                    member = context.Members.SingleOrDefault(x => x.Email == email && x.Password == password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
    }
}
