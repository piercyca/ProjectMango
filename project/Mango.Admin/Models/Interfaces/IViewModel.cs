using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mango.Admin.Models.Interfaces
{
    public interface IViewModel
    {
        IEnumerable<ValidationResult> Validate();
    }
}
