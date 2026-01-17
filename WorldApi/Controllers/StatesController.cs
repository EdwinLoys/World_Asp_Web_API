using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorldApi.DTO.States;
using WorldApi.Models;
using WorldApi.Repository.IRepository;

namespace WorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private readonly IStatesRepository _statesRepository;
        private readonly IMapper _mapper;

        public StatesController(IStatesRepository statesRepository, IMapper mapper)
        {
            _statesRepository = statesRepository;
            _mapper = mapper;
        }

        //Get: api/States

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StatesDTO>>> GetAll()
        {
            var countries = await _statesRepository.GetAll();

            var countriesDTO = _mapper.Map<List<StatesDTO>>(countries);


            if (countries == null)
            {
                return NoContent();
            }
            return Ok(countriesDTO);
        }

        //Get: api/States/id = 1

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<StatesDTO>> GetById(int id)
        {
            var states = await _statesRepository.GetById(id);
            var statesDTO = _mapper.Map<StatesDTO>(states);

            if (states == null)
            {
                return Conflict($"State with id {id} not found.");
            }
            var stateDTO = _mapper.Map<StatesDTO>(states);
            return CreatedAtAction("GetById", new { id = states.Id }, states);
        }

        //Post: api/States
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<StatesDTO>> Create([FromBody] CreateStatesDTO statesDTO)
        {
            var result = _statesRepository.IsStateExsits(statesDTO.Name);
            if (result)
            {
                return Conflict($"State with name {statesDTO.Name} already exists.");
            }

            var states = _mapper.Map<States>(statesDTO);
            await _statesRepository.Create(states);
            return CreatedAtAction("GetById", new { id = states.Id }, states);

        }

        //Put: api/States/id=1
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Update(int id, [FromBody] UpdateStatesDTO statesDTO)
        {
            var states = await _statesRepository.GetById(id);

            var stateDTO = _mapper.Map<StatesDTO>(states);

            if (states == null)
            {
                return NoContent();
            }

            await _statesRepository.Update(states);
            return NoContent();

        }

        //Delete: api/States/id=1
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteById(int id)
        {

            if (id == 0)
            {
                return BadRequest();   
            }

            var states = await _statesRepository.GetById(id);
            if (states == null)
            {
                return NotFound();
            }

            await _statesRepository.Delete(states);
            return NoContent();
        }

    }
}