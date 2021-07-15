using System.ComponentModel.DataAnnotations;
using CookieVisitorGroupCriteria.Enums;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Web.Mvc.VisitorGroups;

namespace CookieVisitorGroupCriteria.Models
{
    /// <summary>
    /// Model for the CookieExistsCriterion
    /// </summary>
    public class CookieExistsCriterionModel : CriterionModelBase
    {
        [Required]
        public string CookieName { get; set; }

        [Required]
        [CriterionPropertyEditor(SelectionFactoryType = typeof(EnumSelectionFactory))]
        public CookieExistsCondition Condition { get; set; }

        public override ICriterionModel Copy()
        {
            return ShallowCopy();
        }
    }
}