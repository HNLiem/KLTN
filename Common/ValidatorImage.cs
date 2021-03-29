using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

public static class ValidatorImage
{
    
    public static bool CheckImage(IFormFile formFile)
    {
        List<string> imgTypes = new List<string> { "image/png", "image/jpg", "image/jpeg" };
        string type = formFile.ContentType;
        return imgTypes.Any(img => img == type);
    }
}