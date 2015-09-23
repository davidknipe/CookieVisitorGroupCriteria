using System.Security.Principal;
using System.Web;
using CookieVisitorGroupCriteria.Enums;
using CookieVisitorGroupCriteria.Models;
using EPiServer.Personalization.VisitorGroups;

namespace CookieVisitorGroupCriteria.Criterion
{
    [VisitorGroupCriterion(
        Category = "Technical Criteria",
        Description = "Check if cookie exits (or not)",
        DisplayName = "Cookie exists",
        LanguagePath = "/cookievisitorgroups/criteria/cookieexistscriterion")]
    public class CookieExistsCriterion : CriterionBase<CookieExistsCriterionModel>
    {
        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var cookie = httpContext.Request.Cookies[Model.CookieName];

            switch (Model.Condition)
            {
                case CookieExistsCondition.Exists:
                    return cookie != null;

                case CookieExistsCondition.DoesNotExist:
                    return cookie == null;

                default:
                    return false;
            }
        }
    }
}
