using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.Interfaces
{
    public interface IViewModel
    {
        IEnumerable<ValidationResult> Validate();
    }
}
