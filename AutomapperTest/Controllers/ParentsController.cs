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
    [Route("api/parents")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ParentsController(ApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<List<ParentToDisplayDto>>> GetAllParents()
        {
            var parents = await _context.Parents
                .Include(x => x.Children)
                .ToListAsync();

            var parentsDto = _mapper.Map<IEnumerable<ParentToDisplayDto>>(parents);

            return Ok(parentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetParentById(int id)
        {
            var parent = await _context.Parents
                .Include(x => x.Children)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (parent == null)
            {
                return NotFound();
            }

            var parentDto = _mapper.Map<ParentToDisplayDto>(parent);

            return Ok(parentDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateParent(ParentCreationDto parentCreationDto)
        {
            var parent = _mapper.Map<Parent>(parentCreationDto);
            _context.Add(parent);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateParent(int id, ParentForUpdateDto parentForUpdateDto)
        {
            var parent = await _context.Parents
                .Include(x => x.Children)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (parent == null)
            {
                return NotFound();
            }
            _mapper.Map(parentForUpdateDto, parent);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}