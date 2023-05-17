# Arithmetic Constraints

SICP Chapter 3.3.5 arithmetic constraints in C#.

Allows you to define variables that can be set or read and arithmetic operations
comprising these variables as well as constants. The following example converts
Degree Celsius to Degree Fahrenheit **and vice versa** with a single arithmetic
constraint equation.

```csharp
using static ArithmeticConstraints.Constraints;

...

var C = Variable("C");
var F = Variable("F");

Equal(9 * C, 5 * (F - 32));
// var _ = 9 * C == 5 * (F - 32);

Set(C, 0);

Assert.Equal(32, F.GetValue());

Unset(C);
Set(F, 86);

Assert.Equal(30, C.GetValue());

```

First we set `C` to 0 °C and read 32 °F from `F`. Then we revoke the set value
for `C` and set `F` to 86 °F instead. This time we read 30 °C from `C`.

## Limitations

Many operations like powers, roots, exponentiation, logarithms or trigonometric
functions are missing. Some of these functions don't have a unique inverse value
for all input values.

## References

**Structure and Interpretation of Computer Programs**,
*H. Abelson, G. Sussman, and with Julie Sussman*,
MIT Press/McGraw-Hill, Cambridge, 2nd Editon edition, (1996)