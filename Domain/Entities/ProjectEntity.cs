using Domain.MethodExtension;

namespace Domain.Entities
{
    public class ProjectEntity
    {
        public Guid Id { get; private set; } //Se asigna en EF DB
        public Guid OwnerId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        //Includes
        public UserEntity? Owner { get; private set; }

        //Const
        private const short TitleLimit = 20;
        private const short DescriptionLimit = 1500;

        public ProjectEntity(string Title, string Description, Guid? OwnerId)
        {
            Title.ThrowIfNullOrEmpty();
            Title.ThrowIfLimitExceeded(20);

            Description.ThrowIfLimitExceeded(1500);

            OwnerId.ThrowIfNullOrEmpty();

            this.Title = Title;
            this.Description = Description;
            this.OwnerId = OwnerId.Value;
        }

        public void Update(string? Title, string? Description)
        {
            if (Title != null)
            {
                Title.ThrowIfNullOrEmpty();
                Title.ThrowIfLimitExceeded(TitleLimit);
                this.Title = Title;
            }

            if (Description != null)
            {
                Description.ThrowIfNullOrEmpty();
                Description.ThrowIfLimitExceeded(DescriptionLimit);
                this.Description = Description;
            }
        }

        public void ChangeOwner(Guid? newOwnerId)
        {
            newOwnerId.ThrowIfNullOrEmpty();

            this.OwnerId = newOwnerId.Value;
        }
    }
}
