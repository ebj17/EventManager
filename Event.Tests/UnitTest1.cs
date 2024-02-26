namespace Event.Tests;
using EventProgram;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        string expected = "Hello world!";

        //Actual
        string actual = Program.GetHelloWorld();

        //Assert
        Assert.Equal(expected, actual);
    }
}