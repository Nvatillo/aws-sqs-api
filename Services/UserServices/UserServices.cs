using System.Security.Claims;

namespace aws_sqs_api.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private IHttpContextAccessor _HttpContextAccessor;

        public UserServices(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }


        public string GetMyName()
        {
            var result = string.Empty;
            if (_HttpContextAccessor.HttpContext != null)
            {
                result = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                return result;
            }
            return result;
        }
    }
}
