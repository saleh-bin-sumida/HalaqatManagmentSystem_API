using HalaqatManagmentSystem_API.Attributes;

namespace HalaqatManagmentSystem_API.Enums;

public enum AttendanceStatus
{
    [AttendanceValue(0)]
    [Display(Name = "غائب بدون عذر")]
    absent = 0,


    [AttendanceValue(0.25)]
    [Display(Name = "غائب بعذر")]
    absentWithExcuse,


    [AttendanceValue(0.5)]
    [Display(Name = "متأخر بدون عذر")]
    lateWithoutExcuse,


    [AttendanceValue(0.75)]
    [Display(Name = "متأخر بعذر ")]
    lateWithExcuse,


    [AttendanceValue(1)]
    [Display(Name = "حاضر")]
    present,

}


