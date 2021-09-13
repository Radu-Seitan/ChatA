using AutoMapper;
using ChatA.Application.Common.Mappings;
using ChatA.Application.MessageRooms.Queries;
using ChatA.Application.Messages.Queries;
using ChatA.Application.Users.Queries;
using ChatA.Domain.Entities;
using System;
using System.Runtime.Serialization;
using Xunit;

namespace ChatA.Tests
{
    
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldHave_ValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(Message), typeof(MessageViewModel))]
        [InlineData(typeof(User), typeof(UserViewModel))]
        [InlineData(typeof(MessageRoom), typeof(MessageRoomViewModel))]
        public void ShouldSupport_Mapping_FromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            var mapped = _mapper.Map(instance, source, destination);
            Assert.True(true);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
