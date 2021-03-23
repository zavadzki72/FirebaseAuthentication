using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        /// <summary>
        ///     Verificar se um usuario está autenticado
        /// </summary>
        /// <response code="204">Usuario está autenticado</response>
        /// <response code="401">Usuario não está autenticado</response>
        [HttpGet]
        [Authorize]
        [Route("IsAuth")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult IsAuth()
        {
            return NoContent();
        }

        /// <summary>
        ///     Pega a informação de um usuario a partir do Token dele
        /// </summary>
        /// <response code="200">Usuario está autenticado</response>
        /// <response code="401">Usuario não está autenticado</response>
        [HttpGet]
        [Authorize]
        [Route("GetGoogleUserInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetGoogleUserInfo()
        {
            string firebaseJson = (User.Claims.FirstOrDefault(x => x.Type == "firebase") != null) ? User.Claims.FirstOrDefault(x => x.Type == "firebase").Value : string.Empty;
            string email = string.Empty;

            if (!string.IsNullOrEmpty(firebaseJson))
            {
                var regexMatch = Regex.Match(firebaseJson, "email.{4}(?<email>.*?\\\")");
                email = regexMatch.Groups["email"].Value.Replace("\"", "");
            }

            return Ok(new
            {
                Id = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value,
                Name = User.Claims.FirstOrDefault(x => x.Type == "name")?.Value,
                Picture = User.Claims.FirstOrDefault(x => x.Type == "picture")?.Value,
                Email = email
            });
        }

    }
}
