using Domain.Enums;
using Domain.MethodExtension;

namespace Domain.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; private set; } // Se asigna en EF DB
        public Guid? OwnerId { get; private set; }
        public Guid ProjectId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskStates Status { get; private set; }
        public DateTime? Expiration { get; private set; }


        //Includes
        public UserEntity? Owner { get; private set; }
        public ProjectEntity? Project { get; private set; }


        //Const
        private const short DescriptionLimit = 1500;
        private const short TitleLimit = 20;


        private TaskEntity() { }

        public TaskEntity(string Title, string Description, Guid? ProjectId, TaskPriority Priority, DateTime? Expiration)
        {
            Title.ThrowIfNullOrEmpty();
            Title.ThrowIfLimitExceeded(TitleLimit);

            Description.ThrowIfLimitExceeded(DescriptionLimit);

            Priority.ThrowIfUndefined();

            ProjectId.ThrowIfNullOrEmpty();

            this.Title = Title;
            this.Description = Description;
            this.Priority = Priority;
            this.Expiration = Expiration ?? null;
            this.ProjectId = ProjectId.Value;
            Status = TaskStates.Pending;
        }

        public void Update(string? Title, string? Description, TaskPriority? Priority, TaskStates? Status, DateTime? Expiration)
        {
            _ValidationExpired();

            if (Expiration != null)
            {
                this.Expiration = Expiration;
            }

            if (Title != null)
            {
                Title.ThrowIfNullOrEmpty();
                Title.ThrowIfLimitExceeded(TitleLimit);
                this.Title = Title;
            }

            if(Description != null)
            {
                Description.ThrowIfLimitExceeded(DescriptionLimit);
                this.Description = Description;
            }

            if(Priority != null)
            {
                Priority.Value.ThrowIfUndefined();
                this.Priority = Priority.Value;
            }

            if(Status != null)
            {

                Status.Value.ThrowIfUndefined();
                this.Status = Status.Value;
            }
        }

        public void ChangeOwner(Guid? newOwnerId)
        {
            _ValidationExpired();

            newOwnerId.ThrowIfNullOrEmpty();
            OwnerId = newOwnerId;
        }

        public void _ValidationExpired()
        {
            if (Expiration.Expired())
            {
                throw new InvalidOperationException("The task has expired. Cannot modified");
            }
        }
    }
}