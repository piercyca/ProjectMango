using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Mango.Core.Infrastructure;
using Mango.Core.Repository;
using Mango.Core.Service;

namespace Mango.Core.Web.CustomValidators {

    public enum UniqueValidatorType {
        /// <summary>
        /// Product Category UrlSlug
        /// </summary>
        ProductCategoryUrlSlug,
        /// <summary>
        /// Product UrlSlug
        /// </summary>
        ProductUrlSlug
    }

    /// <summary>
    /// Determines if input value is unique in the database.
    /// </summary>
    public class UniqueValidatorAttribute: ValidationAttribute, IClientValidatable {
        /// <summary>
        /// Indentify property, used to omit the current record to determine uniqueness 
        /// compared to all OTHER records. If value is 0 then new record is assumed. 
        /// </summary>
        public string CurrentIdProperty { get; private set; }
        /// <summary>
        /// The type of validator. Determines which validation logic to use.
        /// </summary>
        public UniqueValidatorType UniqueValidatorType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueValidatorAttribute"/> class.
        /// </summary>
        /// <param name="currentIdProperty">Name of unique identifier property in model.</param>
        /// <param name="uniqueValidatorType"><see cref="UniqueValidatorType"/> type</param>
        public UniqueValidatorAttribute(string currentIdProperty, UniqueValidatorType uniqueValidatorType) {
            CurrentIdProperty = currentIdProperty;
            UniqueValidatorType = uniqueValidatorType;
        }

        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var currentIdPropertyValue = validationContext.ObjectType.GetProperty(CurrentIdProperty).GetValue(validationContext.ObjectInstance, null);
            if (currentIdPropertyValue == null) {
                return new ValidationResult("Model Error: CurrentIdProperty is null. Check spelling or syntax.");
            }
            int currentId;
            if (int.TryParse(currentIdPropertyValue.ToString(), out currentId)) {
                
                if (value != null) {
                    var result = ValidationResult.Success;
                    if (!string.IsNullOrEmpty(value.ToString())) {
                        var currentValue = value.ToString();
                        var dbFactory = new DatabaseFactory();
                        bool isValid;
                        switch (UniqueValidatorType) {
                            case UniqueValidatorType.ProductCategoryUrlSlug:
                                var productCategoryService = new ProductCategoryService(new ProductCategoryRepository(dbFactory), new UnitOfWork(dbFactory));
                                isValid = !productCategoryService.UrlSlugExists(currentValue, currentId);
                                break;
                            case UniqueValidatorType.ProductUrlSlug:
                                var productService = new ProductService(new ProductRepository(dbFactory), new UnitOfWork(dbFactory));
                                isValid = !productService.UrlSlugExists(currentValue, currentId);
                                break;
                            default:
                                return new ValidationResult("Model Error: 'UniqueValidatorType' invalid.");
                        }
                        if (!isValid) {
                            result = new ValidationResult(ErrorMessage);
                        }
                    }
                    return result;
                }
                return new ValidationResult("Model Error: 'value' is null.");
            }
            return new ValidationResult("Model Error: Identifier property 'null' or invalid.");
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
            var rule = new ModelClientValidationRule {
                ErrorMessage = ErrorMessage,
                ValidationType = "uniquevalidator"
            };
            rule.ValidationParameters["currentidproperty"] = CurrentIdProperty;
            rule.ValidationParameters["uniquevalidatortype"] = UniqueValidatorType;
            yield return rule;
        }

        public UniqueValidatorAttribute()
        {
        }
    }

    
}