namespace WebApi.QueryFilter
{
    public class TicketQueryFilter
    {
        public int? Id { get; set; }
        public int? ProjectId { get; set; }
        public string TitleOrDescription { get; set; }
    }
}
