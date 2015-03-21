using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mango.Core.Web.CustomValidators {

    /// <summary>
    /// Validates url slug value.
    /// </summary>
    public class UrlSlugValidatorAttribute: RegularExpressionAttribute, IClientValidatable {

        private const string _pattern = @"[a-z0-9-_]*";
        private const string _errorMessage = "Only Letters, Numbers, and &quot;-&quot; allowed";

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlSlugValidatorAttribute"/> class.
        /// </summary>
        public UrlSlugValidatorAttribute()
            : base(_pattern) {
            ErrorMessage = _errorMessage;
        }

        /// <summary>
        /// When implemented in a class, returns client validation rules for that class.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        /// <param name="context">The controller context.</param>
        /// <returns>
        /// The client validation rules for this validator.
        /// </returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {
            yield return new ModelClientValidationRegexRule(_errorMessage, _pattern);
        }
    }

    
}