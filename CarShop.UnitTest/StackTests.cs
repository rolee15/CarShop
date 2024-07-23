namespace CarShop.UnitTest;

public class StackTests
{
    private Stack myStack;

    [SetUp]
    public void Setup()
    {
        myStack = new Stack();
    }

    [Test]
    public void GivenEmptyStack_WhenNumberIsPushed_ThatNumberIsPopped()
    {
        myStack.Push(42);

        int result = myStack.Pop();

        Assert.That(result, Is.EqualTo(42));
    }

    [TestCase(new[] { 13, 42 }, new[] { 42, 13 })]
    [TestCase(new[] { -40, 0, 80 }, new[] { 80, 0, -40 })]
    public void GivenBlankStack_WhenPushingMultipleNumbers_ThenReverseOrderIsDropped(int[] input, int[] expectedOutput)
    {
        // Arrange
        foreach (int item in input) myStack.Push(item);

        // Act + Assert
        foreach (int item in expectedOutput)
        {
            Assert.That(myStack.Pop(), Is.EqualTo(item));
        }

        // Assert.That(actualOutputArray, Is.EqualTo(expectedOutput));
    }
}

internal class Stack
{
    private List<int> numbers = [];

    public void Push(int number)
    {
        numbers.Add(number);
    }

    public int Pop()
    {
        int item = numbers[^1];
        numbers.RemoveAt(numbers.Count - 1);
        return item;
    }
}
