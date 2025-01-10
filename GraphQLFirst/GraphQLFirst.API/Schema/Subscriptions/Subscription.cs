using GraphQLFirst.API.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLFirst.API.Schema.Subscriptions
{
    
    /// <summary>
    /// In GraphQL, Subscriptions able clients to receive updated data in real time while changes happens on server.
    /// That´s why we set up WebSockers ai Startup.cs
    /// </summary>
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{courseId}_{nameof(Subscription.CourseUpdated)}";

            return topicEventReceiver.SubscribeAsync<CourseResult>(topicName);
        }
    }
}
