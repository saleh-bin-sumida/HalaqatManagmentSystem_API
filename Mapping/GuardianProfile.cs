namespace HalaqatManagmentSystem_API.Mapping;

public static class GuardianProfile
{
    public static Expression<Func<Guardian, GetGuardianNameDto>> ToGetGuardianNameDto()
    {
        return guardian => new GetGuardianNameDto
        {
            Id = guardian.Id,
            FullName = guardian.FirstName + " " + guardian.LastName
        };
    }

    public static Expression<Func<Guardian, GetGuardianDto>> ToGetGuardianDto()
    {
        return guardian => new GetGuardianDto
        {
            Id = guardian.Id,
            FirstName = guardian.FirstName,
            LastName = guardian.LastName,
            Gender = guardian.Gender,
            Occupation = guardian.Occupation,
            PhoneNumber = guardian.PhoneNumber
        };
    }

    public static Expression<Func<Guardian, GetGuardianFullInfoDto>> ToGetGuardianFullInfoDto()
    {
        return guardian => new GetGuardianFullInfoDto
        {
            Id = guardian.Id,
            FirstName = guardian.FirstName,
            LastName = guardian.LastName,
            Gender = guardian.Gender,
            PhoneNumber = guardian.PhoneNumber,

            Occupation = guardian.Occupation,

            IdentityType = guardian.IdentityType,
            IdentityNumber = guardian.IdentityNumber,
            MaritalStatus = guardian.MaritalStatus,
        };
    }

    public static Guardian ToGuardian(this AddGuardianDto addGuardianDto)
    {
        var guardian = new Guardian
        {
            FirstName = addGuardianDto.FirstName,
            LastName = addGuardianDto.LastName,
            Gender = addGuardianDto.Gender,
            PhoneNumber = addGuardianDto.PhoneNumber,

            Occupation = addGuardianDto.Occupation,

            IdentityType = addGuardianDto.IdentityType,
            IdentityNumber = addGuardianDto.IdentityNumber,
            MaritalStatus = addGuardianDto.MaritalStatus,
        };

        return guardian;
    }

    public static void UpdateGuardian(this Guardian guardian, UpdateGuardianDto updateGuardianDto)
    {
        guardian.FirstName = updateGuardianDto.FirstName;
        guardian.LastName = updateGuardianDto.LastName;
        guardian.Gender = updateGuardianDto.Gender;
        guardian.PhoneNumber = updateGuardianDto.PhoneNumber;

        guardian.Occupation = updateGuardianDto.Occupation;

        guardian.IdentityType = updateGuardianDto.IdentityType;
        guardian.IdentityNumber = updateGuardianDto.IdentityNumber;
        guardian.MaritalStatus = updateGuardianDto.MaritalStatus;
    }
}
