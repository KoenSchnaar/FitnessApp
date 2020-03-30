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
        public Upload()
        {

        }

        public ExerciseModel UploadPicture(ExerciseModel exerciseMdl)
        {
            if (exerciseMdl.ImageUpload != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\ExercisePictures", exerciseMdl.ImageUpload.FileName);
                exerciseMdl.ImagePath = @"..\..\Images\ExercisePictures\" + exerciseMdl.ImageUpload.FileName;

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
