using FluentValidation;
using FluentValidation.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IValidator<StudentDto> _validator;

        private static List<StudentDto> students = new();
        public StudentController(IValidator<StudentDto> validator)
        {
            _validator = validator;
        }
        [HttpPost]
        public IActionResult Add(StudentDto student)
        {
            var validate = _validator.Validate(student);

            if (validate.IsValid)
            {
                students.Add(student);

                return Ok("Added Successfully");
            }

            return BadRequest(validate.Errors.ToList());
        }
    }
}
