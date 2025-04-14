namespace HalaqatSchoolSystetem.Web.Controllers;

[ApiController]
public class StudentsController(UnitOfWork _unitOfWork) : ControllerBase
{
    /// <summary>
    /// جلب جميع الطلاب
    /// </summary>
    /// <returns>جميع الطلاب</returns>
    [HttpGet(SystemApiRouts.Students.GetAll)]
    public async Task<IActionResult> GetAllStudents(
        int pageSize = 10,
        int pageNumber = 1,
        string? searchTerm = null,
        int? halaqaId = null,
        SchoolGrade? schoolGrade = null,
        //IEnumerable<int>? yearsOfBirth = null,
        bool? gender = null)
    {
        var response = await _unitOfWork.Students.GetAllStudentsAsync(pageSize, pageNumber, searchTerm, halaqaId, schoolGrade, gender);
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }


    /// <summary>
    /// جلب جميع الطلاب غير المرتبطين ب حلقة
    /// </summary>
    /// <returns>جميع الطلاب</returns>
    [HttpGet(SystemApiRouts.Students.GetStudentsNamesNotLinkedToHalaqa)]
    public async Task<IActionResult> GetStudentsNamesNotLinkedToHalaqaAsync()
    {
        var response = await _unitOfWork.Students.GetStudentsNamesNotLinkedToHalaqaAsync();
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }



    /// <summary>
    /// جلب جميع الطلاب المرتبطين بالحلقة المحددة
    /// </summary>
    /// <param name="HalaqaId">رقم معرف الحلقة</param>
    /// <returns>جميع الطلاب المرتبطين بالحلقة المحددة</returns>
    [HttpGet(SystemApiRouts.Students.GetByHalaqa)]
    public async Task<IActionResult> GetAllStudentsByHalaqa(int HalaqaId, string? searchTerm = null)
    {
        var response = await _unitOfWork.Students.GetStudentsByHalaqaAsync(HalaqaId, searchTerm);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }



    /// <summary>
    /// جلب بيانات طالب بناء على الرقم المعرفي
    /// </summary>
    /// <param name="Id">رقم معرف الطالب</param>
    /// <returns>بيانات الطالب</returns>
    [HttpGet(SystemApiRouts.Students.GetById)]
    public async Task<IActionResult> GetStudentById(Guid Id)
    {
        var response = await _unitOfWork.Students.GetStudentByIdAsync(Id);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    /// <summary>
    /// جلب جميع بيانات طالب بناء على الرقم المعرفي
    /// </summary>
    /// <param name="Id">رقم معرف الطالب</param>
    /// <returns>بيانات الطالب</returns>
    [HttpGet(SystemApiRouts.Students.GetFullInfoById)]
    public async Task<IActionResult> GetStudentFullInfoById(Guid Id)
    {
        var response = await _unitOfWork.Students.GetStudentFullInfoByIdAsync(Id);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[HttpGet(SystemApiRouts.Students.GetAllEnrollments)]
    //public async Task<IActionResult> GetAllEnrollmentsForStudent([FromRoute] Guid id)
    //{
    //    var response = await _unitOfWork.Students.GetAllEnrollmentsForStudent(id);
    //    if (!response.Success)
    //        return NotFound(response);

    //    return Ok(response);
    //}

    /// <summary>
    /// إنشاء طالب
    /// </summary>
    /// <param name="StudentDto">بيانات الطالب الجديدة</param>
    /// <returns>الطالب الذي تم إنشاؤه</returns>
    [HttpPost(SystemApiRouts.Students.Add)]
    public async Task<IActionResult> AddStudent([FromBody] AddStudentDto StudentDto)
    {

        var response = await _unitOfWork.Students.AddStudentAsync(StudentDto);
        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }


    /// <summary>
    /// تعديل بيانات طالب
    /// </summary>
    /// <param name="StudentDto">بيانات الطالب المعدلة</param>
    /// <returns>الطالب الذي تم تحديثه</returns>
    [HttpPut(SystemApiRouts.Students.Update)]
    public async Task<IActionResult> UpdateStudent(Guid Id, [FromBody] UpdateStudentDto StudentDto)
    {

        var response = await _unitOfWork.Students.UpdateStudentAsync(Id, StudentDto);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    /// <summary>
    /// حذف طالب
    /// </summary>
    /// <param name="Id">رقم معرف الطالب</param>
    /// <returns>نتيجة عملية الحذف</returns>
    [HttpDelete(SystemApiRouts.Students.Delete)]
    public async Task<IActionResult> DeleteStudent(Guid Id)
    {
        var response = await _unitOfWork.Students.DeleteStudentAsync(Id);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }


    /// <summary>
    /// حذف مجموعة من الطلاب
    /// </summary>
    /// <param name="Ids">قائمة معرفات الطلاب</param>
    /// <returns>نتيجة عملية الحذف</returns>
    [HttpDelete(SystemApiRouts.Students.DeleteRange)]
    public async Task<IActionResult> DeleteRangeStudents([FromBody] List<Guid> Ids)
    {
        var response = await _unitOfWork.Students.DeleteRangeStudentsAsync(Ids);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }
}

