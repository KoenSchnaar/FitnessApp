using FitnessApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.FileTransfers
{
    public class Upload
    {
        public ExerciseModel UploadPicture(ExerciseModel exerciseMdl)
        {
            if (exerciseMdl.ImageUpload != null)
            {
                var dateTime = DateTime.Now.ToString("yymmssffff");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\ExercisePictures", dateTime + exerciseMdl.ImageUpload.FileName);
                exerciseMdl.ImagePath = @"..\..\Images\ExercisePictures\" + dateTime + exerciseMdl.ImageUpload.FileName;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    exerciseMdl.ImageUpload.CopyTo(stream);
                }
                return exerciseMdl;
            }
            return null;
        }
    }
}
