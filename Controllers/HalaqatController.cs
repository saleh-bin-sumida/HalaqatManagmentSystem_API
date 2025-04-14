namespace HalaqatManagmentSystem_API.Controllers;

[ApiController]
public class HalaqatController(UnitOfWork _unitOfWork) : ControllerBase
{
    [HttpGet(SystemApiRouts.Halaqat.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllHalaqat(int pageSize = 10, int pageNumber = 1, string? searchTerm = null)
    {
        var response = await _unitOfWork.Halaqat.GetAllHalaqatAsync(pageSize, pageNumber, searchTerm);
        return Ok(response);
    }

    [HttpGet(SystemApiRouts.Halaqat.GetAllNames)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllHalaqatNames(int pageSize = 10, int pageNumber = 1, string? searchTerm = null)
    {
        var response = await _unitOfWork.Halaqat.GetAllHalaqatNamesAsync(pageSize, pageNumber, searchTerm);
        return Ok(response);
    }

    [HttpGet(SystemApiRouts.Halaqat.GetAllAssignedToTeacher)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllHalaqatAssignedToTeacher(Guid teacherId, int pageSize = 10, int pageNumber = 1, string? searchTerm = null)
    {
        var response = await _unitOfWork.Halaqat.GetAllHalaqatAssignedToTeacherAsync(teacherId, pageSize, pageNumber, searchTerm);
        return response.Success ? Ok(response) : NotFound(response.Message);
    }

    [HttpGet(SystemApiRouts.Halaqat.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetHalaqaById(int Id)
    {
        var response = await _unitOfWork.Halaqat.GetHalaqaByIdAsync(Id);
        return response.Success ? Ok(response) : NotFound(response.Message);
    }


    [HttpPut(SystemApiRouts.Halaqat.AddStudentToHalaqa)]
    public async Task<IActionResult> AddStudentToHalaqa(Guid StudentId, int HalaqaId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _unitOfWork.Halaqat.AddStudentToHalaqaAsync(StudentId, HalaqaId);
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPut(SystemApiRouts.Halaqat.AddStudentsToHalaqa)]
    public async Task<IActionResult> AddStudentsToHalaqa(List<Guid> Ids, int HalaqaId)
    {
        var response = await _unitOfWork.Halaqat.AddStudentsToHalaqaAsync(Ids, HalaqaId);
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }



    [HttpPut(SystemApiRouts.Students.DeleteStudentFromHalaqa)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteStudentFromHalaqa(Guid Id)
    {
        var response = await _unitOfWork.Halaqat.DeleteStudentFromHalaqa(Id);
        return response.Success ? Ok(response) : NotFound(response);
    }


    [HttpPost(SystemApiRouts.Halaqat.Add)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddHalaqa(AddHalaqaDto halaqaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _unitOfWork.Halaqat.AddHalaqaAsync(halaqaDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPatch(SystemApiRouts.Halaqat.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateHalaqa(int Id, UpdateHalaqaDto halaqaDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _unitOfWork.Halaqat.UpdateHalaqaAsync(Id, halaqaDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete(SystemApiRouts.Halaqat.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteHalaqa(int Id)
    {
        var response = await _unitOfWork.Halaqat.DeleteHalaqaAsync(Id);
        return response.Success ? Ok(response) : NotFound(response);
    }


}
