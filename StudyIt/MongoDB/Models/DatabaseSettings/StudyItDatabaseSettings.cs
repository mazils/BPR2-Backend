namespace StudyIt.MongoDB.Models;

public class StudyItDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollectionName { get; set; } = null!;
    public string UserCollection { get; set; } = null!;
    public string ProjectGroupCollection { get; set; } = null!;
    public string CompanyCollection { get; set; } = null!;
    public string PostCollection { get; set; } = null!;
    
    
    public string DefaultUserImage { get; set; } = null!;
    public string DefaultPersonalityProfile { get; set; } = null!;
    public string DefaultCompanyLogo { get; set; } = null!;
}