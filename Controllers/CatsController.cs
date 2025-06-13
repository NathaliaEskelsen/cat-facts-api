using System.Reflection.Metadata;
using AutoMapper;
using Azure;
using CatFacts.Models;
using CatFacts.Data;
using CatFacts.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CatFacts.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatRepo _repository;
        private readonly IMapper _mapper;

        public CatsController(ICatRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Cat>> GetAllCats()
        {
            var cat = _repository.GetAllCats();
            return Ok(_mapper.Map<IEnumerable<CatReadDto>>(cat));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCatById")]
        public ActionResult<CatReadDto> GetCatById(int id)
        {
            var cat = _repository.GetCatById(id);
            if (cat != null)
            {
                return Ok(_mapper.Map<CatReadDto>(cat));
            }
            return NotFound();
        }


        //POST api/commands
        [HttpPost]
        public ActionResult<CatReadDto> CreateCat(CatCreateDto catCreateDto)
        {
            var catModel = _mapper.Map<Cat>(catCreateDto);
            _repository.CreateCat(catModel);
            _repository.SaveChanges();

            var catReadDto = _mapper.Map<CatReadDto>(catModel);
            return CreatedAtRoute(nameof(GetCatById), new { Id = catReadDto.Id }, catReadDto);

        }

        //PUT api/command/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCat(int id, CatUpdateDto catUpdateDto)
        {
            var catModelFromRepo = _repository.GetCatById(id);

            if (catModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(catUpdateDto, catModelFromRepo);

            _repository.UpdateCat(catModelFromRepo);

            _repository.SaveChanges();

            return NoContent();


        }




        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCatUpdate(int id, JsonPatchDocument<CatUpdateDto> patchDoc)
        {
            var catModelFromRepo = _repository.GetCatById(id);

            if (catModelFromRepo == null)
            {
                return NotFound();
            }

            var catToPatch = _mapper.Map<CatUpdateDto>(catModelFromRepo);

            patchDoc.ApplyTo(catToPatch, ModelState);

            if (!TryValidateModel(catToPatch))
            {
                return ValidationProblem(ModelState);
            }


            _mapper.Map(catToPatch, catModelFromRepo);

            _repository.UpdateCat(catModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }


        //DELETE api/command/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCat(int id)
        {
            var catModelFromRepo = _repository.GetCatById(id);
            if (catModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCat(catModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}