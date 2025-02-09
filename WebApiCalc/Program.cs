var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/calc", (HttpContext context) =>
{
    var op = context.Request.Query["op"];
    if (!double.TryParse(context.Request.Query["x"], out double x) ||
        !double.TryParse(context.Request.Query["y"], out double y))
    {
        return Results.BadRequest("Invalid parameters");
    }

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
            if (y == 0) return Results.BadRequest("Dividing by 0 not allowed");
            result = x / y;
            break;
        case "pow":
            result = Math.Pow(x, y);
            break;
        case "sqrt":
            if (x < 0) return Results.BadRequest("Cannot calculate square root of negative number");
            result = Math.Pow(x, 1 / y);
            break;
        default:
            return Results.BadRequest("Invalid selection");
    }

    if (double.IsInfinity(result)) return Results.BadRequest("Overflow");
    return Results.Ok(result);
});
app.Run();