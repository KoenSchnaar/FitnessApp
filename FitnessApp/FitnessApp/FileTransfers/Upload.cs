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
        public string UploadPicture(ExerciseModel exerciseMdl)
        {
            if(exerciseMdl.ImageUpload != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(exerciseMdl.ImageUpload.FileName);
                var extension = Path.GetExtension(exerciseMdl.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                var exerciseMdl = @"..\..\Images\ExercisePictures\" + fileName;
            }
            return null;
        }
    }
}
