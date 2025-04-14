namespace HalaqatManagmentSystem_API.Controllers;

[ApiController]
public class GuardiansController(UnitOfWork _unitOfWork) : ControllerBase
{


    /// <summary>
    /// Gets all guardians.
    /// </summary>
    /// <returns>A list of all guardians.</returns>
    [HttpGet]
    [Route(SystemApiRouts.Guardians.GetAll)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetGuardianDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllGuardians(int pageSize = 10, int pageNumber = 1, string? searchTerm = null, bool? gender = null)
    {
        var response = await _unitOfWork.Guardians.GetAllGuardiansAsync(pageSize, pageNumber, searchTerm, gender);
        if (response.Success)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Gets all guardians names.
    /// </summary>
    /// <returns>A list of all guardians.</returns>
    [HttpGet(SystemApiRouts.Guardians.GetAllNames)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetGuardianNameDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllGuardiansNames(int pageSize = 10, int pageNumber = 1)
    {
        var response = await _unitOfWork.Guardians.GetAllGuardiansNamesAsync(pageSize, pageNumber);
        if (response.Success)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Gets a guardian by ID.
    /// </summary>
    /// <param name="Id">The ID of the guardian.</param>
    /// <returns>The guardian with the specified ID.</returns>
    [HttpGet(SystemApiRouts.Guardians.GetById)]
    [ProducesResponseType(typeof(BaseResponse<GetGuardianDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGuardianById(Guid Id)
    {
        var response = await _unitOfWork.Guardians.GetGuardianByIdAsync(Id);
        if (response.Success)
        {
            return Ok(response);
        }
        return NotFound(response);
    }

    /// <summary>
    /// Gets full information of a guardian by ID.
    /// </summary>
    /// <param name="Id">The ID of the guardian.</param>
    /// <returns>The full information of the guardian with the specified ID.</returns>
    [HttpGet(SystemApiRouts.Guardians.GetFullInfoById)]
    [ProducesResponseType(typeof(BaseResponse<GetGuardianFullInfoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGuardianFullInfoById(Guid Id)
    {
        var response = await _unitOfWork.Guardians.GetGuardianFullInfoByIdAsync(Id);
        if (response.Success)
        {
            return Ok(response);
        }
        return NotFound(response);
    }

    /// <summary>
    /// Adds a new guardian.
    /// </summary>
    /// <param name="guardianDto">The guardian details.</param>
    /// <returns>The added guardian.</returns>
    [HttpPost(SystemApiRouts.Guardians.Add)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddGuardian(AddGuardianDto guardianDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new BaseResponse<string>
            {
                Success = false,
                Message = "Invalid model state",
                Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
            });
        }

        var response = await _unitOfWork.Guardians.AddGuardianAsync(guardianDto);
        return response.Success ? Ok(response) : BadRequest(response);

    }

    /// <summary>
    /// Updates an existing guardian.
    /// </summary>
    /// <param name="Id">The guardian Id update.</param>
    /// <param name="guardianDto">The guardian details to update.</param>
    /// <returns>The updated guardian.</returns>
    [HttpPut(SystemApiRouts.Guardians.Update)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGuardian(Guid Id, UpdateGuardianDto guardianDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new BaseResponse<string>
            {
                Success = false,
                Message = "Invalid model state",
                Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
            });
        }

        var response = await _unitOfWork.Guardians.UpdateGuardianAsync(Id, guardianDto);
        if (response.Success)
        {
            return Ok(response);
        }
        return NotFound(response);
    }

    /// <summary>
    /// Deletes a guardian by ID.
    /// </summary>
    /// <param name="Id">The ID of the guardian to delete.</param>
    /// <returns>Confirmation message.</returns>
    [HttpDelete(SystemApiRouts.Guardians.Delete)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteGuardian(Guid Id)
    {
        var response = await _unitOfWork.Guardians.DeleteGuardianAsync(Id);
        if (response.Success)
        {
            return Ok(response);
        }
        return NotFound(response);
    }

    /// <summary>
    /// Deletes a range of guardians by their IDs.
    /// </summary>
    /// <param name="Ids">The IDs of the guardians to delete.</param>
    /// <returns>Confirmation message.</returns>
    [HttpDelete(SystemApiRouts.Guardians.DeleteRange)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteRangeGuardians([FromBody] List<Guid> Ids)
    {
        var response = await _unitOfWork.Guardians.DeleteRangeGuardiansAsync(Ids);
        if (response.Success)
        {
            return Ok(response);
        }
        return NotFound(response);
    }
}

