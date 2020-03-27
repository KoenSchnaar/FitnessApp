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
            if(exerciseMdl.ImageUpload != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(exerciseMdl.ImageUpload.FileName);
                var extension = Path.GetExtension(exerciseMdl.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                exerciseMdl.ImagePath = @"..\..\Images\ExercisePictures\" + fileName;
                exerciseMdl.ImageUpload.SaveAs(Path.Combine(Server.MapPath(@"..\..\Images\ExercisePictures\"), fileName));
                return exerciseMdl;
            }
            return null;
        }
    }
}
