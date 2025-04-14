namespace HalaqatManagmentSystem_API.Enums;

public enum MaritalStatus
{
    [Display(Name = "غير معروف")]
    Unknown,

    [Display(Name = "أعزب")]
    Single,

    [Display(Name = "متزوج")]
    Married,

    //[Display(Name = "أرملة")]
    //Widowed
}
