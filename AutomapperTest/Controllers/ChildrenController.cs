using AutoMapper;
using AutomapperTest.Dto;
using AutomapperTest.Entity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomapperTest.Controllers
{
    [Route("api/children")]
    [ApiController]
    public class ChildrenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ChildrenController(ApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IList<ChildToDisplayDto>>> GetAllChildren()
        {
            var child = await _context.Children.ToListAsync();

            var childDto = _mapper.Map<IList<ChildToDisplayDto>>(child);

            return Ok(childDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ChildToDisplayDto>> GetChildById(int id)
        {
            var child = await _context.Children.FirstOrDefaultAsync(x => x.Id == id);

            var childDto = _mapper.Map<ChildToDisplayDto>(child);

            return Ok(childDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateChild(ChildCreationDto childCreationDto)
        {
            var child = _mapper.Map<Child>(childCreationDto);
            _context.Add(child);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateChild(int id, ChildCreationDto ChildCreationDto)
        {
            var Child = await _context.Children
                .SingleOrDefaultAsync(x => x.Id == id);

            if (Child == null)
            {
                return NotFound();
            }
            _mapper.Map(ChildCreationDto, Child);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}