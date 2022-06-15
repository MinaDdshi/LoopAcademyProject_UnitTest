using LoopAcademyProject.DatabaseContext;
using LoopAcademyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAcademyProject.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(ApplicationDbContext _context)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.Users.AddRange(
                new User() { UserName = "Test UserName 1", Name = "Test Name 1", SurName = "Test SurName 1", PhoneNumber = "Test PhoneNumber 1", Birth = Convert.ToDateTime("Test Birth 1"), NationalCode = "Test NationalCode 1" }
            );
            _context.SaveChanges();
        }
    }
}
