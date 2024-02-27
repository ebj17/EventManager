using Xunit;
using MyEvents;

namespace MyEvents.Tests
{
    public class EventTests
    {
        [Fact]
        public void Event_IsActive_WhenCreated()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50);
            Assert.True(evnt.IsActive);
        }

        [Fact]
        public void CancelEvent_SetsIsActiveToFalse()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50);
            evnt.Cancel();
            Assert.False(evnt.IsActive);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        public void RegisterAttendee_DecreasesCapacity(int initialCapacity)
        {
            var evnt = new Event("Code Workshop", "Workshop", initialCapacity);
            bool registrationResult = evnt.RegisterAttendee();

            Assert.True(registrationResult);
            Assert.Equal(initialCapacity - 1, evnt.Capacity);
        }

        [Fact]
        public void RegisterAttendee_ReturnsFalse_WhenEventIsFull()
        {
            var evnt = new Event("Code Workshop", "Workshop", 0); // Event is already full
            bool registrationResult = evnt.RegisterAttendee();
            Assert.False(registrationResult);
        }

        [Fact]
        public void Vertifying_VIPAttendance()
        {
        //Arrange
        var evnt1 = new Event("Midget mathematical problems","Workshop", 4);
        evnt1.VIP_list("Epstein");
        //Since the Class program will belong to an instance of Event, we have to create a mock one

        //Act
        var actual = evnt1.VIPs; 
        //Assert
        Assert.Contains("Epstein", actual);
        }

        [Fact]
        public void NoDuplicate_creation()
        {
            //Arrange
            var evnt2 = new Event("Epstein didnt kill himself", "Fact", 10);

            //Act
            try
            {
            evnt2.VIP_list("Bruv");
            evnt2.VIP_list("Bruv");
            }

            //Assert
            catch (ArgumentException)
            {
                return; //test passed
            }
            Assert.True(false, "Expected Exception was not thrown");
        }

    }
}