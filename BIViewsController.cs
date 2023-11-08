//using Microsoft.AspNetCore.Mvc;
//using MNSBI.Core.Entities;
//using MNSBI2.Data.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace MNSBI2.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BIViewsController : ControllerBase
//    {
//        private readonly IBIViewRepository _biViewRepository;

//        public BIViewsController(IBIViewRepository biViewRepository)
//        {
//            _biViewRepository = biViewRepository;
//        }

//        // GET: api/BIViews
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<BIView>>> GetAllBIViews()
//        {
//            var biViews = await _biViewRepository.GetAllAsync();
//            return Ok(biViews);
//        }

//        // GET: api/BIViews/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<BIView>> GetBIViewById(Guid id)
//        {
//            var biView = await _biViewRepository.GetByIdAsync(id);
//            if (biView == null)
//            {
//                return NotFound();
//            }
//            return Ok(biView);
//        }

//        // POST: api/BIViews
//        [HttpPost]
//        public async Task<ActionResult<BIView>> CreateBIView([FromBody] BIView biView)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var createdBiView = await _biViewRepository.AddAsync(biView);
//            return CreatedAtAction(nameof(GetBIViewById), new { id = createdBiView.Id }, createdBiView);
//        }

//        // PUT: api/BIViews/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateBIView(Guid id, [FromBody] BIView biView)
//        {
//            if (id != biView.Id)
//            {
//                return BadRequest("ID mismatch");
//            }

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            await _biViewRepository.UpdateAsync(biView);
//            return NoContent();
//        }

//        // DELETE: api/BIViews/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteBIView(Guid id)
//        {
//            var biView = await _biViewRepository.GetByIdAsync(id);
//            if (biView == null)
//            {
//                return NotFound();
//            }

//            await _biViewRepository.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}







using Microsoft.AspNetCore.Mvc;
using MNSBI2.Core.Models;
using MNSBI2.Data.Repositories;

[Route("api/[controller]")]
[ApiController]
public class BIViewsController : ControllerBase
{
    private readonly IBIViewRepository _biViewRepository;
    private readonly ILogger<BIViewsController> _logger; // Logging

    // Inject the IBIViewRepository and ILogger into the constructor
    public BIViewsController(IBIViewRepository biViewRepository, ILogger<BIViewsController> logger)
    {
        _biViewRepository = biViewRepository;
        _logger = logger;
    }

    // GET: api/BIViews
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BIView>>> GetAllBIViews()
    {
        try
        {
            var biViews = await _biViewRepository.GetAllAsync();
            return Ok(biViews);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all BIViews");
            return StatusCode(500, "An error occurred while retrieving the views");
        }
    }

    // GET: api/BIViews/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<BIView>> GetBIViewById(Guid id)
    {
        try
        {
            var biView = await _biViewRepository.GetByIdAsync(id);
            if (biView == null)
            {
                return NotFound();
            }
            return Ok(biView);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting BIView with ID: {BIViewId}", id);
            return StatusCode(500, "An error occurred while retrieving the view");
        }
    }

    // POST: api/BIViews
    [HttpPost]
    public async Task<ActionResult<BIView>> CreateBIView([FromBody] BIView biView)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            _logger.LogWarning("Invalid model state: {@ModelStateErrors}", errors);
            return BadRequest(new { Message = "Invalid model state", Details = errors });
        }

        // Controleer of het ID-veld leeg is
        if (biView.Id == Guid.Empty)
        {
            // Genereer een nieuw GUID (ID)
            biView.Id = Guid.NewGuid();
        }

        try
        {
            var createdBiView = await _biViewRepository.AddAsync(biView);
            return CreatedAtAction(nameof(GetBIViewById), new { id = createdBiView.Id }, createdBiView);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating BIView: {@BIView}", biView);
            return StatusCode(500, "An error occurred while creating the view");
        }
    }


    // PUT: api/BIViews/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBIView(Guid id, [FromBody] BIView biView)
    {
        if (id != biView.Id)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _biViewRepository.UpdateAsync(biView);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating BIView with ID: {BIViewId}", id);
            return StatusCode(500, "An error occurred while updating the view");
        }
    }

    // DELETE: api/BIViews/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBIView(Guid id)
    {
        try
        {
            var biView = await _biViewRepository.GetByIdAsync(id);
            if (biView == null)
            {
                return NotFound();
            }

            await _biViewRepository.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting BIView with ID: {BIViewId}", id);
            return StatusCode(500, "An error occurred while deleting the view");
        }
    }
}