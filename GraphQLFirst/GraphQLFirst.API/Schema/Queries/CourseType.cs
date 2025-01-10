using GraphQLFirst.API.DTOs;
using GraphQLFirst.API.Models;

namespace GraphQLFirst.API.Schema.Queries
{


    public class CourseType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Subject Subject { get; set; }

        public Guid InstructorID { get; set; }

        public InstructorType Instructor { get; set; }

        public IEnumerable<StudentType> Students { get; set; }
    }
}
