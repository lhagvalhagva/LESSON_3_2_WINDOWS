namespace LAB__1.Models
{
    public class MemoryItem
    {
        public double value { get; set; }
        // public DateTime savedAt { get; set; }

        public MemoryItem(double value)
        {
            this.value = value;
            // this.savedAt = DateTime.Now;
        }
    }
}