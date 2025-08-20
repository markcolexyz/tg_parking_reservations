using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ParkingDbContext _context;

    public AuthController(ParkingDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        // Authenticate against the Employee table
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == loginRequest.EmployeeId && e.Password == loginRequest.Password);

        if (employee == null)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        return Ok(new { Message = "Login successful" });
    }

}
