
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Dtos;
using AutoMapper;
using API.errors;

namespace API.Controllers
{
    public class CarsController : BaseApiController
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CarsController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarsToReturnDto>>> GetCars()
        {
            var cars = await _context.ModelYears
            .Include(s => s.Makes)
            .ToListAsync();

            return Ok(_mapper.Map<List<CarsToReturnDto>>(cars));
        }

        [HttpPost]
        public async Task<ActionResult> InsertCars([FromBody] CarsToInsertDto carsDto)
        {
            try
            {
                var entity = await _context.ModelYears.Where(s => s.Name == carsDto.Name && s.Year == carsDto.Year && s.Makes.Name == carsDto.Make).ToListAsync();

                if (entity.Count > 0) return BadRequest(new ApiResponse(403, "Car Already Exists"));

                var make = await RetrieveMake(carsDto);

                if (make == null)  make = CreateMake(carsDto);

                await _context.SaveChangesAsync();

                var model = CreateModel(carsDto, make);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse(400, ex.Message));
            }

        }

        private ModelYear CreateModel(CarsToInsertDto carsDto, Make make)
        {
            var model = new ModelYear { Name = carsDto.Name, Year = carsDto.Year, MakeId = make.Id };
            _context.ModelYears.Add(model);
            return model;
        }

        private Make CreateMake(CarsToInsertDto carsDto)
        {
            var make = new Make {Name = carsDto.Make,};
            _context.Makes.Add(make);

            return make;        
        }

        private async Task<Make> RetrieveMake(CarsToInsertDto carsDto)
        {
            return await _context.Makes.FirstOrDefaultAsync(X => X.Name == carsDto.Make);
        }
    }
}