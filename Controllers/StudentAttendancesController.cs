namespace HalaqatManagmentSystem_API.Server.Controllers;

[ApiController]
public class StudentAttendancesController(UnitOfWork _unitOfWork) : ControllerBase
{
    /// <summary>
    /// Retrieves attendance records by Halaqa ID and date.
    /// </summary>
    /// <param name="halaqaId">The ID of the Halaqa.</param>
    /// <param name="date">The date for attendance.</param>
    /// <returns>Attendance records for the Halaqa.</returns>
    /// <response code="200">Returns the attendance records for the Halaqa.</response>
    /// <response code="404">If the Halaqa is not found.</response>
    [HttpGet(SystemApiRouts.StudentAttendances.GetByHalaqa)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAttendancesByHalaqa([FromQuery] int halaqaId, [FromQuery] DateOnly date)
    {
        var response = await _unitOfWork.StudentAttendances.GetAttendancesByHalaqaAsync(halaqaId, date);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    /// <summary>
    /// Records a new attendance or updates it if it exists for a student.
    /// </summary>
    /// <param name="attendancesDto">The attendance details.</param>
    /// <returns>The created or updated attendance record.</returns>
    /// <response code="201">Returns the newly created or updated attendance record.</response>
    /// <response code="400">If the model state is invalid.</response>
    /// <response code="404">If the student is not found.</response>
    [HttpPost(SystemApiRouts.StudentAttendances.AddOrUpdate)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddOrUpdateAttendances(List<AddUpdatedAttendanceDto> attendancesDto)
    {

        var response = await _unitOfWork.StudentAttendances.AddOrUpdateAttendancesAsync(attendancesDto);
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    /// <summary>
    /// Deletes attendances for a specific day by IDs.
    /// </summary>
    /// <param name="Ids">The IDs of the attendance records to delete.</param>
    /// <returns>A confirmation message.</returns>
    /// <response code="204">If the attendance records are deleted successfully.</response>
    /// <response code="404">If the attendance records are not found.</response>
    [HttpDelete(SystemApiRouts.StudentAttendances.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAttendance([FromBody] List<int> Ids)
    {
        var response = await _unitOfWork.StudentAttendances.DeleteAttendanceAsync(Ids);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }
}


