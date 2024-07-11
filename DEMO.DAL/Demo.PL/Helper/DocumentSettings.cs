namespace Demo.PL.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string floderName)
        {


            var floderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", floderName);

            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            var filePath = Path.Combine(floderPath, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            return fileName;

        }


    }
}
