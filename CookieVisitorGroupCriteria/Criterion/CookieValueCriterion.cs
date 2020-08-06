using System;
using System.Security.Principal;
using System.Web;
using CookieVisitorGroupCriteria.Enums;
using CookieVisitorGroupCriteria.Models;
using EPiServer.Personalization.VisitorGroups;

namespace CookieVisitorGroupCriteria.Criterion
{
    [VisitorGroupCriterion(
        Category = "Technical Criteria",
        Description = "Check a cookie value",
        DisplayName = "Cookie value")]
    public class CookieValueCriteria : CriterionBase<CookieValueCriterionModel>
    {
        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var cookie = HttpContext.Current.Request.Cookies[Model.CookieName];
            if (cookie == null)
            {
                return false;
            }

            var cookieValue = cookie.Value;
            if (string.IsNullOrWhiteSpace(cookieValue))
            {
                return false;
            }

            switch (Model.Condition)
            {
                case CookieValueCondition.Contains:
                    return Model.CaseSensitive
                        ? cookieValue.IndexOf(Model.CookieValue, 0, StringComparison.CurrentCulture) >= 0
                        : cookieValue.IndexOf(Model.CookieValue, 0, StringComparison.CurrentCultureIgnoreCase) >= 0;

                case CookieValueCondition.DoesNotContain:
                    return !Model.CaseSensitive
                        ? cookieValue.IndexOf(Model.CookieValue, 0, StringComparison.CurrentCulture) >= 0
                        : cookieValue.IndexOf(Model.CookieValue, 0, StringComparison.CurrentCultureIgnoreCase) >= 0;

                case CookieValueCondition.Is:
                    return Model.CaseSensitive
                        ? Model.CookieValue.Equals(cookieValue, StringComparison.CurrentCulture)
                        : Model.CookieValue.Equals(cookieValue, StringComparison.CurrentCultureIgnoreCase);

                case CookieValueCondition.IsNot:
                    return !(Model.CaseSensitive
                        ? Model.CookieValue.Equals(cookieValue, StringComparison.CurrentCulture)
                        : Model.CookieValue.Equals(cookieValue, StringComparison.CurrentCultureIgnoreCase));

                case CookieValueCondition.StartsWith:
                    return !(Model.CaseSensitive
                        ? Model.CookieValue.StartsWith(cookieValue, StringComparison.CurrentCulture)
                        : Model.CookieValue.StartsWith(cookieValue, StringComparison.CurrentCultureIgnoreCase));

                case CookieValueCondition.EndsWith:
                    return !(Model.CaseSensitive
                        ? Model.CookieValue.EndsWith(cookieValue, StringComparison.CurrentCulture)
                        : Model.CookieValue.EndsWith(cookieValue, StringComparison.CurrentCultureIgnoreCase));

                default:
                    return false;
            }
        }
    }
}
