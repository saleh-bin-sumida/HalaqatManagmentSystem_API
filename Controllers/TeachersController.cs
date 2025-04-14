namespace HalaqatSchoolSystetem.Web.Controllers;

[ApiController]
public class TeachersController(UnitOfWork _unitOfWork) : ControllerBase
{


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch(SystemApiRouts.Teachers.AssignTeacherToHalaqa)]
    public async Task<IActionResult> AssignTeacherToHalaqa(Guid TeacherId, int Halaqa_Id)
    {
        var response = await _unitOfWork.Teachers.AssignTeacherToHalaqa(TeacherId, Halaqa_Id);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(SystemApiRouts.Teachers.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllTeachers(int pageSize = 10, int pageNumber = 1, string? searchTerm = null)
    {
        var response = await _unitOfWork.Teachers.GetAllTeachersAsync(pageSize, pageNumber, searchTerm);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }


    [HttpGet(SystemApiRouts.Teachers.GetAllNames)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeachersNames(int pageSize = 10, int pageNumber = 1)
    {
        var response = await _unitOfWork.Teachers.GetTeachersNamesAsync(pageSize, pageNumber);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    //[HttpGet(SystemApiRouts.Teachers.GetAllTeachersInLevel)]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetAllTeachersInLevel(int levelId, int pageSize = 10, int pageNumber = 1, string? searchTerm = null)
    //{
    //    var response = await _unitOfWork.Teachers.GetAllTeachersInLevelAsync(levelId, pageSize, pageNumber, searchTerm);
    //    if (response.Success)
    //        return Ok(response);
    //    return NotFound(response);
    //}

    [HttpGet(SystemApiRouts.Teachers.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTeacherById(Guid Id)
    {
        var response = await _unitOfWork.Teachers.GetTeacherByIdAsync(Id);
        if (response is null)
            return NotFound("No teacher found with that Id");

        return Ok(response);
    }

    [HttpGet(SystemApiRouts.Teachers.GetFullInfoById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTeacherFullInfoById(Guid Id)
    {
        var response = await _unitOfWork.Teachers.GetTeacherFullInfoByIdAsync(Id);
        if (response is null)
            return NotFound("No teacher found with that Id");

        return Ok(response);
    }

    [HttpPost(SystemApiRouts.Teachers.Add)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddTeacher(AddTeacherDto teacherDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _unitOfWork.Teachers.AddTeacherAsync(teacherDto);
        if (response.Success)
            return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(SystemApiRouts.Teachers.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTeacher(Guid Id, UpdateTeacherDto teacherDto)
    {
        var response = await _unitOfWork.Teachers.UpdateTeacherAsync(Id, teacherDto);
        if (response.Success)
            return Ok(response);
        return NotFound(response);
    }

    [HttpDelete(SystemApiRouts.Teachers.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTeacher(Guid Id)
    {
        var response = await _unitOfWork.Teachers.DeleteTeacherAsync(Id);
        if (response.Success)
            return Ok($"Teacher with ID [{Id}] deleted.");
        return NotFound(response);
    }


    [HttpDelete(SystemApiRouts.Teachers.DeleteRange)]
    public async Task<IActionResult> DeleteRangeTeachers([FromBody] List<Guid> Ids)
    {
        var response = await _unitOfWork.Teachers.DeleteRangeTeachersAsync(Ids);
        if (response.Success)
            return Ok(response);
        return NotFound(response);
    }
}
