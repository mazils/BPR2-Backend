using System.Collections.Generic;

namespace StudyIt.MongoDB.Models;

public class AllCompanyPosts
{
    public IEnumerable<Post> data { get; set; }
}