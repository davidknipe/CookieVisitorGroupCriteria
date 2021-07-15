using System.ComponentModel.DataAnnotations;
using CookieVisitorGroupCriteria.Enums;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Web.Mvc.VisitorGroups;

namespace CookieVisitorGroupCriteria.Models
{
    /// <summary>
    /// Model for CookieValueCriterion
    /// </summary>
    public class CookieValueCriterionModel : CriterionModelBase
    {
        /// <summary>
        /// The name of the cookie to check
        /// </summary>
        [Required]
        public string CookieName { get; set; }

        /// <summary>
        /// The condition to apply when checking the cookie value
        /// </summary>
        [Required]
        [CriterionPropertyEditor(SelectionFactoryType = typeof(EnumSelectionFactory))]
        public CookieValueCondition Condition { get; set; }

        /// <summary>
        /// The value to check for in the cookie
        /// </summary>
        [Required]
        public string CookieValue { get; set; }

        /// <summary>
        /// Whether the value check is case senstive or not
        /// </summary>
        [CriterionPropertyEditor(LabelTranslationKey = "/cookievisitorgroupcriteria/casesensitive")]
        public bool CaseSensitive { get; set; }

        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }
    }
}