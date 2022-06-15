using LoopAcademyProject.Test;
using FluentAssertions;
using LoopAcademyProject.Controllers;
using LoopAcademyProject.DatabaseContext;
using LoopAcademyProject.DatabaseContext.Repository;
using LoopAcademyProject.Entities;
using LoopAcademyProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LoopAcademyProject.Test
{
    public class UsersUnitTestController
    {
        private readonly UserService _userService;
        private readonly Logger<UsersController> _logger;

        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=.;Database=LoopAcademyProject;Trusted_Connection=True;";

        static UsersUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public UsersUnitTestController()
        {
            var something = new ApplicationDbContext(dbContextOptions);
            DummyDataDBInitializer _context = new DummyDataDBInitializer();
            _context.Seed(something);

            //_userService = new UserService((IBaseRepository<User>)something);
        }



        #region Read  
        [Fact]
        public async void Task_Read_Return_OkResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var Id = 2;

            //Act  
            var data = await controller.Read(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Read_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var Id = 3;

            //Act  
            var data = await controller.Read(Id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_Read_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            int? Id = null;

            //Act  
            var data = await controller.Read(Id.Value);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Read_MatchResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            int Id = 1;

            //Act  
            var data = await controller.Read(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var user = okResult.Value.Should().BeAssignableTo<User>().Subject;

            Assert.Equal("Test UserName 1", user.UserName);
            Assert.Equal("Test Name 1", user.Name);
            Assert.Equal("Test SurName 1", user.SurName);
            Assert.Equal("Test PhoneNumber 1", user.PhoneNumber);
            Assert.Equal("Test Birth 1", Convert.ToString(user.Birth));
            Assert.Equal("Test NationalCode 1", user.NationalCode);
        }
        #endregion



        #region ReadAll 
        [Fact]
        public async void Task_ReadAll_Return_OkResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);

            //Act  
            var data = await controller.ReadAll();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_ReadAll_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);

            //Act  
            var data = controller.ReadAll();
            data = null;

            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_ReadAll_MatchResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);

            //Act  
            var data = await controller.ReadAll();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var user = okResult.Value.Should().BeAssignableTo<List<User>>().Subject;

            Assert.Equal("Test UserName 1", user[0].UserName);
            Assert.Equal("Test Name 1", user[0].Name);
            Assert.Equal("Test SurName 1", user[0].SurName);
            Assert.Equal("Test PhoneNumber 1", user[0].PhoneNumber);
            Assert.Equal("Test Birth 1", Convert.ToString(user[0].Birth));
            Assert.Equal("Test NationalCode 1", user[0].NationalCode);

            Assert.Equal("Test UserName 2", user[1].UserName);
            Assert.Equal("Test Name 2", user[1].Name);
            Assert.Equal("Test SurName 2", user[1].SurName);
            Assert.Equal("Test PhoneNumber 2", user[1].PhoneNumber);
            Assert.Equal("Test Birth 2", Convert.ToString(user[1].Birth));
            Assert.Equal("Test NationalCode 2", user[1].NationalCode);
        }
        #endregion



        #region Create 
        [Fact]
        public async void Task_Create_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var user = new User() { UserName = "Test UserName 1", Name = "Test Name 1", SurName = "Test SurName 1", PhoneNumber = "Test PhoneNumber 1", Birth = Convert.ToDateTime("Test Birth 1"), NationalCode = "Test NationalCode 1" };

            //Act  
            var data = await controller.Create(user);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Create_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            User user = new User() { UserName = "Test UserName 1", Name = "Test Name 1", SurName = "Test SurName 1", PhoneNumber = "Test PhoneNumber 1", Birth = Convert.ToDateTime("Test Birth 1"), NationalCode = "Test NationalCode 1" };

            //Act              
            var data = await controller.Create(user);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Create_ValidData_MatchResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var user = new User() { UserName = "Test UserName 1", Name = "Test Name 1", SurName = "Test SurName 1", PhoneNumber = "Test PhoneNumber 1", Birth = Convert.ToDateTime("Test Birth 1"), NationalCode = "Test NationalCode 1" };

            //Act  
            var data = await controller.Create(user);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;

            Assert.Equal(3, okResult.Value);
        }
        #endregion



        #region Update 
        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var Id = 2;

            //Act  
            var existingUser = await controller.Read(Id);
            var okResult = existingUser.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<User>().Subject;

            var user = new User();
            user.UserName = result.UserName;
            user.Name = result.Name;
            user.SurName = result.SurName;
            user.PhoneNumber = result.PhoneNumber;
            user.Birth = result.Birth;
            user.NationalCode = result.NationalCode;
          
            var updatedData = await controller.Update(user);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var Id = 2;

            //Act  
            var existingUser = await controller.Read(Id);
            var okResult = existingUser.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<User>().Subject;

            var user = new User();
            user.UserName = result.UserName;
            user.Name = result.Name;
            user.SurName = result.SurName;
            user.PhoneNumber = result.PhoneNumber;
            user.Birth = result.Birth;
            user.NationalCode = result.NationalCode;

            var data = await controller.Update(user);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_NotFound()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var Id = 2;

            //Act  
            var existingUser = await controller.Read(Id);
            var okResult = existingUser.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<User>().Subject;

            var user = new User();
            user.Id = 5;
            user.UserName = result.UserName;
            user.Name = result.Name;
            user.SurName = result.SurName;
            user.PhoneNumber = result.PhoneNumber;
            user.Birth = result.Birth;
            user.NationalCode = result.NationalCode;

            var data = await controller.Update(user);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }
        #endregion



        #region Delete  
        [Fact]
        public async void Task_Delete_Return_OkResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var Id = 2;

            //Act  
            var data = await controller.Delete(Id);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public async void Task_Delete_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            var Id = 5;

            //Act  
            var data = await controller.Delete(Id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_Delete_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new UsersController(_userService, _logger);
            int? Id = null;

            //Act  
            var data = await controller.Delete(Id.Value);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
        #endregion
    }
}