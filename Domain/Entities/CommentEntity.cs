using Domain.MethodExtension;

namespace Domain.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; private set; } //Se Asigna EF DB
        public Guid UserId { get; private set; }
        public Guid TaskId { get; private set; }
        public string Text { get; private set; } = string.Empty;

        public UserEntity? Owner { get; private set; }
        public TaskEntity? Task { get; private set; }

        public CommentEntity(Guid? TaskId, Guid? UserId, string Text)
        {
            TaskId.ThrowIfNullOrEmpty();
            UserId.ThrowIfNullOrEmpty();
            Text.ThrowIfNullOrEmpty();

            this.UserId = UserId.Value;
            this.TaskId = TaskId.Value;
            this.Text = Text;
        }
    }
}
