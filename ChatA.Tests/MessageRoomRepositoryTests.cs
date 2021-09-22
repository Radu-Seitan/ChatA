using ChatA.Domain.Entities;
using ChatA.Domain.Enums;
using ChatA.Infrastructure.Repositories;
using ChatA.Application.Common.Exceptions;
using System.Linq;
using Xunit;

namespace ChatA.Tests
{
    public class MessageRoomRepositoryTests
    {
        private TestDataContextFactory _factory;
        public MessageRoomRepositoryTests()
        {
            _factory = new TestDataContextFactory();
        }

        [Fact]
        public async void CreateGroupMessageRoom_CreatesRoomAndMembership()
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
                context.Add(user);
                context.SaveChanges();

                //Act
                var repository = new MessageRoomRepository(context);
                await repository.CreateGroupMessageRoom(user.Id, "test room");
                var membership = context.Memberships.FirstOrDefault(p => p.UserId == user.Id && p.Role == MembershipRole.Owner && p.Room.Name == "test room");
                var room = membership.Room;

                //Assert
                Assert.NotNull(membership);
                Assert.IsAssignableFrom<Membership>(membership);
                Assert.NotNull(room);
                Assert.IsAssignableFrom<MessageRoom>(room);
                Assert.Equal(user, membership.User);
            }
        }

        [Fact]
        public async void AddUserToGroupMessageRoom_CreatesSpecificMembership()
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
                context.Add(user1);
                context.Add(user2);
                context.SaveChanges();

                //Act
                var repository = new MessageRoomRepository(context);
                await repository.CreateGroupMessageRoom(user1.Id, "test room");
                var membership = context.Memberships.FirstOrDefault(p => p.UserId == user1.Id && p.Role == MembershipRole.Owner && p.Room.Name == "test room");
                var room = membership.Room;

                await repository.AddUserToGroupMessageRoom(room.Id, user2.Id,user1.Id);
                var membership2 = context.Memberships.FirstOrDefault(p => p.UserId == user2.Id && p.Role == MembershipRole.Default && p.Room.Name == "test room");

                //Assert
                Assert.NotNull(membership2);
                Assert.IsAssignableFrom<Membership>(membership2);
                Assert.Equal(user2, membership2.User);
                Assert.Equal(room, membership2.Room);
            }
        }

        [Fact]
        public async void CreateIndividualMessageRoom_CreatesRoomAndMemberships()
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
                context.Add(user1);
                context.Add(user2);
                context.SaveChanges();

                //Act
                var repository = new MessageRoomRepository(context);
                await repository.CreateIndividualMessageRoom(user1.Id, user2.Id);
                var membership1 = context.Memberships.SingleOrDefault(p => p.UserId == user1.Id
                    && p.Role == MembershipRole.Default
                    && p.Room.Name == $"{user1.Username} & {user2.Username}");
                var membership2 = context.Memberships.SingleOrDefault(p => p.UserId == user2.Id
                    && p.Role == MembershipRole.Default
                    && p.Room.Name == $"{user1.Username} & {user2.Username}");
                var room1 = membership1.Room;
                var room2 = membership2.Room;

                //Assert
                Assert.NotNull(membership1);
                Assert.IsAssignableFrom<Membership>(membership1);
                Assert.Equal(user2, membership2.User);
                Assert.NotNull(membership2);
                Assert.IsAssignableFrom<Membership>(membership2);
                Assert.Equal(user2, membership2.User);
                Assert.Equal(room1, room2);
            }
        }

        [Fact]
        public async void CreateIndividualMessageRoom_RaisesException_WhenCreatedMultipleTimes()
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
                context.Add(user1);
                context.Add(user2);
                context.SaveChanges();

                //Act
                var repository = new MessageRoomRepository(context);
                await repository.CreateIndividualMessageRoom(user1.Id, user2.Id);

                //Assert
                await Assert.ThrowsAsync<BadRequestException>(() => repository.CreateIndividualMessageRoom(user1.Id, user2.Id));
            }
        }
    }
}
