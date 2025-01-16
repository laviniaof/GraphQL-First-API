using GraphQLFirst.API.DTOs;
using GraphQLFirst.API.Schema.Subscriptions;
using GraphQLFirst.API.Services.Courses;
using HotChocolate.Execution.Processing;
using HotChocolate.Subscriptions;

namespace GraphQLFirst.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;

        public Mutation(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }


        public async Task<CourseResult> CreateCourse(CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            courseDTO = await _coursesRepository.Create(courseDTO);

            CourseResult course = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                InstructorId = courseDTO.InstructorId,

            };

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course); ;

            return course;
        }

        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Id = id,
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            courseDTO = await _coursesRepository.Update(courseDTO);

            CourseResult course= new CourseResult()
            {
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            string updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updateCourseTopic, course);

            return course;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            return await _coursesRepository.Delete(id);
        }
    }
}
