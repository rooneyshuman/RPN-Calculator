# Reverse Polish Notation Calculator

A test suite was added to the Reverse Polish Notation Calculator program. Excluding the driver Program class, 
code test coverage was increased to ~95%.

## Background

Calculator program is written in C# using .Net CORE 2.1

## Test Suite

Use Visual Studio or any other IDE with a testing capability and select "Run Tests".

### Test Breakdown

#### CalculatorTests
Tests that each operation from the Calculator class is performed properly. The result is verified using Fluent Assertions 
against the expected result of the operation. Also checks that an exception is thrown on divisions by 0.

```
result.Should().Be(24, "Because addition...");
```
```
Assert.Throws<ArgumentException>(() => calc.Divide(first, second));
```

#### LoggerTests
Tests that each Logger class method is executed when expected. A temporary log file is created at the beginning of the tests 
and deleted after the tests have been completed. FluentAssertions was used to verify if a string that should have been logged
was properly written, or to check if one that should not have been logged was properly ignored.

```
logFile.Should().Contain("write me");
```
```
logFile.Should().NotContain("don't write me");
```

#### RpnEngineTests
Tests that proper calls to Calculator and Logger class methods were made by injecting a fakes into a new RpnEngine constructor.
FakeItEasy was used to create the fake objects and to verify that the method calls were made for each operation. Also verifies
an exception is thrown when an unparsable token was entered.

```
A.CallTo(() => calc.Multiply(3, 2)).MustHaveHappened();
```
```
A.CallTo(() => log.Fatal("Could not parse []]")).MustHaveHappened();
```
```
Assert.Throws<ArgumentException>(() => rpnEngine.CalculateRpn(input));
```

### Frameworks Used

* Fluent Assertions
* FakeItEasy

## Authors

* **Belén Bustamante** - *RPN Calculator Test Suite* - [rooneyshuman](https://github.com/rooneyshuman)
* **Chris Gilmore** - *RPN Calculator Program*

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
