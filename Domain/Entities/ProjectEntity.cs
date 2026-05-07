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
            Title.ThrowIfLimitMax(20);

            Description.ThrowIfLimitMax(1500);

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
                Title.ThrowIfLimitMax(TitleLimit);
                this.Title = Title;
            }

            if (Description != null)
            {
                Description.ThrowIfNullOrEmpty();
                Description.ThrowIfLimitMax(DescriptionLimit);
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
