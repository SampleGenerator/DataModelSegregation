using Application.Dtos;
using Application.Utility.Mapping;
using DataModels;
using LogicalModels.UserAggregate.Data;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppMapper _mapper;

        public UserController(ILogger<UserController> logger,
            IUserRepository userRepository, IUnitOfWork unitOfWork,
            IAppMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var users = await _userRepository.Get(ct);

            var dtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(dtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            var user = await _userRepository.GetById(id, ct);

            var rs = _mapper.Map<UserDto>(user);

            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto dto, CancellationToken ct)
        {
            var user = LogicalModels.UserAggregate.Entities.User.Create(dto.Fullname, dto.Email);
            var userCreated = await _userRepository.Insert(user, ct);
            await _unitOfWork.SaveChanges(ct);

            var rs = _mapper.Map<UserDto>(userCreated);

            return Ok(rs);
        }
    }
}