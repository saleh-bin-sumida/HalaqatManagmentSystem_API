namespace HalaqatManagmentSystem_API.Enums
{
    public enum IdentityType
    {
        [Display(Name = "لايوجد")]
        None = 0,

        [Display(Name = "بطاقة هوية شخصيه")]
        PersonalIdentityCard = 1,

        [Display(Name = "جواز سفر")]
        Passport = 2,

        [Display(Name = "شهادة ميلاد")]
        BirthCertificate = 3,
    }
}
