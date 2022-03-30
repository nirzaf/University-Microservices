using FluentValidation;

namespace University.Courses.Application.Commands.Validators;

public class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
{
    public AddCourseCommandValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("title not be empty!");
        RuleFor(x => x.Credits).GreaterThan(0).WithMessage("credits must greater than 0!");
        RuleFor(x => x.DepartmentId).NotNull().WithMessage("departmentId not be null! ");
    }
}