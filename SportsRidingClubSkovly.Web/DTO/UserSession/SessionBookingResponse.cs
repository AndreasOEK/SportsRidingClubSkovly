namespace SportsRidingClubSkovly.Web.DTO.UserSession
{
    public record SessionBookingResponse(
        Guid Id,
        Guid UserId,
        byte[] RowVersion
    );
}
