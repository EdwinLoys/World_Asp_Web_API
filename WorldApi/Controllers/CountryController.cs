using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WorldApi.Data;
using WorldApi.DTO.Country;
using WorldApi.Models;
using WorldApi.Repository.IRepository;

namespace WorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        


        public CountryController(ICountryRepository countryRepository, IMapper mapping)
        {
            _countryRepository = countryRepository;
            _mapper = mapping;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAll()
        {
            var Countries = await _countryRepository.GetAll();

            var countriesDTO = _mapper.Map<List<CountryDTO>>(Countries);

            if (Countries == null)
            {
                return NotFound();
            }
            return Ok(countriesDTO);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryDTO>> GetById(int id)
        {
            var country = await _countryRepository.GetById(id);
            var CountryDTO = _mapper.Map<CountryDTO>(country);
            if (country == null)
            {
                return NoContent();
            }
            return (CountryDTO); 
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateCountryDTO>> Create([FromBody] CreateCountryDTO countryDTO)
        {
            var exists =  _countryRepository.IsCountryExist(countryDTO.Name);

            if (exists)
            {
                return Conflict("Country with the same name already exists.");
            }

            var country = _mapper.Map<Country>(countryDTO);
           await _countryRepository.Create(country);
            return CreatedAtAction("GetById ", new {id = country.Id},country);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Country>> Update(int id,[FromBody] UpdateCountryDto countryDto)
        {
            if(countryDto== null || id != countryDto.Id){
                return BadRequest();
            }

            

            var country = _mapper.Map<Country>(countryDto); // test

            await _countryRepository.Update(country);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var country = await _countryRepository.GetById(id);
            if (country == null)
            {
                return NoContent();
            }

            await _countryRepository.Delete(country);
            return NoContent();

        }

    }
}
