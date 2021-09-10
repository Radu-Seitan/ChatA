using ChatA.Application.Common.Exceptions;
using ChatA.Domain.Entities;
using ChatA.Domain.Enums;
using ChatA.Infrastructure.Repositories;
using System.Collections;
using System.Linq;
using Xunit;

namespace ChatA.Tests
{
    public class MessageRepositoryTests
    {
        private TestDataContextFactory _factory;
        public MessageRepositoryTests()
        {
            _factory = new TestDataContextFactory();
        }
        [Fact]
        public async void CreateMessage_CreatesMessage()
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

                var repository = new MessageRoomRepository(context);
                await new UserRepository(context).CreateUser(user);
                await repository.CreateGroupMessageRoom(user.Id, "test room");
                var room = context.Memberships.FirstOrDefault(p => p.UserId == user.Id && p.Role == MembershipRole.Owner && p.Room.Name == "test room").Room;

                //Act
                await (new MessageRepository(context)).CreateMessage(user.Id, room.Id, "test");
                var res = context.Messages.FirstOrDefault(m => m.SenderId == user.Id && m.RoomId == room.Id && m.Text == "test");

                //Assert
                Assert.NotNull(res);
                Assert.Equal(user.Id, res.SenderId);
                Assert.Equal(room.Id,res.RoomId);
                Assert.Equal("test", res.Text);
            }
        }

        [Fact]
        public async void GetMessages_When_NullRoomId()
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

                var roomRepository = new MessageRoomRepository(context);
                var userRepository = new UserRepository(context);
                await userRepository.CreateUser(user1);
                await userRepository.CreateUser(user2);
                await roomRepository.CreateGroupMessageRoom(user1.Id, "test room");
                var room = context.Memberships.FirstOrDefault(p => p.UserId == user1.Id && p.Role == MembershipRole.Owner && p.Room.Name == "test room").Room;
                await roomRepository.AddUserToGroupMessageRoom(room.Id, user2.Id);

                var messageRepository = new MessageRepository(context);

                await messageRepository.CreateMessage(user1.Id, room.Id, "test");
                await messageRepository.CreateMessage(user1.Id, room.Id, "test 1");
                await messageRepository.CreateMessage(user2.Id, room.Id, "test 2");

                //Act
                var messages = await messageRepository.GetMessages(room.Id);

                //Assert
                Assert.NotNull(messages);
                Assert.IsAssignableFrom<IEnumerable>(messages);
                Assert.Equal(3, messages.Count());
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task SendingEmptyMessage_RaisesException()
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

                var repository = new MessageRoomRepository(context);
                await new UserRepository(context).CreateUser(user);
                await repository.CreateGroupMessageRoom(user.Id, "test room");
                var room = context.Memberships.FirstOrDefault(p => p.UserId == user.Id && p.Role == MembershipRole.Owner && p.Room.Name == "test room").Room;


                //Assert
                await Assert.ThrowsAsync<EmptyMessageException>(() => new MessageRepository(context).CreateMessage(user.Id, room.Id, ""));
            }
        }
    }
    
}
