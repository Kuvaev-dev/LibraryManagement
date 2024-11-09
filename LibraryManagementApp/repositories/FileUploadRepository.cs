using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace LibraryManagementApp.repositories
{
    public interface IFileUploadRepository
    {
        string SaveUploadedFile(FileUpload fileUpload, string folderPath);
    }

    public class FileUploadRepository : IFileUploadRepository
    {
        public string SaveUploadedFile(FileUpload fileUpload, string folderPath)
        {
            try
            {
                if (!fileUpload.HasFile)
                    return "~/book_inventory/book1.png";

                string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                string serverPath = HttpContext.Current.Server.MapPath(folderPath + fileName);

                fileUpload.SaveAs(serverPath);

                return folderPath + fileName;
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving file: " + ex.Message);
            }
        }
    }
}