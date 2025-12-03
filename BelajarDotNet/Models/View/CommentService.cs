namespace BelajarDotNet.Models
{
    public class CommentService
    {
        public static async Task<List<Comment>> GetRecentCommentsAsync()
        {
            await Task.Delay(500);

            return new List<Comment>
            {
                new Comment()
                {
                    Text = "Thisi Great Post", User="Fauzi",
                },
                new Comment()
                {
                    Text="Very Informative, thanks for sharing", User="Sigit"
                },
                new Comment()
                {
                    Text = " I had similar experience", User= "Egy"
                }
            };
        }
    }
}
