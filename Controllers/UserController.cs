using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Interfaces;
using SimpleApi.Models.Dto;
using SimpleApi.Models.Entities;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISimpleApiService _simpleApiService;
        private readonly IMapper _mapper;

        public UserController(ISimpleApiService simpleApiService, IMapper mapper)
        {
            _simpleApiService = simpleApiService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto user, CancellationToken cancellationToken)
        {
            try
            {
                var userEntity = _mapper.Map<UserEntity>(user);
                await _simpleApiService.CreateAsync(userEntity, cancellationToken);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserAsync([FromRoute] int userId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _simpleApiService.GetAsync(userId, cancellationToken));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int userId, CancellationToken cancellationToken)
        {
            try
            {
                await _simpleApiService.DeleteAsync(userId, cancellationToken);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int userId, [FromBody] UpdateUserDto user, CancellationToken cancellationToken)
        {
            try
            {
                var userEntity = _mapper.Map<UserEntity>(user);
                await _simpleApiService.UpdateAsync(userId, userEntity, cancellationToken);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
