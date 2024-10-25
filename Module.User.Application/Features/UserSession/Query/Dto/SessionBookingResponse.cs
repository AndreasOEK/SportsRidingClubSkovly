namespace Module.User.Application.Features.UserSession.Query.Dto
{
    public record SessionBookingResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
