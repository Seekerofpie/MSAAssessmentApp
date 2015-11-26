using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSAAssessmentApp.Models
{
    public enum Status
    {
        Ongoing, Upcoming, Completed
    }

    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int CourseID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int? Percentage { get; set; }
        public int? MyWeightedMark { get; set; }
        public Status CurrentStatus { get; set; }

        [JsonIgnore]
        public virtual Course course{ get; set; }

    }
}