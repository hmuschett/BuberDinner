namespace buberDinner.Infrastructure.Authentication;
public class JwtSettings
{
    public const string SectionName="JwtSettings";
    public string Secret {get; set;} = null!;
    public int ExpiresMinutes {get; set;}
    public string Issuer {get; set;} = null!;
    public string Audience {get; set;} = null!;
}