var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/calc", async (string op, double x, double y) =>
{

    double result;
    switch (op)
    {
        case "add":
            result = x + y;
            break;
        case "sub":
            result = x - y;
            break;
        case "mul":
            result = x * y;
            break;
        case "div":
            if (y == 0) return "Division by 0 not allowed!";
            else result = x / y;
            break;
        case "pow":
            result = Math.Pow(x, y);
            break;
        case "sqrt":
            result = Math.Pow(y, (1 / x));
            break;
        default:
            return "invalid selection";
    }

    if (double.IsInfinity(result)) return "overflow";
    else return $"{result}";
});

app.Run();


