using FluentValidation.Results;

namespace buckstore.manager.service.application.Commands
{
	public abstract class Command
	{
		protected ValidationResult ValidationResult { get; set; }

		public ValidationResult GetValidationResult()
		{
			return ValidationResult;
		}

		public abstract bool IsValid();
	}
}