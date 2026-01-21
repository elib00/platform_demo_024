namespace ApplicationLibrary
{
    public class Timesheet
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; } = string.Empty;

        //navigational props
        public ServicePlan ServicePlan { get; set; }
    }
}
