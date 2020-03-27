using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FitnessApp.Models
{
    public class ExerciseModel
    {
        public int ExerciseId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Discription { get; set; }

        [Required]
        public string MuscleGroup { get; set; }
        [DisplayName("Image")]
        public string ImagePath { get; set; }
        public int NrOfSets { get; set; }
        public List<SetModel> Sets { get; set; }
        //[NotMapped]
        public IFormFile ImageUpload { get; set; }


        public ExerciseModel()
        {
            ImagePath = @"..\..\Images\ExercisePictures\Default.png";
        }
    }
}
