using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Mango.Web.Models.Interfaces;

namespace Mango.Web.Models.Abstracts
{
    public abstract class ViewModel : IViewModel
    {
        public IEnumerable<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, context, validationResults, true);
            return validationResults;
        }
    }
}
