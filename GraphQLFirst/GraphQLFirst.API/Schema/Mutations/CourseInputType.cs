using GraphQLFirst.API.Models;
using GraphQLFirst.API.Schema.Queries;

namespace GraphQLFirst.API.Schema.Mutations
{
    public class CourseInputType
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
