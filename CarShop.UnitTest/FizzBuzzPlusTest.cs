using System.Collections;
using System.Text;

namespace CarShop.UnitTest;

public class FizzBuzzPlusTest
{
    private readonly FizzBuzz _fizzBuzz = new();

    [Test]
    public void GivenNumber_WhenDivisibleBy3ButNotContaining3_ReturnsFizz()
    {
        string result = _fizzBuzz.GetSingleString(6);

        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void GivenNumber_WhenDivisibleBy3AndContains3_ReturnsFizz()
    {
        string result = _fizzBuzz.GetSingleString(3);

        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void GivenNumber_WhenDivisibleBy5ButNotContaining5_ReturnsBuzz()
    {
        string result = _fizzBuzz.GetSingleString(10);

        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [Test]
    public void GivenNumber_WhenDivisibleBy5AndContains5_ReturnsBuzz()
    {
        string result = _fizzBuzz.GetSingleString(5);

        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [Test]
    public void GivenNumberIsDivisibleBy3And5_WhenNotContaining3Or5_ReturnsFizzBuzz()
    {
        string result = _fizzBuzz.GetSingleString(60);

        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    [Test]
    public void GivenNumberIsDivisibleBy3And5_WhenContains3AndNotContaining5_ReturnsFizzBuzz()
    {
        string result = _fizzBuzz.GetSingleString(30);

        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    [Test]
    public void GivenNumberIsDivisibleBy3And5_WhenContains3And5_ReturnsFizzBuzz()
    {
        string result = _fizzBuzz.GetSingleString(15);

        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    [Test]
    public void GivenNumberIsNotDivisibleBy3And5_WhenContains3AndNotContaining5_ReturnsFizz()
    {
        string result = _fizzBuzz.GetSingleString(31);

        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void GivenNumberIsNotDivisibleBy3And5_WhenNotContaining3AndContains5_ReturnsBuzz()
    {
        string result = _fizzBuzz.GetSingleString(25);

        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [Test]
    public void GivenNumberIsNotDivisibleBy3And5_WhenContains3And5_ReturnsFizzBuzz()
    {
        string result = _fizzBuzz.GetSingleString(35);

        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    [Test]
    public void GivenNumberIsNotDivisibleBy3And5_WhenNotContaining3Or5_ReturnsEmptyString()
    {
        string result = _fizzBuzz.GetSingleString(1);

        Assert.That(result, Is.EqualTo(string.Empty));
    }
}

internal class FizzBuzz
{
    private static readonly Dictionary<Predicate<int>, string> predicates = new Dictionary<Predicate<int>, string>()
    {
        { x => x % 3 == 0 || x.ToString().Contains('3'), "Fizz" },
        { x => x % 5 == 0 || x.ToString().Contains('5'), "Buzz" }
    };

    public string GetSingleString(int number)
    {
        var result = string.Empty;
        foreach (var (predicate, value) in predicates)
        {
            if (predicate(number))
            {
                result += value;
            }
        }
        return result;
    }

    public string GetFullString(int limit)
    {
        var sb = new StringBuilder();
        for (var i = 1; i <= limit; i++)
        {
            string str = GetSingleString(i);
            sb.Append(str);
        }
        return sb.ToString();
    }
}