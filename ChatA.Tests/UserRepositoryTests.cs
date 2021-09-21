using ChatA.Domain.Entities;
using ChatA.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using Xunit;

namespace ChatA.Tests
{
    public class UserRepositoryTests
    {
        private TestDataContextFactory _factory;

        public UserRepositoryTests()
        {
            _factory = new TestDataContextFactory();
        }

        [Fact]
        public async void CreateUser_AddsUserToDatabase()
        {
            using (var context = _factory.Create())
            {
                //Arrange
                var user = new User
                {
                    Id = "1",
                    Email = "user@user.com",
                    Memberships = new(),
                    Username = "test user"
                };

                //Act            
                var userRepository = new UserRepository(context);
                await userRepository.CreateUser(user);

                //Assert
                Assert.Contains(user, context.Users.ToList());
            }
        }

        [Fact]
        public async void SearchUsers_ReturnsListOfAllUsers()
        {
            using (var context = _factory.Create())
            {
                //Arrange
                var user1 = new User
                {
                    Id = "1",
                    Email = "user1@user.com",
                    Memberships = new(),
                    Username = "test user 1"
                };

                var user2 = new User
                {
                    Id = "2",
                    Email = "user2@user.com",
                    Memberships = new(),
                    Username = "test user 2"
                };

                var user3 = new User
                {
                    Id = "3",
                    Email = "user3@user.com",
                    Memberships = new(),
                    Username = "andrei"
                };

                var userRepository = new UserRepository(context);
                await userRepository.CreateUser(user1);
                await userRepository.CreateUser(user2);
                await userRepository.CreateUser(user3);

                //Act            
                var res1 = await userRepository.SearchUsers("user");
                var res2 = await userRepository.SearchUsers();

                //Assert
                Assert.NotNull(res1);
                Assert.IsAssignableFrom<IEnumerable>(res1);
                Assert.Contains(user1, res1);
                Assert.Contains(user2, res1);
                Assert.Equal(2, res1.Count());
                Assert.Equal(6, res2.Count());
            }
        }
    }
}
